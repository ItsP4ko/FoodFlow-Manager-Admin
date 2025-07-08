using Modelo.Context;
using Servicios.DTOs;

namespace Servicios.Servicios.DGVServicio
{
    public class PermisoService
    {
        private readonly EasyFoodFlowContext _context;

        public PermisoService(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public List<PermisoDTO> ObtenerTodos()
        {
            return _context.Permisos
                .Select(p => new PermisoDTO
                {
                    IdPermiso = p.IdPermiso,
                    Nombre = p.Nombre
                }).ToList();
        }
        public List<PermisoDTO> BuscarPorNombre(string nombre)
        {
            return _context.Permisos
                .Where(p => p.Nombre.ToLower().Contains(nombre.ToLower()))
                .Select(p => new PermisoDTO
                {
                    IdPermiso = p.IdPermiso,
                    Nombre = p.Nombre
                }).ToList();
        }

        public List<PermisoDTO> ObtenerPorRol(int idRol)
        {
            return _context.Roles
                .Where(r => r.IdRol == idRol)
                .SelectMany(r => r.IdPermisos)
                .Select(p => new PermisoDTO
                {
                    IdPermiso = p.IdPermiso,
                    Nombre = p.Nombre
                }).ToList();
        }

    }
}
