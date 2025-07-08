using System;
using System.Linq;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using Modelo.Context;
using Modelo.Models;

namespace Controladora.Seguridad
{
    public class ControladoraRolesPermisos
    {
        private readonly EasyFoodFlowContext _context;
        private readonly PasswordCheck _passwordCheck;

        public ControladoraRolesPermisos()
        {
            _context = new EasyFoodFlowContext();
            _passwordCheck = new PasswordCheck();
        }


        // Crear un nuevo rol
        public void CrearRol(string nombreRol, int idUsuario)
        {
            // 1. Validaciones
            if (string.IsNullOrWhiteSpace(nombreRol))
                throw new ArgumentException("El nombre del rol no puede estar vacío.", nameof(nombreRol));

            if (!_passwordCheck.TienePermiso(idUsuario, "GestionAdminAdmin"))   
                throw new UnauthorizedAccessException("No tienes permiso para gestionar roles y permisos.");

            if (_context.Roles.Any(r => r.Nombre == nombreRol))
            {
                MessageBox.Show($"Ya existe un rol con el nombre '{nombreRol}'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Crear y guardar
            var nuevoRol = RoleFactory.CrearNuevoRole(nombreRol);
            _context.Roles.Add(nuevoRol);
            _context.SaveChanges();

            MessageBox.Show($"Rol '{nombreRol}' creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // Crear Permiso Nuevo
        public void CrearPermiso(string nombre, int idUsuario)
        {
            
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del permiso no puede estar vacío.", nameof(nombre));

            if (_context.Permisos.Any(p => p.Nombre == nombre))
                throw new InvalidOperationException("Ya existe un permiso con este nombre.");

            if (!_passwordCheck.TienePermiso(idUsuario, "GestionAdminAdmin"))
                throw new UnauthorizedAccessException("El rol no tiene permiso para gestionar roles y permisos.");

            var nuevoPermiso = new Permiso { Nombre = nombre };
            _context.Permisos.Add(nuevoPermiso);
            _context.SaveChanges();
        }


        // Asignar un permiso a un rol
        public void AsignarPermisoARol(int idRolObjetivo, int idPermiso, int idUsuario)
        {
            
            if (!_passwordCheck.TienePermiso(idUsuario, "GestionAdminAdmin"))
                throw new UnauthorizedAccessException(
                   "No tienes permiso para gestionar roles y permisos.");

            
            var rol = RoleFactory.CargarPorId(idRolObjetivo, _context);

            
            var permiso = _context.Permisos.Find(idPermiso);
            if (permiso == null)
                return;

            
            if (!rol.IdPermisos.Any(p => p.IdPermiso == idPermiso))
            {
                rol.IdPermisos.Add(permiso);
                _context.SaveChanges();
            }
        }

        public void AsignarRolARol(int idRolPadre, int idRolHijo, int idUsuario)
        {
            if (!_passwordCheck.TienePermiso(idUsuario, "GestionadminAdmin"))
                throw new UnauthorizedAccessException(
                    "No tienes permiso para gestionar roles y permisos.");

            var rolPadre = RoleFactory.CargarPorId(idRolPadre, _context); 
            var rolHijo = RoleFactory.CargarPorId(idRolHijo, _context);

            if (rolPadre == null)
                throw new Exception($"El rol padre con ID {idRolPadre} no fue encontrado.");

            if (rolHijo == null)
                throw new Exception($"El rol hijo con ID {idRolHijo} no fue encontrado.");

            if (!rolPadre.RolesHijos.Any(r => r.IdRol == idRolHijo))
            {
                rolPadre.RolesHijos.Add(rolHijo);
                _context.SaveChanges(); 
            }
            else
            {
                throw new Exception($"El rol '{rolHijo.Nombre}' ya es hijo del rol '{rolPadre.Nombre}'.");
            }
        }


        // Eliminar un permiso de un rol
        public void EliminarPermisoDeRol(int idRol, int idPermiso, int idUsuario)
        {

            var rol = _context.Roles.Include(r => r.IdPermisos).FirstOrDefault(r => r.IdRol == idRol);
            var permiso = _context.Permisos.Find(idPermiso);

            if (rol == null)
                throw new InvalidOperationException("Rol no encontrado.");

            if (permiso == null)
                throw new InvalidOperationException("Permiso no encontrado.");

            if (!_passwordCheck.TienePermiso(idUsuario, "GestionAdminAdmin"))
                throw new UnauthorizedAccessException("El rol no tiene permiso para gestionar roles y permisos.");

            if (rol.IdPermisos.Any(p => p.IdPermiso == idPermiso))
            {
                rol.IdPermisos.Remove(permiso);
                _context.SaveChanges();
            }
        }


        // Eliminar un rol existente
        public void EliminarRol(int idRol, int idUsuario)
        {
            var rol = _context.Roles
                .Include(r => r.IdPermisos)
                .Include(r => r.Usuarios)
                .ThenInclude(u => u.DniNavigation)  
                .FirstOrDefault(r => r.IdRol == idRol);

            if (rol == null)
                throw new InvalidOperationException("Rol no encontrado.");

            if (!_passwordCheck.TienePermiso(idUsuario, "GestionAdminAdmin"))
                throw new UnauthorizedAccessException("El rol no tiene permiso para gestionar roles y permisos.");

            // Verificar si el rol está asignado a usuarios o entidades relacionadas
            if (rol.Usuarios.Any())
                throw new InvalidOperationException("No se puede eliminar el rol porque está asignado a uno o más usuarios o entidades.");

            // Eliminar relaciones con permisos
            rol.IdPermisos.Clear();

            // Eliminar el rol
            _context.Roles.Remove(rol);
            _context.SaveChanges();
        }


        // Modificar un rol existente
        public void ModificarRol(int idRol, string nuevoNombre, int idUsuario)
        {
            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new ArgumentException("El nombre del rol no puede estar vacío.", nameof(nuevoNombre));

            if (!_passwordCheck.TienePermiso(idUsuario, "GestionAdminAdmin"))
                throw new UnauthorizedAccessException("El rol no tiene permiso para gestionar roles y permisos.");

            var rol = _context.Roles.Find(idRol);
            if (rol == null)
                throw new InvalidOperationException("Rol no encontrado.");

            if (_context.Roles.Any(r => r.Nombre == nuevoNombre && r.IdRol != idRol))
                throw new InvalidOperationException("Ya existe otro rol con este nombre.");

            rol.Nombre = nuevoNombre;
            _context.SaveChanges();
        }
        

        // Modificar un permiso existente
        public void ModificarPermiso(int idPermiso, string nuevoNombre, int idUsuario)
        {

            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new ArgumentException("El nombre del permiso no puede estar vacío.", nameof(nuevoNombre));

            if (!_passwordCheck.TienePermiso(idUsuario, "GestionAdminAdmin"))
                throw new UnauthorizedAccessException("El rol no tiene permiso para gestionar roles y permisos.");

            var permiso = _context.Permisos.Find(idPermiso);
            if (permiso == null)
                throw new InvalidOperationException("Permiso no encontrado.");

            if (_context.Permisos.Any(p => p.Nombre == nuevoNombre && p.IdPermiso != idPermiso))
                throw new InvalidOperationException("Ya existe otro permiso con este nombre.");

            permiso.Nombre = nuevoNombre;
            _context.SaveChanges();
        }
    }
}
