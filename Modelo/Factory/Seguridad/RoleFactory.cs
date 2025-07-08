using Microsoft.EntityFrameworkCore;
using Modelo.Context;
using Modelo.Models;

public static class RoleFactory
{
    // Cargar un rol ya existente con sus permisos e hijos
    public static Role CargarPorId(int idRol,
       EasyFoodFlowContext context)
    {
        var role = context.Roles
            .Include(r => r.IdPermisos)
            .Include(r => r.RolesHijos)
                .ThenInclude(h => h.IdPermisos)
            .Include(r => r.RolesHijos)
                .ThenInclude(h => h.RolesHijos)
            .FirstOrDefault(r => r.IdRol == idRol);

        if (role == null)
            throw new ArgumentException($"No se encontró el rol con Id = {idRol}.");

        role.InicializarDesdeEF();
        return role;
    }

    // Crear un rol nuevo vacío (solo nombre)
    public static Role CrearNuevoRole(string nombreRol)
    {
        var nuevoRol = new Role
        {
            Nombre = nombreRol
            
        };

        return nuevoRol;
    }
}
