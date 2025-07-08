using System;
using System.Collections.Generic;

namespace Modelo.Models;

public partial class Cliente : Persona
{
    public int Dni { get; set; }
    public string? Direccion { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
