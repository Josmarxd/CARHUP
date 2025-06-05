namespace CarHup
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
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            linkLabel1 = new LinkLabel();
            usuarioT = new TextBox();
            passawordT = new TextBox();
            label1 = new Label();
            btnAcceder = new Button();
            recuperarContraseña = new LinkLabel();
            btnMaximizar = new PictureBox();
            btnMinimizar = new PictureBox();
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMaximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 122, 204);
            panel1.Controls.Add(pictureBox3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 330);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(3, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(244, 330);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            pictureBox3.MouseDown += pictureBox3_MouseDown;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(403, 61);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(0, 15);
            linkLabel1.TabIndex = 1;
            // 
            // usuarioT
            // 
            usuarioT.BackColor = Color.FromArgb(15, 15, 15);
            usuarioT.BorderStyle = BorderStyle.None;
            usuarioT.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usuarioT.ForeColor = Color.DimGray;
            usuarioT.Location = new Point(355, 79);
            usuarioT.Name = "usuarioT";
            usuarioT.Size = new Size(367, 22);
            usuarioT.TabIndex = 2;
            usuarioT.Text = "Usuario";
            usuarioT.TextChanged += textBox1_TextChanged;
            usuarioT.Enter += usuarioT_Enter;
            usuarioT.Leave += usuarioT_Leave;
            // 
            // passawordT
            // 
            passawordT.BackColor = Color.FromArgb(15, 15, 15);
            passawordT.BorderStyle = BorderStyle.None;
            passawordT.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passawordT.ForeColor = Color.DimGray;
            passawordT.Location = new Point(355, 144);
            passawordT.Name = "passawordT";
            passawordT.Size = new Size(367, 22);
            passawordT.TabIndex = 3;
            passawordT.Text = "Contraseña";
            passawordT.TextChanged += passawordT_TextChanged;
            passawordT.Enter += passawordT_Enter;
            passawordT.Leave += passawordT_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(488, 9);
            label1.Name = "label1";
            label1.Size = new Size(85, 33);
            label1.TabIndex = 4;
            label1.Text = "Login";
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
            btnAcceder.Location = new Point(355, 208);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.Size = new Size(377, 31);
            btnAcceder.TabIndex = 5;
            btnAcceder.Text = "ACCEDER";
            btnAcceder.UseVisualStyleBackColor = false;
            btnAcceder.Click += btnAcceder_Click;
            btnAcceder.MouseClick += btnAcceder_MouseClick;
            // 
            // recuperarContraseña
            // 
            recuperarContraseña.AutoSize = true;
            recuperarContraseña.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            recuperarContraseña.LinkColor = Color.DimGray;
            recuperarContraseña.Location = new Point(430, 304);
            recuperarContraseña.Name = "recuperarContraseña";
            recuperarContraseña.Size = new Size(204, 17);
            recuperarContraseña.TabIndex = 6;
            recuperarContraseña.TabStop = true;
            recuperarContraseña.Text = "¿Has olvidado tu contraseña?";
            recuperarContraseña.LinkClicked += linkLabel2_LinkClicked;
            // 
            // btnMaximizar
            // 
            btnMaximizar.Image = (Image)resources.GetObject("btnMaximizar.Image");
            btnMaximizar.Location = new Point(741, 9);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new Size(27, 23);
            btnMaximizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnMaximizar.TabIndex = 7;
            btnMaximizar.TabStop = false;
            btnMaximizar.Click += pictureBox1_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Image = (Image)resources.GetObject("btnMinimizar.Image");
            btnMinimizar.Location = new Point(701, 9);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(31, 25);
            btnMinimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnMinimizar.TabIndex = 8;
            btnMinimizar.TabStop = false;
            btnMinimizar.Click += pictureBox2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(40, 40, 40);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.WhiteSmoke;
            button1.Location = new Point(355, 258);
            button1.Name = "button1";
            button1.Size = new Size(377, 31);
            button1.TabIndex = 9;
            button1.Text = "CREAR CUENTA";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.MouseClick += button1_MouseClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(780, 330);
            Controls.Add(button1);
            Controls.Add(btnMinimizar);
            Controls.Add(btnMaximizar);
            Controls.Add(recuperarContraseña);
            Controls.Add(btnAcceder);
            Controls.Add(label1);
            Controls.Add(passawordT);
            Controls.Add(usuarioT);
            Controls.Add(linkLabel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            MouseDown += Form1_MouseDown;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMaximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private LinkLabel linkLabel1;
        private TextBox usuarioT;
        private TextBox passawordT;
        private Label label1;
        private Button btnAcceder;
        private LinkLabel recuperarContraseña;
        private PictureBox btnMaximizar;
        private PictureBox btnMinimizar;
        private PictureBox pictureBox3;
        private Button button1;
    }
}
