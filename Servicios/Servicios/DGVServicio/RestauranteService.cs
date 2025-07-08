using Modelo.Context;
using Servicios.DTOs;

namespace Servicios.Services
{
    public class RestauranteService
    {
        private readonly EasyFoodFlowContext _context;

        public RestauranteService(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public List<RestauranteDTO> ObtenerTodos()
        {
            return _context.Restaurantes
                .Select(r => new RestauranteDTO
                {
                    IdRestaurante = r.IdRestaurante,
                    Nombre = r.Nombre,
                    Direccion = r.Direccion,
                    Deuda = r.Deuda,
                    Estado = r.Estado
                }).ToList();
        }

        public List<RestauranteDTO> BuscarPorNombre(string nombre)
        {
            return _context.Restaurantes
                .Where(r => r.Nombre.ToLower().Contains(nombre.ToLower()))
                .Select(r => new RestauranteDTO
                {
                    IdRestaurante = r.IdRestaurante,
                    Nombre = r.Nombre,
                    Direccion = r.Direccion,
                    Deuda = r.Deuda,
                    Estado = r.Estado
                }).ToList();
        }
    }
}
