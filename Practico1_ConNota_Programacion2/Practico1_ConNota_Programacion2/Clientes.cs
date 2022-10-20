using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico1_ConNota_Programacion2
{
    internal class Clientes
    {
        public string nombreCliente { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string tipoCliente { get; set; }
        public int idCliente { get; set; }

        public void validarOrdenDePago()
        {
            if (tipoCliente == "Empresa")
            {
                Console.WriteLine("\nRecibimos la correspondiente orden de pago para poder confirmar la compra");
            }
        }

        public string getCliente()
        {
            return $"{nombreCliente} - ({tipoCliente})";
        }
    }
}
