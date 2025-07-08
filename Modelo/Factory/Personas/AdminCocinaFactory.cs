using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Factory.Personas
{
    public static class AdminCocinaFactory
    {
        public static AdminCocina Crear(int dni, int idRestaurante, string nombre, string apellido)
        {
            return new AdminCocina
            {
                Dni = dni,
                Nombre = nombre,
                Apellido = apellido,
                IdRestaurante = idRestaurante
            };
        }
    }
}
