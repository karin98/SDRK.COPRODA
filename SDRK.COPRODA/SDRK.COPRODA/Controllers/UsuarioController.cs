using SDRK.COPRODA.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDRK.COPRODA.Controllers
{
    public class UsuarioController : Controller
    {
        LNUsuario lnUsuario = new LNUsuario();
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }


        ////public ActionResult CrearUsuario()
        ////{
           
        ////    return View();

        ////}
        ////[HttpPost,ValidateAntiForgeryToken]
        public ActionResult CrearUsuario(string TipoUsuario, string Nombre, string Apellido, string IdTipoDocumento, string DocumentoIdentidad,
       string Telefono, string Celular, string Usuario, string ClaveAcceso, string EstadoUsuario, string CreadoPor)
        {
            string Respuesta = "";
            Respuesta = lnUsuario.UsuarioCrear(TipoUsuario, Nombre, Apellido, IdTipoDocumento, DocumentoIdentidad,Telefono, Celular, Usuario, ClaveAcceso, EstadoUsuario, CreadoPor, DateTime.Now);

            if (Respuesta == "")
                return RedirectToAction("Index", "Usuario");
            else
            {
                ViewBag.MensajeUsuarioCrear = Respuesta;
                return RedirectToAction("CrearUsuario", "Usuario");
            }
        }



    }
}