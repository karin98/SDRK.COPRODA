using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string DireccionFacturacion { get; set; }
        public int IdDireccionEntrega { get; set; }
        public string NombreDireccionEntrega { get; set; }
        public string TipoEntrega { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaEntrega { get; set; }
        public string EstadoPedido { get; set; }
        public DateTime FechaCambioEstado { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }



        public int TotalItems { get; set; }
        public decimal TotalPedido { get; set; }

    }
}
