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
    public class PedidoController : Controller
    {
        Util util = new Util();
        LNPedidoProducto lnPedidoProducto = new LNPedidoProducto();
        LNPedido lnPedido = new LNPedido();
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult PedidoCrear()
        {
            ViewBag.ListaEstadoPedido = util.DropDownListaEstadoPedido();
            ViewBag.ListaCliente = util.DropDownListaCliente();
            ViewBag.ListaDirecciones = util.DropDownDireccion(0);
            ViewBag.ListaTipoEntrega = util.DropDownListaTipoEntrega();

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult PedidoCrear(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                string Respuesta = "";
                pedido.IdUsuario = Int32.Parse(Session["IdUsuario"].ToString());
                pedido.EstadoPedido = "Solicitado";
                pedido.CreadoPor = Session["Usuario"].ToString();
                pedido.FechaCreacion = DateTime.Now;

                Respuesta = lnPedido.PedidoCrear(pedido);

                if (Respuesta == "")
                    return RedirectToAction("Index", "Pedido");
                else
                {
                    ViewBag.ListaEstadoPedido = util.DropDownListaEstadoPedido();
                    ViewBag.ListaTipoEntrega = util.DropDownListaTipoEntrega();
                    ViewBag.ListaCliente = util.DropDownListaCliente();
                    ViewBag.ListaDirecciones = util.DropDownDireccion(pedido.IdCliente);
                    return View();
                }
            }
            else
            {
                ViewBag.ListaEstadoPedido = util.DropDownListaEstadoPedido();
                ViewBag.ListaTipoEntrega = util.DropDownListaTipoEntrega();
                ViewBag.ListaCliente = util.DropDownListaCliente();
                ViewBag.ListaDirecciones = util.DropDownDireccion(pedido.IdCliente);
                return View();
            }
        }

        [HttpGet]
        public ActionResult PedidoEditar(Pedido pedido, string mensajeError)
        {
            pedido = lnPedido.PedidoLeer(pedido.IdPedido).First();

            decimal Total = 0;
            List<PedidoProducto> origenDatos = lnPedidoProducto.PedidoProductoLeer(pedido.IdPedido);
            if (origenDatos.Count != 0)
            {
                foreach (PedidoProducto pedidoProducto in origenDatos)
                {
                    Total = Math.Round(Total + (pedidoProducto.PrecioUnidadMedida * pedidoProducto.Cantidad), 2);
                }
            }
            ViewBag.ListaEstadoPedido = util.DropDownListaEstadoPedido();
            ViewBag.ListaTipoEntrega = util.DropDownListaTipoEntrega();
            pedido.TotalPedido = Total;
            pedido.TotalItems = origenDatos.Count;

            ViewBag.ListaDireccion = util.DropDownDireccion(pedido.IdCliente);
            return View(pedido);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult PedidoEditar(Pedido pedido)
        {
            string Respuesta = "";
            pedido.ModificadoPor = Session["Usuario"].ToString();
            pedido.FechaModificacion = DateTime.Now;

            Respuesta = lnPedido.PedidoEditar(pedido);

            return RedirectToAction("PedidoEditar", "Pedido", new { IdPedido = pedido.IdPedido, mensajeError = Respuesta });

        }

        public PartialViewResult PedidoListar(int IdPedido)
        {
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = lnPedido.PedidoLeer(IdPedido);

            return PartialView(pedidos);
        }

        /*Pedido Producto*/


    }
}