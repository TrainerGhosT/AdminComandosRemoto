using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AdminComandos.Core.Services;
using Core.Models;

namespace AdminComandos
{
    public partial class CommandForm : Form
    {
        private readonly StorageService _storageService;
        private readonly Commands _existingCommand;
        private readonly Guid? _serverId;
        private readonly bool _isEditMode;

        // Constructor para agregar comando nuevo
        public CommandForm(StorageService storageService, Guid serverId)
        {
            InitializeComponent();
            _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
            _serverId = serverId;
            _isEditMode = false;
            ConfigureForm();
        }

        // Constructor para editar comando existente
        public CommandForm(StorageService storageService, Commands existingCommand)
        {
            InitializeComponent();
            _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
            _existingCommand = existingCommand ?? throw new ArgumentNullException(nameof(existingCommand));
            _isEditMode = true;
            ConfigureForm();
            LoadData();
        }

        private void ConfigureForm()
        {
            Text = _isEditMode ? "Editar Comando" : "Agregar Comando";

            if (_isEditMode)
            {
                btnSave.Text = "Actualizar";
            }
        }

        private void LoadData()
        {
            if (_isEditMode && _existingCommand != null)
            {
                txtCommandText.Text = _existingCommand.Text;
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
                    result = _storageService.UpdateCommand(_existingCommand.Id, txtCommandText.Text.Trim());
                }
                else
                {
                    result = _storageService.AddCommand(_serverId.Value, txtCommandText.Text.Trim());
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
            if (string.IsNullOrWhiteSpace(txtCommandText.Text))
            {
                MessageBox.Show("El texto del comando es requerido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCommandText.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
