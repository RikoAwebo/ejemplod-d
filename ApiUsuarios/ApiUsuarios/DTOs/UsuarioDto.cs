namespace ApiUsuarios.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Carnet { get; set; } = string.Empty;
        public DateOnly FechaNacimiento { get; set; }
    }
}