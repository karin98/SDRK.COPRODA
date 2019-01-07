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

      
        public string RazonSocial { get; set; }

        [Required]
        public string RUC { get; set; }

        
        public string Telefono { get; set; }

        [Required]
        public string Celular { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string EstadoCliente { get; set; }

        public string CreadoPor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaModificacion { get; set; }
    }
}
