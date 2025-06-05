using System;

namespace CarHup
{
    public class Usuario
    {
        public decimal Calificacion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Passaword { get; set; }
        public string Sexo { get; set; }
        public decimal Ingresos { get; set; }
        public bool Conductor { get; set; } // Indica si es conductor

        public bool Estado { get; set; }

        public string Detalle { get; set; }

        // Constructor que recibe todos los datos
        public Usuario(decimal calificacion, string nombre, string correo, string passaword, string sexo, decimal ingresos, bool conductor,bool estado, string detalle)
        {
            Calificacion = calificacion;
            Nombre = nombre;
            Correo = correo;
            Passaword = passaword;
            Sexo = sexo;
            Ingresos = ingresos;
            Conductor = conductor;
            Estado = estado;
            Detalle = detalle;
        }

        public override string ToString()
        {
            return $"Usuario: Calificación={Calificacion}, Nombre={Nombre}, Correo={Correo}, Contraseña={Passaword}, Sexo={Sexo}, Ingresos={Ingresos:C}, Conductor={Conductor}";
        }
    }
}



