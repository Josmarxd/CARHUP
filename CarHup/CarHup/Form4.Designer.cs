namespace CarHup
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            usuarioT = new TextBox();
            correoT = new TextBox();
            passawordT = new TextBox();
            sexoCT = new ComboBox();
            btnAcceder = new Button();
            label2 = new Label();
            btnMinimizar = new PictureBox();
            btnMaximizar = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMaximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 122, 204);
            panel1.Controls.Add(pictureBox3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(232, 330);
            panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(-12, -3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(244, 330);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            pictureBox3.MouseDown += pictureBox3_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(389, 9);
            label1.Name = "label1";
            label1.Size = new Size(229, 33);
            label1.TabIndex = 5;
            label1.Text = "Create Account";
            label1.Click += label1_Click;
            // 
            // usuarioT
            // 
            usuarioT.BackColor = Color.FromArgb(15, 15, 15);
            usuarioT.BorderStyle = BorderStyle.None;
            usuarioT.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usuarioT.ForeColor = Color.DimGray;
            usuarioT.Location = new Point(304, 89);
            usuarioT.Name = "usuarioT";
            usuarioT.Size = new Size(367, 22);
            usuarioT.TabIndex = 6;
            usuarioT.Text = "Crea un nombre de Usuario";
            usuarioT.TextChanged += usuarioT_TextChanged;
            usuarioT.Enter += usuarioT_Enter;
            usuarioT.Leave += usuarioT_Leave;
            // 
            // correoT
            // 
            correoT.BackColor = Color.FromArgb(15, 15, 15);
            correoT.BorderStyle = BorderStyle.None;
            correoT.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            correoT.ForeColor = Color.DimGray;
            correoT.Location = new Point(304, 135);
            correoT.Name = "correoT";
            correoT.Size = new Size(367, 22);
            correoT.TabIndex = 7;
            correoT.Text = "Correo Electronico";
            correoT.Enter += textBox1_Enter;
            correoT.Leave += CorreoT_Leave;
            // 
            // passawordT
            // 
            passawordT.BackColor = Color.FromArgb(15, 15, 15);
            passawordT.BorderStyle = BorderStyle.None;
            passawordT.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passawordT.ForeColor = Color.DimGray;
            passawordT.Location = new Point(304, 185);
            passawordT.Name = "passawordT";
            passawordT.Size = new Size(367, 22);
            passawordT.TabIndex = 8;
            passawordT.Text = "Contraseña";
            passawordT.TextChanged += textBox2_TextChanged;
            passawordT.Enter += passawordT_Enter;
            passawordT.Leave += passawordT_Leave;
            // 
            // sexoCT
            // 
            sexoCT.FormattingEnabled = true;
            sexoCT.Items.AddRange(new object[] { "Hombre", "Mujer" });
            sexoCT.Location = new Point(389, 225);
            sexoCT.Name = "sexoCT";
            sexoCT.Size = new Size(164, 23);
            sexoCT.TabIndex = 9;
            // 
            // btnAcceder
            // 
            btnAcceder.BackColor = Color.FromArgb(40, 40, 40);
            btnAcceder.FlatAppearance.BorderSize = 0;
            btnAcceder.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            btnAcceder.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnAcceder.FlatStyle = FlatStyle.Flat;
            btnAcceder.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAcceder.ForeColor = Color.WhiteSmoke;
            btnAcceder.Location = new Point(304, 272);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.Size = new Size(377, 31);
            btnAcceder.TabIndex = 10;
            btnAcceder.Text = "CREATE";
            btnAcceder.UseVisualStyleBackColor = false;
            btnAcceder.Click += btnAcceder_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(304, 225);
            label2.Name = "label2";
            label2.Size = new Size(46, 19);
            label2.TabIndex = 11;
            label2.Text = "Sexo";
            label2.Click += label2_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Image = (Image)resources.GetObject("btnMinimizar.Image");
            btnMinimizar.Location = new Point(694, 7);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(31, 25);
            btnMinimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnMinimizar.TabIndex = 12;
            btnMinimizar.TabStop = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnMaximizar
            // 
            btnMaximizar.Image = (Image)resources.GetObject("btnMaximizar.Image");
            btnMaximizar.Location = new Point(731, 9);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new Size(27, 23);
            btnMaximizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnMaximizar.TabIndex = 13;
            btnMaximizar.TabStop = false;
            btnMaximizar.Click += btnMaximizar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(238, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(53, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(780, 330);
            Controls.Add(pictureBox1);
            Controls.Add(btnMaximizar);
            Controls.Add(btnMinimizar);
            Controls.Add(label2);
            Controls.Add(btnAcceder);
            Controls.Add(sexoCT);
            Controls.Add(passawordT);
            Controls.Add(correoT);
            Controls.Add(usuarioT);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form4";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form4";
            Load += Form4_Load;
            MouseDown += Form4_MouseDown;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMaximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox3;
        private Label label1;
        private TextBox usuarioT;
        private TextBox correoT;
        private TextBox passawordT;
        private ComboBox sexoCT;
        private Button btnAcceder;
        private Label label2;
        private PictureBox btnMinimizar;
        private PictureBox btnMaximizar;
        private PictureBox pictureBox1;
    }
}