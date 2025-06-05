using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarHup
{
    public partial class Form5 : Form
    {

        int cont = 0;
        Cliente cliente;
        string nombreC;
        public Form5(string nombreC)
        {
            InitializeComponent();
            Panel_E2.Visible = false;
            this.nombreC = nombreC;
            cliente = new Cliente("192.168.36.183", 5000);

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = true;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;
            cont = 2;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = true;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;
            cont = 4;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = true;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;
            cont = 6;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = true;
            Panel_E5.Visible = false;
            cont = 8;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = true;
            cont = 10;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = true;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;
            cont = 2;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = true;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;
            cont = 4;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = true;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;
            cont = 6;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = true;
            Panel_E5.Visible = false;
            cont = 8;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = true;
            cont = 10;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = true;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;
            cont = 2;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = true;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;
            cont = 4;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = true;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;
            cont = 6;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = true;
            Panel_E5.Visible = false;

            cont = 8;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = true;

            cont = 10;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = true;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;

            cont = 2;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = true;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;

            cont = 4;
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = true;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;

            cont = 6;
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = true;
            Panel_E5.Visible = false;

            cont = 8;
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = true;

            cont = 10;
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = true;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;

            cont = 2;
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = true;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;

            cont = 4;
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = true;
            Panel_E4.Visible = false;
            Panel_E5.Visible = false;

            cont = 6;
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = true;
            Panel_E5.Visible = false;

            cont = 8;
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            Panel_E1.Visible = false;
            Panel_E2.Visible = false;
            Panel_E3.Visible = false;
            Panel_E4.Visible = false;
            Panel_E5.Visible = true;

            cont = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cliente.Enviar_Calificacion(cont.ToString(),nombreC);
            this.Hide();
        }
    }
}
