using System;
using System.Collections.Generic;
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
        public string UsuarioCD { get; set; }
        public string ClaveAcceso { get; set; }
        public string EstadoUsuario { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
