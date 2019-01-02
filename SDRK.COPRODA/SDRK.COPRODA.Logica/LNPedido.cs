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
