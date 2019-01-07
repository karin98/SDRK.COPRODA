using SDRK.COPRODA.Datos;
using SDRK.COPRODA.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Logica
{
    public class LNPedido
    {
        ADPedido adPedido = new ADPedido();

        public string PedidoCrear(Pedido pedido)
        {
            return adPedido.PedidoCrear(pedido);
        }

        public string PedidoEditar(Pedido pedido)
        {
            return adPedido.PedidoEditar(pedido);
        }

        public string PedidoActualizarEstado(Pedido pedido)
        {
            return adPedido.PedidoActualizarEstado(pedido);
        }

        public List<Pedido> PedidoLeer(int IdPedido)
        {
            return adPedido.PedidoLeer(IdPedido);
        }

        public List<TipoTransaccion> TipoTransaccionLeer()
        {
            return adPedido.TipoTransaccionLeer();
        }
    }
}
