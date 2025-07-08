using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DTOs
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        public int DniCliente { get; set; }
        public decimal Total { get; set; }
        public string? DireccionEntrega { get; set; }
    }
}
