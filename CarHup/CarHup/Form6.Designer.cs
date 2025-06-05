namespace CarHup
{
    partial class Form6
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            panel1 = new Panel();
            pictureBox15 = new PictureBox();
            pictureBox20 = new PictureBox();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            Color_T = new TextBox();
            Placa_T = new TextBox();
            Tipo_T = new TextBox();
            Marca_T = new TextBox();
            Modelo_T = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox20).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 39);
            panel1.Controls.Add(pictureBox15);
            panel1.Controls.Add(pictureBox20);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(493, 76);
            panel1.TabIndex = 0;
            // 
            // pictureBox15
            // 
            pictureBox15.Dock = DockStyle.Right;
            pictureBox15.Image = (Image)resources.GetObject("pictureBox15.Image");
            pictureBox15.Location = new Point(191, 0);
            pictureBox15.Name = "pictureBox15";
            pictureBox15.Size = new Size(133, 76);
            pictureBox15.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox15.TabIndex = 18;
            pictureBox15.TabStop = false;
            // 
            // pictureBox20
            // 
            pictureBox20.Dock = DockStyle.Right;
            pictureBox20.Image = (Image)resources.GetObject("pictureBox20.Image");
            pictureBox20.Location = new Point(324, 0);
            pictureBox20.Name = "pictureBox20";
            pictureBox20.Size = new Size(169, 76);
            pictureBox20.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox20.TabIndex = 17;
            pictureBox20.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(167, 23);
            label1.TabIndex = 1;
            label1.Text = "Detalles del Auto";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label6, 0, 4);
            tableLayoutPanel1.Controls.Add(label5, 0, 3);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(button1, 1, 5);
            tableLayoutPanel1.Controls.Add(Color_T, 1, 0);
            tableLayoutPanel1.Controls.Add(Placa_T, 1, 1);
            tableLayoutPanel1.Controls.Add(Tipo_T, 1, 2);
            tableLayoutPanel1.Controls.Add(Marca_T, 1, 3);
            tableLayoutPanel1.Controls.Add(Modelo_T, 1, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 76);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel1.Size = new Size(493, 208);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Left;
            label6.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(3, 136);
            label6.Name = "label6";
            label6.Size = new Size(81, 34);
            label6.TabIndex = 12;
            label6.Text = "Modelo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(3, 102);
            label5.Name = "label5";
            label5.Size = new Size(71, 34);
            label5.TabIndex = 11;
            label5.Text = "Marca";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(3, 68);
            label4.Name = "label4";
            label4.Size = new Size(126, 34);
            label4.TabIndex = 10;
            label4.Text = "Tipo De Auto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(3, 34);
            label3.Name = "label3";
            label3.Size = new Size(172, 34);
            label3.TabIndex = 9;
            label3.Text = "Numero De Placa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 34);
            label2.TabIndex = 8;
            label2.Text = "Color";
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(249, 173);
            button1.Name = "button1";
            button1.Size = new Size(241, 32);
            button1.TabIndex = 2;
            button1.Text = "Acceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Color_T
            // 
            Color_T.Location = new Point(249, 3);
            Color_T.Name = "Color_T";
            Color_T.Size = new Size(232, 23);
            Color_T.TabIndex = 3;
            // 
            // Placa_T
            // 
            Placa_T.Location = new Point(249, 37);
            Placa_T.Name = "Placa_T";
            Placa_T.Size = new Size(232, 23);
            Placa_T.TabIndex = 4;
            // 
            // Tipo_T
            // 
            Tipo_T.Location = new Point(249, 71);
            Tipo_T.Name = "Tipo_T";
            Tipo_T.Size = new Size(232, 23);
            Tipo_T.TabIndex = 5;
            // 
            // Marca_T
            // 
            Marca_T.Location = new Point(249, 105);
            Marca_T.Name = "Marca_T";
            Marca_T.Size = new Size(232, 23);
            Marca_T.TabIndex = 6;
            // 
            // Modelo_T
            // 
            Modelo_T.Location = new Point(249, 139);
            Modelo_T.Name = "Modelo_T";
            Modelo_T.Size = new Size(232, 23);
            Modelo_T.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 19);
            ClientSize = new Size(493, 284);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form6";
            Text = "Form6";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox15).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox20).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox20;
        private PictureBox pictureBox15;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox Marca_T;
        private Button button1;
        private TextBox Color_T;
        private TextBox Placa_T;
        private TextBox Tipo_T;
        private ContextMenuStrip contextMenuStrip1;
        private Label label2;
        private TextBox Modelo_T;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}