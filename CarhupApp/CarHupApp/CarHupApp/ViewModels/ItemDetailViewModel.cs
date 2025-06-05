using CarHupApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarHupApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        private string nombreConductor;
        private string dinero;
        private string cantidadPasajero;

        public string Id { get; set; }

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

        public string NombreConductor
        {
            get => nombreConductor;
            set => SetProperty(ref nombreConductor, value);
        }

        public string Dinero
        {
            get => dinero;
            set => SetProperty(ref dinero, value);
        }

        public string CantidadPasajero
        {
            get => cantidadPasajero;
            set => SetProperty(ref cantidadPasajero, value);
        }

        public async Task LoadItem(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.NombreSolicitud;
                Description = item.Description;
                NombreConductor = item.nombreConductor;
                Dinero = item.dinero;
                CantidadPasajero = item.cantidad_Pasajero;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}


