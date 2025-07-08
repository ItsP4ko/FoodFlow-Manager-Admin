using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Clases_Auxiliares
{
    public class ExtraGridItem
    {
        public int IdAderezo { get; set; }
        public int Cantidad { get; set; } = 1;
        public decimal Precio { get; set; }
        public bool Seleccionado { get; set; }
        public Aderezo Aderezo { get; set; } = null!;
    }
}
