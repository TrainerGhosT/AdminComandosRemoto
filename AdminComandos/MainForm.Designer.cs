using Org.BouncyCastle.Asn1.Crmf;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace AdminComandos
{
    partial class MainForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.panelServers = new System.Windows.Forms.Panel();
            this.listViewServers = new System.Windows.Forms.ListView();
            this.panelServerButtons = new System.Windows.Forms.Panel();
            this.btnDeleteServer = new System.Windows.Forms.Button();
            this.btnEditServer = new System.Windows.Forms.Button();
            this.btnAddServer = new System.Windows.Forms.Button();
            this.lblServers = new System.Windows.Forms.Label();
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.listViewCommands = new System.Windows.Forms.ListView();
            this.panelCommandButtons = new System.Windows.Forms.Panel();
            this.btnExecuteCommand = new System.Windows.Forms.Button();
            this.btnDeleteCommand = new System.Windows.Forms.Button();
            this.btnEditCommand = new System.Windows.Forms.Button();
            this.btnAddCommand = new System.Windows.Forms.Button();
            this.lblCommands = new System.Windows.Forms.Label();
            this.panelOutput = new System.Windows.Forms.Panel();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.lblOutput = new System.Windows.Forms.Label();

            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(984, 50);
            this.panelTop.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(984, 50);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Administración de comandos remotos";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 50);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.panelServers);
            this.splitContainerMain.Panel1MinSize = 250;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerRight);
            this.splitContainerMain.Size = new System.Drawing.Size(984, 611);
            this.splitContainerMain.SplitterDistance = 250;
            this.splitContainerMain.TabIndex = 1;
            // 
            // panelServers
            // 
            this.panelServers.Controls.Add(this.listViewServers);
            this.panelServers.Controls.Add(this.panelServerButtons);
            this.panelServers.Controls.Add(this.lblServers);
            this.panelServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelServers.Location = new System.Drawing.Point(0, 0);
            this.panelServers.Name = "panelServers";
            this.panelServers.Padding = new System.Windows.Forms.Padding(10);
            this.panelServers.Size = new System.Drawing.Size(250, 611);
            this.panelServers.TabIndex = 0;
            // 
            // listViewServers
            // 
            this.listViewServers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewServers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listViewServers.FullRowSelect = true;
            this.listViewServers.HideSelection = false;
            this.listViewServers.Location = new System.Drawing.Point(10, 35);
            this.listViewServers.MultiSelect = false;
            this.listViewServers.Name = "listViewServers";
            this.listViewServers.Size = new System.Drawing.Size(230, 516);
            this.listViewServers.TabIndex = 2;
            this.listViewServers.UseCompatibleStateImageBehavior = false;
            this.listViewServers.View = System.Windows.Forms.View.List;
            this.listViewServers.SelectedIndexChanged += new System.EventHandler(this.listViewServers_SelectedIndexChanged);
            // 
            // panelServerButtons
            // 
            this.panelServerButtons.Controls.Add(this.btnDeleteServer);
            this.panelServerButtons.Controls.Add(this.btnEditServer);
            this.panelServerButtons.Controls.Add(this.btnAddServer);
            this.panelServerButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelServerButtons.Location = new System.Drawing.Point(10, 551);
            this.panelServerButtons.Name = "panelServerButtons";
            this.panelServerButtons.Size = new System.Drawing.Size(230, 50);
            this.panelServerButtons.TabIndex = 1;
            // 
            // btnDeleteServer
            // 
            this.btnDeleteServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnDeleteServer.FlatAppearance.BorderSize = 0;
            this.btnDeleteServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteServer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnDeleteServer.Location = new System.Drawing.Point(156, 5);
            this.btnDeleteServer.Name = "btnDeleteServer";
            this.btnDeleteServer.Size = new System.Drawing.Size(40, 40);
            this.btnDeleteServer.TabIndex = 2;
            this.btnDeleteServer.Text = "−";
            this.btnDeleteServer.UseVisualStyleBackColor = false;
            this.btnDeleteServer.Click += new System.EventHandler(this.btnDeleteServer_Click);
            // 
            // btnEditServer
            // 
            this.btnEditServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.btnEditServer.FlatAppearance.BorderSize = 0;
            this.btnEditServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditServer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(120)))));
            this.btnEditServer.Location = new System.Drawing.Point(95, 5);
            this.btnEditServer.Name = "btnEditServer";
            this.btnEditServer.Size = new System.Drawing.Size(40, 40);
            this.btnEditServer.TabIndex = 1;
            this.btnEditServer.Text = "✎";
            this.btnEditServer.UseVisualStyleBackColor = false;
            this.btnEditServer.Click += new System.EventHandler(this.btnEditServer_Click);
            // 
            // btnAddServer
            // 
            this.btnAddServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(240)))), ((int)(((byte)(200)))));
            this.btnAddServer.FlatAppearance.BorderSize = 0;
            this.btnAddServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddServer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(50)))));
            this.btnAddServer.Location = new System.Drawing.Point(34, 5);
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(40, 40);
            this.btnAddServer.TabIndex = 0;
            this.btnAddServer.Text = "+";
            this.btnAddServer.UseVisualStyleBackColor = false;
            this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
            // 
            // lblServers
            // 
            this.lblServers.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblServers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblServers.Location = new System.Drawing.Point(10, 10);
            this.lblServers.Name = "lblServers";
            this.lblServers.Size = new System.Drawing.Size(230, 25);
            this.lblServers.TabIndex = 0;
            this.lblServers.Text = "Servidores disponibles";
            // 
            // splitContainerRight
            // 
            this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRight.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRight.Name = "splitContainerRight";
            this.splitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRight.Panel1
            // 
            this.splitContainerRight.Panel1.Controls.Add(this.panelCommands);
            // 
            // splitContainerRight.Panel2
            // 
            this.splitContainerRight.Panel2.Controls.Add(this.panelOutput);
            this.splitContainerRight.Size = new System.Drawing.Size(730, 611);
            this.splitContainerRight.SplitterDistance = 250;
            this.splitContainerRight.TabIndex = 0;
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.listViewCommands);
            this.panelCommands.Controls.Add(this.panelCommandButtons);
            this.panelCommands.Controls.Add(this.lblCommands);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCommands.Location = new System.Drawing.Point(0, 0);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Padding = new System.Windows.Forms.Padding(10);
            this.panelCommands.Size = new System.Drawing.Size(730, 250);
            this.panelCommands.TabIndex = 0;
            // 
            // listViewCommands
            // 
            this.listViewCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCommands.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listViewCommands.FullRowSelect = true;
            this.listViewCommands.HideSelection = false;
            this.listViewCommands.Location = new System.Drawing.Point(10, 35);
            this.listViewCommands.MultiSelect = false;
            this.listViewCommands.Name = "listViewCommands";
            this.listViewCommands.Size = new System.Drawing.Size(710, 155);
            this.listViewCommands.TabIndex = 2;
            this.listViewCommands.UseCompatibleStateImageBehavior = false;
            this.listViewCommands.View = System.Windows.Forms.View.List;
            this.listViewCommands.SelectedIndexChanged += new System.EventHandler(this.listViewCommands_SelectedIndexChanged);
            // 
            // panelCommandButtons
            // 
            this.panelCommandButtons.Controls.Add(this.btnExecuteCommand);
            this.panelCommandButtons.Controls.Add(this.btnDeleteCommand);
            this.panelCommandButtons.Controls.Add(this.btnEditCommand);
            this.panelCommandButtons.Controls.Add(this.btnAddCommand);
            this.panelCommandButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommandButtons.Location = new System.Drawing.Point(10, 190);
            this.panelCommandButtons.Name = "panelCommandButtons";
            this.panelCommandButtons.Size = new System.Drawing.Size(710, 50);
            this.panelCommandButtons.TabIndex = 1;
            // 
            // btnExecuteCommand
            // 
            this.btnExecuteCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(250)))));
            this.btnExecuteCommand.FlatAppearance.BorderSize = 0;
            this.btnExecuteCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecuteCommand.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExecuteCommand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(120)))));
            this.btnExecuteCommand.Location = new System.Drawing.Point(417, 5);
            this.btnExecuteCommand.Name = "btnExecuteCommand";
            this.btnExecuteCommand.Size = new System.Drawing.Size(155, 40);
            this.btnExecuteCommand.TabIndex = 3;
            this.btnExecuteCommand.Text = "▶ Ejecutar";
            this.btnExecuteCommand.UseVisualStyleBackColor = false;
            this.btnExecuteCommand.Click += new System.EventHandler(this.btnExecuteCommand_Click);
            // 
            // btnDeleteCommand
            // 
            this.btnDeleteCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnDeleteCommand.FlatAppearance.BorderSize = 0;
            this.btnDeleteCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCommand.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteCommand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnDeleteCommand.Location = new System.Drawing.Point(156, 5);
            this.btnDeleteCommand.Name = "btnDeleteCommand";
            this.btnDeleteCommand.Size = new System.Drawing.Size(40, 40);
            this.btnDeleteCommand.TabIndex = 2;
            this.btnDeleteCommand.Text = "−";
            this.btnDeleteCommand.UseVisualStyleBackColor = false;
            this.btnDeleteCommand.Click += new System.EventHandler(this.btnDeleteCommand_Click);
            // 
            // btnEditCommand
            // 
            this.btnEditCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.btnEditCommand.FlatAppearance.BorderSize = 0;
            this.btnEditCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCommand.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditCommand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(120)))));
            this.btnEditCommand.Location = new System.Drawing.Point(95, 5);
            this.btnEditCommand.Name = "btnEditCommand";
            this.btnEditCommand.Size = new System.Drawing.Size(40, 40);
            this.btnEditCommand.TabIndex = 1;
            this.btnEditCommand.Text = "✎";
            this.btnEditCommand.UseVisualStyleBackColor = false;
            this.btnEditCommand.Click += new System.EventHandler(this.btnEditCommand_Click);
            // 
            // btnAddCommand
            // 
            this.btnAddCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(240)))), ((int)(((byte)(200)))));
            this.btnAddCommand.FlatAppearance.BorderSize = 0;
            this.btnAddCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCommand.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddCommand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(50)))));
            this.btnAddCommand.Location = new System.Drawing.Point(34, 5);
            this.btnAddCommand.Name = "btnAddCommand";
            this.btnAddCommand.Size = new System.Drawing.Size(40, 40);
            this.btnAddCommand.TabIndex = 0;
            this.btnAddCommand.Text = "+";
            this.btnAddCommand.UseVisualStyleBackColor = false;
            this.btnAddCommand.Click += new System.EventHandler(this.btnAddCommand_Click);
            // 
            // lblCommands
            // 
            this.lblCommands.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCommands.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCommands.Location = new System.Drawing.Point(10, 10);
            this.lblCommands.Name = "lblCommands";
            this.lblCommands.Size = new System.Drawing.Size(710, 25);
            this.lblCommands.TabIndex = 0;
            this.lblCommands.Text = "Comandos del servidor";
            // 
            // panelOutput
            // 
            this.panelOutput.Controls.Add(this.txtOutput);
            this.panelOutput.Controls.Add(this.lblOutput);
            this.panelOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutput.Location = new System.Drawing.Point(0, 0);
            this.panelOutput.Name = "panelOutput";
            this.panelOutput.Padding = new System.Windows.Forms.Padding(10);
            this.panelOutput.Size = new System.Drawing.Size(730, 357);
            this.panelOutput.TabIndex = 0;
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOutput.ForeColor = System.Drawing.Color.White;
            this.txtOutput.Location = new System.Drawing.Point(10, 35);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(710, 312);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.Text = "";
            // 
            // lblOutput
            // 
            this.lblOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOutput.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOutput.Location = new System.Drawing.Point(10, 10);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(710, 25);
            this.lblOutput.TabIndex = 0;
            this.lblOutput.Text = "Salida de comandos";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de comandos remotos";
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.panelServers.ResumeLayout(false);
            this.panelServerButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel2.ResumeLayout(false);
            this.splitContainerRight.ResumeLayout(false);
            this.panelCommands.ResumeLayout(false);
            this.panelCommandButtons.ResumeLayout(false);
            this.panelOutput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel panelServers;
        private System.Windows.Forms.ListView listViewServers;
        private System.Windows.Forms.Panel panelServerButtons;
        private System.Windows.Forms.Button btnDeleteServer;
        private System.Windows.Forms.Button btnEditServer;
        private System.Windows.Forms.Button btnAddServer;
        private System.Windows.Forms.Label lblServers;
        private System.Windows.Forms.SplitContainer splitContainerRight;
        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.ListView listViewCommands;
        private System.Windows.Forms.Panel panelCommandButtons;
        private System.Windows.Forms.Button btnExecuteCommand;
        private System.Windows.Forms.Button btnDeleteCommand;
        private System.Windows.Forms.Button btnEditCommand;
        private System.Windows.Forms.Button btnAddCommand;
        private System.Windows.Forms.Label lblCommands;
        private System.Windows.Forms.Panel panelOutput;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Label lblOutput;
    }

}