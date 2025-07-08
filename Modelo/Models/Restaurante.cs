using System;
using System.Collections.Generic;

namespace Modelo.Models;

public partial class Restaurante
{
    public Restaurante()
    {
        Platos = new HashSet<Plato>();
        Pedidos = new HashSet<Pedido>();
        Aderezos = new HashSet<Aderezo>();
        AdminRestaurantes = new HashSet<AdminRestaurante>();
        AdminCocinas = new HashSet<AdminCocina>();
        CajeroRestaurantes = new HashSet<CajeroRestaurante>();
        Menus = new HashSet<Menu>();
    }

    public int IdRestaurante { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public decimal Deuda { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<AdminRestaurante> AdminRestaurantes { get; set; }

    public virtual ICollection<AdminCocina> AdminCocinas { get; set; }

    public virtual ICollection<CajeroRestaurante> CajeroRestaurantes { get; set; }

    public virtual ICollection<Aderezo> Aderezos { get; set; }

    public virtual ICollection<Menu> Menus { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; }

    public virtual ICollection<Plato> Platos { get; set; }
}
