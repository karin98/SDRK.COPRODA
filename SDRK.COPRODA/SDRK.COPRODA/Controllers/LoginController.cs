using SDRK.COPRODA.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDRK.COPRODA.Controllers
{
    public class LoginController : Controller
    {
        LNUsuario lnUsuario = new LNUsuario();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Login(string pUsuario, string pClaveAcceso)
        {
            if (pUsuario == lnUsuario.Usuario_Validar(pUsuario, pClaveAcceso).UsuarioCD && pClaveAcceso == lnUsuario.Usuario_Validar(pUsuario, pClaveAcceso).ClaveAcceso)
            {
                Session["Nombre"] = lnUsuario.Usuario_Validar(pUsuario, pClaveAcceso).Nombre;

                return RedirectToAction("About", "Home");
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        }



    }
}