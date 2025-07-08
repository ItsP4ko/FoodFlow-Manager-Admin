using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Factory.Personas
{
    public static class AdminRestauranteFactory
    {
        public static AdminRestaurante Crear(int dni, int idRestaurante, string nombre, string apellido)
        {
            return new AdminRestaurante
            {
                Dni = dni,
                Nombre = nombre,
                Apellido = apellido,
                IdRestaurante = idRestaurante
            };
        }
    }
}
