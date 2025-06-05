using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarHup
{
    public class Cliente
    {
        private TcpClient _clienteSocket;
        private NetworkStream _stream;
        private readonly string _direccionServidor;
        private readonly int _puerto;

        public Cliente(string direccionServidor, int puerto)
        {
            _direccionServidor = direccionServidor;
            _puerto = puerto;
        }    


       
        public void Conectar()
        {
            try
            {
                _clienteSocket = new TcpClient(_direccionServidor, _puerto);
                _stream = _clienteSocket.GetStream();
                Console.WriteLine("Conectado al servidor");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public string estadoSolicitudU2(string nombre)
        {
            Conectar();
            EnviarDatos("verificarSEstadoU2", nombre);
            string calificacionR = RecibirDatos();
            Cerrar();
            return calificacionR;
        }


        public string estadoSolicitudC2(string nombre,string solicitud)
        {
            Conectar();
            EnviarDatos("verificarSEstadoC2", nombre,solicitud);
            string calificacionR = RecibirDatos();
            Cerrar();
            return calificacionR;
        }


        public string estadoSolicitudU(string nombre,string NombreS)
        {
            Conectar();
            EnviarDatos("verificarSEstadoU", nombre,NombreS);
            string calificacionR = RecibirDatos();
            Cerrar();
            return calificacionR;
        }


        public string estadoSolicitudC(string nombreC )
        {
            Conectar();
            EnviarDatos("verificarSEstadoC", nombreC);
            string calificacionR = RecibirDatos();
            Cerrar();
            return calificacionR;
        }
        
        
        public string tamanioDeSolictudC(string nombre)
        {
            Conectar();
            EnviarDatos("Tamaño SolicitudC", nombre);
            string calificacionR = RecibirDatos();
            Cerrar();
            return calificacionR;
        }


        public string Enviar_Calificacion(string calificacion,string nombreC)
        {
            Conectar();
            EnviarDatos("calificacion",calificacion,nombreC);
            string calificacionR = RecibirDatos();
            Cerrar();
            return calificacionR;
        }


        public string Ver_Calificacion(string nombre)
        {
            Conectar();
            EnviarDatos("calificacionE",nombre);
            string calificacionR = RecibirDatos();
            Cerrar();
            return calificacionR;
        }


        public string pedirMisSolicitudesConductor(string nombre)
        {
            Conectar();
            EnviarDatos("Solicitudes", nombre);
            string datos = RecibirDatos();
            Cerrar();
            return datos;
        }



        public string buscar(string nombre)
        {
            Conectar();
            EnviarDatos("buscar",nombre);
            string busqueda = RecibirDatos();
            Cerrar();
            return busqueda;
        }


        public string verGenero(string nombre)
        {
            Conectar();
            EnviarDatos("genero", nombre);
            string busqueda = RecibirDatos();
            Cerrar();
            return busqueda;
        }


        public string EliminarSolicitudConductor(string solicitud, string nombre)
        {
            Conectar();
            EnviarDatos("Eliminar", solicitud, nombre);
            string busqueda = RecibirDatos();
            Cerrar();
            return busqueda;
        }


        public string VerDinero(string nombre)
        {
            Conectar();
            EnviarDatos("CSalario", nombre);
            string busqueda = RecibirDatos();
            Cerrar();
            return busqueda;
        } 


        public string cambiarEstadoOcupado(string nombreS,string nombreU)
        {
            Conectar();
            EnviarDatos("estado", nombreU,nombreS);
            string busqueda = RecibirDatos();
            Cerrar();
            return busqueda;
        }



        public string cambiarEstadoLibre(string nombreS, string nombreU)
        {
            Conectar();
            EnviarDatos("estado2", nombreU, nombreS);
            string busqueda = RecibirDatos();
            Cerrar();
            return busqueda;
        }

        public string agregarDinero(string cantidad,string nombre)
        {
            Conectar();
            EnviarDatos("Dinero", cantidad,nombre);
            string busqueda = RecibirDatos();  
            Cerrar();
            return busqueda;
        }

        public string cambiarAConductor(string nombre)
        {
            Conectar();
            EnviarDatos("estadoC", nombre);
            string busqueda = RecibirDatos();
            Cerrar();
            return busqueda;
        }


        public string tamanioDeSolicitudes(string nombre)
        {
            Conectar();
            EnviarDatos("Tamaño Solicitud", nombre);
            string busqueda = RecibirDatos();
            Cerrar();
            return busqueda;
        }


        public string cambiarAUsuario(string nombre)
        {
            Conectar();
            EnviarDatos("estadoU", nombre);
            string busqueda = RecibirDatos();
            Cerrar();
            return busqueda;
        }

        public string PedirMisSolicitudes(string nombre)
        {
            Conectar();
            EnviarDatos("MisSolicitudes",nombre);
            string datos = RecibirDatos();
            Cerrar();
            return datos;
        }


        public string EliminarSolicitud(string nombreS,string nombreU)
        {
            Conectar();
            EnviarDatos("Eliminar_Solicitud", nombreS, nombreU);
            string respuesta = RecibirDatos();
            Cerrar();
            return respuesta;

        }


        public string verificarEstadoU(string nombre)
        {
            Conectar();
            EnviarDatos("Ve",nombre);
            string respuesta = RecibirDatos();
            Cerrar();
            return respuesta;
        }

        


        public string estadoSolicitudActiva(string nombreU,string nombreS)
        {
            Conectar();
            EnviarDatos("estadoS", nombreS, nombreU);
            string respuesta = RecibirDatos();
            Cerrar();
            return respuesta;
        }


        public string estadoSolicitudDesactiva(string nombreU, string nombreS)
        {
            Conectar();
            EnviarDatos("estadoS2", nombreS, nombreU);
            string respuesta = RecibirDatos();
            Cerrar();
            return respuesta;
        }

        public string estadoSolicitudDesactivadaU(string nombreU,string nombreS)
        {
            Conectar();
            EnviarDatos("estadoS3", nombreS, nombreU);
            string respuesta = RecibirDatos();
            Cerrar();
            return respuesta;
        }




        public string enviarSolicitud(Solicitud solicitud)
        {
            Conectar();
            string usuarioJson = JsonConvert.SerializeObject(solicitud);
            EnviarDatos("enviar_Solicitud", usuarioJson,"vrg");
            string respuesta = RecibirDatos();
            Cerrar();
            return respuesta;
        }

        public string iniciarSesion(string nombre, string password)
        {
            
            Conectar();
            var datosLogin = new
            {
                Nombre = nombre,
                Password = password  
            };

            string usuarioJson = JsonConvert.SerializeObject(datosLogin);
            EnviarDatos("iniciar_sesion", usuarioJson,"pito");
            string respuesta = RecibirDatos();

            Cerrar();

            return respuesta;  
        }



        public string enviarDatosAuto(Auto auto,string nombre)
        {
            Conectar();
            string usuarioJson = JsonConvert.SerializeObject(auto);
            EnviarDatos("enviar_Auto", usuarioJson,nombre);
            string respuesta = RecibirDatos();
            Cerrar();
            return respuesta;
        }



        public string recibirAuto(string nombreC)
        {
            Conectar();
            EnviarDatos("recibir_Auto", nombreC);
            string respuesta = RecibirDatos();
            Cerrar();
            return respuesta;
        }


        public string ver_Conductores()
        {
            Conectar();
            EnviarDatos("solicitar_conductores","hola");
            string Vc = RecibirDatos();
            Cerrar();
            return Vc;
            
        }

        public string crearUsuario(Usuario usuario)
        {
            try
            {
                Conectar();

               
                string usuarioJson = JsonConvert.SerializeObject(usuario);

                
                EnviarDatos("crear_cuenta", usuarioJson,"xd"); 

                
                string respuesta = RecibirDatos();  

                // Usar la respuesta
                MessageBox.Show($"Respuesta del servidor: {respuesta}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return respuesta;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "ERROR :[";
            }
            finally
            {
                Cerrar(); 
            }
        }


        public void EnviarDatos(string tipo, string mensajeTexto, string NombreC, string calificacion)
        {
            if (_stream == null)
            {
                MessageBox.Show("No estás conectado al servidor. Llama a Conectar primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                var mensaje = new Mensaje { Tipo = tipo, Contenido = mensajeTexto, nombreC = NombreC,calificacion = calificacion };
                string mensajeJson = JsonConvert.SerializeObject(mensaje);
                byte[] mensajeBytes = Encoding.UTF8.GetBytes(mensajeJson);

                _stream.Write(mensajeBytes, 0, mensajeBytes.Length);
                Console.WriteLine("Datos enviados al servidor.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void EnviarDatos(string tipo, string mensajeTexto,string NombreC)
        {
            if (_stream == null)
            {
                MessageBox.Show("No estás conectado al servidor. Llama a Conectar primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                
                var mensaje = new Mensaje { Tipo = tipo, Contenido = mensajeTexto, nombreC = NombreC };
                string mensajeJson = JsonConvert.SerializeObject(mensaje);
                byte[] mensajeBytes = Encoding.UTF8.GetBytes(mensajeJson); 

                _stream.Write(mensajeBytes, 0, mensajeBytes.Length);
                Console.WriteLine("Datos enviados al servidor.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void EnviarDatos(string tipo, string mensajeTexto)
        {
            if (_stream == null)
            {
                MessageBox.Show("No estás conectado al servidor. Llama a Conectar primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                var mensaje = new Mensaje { Tipo = tipo, Contenido = mensajeTexto};
                string mensajeJson = JsonConvert.SerializeObject(mensaje);
                byte[] mensajeBytes = Encoding.UTF8.GetBytes(mensajeJson);

                _stream.Write(mensajeBytes, 0, mensajeBytes.Length);
                Console.WriteLine("Datos enviados al servidor.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string RecibirDatos()
        {
            if (_stream == null)
            {
                throw new InvalidOperationException("No estás conectado al servidor. Llama a Conectar primero.");
            }

            try
            {
                byte[] buffer = new byte[1024];  // Buffer para almacenar los datos recibidos
                int bytesRead = _stream.Read(buffer, 0, buffer.Length);  // Leer datos del flujo sin asincronía
                string respuesta = Encoding.UTF8.GetString(buffer, 0, bytesRead);  // Convertir bytes a cadena UTF-8

                return respuesta;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recibir datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void Cerrar()
        {
            if (_clienteSocket != null)
            {
                _clienteSocket.Close();
                Console.WriteLine("Conexión cerrada.");
            }
        }
    }

    public class Mensaje
    {
        public string Tipo { get; set; }
        public string Contenido { get; set; }
        public string nombreC { get; set; }

        public string calificacion { get; set; }
    }
}






