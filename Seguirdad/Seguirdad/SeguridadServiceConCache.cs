using Microsoft.EntityFrameworkCore;
using Modelo.Context;
using Modelo.Factory.Personas;
using Modelo.Models;
using Seguirdad_Modulo.Helpers;
using Seguirdad_Modulo.DTOs;

namespace Seguirdad.Seguirdad
{
    public class SeguridadServiceConCache
    {
        private readonly EasyFoodFlowContext _context;
        private readonly Helpers _helpers;

        public SeguridadServiceConCache()
        {
            _context = new EasyFoodFlowContext();
            _helpers = new Helpers();
        }

        #region Gestión de Usuarios con Cache

        public async Task<ApiResponse<bool>> RegistrarUsuarioAsync(string email, string password, string confirmPassword, int dni, int idRol)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                    return ApiResponse<bool>.ErrorResponse("El email es requerido");

                if (string.IsNullOrWhiteSpace(password))
                    return ApiResponse<bool>.ErrorResponse("La contraseña es requerida");

                if (password != confirmPassword)
                    return ApiResponse<bool>.ErrorResponse("Las contraseñas no coinciden");

                if (!_helpers.EsEmailValido(email))
                    return ApiResponse<bool>.ErrorResponse("El formato del email no es válido");

                var usuarioExistente = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.NombreUsuario == email);

                if (usuarioExistente != null)
                    return ApiResponse<bool>.ErrorResponse($"Ya existe un usuario con el email: {email}");

                var persona = await _context.Personas
                    .FirstOrDefaultAsync(p => p.Dni == dni);
                if (persona == null)
                    return ApiResponse<bool>.ErrorResponse("La persona especificada no existe.");

                var rol = await _context.Roles
                    .FirstOrDefaultAsync(r => r.IdRol == idRol);
                if (rol == null)
                    return ApiResponse<bool>.ErrorResponse("El rol especificado no existe.");

                string contrasenaHasheada = _helpers.HashearContrasena(password);

                var nuevoUsuario = UsuarioFactory.Crear(email, dni, idRol, contrasenaHasheada);
                nuevoUsuario.Estado = "Activo";

