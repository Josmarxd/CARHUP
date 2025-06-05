using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic;
using System.Text.Json;
using Newtonsoft.Json;

namespace CarHup
{
    public partial class Form4 : Form
    {

        Cliente cliente;
        public Form4()
        {
            InitializeComponent();
            cliente = new Cliente("192.168.36.183", 5000);
        }


        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void usuarioT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void usuarioT_Enter(object sender, EventArgs e)
        {
            if (usuarioT.Text == "Crea un nombre de Usuario")
            {
                usuarioT.Text = "";
                usuarioT.ForeColor = Color.LightBlue;
            }
        }

        private void usuarioT_Leave(object sender, EventArgs e)
        {
            if (usuarioT.Text == "")
            {
                usuarioT.Text = "Crea un nombre de Usuario";
                usuarioT.ForeColor = Color.DimGray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (correoT.Text == "Correo Electronico")
            {
                correoT.Text = "";
                correoT.ForeColor = Color.LightBlue;
            }
        }

        private void CorreoT_Leave(object sender, EventArgs e)
        {
            if (correoT.Text == "")
            {
                correoT.Text = "Correo Electronico";
                correoT.ForeColor = Color.DimGray;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos requeridos estén completos
                if (string.IsNullOrWhiteSpace(usuarioT.Text) ||
                    string.IsNullOrWhiteSpace(passawordT.Text) ||
                    sexoCT.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(correoT.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Asignar valores a las variables de usuario
                string nombre = usuarioT.Text;
                string password = passawordT.Text;  // Corregir el error ortográfico
                string sexo = sexoCT.SelectedItem.ToString();
                string correo = correoT.Text;

               
                Usuario nuevoUsuario = new Usuario(0, nombre, correo, password, sexo, 0, false,false, "Este conductor aun no a descrito las caracteristicas del vehiculo. puedes continuar si decides confiar\r\nen el conductor, pero si quiere puede elegir entre varios conductores \r\n");

                
               
                string respuesta = cliente.crearUsuario(nuevoUsuario); 
                
                
                if (respuesta != null && respuesta.Contains("exitosamente")) 
                {
                    Form1 form = new Form1();  
                    form.Show();
                    this.Hide();
                }
                else
                {
                   
                    MessageBox.Show("No se pudo crear la cuenta: " + (respuesta ?? "Respuesta nula"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void passawordT_Enter(object sender, EventArgs e)
        {
            if (passawordT.Text == "Contraseña")
            {
                passawordT.Text = "";
                passawordT.ForeColor = Color.LightBlue;
            }
        }

        private void passawordT_Leave(object sender, EventArgs e)
        {
            if (passawordT.Text == "")
            {
                passawordT.Text = "Contraseña";
                passawordT.ForeColor = Color.DimGray;
            }
        }

        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Form1 nuevaVentana = new Form1();
            nuevaVentana.Show();
            this.Hide();
            
        }
    }
}
