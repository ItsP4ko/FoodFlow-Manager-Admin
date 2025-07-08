using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Factory
{
    public static class CadetesFactory
    {
        public static Cadete Crear(string nombre, string apellido, int dni)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido no puede estar vacío.", nameof(apellido));
            if (dni <= 0)
                throw new ArgumentOutOfRangeException(nameof(dni), "El DNI debe ser un número positivo.");
            return new Cadete
            {
                Nombre = nombre,
                Apellido = apellido,
                Dni = dni,
                Estado = "Activo"
            };
        }

    }
}
