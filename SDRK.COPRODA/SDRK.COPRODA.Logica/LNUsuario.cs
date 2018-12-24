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

        public string UsuarioCrear(string TipoUsuario, string Nombre, string Apellido, string IdTipoDocumento, string DocumentoIdentidad,
    string Telefono, string Celular, string Usuario, string ClaveAcceso, string EstadoUsuario, string CreadoPor, DateTime FechaCreacion)
        {
            return adUsuario.UsuarioCrear(TipoUsuario, Nombre, Apellido, IdTipoDocumento, DocumentoIdentidad,
  Telefono, Celular, Usuario, ClaveAcceso, EstadoUsuario, CreadoPor, FechaCreacion);
        }
        }
}
