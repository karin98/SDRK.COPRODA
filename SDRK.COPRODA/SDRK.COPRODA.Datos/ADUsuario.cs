using MySql.Data.MySqlClient;
using SDRK.COPRODA.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Datos
{
    public class ADUsuario
    {
        ADConexion cnn = new ADConexion();

        public Usuario Usuario_Validar(string pUsuario, string pClaveAcceso)
        {
            Usuario usuario = new Usuario();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UsuarioValidar";
                cmd.Connection = cnn.cn;
                cnn.Conectar();
                //cmd.Parameters.Add(new MySqlParameter("pUsuario", MySqlDbType.VarChar)).Value = pUsuario;
                //cmd.Parameters.Add(new MySqlParameter("pClaveAcceso", MySqlDbType.VarChar)).Value = pClaveAcceso;
                cmd.Parameters.AddWithValue("pUsuario", pUsuario);
                cmd.Parameters.AddWithValue("pClaveAcceso", pClaveAcceso);

                cmd.ExecuteNonQuery();
                cnn.Desconectar();


                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);


                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    usuario.IdUsuario = Funciones.ToInt(dt.Rows[n]["IdUsuario"]);
                    usuario.TipoUsuario = Funciones.ToString(dt.Rows[n]["TipoUsuario"]);
                    usuario.Nombre = Funciones.ToString(dt.Rows[n]["Nombre"]);
                    usuario.Apellido = Funciones.ToString(dt.Rows[n]["Apellido"]);
                    usuario.IdTipoDocumentoIdentidad = Funciones.ToString(dt.Rows[n]["IdTipoDocumentoIdentidad"]);
                    usuario.DocumentoIdentidad = Funciones.ToString(dt.Rows[n]["DocumentoIdentidad"]);
                    usuario.Telefono = Funciones.ToString(dt.Rows[n]["Telefono"]);
                    usuario.Celular = Funciones.ToString(dt.Rows[n]["Celular"]);
                    usuario.UsuarioCD = Funciones.ToString(dt.Rows[n]["Usuario"]);
                    usuario.ClaveAcceso = Funciones.ToString(dt.Rows[n]["ClaveAcceso"]);
                    usuario.EstadoUsuario = Funciones.ToString(dt.Rows[n]["EstadoUsuario"]);
                    usuario.CreadoPor = Funciones.ToString(dt.Rows[n]["CreadoPor"]);
                    usuario.FechaCreacion = Funciones.ToDateTime(dt.Rows[n]["FechaCreacion"]);
                    usuario.ModificadoPor = Funciones.ToString(dt.Rows[n]["ModificadoPor"]);
                    usuario.FechaModificacion = Funciones.ToDateTime(dt.Rows[n]["FechaModificacion"]);

                }
            }
            catch (MySqlException ex) { }
            try
            {
                cnn.Desconectar();
            }
            catch (Exception ex) { }

            return usuario;
        }
    }
}
