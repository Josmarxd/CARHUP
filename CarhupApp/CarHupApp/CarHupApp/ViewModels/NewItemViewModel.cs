using CarHupApp.Models;
using CarHupApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarHupApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;
        private string nombre_conductor;
        private string dinero;
        private string cantidad_pasajeros;
        Cliente cliente;

        public NewItemViewModel()
        {
            cliente = new Cliente("192.168.0.75", 5000);
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }


        public string Nombre_Conductor
        {
            get => nombre_conductor;
            set => SetProperty(ref nombre_conductor, value);
        }


        public string Cantidad_Pasajeros
        {
            get => cantidad_pasajeros;
            set => SetProperty(ref cantidad_pasajeros, value);
        }

        public string Dinero
        {
            get => dinero;
            set => SetProperty(ref dinero, value);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
           
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                NombreSolicitud = Text,
                Description = Description,
                nombreConductor = Nombre_Conductor,
                dinero = Dinero,
                cantidad_Pasajero = Cantidad_Pasajeros
                
            };

            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Nombre.txt");
            string jsonString = File.ReadAllText(rutaArchivo);
            var usuarioInfo = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            string nombreUsuario = usuarioInfo["Usuario"];


            


            Solicitud solicitud = new Solicitud(Text, Dinero,Cantidad_Pasajeros, "Ejemplo 1", "Ejemplo 2", "1234566", nombreUsuario,Description, Nombre_Conductor);
            cliente.enviarSolicitud(solicitud);

            await DataStore.AddItemAsync(newItem);
            

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
