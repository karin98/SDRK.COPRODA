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
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ClienteCrear()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult ClienteCrear(Cliente cliente)
        {
            return View();
        }
    }
}