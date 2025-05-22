using Org.BouncyCastle.Asn1.Crmf;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace AdminComandos
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            Btn_EliminarServidor = new Button();
            Btn_EditarServidor = new Button();
            Btn_AnadirServidor = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            List_Comandos = new ListView();
            panel2 = new Panel();
            Btn_EliminarCommand = new Button();
            Btn_EditarComand = new Button();
            Btn_Iniciar = new Button();
            Btn_AnadirComand = new Button();
            Txt_Resultados = new TextBox();
            statusStrip1 = new StatusStrip();
            tslBitacora = new ToolStripStatusLabel();
            List_Servers = new ListView();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Btn_EliminarServidor);
            panel1.Controls.Add(Btn_EditarServidor);
            panel1.Controls.Add(Btn_AnadirServidor);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(389, 131);
            panel1.TabIndex = 0;
            // 
            // Btn_EliminarServidor
            // 
            Btn_EliminarServidor.BackColor = Color.Transparent;
            Btn_EliminarServidor.BackgroundImage = (System.Drawing.Image)resources.GetObject("Btn_EliminarServidor.BackgroundImage");
            Btn_EliminarServidor.BackgroundImageLayout = ImageLayout.Zoom;
            Btn_EliminarServidor.FlatStyle = FlatStyle.Popup;
            Btn_EliminarServidor.ForeColor = Color.Transparent;
            Btn_EliminarServidor.Location = new Point(277, 36);
            Btn_EliminarServidor.Margin = new Padding(3, 4, 3, 4);
            Btn_EliminarServidor.Name = "Btn_EliminarServidor";
            Btn_EliminarServidor.Size = new Size(86, 91);
            Btn_EliminarServidor.TabIndex = 9;
            Btn_EliminarServidor.UseVisualStyleBackColor = false;
            Btn_EliminarServidor.Click += Btn_EliminarServidor_Click;
            // 
            // Btn_EditarServidor
            // 
            Btn_EditarServidor.BackColor = Color.Transparent;
            Btn_EditarServidor.BackgroundImage = (System.Drawing.Image)resources.GetObject("Btn_EditarServidor.BackgroundImage");
            Btn_EditarServidor.BackgroundImageLayout = ImageLayout.Zoom;
            Btn_EditarServidor.FlatStyle = FlatStyle.Popup;
            Btn_EditarServidor.ForeColor = Color.Transparent;
            Btn_EditarServidor.Location = new Point(154, 36);
            Btn_EditarServidor.Margin = new Padding(3, 4, 3, 4);
            Btn_EditarServidor.Name = "Btn_EditarServidor";
            Btn_EditarServidor.Size = new Size(86, 91);
            Btn_EditarServidor.TabIndex = 8;
            Btn_EditarServidor.UseVisualStyleBackColor = false;
            Btn_EditarServidor.Click += Btn_EditarServidor_Click;
            // 
            // Btn_AnadirServidor
            // 
            Btn_AnadirServidor.BackColor = Color.Transparent;
            Btn_AnadirServidor.BackgroundImage = Properties.Resources.anadir;
            Btn_AnadirServidor.BackgroundImageLayout = ImageLayout.Zoom;
            Btn_AnadirServidor.FlatStyle = FlatStyle.Popup;
            Btn_AnadirServidor.ForeColor = Color.Transparent;
            Btn_AnadirServidor.Location = new Point(24, 36);
            Btn_AnadirServidor.Margin = new Padding(3, 4, 3, 4);
            Btn_AnadirServidor.Name = "Btn_AnadirServidor";
            Btn_AnadirServidor.Size = new Size(86, 91);
            Btn_AnadirServidor.TabIndex = 7;
            Btn_AnadirServidor.UseVisualStyleBackColor = false;
            Btn_AnadirServidor.Click += Btn_AnadirServidor_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(158, 20);
            label1.TabIndex = 0;
            label1.Text = "Servidores disponibles";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(List_Comandos);
            groupBox1.Controls.Add(panel2);
            groupBox1.Location = new Point(395, 0);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(523, 320);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Comandos del servidor";
            // 
            // List_Comandos
            // 
            List_Comandos.Location = new Point(7, 107);
            List_Comandos.Margin = new Padding(3, 4, 3, 4);
            List_Comandos.Name = "List_Comandos";
            List_Comandos.Size = new Size(509, 204);
            List_Comandos.TabIndex = 3;
            List_Comandos.UseCompatibleStateImageBehavior = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(Btn_EliminarCommand);
            panel2.Controls.Add(Btn_EditarComand);
            panel2.Controls.Add(Btn_Iniciar);
            panel2.Controls.Add(Btn_AnadirComand);
            panel2.Location = new Point(7, 23);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(510, 76);
            panel2.TabIndex = 2;
            // 
            // Btn_EliminarCommand
            // 
            Btn_EliminarCommand.BackColor = Color.Transparent;
            Btn_EliminarCommand.BackgroundImage = (System.Drawing.Image)resources.GetObject("Btn_EliminarCommand.BackgroundImage");
            Btn_EliminarCommand.BackgroundImageLayout = ImageLayout.Zoom;
            Btn_EliminarCommand.FlatStyle = FlatStyle.Popup;
            Btn_EliminarCommand.ForeColor = Color.Transparent;
            Btn_EliminarCommand.Location = new Point(194, 7);
            Btn_EliminarCommand.Margin = new Padding(3, 4, 3, 4);
            Btn_EliminarCommand.Name = "Btn_EliminarCommand";
            Btn_EliminarCommand.Size = new Size(66, 65);
            Btn_EliminarCommand.TabIndex = 10;
            Btn_EliminarCommand.UseVisualStyleBackColor = false;
            Btn_EliminarCommand.Click += Btn_EliminarCommand_Click;
            // 
            // Btn_EditarComand
            // 
            Btn_EditarComand.BackColor = Color.Transparent;
            Btn_EditarComand.BackgroundImage = (System.Drawing.Image)resources.GetObject("Btn_EditarComand.BackgroundImage");
            Btn_EditarComand.BackgroundImageLayout = ImageLayout.Zoom;
            Btn_EditarComand.FlatStyle = FlatStyle.Popup;
            Btn_EditarComand.ForeColor = Color.Transparent;
            Btn_EditarComand.Location = new Point(100, 7);
            Btn_EditarComand.Margin = new Padding(3, 4, 3, 4);
            Btn_EditarComand.Name = "Btn_EditarComand";
            Btn_EditarComand.Size = new Size(66, 65);
            Btn_EditarComand.TabIndex = 9;
            Btn_EditarComand.UseVisualStyleBackColor = false;
            Btn_EditarComand.Click += Btn_EditarComand_Click;
            // 
            // Btn_Iniciar
            // 
            Btn_Iniciar.BackColor = Color.Transparent;
            Btn_Iniciar.BackgroundImage = (System.Drawing.Image)resources.GetObject("Btn_Iniciar.BackgroundImage");
            Btn_Iniciar.BackgroundImageLayout = ImageLayout.Zoom;
            Btn_Iniciar.FlatStyle = FlatStyle.Popup;
            Btn_Iniciar.ForeColor = Color.Transparent;
            Btn_Iniciar.Location = new Point(432, 7);
            Btn_Iniciar.Margin = new Padding(3, 4, 3, 4);
            Btn_Iniciar.Name = "Btn_Iniciar";
            Btn_Iniciar.Size = new Size(66, 65);
            Btn_Iniciar.TabIndex = 8;
            Btn_Iniciar.UseVisualStyleBackColor = false;
            Btn_Iniciar.Click += Btn_Iniciar_Click;
            // 
            // Btn_AnadirComand
            // 
            Btn_AnadirComand.BackColor = Color.Transparent;
            Btn_AnadirComand.BackgroundImage = Properties.Resources.agregar;
            Btn_AnadirComand.BackgroundImageLayout = ImageLayout.Zoom;
            Btn_AnadirComand.FlatStyle = FlatStyle.Popup;
            Btn_AnadirComand.ForeColor = Color.Transparent;
            Btn_AnadirComand.Location = new Point(3, 7);
            Btn_AnadirComand.Margin = new Padding(3, 4, 3, 4);
            Btn_AnadirComand.Name = "Btn_AnadirComand";
            Btn_AnadirComand.Size = new Size(66, 65);
            Btn_AnadirComand.TabIndex = 5;
            Btn_AnadirComand.UseVisualStyleBackColor = false;
            Btn_AnadirComand.Click += Btn_AnadirComand_Click;
            // 
            // Txt_Resultados
            // 
            Txt_Resultados.BackColor = SystemColors.MenuText;
            Txt_Resultados.Font = new System.Drawing.Font("RobotoMono Nerd Font", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Txt_Resultados.ForeColor = Color.Lime;
            Txt_Resultados.Location = new Point(0, 331);
            Txt_Resultados.Margin = new Padding(3, 4, 3, 4);
            Txt_Resultados.Multiline = true;
            Txt_Resultados.Name = "Txt_Resultados";
            Txt_Resultados.ScrollBars = ScrollBars.Vertical;
            Txt_Resultados.Size = new Size(918, 295);
            Txt_Resultados.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslBitacora });
            statusStrip1.Location = new Point(0, 634);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(923, 26);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // tslBitacora
            // 
            tslBitacora.Name = "tslBitacora";
            tslBitacora.Size = new Size(288, 20);
            tslBitacora.Text = "Resultado bitácora: (esperando ejecución)";
            // 
            // List_Servers
            // 
            List_Servers.Location = new Point(3, 135);
            List_Servers.Margin = new Padding(3, 4, 3, 4);
            List_Servers.Name = "List_Servers";
            List_Servers.Size = new Size(385, 187);
            List_Servers.TabIndex = 9;
            List_Servers.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(923, 660);
            Controls.Add(List_Servers);
            Controls.Add(statusStrip1);
            Controls.Add(Txt_Resultados);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            IsMdiContainer = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Administracion de Comandos Remotos";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox1;
        private Panel panel2;
        private TextBox Txt_Resultados;
        private Label label1;
        private Button Btn_EliminarServidor;
        private Button Btn_EditarServidor;
        private Button Btn_AnadirComand;
        private Button Btn_AnadirServidor;
        
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tslBitacora;
        private ListView List_Comandos;
        private ListView List_Servers;
        private Button Btn_EliminarCommand;
        private Button Btn_Iniciar;
        private Button Btn_EditarComand;
    }

}