using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace CarHup
{
    public partial class Form1 : Form
    {

        Cliente cliente;
        public Form1()
        {
            InitializeComponent();
            cliente = new Cliente("192.168.36.183", 5000);
        }


        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void passawordT_TextChanged(object sender, EventArgs e)
        {

        }

        private void usuarioT_Enter(object sender, EventArgs e)
        {
            if (usuarioT.Text == "Usuario")
            {
                usuarioT.Text = "";
                usuarioT.ForeColor = Color.LightBlue;

            }
        }


        private void usuarioT_Leave(object sender, EventArgs e)
        {
            if (usuarioT.Text == "")
            {
                usuarioT.Text = "Usuario";
                usuarioT.ForeColor = Color.DimGray;
            }
        }

        private void passawordT_Enter(object sender, EventArgs e)
        {
            if (passawordT.Text == "Contraseña")
            {
                passawordT.Text = "";
                passawordT.ForeColor = Color.LightBlue;
                passawordT.UseSystemPasswordChar = true;
            }
        }

        private void passawordT_Leave(object sender, EventArgs e)
        {
            if (passawordT.Text == "")
            {
                passawordT.Text = "Contraseña";
                passawordT.ForeColor = Color.DimGray;
                passawordT.UseSystemPasswordChar = false;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        private void btnAcceder_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form4 nuevaVentana = new Form4();
                nuevaVentana.Show();
                this.Hide();
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            string usuario = usuarioT.Text;
            string passaword = passawordT.Text;

          string respuesta = cliente.iniciarSesion(usuario,passaword);


            if (respuesta != null && respuesta.Contains("exitoso"))
            {

                string d = cliente.verificarEstadoU(usuario);

                if (d == "Usuario")
                {
                Form2 form = new Form2(usuario);
                form.Show();
                this.Hide();
                }
                else {
                    PanelP form2 = new PanelP(usuario);
                    form2.Show();
                    this.Hide();
                }
                
            }
            else
            {
                MessageBox.Show("No se pudo iniciar Sesion: " + (respuesta ?? "Respuesta nula"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
