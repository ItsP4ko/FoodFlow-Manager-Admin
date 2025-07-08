using Modelo.Estado;
using Modelo.Interfacez;
using System;
using System.Collections.Generic;

namespace Modelo.StateMachine
{
    public static class EstadoPedidoFlow
    {
        private static readonly Dictionary<string, List<Type>> _transicionesValidas = new()
        {
            { "Nuevo", new List<Type> { typeof(EstadoEnPreparacion) } },       
            { "En Preparacion", new List<Type>
                {
                    typeof(EstadoListo),     
                    typeof(EstadoRetiro)     
                }
            },
            { "Listo para entregar", new List<Type>
                {
                    typeof(EstadoDomicilio),
                    typeof(EstadoRetiro)
                }
            },
            { "En camino - Domicilio", new List<Type> { typeof(EstadoEntregado) } },
            { "Listo para retiro en local", new List<Type> { typeof(EstadoEntregado) } },
        };

        public static bool PuedeTransicionar(string estadoActual, IEstadoPedido nuevoEstado)
        {
            return _transicionesValidas.ContainsKey(estadoActual)
                && _transicionesValidas[estadoActual].Contains(nuevoEstado.GetType());
        }
    }
}
