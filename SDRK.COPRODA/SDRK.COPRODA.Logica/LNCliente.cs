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

        public List<Cliente> ClienteLeer(int idCliente) //Agregar Parametros
        {
            return adCliente.ClienteLeer(idCliente);
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

        public List<Direccion> DireccionLeer(int IdCliente)
        {
            return adCliente.DireccionLeer(IdCliente);
        }
        }
}

