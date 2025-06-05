using CarHupApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace CarHupApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        Cliente cliente = new Cliente("192.168.0.75", 5000);

        public MockDataStore()
        {
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Nombre.txt");
            string jsonString = File.ReadAllText(rutaArchivo);
            var usuarioInfo = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            string nombreUsuario = usuarioInfo["Usuario"];

            var solicitudes = cliente.PedirMisSolicitudes(nombreUsuario);
            var solicitudes2 = JsonConvert.DeserializeObject<List<Solicitud>>(solicitudes);

            items = new List<Item>();

            foreach (var solicitud in solicitudes2)
            {
                if(solicitud.Nombre_S == null || solicitud.Nombre_S == " ") new Item { Id = Guid.NewGuid().ToString(), NombreSolicitud = "Vacio", Description = "No hay solicitud" };
                else new Item { Id = Guid.NewGuid().ToString(), NombreSolicitud = solicitud.Nombre_S, Description = solicitud.Nombre_Conductor };
            }


        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }



        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}