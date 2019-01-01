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
                cmd.Parameters.AddWithValue("pUsuario", pUsuario);
                cmd.Parameters.AddWithValue("pClave", pClaveAcceso);

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
                    usuario.IdTipoDocumentoIdentidad = Funciones.ToString(dt.Rows[n]["IdTipoDocumento"]);
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

                    cnn.Desconectar();
                }
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
            }

            return usuario;
        }


        public string UsuarioCrear(Usuario usuario)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UsuarioCrear";
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.Parameters.AddWithValue("TipoUsuario", usuario.TipoUsuario);
                cmd.Parameters.AddWithValue("Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("IdTipoDocumento", usuario.IdTipoDocumentoIdentidad);
                cmd.Parameters.AddWithValue("DocumentoIdentidad", usuario.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("Celular", usuario.Celular);
                cmd.Parameters.AddWithValue("Usuario", usuario.UsuarioCD);
                cmd.Parameters.AddWithValue("ClaveAcceso", usuario.ClaveAcceso);
                cmd.Parameters.AddWithValue("EstadoUsuario", usuario.EstadoUsuario);
                cmd.Parameters.AddWithValue("CreadoPor", usuario.CreadoPor);
                cmd.Parameters.AddWithValue("FechaCreacion", usuario.FechaCreacion);
                cmd.ExecuteNonQuery();
                cnn.Desconectar();

                return "";

            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
                return "Error al crear el usuario";
            }
        }


        public string UsuarioEliminar(string Usuario)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UsuarioEliminar"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.Parameters.AddWithValue("Usuario", Usuario);
                cmd.ExecuteNonQuery();
                cnn.Desconectar();

                return "";
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
                return "Error al eliminar el usuario";
            }
        }

        //Listar Usuarios
    }
}