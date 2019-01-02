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
    public class UsuarioController : Controller
    {
        Util util = new Util();
        LNUsuario lnUsuario = new LNUsuario();
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CrearUsuario()
        {
            ViewBag.ListaEstados = util.DropDownListaEstados();
            ViewBag.MensajeUsuarioCrear = "";
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult CrearUsuario(Usuario usuario)
        {
            string Respuesta = "";
            usuario.CreadoPor = Session["Usuario"].ToString();
            usuario.FechaCreacion = DateTime.Now;

            Respuesta = lnUsuario.UsuarioCrear(usuario);

            if (Respuesta == "")
                return RedirectToAction("Index", "Login");
            else
            {
                ViewBag.MensajeUsuarioCrear = Respuesta;
                return RedirectToAction("CrearUsuario", "Usuario");
            }
        }
    }
}