using System.Collections.Concurrent;

namespace Seguirdad_Modulo.Helpers
{
    public class UsuarioCache
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; } = string.Empty;
        public int? IdRestaurante { get; set; }
        public string? NombreRestaurante { get; set; }
        public List<string> Permisos { get; set; } = new();
        public DateTime UltimoAcceso { get; set; } 
    }

    public class CacheHelper
    {
        private static readonly ConcurrentDictionary<int, UsuarioCache> _cacheUsuarios = new();
        private static readonly TimeSpan _tiempoSinUso = TimeSpan.FromHours(2); // 2 horas sin uso para limpiar

        #region Métodos Esenciales

        
        public static void EstablecerCache(int idUsuario, int idRol, string nombreRol, 
            int? idRestaurante, string? nombreRestaurante, List<string> permisos)
        {
            var cacheData = new UsuarioCache
            {
                IdUsuario = idUsuario,
                IdRol = idRol,
                NombreRol = nombreRol,
                IdRestaurante = idRestaurante,
                NombreRestaurante = nombreRestaurante,
                Permisos = permisos ?? new List<string>(),
                UltimoAcceso = DateTime.Now
            };

            _cacheUsuarios.AddOrUpdate(idUsuario, cacheData, (key, oldValue) => cacheData);
        }


        public static UsuarioCache? ObtenerCache(int idUsuario)
        {
            if (_cacheUsuarios.TryGetValue(idUsuario, out var cacheData))
            {
                // Cache encontrado - devolver los datos
                return cacheData;
            }

            return null; // No hay cache para este usuario
        }

        
        public static bool TienePermiso(int idUsuario, string nombrePermiso)
        {
            if (_cacheUsuarios.TryGetValue(idUsuario, out var cacheData))
            {
                
                cacheData.UltimoAcceso = DateTime.Now;
                
                return cacheData.Permisos.Contains(nombrePermiso, StringComparer.OrdinalIgnoreCase);
            }

            return false; // No hay cache, necesita verificación desde BD
        }

        public static bool TieneCache(int idUsuario)
        {
            return _cacheUsuarios.ContainsKey(idUsuario);
        }

        
        public static void LimpiarCache(int idUsuario)
        {
            _cacheUsuarios.TryRemove(idUsuario, out _);
        }

        
        public static void ActualizarPermisos(int idUsuario, List<string> nuevosPermisos)
        {
            if (_cacheUsuarios.TryGetValue(idUsuario, out var cacheData))
            {
                cacheData.Permisos = nuevosPermisos ?? new List<string>();
                cacheData.UltimoAcceso = DateTime.Now;
            }
        }

       
        public static void LimpiarCacheInactivo()
        {
            var ahora = DateTime.Now;
            var usuariosInactivos = _cacheUsuarios
                .Where(kvp => ahora - kvp.Value.UltimoAcceso > _tiempoSinUso)
                .Select(kvp => kvp.Key)
                .ToList();

            foreach (var idUsuario in usuariosInactivos)
            {
                _cacheUsuarios.TryRemove(idUsuario, out _);
            }
        }

        
        public static (int TotalUsuarios, int UsuariosActivos) ObtenerEstadisticas()
        {
            var ahora = DateTime.Now;
            var total = _cacheUsuarios.Count;
            var activos = _cacheUsuarios.Count(kvp => ahora - kvp.Value.UltimoAcceso <= _tiempoSinUso);

            return (total, activos);
        }

        #endregion
    }
}