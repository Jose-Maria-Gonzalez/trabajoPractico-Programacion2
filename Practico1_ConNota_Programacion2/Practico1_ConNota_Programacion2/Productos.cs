using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico1_ConNota_Programacion2
{
    internal class Productos
    {
        public string nombreProducto { get; set; }
        public int precio { get; set; }

        public string getProductos()
        {
            return $"{nombreProducto} - ${precio}";
        }
    }
}
