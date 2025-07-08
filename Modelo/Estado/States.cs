using Modelo.Interfacez;
using Modelo.Models;
using System;
using System.Linq;

namespace Modelo.Estado
{
    public class EstadoEnPreparacion : IEstadoPedido
    {
        public void  Manejar(Pedido pedido)
        {
            if (!pedido.PedidoPlatos.Any())
                throw new InvalidOperationException("No se puede poner en preparación un pedido sin platos.");

            pedido.Estado = ObtenerNombreEstado();
            pedido.Tiempos.Add(new Tiempo
            {
                IdPedido = pedido.IdPedido,
                Fase = "Preparación",
                Inicio = DateTime.Now
            });
        }

        public string ObtenerNombreEstado() => "En Preparacion";
    }

    public class EstadoListo : IEstadoPedido
    {
        public void Manejar(Pedido pedido)
        {
            if (pedido.Estado != "En Preparacion")
                throw new InvalidOperationException("Solo los pedidos en preparación pueden pasar a 'Listo'.");

            pedido.Estado = ObtenerNombreEstado();

            var tiempo = pedido.Tiempos.FirstOrDefault(t => t.Fase == "Preparación" && t.Fin == null);
            if (tiempo != null)
                tiempo.Fin = DateTime.Now;
        }

        public string ObtenerNombreEstado() => "Listo para entregar";
    }

    public class EstadoDomicilio : IEstadoPedido
    {
        public void Manejar(Pedido pedido)
        {
            if (pedido.Estado != "Listo para entregar")
                throw new InvalidOperationException("El pedido debe estar listo para ser enviado a domicilio.");

            pedido.Estado = ObtenerNombreEstado();

            pedido.Tiempos.Add(new Tiempo
            {
                IdPedido = pedido.IdPedido,
                Fase = "Envío a domicilio",
                Inicio = DateTime.Now
            });
        }

        public string ObtenerNombreEstado() => "En camino - Domicilio";
    }

    public class EstadoRetiro : IEstadoPedido
    {
        public void Manejar(Pedido pedido)
        {
            if (pedido.Estado != "Listo para entregar")
                throw new InvalidOperationException("Solo se puede retirar un pedido que esté listo para entregar.");

            pedido.Estado = ObtenerNombreEstado();

            pedido.Tiempos.Add(new Tiempo
            {
                IdPedido = pedido.IdPedido,
                Fase = "Retiro en local",
                Inicio = DateTime.Now
            });
        }

        public string ObtenerNombreEstado() => "Listo para retiro en local";
    }

    public class EstadoEntregado : IEstadoPedido
    {
        public void Manejar(Pedido pedido)
        {
            if (pedido.Estado != "En camino - Domicilio" && pedido.Estado != "Listo para retiro en local")
                throw new InvalidOperationException("El pedido debe estar en camino o listo para retiro para ser entregado.");

            pedido.Estado = ObtenerNombreEstado();

            var tiempo = pedido.Tiempos.LastOrDefault(t => t.Fin == null);
            if (tiempo != null)
                tiempo.Fin = DateTime.Now;
        }

        public string ObtenerNombreEstado() => "Completado";
    }
}
