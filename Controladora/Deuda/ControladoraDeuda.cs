using Controladora.Seguridad;
using DocumentFormat.OpenXml.Vml;
using Modelo.Context;
using Servicios.Servicios.ServiciosExtras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Deuda
{
    public class ControladoraDeuda
    {
        private readonly DeudaService _deudaService;
        private readonly PasswordCheck _passwordCheck;
        private readonly int _idUsuario;

        public ControladoraDeuda(int idUsuario)
        {
            var context = new EasyFoodFlowContext();
            _deudaService = new DeudaService(context);
            _passwordCheck = new PasswordCheck();
            _idUsuario = idUsuario;
        }

        public async Task<bool> PagarDeudaAsync(int idRestaurante, decimal total)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionRestaurante"))
            {
                MessageBox.Show("No tienes permiso");
                return false;
            }

            try
            {
                bool pagado = await _deudaService.PagarDeudaAsync(idRestaurante, total);

                if (!pagado)
                {
                    MessageBox.Show("No se pudo aplicar el pago. Verificá la deuda actual.");
                    return false;
                }

                MessageBox.Show("Pago realizado correctamente.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el pago: " + ex.Message);
                return false;
            }
        }

        public async Task<decimal> RecuperarDeudaAsync(int idRestaurante)
        {
            try
            {
                var deuda = await _deudaService.ObtenerDeudaAsync(idRestaurante);
                if (deuda == null)
                {
                    MessageBox.Show("No se encontró el restaurante o no tiene deuda registrada.");
                    return 0;
                }
                return deuda.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar la deuda: " + ex.Message);
                return 0;
            }
        }
    }
}
