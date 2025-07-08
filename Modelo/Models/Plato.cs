using System;
using System.Collections.Generic;

namespace Modelo.Models;

public partial class Plato 
{
    public Plato()
    {
        PedidoPlatos = new HashSet<PedidoPlato>();
    }

    public int IdPlato { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }   

    public bool Estado { get; set; }

    public int Categoria { get; set; }

    public int IdRestaurante { get; set; }

    public virtual Restaurante IdRestauranteNavigation { get; set; } = null!;

    public virtual Categoria CategoriaNavigation { get; set; } = null!;
    
    public virtual ICollection<PedidoPlato> PedidoPlatos { get; set; }
}
