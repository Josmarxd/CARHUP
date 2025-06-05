using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHupApp
{
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
        public string detalles { get; set; }


        public Solicitud() { }


        public Solicitud(
            string nombre_S,
            string dinero,
            string cantidad_Pasajeros,
            string cuidadE,
            string cuidadS,
            string ip_Google,
            string nombre_Usuario,
            string nombre_Conductor,
            string detalles)
        {
            this.Nombre_S = nombre_S;
            this.Dinero = dinero;
            this.Cantidad_Pasajeros = cantidad_Pasajeros;
            this.CuidadE = cuidadE;
            this.CuidadS = cuidadS;
            this.Ip_Google = ip_Google;
            this.Nombre_Usuario = nombre_Usuario;
            this.Nombre_Conductor = nombre_Conductor;
            this.detalles = detalles;

        }
    }


}

