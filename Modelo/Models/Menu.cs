using System;
using System.Collections.Generic;

namespace Modelo.Models;

public partial class Menu
{
    public int IdMenu { get; set; }

    public byte[]? Pdf { get; set; }

    public int IdRestaurante { get; set; }

    public string Categoria { get; set; } = null!;
    
    public DateTime? FechaCreacion { get; set; }
    
    public bool? Estado { get; set; }

    public virtual Restaurante IdRestauranteNavigation { get; set; } = null!;
}
