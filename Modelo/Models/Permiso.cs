using Modelo.Interfacez;

namespace Modelo.Models;

public partial class Permiso : IPermissionComponent
{
    public int IdPermiso { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    
    public virtual ICollection<Role> IdRoles { get; set; } = new List<Role>();

    public void Add(IPermissionComponent component)
    {
        throw new NotSupportedException("No se pueden agregar componentes a un permiso individual.");
    }

    public void Remove(IPermissionComponent component)
    {
        throw new NotSupportedException("No se pueden eliminar componentes de un permiso individual.");
    }

    public bool HasPermission(string permission)
    {
        return Nombre.Equals(permission, StringComparison.OrdinalIgnoreCase);
    }
}
