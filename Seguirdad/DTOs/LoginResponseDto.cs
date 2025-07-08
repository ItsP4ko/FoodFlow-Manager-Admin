namespace Seguirdad_Modulo.DTOs
{
    public class LoginResponseDto
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string NombreRol { get; set; } = string.Empty;
        public int IdRol { get; set; }
        public List<string> Permisos { get; set; } = new();
        
        // Información básica del restaurante asociado (si aplica)
        public int? IdRestauranteAsociado { get; set; }
        public string? NombreRestaurante { get; set; }
    }
}