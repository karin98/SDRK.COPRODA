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

        public List<Cliente> ClienteLeer() //Agregar Parametros
        {
            return adCliente.ClienteLeer();
        }

        public string ClienteCrear(Cliente cliente)
        {
            return adCliente.ClienteCrear(cliente);
        }

        public string ClienteEditar(Cliente cliente)
        {
            return adCliente.ClienteEditar(cliente);
        }

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

