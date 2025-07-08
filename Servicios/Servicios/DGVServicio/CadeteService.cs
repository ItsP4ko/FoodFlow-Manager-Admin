using Modelo.Context;
using Servicios.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios.DGVServicio
{
    public class CadeteService
    {
        private readonly EasyFoodFlowContext _context;

        public CadeteService(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public List<CadeteDTO> ObtenerTodos()
        {
            return _context.Cadetes
                .Select(c => new CadeteDTO
                {
                    Dni = c.Dni,
                    NombreCompleto = c.NombreCompleto
                }).ToList();
        }

        public List<CadeteDTO> BuscarPorDniParcial(int dniInicio)
        {
            string filtro = dniInicio.ToString();
            return _context.Cadetes
                .Where(c => c.Dni.ToString().StartsWith(filtro))
                .Select(c => new CadeteDTO
                {
                    Dni = c.Dni,
                    NombreCompleto = c.NombreCompleto
                })
                .ToList();
        }
    }
}
