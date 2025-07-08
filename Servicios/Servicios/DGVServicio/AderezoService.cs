using Modelo.Context;
using Servicios.DTOs;

namespace Servicios.Services
{
    public class AderezoService
    {
        private readonly EasyFoodFlowContext _context;

        public AderezoService(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public List<AderezoDTO> ObtenerPorRestaurante(int idRestaurante)
        {
            return _context.Aderezos
                .Where(a => a.IdRestaurante == idRestaurante)
                .Select(a => new AderezoDTO
                {
                    IdAderezo = a.IdAderezo,
                    Nombre = a.Nombre,
                    Precio = a.Precio,
                    Estado = a.Estado ? "Habilitado" : "Inactivo"
                }).ToList();
        }

        public List<AderezoDTO> BuscarPorNombre(int idRestaurante, string aderezoNombre)
        {
            return _context.Aderezos
                .Where(a => a.IdRestaurante == idRestaurante
                            && a.Nombre.ToLower().Contains(aderezoNombre.ToLower()))
                .Select(a => new AderezoDTO
                {
                    IdAderezo = a.IdAderezo,
                    Nombre = a.Nombre,
                    Precio = a.Precio,
                    Estado = a.Estado ? "Habilitado" : "Inactivo"
                }).ToList();
        }

    }
}
