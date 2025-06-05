using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHup
{
    public class Auto
    {
        public string Color { get; set; }
        public string NumeroPlaca { get; set; }
        public string TipoAuto { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public Auto() { }

        public Auto(string color, string numeroPlaca, string tipoAuto, string marca, string modelo)
        {
            Color = color;
            NumeroPlaca = numeroPlaca;
            TipoAuto = tipoAuto;
            Marca = marca;
            Modelo = modelo;
        }
    }

}
