using Modelo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios.ServiciosExtras
{
    public class DeudaService
    {
        private readonly EasyFoodFlowContext _context;

        public DeudaService(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public async Task<decimal?> ObtenerDeudaAsync(int idRestaurante)
        {
            var restaurante = await _context.Restaurantes.FindAsync(idRestaurante);
            return restaurante?.Deuda;
        }

        public async Task<bool> PagarDeudaAsync(int idRestaurante, decimal monto)
        {
            var restaurante = await _context.Restaurantes.FindAsync(idRestaurante);

            if (restaurante == null || restaurante.Deuda <= 0)
                return false;

            restaurante.Deuda = Math.Max(0, restaurante.Deuda - monto);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
