using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DTOs
{
    public class AderezoDTO
    {
        public int IdAderezo { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public string Estado { get; set; } = null!;
    }
}
