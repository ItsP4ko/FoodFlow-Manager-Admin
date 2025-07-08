using System;
using System.Collections.Generic;

namespace Modelo.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Estado { get; set; }

    public int Dni { get; set; }

    public int IdRol { get; set; }

    public virtual Role? IdRolNavigation { get; set; }

    public virtual Persona DniNavigation { get; set; } = null!;
}
