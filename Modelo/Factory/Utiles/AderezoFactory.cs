using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Factory.Utiles
{
    public class AderezoFactory
    {
        public static Aderezo Crear(string nombre, bool estado, decimal precio, int idRestaurante)
        {
            return new Aderezo
            {
                Nombre = nombre,
                Estado = estado,
                Precio = precio,
                IdRestaurante = idRestaurante
            };
        }

    }
}
