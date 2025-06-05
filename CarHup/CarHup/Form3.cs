using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarHup
{
    public partial class PanelP : Form
    {


        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        Cliente cliente;
        string nombre;
        string nombreU;

        public PanelP(string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;
            cliente = new Cliente("192.168.36.183", 5000);
            MisIngresos_Panel.Visible = false;
            SolicitudesPanel.Visible = false;
            PanelClasificacion.Visible = false;
            VentanaAbajo.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            cliente.cambiarAUsuario(nombre);
            Form2 f = new Form2(nombre);
            f.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                Form1 nuevaVentana = new Form1();
                nuevaVentana.Show();
                this.Hide();
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MisIngresos_Panel.Visible = true;
            SolicitudesPanel.Visible = false;
            PanelClasificacion.Visible = false;
            VentanaAbajo.Visible = false;
            Ingreso_D.Text = cliente.VerDinero(nombre);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MisIngresos_Panel.Visible = false;
            SolicitudesPanel.Visible = true;
            PanelClasificacion.Visible = false;
            VentanaAbajo.Visible = false;

            Solicitud_1.Text = "vacio";
            Solicitud_2.Text = "vacio";
            Solicitud_3.Text = "vacio";
            Solicitud_4.Text = "vacio";
            Solicitud_5.Text = "vacio";
            Solicitud_6.Text = "vacio";
            Solicitud_7.Text = "vacio";
            Solicitud_8.Text = "vacio";
            try
            {
                var solicitudes = cliente.pedirMisSolicitudesConductor(nombre);


                if (solicitudes != null)
                {
                    var solicitudes2 = JsonConvert.DeserializeObject<List<Solicitud>>(solicitudes);

                    if (solicitudes2 != null)
                    {
                        int cont = 1;
                        foreach (var solicitud in solicitudes2)
                        {
                            if (cont == 1) Solicitud_1.Text = solicitud.Nombre_S;
                            else if (cont == 2) Solicitud_2.Text = solicitud.Nombre_S;
                            else if (cont == 3) Solicitud_3.Text = solicitud.Nombre_S;
                            else if (cont == 4) Solicitud_4.Text = solicitud.Nombre_S;
                            else if (cont == 5) Solicitud_5.Text = solicitud.Nombre_S;
                            else if (cont == 6) Solicitud_6.Text = solicitud.Nombre_S;
                            else if (cont == 7) Solicitud_7.Text = solicitud.Nombre_S;
                            else if (cont == 8) Solicitud_8.Text = solicitud.Nombre_S;
                            cont++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron deserializar las solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se recibieron solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Console.Write("Completado" + ex);
            }
        }

        private void Solicitud_1_Click(object sender, EventArgs e)
        {

            VentanaAbajo.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.pedirMisSolicitudesConductor(nombre);

                if (solicitudes != null)
                {
                    var solicitudes2 = JsonConvert.DeserializeObject<List<Solicitud>>(solicitudes);

                    if (solicitudes2 != null)
                    {

                        foreach (var solicitud in solicitudes2)
                        {

                            if (cont == 1)
                            {
                                Nombre_SolicitudL.Text = solicitud.Nombre_S;
                                Dinero_PropuestoL.Text = solicitud.Dinero;
                                Pasajero_L.Text = solicitud.Cantidad_Pasajeros;
                                Cuidad_LL.Text = solicitud.CuidadE;
                                Cuidad_TL.Text = solicitud.CuidadS;
                                Label.Text = solicitud.Ip_Google;
                                Mi_InformacionL.Text = solicitud.detalles;
                                nombreU = solicitud.Nombre_Usuario;
                                break;
                            }

                            cont++;

                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron deserializar las solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se recibieron solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Console.Write("Completado" + ex);
            }
        }

        private void Solicitud_2_Click(object sender, EventArgs e)
        {
            VentanaAbajo.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.pedirMisSolicitudesConductor(nombre);

                if (solicitudes != null)
                {
                    var solicitudes2 = JsonConvert.DeserializeObject<List<Solicitud>>(solicitudes);

                    if (solicitudes2 != null)
                    {

                        foreach (var solicitud in solicitudes2)
                        {

                            if (cont == 2)
                            {
                                Nombre_SolicitudL.Text = solicitud.Nombre_S;
                                Dinero_PropuestoL.Text = solicitud.Dinero;
                                Pasajero_L.Text = solicitud.Cantidad_Pasajeros;
                                Cuidad_LL.Text = solicitud.CuidadE;
                                Cuidad_TL.Text = solicitud.CuidadS;
                                Label.Text = solicitud.Ip_Google;
                                Mi_InformacionL.Text = solicitud.detalles;
                                nombreU = solicitud.Nombre_Usuario;
                                break;
                            }

                            cont++;

                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron deserializar las solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se recibieron solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Console.Write("Completado" + ex);
            }
        }

        private void Solicitud_3_Click(object sender, EventArgs e)
        {
            VentanaAbajo.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.pedirMisSolicitudesConductor(nombre);

                if (solicitudes != null)
                {
                    var solicitudes2 = JsonConvert.DeserializeObject<List<Solicitud>>(solicitudes);

                    if (solicitudes2 != null)
                    {

                        foreach (var solicitud in solicitudes2)
                        {

                            if (cont == 3)
                            {
                                Nombre_SolicitudL.Text = solicitud.Nombre_S;
                                Dinero_PropuestoL.Text = solicitud.Dinero;
                                Pasajero_L.Text = solicitud.Cantidad_Pasajeros;
                                Cuidad_LL.Text = solicitud.CuidadE;
                                Cuidad_TL.Text = solicitud.CuidadS;
                                Label.Text = solicitud.Ip_Google;
                                Mi_InformacionL.Text = solicitud.detalles;
                                nombreU = solicitud.Nombre_Usuario;
                                break;
                            }

                            cont++;

                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron deserializar las solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se recibieron solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Console.Write("Completado" + ex);
            }
        }

        private void Solicitud_4_Click(object sender, EventArgs e)
        {
            VentanaAbajo.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.pedirMisSolicitudesConductor(nombre);

                if (solicitudes != null)
                {
                    var solicitudes2 = JsonConvert.DeserializeObject<List<Solicitud>>(solicitudes);

                    if (solicitudes2 != null)
                    {

                        foreach (var solicitud in solicitudes2)
                        {

                            if (cont == 4)
                            {
                                Nombre_SolicitudL.Text = solicitud.Nombre_S;
                                Dinero_PropuestoL.Text = solicitud.Dinero;
                                Pasajero_L.Text = solicitud.Cantidad_Pasajeros;
                                Cuidad_LL.Text = solicitud.CuidadE;
                                Cuidad_TL.Text = solicitud.CuidadS;
                                Label.Text = solicitud.Ip_Google;
                                Mi_InformacionL.Text = solicitud.detalles;
                                nombreU = solicitud.Nombre_Usuario;
                                break;
                            }

                            cont++;

                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron deserializar las solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se recibieron solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Console.Write("Completado" + ex);
            }
        }

        private void Solicitud_5_Click(object sender, EventArgs e)
        {
            VentanaAbajo.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.pedirMisSolicitudesConductor(nombre);

                if (solicitudes != null)
                {
                    var solicitudes2 = JsonConvert.DeserializeObject<List<Solicitud>>(solicitudes);

                    if (solicitudes2 != null)
                    {

                        foreach (var solicitud in solicitudes2)
                        {

                            if (cont == 5)
                            {
                                Nombre_SolicitudL.Text = solicitud.Nombre_S;
                                Dinero_PropuestoL.Text = solicitud.Dinero;
                                Pasajero_L.Text = solicitud.Cantidad_Pasajeros;
                                Cuidad_LL.Text = solicitud.CuidadE;
                                Cuidad_TL.Text = solicitud.CuidadS;
                                Label.Text = solicitud.Ip_Google;
                                Mi_InformacionL.Text = solicitud.detalles;
                                nombreU = solicitud.Nombre_Usuario;
                                break;
                            }

                            cont++;

                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron deserializar las solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se recibieron solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Console.Write("Completado" + ex);
            }
        }

        private void Solicitud_6_Click(object sender, EventArgs e)
        {
            VentanaAbajo.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.pedirMisSolicitudesConductor(nombre);

                if (solicitudes != null)
                {
                    var solicitudes2 = JsonConvert.DeserializeObject<List<Solicitud>>(solicitudes);

                    if (solicitudes2 != null)
                    {

                        foreach (var solicitud in solicitudes2)
                        {

                            if (cont == 6)
                            {
                                Nombre_SolicitudL.Text = solicitud.Nombre_S;
                                Dinero_PropuestoL.Text = solicitud.Dinero;
                                Pasajero_L.Text = solicitud.Cantidad_Pasajeros;
                                Cuidad_LL.Text = solicitud.CuidadE;
                                Cuidad_TL.Text = solicitud.CuidadS;
                                Label.Text = solicitud.Ip_Google;
                                Mi_InformacionL.Text = solicitud.detalles;
                                nombreU = solicitud.Nombre_Usuario;
                                break;
                            }

                            cont++;

                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron deserializar las solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se recibieron solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Console.Write("Completado" + ex);
            }
        }

        private void Solicitud_7_Click(object sender, EventArgs e)
        {
            VentanaAbajo.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.pedirMisSolicitudesConductor(nombre);

                if (solicitudes != null)
                {
                    var solicitudes2 = JsonConvert.DeserializeObject<List<Solicitud>>(solicitudes);

                    if (solicitudes2 != null)
                    {

                        foreach (var solicitud in solicitudes2)
                        {

                            if (cont == 7)
                            {
                                Nombre_SolicitudL.Text = solicitud.Nombre_S;
                                Dinero_PropuestoL.Text = solicitud.Dinero;
                                Pasajero_L.Text = solicitud.Cantidad_Pasajeros;
                                Cuidad_LL.Text = solicitud.CuidadE;
                                Cuidad_TL.Text = solicitud.CuidadS;
                                Label.Text = solicitud.Ip_Google;
                                Mi_InformacionL.Text = solicitud.detalles;
                                nombreU = solicitud.Nombre_Usuario;

                                break;

                            }

                            cont++;

                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron deserializar las solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se recibieron solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Console.Write("Completado" + ex);
            }
        }

        private void Solicitud_8_Click(object sender, EventArgs e)
        {
            VentanaAbajo.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.pedirMisSolicitudesConductor(nombre);

                if (solicitudes != null)
                {
                    var solicitudes2 = JsonConvert.DeserializeObject<List<Solicitud>>(solicitudes);

                    if (solicitudes2 != null)
                    {

                        foreach (var solicitud in solicitudes2)
                        {

                            if (cont == 8)
                            {
                                Nombre_SolicitudL.Text = solicitud.Nombre_S;
                                Dinero_PropuestoL.Text = solicitud.Dinero;
                                Pasajero_L.Text = solicitud.Cantidad_Pasajeros;
                                Cuidad_LL.Text = solicitud.CuidadE;
                                Cuidad_TL.Text = solicitud.CuidadS;
                                Label.Text = solicitud.Ip_Google;
                                Mi_InformacionL.Text = solicitud.detalles;
                                nombreU = solicitud.Nombre_Usuario;
                                break;
                            }

                            cont++;

                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron deserializar las solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se recibieron solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Console.Write("Completado" + ex);
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            string cantidadC = cliente.estadoSolicitudU(nombreU, Nombre_SolicitudL.Text);
            string cantidadO = cliente.estadoSolicitudC(nombre);

            if (cantidadC == "existe")
                MessageBox.Show("actualmente el usuario esta en un viaje");
            else if (cantidadO == "existe")
                MessageBox.Show("actualmente ya as aceptado esta solicitud");
            else
            {
                cliente.agregarDinero(Dinero_PropuestoL.Text, nombre);
                cliente.estadoSolicitudActiva(nombre, Nombre_SolicitudL.Text);
                VentanaAbajo.Visible = false;
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            cliente.EliminarSolicitudConductor(Nombre_SolicitudL.Text, nombre);
            VentanaAbajo.Visible = false;
        }

        private void Terminar_Click(object sender, EventArgs e)
        {
            cliente.estadoSolicitudDesactiva(nombre, Nombre_SolicitudL.Text);
            VentanaAbajo.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PanelClasificacion.Visible = true;
            VentanaAbajo.Visible = false;
            MisIngresos_Panel.Visible = false;
            SolicitudesPanel.Visible = false;

            Calificacion_Final.Text = cliente.Ver_Calificacion(nombre);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox13_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox15_Click_1(object sender, EventArgs e)
        {
            Form6 form = new Form6(nombre);
            form.Show();
        }
    }
}
