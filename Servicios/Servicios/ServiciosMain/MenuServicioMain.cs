using Modelo.Context;
using Modelo.Models;
using System;
using System.IO;
using System.Linq;

namespace Servicios.Menu
{
    public class MenuServicioMain
    {
        private readonly EasyFoodFlowContext _context;

        public MenuServicioMain(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public void GuardarMenu(int idRestaurante, string categoria, byte[] archivoPdf)
        {
            var menuExistente = _context.Menus
                .FirstOrDefault(m => m.IdRestaurante == idRestaurante && m.Categoria == categoria);

            if (menuExistente != null)
            {
                menuExistente.Pdf = archivoPdf;
                _context.Menus.Update(menuExistente);
            }
            else
            {
                var nuevoMenu = new Modelo.Models.Menu
                {
                    Pdf = archivoPdf,
                    IdRestaurante = idRestaurante,
                    Categoria = categoria
                };

                _context.Menus.Add(nuevoMenu);
            }

            _context.SaveChanges();
        }

        public byte[]? ObtenerMenuPdf(int idRestaurante, string categoria)
        {
            var menu = _context.Menus.FirstOrDefault(m =>
                m.IdRestaurante == idRestaurante &&
                m.Categoria == categoria);

            return menu?.Pdf;
        }

        public bool EliminarMenu(int idRestaurante, string categoria)
        {
            var menu = _context.Menus.FirstOrDefault(m =>
                m.IdRestaurante == idRestaurante &&
                m.Categoria == categoria);

            if (menu != null)
            {
                _context.Menus.Remove(menu);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
