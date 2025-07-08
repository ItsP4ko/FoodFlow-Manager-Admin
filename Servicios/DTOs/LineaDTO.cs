using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DTOs
{
    public class LineaDTO
    {
        public int IdPedidoPlato { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioMomento { get; set; }
        public string? Observaciones { get; set; }

        // Información del plato
        public string NombrePlato { get; set; } = string.Empty;
        public string? DescripcionPlato { get; set; }

        // Aderezos
        public List<AderezoLineaDTO> Aderezos { get; set; } = new List<AderezoLineaDTO>();

        // Total de la línea
        public decimal TotalLinea { get; set; }
    }
}
