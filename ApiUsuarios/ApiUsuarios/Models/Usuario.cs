using System;
using System.Collections.Generic;

namespace ApiUsuarios.Models
{
    public partial class Usuario : BaseEntity
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Carnet { get; set; } = null!;
        public DateOnly FechaNacimiento { get; set; }
    }
}