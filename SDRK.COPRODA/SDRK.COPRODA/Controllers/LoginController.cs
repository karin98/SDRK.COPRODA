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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario usuarioDatos = lnUsuario.Usuario_Validar(usuario.UsuarioCD, usuario.ClaveAcceso);
                Session["MensajeLogin"] = "";
                if (usuario.UsuarioCD == usuario.UsuarioCD && usuario.ClaveAcceso == usuario.ClaveAcceso)
                {
                    Session["Login"] = true;
                    Session["NombreUsuario"] = usuarioDatos.Nombre;
                    Session["ApellidoUsuario"] = usuarioDatos.Apellido;
                    Session["TipoUsuario"] = usuarioDatos.TipoUsuario;
                    Session["Usuario"] = usuarioDatos.UsuarioCD;
                    return RedirectToAction("Index", "Inicio");
                }
                else
                {
                    Session["MensajeLogin"] = "Credenciales Incorrectas";
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                return View();
            }
        }
    }
}
