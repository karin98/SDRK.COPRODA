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
    public class ADCliente
    {
        ADConexion cnn = new ADConexion();


        public List<Cliente> ClienteLeer(int idCliente)
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ClienteLeer"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    Cliente cliente = new Cliente();
                    cliente.IdCliente = Funciones.ToInt(dt.Rows[n]["IdCliente"]);
                    cliente.IdTipoCliente = Funciones.ToString(dt.Rows[n]["IdTipoCliente"]);
                    cliente.Nombre = Funciones.ToString(dt.Rows[n]["Nombre"]);
                    cliente.Apellido = Funciones.ToString(dt.Rows[n]["Apellido"]);
                    cliente.IdTipoDocumento = Funciones.ToString(dt.Rows[n]["IdTipoDocumento"]);
                    cliente.DocumentoIdentidad = Funciones.ToString(dt.Rows[n]["DocumentoIdentidad"]);
                    cliente.RazonSocial = Funciones.ToString(dt.Rows[n]["RazonSocial"]);
                    cliente.RUC = Funciones.ToString(dt.Rows[n]["RUC"]);
                    cliente.Telefono = Funciones.ToString(dt.Rows[n]["Telefono"]);
                    cliente.Celular = Funciones.ToString(dt.Rows[n]["Celular"]);
                    cliente.Email = Funciones.ToString(dt.Rows[n]["Email"]);
                    cliente.EstadoCliente = Funciones.ToString(dt.Rows[n]["EstadoCliente"]);
                    cliente.CreadoPor = Funciones.ToString(dt.Rows[n]["CreadoPor"]);
                    cliente.FechaCreacion = Funciones.ToDateTime(dt.Rows[n]["FechaCreacion"]);
                    cliente.ModificadoPor = Funciones.ToString(dt.Rows[n]["ModificadoPor"]);
                    cliente.FechaModificacion = Funciones.ToDateTime(dt.Rows[n]["FechaModificacion"]);
                    clientes.Add(cliente);
                }
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
            }
            try
            {
                cnn.Desconectar();
            }
            catch (Exception ex) { }

            return clientes;
        }

        public string ClienteCrear(Cliente cliente)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ClienteCrear";
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.Parameters.AddWithValue("pIdTipoCliente", cliente.IdTipoCliente);
                cmd.Parameters.AddWithValue("pNombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("pApellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("pIdTipoDocumento", cliente.IdTipoDocumento);
                cmd.Parameters.AddWithValue("pDocumentoIdentidad", cliente.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("pRazonSocial", cliente.RazonSocial);
                cmd.Parameters.AddWithValue("pRUC", cliente.RUC);
                cmd.Parameters.AddWithValue("pTelefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("pCelular", cliente.Celular);
                cmd.Parameters.AddWithValue("pEmail", cliente.Email);
                cmd.Parameters.AddWithValue("pEstadoCliente", cliente.EstadoCliente);
                cmd.Parameters.AddWithValue("pCreadoPor", cliente.CreadoPor);
                cmd.Parameters.AddWithValue("pFechaCreacion", cliente.FechaCreacion);

                cmd.ExecuteNonQuery();
                cnn.Desconectar();

                return "";
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
                return "Error al crear al cliente";
            }
        }

        public string ClienteEditar(Cliente cliente)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ClienteEditar"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.Parameters.AddWithValue("pIdCliente", cliente.IdCliente);
                cmd.Parameters.AddWithValue("pIdTipoCliente", cliente.IdTipoCliente);
                cmd.Parameters.AddWithValue("pNombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("pApellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("pIdTipoDocumento", cliente.IdTipoDocumento);
                cmd.Parameters.AddWithValue("pDocumentoIdentidad", cliente.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("pRazonSocial", cliente.RazonSocial);
                cmd.Parameters.AddWithValue("pRUC", cliente.RUC);
                cmd.Parameters.AddWithValue("pTelefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("pCelular", cliente.Celular);
                cmd.Parameters.AddWithValue("pEmail", cliente.Email);
                cmd.Parameters.AddWithValue("pEstadoCliente", cliente.EstadoCliente);
                cmd.Parameters.AddWithValue("pModificadoPor", cliente.ModificadoPor);
                cmd.Parameters.AddWithValue("pFechaModificacion", cliente.FechaModificacion);

                cmd.ExecuteNonQuery();
                cnn.Desconectar();

                return "";
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
                return "Error al actualizar el cliente";
            }
        }

        public List<TipoCliente> TipoClienteLeer()
        {
            List<TipoCliente> tipoClientes = new List<TipoCliente>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TipoClienteLeer"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    TipoCliente tipoCliente = new TipoCliente();
                    tipoCliente.IdTipoCliente = Funciones.ToString(dt.Rows[n]["IdTipoCliente"]);
                    tipoCliente.TipoClienteValor = Funciones.ToString(dt.Rows[n]["TipoCliente"]);
                    tipoCliente.Descripcion = Funciones.ToString(dt.Rows[n]["Descripcion"]);
                    tipoClientes.Add(tipoCliente);
                }
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
            }
            try
            {
                cnn.Desconectar();
            }
            catch (Exception ex) { }

            return tipoClientes;
        }

        public List<TipoDocumento> TipoDocumentoLeer() //Tipo de Documento de Identidad
        {
            List<TipoDocumento> tipoDocumentos = new List<TipoDocumento>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TipoDocumentoLeer"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    TipoDocumento tipoDocumento = new TipoDocumento();
                    tipoDocumento.IdTipoDocumento = Funciones.ToString(dt.Rows[n]["IdTipoDocumento"]);
                    tipoDocumento.TipoDocumentoValor = Funciones.ToString(dt.Rows[n]["TipoDocumento"]);
                    tipoDocumento.Descripcion = Funciones.ToString(dt.Rows[n]["Descripcion"]);
                    tipoDocumentos.Add(tipoDocumento);
                }
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
            }
            try
            {
                cnn.Desconectar();
            }
            catch (Exception ex) { }

            return tipoDocumentos;
        }

        public List<Direccion> DireccionLeer(int idDireccion, int IdCliente)
        {
            List<Direccion> direcciones = new List<Direccion>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DireccionLeer";
                cmd.Connection = cnn.cn;
                cnn.Conectar();
                cmd.Parameters.AddWithValue("pIdDireccion", idDireccion);
                cmd.Parameters.AddWithValue("pIdCliente", IdCliente);
                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    Direccion direccion = new Direccion();
                    direccion.IdDireccion = Funciones.ToInt(dt.Rows[n]["IdDireccion"]);
                    direccion.NombreDireccion = Funciones.ToString(dt.Rows[n]["NombreDireccion"]);
                    direccion.Calle1 = Funciones.ToString(dt.Rows[n]["Calle1"]);
                    direccion.Calle2 = Funciones.ToString(dt.Rows[n]["Calle2"]);
                    direccion.Distrito = Funciones.ToString(dt.Rows[n]["Distrito"]);
                    direccion.Departamento = Funciones.ToString(dt.Rows[n]["Departamento"]);
                    direccion.Provincia = Funciones.ToString(dt.Rows[n]["Provincia"]);
                    direccion.EstadoDireccion = Funciones.ToString(dt.Rows[n]["EstadoDireccion"]);
                    direccion.CreadoPor = Funciones.ToString(dt.Rows[n]["CreadoPor"]);
                    direccion.FechaCreacion = Funciones.ToDateTime(dt.Rows[n]["FechaCreacion"]);
                    direccion.ModificadoPor = Funciones.ToString(dt.Rows[n]["ModificadoPor"]);
                    direccion.FechaModificacion = Funciones.ToDateTime(dt.Rows[n]["FechaModificacion"]);

                    //Demas datos de direccion

                    direcciones.Add(direccion);
                }
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
            }
            try
            {
                cnn.Desconectar();
            }
            catch (Exception ex) { }

            return direcciones;
        }

        public string DireccionCrear(Direccion direccion)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DireccionCrear"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.Parameters.AddWithValue("pIdCliente", direccion.IdCliente);
                cmd.Parameters.AddWithValue("pNombreDireccion", direccion.NombreDireccion);
                cmd.Parameters.AddWithValue("pCalle1", direccion.Calle1);
                cmd.Parameters.AddWithValue("pCalle2", direccion.Calle2);
                cmd.Parameters.AddWithValue("pDistrito", direccion.Distrito);
                cmd.Parameters.AddWithValue("pDepartamento", direccion.Departamento);
                cmd.Parameters.AddWithValue("pProvincia", direccion.Provincia);
                cmd.Parameters.AddWithValue("pEstadoDireccion", direccion.EstadoDireccion);
                cmd.Parameters.AddWithValue("pCreadoPor", direccion.CreadoPor);
                cmd.Parameters.AddWithValue("pFechaCreacion", direccion.FechaCreacion);

                cmd.ExecuteNonQuery();
                cnn.Desconectar();

                return "";
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
                return "Error al crear la direccion";
            }
        }

        public string DireccionEditar(Direccion direccion)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DireccionEditar"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.Parameters.AddWithValue("pIdDireccion", direccion.IdDireccion);
                cmd.Parameters.AddWithValue("pIdCliente", direccion.IdCliente);
                cmd.Parameters.AddWithValue("pNombreDireccion", direccion.NombreDireccion);
                cmd.Parameters.AddWithValue("pCalle1", direccion.Calle1);
                cmd.Parameters.AddWithValue("pCalle2", direccion.Calle2);
                cmd.Parameters.AddWithValue("pDistrito", direccion.Distrito);
                cmd.Parameters.AddWithValue("pDepartamento", direccion.Departamento);
                cmd.Parameters.AddWithValue("pProvincia", direccion.Provincia);
                cmd.Parameters.AddWithValue("pEstadoDireccion", direccion.EstadoDireccion);
                cmd.Parameters.AddWithValue("pModificadoPor", direccion.ModificadoPor);
                cmd.Parameters.AddWithValue("pFechaModificacion", direccion.FechaModificacion);

                cmd.ExecuteNonQuery();
                cnn.Desconectar();

                return "";
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
                return "Error al editar la direccion";
            }
        }
    }
}
