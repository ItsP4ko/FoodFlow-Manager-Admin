using System;
using System.Linq;
using System.Windows.Forms;
using Modelo.Models;
using Modelo;
using Controladora.Seguridad;
using Modelo.Context;
using Servicios.Services;
using DocumentFormat.OpenXml.InkML;
using Servicios.Servicios.Servicios;

namespace Controladora.Restaurante
{
    public class ABMRestaurante
    {
        // Contexto que se usa para operaciones de lectura (por ejemplo, para validaciones)
        private readonly EasyFoodFlowContext _context;
        private readonly PasswordCheck _passwordCheck;
        private readonly RestauranteServiceMain _restauranteService;
        private readonly int _idUsuario;
        public ABMRestaurante(int idUsuario)
        {
            _restauranteService = new RestauranteServiceMain(_context);
            _passwordCheck = new PasswordCheck();
            _context = new EasyFoodFlowContext();
            _idUsuario = idUsuario;
        }

        public string BuscarRestaurante(int idRestaurante)
        {
            var restaurante = _restauranteService.ObtenerPorId(idRestaurante);
            if (restaurante == null)
            {
                return "Restaurante desconocido";
            }

            return restaurante.Nombre;
        }

        public bool AgregarRestaurante(string nombre, string direccion, int capacidad, int dniAdmin, int dniCocinero, int dniCajero)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionAdminAdmin"))
            {
                MessageBox.Show("No tienes permiso");
                return false;
            }

            if (_restauranteService.YaExiste(nombre))
            {
                MessageBox.Show("Ya existe un restaurante con este nombre.");
                return false;
            }

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var restaurante = _restauranteService.Crear(nombre, direccion, capacidad);
                _restauranteService.Save();

                int idNuevoRestaurante = restaurante.IdRestaurante;

                var (UsuarioAdmin, UsuarioCocinero, UsuarioCajero) = _restauranteService.RegistrarUsuariosRestaurante(idNuevoRestaurante, dniAdmin, dniCocinero, dniCajero);
                var (admin, cocinero, cajero) = _restauranteService.CrearTiposUsuarios(idNuevoRestaurante, dniAdmin, dniCocinero, dniCajero);

                if (UsuarioAdmin == null || UsuarioCocinero == null || UsuarioCajero == null ||
                admin == null || cocinero == null || cajero == null)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al registrar uno o más usuarios.");
                    return false;
                }

                transaction.Commit();
                MessageBox.Show("Restaurante y usuarios creados exitosamente.");
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show($"Error al agregar el restaurante: {ex.Message}");
                return false;
            }
        }

        public bool ModificarRestaurante(int idRestaurante, string nombre, string direccion, int capacidad)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionAdminAdmin"))
            {
                MessageBox.Show("No tienes permiso");
                return false;
            }

            var restaurante = _restauranteService.ObtenerPorId(idRestaurante);
            if (restaurante == null)
            {
                MessageBox.Show("Error: Restaurante no encontrado.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(direccion) || capacidad <= 0)
            {
                MessageBox.Show("Parámetros inválidos");
                return false;
            }

            _restauranteService.Modificar(restaurante, nombre, direccion, capacidad);
            _restauranteService.Save();

            MessageBox.Show("Restaurante modificado exitosamente.");
            return true;
        }

        public bool EliminarRestaurante(int idRestaurante)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionAdminAdmin"))
            {
                MessageBox.Show("No tienes permiso");
                return false;
            }

            var restaurante = _restauranteService.ObtenerPorId(idRestaurante);
            if (restaurante == null)
            {
                MessageBox.Show("Error: Restaurante no encontrado.");
                return false;
            }

            _restauranteService.Eliminar(restaurante);
            _restauranteService.Save();

            MessageBox.Show("Restaurante eliminado exitosamente.");
            return true;
        }

    }
}
