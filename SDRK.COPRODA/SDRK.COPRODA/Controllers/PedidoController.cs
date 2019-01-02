using SDRK.COPRODA.Logica;
using SDRK.COPRODA.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDRK.COPRODA.Controllers
{
    public class PedidoController : Controller
    {
        LNPedido lnPedido = new LNPedido(); 
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PedidoListar(int IdPedido)
        {
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = lnPedido.PedidoLeer(IdPedido);

            return PartialView(pedidos);
        }
    }
}