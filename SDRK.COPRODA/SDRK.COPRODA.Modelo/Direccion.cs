using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Modelo
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public int IdCliente { get; set; }
        public string NombreDireccion { get; set; }
        public string Calle1 { get; set; }
        public string Calle2 { get; set; }
        public string Distrito { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string EstadoDireccion { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
