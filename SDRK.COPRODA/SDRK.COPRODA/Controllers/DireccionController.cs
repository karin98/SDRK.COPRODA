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
    public class DireccionController : Controller
    {
        Util util = new Util();
        LNCliente lnCliente = new LNCliente();
        // GET: Direccion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DireccionCrear(int IdCliente)
        {
            Direccion direccion = new Direccion();
            direccion.IdCliente = IdCliente;
            ViewBag.IdCliente = IdCliente;
            ViewBag.EstadoDireccion = util.DropDownListaEstados();

            return View(direccion);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DireccionCrear(Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                string Respuesta = "";
                direccion.CreadoPor = Session["Usuario"].ToString();
                direccion.FechaCreacion = DateTime.Now;

                Respuesta = lnCliente.DireccionCrear(direccion);

                if (Respuesta == "")
                    return RedirectToAction("ClienteEditar", "Cliente", new { IdCliente = direccion.IdCliente, mensajeError="" });
                else
                {
                    ViewBag.TipoDocumento = util.DropDownTipoDocumento();
                    ViewBag.EstadoCliente = util.DropDownListaEstados();
                    ViewBag.TipoCliente = util.DropDownTipoCliente();
                    return View();
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

        [HttpGet]
        public ActionResult DireccionEditar(Direccion direccion, string mensajeError)
        {
            direccion = lnCliente.DireccionLeer(direccion.IdDireccion, direccion.IdCliente).First();
            ViewBag.EstadoDireccion = util.DropDownListaEstados();

            return View(direccion);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DireccionEditar(Direccion direccion)
        {
            string Respuesta = "";
            direccion.ModificadoPor = Session["Usuario"].ToString();
            direccion.FechaModificacion = DateTime.Now;

            Respuesta = lnCliente.DireccionEditar(direccion);

            return RedirectToAction("DireccionEditar", "Direccion", new { IdDireccion = direccion.IdDireccion, mensajeError = Respuesta });

        }

        public PartialViewResult DireccionListar(int idCliente)
        {
            List<Direccion> direcciones = new List<Direccion>();
            direcciones = lnCliente.DireccionLeer(0, idCliente);

            return PartialView(direcciones);
        }
    }
}