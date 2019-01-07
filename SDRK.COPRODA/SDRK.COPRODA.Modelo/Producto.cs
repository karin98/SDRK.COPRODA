using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Modelo
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Presentacion { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PrecioUnidadMedida { get; set; }
        public string UnidadCompra { get; set; }
        public decimal PrecioUnidadCompra { get; set; }
        public string Estado { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
