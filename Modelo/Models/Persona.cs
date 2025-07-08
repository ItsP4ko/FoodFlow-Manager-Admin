using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Models;

public partial class Persona
{
    public int Dni { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public string NombreCompleto => $"{Nombre} {Apellido}";

    public Restaurante? RestauranteAsociado
    {
        get
        {
            return this switch
            {
                AdminRestaurante adminR => adminR.IdRestauranteNavigation,
                AdminCocina adminC => adminC.IdRestauranteNavigation,
                CajeroRestaurante cajero => cajero.Restaurante,
                _ => null
            };
        }
    }

    
}
