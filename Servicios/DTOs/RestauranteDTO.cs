using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DTOs
{
    public class RestauranteDTO
    {
        public int IdRestaurante { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public decimal Deuda { get; set; }
        public string? Estado { get; set; }
    }
}
