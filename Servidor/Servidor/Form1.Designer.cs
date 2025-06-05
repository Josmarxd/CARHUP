namespace Servidor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            usuarios_activos = new Panel();
            btnDetenerServidor = new Button();
            btnIniciarServidor = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            usuarios_activos.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(227, 28);
            label1.TabIndex = 1;
            label1.Text = "SERVIDOR CARHUP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(95, 13);
            label2.Name = "label2";
            label2.Size = new Size(137, 28);
            label2.TabIndex = 2;
            label2.Text = "Activacion";
            label2.Click += label2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(usuarios_activos);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 141);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(473, 211);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkBlue;
            label3.Location = new Point(124, 110);
            label3.Name = "label3";
            label3.Size = new Size(185, 28);
            label3.TabIndex = 2;
            label3.Text = "servidor Activo";
            // 
            // usuarios_activos
            // 
            usuarios_activos.AutoScroll = true;
            usuarios_activos.BackColor = SystemColors.Highlight;
            usuarios_activos.Controls.Add(btnDetenerServidor);
            usuarios_activos.Controls.Add(btnIniciarServidor);
            usuarios_activos.Controls.Add(label2);
            usuarios_activos.Dock = DockStyle.Right;
            usuarios_activos.Location = new Point(479, 55);
            usuarios_activos.Name = "usuarios_activos";
            usuarios_activos.Size = new Size(321, 395);
            usuarios_activos.TabIndex = 4;
            // 
            // btnDetenerServidor
            // 
            btnDetenerServidor.FlatAppearance.BorderColor = Color.White;
            btnDetenerServidor.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDetenerServidor.Location = new Point(177, 86);
            btnDetenerServidor.Name = "btnDetenerServidor";
            btnDetenerServidor.Size = new Size(120, 35);
            btnDetenerServidor.TabIndex = 4;
            btnDetenerServidor.Text = "Desactivar";
            btnDetenerServidor.UseVisualStyleBackColor = true;
            btnDetenerServidor.Click += btnDetenerServidor_Click_1;
            // 
            // btnIniciarServidor
            // 
            btnIniciarServidor.FlatAppearance.BorderColor = Color.White;
            btnIniciarServidor.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciarServidor.Location = new Point(32, 86);
            btnIniciarServidor.Name = "btnIniciarServidor";
            btnIniciarServidor.Size = new Size(104, 35);
            btnIniciarServidor.TabIndex = 3;
            btnIniciarServidor.Text = "Activar";
            btnIniciarServidor.UseVisualStyleBackColor = true;
            btnIniciarServidor.Click += btnIniciarServidor_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(16, 16, 16);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 55);
            panel2.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            usuarios_activos.ResumeLayout(false);
            usuarios_activos.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Label label2;
        private Panel panel1;
        private Panel usuarios_activos;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label3;
        private Button btnDetenerServidor;
        private Button btnIniciarServidor;
    }
}
