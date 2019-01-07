using SDRK.COPRODA.Datos;
using SDRK.COPRODA.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Logica
{
    public class LNPedidoProducto
    {
        ADPedidoProducto adPedidoProducto = new ADPedidoProducto();

        public List<PedidoProducto> PedidoProductoLeer(int IdPedido)
        {
            return adPedidoProducto.PedidoProductoLeer(IdPedido);
        }

        public string PedidoProductoCrear(PedidoProducto pedidoProducto)
        {
            return adPedidoProducto.PedidoProductoCrear(pedidoProducto);
        }

        public string PedidoProductoEditar(PedidoProducto pedidoProducto)
        {
            return adPedidoProducto.PedidoProductoEditar(pedidoProducto);
        }

        public string PedidoProductoEliminar (PedidoProducto pedidoProducto)
        {
            return adPedidoProducto.PedidoProductoEliminar(pedidoProducto);
        }
    }
}
