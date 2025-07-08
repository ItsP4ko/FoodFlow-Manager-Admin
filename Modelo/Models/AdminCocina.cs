using System;
using System.Collections.Generic;

namespace Modelo.Models;

public partial class AdminCocina : Persona
{
    public int? IdRestaurante { get; set; }

    public virtual Restaurante? IdRestauranteNavigation { get; set; }
}
