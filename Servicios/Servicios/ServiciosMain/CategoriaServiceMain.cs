using Modelo.Context;
using Modelo.Factory.Utiles;
using Servicios.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios.ServiciosMain
{
    public class CategoriaServiceMain
    {
        private readonly EasyFoodFlowContext _context;

        public CategoriaServiceMain(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public bool YaExiste(string nombre, int idRestaurante)
        {
            return _context.Categorias.Any(c => c.Nombre == nombre && c.IdRestaurante == idRestaurante);
        }

        public bool CrearCategoria(string nombre, int idRestaurante, bool estado)
        {
            var nuevaCategoria = CategoriaFactory.Crear(nombre, idRestaurante, estado);
            _context.Categorias.Add(nuevaCategoria);
            _context.SaveChanges();
            return true;
        }

        public bool ModificarCategoria(int idCategoria, string nombre, bool estado)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.IdCategoria == idCategoria);
            if (categoria == null)
                return false;

            bool huboCambio = false;

            if (!string.IsNullOrWhiteSpace(nombre) && categoria.Nombre != nombre)
            {
                categoria.Nombre = nombre;
                huboCambio = true;
            }

            if (categoria.Estado != estado)
            {
                categoria.Estado = estado;
                huboCambio = true;
            }

            if (!huboCambio)
                return false;

            _context.SaveChanges();
            return true;
        }
    }
}
