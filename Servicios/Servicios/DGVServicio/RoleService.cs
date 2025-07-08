using Modelo.Context;
using Servicios.DTOs;

namespace Servicios.Services
{
    public class RoleService
    {
        private readonly EasyFoodFlowContext _context;

        public RoleService(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public List<RoleDTO> ObtenerTodos()
        {
            return _context.Roles
                .Select(r => new RoleDTO
                {
                    IdRol = r.IdRol,
                    Nombre = r.Nombre
                }).ToList();
        }
        public List<RoleDTO> BuscarPorNombre(string nombre)
        {
            return _context.Roles
                .Where(r => r.Nombre.ToLower().Contains(nombre.ToLower()))
                .Select(r => new RoleDTO
                {
                    IdRol = r.IdRol,
                    Nombre = r.Nombre
                }).ToList();
        }

    }
}
