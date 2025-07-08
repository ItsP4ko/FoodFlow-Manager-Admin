using Modelo.Estado;
using Modelo.Interfacez;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System;

namespace Modelo.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoPlatos = new HashSet<PedidoPlato>();
            CadetePedidos = new HashSet<CadetePedido>();
            Tiempos = new HashSet<Tiempo>();
            EstadoActual = new EstadoEnPreparacion();
            Estado = EstadoActual.ObtenerNombreEstado();
        }

        public int IdPedido { get; set; }
        
        public int DniCliente { get; set; }
        
        public int IdRestaurante { get; set; }
        
        public decimal Total { get; set; }
        
        public string Estado { get; set; } = null!;
        
        public string? DireccionEntrega { get; set; }
        
        public DateTime? FechaHoraCreacion { get; set; }
        
        public string? MetodoPago { get; set; }
        
        public string? Observaciones { get; set; }

        public virtual Cliente DniClienteNavigation { get; set; } = null!;

        public virtual Restaurante IdRestauranteNavigation { get; set; } = null!;
        
        public virtual ICollection<Tiempo> Tiempos { get; set; }
        
        public virtual ICollection<PedidoPlato> PedidoPlatos { get; set; }
        
        public virtual ICollection<CadetePedido> CadetePedidos { get; set; }

        [NotMapped]
        public IEstadoPedido EstadoActual { get; private set; }

        public void AgregarPlato(Plato plato)
        {
            if (!PedidoPlatos.Any(pp => pp.IdPlato == plato.IdPlato))
            {
                PedidoPlatos.Add(new PedidoPlato
                {
                    IdPedido = this.IdPedido,
                    IdPlato = plato.IdPlato,
                    Pedido = this,
                    Plato = plato,
                    PrecioMomento = plato.Precio
                });

                Total += plato.Precio;
            }
        }

        public void EliminarPlato(int idPedidoPlatoAEliminar)
        {
            var lineaAEliminar = PedidoPlatos
                                 .FirstOrDefault(pp => pp.IdPedidoPlato == idPedidoPlatoAEliminar);

            if (lineaAEliminar == null)
            {
                throw new InvalidOperationException($"No se encontró la línea de pedido con IdPedidoPlato {idPedidoPlatoAEliminar} en este pedido.");
            }

            decimal precioLinea = lineaAEliminar.PrecioMomento +
                                  lineaAEliminar.AderezoPedidoPlatos.Sum(ap => ap.PrecioMomento * ap.Cantidad);

            PedidoPlatos.Remove(lineaAEliminar);

            Total -= precioLinea;
        }

        public void CambiarEstado(IEstadoPedido nuevoEstado)
        {
            if (!Modelo.StateMachine.EstadoPedidoFlow.PuedeTransicionar(this.Estado, nuevoEstado))
                throw new InvalidOperationException($"No se puede cambiar el estado de '{this.Estado}' a '{nuevoEstado.ObtenerNombreEstado()}'.");

            // Finaliza el tiempo de la fase anterior antes de cambiar el estado, si existe y no ha terminado
            var tiempoAnterior = Tiempos.LastOrDefault(t => t.Fin == null);
            if (tiempoAnterior != null)
            {
                tiempoAnterior.Fin = DateTime.Now;
            }

            EstadoActual = nuevoEstado;
            EstadoActual.Manejar(this); // Aquí se registrará el nuevo Tiempo o se actualizará el estado
        }
    }
}
