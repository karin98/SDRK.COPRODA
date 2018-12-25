using SDRK.COPRODA.Logica;
using SDRK.COPRODA.Modelo;
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
            Usuario usuario = lnUsuario.Usuario_Validar(pUsuario, pClaveAcceso);
            Session["MensajeLogin"] = "";
            if (pUsuario == usuario.UsuarioCD && pClaveAcceso == usuario.ClaveAcceso)
            {
                Session["NombreUsuario"] = usuario.Nombre;
                Session["Usuario"] = usuario.UsuarioCD;
                return RedirectToAction("Index", "Inicio");
            }
            else
            {
                Session["MensajeLogin"] = "Credenciales Incorrectas";
                return RedirectToAction("Index", "Login");
            }
        }
    }
}