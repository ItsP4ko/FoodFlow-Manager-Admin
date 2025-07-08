using Controladora.Seguridad;
using Modelo.Context;
using Servicios;
using Servicios.Services;
using Servicios.Servicios.ServiciosMain;
using System;
using System.Windows.Forms;

namespace Controladora.Aderezos
{
    public class ABMAderezos
    {
        private readonly AderezoServiceMain _aderezoService;
        private readonly PasswordCheck _passwordCheck;
        private readonly int _idUsuario;

        public ABMAderezos(int idUsuario)
        {
            var context = new EasyFoodFlowContext();
            _aderezoService = new AderezoServiceMain(context);
            _passwordCheck = new PasswordCheck();
            _idUsuario = idUsuario;
        }

        public bool AgregarAderezo(string nombre, bool estado, decimal precio, int idRestaurante)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionCocina"))
            {
                MessageBox.Show("No tienes permiso");
                return false;
            }

            if (string.IsNullOrWhiteSpace(nombre) || precio <= 0)
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_aderezoService.RestauranteExiste(idRestaurante))
            {
                MessageBox.Show($"No existe el restaurante con Id = {idRestaurante}.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_aderezoService.YaExiste(nombre, idRestaurante))
            {
                MessageBox.Show("Ya existe un aderezo con este nombre en este restaurante.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                _aderezoService.CrearAderezo(nombre, estado, precio, idRestaurante);
                MessageBox.Show("Aderezo creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el aderezo: " + ex.Message);
                return false;
            }
        }

        public bool ModificarAderezo(int idAderezo, decimal precio, bool estado, string nombre)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionCocina"))
            {
                MessageBox.Show("No tienes permiso");
                return false;
            }

            try
            {
                var aderezo = _aderezoService.ObtenerPorId(idAderezo);
                if (aderezo == null)
                {
                    MessageBox.Show("Aderezo no encontrado.");
                    return false;
                }

                _aderezoService.ModificarAderezo(aderezo, nombre, precio, estado);
                MessageBox.Show("Aderezo modificado exitosamente.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el aderezo: " + ex.Message);
                return false;
            }
        }
    }
}
