using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Factory.Utiles
{
    public class CategoriaFactory
    {
        public static Categoria Crear(string nombre, int idRestaurante, bool estado)
        {
            return new Categoria
            {
                Nombre = nombre,
                IdRestaurante = idRestaurante,
                Estado = estado,
                Descripcion = string.Empty
            };
        }
    }
}
