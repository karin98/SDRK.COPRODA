using SDRK.COPRODA.Logica;
using SDRK.COPRODA.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDRK.COPRODA.Controllers
{
    public class ProductoController : Controller
    {
        LNProducto lnProducto = new LNProducto();

        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ProductoListar(int idProducto)
        {
            List<Producto> producto = new List<Producto>();
            producto = lnProducto.ProductoLeer(idProducto);

            return PartialView(producto);
        }
    }
}