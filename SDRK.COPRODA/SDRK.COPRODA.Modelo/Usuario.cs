﻿using System;
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

        [Display(Name = "Tipo de Usuario")]
        //[Required(ErrorMessage = "El Campo es obligatorio.")]
        public string TipoUsuario { get; set; }
   
        //[Required(ErrorMessage = "El Campo es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Campo es obligatorio.")]
        public string Apellido { get; set; }

        [Display(Name = "Tipo de Documento de Identidad")]
        //[Required(ErrorMessage = "El Campo es obligatorio.")]
        public string IdTipoDocumentoIdentidad { get; set; }

        [Display(Name = "Documento de Identidad")]
        //[Required(ErrorMessage = "El Campo es obligatorio.")]
        public string DocumentoIdentidad { get; set; }

        public string Telefono { get; set; }

        //[Required(ErrorMessage = "El Campo es obligatorio.")]
        public string Celular { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El Campo es obligatorio.")]
        public string UsuarioCD { get; set; } //Usuario Coproda

        [Display(Name = "Contraseña")]
        [Required]
        public string ClaveAcceso { get; set; }

        [Display(Name = "Estado")]
        public string EstadoUsuario { get; set; }

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
