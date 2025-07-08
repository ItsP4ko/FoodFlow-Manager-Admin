using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Modelo.Models;

public partial class PedidoPlato
{
    public PedidoPlato()
    {
        AderezoPedidoPlatos = new HashSet<AderezoPedidoPlato>();
    }

    public int IdPedidoPlato { get; set; }
    
    public int IdPedido { get; set; }
    
    public int IdPlato { get; set; }
    
    public int Cantidad { get; set; }

    public decimal PrecioMomento { get; set; }
    
    public string? Observaciones { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
    
    public virtual Plato IdPlatoNavigation { get; set; } = null!;
    
    public virtual ICollection<AderezoPedidoPlato> AderezoPedidoPlatos { get; set; }

    // Propiedades de compatibilidad con el código existente
    [NotMapped]
    public virtual Pedido Pedido 
    { 
        get => IdPedidoNavigation; 
        set => IdPedidoNavigation = value; 
    }
    
    [NotMapped]
    public virtual Plato Plato 
    { 
        get => IdPlatoNavigation; 
        set => IdPlatoNavigation = value; 
    }

    [NotMapped]
    public decimal PrecioFinal 
        => PrecioMomento * Cantidad
            + AderezoPedidoPlatos.Sum(ap => ap.PrecioMomento * ap.Cantidad); 
    
    [NotMapped]
    public string Descripcion
        => IdPlatoNavigation?.Nombre
            + (AderezoPedidoPlatos.Any()
                ? " + " + string.Join(" + ",
                      AderezoPedidoPlatos.Select(ap => ap.IdAderezoNavigation?.Nombre))
                : "");
}
