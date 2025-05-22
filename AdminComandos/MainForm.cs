using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using Core.Models;
using AdminComandos.Core.Interfaces;
using AdminComandos.Core.Services;
using AdminComandos.Core.Repositories;
using AdminComandos.Core.Utils;
using static Org.BouncyCastle.Math.Primes;

namespace AdminComandos
{
    public partial class MainForm : Form
    {
        private readonly StorageService _storageService;
        private readonly SshService _sshService;

        public MainForm()
        {
            InitializeComponent();

            string projectPath = GetProjectDirectory();
            string dataPath = Path.Combine(projectPath, "../Data");
            Directory.CreateDirectory(dataPath);

            var repository = new XMLRepository(dataPath);
            _storageService = new StorageService(repository);

            // Crear el factory y pasarlo al servicio SSH
            var sshClientFactory = new SshClientFactory();
            _sshService = new SshService(sshClientFactory);

            ConfigureListViews();
            LoadServers();
        }

        /// <summary>
        /// Obtiene la carpeta del proyecto (donde está el ejecutable)
        /// </summary>
        /// <returns>Ruta de la carpeta del proyecto</returns>
        private string GetProjectDirectory()
        {
            // Obtener la carpeta donde está el ejecutable
            string exePath = Application.ExecutablePath;
            string exeDirectory = Path.GetDirectoryName(exePath);

            // Si estamos en modo Debug/Release, subir hasta encontrar la carpeta del proyecto
            DirectoryInfo directory = new DirectoryInfo(exeDirectory);

            // Buscar hacia arriba hasta encontrar archivos de proyecto (.csproj, .sln)
            while (directory != null && !HasProjectFiles(directory))
            {
                directory = directory.Parent;
            }

            // Si encontramos la carpeta del proyecto, usarla; si no, usar la carpeta del ejecutable
            return directory?.FullName ?? exeDirectory;
        }

        /// <summary>
        /// Verifica si la carpeta contiene archivos de proyecto
        /// </summary>
        /// <param name="directory">Directorio a verificar</param>
        /// <returns>True si contiene archivos de proyecto</returns>
        private bool HasProjectFiles(DirectoryInfo directory)
        {
            return directory.GetFiles("*.csproj").Length > 0 ||
                   directory.GetFiles("*.sln").Length > 0 ||
                   directory.GetDirectories("bin").Length > 0;
        }

        private void ConfigureListViews()
        {
            // Configurar ListView de servidores
            List_Servers.View = View.Details;
            List_Servers.FullRowSelect = true;
            List_Servers.GridLines = true;
            List_Servers.Columns.Clear();
            List_Servers.Columns.Add("Nombre", 120, HorizontalAlignment.Left);
            List_Servers.Columns.Add("IP", 100, HorizontalAlignment.Left);
            List_Servers.Columns.Add("Usuario", 100, HorizontalAlignment.Left);

            // Configurar ListView de comandos
            List_Comandos.View = View.Details;
            List_Comandos.FullRowSelect = true;
            List_Comandos.GridLines = true;
            List_Comandos.Columns.Clear();
            List_Comandos.Columns.Add("ID", 50, HorizontalAlignment.Left);
            List_Comandos.Columns.Add("Comando", 300, HorizontalAlignment.Left);

            // Eventos
            List_Servers.SelectedIndexChanged += List_Servers_SelectedIndexChanged;
            List_Comandos.SelectedIndexChanged += List_Comandos_SelectedIndexChanged;
        }

        private void LoadServers()
        {
            try
            {
                var servers = _storageService.GetAllServers();

                List_Servers.Items.Clear();
                foreach (var server in servers)
                {
                    var item = new ListViewItem(new[]
                    {
                        server.Name,
                        server.IP,
                        server.Username
                    })
                    { Tag = server };
                    List_Servers.Items.Add(item);
                }

                // Limpiar comandos si no hay servidor seleccionado
                if (List_Servers.SelectedItems.Count == 0)
                {
                    List_Comandos.Items.Clear();
                }

                UpdateStatusBar($"Servidores cargados correctamente. Total: {servers.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando servidores: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatusBar("Error cargando servidores.");
            }
        }

        private void LoadCommandsForSelectedServer()
        {
            List_Comandos.Items.Clear();

            if (List_Servers.SelectedItems.Count == 0)
                return;

            try
            {
                var selectedServer = (Server)List_Servers.SelectedItems[0].Tag;
                var commands = _storageService.GetCommandsByServerId(selectedServer.Id);

                foreach (var command in commands)
                {
                    var item = new ListViewItem(new[]
                    {
                        command.Id.ToString().Substring(0, 8) + "...",
                        command.Text
                    })
                    { Tag = command };
                    List_Comandos.Items.Add(item);
                }

                UpdateStatusBar($"Comandos cargados para servidor: {selectedServer.Name} ({commands.Count} comandos)");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando comandos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatusBar("Error cargando comandos.");
            }
        }

        private void List_Servers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCommandsForSelectedServer();
            UpdateButtonStates();
        }

        private void List_Comandos_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool serverSelected = List_Servers.SelectedItems.Count > 0;
            bool commandSelected = List_Comandos.SelectedItems.Count > 0;

