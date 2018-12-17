using SDRK.COPRODA.Datos;
using SDRK.COPRODA.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Logica
{
    public class LNUsuario
    {
        ADUsuario adUsuario = new ADUsuario();

        public Usuario Usuario_Validar(string pUsuario, string pClaveAcceso)
        {
            return adUsuario.Usuario_Validar(pUsuario, pClaveAcceso);
        }
    }
}
