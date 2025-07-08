using System;
using System.Collections.Generic;

namespace Modelo.Models;

public partial class CadetePedido
{
    public int IdCadetePedido { get; set; }

    public int DniCadete { get; set; }

    public int IdPedido { get; set; }
    
    public DateTime? FechaAsignacion { get; set; }

    public virtual Cadete DniCadeteNavigation { get; set; } = null!;

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
