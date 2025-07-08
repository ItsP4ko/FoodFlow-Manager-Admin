using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Factory.Personas
{
    public static class CajeroRestauranteFactory
    {
        public static CajeroRestaurante Crear(int dni, int idRestaurante, string nombre, string apellido)
        {
            return new CajeroRestaurante
            {
                Dni = dni,
                Nombre = nombre,
                Apellido = apellido,
                IdRestaurante = idRestaurante
            };
        }
    }
}
