using SDRK.COPRODA.Datos;
using SDRK.COPRODA.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Logica
{
    public class LNCliente
    {
        ADCliente adCliente = new ADCliente();

        public List<TipoDocumento> TipoDocumentoLeer()
        {
            return adCliente.TipoDocumentoLeer();
        }

        public List<TipoCliente> TipoClienteLeer()
        {
            return adCliente.TipoClienteLeer();
        }
    }
}

