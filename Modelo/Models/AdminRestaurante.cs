using System;
using System.Collections.Generic;

namespace Modelo.Models;

public partial class AdminRestaurante : Persona
{
    public int? IdRestaurante { get; set; }

    public virtual Restaurante? IdRestauranteNavigation { get; set; }
}
