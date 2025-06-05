using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Servidor
{
    public partial class Form1 : Form
    {
        private Socket _servidorSocket;
        private readonly int _puerto = 5000;
        private bool _servidorActivo = false;
        private string ruta_Archivo_usuarios = @"C:\Users\Josmar\Desktop\Informacion Importante\Base_De_Datos_Json\usuarios_AC.txt";
        private string ruta_carpeta_usuarios = @"C:\Users\Josmar\Desktop\Informacion Importante\Base_De_Datos_Json\Usuarios";
        private string ruta_Archivo_Administrador = @"C:\Users\Josmar\Desktop\Informacion Importante\Base_De_Datos_Json\admistrador_AC.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciarServidor_Click(object sender, EventArgs e)
        {
            if (!_servidorActivo)
            {
                _servidorSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var puntoFinal = new IPEndPoint(IPAddress.Any, _puerto); // Usar 0.0.0.0 para aceptar todas las conexiones
                _servidorSocket.Bind(puntoFinal);
                _servidorSocket.Listen(10);

                _servidorActivo = true;
                System.Threading.ThreadPool.QueueUserWorkItem(EscucharConexiones);
                Console.WriteLine("Servidor iniciado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EscucharConexiones(object state)
        {
            while (_servidorActivo)
            {
                try
                {
                    var clienteSocket = _servidorSocket.Accept();
                    Task.Run(() => ProcesarCliente(clienteSocket));
                }
                catch (SocketException ex)
                {
                    MessageBox.Show($"Error de socket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private async Task ProcesarCliente(Socket clienteSocket)
        {
            try
            {
                using (var stream = new NetworkStream(clienteSocket))
                {
                    var buffer = new byte[1024];
                    int bytesLeidos = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesLeidos == 0)
                    {
                        MessageBox.Show("El cliente cerró la conexión.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string mensajeJson = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);
                    var mensaje = JsonConvert.DeserializeObject<Mensaje>(mensajeJson);

                    switch (mensaje.Tipo)
                    {
                        case "crear_cuenta":
                            var nuevoUsuario = JsonConvert.DeserializeObject<Usuario>(mensaje.Contenido);
                            string jsonUsuario = JsonConvert.SerializeObject(nuevoUsuario);
                            File.AppendAllText(ruta_Archivo_usuarios, jsonUsuario + Environment.NewLine);

                            var respuesta = "exitosamente";
                            var respuestaBytes = Encoding.UTF8.GetBytes(respuesta);

                            string nombreNuevaCarpeta = nuevoUsuario.Nombre;


                            string rutaCompleta = Path.Combine(ruta_carpeta_usuarios, nombreNuevaCarpeta);
                            Directory.CreateDirectory(rutaCompleta);

                            string rutaCompleta3 = Path.Combine(ruta_carpeta_usuarios, nuevoUsuario.Nombre);
                            string ruta2 = Path.Combine(rutaCompleta3, "MisSolicitudes-" + nuevoUsuario.Nombre + ".txt");
                            File.Create(ruta2);

                            string rutaCompleta2 = Path.Combine(ruta_carpeta_usuarios, nuevoUsuario.Nombre);
                            string ruta = Path.Combine(rutaCompleta2, "Solicitudes-" + nuevoUsuario.Nombre + ".txt");
                            File.Create(ruta);


                            string rutaCompleta290 = Path.Combine(ruta_carpeta_usuarios, nuevoUsuario.Nombre);
                            string ruta09 = Path.Combine(rutaCompleta290, "Auto-" + nuevoUsuario.Nombre + ".txt");
                            File.Create(ruta09);

                            await stream.WriteAsync(respuestaBytes, 0, respuestaBytes.Length);
                            Console.WriteLine("Cuenta creada con éxito.");
                            break;


                        case "iniciar_sesionAD":
                            var datosLogin = JsonConvert.DeserializeObject<DatosLogin>(mensaje.Contenido);
                            var usuarios = File.ReadAllLines(ruta_Archivo_Administrador);
                            bool usuarioExiste = false;

                            foreach (var usuario in usuarios)
                            {
                                var usuarioObj = JsonConvert.DeserializeObject<Usuario>(usuario);
                                if (usuarioObj.Nombre == datosLogin.Nombre && usuarioObj.Passaword == datosLogin.Password)
                                {
                                    usuarioExiste = true;
                                    break;
                                }
                            }

                            var respuestaInicioSesion = usuarioExiste ? "exitoso" : "fallido";
                            var respuestaBytesInicioSesion = Encoding.UTF8.GetBytes(respuestaInicioSesion);
                            await stream.WriteAsync(respuestaBytesInicioSesion, 0, respuestaBytesInicioSesion.Length);
                            Console.WriteLine("exitoso");
                            break;


                            case "Ver_TodosU":
                            var usuarios_U = ObtenerUsuariosConductores(ruta_Archivo_usuarios);
                            var usuariosJson = JsonConvert.SerializeObject(usuarios_U);
                            var respue = Encoding.UTF8.GetBytes(usuariosJson);
                            await stream.WriteAsync(respue, 0, respue.Length);
                            break;




                        case "Ver_TodosC":
                            var usuarios_U2 = ObtenerUsuariosNoConductores(ruta_Archivo_usuarios);
                            var usuariosJson2 = JsonConvert.SerializeObject(usuarios_U2);
                            var respue2 = Encoding.UTF8.GetBytes(usuariosJson2);
                            await stream.WriteAsync(respue2, 0, respue2.Length);
                            break;



                        case "iniciar_sesion":
                            var datosLoginPN = JsonConvert.DeserializeObject<DatosLogin>(mensaje.Contenido);
                            var usuariosPN = File.ReadAllLines(ruta_Archivo_usuarios);
                            bool usuarioExistePN = false;

                            foreach (var usuario in usuariosPN)
                            {
                                var usuarioObjPN2 = JsonConvert.DeserializeObject<Usuario>(usuario);
                                if (usuarioObjPN2.Nombre == datosLoginPN.Nombre && usuarioObjPN2.Passaword == datosLoginPN.Password)
                                {
                                    usuarioExistePN = true;
                                    break;
                                }
                            }

                            var respuestaInicioSesionPN = usuarioExistePN ? "exitoso" : "fallido";
                            var respuestaBytesInicioSesionPN = Encoding.UTF8.GetBytes(respuestaInicioSesionPN);
                            await stream.WriteAsync(respuestaBytesInicioSesionPN, 0, respuestaBytesInicioSesionPN.Length);
                            Console.WriteLine("exitoso");
                            break;



                        case "recibir_Auto":
                            string rutaCoca = Path.Combine(ruta_carpeta_usuarios, mensaje.Contenido);
                            string ruta094K = Path.Combine(rutaCoca, "Auto-" + mensaje.Contenido + ".txt");

                           string autoLOL = ObtenerDetallesCamion(ruta094K);

                            var respuestaBytesInicioSesionPN9 = Encoding.UTF8.GetBytes(autoLOL);
                            await stream.WriteAsync(respuestaBytesInicioSesionPN9, 0, respuestaBytesInicioSesionPN9.Length);
                            break;



                        case "enviar_Auto":
                            string rutaCo = Path.Combine(ruta_carpeta_usuarios, mensaje.nombreC);
                            string ruta094 = Path.Combine(rutaCo, "Auto-" + mensaje.nombreC + ".txt");
                            GuardarCamion(ruta094, mensaje.Contenido);
                            var respuestaBytesIXD2 = Encoding.UTF8.GetBytes("Muy bien");
                            await stream.WriteAsync(respuestaBytesIXD2, 0, respuestaBytesIXD2.Length);

                            break;





                        case "Tamaño Solicitud":
                            string rutaCompleta29l = Path.Combine(ruta_carpeta_usuarios, mensaje.Contenido);
                            string ruta69 = Path.Combine(rutaCompleta29l, "MisSolicitudes-" + mensaje.Contenido + ".txt");
                            string total = obtenerTamanioS(ruta69).ToString();

                            var respuestaBytesIXD = Encoding.UTF8.GetBytes(total);
                            await stream.WriteAsync(respuestaBytesIXD, 0, respuestaBytesIXD.Length);
                            break;


                        case "Tamaño SolicitudC":
                            string rutaCompleta29ll = Path.Combine(ruta_carpeta_usuarios, mensaje.Contenido);
                            string ruta699 = Path.Combine(rutaCompleta29ll, "Solicitudes-" + mensaje.Contenido + ".txt");
                            string total2 = obtenerTamanioS(ruta699).ToString();

                            var respuestaBytesIXDl = Encoding.UTF8.GetBytes(total2);
                            await stream.WriteAsync(respuestaBytesIXDl, 0, respuestaBytesIXDl.Length);
                            break;



                        case "estado":

                            string rutaCompleta29 = Path.Combine(ruta_carpeta_usuarios, mensaje.nombreC);
                            string ruta9 = Path.Combine(rutaCompleta29, "Solicitudes-" + mensaje.nombreC + ".txt");

                            string nombreUsua = ObtenerNombreUsuarioPorSolicitud(ruta9, mensaje.Contenido);
                            ActualizarEstado(ruta_Archivo_usuarios, nombreUsua);
                            var respuestaBytesI = Encoding.UTF8.GetBytes("exitoso");
                            await stream.WriteAsync(respuestaBytesI, 0, respuestaBytesI.Length);
                            break;



                        case "estadoC":

                            ActualizarEstadoConductor(ruta_Archivo_usuarios, mensaje.Contenido);
                            var respuestaBytesI2 = Encoding.UTF8.GetBytes("exitoso");
                            await stream.WriteAsync(respuestaBytesI2, 0, respuestaBytesI2.Length);
                            break;


                        case "estadoU":
                            ActualizarEstadoConductor2(ruta_Archivo_usuarios, mensaje.Contenido);
                            var respuestaBytesI2a = Encoding.UTF8.GetBytes("exitoso");
                            await stream.WriteAsync(respuestaBytesI2a, 0, respuestaBytesI2a.Length);
                            break;


                        case "genero":
                            string sexo = BuscarSexoPorNombre(mensaje.Contenido);

                            var respuestaBytesI22 = Encoding.UTF8.GetBytes(sexo);
                            await stream.WriteAsync(respuestaBytesI22, 0, respuestaBytesI22.Length);
                            break;


                        case "Solicitudes":
                            try
                            {
                                string rutaCompletaM22 = Path.Combine(ruta_carpeta_usuarios, mensaje.Contenido);
                                string rutaM32 = Path.Combine(rutaCompletaM22, "Solicitudes-" + mensaje.Contenido + ".txt");

                                var solicitudesx34 = ObtenerTodasLasSolicitudes(rutaM32);
                                string conductoresw50 = JsonConvert.SerializeObject(solicitudesx34);

                                var respuestaBytes33 = Encoding.UTF8.GetBytes(conductoresw50);
                                await stream.WriteAsync(respuestaBytes33, 0, respuestaBytes33.Length);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al obtener las solicitudes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;


                        case "solicitar_conductores":
                            var conductores = ObtenerConductoresTop(3);
                            string conductoresJson = JsonConvert.SerializeObject(conductores);
                            var respuestaBytes2 = Encoding.UTF8.GetBytes(conductoresJson);
                            await stream.WriteAsync(respuestaBytes2, 0, respuestaBytes2.Length);
                            break;

                        case "enviar_Solicitud":
                            var nuevaSolicitud = JsonConvert.DeserializeObject<Solicitud>(mensaje.Contenido);


                            string rutaCompletaM = Path.Combine(ruta_carpeta_usuarios, nuevaSolicitud.Nombre_Usuario);
                            string rutaM = Path.Combine(rutaCompletaM, "MisSolicitudes-" + nuevaSolicitud.Nombre_Usuario + ".txt");

                            string rutaCompletaX = Path.Combine(ruta_carpeta_usuarios, nuevaSolicitud.Nombre_Conductor);
                            string rutaTxt = Path.Combine(rutaCompletaX, "Solicitudes-" + nuevaSolicitud.Nombre_Conductor + ".txt");




                            var respuestaBytesLimite = Encoding.UTF8.GetBytes("limiteAlcanzado");
                            await stream.WriteAsync(respuestaBytesLimite, 0, respuestaBytesLimite.Length);

                            var listaSolicitudes = JsonConvert.DeserializeObject<Solicitud>(mensaje.Contenido);
                            string contenidoActualizado = JsonConvert.SerializeObject(listaSolicitudes);

                            File.AppendAllText(rutaM, contenidoActualizado + Environment.NewLine);
                            File.AppendAllText(rutaTxt, contenidoActualizado + Environment.NewLine);

                            var respuestaBytesEnviado = Encoding.UTF8.GetBytes("enviadoC");
                            await stream.WriteAsync(respuestaBytesEnviado, 0, respuestaBytesEnviado.Length);

                            break;



                        case "verificarSEstadoU":
                            
                            string rutaCompletaMlU = Path.Combine(ruta_carpeta_usuarios, mensaje.Contenido);
                            string rutaMXX = Path.Combine(rutaCompletaMlU, "MisSolicitudes-" + mensaje.Contenido + ".txt");

                            string respuesta0 = obtenerEstadoSolicitud(rutaMXX,mensaje.nombreC);
                            var respuestaBytesEnviado09 = Encoding.UTF8.GetBytes(respuesta0);
                            await stream.WriteAsync(respuestaBytesEnviado09, 0, respuestaBytesEnviado09.Length);
                            break;


                        case "verificarSEstadoU2":
                            string rutaCompletaMlUP = Path.Combine(ruta_carpeta_usuarios, mensaje.Contenido);
                            string rutaMXXS = Path.Combine(rutaCompletaMlUP, "MisSolicitudes-" + mensaje.Contenido + ".txt");

                            string respues = obtenerEstadoSolicitud(rutaMXXS);
                            var respuest= Encoding.UTF8.GetBytes(respues);
                            await stream.WriteAsync(respuest, 0, respuest.Length);
                            break;


                        case "verificarSEstadoC":
                            string rutaCompletaXVideos = Path.Combine(ruta_carpeta_usuarios, mensaje.Contenido);
                            string rutaTxtxt = Path.Combine(rutaCompletaXVideos, "Solicitudes-" + mensaje.Contenido + ".txt");

                            string xco = obtenerEstadoSolicitud(rutaTxtxt);

                            var respuestaBytesEnviadop = Encoding.UTF8.GetBytes(xco);
                            await stream.WriteAsync(respuestaBytesEnviadop, 0, respuestaBytesEnviadop.Length);


                            break;


                        case "verificarSEstadoC2":
                            string rutaCompletaXVideo= Path.Combine(ruta_carpeta_usuarios, mensaje.Contenido);
                            string r = Path.Combine(rutaCompletaXVideo, "Solicitudes-" + mensaje.Contenido + ".txt");

                            string xcol = obtenerEstadoSolicitud(r,mensaje.nombreC);

                            var respuestaByy = Encoding.UTF8.GetBytes(xcol);
                            await stream.WriteAsync(respuestaByy, 0, respuestaByy.Length);

                            break;


                        case "estado2":

                            string rutaCompletau = Path.Combine(ruta_carpeta_usuarios, mensaje.nombreC);
                            string ruta9u = Path.Combine(rutaCompletau, "Solicitudes-" + mensaje.nombreC + ".txt");

                            string nombreUsua2 = ObtenerNombreUsuarioPorSolicitud(ruta9u, mensaje.Contenido);
                            ActualizarEstado2(ruta_Archivo_usuarios, nombreUsua2);
                            var respuestaBytesI222 = Encoding.UTF8.GetBytes("exitoso");
                            await stream.WriteAsync(respuestaBytesI222, 0, respuestaBytesI222.Length);
                            break;


                        case "estadoS":
                            

                            string rutaCompletau12 = Path.Combine(ruta_carpeta_usuarios, mensaje.nombreC);
                            string ruta9uu1 = Path.Combine(rutaCompletau12, "Solicitudes-" + mensaje.nombreC + ".txt");
                            string nombreUsw2 = ObtenerNombreUsuarioPorSolicitud(ruta9uu1, mensaje.Contenido);
                            string rutaCompletau12U = Path.Combine(ruta_carpeta_usuarios, nombreUsw2);
                            string ruta9uu1U = Path.Combine(rutaCompletau12U, "MisSolicitudes-" +nombreUsw2+ ".txt");

                            ActualizarEstadoSolicitud(ruta9uu1U, mensaje.Contenido);
                            ActualizarEstadoSolicitud(ruta9uu1, mensaje.Contenido);


                            var respuestaBytesI282 = Encoding.UTF8.GetBytes("exitoso");
                            await stream.WriteAsync(respuestaBytesI282, 0, respuestaBytesI282.Length);
                            break;


                        case "estadoS2":
                            string rutaCom = Path.Combine(ruta_carpeta_usuarios, mensaje.nombreC);
                            string rut= Path.Combine(rutaCom, "Solicitudes-" + mensaje.nombreC + ".txt");

                            ActualizarEstadoSolicitud2(rut, mensaje.Contenido);
                            

                            var respuestaBy = Encoding.UTF8.GetBytes("exitoso");
                            await stream.WriteAsync(respuestaBy, 0, respuestaBy.Length);
                            break;


                        case "estadoS3":
                            string rutaCom2 = Path.Combine(ruta_carpeta_usuarios, mensaje.nombreC);
                            string rut2 = Path.Combine(rutaCom2, "Solicitudes-" + mensaje.nombreC + ".txt");
                            string nom = ObtenerNombreUsuarioPorSolicitud(rut2, mensaje.Contenido);

                            string rutaComp = Path.Combine(ruta_carpeta_usuarios, nom);
                            string ru = Path.Combine(rutaComp, "MisSolicitudes-" + nom + ".txt");

                            ActualizarEstadoSolicitud2(ru, mensaje.Contenido);
                            var respuestaBytesI222xr = Encoding.UTF8.GetBytes("exitoso");
                            await stream.WriteAsync(respuestaBytesI222xr, 0, respuestaBytesI222xr.Length);
                            break;



                        case "MisSolicitudes":
                            try
                            {
                                string rutaCompletaM22 = Path.Combine(ruta_carpeta_usuarios, mensaje.Contenido);
                                string rutaM32 = Path.Combine(rutaCompletaM22, "MisSolicitudes-" + mensaje.Contenido + ".txt");

                                var solicitudesx34 = ObtenerTodasLasSolicitudes(rutaM32);
                                string conductoresw50 = JsonConvert.SerializeObject(solicitudesx34);

                                var respuestaBytes33 = Encoding.UTF8.GetBytes(conductoresw50);
                                await stream.WriteAsync(respuestaBytes33, 0, respuestaBytes33.Length);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al obtener las solicitudes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;


                        case "buscar":
                            var usuarioEncontrado = BuscarUsuariosPorNombre(mensaje.Contenido);
                            string usuarioE = JsonConvert.SerializeObject(usuarioEncontrado);
                            var respuestaBytes4 = Encoding.UTF8.GetBytes(usuarioE);
                            await stream.WriteAsync(respuestaBytes4, 0, respuestaBytes4.Length);
                            break;

                        case "Eliminar_Solicitud":
                            string rutaCompletaM4 = Path.Combine(ruta_carpeta_usuarios, mensaje.nombreC);
                            string rutaM5 = Path.Combine(rutaCompletaM4, "MisSolicitudes-" + mensaje.nombreC + ".txt");
                            
                            string nombreConductor = EliminarSolicitudPorNombre(rutaM5, mensaje.Contenido);
                            
                            string rutaCompletaKO = Path.Combine(ruta_carpeta_usuarios,nombreConductor);
                            string rutaKO = Path.Combine(rutaCompletaKO, "Solicitudes-" + nombreConductor + ".txt");

                            
                            EliminarSolicitudPorNombreConductor(rutaKO,mensaje.Contenido);
                            var respuestaBytes43 = Encoding.UTF8.GetBytes("Solicitud eliminada exitosamente.");
                            await stream.WriteAsync(respuestaBytes43, 0, respuestaBytes43.Length);
                            
                            break;

                        case "Eliminar":
                            string rutaCompletaM46 = Path.Combine(ruta_carpeta_usuarios, mensaje.nombreC);
                            string rutaM56 = Path.Combine(rutaCompletaM46, "Solicitudes-" + mensaje.nombreC + ".txt");

                            EliminarSolicitudPorNombreConductor(rutaM56,mensaje.Contenido);
                            var respuestaBytes433 = Encoding.UTF8.GetBytes("Solicitud eliminada exitosamente.");
                            await stream.WriteAsync(respuestaBytes433, 0, respuestaBytes433.Length);

                            break;


                        case "Dinero":
                            string salario = ActualizarSalarioUsuario(ruta_Archivo_usuarios, mensaje.nombreC, mensaje.Contenido);
                            var respuestaBytes434 = Encoding.UTF8.GetBytes(salario);
                            await stream.WriteAsync(respuestaBytes434, 0, respuestaBytes434.Length);
                            break;

                        case "calificacion":
                            ActualizarCalificacionUsuario(ruta_Archivo_usuarios,mensaje.nombreC,mensaje.Contenido);

                            var respuestaBytes0 = Encoding.UTF8.GetBytes("bien");
                            await stream.WriteAsync(respuestaBytes0, 0, respuestaBytes0.Length);

                            break;

                        case "calificacionE":
                           string c = BuscarCalificacion(ruta_Archivo_usuarios, mensaje.Contenido);
                            var respuestaBytes0000 = Encoding.UTF8.GetBytes(c);
                            await stream.WriteAsync(respuestaBytes0000, 0, respuestaBytes0000.Length);
                            break;


                        case "CSalario":
                           string salarioXD = BuscarSalarioPorNombre(ruta_Archivo_usuarios,mensaje.Contenido);
                            var respuestaBytes000 = Encoding.UTF8.GetBytes(salarioXD);
                            await stream.WriteAsync(respuestaBytes000, 0, respuestaBytes000.Length);
                            break;



                        case "Ve":
                            string hola = ObtenerEstadoUsuario(ruta_Archivo_usuarios, mensaje.Contenido);
                            var respuestaByteskoca = Encoding.UTF8.GetBytes(hola);
                            await stream.WriteAsync(respuestaByteskoca, 0, respuestaByteskoca.Length);
                            break;



                        default:
                            respuesta = "Tipo de acción no reconocida";
                            respuestaBytes = Encoding.UTF8.GetBytes(respuesta);
                            await stream.WriteAsync(respuestaBytes, 0, respuestaBytes.Length);
                            MessageBox.Show("Acción no reconocida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clienteSocket.Close();
            }
        }



        public void GuardarCamion(string ruta, string camionJson)
        {
           
            if (File.Exists(ruta))
            {
                File.Delete(ruta); 
            }

            File.WriteAllText(ruta, camionJson);
        }


        public string ObtenerDetallesCamion(string ruta)
        {
            if (!File.Exists(ruta))
            {
                return "Archivo no encontrado"; 
            }

            return File.ReadAllText(ruta);
        }





        public List<Usuario> ObtenerUsuariosConductores(string rutaArchivo)
        {
            var usuariosConductores = new List<Usuario>();

            
            if (!File.Exists(rutaArchivo))
            {
               
                return usuariosConductores;
            }

            
            var lineas = File.ReadAllLines(rutaArchivo);

            foreach (var linea in lineas)
            {
                var usuario = JsonConvert.DeserializeObject<Usuario>(linea);

                if (usuario != null && usuario.Conductor)
                {
                    usuariosConductores.Add(usuario); 
                }
            }

            return usuariosConductores; 
        }




        public List<Usuario> ObtenerUsuariosNoConductores(string rutaArchivo)
        {
            
            var usuariosNoConductores = new List<Usuario>();

          
            if (!File.Exists(rutaArchivo))
            {
               
                return usuariosNoConductores;
            }

            
            var lineas = File.ReadAllLines(rutaArchivo);

            
            foreach (var linea in lineas)
            {
                var usuario = JsonConvert.DeserializeObject<Usuario>(linea);

                
                if (usuario != null && usuario.Conductor == false)
                {
                    usuariosNoConductores.Add(usuario); 
                }
            }

            return usuariosNoConductores;
        }




        public string obtenerEstadoSolicitud(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                return "Error: El archivo no existe.";
            }

            var lineas = File.ReadAllLines(rutaArchivo);

            foreach (var linea in lineas)
            {
                var solicitud = JsonConvert.DeserializeObject<Solicitud>(linea);

                if (solicitud != null && solicitud.estado) 
                {
                    return "existe"; 
                }
            }

            return "no existe";
        }



        public string obtenerEstadoSolicitud(string rutaArchivo, string nombreSolicitud)
        {
            
            if (!File.Exists(rutaArchivo))
            {
                return "Error: El archivo no existe.";
            }

            var lineas = File.ReadAllLines(rutaArchivo); 

            
            foreach (var linea in lineas)
            {
                var solicitud = JsonConvert.DeserializeObject<Solicitud>(linea); 

                if (solicitud != null && solicitud.Nombre_S == nombreSolicitud) 
                {
                    
                    if (solicitud.estado)
                    {
                        return "existe";
                    }
                    else 
                    {
                        return "no existe";
                    }
                }
            }

            
            return "Solicitud no encontrada"; 

        }





        public string BuscarSalarioPorNombre(string rutaArchivo, string nombreUsuario)
        {
            if (!File.Exists(rutaArchivo))
            {
                return "Error: El archivo no existe.";
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            string salario = null;

            foreach (var linea in lineas)
        {
                var usuario = JsonConvert.DeserializeObject<Usuario>(linea);

                if (usuario != null && usuario.Nombre == nombreUsuario)
                {
                    salario = usuario.Ingresos.ToString(); 
                    break; 
                }
            }

            if (salario == null)
            {
                return "Error: Usuario no encontrado.";
            }

            return salario; 
        }




        public string BuscarCalificacion(string rutaArchivo, string nombreUsuario)
        {
            if (!File.Exists(rutaArchivo))
            {
                return "Error: El archivo no existe.";
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            string calificacion = null ;

            foreach (var linea in lineas)
            {
                var usuario = JsonConvert.DeserializeObject<Usuario>(linea);

                if (usuario != null && usuario.Nombre == nombreUsuario)
                {
                    calificacion = usuario.Calificacion.ToString();
                    break;
                }
            }

            if (calificacion == null)
            {
                return "Error: Usuario no encontrado.";
            }

            return calificacion;
        }



        public string EliminarSolicitudPorNombreConductor(string rutaArchivo, string nombreSolicitud)
        {
            if (File.Exists(rutaArchivo))
            {
                var lineas = File.ReadAllLines(rutaArchivo);
                var solicitudes = new List<Solicitud>();

                foreach (var linea in lineas)
                {
                    var solicitud = JsonConvert.DeserializeObject<Solicitud>(linea);
                    solicitudes.Add(solicitud);
                }

                var solicitudesActualizadas = solicitudes.Where(s => s.Nombre_S != nombreSolicitud).ToList();

                File.WriteAllText(rutaArchivo, "");
                foreach (var solicitud in solicitudesActualizadas)
                {
                    File.AppendAllText(rutaArchivo, JsonConvert.SerializeObject(solicitud) + Environment.NewLine);
                }

                return "Solicitud eliminada exitosamente.";
            }
            else
            {
                return "El archivo no existe.";
            }
        }



        public string ActualizarCalificacionUsuario(string rutaArchivo, string nombreConductor, string calificacionString)
        {
            if (!File.Exists(rutaArchivo))
            {
                return "Error: El archivo no existe.";
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            var usuarios = new List<Usuario>();
            bool encontrado = false;

            decimal nuevaCalificacion;
            if (!decimal.TryParse(calificacionString, out nuevaCalificacion))
            {
                return "Error: Calificación no válida.";
            }

            foreach (var linea in lineas)
            {
                var usuario = JsonConvert.DeserializeObject<Usuario>(linea);

                if (usuario != null && usuario.Nombre == nombreConductor)
                {
                    encontrado = true;
                    decimal promedio = (usuario.Calificacion + nuevaCalificacion) / 2;
                    promedio = Math.Round(promedio, 1);
                    usuario.Calificacion = promedio;

                }

                usuarios.Add(usuario); 
            }

            if (!encontrado)
            {
                return "Error: Usuario no encontrado.";
            }

           
            File.WriteAllText(rutaArchivo, "");
            foreach (var usuario in usuarios)
        {
                File.AppendAllText(rutaArchivo, JsonConvert.SerializeObject(usuario) + Environment.NewLine);
            }

            return "Bien";
        }



        public string ActualizarSalarioUsuario(string rutaArchivo, string nombreUsuario, string salarioAgregarString)
        {
            if (!File.Exists(rutaArchivo))
            {
                return "Error: El archivo no existe.";
            }

            decimal salarioAgregar;
            if (!decimal.TryParse(salarioAgregarString, out salarioAgregar))
            {
                return "Error: Salario no válido.";
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            var usuarios = new List<Usuario>();
            decimal salarioActualizado = 0; 
            bool encontrado = false;

            foreach (var linea in lineas)
    {
                var usuario = JsonConvert.DeserializeObject<Usuario>(linea);

                if (usuario != null && usuario.Nombre == nombreUsuario)
                {
                    encontrado = true;
                    salarioActualizado = usuario.Ingresos + salarioAgregar; 
                    usuario.Ingresos = salarioActualizado; 
                }

                usuarios.Add(usuario); 
            }

            if (!encontrado)
            {
                return "Error: Usuario no encontrado.";
            }

            
            File.WriteAllText(rutaArchivo, "");
            foreach (var usuario in usuarios)
    {
                File.AppendAllText(rutaArchivo, JsonConvert.SerializeObject(usuario) + Environment.NewLine);
            }

            return salarioActualizado.ToString();
        }


        public string ActualizarEstado(string rutaArchivo, string nombreUsuario)
        {
            if (!File.Exists(rutaArchivo))
            {
                return "Error: El archivo no existe.";
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            var usuarios = new List<Usuario>();
            bool encontrado = false;

            foreach (var linea in lineas)
        {
                var usuario = JsonConvert.DeserializeObject<Usuario>(linea);

                if (usuario != null && usuario.Nombre == nombreUsuario)
                {
                    encontrado = true;
                    usuario.Estado = true; 
                }

                usuarios.Add(usuario); 
            }

            if (!encontrado)
            {
                return "Error: Usuario no encontrado.";
            }

            
            File.WriteAllText(rutaArchivo, ""); 
            foreach (var usuario in usuarios)
        {
                File.AppendAllText(rutaArchivo, JsonConvert.SerializeObject(usuario) + Environment.NewLine);
            }

            return "Bien"; 
        }


        public string ActualizarEstadoSolicitud(string rutaArchivo, string nombreSolicitud)
        {
            if (!File.Exists(rutaArchivo))
            {
                return "Error: El archivo no existe.";
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            var solicitudes = new List<Solicitud>();
            bool encontrado = false;

            foreach (var linea in lineas)
            {
                var solicitud = JsonConvert.DeserializeObject<Solicitud>(linea);

                if (solicitud != null && solicitud.Nombre_S == nombreSolicitud)
                {
                    encontrado = true;
                    solicitud.estado = true; 
                }

                solicitudes.Add(solicitud);
            }

            if (!encontrado)
            {
                return "Error: Solicitud no encontrada.";
            }

            // Reescribir el archivo con las modificaciones
            File.WriteAllText(rutaArchivo, "");
            foreach (var solicitud in solicitudes)
    {
                File.AppendAllText(rutaArchivo, JsonConvert.SerializeObject(solicitud) + Environment.NewLine);
            }

            return "Estado de la solicitud actualizado.";
        }




        public string ActualizarEstadoSolicitud2(string rutaArchivo, string nombreSolicitud)
        {
            if (!File.Exists(rutaArchivo))
            {
                return "Error: El archivo no existe.";
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            var solicitudes = new List<Solicitud>();
            bool encontrado = false;

            foreach (var linea in lineas)
            {
                var solicitud = JsonConvert.DeserializeObject<Solicitud>(linea);

                if (solicitud != null && solicitud.Nombre_S == nombreSolicitud)
                {
                    encontrado = true;
                    solicitud.estado = false; // Cambiar el estado a falso
                }

                solicitudes.Add(solicitud); 
            }

            if (!encontrado)
            {
                return "Error: Solicitud no encontrada.";
            }

            File.WriteAllText(rutaArchivo, "");
            foreach (var solicitud in solicitudes)
    {
                File.AppendAllText(rutaArchivo, JsonConvert.SerializeObject(solicitud) + Environment.NewLine);
            }

            return "Estado de la solicitud actualizado.";
        }











        public string ActualizarEstado2(string rutaArchivo, string nombreUsuario)
        {
            if (!File.Exists(rutaArchivo))
            {
                return "Error: El archivo no existe.";
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            var usuarios = new List<Usuario>();
            bool encontrado = false;

            foreach (var linea in lineas)
            {
                var usuario = JsonConvert.DeserializeObject<Usuario>(linea);

                if (usuario != null && usuario.Nombre == nombreUsuario)
                {
                    encontrado = true;
                    usuario.Estado = false;
                }

                usuarios.Add(usuario);
            }

            if (!encontrado)
            {
                return "Error: Usuario no encontrado.";
            }


            File.WriteAllText(rutaArchivo, "");
            foreach (var usuario in usuarios)
            {
                File.AppendAllText(rutaArchivo, JsonConvert.SerializeObject(usuario) + Environment.NewLine);
            }

            return "Bien";
        }




        public string ActualizarEstadoConductor(string rutaArchivo, string nombreUsuario)
        {
            if (!File.Exists(rutaArchivo))
            {
                return "Error: El archivo no existe.";
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            var usuarios = new List<Usuario>();
            bool encontrado = false;

            foreach (var linea in lineas)
        {
                var usuario = JsonConvert.DeserializeObject<Usuario>(linea);

                if (usuario != null && usuario.Nombre == nombreUsuario)
                {
                    encontrado = true;
                    usuario.Conductor = true; 
                }

                usuarios.Add(usuario); 
            }

            if (!encontrado)
            {
                return "Error: Usuario no encontrado.";
            }

            
            File.WriteAllText(rutaArchivo, ""); 
            foreach (var usuario in usuarios)
        {
                File.AppendAllText(rutaArchivo, JsonConvert.SerializeObject(usuario) + Environment.NewLine);
            }

            return "Bien"; 
        }


        public string ActualizarEstadoConductor2(string rutaArchivo, string nombreUsuario)
        {
            if (!File.Exists(rutaArchivo))
            {
                return "Error: El archivo no existe.";
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            var usuarios = new List<Usuario>();
            bool encontrado = false;

            foreach (var linea in lineas)
            {
                var usuario = JsonConvert.DeserializeObject<Usuario>(linea);

                if (usuario != null && usuario.Nombre == nombreUsuario)
                {
                    encontrado = true;
                    usuario.Conductor = false;
                }

                usuarios.Add(usuario);
            }

            if (!encontrado)
            {
                return "Error: Usuario no encontrado.";
            }


            File.WriteAllText(rutaArchivo, "");
            foreach (var usuario in usuarios)
            {
                File.AppendAllText(rutaArchivo, JsonConvert.SerializeObject(usuario) + Environment.NewLine);
            }

            return "Bien";
        }






        public List<Usuario> BuscarUsuariosPorNombre(string nombreBuscado)
        {
            var resultados = new List<Usuario>();

            if (File.Exists(ruta_Archivo_usuarios))
            {
                var lineas = File.ReadAllLines(ruta_Archivo_usuarios);

                foreach (var linea in lineas)
        {
                    var usuario = JsonConvert.DeserializeObject<Usuario>(linea);

                    if (usuario != null && usuario.Nombre == nombreBuscado) 
                    {
                        resultados.Add(usuario);
                    }
                }
            }
            return resultados; 
        }



        public string Buscar(string nombreBuscado)
        {
            string salario = "";

            if (File.Exists(ruta_Archivo_usuarios))
            {
                var lineas = File.ReadAllLines(ruta_Archivo_usuarios);

                foreach (var linea in lineas)
                {
                    var usuario = JsonConvert.DeserializeObject<Usuario>(linea);

                    if (usuario != null && usuario.Nombre == nombreBuscado)
                    {
                        salario = usuario.Ingresos.ToString();
                    }
                }
            }
            return salario;
        }


        public string BuscarSexoPorNombre(string nombreBuscado)
        {
            string sexo = "";

            if (File.Exists(ruta_Archivo_usuarios))
            {
                var lineas = File.ReadAllLines(ruta_Archivo_usuarios);

                foreach (var linea in lineas)
                {
                    var usuario = JsonConvert.DeserializeObject<Usuario>(linea);

                    if (usuario != null && usuario.Nombre == nombreBuscado)
                    {
                        sexo = usuario.Sexo; 
                        break; 
                    }
                }
            }
            else
            {
                sexo = "Archivo no encontrado"; 
            }

            return sexo; 
        }



        public string EliminarSolicitudPorNombre(string rutaArchivo, string nombreSolicitud)
        {
            if (File.Exists(rutaArchivo))
            {
                var lineas = File.ReadAllLines(rutaArchivo);
                var solicitudes = new List<Solicitud>();
                string nombreConductorEliminado = null;

                foreach (var linea in lineas)
        {
                    var solicitud = JsonConvert.DeserializeObject<Solicitud>(linea);

                    if (solicitud.Nombre_S == nombreSolicitud)
                    {
                        nombreConductorEliminado = solicitud.Nombre_Conductor; // Capturar el nombre del conductor
                    }
                    else
                    {
                        solicitudes.Add(solicitud); 
                    }
                }

                File.WriteAllText(rutaArchivo, "");
                foreach (var solicitud in solicitudes)
        {
                    File.AppendAllText(rutaArchivo, JsonConvert.SerializeObject(solicitud) + Environment.NewLine);
                }

                return nombreConductorEliminado; 
            }
            else
            {
                return "éxito";
            }
        }





        private int obtenerTamanioS(string ruta)
        {

            int cont = 0;
            var solicitudes = new List<Solicitud>();

            if (File.Exists(ruta))
            {
                var lineas = File.ReadAllLines(ruta);

                foreach (var linea in lineas)
                {
                    var solicitud = JsonConvert.DeserializeObject<Solicitud>(linea);
                    cont++;
                }
                return cont;
            }

            return 0;
        }


        private List<Solicitud> ObtenerTodasLasSolicitudes(string ruta)
        {
            var solicitudes = new List<Solicitud>();

            if (File.Exists(ruta))
            {
                var lineas = File.ReadAllLines(ruta);

                foreach (var linea in lineas)
                {
                    var solicitud = JsonConvert.DeserializeObject<Solicitud>(linea);
                    solicitudes.Add(solicitud);
                }
                return solicitudes;
            }

            return new List<Solicitud>();
        }


        public string ObtenerNombreConductorPorSolicitud(string ruta,string nombreSolicitud)
        {
        
            if (File.Exists(ruta))
            {
                
                var lineas = File.ReadAllLines(ruta);
                string nombreConductor = "sexo";

                foreach (var linea in lineas)
                {
                    var solicitud = JsonConvert.DeserializeObject<Solicitud>(linea);

                    if (solicitud != null && solicitud.Nombre_S == nombreSolicitud)
                    {
                        nombreConductor = solicitud.Nombre_Conductor; 
                        break; 
                    }
                }

                return nombreConductor; 
            }
            else
            {
                Console.WriteLine("El archivo de solicitudes no existe.");
                return "error";
            }
        }



        public string ObtenerEstadoUsuario(string rutaArchivo, string nombreUsuario)
        {
            if (!File.Exists(rutaArchivo))
            {
                return "Error: El archivo no existe.";
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            string estado = "Usuario"; 
            bool encontrado = false;

            foreach (var linea in lineas)
    {
                var usuario = JsonConvert.DeserializeObject<Usuario>(linea);

                if (usuario != null && usuario.Nombre == nombreUsuario)
                {
                    encontrado = true;
                    estado = usuario.Conductor ? "Conductor" : "Usuario"; 
                    break; 
                }
            }

            if (!encontrado)
            {
                return "Error: Usuario no encontrado.";
            }

            return estado;
        }



        public string ObtenerNombreUsuarioPorSolicitud(string rutaArchivo, string nombreSolicitud)
        {
            
            if (!File.Exists(rutaArchivo))
            {
                return "error: El archivo no existe."; 
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            string nombreUsuario = "no encontrado"; 

            
            foreach (var linea in lineas)
            {
                var solicitud = JsonConvert.DeserializeObject<Solicitud>(linea); 

                
                if (solicitud != null && solicitud.Nombre_S == nombreSolicitud)
                {
                    nombreUsuario = solicitud.Nombre_Usuario; 
                    break; 
                }
            }

            return nombreUsuario; // Devolver el nombre del usuario
        }





        private List<Usuario> ObtenerConductoresTop(int top)
        {
            var usuarios = new List<Usuario>();

            if (File.Exists(ruta_Archivo_usuarios))
            {
                var lineas = File.ReadAllLines(ruta_Archivo_usuarios);

                foreach (var linea in lineas)
                {
                    var usuario = JsonConvert.DeserializeObject<Usuario>(linea);
                    usuarios.Add(usuario);
                }


                var conductores = usuarios
                    .Where(u => u.Conductor)
                    .OrderByDescending(u => u.Calificacion)
                    .Take(top)
                    .ToList();


                Random rnd = new Random();
                var conductoresAleatorios = conductores.OrderBy(x => rnd.Next()).ToList(); // Ordenar aleatoriamente

                return conductoresAleatorios;
            }

            return new List<Usuario>();
        }



        private void btnDetenerServidor_Click_1(object sender, EventArgs e)
        {
            if (_servidorActivo)
            {
                _servidorSocket.Close();
                _servidorActivo = false;
                Console.WriteLine("Servidor detenido");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Método intacto
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

public class Mensaje
{
    public string Tipo { get; set; }
    public string Contenido { get; set; }
    public string nombreC { get; set; }
    public string calificacion{get;set;}
    }


    public class Usuario
    {
        public decimal Calificacion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Passaword { get; set; }
        public string Sexo { get; set; }
        public decimal Ingresos { get; set; }
        public bool Conductor { get; set; }
        public bool Estado { get; set; }
    }

    public class DatosLogin
    {
        public string Nombre { get; set; }
        public string Password { get; set; }
    }

    public class Solicitud
    {
        public string Nombre_S { get; set; }
        public string Dinero { get; set; }
        public string Cantidad_Pasajeros { get; set; }
        public string CuidadE { get; set; }
        public string CuidadS { get; set; }
        public string Ip_Google { get; set; }
        public string Nombre_Usuario { get; set; } 
        public string Nombre_Conductor { get; set; } 
        public bool estado { get; set; }
    }



   public class Auto
    {
        public string Color { get; set; }
        public string NumeroPlaca { get; set; }
        public string TipoAuto { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
    }

}



