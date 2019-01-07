using SDRK.COPRODA.Datos;
using SDRK.COPRODA.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Logica
{
    public class LNProducto
    {
        ADProducto adproducto = new ADProducto();

        public List<Producto> ProductoLeer(int idProducto)
        {
            return adproducto.ProductoLeer(idProducto);
        }
    }
}
