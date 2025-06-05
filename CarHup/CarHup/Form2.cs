using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CarHup
{
    public partial class Form2 : Form
    {

        string nombre;
        string conductor;
        Cliente cliente;
        public Form2(string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;
            comprobarGenero();
            cliente = new Cliente("192.168.36.183", 5000);
            CrearSolicitud_P.Visible = false;
            Panel_CC.Visible = false;
            Panel_SolcitudTxt.Visible = false;
            Panel_Historial.Visible = false;
            Buscador_P.Visible = false;

        }


        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }





        private void btnAcceder_Click(object sender, EventArgs e)
        {
            cliente.cambiarAConductor(nombre);
            PanelP vena = new PanelP(nombre);
            vena.Show();
            this.Hide();
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

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


        private void comprobarGenero()
        {
            string generoUsuario = ObtenerGeneroUsuario(nombre);
            if (generoUsuario == "Hombre")
            {
                hombreI.Visible = true;
                mujerI.Visible = false;
            }
            else if (generoUsuario == "Mujer")
            {
                hombreI.Visible = false;
                mujerI.Visible = true;
            }
        }



        private string ObtenerGeneroUsuario(string nombreUsuario)
        {
            return "Hombre";
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Panel_CC.Visible = true;
            Panel_SolcitudTxt.Visible = false;
            Panel_Historial.Visible = false;
            Buscador_P.Visible = false;

            var conductoresJson = cliente.ver_Conductores();
            var conductores = JsonConvert.DeserializeObject<List<Usuario>>(conductoresJson);

            int cont = 1;

            foreach (var conductor in conductores)
            {
                if (cont == 1)
                {
                    NombreC_1.Text = conductor.Nombre;
                    Calificacion_L.Text = conductor.Calificacion.ToString();
                }
                else if (cont == 2)
                {
                    NombreC_2.Text = conductor.Nombre;
                    Calificacion_L2.Text = conductor.Calificacion.ToString();
                }
                else if (cont == 3)
                {
                    NombreC_3.Text = conductor.Nombre;
                    Calificacion_L3.Text = conductor.Calificacion.ToString();
                }

                cont++;

                if (cont > 3)
                {
                    break;
                }
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Activo_C_Click(object sender, EventArgs e)
        {

        }

        private void mujerI_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hombreI_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            Solicitud_1.Text = "vacio";
            Solicitud_2.Text = "vacio";
            Solicitud_3.Text = "vacio";
            Solicitud_4.Text = "vacio";
            Solicitud_5.Text = "vacio";
            Solicitud_6.Text = "vacio";
            Solicitud_7.Text = "vacio";
            Solicitud_8.Text = "vacio";

            Panel_CC.Visible = false;
            CrearSolicitud_P.Visible = false;
            Panel_Historial.Visible = true;
            Buscador_P.Visible = false;


            try
            {
                var solicitudes = cliente.PedirMisSolicitudes(nombre);

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


        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            Panel_CC.Visible = false;
            Buscador_P.Visible = true;
            Panel_Historial.Visible = false;
            Panel_SolcitudTxt.Visible = false;
            CrearSolicitud_P.Visible = false;
            PanelTablaBusqueda.Visible = false;


        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void Nombre_Solicitud_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        string nombreCT;
        private void Reservar_B_Click(object sender, EventArgs e)
        {
            CrearSolicitud_P.Visible = true;
            nombreCT = NombreC_1.Text;

            string autoJson = cliente.recibirAuto(nombreCT);

            if (!string.IsNullOrEmpty(autoJson))
            {
                var camion = JsonConvert.DeserializeObject<Auto>(autoJson);

                if (camion != null)
                {
                    
                    Color2_T.Text = $"Color: {camion.Color}";
                    Placa2_T.Text = $"Número de Placa: {camion.NumeroPlaca}";
                    Tipo2_T.Text = $"Tipo de Auto: {camion.TipoAuto}";
                    Marca2_T.Text = $"Marca: {camion.Marca}";
                    Modelo2_T.Text = $"Modelo: {camion.Modelo}";
                }
            }
            else
            {
                MessageBox.Show("No se recibieron datos del auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Enviar_D_Click(object sender, EventArgs e)
        {
            string nombre_S = Nombre_Solicitud.Text;
            string dinero = DineroPropuesto.Text;
            string cantidad_P = Cantidad_Pasajeros.Text;
            string cuidadE = cuidad_E.Text;
            string cuidadS = Cuidad_S.Text;
            string ip_Google = Dirreccion_Google.Text;
            string nombreU = nombre;
            string nombreC;

            if (nombreCT == NombreC_1.Text)
            {
                nombreC = NombreC_1.Text;
            }
            else if (nombreCT == NombreC_2.Text)
            {
                nombreC = NombreC_2.Text;
            }
            else if (nombreCT == NombreC_3.Text)
            {
                nombreC = NombreC_3.Text;
            }
            else
            {
                nombreC = conductor;
            }

            string datos = Descripcion.Text;
            Solicitud solicitud = new Solicitud(nombre_S, dinero, cantidad_P, cuidadE, cuidadS, ip_Google, nombreU, nombreC, datos);

            string cantidad = cliente.tamanioDeSolicitudes(nombre);
            string cantidadC = cliente.estadoSolicitudU2(nombre);


            string cantidadO = cliente.estadoSolicitudC(nombreC);
            string cantidadCT = cliente.tamanioDeSolictudC(nombreC);
            if (cantidad == "8")
                MessageBox.Show("No puedes hacer mas solicitudes ya as alcanzado el limite de solicitudes");
            else if (cantidadCT == "8")
                MessageBox.Show("No puedes hacer mas solicitudes el conductor tiene mas solicitudes");
            else if (cantidadC == "existe")
                MessageBox.Show("actualmente estas en un viaje no puedes hacer otra solicitud");
            else if (cantidadCT == "existe")
                MessageBox.Show("actualmente el conductor esta en viaje intenta mas tarde");
            else
            {
                cliente.enviarSolicitud(solicitud);
                Nombre_Solicitud.Text = "";
                DineroPropuesto.Text = " ";
                Cantidad_Pasajeros.Text = "";
                cuidad_E.Text = "";
                Cuidad_S.Text = "";
                nombreU = "";
            }

            CrearSolicitud_P.Visible = false;
        }



        private void Reservar2_Click(object sender, EventArgs e)
        {
            CrearSolicitud_P.Visible = true;
            nombreCT = NombreC_2.Text;

            string autoJson = cliente.recibirAuto(nombreCT);

            if (!string.IsNullOrEmpty(autoJson))
            {
                var camion = JsonConvert.DeserializeObject<Auto>(autoJson);

                if (camion != null)
                {

                    Color2_T.Text = $"Color: {camion.Color}";
                    Placa2_T.Text = $"Número de Placa: {camion.NumeroPlaca}";
                    Tipo2_T.Text = $"Tipo de Auto: {camion.TipoAuto}";
                    Marca2_T.Text = $"Marca: {camion.Marca}";
                    Modelo2_T.Text = $"Modelo: {camion.Modelo}";
                }
            }
            else
            {
                MessageBox.Show("No se recibieron datos del auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CrearSolicitud_P.Visible = true;
            nombreCT = NombreC_3.Text;


            string autoJson = cliente.recibirAuto(nombreCT);

            if (!string.IsNullOrEmpty(autoJson))
            {
                var camion = JsonConvert.DeserializeObject<Auto>(autoJson);

                if (camion != null)
                {

                    Color2_T.Text = $"Color: {camion.Color}";
                    Placa2_T.Text = $"Número de Placa: {camion.NumeroPlaca}";
                    Tipo2_T.Text = $"Tipo de Auto: {camion.TipoAuto}";
                    Marca2_T.Text = $"Marca: {camion.Marca}";
                    Modelo2_T.Text = $"Modelo: {camion.Modelo}";
                }
            }
            else
            {
                MessageBox.Show("No se recibieron datos del auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            CrearSolicitud_P.Visible = false;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Panel_SolcitudTxt.Visible = false;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
            "¿Estás seguro de que quieres eliminar esta solicitud?",
            "Confirmar Eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );


            if (resultado == DialogResult.Yes)
            {

                cliente.EliminarSolicitud(Nombre_SolicitudL.Text, nombre);
            }
            else
            {
                Console.WriteLine("Eliminación de solicitud cancelada.");
            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            pictureBox3_Click(sender, e);
            Panel_SolcitudTxt.Visible = false;
            Panel_Historial.Visible = false;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            pictureBox6_Click(sender, e);
        }

        private void Panel_Historial_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Solicitud_1_Click(object sender, EventArgs e)
        {
            Panel_SolcitudTxt.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.PedirMisSolicitudes(nombre);

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


                                string autoJson = cliente.recibirAuto(solicitud.Nombre_Conductor);

                                if (!string.IsNullOrEmpty(autoJson))
                                {
                                    var camion = JsonConvert.DeserializeObject<Auto>(autoJson);

                                    if (camion != null)
                                    {

                                        Color_T.Text = $"Color: {camion.Color}";
                                        Placa_T.Text = $"Número de Placa: {camion.NumeroPlaca}";
                                        Tipo.Text = $"Tipo de Auto: {camion.TipoAuto}";
                                        Marca_T.Text = $"Marca: {camion.Marca}";
                                        Modelo_T.Text = $"Modelo: {camion.Modelo}";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se recibieron datos del auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }



                                string eliminar = cliente.estadoSolicitudU(nombre, solicitud.Nombre_S);

                                string eliminarC = cliente.estadoSolicitudC2(solicitud.Nombre_Conductor, solicitud.Nombre_S);


                                if (eliminar == "existe" && eliminarC == "no existe")
                                {
                                    string nombreC = solicitud.Nombre_Conductor;
                                    Form5 form5 = new Form5(nombreC);
                                    form5.Show();
                                    cliente.EliminarSolicitud(solicitud.Nombre_S, nombre);
                                }

                                cont++;

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se recibieron solicitudes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.Write("Completado" + ex);
            }
        }

        private void Solicitud_2_Click(object sender, EventArgs e)
        {
            Panel_SolcitudTxt.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.PedirMisSolicitudes(nombre);

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

                                string autoJson = cliente.recibirAuto(solicitud.Nombre_Conductor);

                                if (!string.IsNullOrEmpty(autoJson))
                                {
                                    var camion = JsonConvert.DeserializeObject<Auto>(autoJson);

                                    if (camion != null)
                                    {

                                        Color_T.Text = $"Color: {camion.Color}";
                                        Placa_T.Text = $"Número de Placa: {camion.NumeroPlaca}";
                                        Tipo.Text = $"Tipo de Auto: {camion.TipoAuto}";
                                        Marca_T.Text = $"Marca: {camion.Marca}";
                                        Modelo_T.Text = $"Modelo: {camion.Modelo}";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se recibieron datos del auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }


                                string eliminar = cliente.estadoSolicitudU(nombre, solicitud.Nombre_S);
                                string eliminarC = cliente.estadoSolicitudC2(solicitud.Nombre_Conductor, solicitud.Nombre_S);


                                if (eliminar == "existe" && eliminarC == "no existe")
                                {
                                    string nombreC = solicitud.Nombre_Conductor;
                                    Form5 form5 = new Form5(nombreC);
                                    form5.Show();
                                    cliente.EliminarSolicitud(solicitud.Nombre_S, nombre);
                                }

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
            Panel_SolcitudTxt.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.PedirMisSolicitudes(nombre);

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

                                string autoJson = cliente.recibirAuto(solicitud.Nombre_Conductor);

                                if (!string.IsNullOrEmpty(autoJson))
                                {
                                    var camion = JsonConvert.DeserializeObject<Auto>(autoJson);

                                    if (camion != null)
                                    {

                                        Color_T.Text = $"Color: {camion.Color}";
                                        Placa_T.Text = $"Número de Placa: {camion.NumeroPlaca}";
                                        Tipo.Text = $"Tipo de Auto: {camion.TipoAuto}";
                                        Marca_T.Text = $"Marca: {camion.Marca}";
                                        Modelo_T.Text = $"Modelo: {camion.Modelo}";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se recibieron datos del auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                string eliminar = cliente.estadoSolicitudU(nombre, solicitud.Nombre_S);
                                string eliminarC = cliente.estadoSolicitudC2(solicitud.Nombre_Conductor, solicitud.Nombre_S);


                                if (eliminar == "existe" && eliminarC == "no existe")
                                {
                                    string nombreC = solicitud.Nombre_Conductor;
                                    Form5 form5 = new Form5(nombreC);
                                    form5.Show();
                                    cliente.EliminarSolicitud(solicitud.Nombre_S, nombre);
                                }
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
            Panel_SolcitudTxt.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.PedirMisSolicitudes(nombre);

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

                                string autoJson = cliente.recibirAuto(solicitud.Nombre_Conductor);

                                if (!string.IsNullOrEmpty(autoJson))
                                {
                                    var camion = JsonConvert.DeserializeObject<Auto>(autoJson);

                                    if (camion != null)
                                    {

                                        Color_T.Text = $"Color: {camion.Color}";
                                        Placa_T.Text = $"Número de Placa: {camion.NumeroPlaca}";
                                        Tipo.Text = $"Tipo de Auto: {camion.TipoAuto}";
                                        Marca_T.Text = $"Marca: {camion.Marca}";
                                        Modelo_T.Text = $"Modelo: {camion.Modelo}";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se recibieron datos del auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                string eliminar = cliente.estadoSolicitudU(nombre, solicitud.Nombre_S);
                                string eliminarC = cliente.estadoSolicitudC2(solicitud.Nombre_Conductor, solicitud.Nombre_S);


                                if (eliminar == "existe" && eliminarC == "no existe")
                                {
                                    string nombreC = solicitud.Nombre_Conductor;
                                    Form5 form5 = new Form5(nombreC);
                                    form5.Show();
                                    cliente.EliminarSolicitud(solicitud.Nombre_S, nombre);
                                }
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
            Panel_SolcitudTxt.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.PedirMisSolicitudes(nombre);

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

                                string autoJson = cliente.recibirAuto(solicitud.Nombre_Conductor);

                                if (!string.IsNullOrEmpty(autoJson))
                                {
                                    var camion = JsonConvert.DeserializeObject<Auto>(autoJson);

                                    if (camion != null)
                                    {

                                        Color_T.Text = $"Color: {camion.Color}";
                                        Placa_T.Text = $"Número de Placa: {camion.NumeroPlaca}";
                                        Tipo.Text = $"Tipo de Auto: {camion.TipoAuto}";
                                        Marca_T.Text = $"Marca: {camion.Marca}";
                                        Modelo_T.Text = $"Modelo: {camion.Modelo}";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se recibieron datos del auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }



                                string eliminar = cliente.estadoSolicitudU(nombre, solicitud.Nombre_S);
                                string eliminarC = cliente.estadoSolicitudC2(solicitud.Nombre_Conductor, solicitud.Nombre_S);


                                if (eliminar == "existe" && eliminarC == "no existe")
                                {
                                    string nombreC = solicitud.Nombre_Conductor;
                                    Form5 form5 = new Form5(nombreC);
                                    form5.Show();
                                    cliente.EliminarSolicitud(solicitud.Nombre_S, nombre);
                                }

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
            Panel_SolcitudTxt.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.PedirMisSolicitudes(nombre);

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


                                string autoJson = cliente.recibirAuto(solicitud.Nombre_Conductor);

                                if (!string.IsNullOrEmpty(autoJson))
                                {
                                    var camion = JsonConvert.DeserializeObject<Auto>(autoJson);

                                    if (camion != null)
                                    {

                                        Color_T.Text = $"Color: {camion.Color}";
                                        Placa_T.Text = $"Número de Placa: {camion.NumeroPlaca}";
                                        Tipo.Text = $"Tipo de Auto: {camion.TipoAuto}";
                                        Marca_T.Text = $"Marca: {camion.Marca}";
                                        Modelo_T.Text = $"Modelo: {camion.Modelo}";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se recibieron datos del auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                string eliminar = cliente.estadoSolicitudU(nombre, solicitud.Nombre_S);
                                string eliminarC = cliente.estadoSolicitudC2(solicitud.Nombre_Conductor, solicitud.Nombre_S);


                                if (eliminar == "existe" && eliminarC == "no existe")
                                {
                                    string nombreC = solicitud.Nombre_Conductor;
                                    Form5 form5 = new Form5(nombreC);
                                    form5.Show();
                                    cliente.EliminarSolicitud(solicitud.Nombre_S, nombre);
                                }
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
            Panel_SolcitudTxt.Visible = true;
            int cont = 1;


            try
            {
                var solicitudes = cliente.PedirMisSolicitudes(nombre);

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


                                string autoJson = cliente.recibirAuto(solicitud.Nombre_Conductor);

                                if (!string.IsNullOrEmpty(autoJson))
                                {
                                    var camion = JsonConvert.DeserializeObject<Auto>(autoJson);

                                    if (camion != null)
                                    {

                                        Color_T.Text = $"Color: {camion.Color}";
                                        Placa_T.Text = $"Número de Placa: {camion.NumeroPlaca}";
                                        Tipo.Text = $"Tipo de Auto: {camion.TipoAuto}";
                                        Marca_T.Text = $"Marca: {camion.Marca}";
                                        Modelo_T.Text = $"Modelo: {camion.Modelo}";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se recibieron datos del auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                string eliminar = cliente.estadoSolicitudU(nombre, solicitud.Nombre_S);
                                string eliminarC = cliente.estadoSolicitudC2(solicitud.Nombre_Conductor, solicitud.Nombre_S);


                                if (eliminar == "existe" && eliminarC == "no existe")
                                {
                                    string nombreC = solicitud.Nombre_Conductor;
                                    Form5 form5 = new Form5(nombreC);
                                    form5.Show();
                                    cliente.EliminarSolicitud(solicitud.Nombre_S, nombre);
                                }


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
            Panel_SolcitudTxt.Visible = true;
            int cont = 1;

            try
            {
                var solicitudes = cliente.PedirMisSolicitudes(nombre);

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


                                string autoJson = cliente.recibirAuto(solicitud.Nombre_Conductor);

                                if (!string.IsNullOrEmpty(autoJson))
                                {
                                    var camion = JsonConvert.DeserializeObject<Auto>(autoJson);

                                    if (camion != null)
                                    {

                                        Color_T.Text = $"Color: {camion.Color}";
                                        Placa_T.Text = $"Número de Placa: {camion.NumeroPlaca}";
                                        Tipo.Text = $"Tipo de Auto: {camion.TipoAuto}";
                                        Marca_T.Text = $"Marca: {camion.Marca}";
                                        Modelo_T.Text = $"Modelo: {camion.Modelo}";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se recibieron datos del auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                string eliminar = cliente.estadoSolicitudU(nombre, solicitud.Nombre_S);
                                string eliminarC = cliente.estadoSolicitudC2(solicitud.Nombre_Conductor, solicitud.Nombre_S);


                                if (eliminar == "existe" && eliminarC == "no existe")
                                {
                                    string nombreC = solicitud.Nombre_Conductor;
                                    Form5 form5 = new Form5(nombreC);
                                    form5.Show();
                                    cliente.EliminarSolicitud(solicitud.Nombre_S, nombre);
                                }

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

        private void Buscar_T_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            string nombreU = Buscar_T.Text;



            try
            {
                var usuarioE = cliente.buscar(nombreU);

                if (usuarioE != null)
                {
                    var usuariosEX = JsonConvert.DeserializeObject<List<Usuario>>(usuarioE);


                    if (usuariosEX != null)
                    {
                        NoseEncontro.Visible = false;
                        PanelTablaBusqueda.Visible = true;
                        foreach (var UsuarioEr in usuariosEX)
                        {
                            Nombre_U.Text = UsuarioEr.Nombre;
                            conductor = Nombre_U.Text;
                            Calificacion_U.Text = UsuarioEr.Calificacion.ToString();
                            break;

                        }
                    }

                    if (Nombre_U.Text == "Nombre_C2")
                    {
                        NoseEncontro.Visible = true;
                        PanelTablaBusqueda.Visible = false;
                    }

                }


            }
            catch (Exception ex)
            {
                Console.Write("Completado" + ex);
            }
        }

        private void tableLayoutPanel35_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Reserva2_Click(object sender, EventArgs e)
        {
            CrearSolicitud_P.Visible = true;
        }

        private void tableLayoutPanel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.google.com.mx/maps";

            try
            {

                System.Diagnostics.Process.Start("edge.exe", url);
            }
            catch (System.ComponentModel.Win32Exception)
            {

                try
                {
                    System.Diagnostics.Process.Start("chrome.exe", url);
                }
                catch (System.ComponentModel.Win32Exception)
                {

                    MessageBox.Show("No se pudo abrir el enlace. Asegúrate de tener un navegador web instalado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void linkGoogle2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        {

            string url = "Dirreccion_GoogleL.Text";

            try
            {

                System.Diagnostics.Process.Start("edge.exe", url);
            }
            catch (System.ComponentModel.Win32Exception)
            {

                try
                {
                    System.Diagnostics.Process.Start("chrome.exe", url);
                }
                catch (System.ComponentModel.Win32Exception)
                {

                    MessageBox.Show("No se pudo abrir el enlace. Asegúrate de tener un navegador web instalado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El usuario no tiene ningu link");
            }
        }

        private void Dirreccion_GoogleL_Click(object sender, EventArgs e)
        {

        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void tableLayoutPanel16_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel33_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

