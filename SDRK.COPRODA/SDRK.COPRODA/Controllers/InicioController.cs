using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDRK.COPRODA.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["Login"]))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }
}