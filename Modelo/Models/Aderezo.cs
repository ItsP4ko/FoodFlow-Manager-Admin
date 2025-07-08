using System;
using System.Collections.Generic;

namespace Modelo.Models;

public partial class Aderezo
{
    public Aderezo()
    {
        AderezoPedidoPlatos = new HashSet<AderezoPedidoPlato>();
    }

    public int IdAderezo { get; set; }
    
    public string Nombre { get; set; } = null!;
    
    public decimal Precio { get; set; }
    
    public bool Estado { get; set; }
    
    public string? Descripcion { get; set; }

    public int IdRestaurante { get; set; }

    public int IdPlato { get; set; }
    
    public virtual Restaurante IdRestauranteNavigation { get; set; } = null!;
    
    public virtual ICollection<AderezoPedidoPlato> AderezoPedidoPlatos { get; set; }
    
    public override string ToString() => $"{Nombre} – ${Precio}";
}
