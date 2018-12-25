using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDRK.COPRODA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Datos del Usuario
            Session["IdUsuario"] = "";
            Session["TipoUsuario"] = "";
            Session["NombreUsuario"] = "";
            Session["ApellidoUsuario"] = "";
            Session["IdTipoDocumento"] = "";
            Session["Telefono"] = "";
            Session["Celular"] = "";
            Session["Usuario"] = "";
            Session["EstadoUsuario"] = "";

            //Mensajes
            Session["MensajeLogin"] = "";
            Session["MensajeUsuarioCrear"] = "";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}