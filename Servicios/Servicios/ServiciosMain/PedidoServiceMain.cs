using Microsoft.EntityFrameworkCore;
using Modelo.Context;
using Modelo.Estado;
using Modelo.Interfacez;
using Modelo.Models;
using Modelo.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios.ServiciosMain
{
    public class PedidoServiceMain
    {
        private readonly EasyFoodFlowContext _context;

        public PedidoServiceMain()
        {
            _context = new EasyFoodFlowContext();
        }

        public (bool Success, string Message, decimal Total, Pedido Pedido) CrearPedidoConExtras(
            int dniCliente,
            int idRestaurante,
            string direccion,
            List<(int IdPlato, List<(int IdAderezo, int Cantidad)> Extras)> lineasPedido)
        {
            try
            {
                // Crear o buscar cliente
                var cliente = _context.Clientes.FirstOrDefault(c => c.Dni == dniCliente);
                if (cliente == null)
                {
                    cliente = new Cliente
                    {
                        Dni = dniCliente,
                        Nombre = "SIN NOMBRE",
                        Apellido = "SIN APELLIDO",
                        Direccion = direccion
                    };
                    _context.Clientes.Add(cliente);
                    _context.SaveChanges();
                }

                // Construir el pedido con el builder
                var builder = new Modelo.Builder.PedidoBuilder(
                    dniCliente: dniCliente,
                    idRestaurante: idRestaurante,
                    direccion: direccion);

                // Agregar cada línea (plato + extras)
                foreach (var linea in lineasPedido)
                {
                    builder.AddPlato(
                        idPlato: linea.IdPlato,
                        extrasConCantidad: linea.Extras);
                }

                // Finalizar y guardar
                Pedido pedido = builder.BuildAndSave();

                return (true,
                    $"Pedido #{pedido.IdPedido} creado con éxito. Total: ${pedido.Total}",
                    pedido.Total,
                    pedido);
            }
            catch (Exception ex)
            {
                return (false,
                    $"Error al crear el pedido: {ex.GetBaseException().Message}",
                    0,
                    null);
            }
        }

        public (bool Success, string Message) EliminarPedido(int idPedido)
        {
            try
            {
                // Buscar el pedido
                var pedido = _context.Pedidos.FirstOrDefault(p => p.IdPedido == idPedido);
                if (pedido == null)
                    return (false, "El pedido no fue encontrado.");

                // Eliminar el pedido
                _context.Pedidos.Remove(pedido);
                _context.SaveChanges();

                return (true, "Pedido eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return (false, $"Error al eliminar el pedido: {ex.Message}");
            }
        }

        public (bool Success, string Message) EliminarLineaPedido(int idLineaAEliminar)
        {
            try
            {
                // Encontrar la línea de pedido y el pedido al que pertenece
                var lineaCompleta = _context.PedidoPlatos
                    .Include(pp => pp.IdPedidoNavigation)
                    .Include(pp => pp.AderezoPedidoPlatos)
                    .ThenInclude(ap => ap.Aderezo)
                    .Include(pp => pp.IdPlatoNavigation)
                    .FirstOrDefault(pp => pp.IdPedidoPlato == idLineaAEliminar);

                if (lineaCompleta == null)
                    return (false, "La línea de pedido seleccionada no fue encontrada.");

                // Eliminar aderezos asociados
                if (lineaCompleta.AderezoPedidoPlatos != null && lineaCompleta.AderezoPedidoPlatos.Any())
                {
                    _context.AderezoPedidoPlatos.RemoveRange(lineaCompleta.AderezoPedidoPlatos);
                }

                // Llamar al método EliminarPlato en la instancia de Pedido
                lineaCompleta.Pedido.EliminarPlato(idLineaAEliminar);

                // Marcar la línea de pedido para eliminación en el contexto de EF
                _context.PedidoPlatos.Remove(lineaCompleta);

                // Guardar todos los cambios
                _context.SaveChanges();

                return (true, "Línea de pedido eliminada y Total del pedido actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return (false, $"Error al eliminar la línea del pedido: {ex.Message}");
            }
        }

        public IList<Aderezo> ObtenerTodosLosAderezosDelRestaurante(int idRestaurante)
        {
            return _context.Aderezos
                       .Where(a => a.Estado && a.IdRestaurante == idRestaurante)
                       .OrderBy(a => a.Nombre)
                       .ToList();
        }

        public (bool Success, string Message) ActualizarEstadoPedido(int idPedido, string nuevoEstadoStr)
        {
            try
            {
                // Cargar el pedido existente
                var pedido = _context.Pedidos
                                     .Include(p => p.Tiempos)
                                     .FirstOrDefault(p => p.IdPedido == idPedido);

                if (pedido == null)
                    return (false, "El pedido no fue encontrado.");

                // Mapear el string al objeto de estado correspondiente
                IEstadoPedido nuevoEstado = nuevoEstadoStr switch
                {
                    "En Preparacion" => new EstadoEnPreparacion(),
                    "Listo para entregar" => new EstadoListo(),
                    "En camino - Domicilio" => new EstadoDomicilio(),
                    "Listo para retiro en local" => new EstadoRetiro(),
                    "Completado" => new EstadoEntregado(),
                    _ => null
                };

                if (nuevoEstado == null)
                    return (false, "El estado especificado no es válido.");

                // Validar con el flow si la transición es permitida
                if (!EstadoPedidoFlow.PuedeTransicionar(pedido.Estado, nuevoEstado))
                    return (false, "La transición de estado no está permitida.");

                // Aplicar el cambio de estado
                pedido.CambiarEstado(nuevoEstado);

                // Guardar los cambios en BD
                _context.SaveChanges();

                return (true, "Estado del pedido actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return (false, $"Error al actualizar el estado del pedido: {ex.Message}");
            }
        }
    }
}

