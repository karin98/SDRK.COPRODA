using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Modelo
{
    public class Cliente
    {
        [Required]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El Tipo de Cliente es obligatorio.")]
        public string IdTipoCliente { get; set; }  //cambiar a tipo  de cliente 

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string IdTipoDocumento { get; set; }

        [Required]
        public string DocumentoIdentidad { get; set; }

        [Required]
        public string RazonSocial { get; set; }

        [Required]
        public string RUC { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Celular { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string EstadoCliente { get; set; }

        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
