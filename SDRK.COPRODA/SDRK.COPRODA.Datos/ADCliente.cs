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


        //public List<Cliente> ClienteLeer()
        //{
        //    List<Cliente> tipoComprobantes = new List<Cliente>();

        //    try
        //    {
        //        MySqlCommand cmd = new MySqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "sp_TipoComprobanteLeer"; //Crear Procedimiento
        //        cmd.Connection = cnn.cn;
        //        cnn.Conectar();

        //        cmd.ExecuteNonQuery();

        //        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();

        //        da.Fill(dt);

        //        for (int n = 0; n < dt.Rows.Count; n++)
        //        {
        //            TipoComprobante tipoComprobante = new TipoComprobante();
        //            tipoComprobante.IdTipoComprobante = Funciones.ToString(dt.Rows[n]["IdTipoComprobante"]);
        //            tipoComprobante.TipoComprobanteValor = Funciones.ToString(dt.Rows[n]["TipoComprobante"]);
        //            tipoComprobante.Decripcion = Funciones.ToString(dt.Rows[n]["Decripcion"]);
        //            tipoComprobantes.Add(tipoComprobante);
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        cnn.Desconectar();
        //    }
        //    try
        //    {
        //        cnn.Desconectar();
        //    }
        //    catch (Exception ex) { }

        //    return tipoComprobantes;
        //}

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
                    tipoCliente.Descripcion = Funciones.ToString(dt.Rows[n]["Decripcion"]);
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
                    tipoDocumento.Descripcion = Funciones.ToString(dt.Rows[n]["Decripcion"]);
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
    }
}
