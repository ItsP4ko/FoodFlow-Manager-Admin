using Microsoft.EntityFrameworkCore;
using Modelo.Context;
using Servicios.DTOs;

namespace Servicios.Services
{
    public class PlatoService
    {
        private readonly EasyFoodFlowContext _context;

        public PlatoService(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public List<PlatoDTO> ObtenerPorRestaurante(int idRestaurante)
        {
            return _context.Platos
                .Where(p => p.IdRestaurante == idRestaurante)
                .Select(p => new PlatoDTO
                {
                    IdPlato = p.IdPlato,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Estado = p.Estado == true ? "Habilitado" : "Inactivo"
                }).ToList();
        }

        public List<PlatoDTO> ObtenerPorRestauranteHabilitado(int idRestaurante)
        {
            return _context.Platos
                .Where(p => p.IdRestaurante == idRestaurante).Where(p => p.Estado == true)
                .Select(p => new PlatoDTO
                {
                    IdPlato = p.IdPlato,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Estado = p.Estado == true ? "Habilitado" : "Inactivo"
                }).ToList();
        }
        public List<PlatoDTO> BuscarPorNombre(int idRestaurante, string nombre)
        {
            return _context.Platos
                .Where(p => p.IdRestaurante == idRestaurante && p.Nombre.ToLower().Contains(nombre.ToLower()))
                .Select(p => new PlatoDTO
                {
                    IdPlato = p.IdPlato,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Estado = p.Estado == true ? "Habilitado" : "Inactivo"
                }).ToList();
        }

        public List<PlatoDTO> BuscarPorNombreCategoria(int idRestaurante, string categoriaNombre)
        {
            return _context.Platos
                .Include(p => p.CategoriaNavigation)
                .Where(p => p.IdRestaurante == idRestaurante
                            && p.CategoriaNavigation.Nombre.ToLower().Contains(categoriaNombre.ToLower()))
                .Select(p => new PlatoDTO
                {
                    IdPlato = p.IdPlato,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Estado = p.Estado == true ? "Habilitado" : "Inactivo"
                }).ToList();
        }


    }
}
