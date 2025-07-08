using System;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using Modelo.Models;
using Modelo;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.EntityFrameworkCore;
using Modelo.Context;
using Seguirdad.Seguirdad;
using Seguirdad_Modulo.Helpers;

namespace Controladora.Seguridad
{
    public class PasswordCheck
    {
        private readonly SeguridadServiceConCache _servicioSeguridad;
        public readonly Helpers _Helper;

        public PasswordCheck()
        {
            _servicioSeguridad = new SeguridadServiceConCache();
            _Helper = new Helpers();
        }

        public bool TienePermiso(int idUsuario, string nombrePermiso)
        {
            if (CacheHelper.TieneCache(idUsuario))
            {
                return CacheHelper.TienePermiso(idUsuario, nombrePermiso);
            }
            try
            {
                using var context = new EasyFoodFlowContext();
                var usuario = context.Usuarios
                    .Include(u => u.IdRolNavigation)
                        .ThenInclude(r => r.IdPermisos)
                    .Include(u => u.IdRolNavigation)
                        .ThenInclude(r => r.RolesHijos)
                        .ThenInclude(rh => rh.IdPermisos)
                    .Include(u => u.DniNavigation)
                    .FirstOrDefault(u => u.IdUsuario == idUsuario);

                if (usuario == null) return false;

                EstablecerCacheCompleto(usuario);

                return _Helper.TienePermiso(usuario.IdRol, nombrePermiso);
            }
            catch
            {
                return false;
            }
        }

        public async Task<Usuario?> VerificarLoginAsync(string nombreUsuario, string contrasena)
        {
            var resultado = await _servicioSeguridad.VerificarLoginAsync(nombreUsuario, contrasena);

            if (resultado.Success)
            {
                var usuario = new Usuario
                {
                    IdUsuario = resultado.Data.IdUsuario,
                    NombreUsuario = resultado.Data.Email,
                    IdRol = resultado.Data.IdRol
                };

                return usuario;
            }

            return null;
        }

        public async Task LogoutAsync(int idUsuario)
        {
            await _servicioSeguridad.LogoutAsync(idUsuario);
        }

        public async Task<(bool Exito, string Mensaje)> CambiarContrasenaAsync(int idUsuario, string contrasenaVieja, string contrasenaNueva, string validacion)
        {
            var resultado = await _servicioSeguridad.CambiarPasswordAsync(idUsuario, contrasenaVieja, contrasenaNueva, validacion);
            return (resultado.Success, resultado.Message);
        }

        public async Task<(bool Exito, string Mensaje)> CambiarMail(int rol, int idUsuarioSeleccionado, int idRestaurante, string nuevoMail)
        {
            var resultado = await _servicioSeguridad.CambiarMailAsync(rol, idUsuarioSeleccionado, nuevoMail);
            return (resultado.Success, resultado.Message);
        }

        public void Logout(int idUsuario)
        {
            CacheHelper.LimpiarCache(idUsuario);
        }

        public void ActualizarPermisosEnCache(int idUsuario, List<string> nuevosPermisos)
        {
            CacheHelper.ActualizarPermisos(idUsuario, nuevosPermisos);
        }

        public void LimpiarCacheInactivo()
        {
            CacheHelper.LimpiarCacheInactivo();
        }


        #region Método Privado

        private void EstablecerCacheCompleto(Usuario usuario)
        {
            try
            {
                var permisos = new List<string>();
                if (usuario.IdRolNavigation != null)
                {
                    usuario.IdRolNavigation.InicializarDesdeEF();
                    permisos = usuario.IdRolNavigation.IdPermisos
                        .Select(p => p.Nombre)
                        .ToList();
                }

                var restauranteAsociado = usuario.DniNavigation?.RestauranteAsociado;

                CacheHelper.EstablecerCache(
                    idUsuario: usuario.IdUsuario,
                    idRol: usuario.IdRol,
                    nombreRol: usuario.IdRolNavigation?.Nombre ?? "",
                    idRestaurante: restauranteAsociado?.IdRestaurante,
                    nombreRestaurante: restauranteAsociado?.Nombre,
                    permisos: permisos
                );
            }
            catch
            {

            }
        }

        #endregion
    }
}