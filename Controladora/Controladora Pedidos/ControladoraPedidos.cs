using Controladora.Seguridad;
using Microsoft.EntityFrameworkCore;
using Modelo.Context;
using Modelo.Estado;
using Modelo.Factory;
using Modelo.Interfacez;
using Modelo.Models;
using Modelo.StateMachine;
using Servicios.Servicios.ServiciosMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Pedidos
{
    public class ControladoraPedidos
    {
        private readonly ControladoraRolesPermisos _controladoraRolesPermisos;
        private readonly PasswordCheck _passwordCheck;
        private readonly PedidoServiceMain _servicioPedidos;
        private readonly int _idUsuario; // rol del usuario que hace la acción

        public ControladoraPedidos(int idUsuario)
        {
            _idUsuario = idUsuario;
            _controladoraRolesPermisos = new ControladoraRolesPermisos();
            _passwordCheck = new PasswordCheck();
            _servicioPedidos = new PedidoServiceMain();
        }

        public (bool Success, string Message, decimal total) CrearPedidoConExtras(
            int dniCliente,
            int idRestaurante,
            string direccion,
            List<(int IdPlato, List<(int IdAderezo, int Cantidad)> Extras)> lineasPedido)
        {
            // Validaciones de permisos y entrada
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionCajero"))
                return (false, "No tienes permiso para crear pedidos.", 0);

            if (lineasPedido == null || lineasPedido.Count == 0)
                return (false, "Debes agregar al menos un plato con sus extras.", 0);

            if (string.IsNullOrWhiteSpace(direccion))
                return (false, "Debes ingresar una dirección.", 0);

            // Delegar la lógica de negocio al servicio
            var resultado = _servicioPedidos.CrearPedidoConExtras(dniCliente, idRestaurante, direccion, lineasPedido);
            return (resultado.Success, resultado.Message, resultado.Total);
        }

        public bool EliminarPedido(int idPedido)
        {
            // Validación de permisos
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionCajero"))
            {
                MessageBox.Show("No tienes permiso para eliminar pedidos.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Delegar la lógica de negocio al servicio
            var resultado = _servicioPedidos.EliminarPedido(idPedido);

            if (!resultado.Success)
            {
                MessageBox.Show(resultado.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            MessageBox.Show(resultado.Message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        public bool EliminarLineaPedido(int idLineaAEliminar)
        {
            // Validación de permisos
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionCajero"))
            {
                MessageBox.Show("No tienes permiso para eliminar líneas de pedido.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Delegar la lógica de negocio al servicio
            var resultado = _servicioPedidos.EliminarLineaPedido(idLineaAEliminar);

            if (!resultado.Success)
            {
                MessageBox.Show(resultado.Message, "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            MessageBox.Show(resultado.Message, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        public IList<Aderezo> ObtenerTodosLosAderezosDelRestaurante(int idRestaurante)
        {
            // Esta operación no requiere validación de permisos específica
            return _servicioPedidos.ObtenerTodosLosAderezosDelRestaurante(idRestaurante);
        }

        public bool ActualizarEstadoPedido(int idPedido, string nuevoEstadoStr)
        {
            // Validación de permisos
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionCocina"))
            {
                MessageBox.Show("No tienes permiso para actualizar estados de pedidos.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Delegar la lógica de negocio al servicio
            var resultado = _servicioPedidos.ActualizarEstadoPedido(idPedido, nuevoEstadoStr);

            if (!resultado.Success)
            {
                MessageBox.Show(resultado.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}



