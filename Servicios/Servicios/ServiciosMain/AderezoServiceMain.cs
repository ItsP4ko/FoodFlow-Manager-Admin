using Modelo.Context;
using Modelo.Factory.Utiles;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios.ServiciosMain
{
    public class AderezoServiceMain
    {
        private readonly EasyFoodFlowContext _context;

        public AderezoServiceMain(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public bool YaExiste(string nombre, int idRestaurante)
        {
            return _context.Aderezos.Any(a => a.Nombre == nombre && a.IdRestaurante == idRestaurante);
        }

        public bool RestauranteExiste(int idRestaurante)
        {
            return _context.Restaurantes.Any(r => r.IdRestaurante == idRestaurante);
        }

        public bool CrearAderezo(string nombre, bool estado, decimal precio, int idRestaurante)
        {
            var nuevoAderezo = AderezoFactory.Crear(nombre, estado, precio, idRestaurante);
            _context.Aderezos.Add(nuevoAderezo);
            _context.SaveChanges();
            return true;
        }

        public Aderezo? ObtenerPorId(int idAderezo)
        {
            return _context.Aderezos.FirstOrDefault(a => a.IdAderezo == idAderezo);
        }

        public bool ModificarAderezo(Aderezo aderezo, string nombre, decimal precio, bool estado)
        {
            aderezo.Nombre = string.IsNullOrWhiteSpace(nombre) ? aderezo.Nombre : nombre;
            aderezo.Precio = precio > 0 ? precio : aderezo.Precio;
            aderezo.Estado = estado;

            _context.SaveChanges();
            return true;
        }
    }
}
