using Modelo.Interfacez;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Factory.Utiles
{
    public static class PlatoFactory
    {
        /// <summary>
        /// Crea una entidad Plato lista para persistir en la BD.
        /// </summary>
        public static Plato Crear(string nombre, bool estado, decimal precio, int idRestaurante, int idCategoria)
        {
            return new Plato
            {
                Nombre = nombre,
                Estado = estado,
                Precio = precio,
                IdRestaurante = idRestaurante,
                Categoria = idCategoria
            };
        }

    }
}

