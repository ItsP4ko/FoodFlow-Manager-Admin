using Controladora.Seguridad;
using Modelo.Context;
using Modelo.Models;
using Servicios.Platos;
using System;
using System.Windows.Forms;

namespace Controladora.Platos
{
    public class ABMPlatos
    {
        private readonly EasyFoodFlowContext _context;
        private readonly PasswordCheck _passwordCheck;
        private readonly PlatoServiceMain _platoService;
        private readonly int _idUsuario;

        public ABMPlatos(int idUsuario)
        {
            _context = new EasyFoodFlowContext();
            _platoService = new PlatoServiceMain(_context);
            _passwordCheck = new PasswordCheck();
            _idUsuario = idUsuario;
        }

        public bool AgregarPlato(string nombre, bool estado, decimal precio, int idRestaurante, int idCategoria)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionCocina"))
            {
                MessageBox.Show("No tienes permiso");
                return false;
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, complete todos los campos.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_platoService.RestauranteExiste(idRestaurante))
            {
                MessageBox.Show($"No existe el restaurante con Id = {idRestaurante}.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_platoService.YaExiste(nombre))
            {
                MessageBox.Show("Ya existe un plato con este nombre.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                _platoService.CrearPlato(nombre, estado, precio, idRestaurante, idCategoria);
                MessageBox.Show("Plato creado exitosamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el plato:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Logica para hacer un borrado de un plato, se utiliza modificar en el caso de elimianr ya que se hace una Baja Logica
        public bool EliminarPlato(int idPlato)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionCocina"))
            {
                MessageBox.Show("No tienes permiso");
                return false;
            }

            try
            {
                var plato = _platoService.ObtenerPorId(idPlato);
                if (plato == null)
                {
                    MessageBox.Show("Plato no encontrado.");
                    return false;
                }

                _platoService.EliminarPlato(plato);
                MessageBox.Show("Plato eliminado exitosamente.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el plato: {ex.Message}");
                return false;
            }
        }

        public bool ModificarPlato(int idPlato, bool estado, int idRestaurante)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionCocina"))
            {
                MessageBox.Show("No tienes permiso");
                return false;
            }

            try
            {
                var plato = _platoService.ObtenerPorId(idPlato, idRestaurante);
                if (plato == null)
                {
                    MessageBox.Show("Plato no encontrado.");
                    return false;
                }

                _platoService.ModificarEstado(plato, estado);
                MessageBox.Show("Plato modificado exitosamente.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el plato: {ex.Message}");
                return false;
            }
        }
    }
}
