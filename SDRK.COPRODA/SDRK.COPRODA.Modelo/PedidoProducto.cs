using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Modelo
{
    public class PedidoProducto
    {
        public int IdPedidoProducto { get; set; }
        public int IdPedido { get; set; }
        [Required]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        [Required]
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PrecioUnidadMedida { get; set; }
        public string UnidadCompra { get; set; }
        public decimal PrecioUnidadCompra { get; set; }
        public decimal CantidadEntregada { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
