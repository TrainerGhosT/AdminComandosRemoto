using AdminComandos.Core.Services;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdminComandos
{
    public partial class ServerForm : Form
    {
        private readonly StorageService _storageService;
        private readonly Server _existingServer;
        private readonly bool _isEditMode;

        public ServerForm(StorageService storageService, Server existingServer = null)
        {
            InitializeComponent();

            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RemoteCommandExecutor");
            Directory.CreateDirectory(appDataPath);
            string xmlFilePath = Path.Combine(appDataPath, "servers.xml");
            _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
            _existingServer = existingServer;
            _isEditMode = existingServer != null;


            ConfigureForm();
            LoadData();
        }

        private void ConfigureForm()
        {
            Text = _isEditMode ? "Editar Servidor" : "Agregar Servidor";

            if (_isEditMode)
            {
                btnSave.Text = "Actualizar";
            }
        }

        private void LoadData()
        {
            if (_isEditMode && _existingServer != null)
            {
                txtName.Text = _existingServer.Name;
                txtIP.Text = _existingServer.IP;
                txtUsername.Text = _existingServer.Username;
                // No cargar la contraseña por seguridad
                txtPassword.PlaceholderText = "Dejar vacío para mantener contraseña actual";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                (bool success, string message) result;

                if (_isEditMode)
                {
                    result = _storageService.UpdateServer(
                        _existingServer.Id,
                        txtName.Text.Trim(),
                        txtIP.Text.Trim(),
                        txtUsername.Text.Trim(),
                        string.IsNullOrWhiteSpace(txtPassword.Text) ? null : txtPassword.Text
                    );
                }
                else
                {
                    result = _storageService.AddServer(
                        txtName.Text.Trim(),
                        txtIP.Text.Trim(),
                        txtUsername.Text.Trim(),
                        txtPassword.Text.Trim()
                    );
                }

                if (result.success)
                {
                    MessageBox.Show(result.message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(result.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            // Validar nombre
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("El nombre del servidor es requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            // Validar IP
            if (string.IsNullOrWhiteSpace(txtIP.Text))
            {
                MessageBox.Show("La dirección IP es requerida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIP.Focus();
                return false;
            }

            // Validar usuario
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("El nombre de usuario es requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // Validar contraseña (solo para nuevo servidor)
            if (!_isEditMode && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La contraseña es requerida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                Cursor = Cursors.WaitCursor;
                btnTestConnection.Enabled = false;

                // Crear servidor temporal para prueba
                var testServer = new Server(
                    txtName.Text.Trim(),
                    txtIP.Text.Trim(),
                    txtUsername.Text.Trim(),
                    ""  // Password vacío para test, se usará la del textbox
                );

                var sshService = new SshService();

                // Aquí podrías implementar un test de conexión simple
                // Por ahora, solo validamos que los datos no estén vacíos
                MessageBox.Show("Conexión simulada exitosa.\n\nNota: La conexión real se probará al ejecutar comandos.",
                    "Test de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el test de conexión: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnTestConnection.Enabled = true;
            }
        }
    }
}
