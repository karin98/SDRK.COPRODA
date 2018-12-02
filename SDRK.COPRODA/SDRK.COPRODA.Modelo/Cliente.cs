using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Modelo
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string IdTipoCliente { get; set; }  //cambiar a tipo  de cliente 
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string IdTipoDocumento { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string RazonSocial { get; set; }
        public string RUC { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
