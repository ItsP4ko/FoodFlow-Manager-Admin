using Modelo.Context;
using Servicios.DTOs;
using Microsoft.EntityFrameworkCore;
using Modelo.Models;

namespace Servicios.Services
{
    public class UsuarioService
    {
        private readonly EasyFoodFlowContext _context;

        public UsuarioService(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public List<UsuarioDTO> ObtenerTodos()
        {
            return _context.Usuarios
                .Include(u => u.DniNavigation)
                .Include(u => u.IdRolNavigation)
                .AsEnumerable() // Pasamos a memoria para usar el helper RestauranteAsociado
                .Select(u => new UsuarioDTO
                {
                    IdUsuario = u.IdUsuario,
                    NombreUsuario = u.NombreUsuario,
                    Rol = u.IdRolNavigation?.Nombre ?? "Sin Rol",
                    Restaurante = u.DniNavigation.RestauranteAsociado?.Nombre ?? "N/A"
                }).ToList();
        }

        public List<UsuarioDTO> BuscarPorNombre(string nombre)
        {
            return _context.Usuarios
                .Include(u => u.DniNavigation)
                .Include(u => u.IdRolNavigation)
                .AsEnumerable()
                .Where(u => u.NombreUsuario.ToLower().Contains(nombre.ToLower()))
                .Select(u => new UsuarioDTO
                {
                    IdUsuario = u.IdUsuario,
                    NombreUsuario = u.NombreUsuario,
                    Rol = u.IdRolNavigation?.Nombre ?? "Sin Rol",
                    Restaurante = u.DniNavigation.RestauranteAsociado?.Nombre ?? "N/A"
                }).ToList();
        }

        public List<UsuarioDTO> BuscarPorRol(string rol)
        {
            return _context.Usuarios
                .Include(u => u.DniNavigation)
                .Include(u => u.IdRolNavigation)
                .AsEnumerable()
                .Where(u => (u.IdRolNavigation?.Nombre.ToLower() ?? "") == rol.ToLower())
                .Select(u => new UsuarioDTO
                {
                    IdUsuario = u.IdUsuario,
                    NombreUsuario = u.NombreUsuario,
                    Rol = u.IdRolNavigation?.Nombre ?? "Sin Rol",
                    Restaurante = u.DniNavigation.RestauranteAsociado?.Nombre ?? "N/A"
                }).ToList();
        }

        public List<UsuarioDTO> BuscarPorMail(string mail)
        {
            return _context.Usuarios
                .Include(u => u.DniNavigation)
                .Include(u => u.IdRolNavigation)
                .AsEnumerable()
                .Where(u => u.NombreUsuario.ToLower().Contains(mail.ToLower()))
                .Select(u => new UsuarioDTO
                {
                    IdUsuario = u.IdUsuario,
                    NombreUsuario = u.NombreUsuario,
                    Rol = u.IdRolNavigation?.Nombre ?? "Sin Rol",
                    Restaurante = u.DniNavigation.RestauranteAsociado?.Nombre ?? "N/A"
                }).ToList();
        }
    }
}