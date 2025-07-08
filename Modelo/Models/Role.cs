using Modelo.Interfacez;
using Modelo.Models;

namespace Modelo.Models;

public partial class Role : IPermissionComponent
{
    public int IdRol { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public virtual ICollection<Permiso> IdPermisos { get; set; } = new List<Permiso>();
    public virtual ICollection<Role> RolesHijos { get; set; } = new List<Role>();
    public virtual ICollection<Role> RolesPadres { get; set; } = new List<Role>();


    private readonly List<IPermissionComponent> _components = new();
    // Métodos del patrón Composite
    public void Add(IPermissionComponent component)
    {
        if (!_components.Contains(component))
            _components.Add(component);
    }

    public void Remove(IPermissionComponent component)
    {
        if (_components.Contains(component))
            _components.Remove(component);
    }

    public bool HasPermission(string permission)
    {
        return _components.Any(c => c.HasPermission(permission));
    }

    // Método opcional para inicializar la jerarquía con datos de EF
    public void InicializarDesdeEF()
    {
        foreach (var permiso in IdPermisos)
        {
            Add(permiso);
        }

        foreach (var rolHijo in RolesHijos)
        {
            rolHijo.InicializarDesdeEF(); // Recursivo si hay jerarquías
            Add(rolHijo);
        }
    }

}
