using SDRK.COPRODA.Common;
using SDRK.COPRODA.Logica;
using SDRK.COPRODA.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDRK.COPRODA.Controllers
{
    public class PedidoProductoController : Controller
    {
        Util util = new Util();
        LNPedidoProducto lnPedidoProducto = new LNPedidoProducto();
        LNProducto lnProducto = new LNProducto();

        // GET: PedidoProducto
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PedidoProductoCrear(int idPedido, string mensajeError)
        {
            ViewBag.IdPedido = idPedido;
            ViewBag.MensajeError = mensajeError;
            ViewBag.ListaProducto = util.DropDownProducto();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult PedidoProductoCrear(PedidoProducto pedidoProducto)
        {
            string respuesta = "";
            Producto producto = lnProducto.ProductoLeer(pedidoProducto.IdProducto).First();
            pedidoProducto.UnidadMedida = producto.UnidadMedida;
            pedidoProducto.PrecioUnidadMedida = producto.PrecioUnidadMedida;
            pedidoProducto.UnidadCompra = producto.UnidadCompra;
            pedidoProducto.PrecioUnidadCompra = producto.PrecioUnidadCompra;
            pedidoProducto.CantidadEntregada = 0;
            pedidoProducto.CreadoPor = Session["Usuario"].ToString();
            pedidoProducto.FechaCreacion = DateTime.Now;

            respuesta = lnPedidoProducto.PedidoProductoCrear(pedidoProducto);

            ViewBag.ListaProducto = util.DropDownProducto();
            if (respuesta == "")
            {
                return RedirectToAction("PedidoEditar", "Pedido", new { IdPedido = pedidoProducto.IdPedido });
            }
            else
            {
                return RedirectToAction("PedidoProductoCrear", "PedidoProducto", new { pedidoProducto = pedidoProducto, mensajeError = respuesta });
            }
        }

        public PartialViewResult PedidoProductoListar(int IdPedido)
        {
            List<PedidoProducto> pedidoProductos = new List<PedidoProducto>();
            pedidoProductos = lnPedidoProducto.PedidoProductoLeer(IdPedido);

            return PartialView(pedidoProductos);
        }

        public ActionResult PedidoProductoEliminar(PedidoProducto pedidoProducto)
        {
            string respuesta = lnPedidoProducto.PedidoProductoEliminar(pedidoProducto);

            return RedirectToAction("PedidoEditar", "Pedido", new { IdPedido = pedidoProducto.IdPedido, mensajeError = "" });
        }
 }
}