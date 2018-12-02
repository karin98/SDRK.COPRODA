using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Modelo
{
   public class ComprobantePago
    {
        public int IdComprobantePago { get; set; }
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public string IdTipoComprobante { get; set; }
        public string IdTipoTransaccion { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string FormaPago { get; set; }
        public string Estado { get; set; }
        public double Monto { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
