using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private readonly XMLRepository _repository;
        private readonly StorageService _storageService;
        private readonly SshService _sshService;
        private List<Server> _servers;
        private Server _selectedServer;
        private Commands _selectedCommand;

        // Iconos para la interfaz
        private readonly ImageList _serverIconList;

        public MainForm()
        {
            InitializeComponent();

            // Configuración del repositorio y servicios
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RemoteCommandExecutor");
            Directory.CreateDirectory(appDataPath);
            string xmlFilePath = Path.Combine(appDataPath, "servers.xml");

            _repository = new XMLRepository(xmlFilePath);
            _storageService = new StorageService(_repository);
            _sshService = new SshService();

            // Inicializar listas
            _servers = new List<Server>();

            // Configurar iconos
            _serverIconList = new ImageList();
            _serverIconList.ColorDepth = ColorDepth.Depth32Bit;
            _serverIconList.ImageSize = new Size(32, 32);
            LoadIcons();

            // Cargar datos al iniciar
            LoadServers();
        }

        private void LoadIcons()
        {
            // Agregar íconos al ImageList
            // En un proyecto real, estos íconos vendrían de recursos embebidos
            _serverIconList.Images.Add("server_add", GetServerIcon(Color.LightGreen));
            _serverIconList.Images.Add("server_remove", GetServerIcon(Color.LightCoral));
            _serverIconList.Images.Add("server_ok", GetServerIcon(Color.LightBlue));

            // Asignar a ListView
            listViewServers.SmallImageList = _serverIconList;
        }

        // Método auxiliar para crear íconos simples para esta demostración
        private Bitmap GetServerIcon(Color color)
        {
            var bitmap = new Bitmap(32, 32);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
                g.FillRectangle(new SolidBrush(color), 5, 5, 22, 22);
                g.DrawRectangle(new Pen(Color.Black), 5, 5, 22, 22);
            }
            return bitmap;
        }

        private void LoadServers()
        {
            try
            {
                _servers = _storageService.GetAllServers();
                RefreshServerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar servidores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshServerList()
        {
            listViewServers.Items.Clear();
            foreach (var server in _servers)
            {
                var item = new ListViewItem
                {
                    Text = server.Name,
                    Tag = server,
                    ImageKey = "server_ok" // Icono por defecto
                };
                listViewServers.Items.Add(item);
            }
        }

        private void RefreshCommandList()
        {
            listViewCommands.Items.Clear();

            if (_selectedServer != null)
            {
                foreach (var command in _selectedServer.Commands)
                {
                    var item = new ListViewItem
                    {
                        Text = command.Text,
                        Tag = command
                    };
                    listViewCommands.Items.Add(item);
                }
            }
        }

        #region Eventos de la interfaz

        private void btnAddServer_Click(object sender, EventArgs e)
        {
            //using (var form = new ServerForm())
            //{
            //    if (form.ShowDialog() == DialogResult.OK)
            //    {
            //        // Crear y agregar nuevo servidor
            //        var server = new Server
            //        {
            //            Id = Guid.NewGuid(),
            //            Name = form.,
            //            IP = form.ServerIp,
            //            Username = form.ServerUsername,
            //            EncryptedPassword = EncryptionHelper.Encrypt(form.ServerPassword),
            //            Comandos = new List<comandos>()
            //        };

            //        _servers.Add(server);
            //        _storageService.SaveServers(_servers);
            //        RefreshServerList();

            //        MessageBox.Show("Se ha agregado un nuevo servidor", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void btnEditServer_Click(object sender, EventArgs e)
        {
            if (_selectedServer == null)
            {
                MessageBox.Show("Por favor seleccione un servidor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //using (var form = new ServerForm(_selectedServer))
            //{
            //    if (form.ShowDialog() == DialogResult.OK)
            //    {
            //        // Actualizar propiedades del servidor
            //        _selectedServer.Name = form.ServerName;
            //        _selectedServer.IP = form.ServerIp;
            //        _selectedServer.Username = form.ServerUsername;
            //        if (!string.IsNullOrEmpty(form.ServerPassword))
            //        {
            //            _selectedServer.EncryptedPassword = EncryptionHelper.Encrypt(form.ServerPassword);
            //        }

            //        _storageService.SaveServers(_servers);
            //        RefreshServerList();

            //        MessageBox.Show("Se ha modificado la información del servidor", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void btnDeleteServer_Click(object sender, EventArgs e)
        {
            if (_selectedServer == null)
            {
                MessageBox.Show("Por favor seleccione un servidor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("¿Desea eliminar el servidor?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _servers.Remove(_selectedServer);
                _storageService.DeleteServer(_selectedServer.Id);
                _selectedServer = null;
                RefreshServerList();
                RefreshCommandList(); // Limpiar comandos
            }
        }

        private void btnAddCommand_Click(object sender, EventArgs e)
        {
            if (_selectedServer == null)
            {
                MessageBox.Show("Por favor seleccione un servidor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //using (var form = new CommandForm())
            //{
            //    if (form.ShowDialog() == DialogResult.OK)
            //    {
            //        var command = new Commands
            //        {
            //            Id = Guid.NewGuid(),
            //            ServerId = _selectedServer.Id,
            //            Text = form.CommandText
            //        };

            //        _selectedServer.Commands.Add(command);
            //        _storageService.AddCommand(_selectedCommand.ServerId, _selectedCommand.Text);
            //        RefreshCommandList();

            //        MessageBox.Show("Se ha agregado un nuevo comando", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void btnEditCommand_Click(object sender, EventArgs e)
        {
            if (_selectedCommand == null)
            {
                MessageBox.Show("Por favor seleccione un comando", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //using (var form = new CommandForm(_selectedCommand))
            //{
            //    if (form.ShowDialog() == DialogResult.OK)
            //    {
            //        _selectedCommand.Text = form.CommandText;
            //        _storageService.AddServer(_selectedServer.Name, _selectedServer.IP, _selectedServer.Username, _selectedServer.EncryptedPassword);
            //        RefreshCommandList();

            //        MessageBox.Show("Se ha modificado la información del comando", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void btnDeleteCommand_Click(object sender, EventArgs e)
        {
            if (_selectedCommand == null)
            {
                MessageBox.Show("Por favor seleccione un comando", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("¿Desea eliminar el comando?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _selectedServer.Commands.Remove(_selectedCommand);
                // _storageService.(_servers);
                
                _selectedCommand = null;
                RefreshCommandList();
            }
        }

        private void btnExecuteCommand_Click(object sender, EventArgs e)
        {
            if (_selectedServer == null || _selectedCommand == null)
            {
                MessageBox.Show("Por favor seleccione el servidor y comando que desea ejecutar",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtOutput.AppendText($"Ejecutando en {_selectedServer.Name} ({_selectedServer.IP}): {_selectedCommand.Text}\r\n");
            txtOutput.AppendText("----------------------------------------\r\n");

            try
            {
                Cursor = Cursors.WaitCursor;

                // Ejecutar comando SSH
                string result = _sshService.ExecuteCommand(_selectedServer, _selectedCommand.Text);

                txtOutput.AppendText(result);
                txtOutput.AppendText("\r\n----------------------------------------\r\n");
            }
            catch (Exception ex)
            {
                txtOutput.AppendText($"ERROR: {ex.Message}\r\n");
                txtOutput.AppendText("----------------------------------------\r\n");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void listViewServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewServers.SelectedItems.Count > 0)
            {
                _selectedServer = (Server)listViewServers.SelectedItems[0].Tag;
                _selectedCommand = null;
                RefreshCommandList();
            }
            else
            {
                _selectedServer = null;
                listViewCommands.Items.Clear();
            }
        }

        private void listViewCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCommands.SelectedItems.Count > 0)
            {
                _selectedCommand = (Commands)listViewCommands.SelectedItems[0].Tag;
            }
            else
            {
                _selectedCommand = null;
            }
        }

        #endregion
    }
}