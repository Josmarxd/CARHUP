using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarHupApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        Cliente cliente;
        public Login()
        {
            InitializeComponent();
            cliente = new Cliente("192.168.0.75", 5000);
        }


        private void IniciarSesion(object sender, EventArgs e)
        {
            string usuario = Usuario_T.Text;
            string passaword = Passaword_T.Text;


            string respuesta = cliente.iniciarSesion(usuario, passaword);

            if (respuesta == "exitoso") { 
                Application.Current.MainPage = new AppShell();

                string nombreUsuario = Usuario_T.Text;
                var usuarioInfo = new { Usuario = nombreUsuario };
                string json = JsonConvert.SerializeObject(usuarioInfo);

                try
                {
                    string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Nombre.txt");
                    File.WriteAllText(rutaArchivo, json);
                }
                catch (Exception ex)
                {
                    DisplayAlert("ERROR EN EL SISTEMA", ex.Message, "Ok");
                }
            }
            else DisplayAlert("Alerta", "Nombre y contraseña incorrectos", "Ok");
        }
    }
}