using Modelo.Context;
using Modelo.Estado;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Modelo.Builder
{
    public class PedidoBuilder
    {
        private readonly EasyFoodFlowContext _context;
        private readonly Pedido _pedido;
        private readonly List<PedidoPlato> _lineas = new();

        public PedidoBuilder(int dniCliente, int idRestaurante, string direccion)
        {
            _context = new EasyFoodFlowContext();

            // 1) Creo el pedido en preparacion
            _pedido = new Pedido
            {
                DniCliente = dniCliente,
                IdRestaurante = idRestaurante,
                DireccionEntrega = direccion,
                Total = 0
                // Pedido asigna internamente el estado “En Preparacion”
            };
        }

        /// <summary>
        /// Agrega una línea (una unidad de plato) y opcionalmente sus extras.
        /// Cada llamada genera una línea independiente, incluso si el mismo plato ya existe.
        /// </summary>
        public PedidoBuilder AddPlato(
            int idPlato,
            IEnumerable<(int IdAderezo, int Cantidad)> extrasConCantidad)
        {
            // 1) Obtengo precio del plato una sola vez
            var precioPlato = _context.Platos.Find(idPlato)?.Precio ?? 0;

            var linea = new PedidoPlato
            {
                IdPlato = idPlato,
                IdPedidoNavigation = _pedido,
                PrecioMomento = precioPlato,
                Cantidad = 1
            };

            // 2) Para cada extra, obtengo su precio y lo guardo
            foreach (var (idAderezo, cantidad) in extrasConCantidad)
            {
                var precioAderezo = _context.Aderezos.Find(idAderezo)?.Precio ?? 0;
                linea.AderezoPedidoPlatos.Add(new AderezoPedidoPlato
                {
                    IdAderezo = idAderezo,
                    Cantidad = cantidad,
                    PrecioMomento = precioAderezo,
                    IdPedidoPlatoNavigation = linea
                });
            }

            _lineas.Add(linea);
            return this;
        }

        /// <summary>
        /// Transiciona a “En Preparacion”, guarda el pedido y las líneas,
        /// y calcula el Total usando los valores ya capturados.
        /// </summary>
        public Pedido BuildAndSave()
        {
            using var trx = _context.Database.BeginTransaction();
            try
            {
                // 2) Agrego el pedido al contexto para que se genere el IdPedido
                _context.Pedidos.Add(_pedido);
                _context.SaveChanges(); 


                // 3) Asigno IdPedido a cada línea y agrego las líneas al contexto
                foreach (var linea in _lineas)
                {
                    linea.IdPedido = _pedido.IdPedido;
                    _context.PedidoPlatos.Add(linea);
                }
                _context.SaveChanges();

                _pedido.EstadoActual.Manejar(_pedido); // Inicia el tiempo, fase: en preparacion
                _context.SaveChanges();

                // 4) Calculo el total en memoria usando PrecioMomento
                _pedido.Total = _lineas.Sum(l =>
                    l.PrecioMomento
                    + l.AderezoPedidoPlatos.Sum(a => a.PrecioMomento * a.Cantidad)
                );

                // 5) Hago un SaveChanges final para las líneas de pedido y el total actualizado
                _context.SaveChanges();
                trx.Commit();
            }
            catch (Exception)
            {
                trx.Rollback();
                throw;
            }

            return _pedido;
        }
    }
}