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
    public class ADPedido
    {
        ADConexion cnn = new ADConexion();

        public List<Pedido> PedidoLeer(int IdPedido)
        {
            List<Pedido> pedidos = new List<Pedido>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_PedidoLeer";
                cmd.Connection = cnn.cn;
                cnn.Conectar();
                cmd.Parameters.AddWithValue("PIdPedido", IdPedido);

                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    Pedido pedido = new Pedido();
                    pedido.IdPedido = Funciones.ToInt(dt.Rows[n]["IdPedido"]);
                    pedido.NumeroPedido = Funciones.ToString(dt.Rows[n]["NumeroPedido"]);
                    pedido.IdUsuario = Funciones.ToInt(dt.Rows[n]["IdUsuario"]);
                    pedido.IdCliente = Funciones.ToInt(dt.Rows[n]["IdCliente"]);
                    pedido.NombreCliente = Funciones.ToString(dt.Rows[n]["Nombre"]);
                    pedido.ApellidoCliente = Funciones.ToString(dt.Rows[n]["Apellido"]);
                    pedido.DireccionFacturacion = Funciones.ToString(dt.Rows[n]["DireccionFacturacion"]);
                    pedido.IdDireccionEntrega = Funciones.ToInt(dt.Rows[n]["IdDireccionEntrega"]);
                    pedido.NombreDireccionEntrega = Funciones.ToString(dt.Rows[n]["NombreDireccion"]);
                    pedido.TipoEntrega = Funciones.ToString(dt.Rows[n]["TipoEntrega"]);
                    pedido.FechaEntrega = Funciones.ToDateTime(dt.Rows[n]["FechaEntrega"]);
                    pedido.EstadoPedido = Funciones.ToString(dt.Rows[n]["EstadoPedido"]);
                    pedido.FechaCambioEstado = Funciones.ToDateTime(dt.Rows[n]["FechaCambioEstado"]);
                    pedido.CreadoPor = Funciones.ToString(dt.Rows[n]["CreadoPor"]);
                    pedido.FechaCreacion = Funciones.ToDateTime(dt.Rows[n]["FechaCreacion"]);
                    pedido.ModificadoPor = Funciones.ToString(dt.Rows[n]["ModificadoPor"]);
                    pedido.FechaModificacion = Funciones.ToDateTime(dt.Rows[n]["FechaModificacion"]);
                    pedidos.Add(pedido);

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

            return pedidos;
        }

        public string PedidoActualizarEstado(Pedido pedido)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_PedidoActualizarEstado"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();
                cmd.Parameters.AddWithValue("pIdPedido", pedido.IdPedido);
                cmd.Parameters.AddWithValue("pEstadoPedido", pedido.EstadoPedido);

                cmd.ExecuteNonQuery();
                cnn.Desconectar();

                return "";
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
                return "Error al actualizar el estado del pedido";
            }
        }

        public string PedidoCrear(Pedido pedido)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_PedidoCrear"; //Crear Procedimiento //numero de pedido se genera solo
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.Parameters.AddWithValue("pIdUsuario", pedido.IdUsuario);
                cmd.Parameters.AddWithValue("pIdCliente", pedido.IdCliente);
                cmd.Parameters.AddWithValue("pDireccionFacturacion", pedido.DireccionFacturacion);
                cmd.Parameters.AddWithValue("pIdDireccionEntrega", pedido.IdDireccionEntrega);
                cmd.Parameters.AddWithValue("pTipoEntrega", pedido.TipoEntrega);
                cmd.Parameters.AddWithValue("pFechaEntrega", pedido.FechaEntrega);
                cmd.Parameters.AddWithValue("pEstadoPedido", pedido.EstadoPedido);
                cmd.Parameters.AddWithValue("pCreadoPor", pedido.CreadoPor);
                cmd.Parameters.AddWithValue("pFechaCreacion", pedido.FechaCreacion);

                cmd.ExecuteNonQuery();
                cnn.Desconectar();

                return "";
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
                return "Error al crear el pedido";
            }
        }

        public string PedidoEditar(Pedido pedido)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_PedidoEditar"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.Parameters.AddWithValue("pIdPedido", pedido.IdPedido);
                cmd.Parameters.AddWithValue("pDireccionFacturacion", pedido.DireccionFacturacion);
                cmd.Parameters.AddWithValue("pIdDireccionEntrega", pedido.IdDireccionEntrega);
                cmd.Parameters.AddWithValue("pTipoEntrega", pedido.TipoEntrega);
                cmd.Parameters.AddWithValue("pFechaEntrega", pedido.FechaEntrega);
                cmd.Parameters.AddWithValue("pEstadoPedido", pedido.EstadoPedido);
                cmd.Parameters.AddWithValue("pFechaCambioEstado", pedido.FechaCambioEstado);
                cmd.Parameters.AddWithValue("pModificadoPor", pedido.ModificadoPor);
                cmd.Parameters.AddWithValue("pFechaModificacion", pedido.FechaModificacion);

                cmd.ExecuteNonQuery();
                cnn.Desconectar();

                return "";
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
                return "Error al actualizar el pedido";
            }
        }

        public List<TipoTransaccion> TipoTransaccionLeer()
        {
            List<TipoTransaccion> tipoTransacciones = new List<TipoTransaccion>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TipoTransaccionLeer"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    TipoTransaccion tipoTransaccion = new TipoTransaccion();
                    tipoTransaccion.IdTipoTransaccion = Funciones.ToString(dt.Rows[n]["IdTipoTransaccion"]);
                    tipoTransaccion.TipoTransaccionValor = Funciones.ToString(dt.Rows[n]["TipoTransaccion"]);
                    tipoTransaccion.Descripcion = Funciones.ToString(dt.Rows[n]["Descripcion"]);
                    tipoTransacciones.Add(tipoTransaccion);
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

            return tipoTransacciones;
        }

        /*Tipo Comprobante de Pago (Comprobante de Pago)*/
        public List<TipoComprobante> TipoComprobanteLeer()
        {
            List<TipoComprobante> tipoComprobantes = new List<TipoComprobante>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TipoComprobanteLeer"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    TipoComprobante tipoComprobante = new TipoComprobante();
                    tipoComprobante.IdTipoComprobante = Funciones.ToString(dt.Rows[n]["IdTipoComprobante"]);
                    tipoComprobante.TipoComprobanteValor = Funciones.ToString(dt.Rows[n]["TipoComprobante"]);
                    tipoComprobante.Descripcion = Funciones.ToString(dt.Rows[n]["Descripcion"]);
                    tipoComprobantes.Add(tipoComprobante);
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

            return tipoComprobantes;
        }

    }
}
