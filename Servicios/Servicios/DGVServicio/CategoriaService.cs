using Modelo.Context;
using Servicios.DTOs;

namespace Servicios.Services
{
    public class CategoriaService
    {
        private readonly EasyFoodFlowContext _context;

        public CategoriaService(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public List<CategoriaDTO> ObtenerPorRestaurante(int idRestaurante)
        {
            return _context.Categorias
                .Where(c => c.IdRestaurante == idRestaurante)
                .Select(c => new CategoriaDTO
                {
                    IdCategoria = c.IdCategoria,
                    Nombre = c.Nombre,
                    Estado = c.Estado ? "Habilitado" : "Inactivo"
                }).ToList();
        }
    }
}
