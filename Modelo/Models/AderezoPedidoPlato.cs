using System;
using System.Collections.Generic;

namespace Modelo.Models;

public partial class AderezoPedidoPlato
{
    public int IdAderezoPedidoPlato { get; set; }
    
    public int IdAderezo { get; set; }
    
    public int IdPedidoPlato { get; set; }

    public int Cantidad { get; set; } = 1;

    public decimal PrecioMomento { get; set; } = 0;

    public virtual Aderezo IdAderezoNavigation { get; set; } = null!;
    
    public virtual PedidoPlato IdPedidoPlatoNavigation { get; set; } = null!;

    // Propiedades de compatibilidad con el código existente
    public virtual Aderezo Aderezo 
    { 
        get => IdAderezoNavigation; 
        set => IdAderezoNavigation = value; 
    }
    
    public virtual PedidoPlato PedidoPlato 
    { 
        get => IdPedidoPlatoNavigation; 
        set => IdPedidoPlatoNavigation = value; 
    }
}
