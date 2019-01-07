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
    public class ClienteController : Controller
    {
        LNCliente lnCliente = new LNCliente();
        Util util = new Util();
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ClienteCrear()
        {
            ViewBag.TipoDocumento = util.DropDownTipoDocumento();
            ViewBag.EstadoCliente = util.DropDownListaEstados();
            ViewBag.TipoCliente = util.DropDownTipoCliente();

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ClienteCrear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                string Respuesta = "";
                cliente.CreadoPor = Session["Usuario"].ToString();
                cliente.FechaCreacion = DateTime.Now;

                Respuesta = lnCliente.ClienteCrear(cliente);

                if (Respuesta == "")
                    return RedirectToAction("Index", "Cliente");
                else
                {
                    ViewBag.MensajeUsuarioCrear = Respuesta;
                    return RedirectToAction("ClienteCrear", "Cliente");
                }
            }
            else
            {
                ViewBag.TipoDocumento = util.DropDownTipoDocumento();
                ViewBag.EstadoCliente = util.DropDownListaEstados();
                ViewBag.TipoCliente = util.DropDownTipoCliente();
                return View();
            }

        }


        public PartialViewResult ClienteListar(int IdCliente)
        {
            List<Cliente> cliente = new List<Cliente>();
            cliente = lnCliente.ClienteLeer(IdCliente);

            return PartialView(cliente);
        }
    }
}