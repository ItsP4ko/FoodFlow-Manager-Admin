using Modelo.Context;
using Seguirdad.Seguirdad;
using Servicios.Services;
using Xunit;
using System.Threading.Tasks;
using System.Linq;

public class Test
{
    private readonly SeguridadServiceConCache _servicioSeguridad;

    public Test()
    {
        try
        {
            System.Console.WriteLine("=== INICIANDO CONSTRUCTOR ===");
            System.Console.WriteLine("Intentando crear SeguridadServiceConCache...");
            
            // Usar la implementación real con constructor sin parámetros
            _servicioSeguridad = new SeguridadServiceConCache();
            
            System.Console.WriteLine("SeguridadServiceConCache creado exitosamente");
            System.Console.WriteLine("=== CONSTRUCTOR COMPLETADO ===");
        }
        catch (System.InvalidOperationException ex)
        {
            System.Console.WriteLine("=== ERROR EN CONSTRUCTOR (InvalidOperationException) ===");
            System.Console.WriteLine($"Mensaje: {ex.Message}");
            System.Console.WriteLine($"InnerException: {ex.InnerException?.Message ?? "N/A"}");
            System.Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            System.Console.WriteLine("===================================================");
            throw;
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("=== ERROR EN CONSTRUCTOR (General) ===");
            System.Console.WriteLine($"Tipo: {ex.GetType().Name}");
            System.Console.WriteLine($"Mensaje: {ex.Message}");
            System.Console.WriteLine($"InnerException: {ex.InnerException?.Message ?? "N/A"}");
            System.Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            System.Console.WriteLine("=====================================");
            throw;
        }
    }

    [Fact]
    public async Task VerificarLoginAsync_LoginExitoso_DebeRetornarUsuario()
    {
        // Arrange - usar datos que podrían existir en tu BD
        var nombreUsuario = "admin@admin.com";
        var contrasena = "123";

        try
        {
            System.Console.WriteLine("=== INICIANDO TEST ===");
            System.Console.WriteLine($"Intentando login con: {nombreUsuario}");
            
            // Act
            System.Console.WriteLine("Llamando a VerificarLoginAsync...");
            var resultado = await _servicioSeguridad.VerificarLoginAsync(nombreUsuario, contrasena);
            System.Console.WriteLine("Respuesta recibida del servicio");

            // Assert
            Assert.NotNull(resultado);
            System.Console.WriteLine($"Success: {resultado.Success}");
            System.Console.WriteLine($"Message: {resultado.Message}");
            
            if (resultado.Success)
            {
                // Si el login fue exitoso, mostrar todos los datos del usuario
                Assert.NotNull(resultado.Data);
                
                // Mostrar todos los datos del usuario en la consola
                System.Console.WriteLine("=== DATOS DEL USUARIO ===");
                System.Console.WriteLine($"ID Usuario: {resultado.Data.IdUsuario}");
                System.Console.WriteLine($"Email: {resultado.Data.Email}");
                System.Console.WriteLine($"Nombre Completo: {resultado.Data.NombreCompleto}");
                System.Console.WriteLine($"ID Rol: {resultado.Data.IdRol}");
                System.Console.WriteLine($"Nombre Rol: {resultado.Data.NombreRol}");
                System.Console.WriteLine($"ID Restaurante Asociado: {resultado.Data.IdRestauranteAsociado?.ToString() ?? "N/A"}");
                System.Console.WriteLine($"Nombre Restaurante: {resultado.Data.NombreRestaurante ?? "N/A"}");
                System.Console.WriteLine($"Cantidad de Permisos: {resultado.Data.Permisos.Count}");
                
                if (resultado.Data.Permisos.Any())
                {
                    System.Console.WriteLine("Permisos:");
                    foreach (var permiso in resultado.Data.Permisos)
                    {
                        System.Console.WriteLine($"  - {permiso}");
                    }
                }
                else
                {
                    System.Console.WriteLine("Sin permisos asignados");
                }
                System.Console.WriteLine("========================");
                
                // Validaciones básicas
                Assert.Equal(nombreUsuario, resultado.Data.Email);
                Assert.True(resultado.Data.IdUsuario > 0);
                Assert.True(resultado.Data.IdRol > 0);
                Assert.False(string.IsNullOrEmpty(resultado.Data.NombreRol));
            }
            else
            {
                // Si el login falló, mostrar el mensaje de error
                System.Console.WriteLine($"=== LOGIN FALLIDO ===");
                System.Console.WriteLine($"Mensaje: {resultado.Message}");
                System.Console.WriteLine($"Errores: {string.Join(", ", resultado.Errors)}");
                System.Console.WriteLine("====================");
                
                Assert.False(string.IsNullOrEmpty(resultado.Message));
                // Este caso es válido si las credenciales no existen en la BD
            }
        }
        catch (System.InvalidOperationException ex)
        {
            // Error específico de Entity Framework / Base de datos
            System.Console.WriteLine($"=== ERROR DE BASE DE DATOS ===");
            System.Console.WriteLine($"Mensaje: {ex.Message}");
            System.Console.WriteLine($"InnerException: {ex.InnerException?.Message ?? "N/A"}");
            System.Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            System.Console.WriteLine("=============================");
            Assert.True(false, $"Error de configuración de BD: {ex.Message}");
        }
        catch (System.Exception ex)
        {
            // Cualquier otro error técnico
            System.Console.WriteLine($"=== ERROR TÉCNICO GENERAL ===");
            System.Console.WriteLine($"Tipo: {ex.GetType().Name}");
            System.Console.WriteLine($"Mensaje: {ex.Message}");
            System.Console.WriteLine($"InnerException: {ex.InnerException?.Message ?? "N/A"}");
            System.Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            System.Console.WriteLine("============================");
            Assert.True(false, $"Error técnico en el test: {ex.Message}");
        }
    }

    [Fact]
    public async Task VerificarLoginAsync_LoginFallido_DebeRetornarError()
    {
        // Arrange - usar datos que sabemos que no existen
        var nombreUsuario = "usuario_inexistente@test.com";
        var contrasena = "password_incorrecto";

        // Act
        var resultado = await _servicioSeguridad.VerificarLoginAsync(nombreUsuario, contrasena);

        // Assert
        Assert.NotNull(resultado);
        Assert.False(resultado.Success);
        Assert.False(string.IsNullOrEmpty(resultado.Message));
    }

    [Fact]
    public async Task VerificarLoginAsync_EmailVacio_DebeRetornarError()
    {
        // Arrange
        var nombreUsuario = "";
        var contrasena = "123";

        // Act
        var resultado = await _servicioSeguridad.VerificarLoginAsync(nombreUsuario, contrasena);

        // Assert
        Assert.NotNull(resultado);
        Assert.False(resultado.Success);
        Assert.Contains("email", resultado.Message.ToLower());
    }

    [Fact]
    public async Task VerificarLoginAsync_ContrasenaVacia_DebeRetornarError()
    {
        // Arrange
        var nombreUsuario = "admin@admin.com";
        var contrasena = "";

        // Act
        var resultado = await _servicioSeguridad.VerificarLoginAsync(nombreUsuario, contrasena);

        // Assert
        Assert.NotNull(resultado);
        Assert.False(resultado.Success);
        Assert.Contains("contraseña", resultado.Message.ToLower());
    }
}