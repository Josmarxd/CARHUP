using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text;


namespace CarHupApp
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
                Console.WriteLine("Error");
            }
        }








        public string EliminarSolicitudConductor(string solicitud, string nombre)
        {
            Conectar();
            EnviarDatos("Eliminar", solicitud, nombre);
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




        public string PedirMisSolicitudes(string nombre)
        {
            Conectar();
            EnviarDatos("MisSolicitudes", nombre);
            string datos = RecibirDatos();
            Cerrar();
            return datos;
        }


        public string EliminarSolicitud(string nombreS, string nombreU)
        {
            Conectar();
            EnviarDatos("Eliminar_Solicitud", nombreS, nombreU);
            string respuesta = RecibirDatos();
            Cerrar();
            return respuesta;
        }       


        public string enviarSolicitud(Solicitud solicitud)
        {
            Conectar();
            string usuarioJson = JsonConvert.SerializeObject(solicitud);
            EnviarDatos("enviar_Solicitud", usuarioJson);
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
            EnviarDatos("iniciar_sesion", usuarioJson);
            string respuesta = RecibirDatos();

            Cerrar();

            return respuesta;
        }






      
       public void EnviarDatos(string tipo, string mensajeTexto, string NombreC, string calificacion)
        {
            if (_stream == null)
            {
                Console.WriteLine("Error");
                return;
            }

            try
            {

                var mensaje = new Mensaje { Tipo = tipo, Contenido = mensajeTexto, nombreC = NombreC, calificacion = calificacion };
                string mensajeJson = JsonConvert.SerializeObject(mensaje);
                byte[] mensajeBytes = Encoding.UTF8.GetBytes(mensajeJson);

                _stream.Write(mensajeBytes, 0, mensajeBytes.Length);
                Console.WriteLine("Datos enviados al servidor.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
        }


        public void EnviarDatos(string tipo, string mensajeTexto, string NombreC)
        {
            if (_stream == null)
            {
                Console.WriteLine("Error");
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
                Console.WriteLine("Error");
            }
        }



        public void EnviarDatos(string tipo, string mensajeTexto)
        {
            if (_stream == null)
            {
                Console.WriteLine("Error");
                return;
            }

            try
            {

                var mensaje = new Mensaje { Tipo = tipo, Contenido = mensajeTexto };
                string mensajeJson = JsonConvert.SerializeObject(mensaje);
                byte[] mensajeBytes = Encoding.UTF8.GetBytes(mensajeJson);
                _stream.Write(mensajeBytes, 0, mensajeBytes.Length);
                Console.WriteLine("Datos enviados al servidor.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
        }

        public string RecibirDatos()
        {
            if (_stream == null)
            {
                
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
                Console.WriteLine("Error");
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

