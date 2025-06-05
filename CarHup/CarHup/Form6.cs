using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarHup
{
    public partial class Form6 : Form
    {

        Cliente cliente = new Cliente("192.168.36.183", 5000);
        string nombre;
        public Form6(string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto(Color_T.Text, Placa_T.Text, Tipo_T.Text, Marca_T.Text, Modelo_T.Text);
            cliente.enviarDatosAuto(auto, nombre);
            this.Hide();
            
        }
    }
}
