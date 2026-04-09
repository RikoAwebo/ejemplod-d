using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.DTOs
{
    public class UsuarioCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Carnet { get; set; } = string.Empty;

        [Required]
        public DateOnly FechaNacimiento { get; set; }
    }
}
