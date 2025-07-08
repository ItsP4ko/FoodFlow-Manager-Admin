using System;
using System.Collections.Generic;

namespace Modelo.Models;

public partial class Cadete : Persona
{
    public int Dni { get; set; }
    public string? Estado { get; set; }

    public virtual ICollection<CadetePedido> CadetePedidos { get; set; } = new List<CadetePedido>();
}
