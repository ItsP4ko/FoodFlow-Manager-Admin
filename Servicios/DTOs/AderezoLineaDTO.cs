using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DTOs
{
    public class AderezoLineaDTO
    {
        public int IdAderezoPedidoPlato { get; set; }
        public string NombreAderezo { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioMomento { get; set; }
    }
}
