using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Modelo
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public string NumeroPedido { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public string DireccionFacturacion { get; set; }
        public int IdDireccionEntrega { get; set; }
        public string TipoEntrega { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string EstadoPedido { get; set; }
        public DateTime FechaCambioEstado { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