                _context.Usuarios.Add(nuevoUsuario);
                await _context.SaveChangesAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Usuario registrado correctamente.");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse($"Error al registrar usuario: {ex.Message}");
            }
        }

        public async Task<ApiResponse<LoginResponseDto>> VerificarLoginAsync(string email, string password)
        {
            try
            {

                if (!_helpers.EsEmailValido(email))
                {

                    return ApiResponse<LoginResponseDto>.ErrorResponse("Formato de email inválido");
                }

                var usuario = await _context.Usuarios
                    .Include(u => u.IdRolNavigation)
                        .ThenInclude(r => r.IdPermisos)
                    .Include(u => u.IdRolNavigation)
                        .ThenInclude(r => r.RolesHijos)
                        .ThenInclude(rh => rh.IdPermisos)
                    .Include(u => u.DniNavigation)
                    .FirstOrDefaultAsync(u => u.NombreUsuario.ToLower() == email.ToLower());

                if (usuario == null)
                {

                    return ApiResponse<LoginResponseDto>.ErrorResponse("Usuario no encontrado.");
                }

                if (usuario.Estado.ToLower() != "activo")
                {
                    System.Diagnostics.Debug.WriteLine("❌ Usuario inactivo.");
                    return ApiResponse<LoginResponseDto>.ErrorResponse("El usuario está inactivo.");
                }

                string contrasenaHasheada = _helpers.HashearContrasena(password);


                if (usuario.Password != contrasenaHasheada)
                {

                    return ApiResponse<LoginResponseDto>.ErrorResponse("Contraseña incorrecta.");
                }

                System.Diagnostics.Debug.WriteLine("✅ Login exitoso.");

                await EstablecerCacheUsuario(usuario);

                var loginResponse = MapearUsuarioALoginResponse(usuario);

                return ApiResponse<LoginResponseDto>.SuccessResponse(loginResponse, "Login exitoso.");
            }
            catch (Exception ex)
            {
                return ApiResponse<LoginResponseDto>.ErrorResponse($"Error en el login: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> LogoutAsync(int idUsuario)
        {
            try
            {
                CacheHelper.LimpiarCache(idUsuario);
                return ApiResponse<bool>.SuccessResponse(true, "Logout exitoso.");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse($"Error en logout: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> CambiarPasswordAsync(int idUsuario, string passwordActual, string nuevaPassword, string confirmNuevaPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(passwordActual))
                    return ApiResponse<bool>.ErrorResponse("La contraseña actual es requerida");

                if (string.IsNullOrWhiteSpace(nuevaPassword))
                    return ApiResponse<bool>.ErrorResponse("La nueva contraseña es requerida");

                if (nuevaPassword != confirmNuevaPassword)
                    return ApiResponse<bool>.ErrorResponse("Las contraseñas nuevas no coinciden");

                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.IdUsuario == idUsuario);

                if (usuario == null)
                    return ApiResponse<bool>.ErrorResponse("No se encontró el usuario.");

                string contrasenaHasheadaActual = _helpers.HashearContrasena(passwordActual);
                if (contrasenaHasheadaActual != usuario.Password)
                    return ApiResponse<bool>.ErrorResponse("La contraseña actual es incorrecta.");

                usuario.Password = _helpers.HashearContrasena(nuevaPassword);
                await _context.SaveChangesAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Contraseña cambiada correctamente.");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse($"Error al cambiar contraseña: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> CambiarMailAsync(int rol, int idUsuarioSeleccionado, string nuevoMail)
        {
            try
            {
                if (!_helpers.EsEmailValido(nuevoMail))
                    return ApiResponse<bool>.ErrorResponse("Mail");

                if (!_helpers.TienePermiso(rol, "GestionarPerfil"))
                    return ApiResponse<bool>.ErrorResponse("No tiene Permiso");


                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.IdUsuario == idUsuarioSeleccionado);

                if (usuario == null)
                    return ApiResponse<bool>.ErrorResponse("No se encontró el usuario.");

                usuario.NombreUsuario = nuevoMail;
                await _context.SaveChangesAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Error al modificar mail.");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse($"Error al cambiar mail: {ex.Message}");
            }
        }

        public async Task<ApiResponse<List<Usuario>>> ObtenerUsuariosPorRestauranteAsync(int idRestaurante)
        {
            try
            {
                // Validar que el restaurante existe
                var restauranteExiste = await _context.Restaurantes
                    .AnyAsync(r => r.IdRestaurante == idRestaurante);

                if (!restauranteExiste)
                {
                    return ApiResponse<List<Usuario>>.ErrorResponse("El restaurante especificado no existe.");
                }

                var usuarios = await _context.Usuarios
                    .Include(u => u.DniNavigation)
                    .Include(u => u.IdRolNavigation)
                    .Where(u =>
                        (u.DniNavigation is AdminRestaurante && ((AdminRestaurante)u.DniNavigation).IdRestaurante == idRestaurante) ||
                        (u.DniNavigation is AdminCocina && ((AdminCocina)u.DniNavigation).IdRestaurante == idRestaurante) ||
                        (u.DniNavigation is CajeroRestaurante && ((CajeroRestaurante)u.DniNavigation).IdRestaurante == idRestaurante)
                    )
                    .Where(u => u.Estado == "Activo") // Solo usuarios activos
                    .ToListAsync();

                return ApiResponse<List<Usuario>>.SuccessResponse(usuarios);
            }
            catch (Exception ex)
            {
                // Log del error (si tienes un logger configurado)
                // _logger.LogError(ex, "Error al obtener usuarios por restaurante {IdRestaurante}", idRestaurante);

                return ApiResponse<List<Usuario>>.ErrorResponse($"Error interno al obtener usuarios del restaurante: {ex.Message}");
            }
        }

        #endregion

        #region Verificación de Permisos con Cache

        /*
        public async Task<ApiResponse<bool>> VerificarPermisoAsync(int idUsuario, string nombrePermiso)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombrePermiso))
                    return ApiResponse<bool>.ErrorResponse("El nombre del permiso es requerido");

                if (CacheHelper.TieneCache(idUsuario))
                {
                    bool tienePermisoCache = CacheHelper.TienePermiso(idUsuario, nombrePermiso);
                    return ApiResponse<bool>.SuccessResponse(
                        tienePermisoCache,
                        $"Permiso verificado desde cache: {(tienePermisoCache ? "Autorizado" : "Denegado")}"
                    );
                }

                var usuario = await _context.Usuarios
                    .Include(u => u.IdRolNavigation)
                        .ThenInclude(r => r.IdPermisos)
                    .Include(u => u.IdRolNavigation)
                        .ThenInclude(r => r.RolesHijos)
                        .ThenInclude(rh => rh.IdPermisos)
                    .Include(u => u.DniNavigation)
                    .FirstOrDefaultAsync(u => u.IdUsuario == idUsuario);

                if (usuario == null)
                    return ApiResponse<bool>.ErrorResponse("Usuario no encontrado");

                await EstablecerCacheUsuario(usuario);

                bool tienePermiso = _helpers.TienePermiso(usuario.IdRol, nombrePermiso);

                return ApiResponse<bool>.SuccessResponse(
                    tienePermiso,
                    $"Permiso verificado desde BD: {(tienePermiso ? "Autorizado" : "Denegado")}"
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse($"Error al verificar permiso: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int?>> ObtenerIdRestauranteAsync(int idUsuario)
        {
            try
            {
                if (CacheHelper.TieneCache(idUsuario))
                {
                    int? idRestauranteCache = CacheHelper.ObtenerIdRestaurante(idUsuario);
                    return ApiResponse<int?>.SuccessResponse(
                        idRestauranteCache,
                        "ID Restaurante obtenido desde cache"
                    );
                }

                var usuario = await _context.Usuarios
                    .Include(u => u.DniNavigation)
                    .Include(u => u.IdRolNavigation)
                        .ThenInclude(r => r.IdPermisos)
                    .FirstOrDefaultAsync(u => u.IdUsuario == idUsuario);

                if (usuario == null)
                    return ApiResponse<int?>.ErrorResponse("Usuario no encontrado");

                await EstablecerCacheUsuario(usuario);

                var idRestaurante = usuario.DniNavigation?.RestauranteAsociado?.IdRestaurante;

                return ApiResponse<int?>.SuccessResponse(
                    idRestaurante,
                    "ID Restaurante obtenido desde BD"
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<int?>.ErrorResponse($"Error al obtener ID restaurante: {ex.Message}");
            }
        }
        */
        #endregion


        #region Métodos de Cache Internos

        private async Task EstablecerCacheUsuario(Usuario usuario)
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error al establecer cache para usuario {usuario.IdUsuario}: {ex.Message}");
            }
        }

        /* private async Task InvalidarCachePorRol(int idRol)
         {
             try
             {
                 var usuariosConRol = await _context.Usuarios
                     .Where(u => u.IdRol == idRol)
                     .Select(u => u.IdUsuario)
                     .ToListAsync();

                 foreach (var idUsuario in usuariosConRol)
                 {
                     CacheHelper.LimpiarCache(idUsuario);
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Error al invalidar cache por rol {idRol}: {ex.Message}");
             }
         } 
        */

        #endregion

        #region Métodos de Mapeo

        private LoginResponseDto MapearUsuarioALoginResponse(Usuario usuario)
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

            return new LoginResponseDto
            {
                IdUsuario = usuario.IdUsuario,
                Email = usuario.NombreUsuario,
                NombreCompleto = usuario.DniNavigation?.NombreCompleto ?? "",
                NombreRol = usuario.IdRolNavigation?.Nombre ?? "",
                IdRol = usuario.IdRol,
                Permisos = permisos,
                IdRestauranteAsociado = restauranteAsociado?.IdRestaurante,
                NombreRestaurante = restauranteAsociado?.Nombre
            };
        }

        #endregion
    } 
}