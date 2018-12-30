using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Modelo
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string IdTipoDocumentoIdentidad { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El Campo es obligatorio.")]
        [StringLength(20, ErrorMessage = "Name can be no larger than 30 characters")]
        public string UsuarioCD { get; set; } //Usuario Coproda

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El Campo es obligatorio.")]
        [StringLength(50, ErrorMessage = "Name can be no larger than 30 characters")]
        public string ClaveAcceso { get; set; }

        public string EstadoUsuario { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