            Btn_EditarServidor.Enabled = serverSelected;
            Btn_EliminarServidor.Enabled = serverSelected;
            Btn_EditarComand.Enabled = commandSelected;
            Btn_EliminarCommand.Enabled = commandSelected; // Botón eliminar comando
            Btn_Iniciar.Enabled = serverSelected && commandSelected;

            // Habilitar botón de agregar comando solo si hay servidor seleccionado
            Btn_AnadirComand.Enabled = serverSelected;
        }

        private void UpdateStatusBar(string message)
        {
            tslBitacora.Text = $"Estado: {message}";
        }

        #region Eventos de Botones de Servidor

        private void Btn_AnadirServidor_Click(object sender, EventArgs e)
        {
            using var form = new ServerForm(_storageService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadServers();
                UpdateStatusBar("Servidor agregado correctamente.");
            }
        }

        private void Btn_EditarServidor_Click(object sender, EventArgs e)
        {
            if (List_Servers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un servidor para editar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedServer = (Server)List_Servers.SelectedItems[0].Tag;
            using var form = new ServerForm(_storageService, selectedServer);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadServers();
                UpdateStatusBar("Servidor modificado correctamente.");
            }
        }

        private void Btn_EliminarServidor_Click(object sender, EventArgs e)
        {
            if (List_Servers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un servidor para eliminar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedServer = (Server)List_Servers.SelectedItems[0].Tag;
            var result = MessageBox.Show(
                $"¿Está seguro de eliminar el servidor '{selectedServer.Name}'?\n\nEsta acción eliminará también todos los comandos asociados.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var (success, message) = _storageService.DeleteServer(selectedServer.Id);
                if (success)
                {
                    LoadServers();
                    UpdateStatusBar("Servidor eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show($"Error eliminando servidor: {message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateStatusBar("Error eliminando servidor.");
                }
            }
        }

        #endregion

        #region Eventos de Botones de Comando

        private void Btn_AnadirComand_Click(object sender, EventArgs e)
        {
            if (List_Servers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un servidor primero.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedServer = (Server)List_Servers.SelectedItems[0].Tag;

            using var form = new CommandForm(_storageService, selectedServer.Id);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadCommandsForSelectedServer();
                UpdateStatusBar("Comando agregado correctamente.");
            }
        }

        private void Btn_EditarComand_Click(object sender, EventArgs e)
        {
            if (List_Comandos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un comando para editar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCommand = (Commands)List_Comandos.SelectedItems[0].Tag;

            using var form = new CommandForm(_storageService, selectedCommand);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadCommandsForSelectedServer();
                UpdateStatusBar("Comando modificado correctamente.");
            }
        }

        private void Btn_EliminarCommand_Click(object sender, EventArgs e) // Eliminar comando
        {
            if (List_Comandos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un comando para eliminar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCommand = (Commands)List_Comandos.SelectedItems[0].Tag;
            var result = MessageBox.Show(
                $"¿Está seguro de eliminar el comando '{selectedCommand.Text}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var (success, message) = _storageService.DeleteCommand(selectedCommand.Id);
                if (success)
                {
                    LoadCommandsForSelectedServer();
                    UpdateStatusBar("Comando eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show($"Error eliminando comando: {message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateStatusBar("Error eliminando comando.");
                }
            }
        }

        #endregion

        #region Ejecución de Comandos

        private void Btn_Iniciar_Click(object sender, EventArgs e)
        {
            if (List_Servers.SelectedItems.Count == 0 || List_Comandos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un servidor y un comando.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedServer = (Server)List_Servers.SelectedItems[0].Tag;
            var selectedCommand = (Commands)List_Comandos.SelectedItems[0].Tag;

            ExecuteCommand(selectedServer, selectedCommand);
        }

        private async void ExecuteCommand(Server server, Commands command)
        {
            try
            {
                UpdateStatusBar($"Ejecutando '{command.Text}' en {server.Name}...");

                Txt_Resultados.Clear();
                Txt_Resultados.AppendText($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Servidor: {server.Name} ({server.IP})\r\n");
                Txt_Resultados.AppendText($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Comando: {command.Text}\r\n");
                Txt_Resultados.AppendText($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Ejecutando...\r\n");
                Txt_Resultados.AppendText(new string('-', 50) + "\r\n");

                Btn_Iniciar.Enabled = false;
                Cursor = Cursors.WaitCursor;

                string result = await Task.Run(() => _sshService.ExecuteCommand(server, command.Text));

                Txt_Resultados.AppendText(result);
                Txt_Resultados.AppendText("\r\n" + new string('-', 50) + "\r\n");
                Txt_Resultados.AppendText($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Comando completado.\r\n");

                UpdateStatusBar($"Comando '{command.Text}' ejecutado correctamente en {server.Name}:{server.IP}.");
            }
            catch (Exception ex)
            {
                Txt_Resultados.AppendText($"\r\n[ERROR] {ex.Message}\r\n");
                Txt_Resultados.AppendText($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Comando falló.\r\n");
                UpdateStatusBar($"Error ejecutando comando: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
                UpdateButtonStates();
            }
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateButtonStates();
            UpdateStatusBar("Aplicación iniciada correctamente.");
        }
    }
}