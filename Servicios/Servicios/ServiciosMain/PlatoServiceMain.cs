using Modelo.Context;
using Modelo.Factory.Utiles;
using Modelo.Models;
using System;
using System.Linq;

namespace Servicios.Platos
{
    public class PlatoServiceMain
    {
        private readonly EasyFoodFlowContext _context;

        public PlatoServiceMain(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public bool YaExiste(string nombre)
        {
            return _context.Platos.Any(p => p.Nombre == nombre);
        }

        public bool RestauranteExiste(int idRestaurante)
        {
            return _context.Restaurantes.Any(r => r.IdRestaurante == idRestaurante);
        }

        public bool CrearPlato(string nombre, bool estado, decimal precio, int idRestaurante, int idCategoria)
        {
            var nuevoPlato = PlatoFactory.Crear(nombre, estado, precio, idRestaurante, idCategoria);
            _context.Platos.Add(nuevoPlato);
            _context.SaveChanges();
            return true;
        }

        public Plato? ObtenerPorId(int idPlato, int? idRestaurante = null)
        {
            return _context.Platos
                .FirstOrDefault(p => p.IdPlato == idPlato && (idRestaurante == null || p.IdRestaurante == idRestaurante));
        }

        public bool EliminarPlato(Plato plato)
        {
            _context.Platos.Remove(plato);
            _context.SaveChanges();
            return true;
        }

        public bool ModificarEstado(Plato plato, bool estado)
        {
            plato.Estado = estado;
            _context.SaveChanges();
            return true;
        }
    }
}
