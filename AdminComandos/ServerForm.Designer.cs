namespace AdminComandos
{
    partial class ServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            txtName = new TextBox();
            lblIP = new Label();
            txtIP = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            btnTestConnection = new Button();
            groupBoxCredentials = new GroupBox();
            groupBoxConnection = new GroupBox();
            groupBoxCredentials.SuspendLayout();
            groupBoxConnection.SuspendLayout();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(14, 33);
            lblName.Name = "lblName";
            lblName.Size = new Size(67, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Nombre:";
            // 
            // txtName
            // 
            txtName.Location = new Point(109, 28);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(228, 27);
            txtName.TabIndex = 1;
            // 
            // lblIP
            // 
            lblIP.AutoSize = true;
            lblIP.Location = new Point(14, 72);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(91, 20);
            lblIP.TabIndex = 2;
            lblIP.Text = "Dirección IP:";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(109, 72);
            txtIP.Margin = new Padding(3, 4, 3, 4);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(228, 27);
            txtIP.TabIndex = 3;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(14, 33);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(62, 20);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Usuario:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(106, 26);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(228, 27);
            txtUsername.TabIndex = 5;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(14, 72);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(86, 20);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Contraseña:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(106, 69);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(228, 27);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(178, 280);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(86, 40);
            btnSave.TabIndex = 3;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(271, 280);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 40);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnTestConnection
            // 
            btnTestConnection.Location = new Point(14, 280);
            btnTestConnection.Margin = new Padding(3, 4, 3, 4);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(137, 40);
            btnTestConnection.TabIndex = 2;
            btnTestConnection.Text = "Probar Conexión";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // groupBoxCredentials
            // 
            groupBoxCredentials.Controls.Add(lblUsername);
            groupBoxCredentials.Controls.Add(txtUsername);
            groupBoxCredentials.Controls.Add(lblPassword);
            groupBoxCredentials.Controls.Add(txtPassword);
            groupBoxCredentials.Location = new Point(14, 144);
            groupBoxCredentials.Margin = new Padding(3, 4, 3, 4);
            groupBoxCredentials.Name = "groupBoxCredentials";
            groupBoxCredentials.Padding = new Padding(3, 4, 3, 4);
            groupBoxCredentials.Size = new Size(343, 120);
            groupBoxCredentials.TabIndex = 1;
            groupBoxCredentials.TabStop = false;
            groupBoxCredentials.Text = "Credenciales SSH";
            // 
            // groupBoxConnection
            // 
            groupBoxConnection.Controls.Add(lblName);
            groupBoxConnection.Controls.Add(txtName);
            groupBoxConnection.Controls.Add(lblIP);
            groupBoxConnection.Controls.Add(txtIP);
            groupBoxConnection.Location = new Point(14, 16);
            groupBoxConnection.Margin = new Padding(3, 4, 3, 4);
            groupBoxConnection.Name = "groupBoxConnection";
            groupBoxConnection.Padding = new Padding(3, 4, 3, 4);
            groupBoxConnection.Size = new Size(343, 120);
            groupBoxConnection.TabIndex = 0;
            groupBoxConnection.TabStop = false;
            groupBoxConnection.Text = "Información del Servidor";
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 336);
            Controls.Add(groupBoxConnection);
            Controls.Add(groupBoxCredentials);
            Controls.Add(btnTestConnection);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Servidor";
            groupBoxCredentials.ResumeLayout(false);
            groupBoxCredentials.PerformLayout();
            groupBoxConnection.ResumeLayout(false);
            groupBoxConnection.PerformLayout();
            ResumeLayout(false);
        }

        private Label lblName;
        private TextBox txtName;
        private Label lblIP;
        private TextBox txtIP;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnSave;
        private Button btnCancel;
        private Button btnTestConnection;
        private GroupBox groupBoxCredentials;
        private GroupBox groupBoxConnection;
    }

    #endregion
}
