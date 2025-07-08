using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DTOs
{
    public class ReporteProductoDTO
    {
        public string NombrePlato { get; set; } = string.Empty;
        public int CantidadVendida { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }
    }
}
