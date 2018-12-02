using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Modelo
{
  public   class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string RUC { get; set; }
        public string IdTipoDocumento { get; set; }
        public string DocumentoIdentidad { get; set; }
        public int  IdDireccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; } 
        public string EstadoProveedor { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }

    }
}
