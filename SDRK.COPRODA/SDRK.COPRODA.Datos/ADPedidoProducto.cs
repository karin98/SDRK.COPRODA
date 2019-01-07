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
    public class ADPedidoProducto
    {
        ADConexion cnn = new ADConexion();

        public List<PedidoProducto> PedidoProductoLeer(int IdPedido)
        {
            List<PedidoProducto> pedidoProductos = new List<PedidoProducto>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_PedidoProductoLeer";
                cmd.Connection = cnn.cn;
                cnn.Conectar();
                cmd.Parameters.AddWithValue("pIdPedido", IdPedido);

                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    PedidoProducto pedidoProducto = new PedidoProducto();
                    pedidoProducto.IdPedidoProducto = Funciones.ToInt(dt.Rows[n]["IdPedidoProducto"]);
                    pedidoProducto.IdPedido = Funciones.ToInt(dt.Rows[n]["IdPedido"]);
                    pedidoProducto.IdProducto = Funciones.ToInt(dt.Rows[n]["IdProducto"]);
                    pedidoProducto.Nombre = Funciones.ToString(dt.Rows[n]["Nombre"]);
                    pedidoProducto.Cantidad = Funciones.ToDecimal(dt.Rows[n]["Cantidad"]);
                    pedidoProducto.UnidadMedida = Funciones.ToString(dt.Rows[n]["UnidadMedida"]);
                    pedidoProducto.PrecioUnidadMedida = Funciones.ToDecimal(dt.Rows[n]["PrecioUnidadMedida"]);
                    pedidoProducto.UnidadCompra = Funciones.ToString(dt.Rows[n]["UnidadCompra"]);
                    pedidoProducto.PrecioUnidadCompra = Funciones.ToDecimal(dt.Rows[n]["PrecioUnidadCompra"]);
                    pedidoProducto.CantidadEntregada = Funciones.ToDecimal(dt.Rows[n]["CantidadEntregada"]);
                    pedidoProducto.CreadoPor = Funciones.ToString(dt.Rows[n]["CreadoPor"]);
                    pedidoProducto.FechaCreacion = Funciones.ToDateTime(dt.Rows[n]["FechaCreacion"]);
                    pedidoProducto.ModificadoPor = Funciones.ToString(dt.Rows[n]["ModificadoPor"]);
                    pedidoProducto.FechaModificacion = Funciones.ToDateTime(dt.Rows[n]["FechaModificacion"]);


                    pedidoProductos.Add(pedidoProducto);

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

            return pedidoProductos;
        }

        public string PedidoProductoCrear(PedidoProducto pedidoProducto)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_PedidoProductoCrear";
                cmd.Connection = cnn.cn;
                cnn.Conectar();
                cmd.Parameters.AddWithValue("pIdPedido", pedidoProducto.IdPedido);
                cmd.Parameters.AddWithValue("pIdProducto", pedidoProducto.IdProducto);
                cmd.Parameters.AddWithValue("pCantidad", pedidoProducto.Cantidad);
                cmd.Parameters.AddWithValue("pUnidadMedida", pedidoProducto.UnidadMedida);
                cmd.Parameters.AddWithValue("pPrecioUnidadMedida", pedidoProducto.PrecioUnidadMedida);
                cmd.Parameters.AddWithValue("pUnidadCompra", pedidoProducto.UnidadCompra);
                cmd.Parameters.AddWithValue("pPrecioUnidadCompra", pedidoProducto.PrecioUnidadCompra);
                cmd.Parameters.AddWithValue("pCantidadEntregada", pedidoProducto.CantidadEntregada);
                cmd.Parameters.AddWithValue("pCreadoPor", pedidoProducto.CreadoPor);
                cmd.Parameters.AddWithValue("pFechaCreacion", pedidoProducto.FechaCreacion);
                
                cmd.ExecuteNonQuery();
                cnn.Desconectar();

                return "";
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
                return "Error al crear el pedido producto";
            }
        }

        public string PedidoProductoEditar(PedidoProducto pedidoProducto)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_PedidoProductoEditar"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.Parameters.AddWithValue("pIdPedidoProducto", pedidoProducto.IdPedidoProducto);
                cmd.Parameters.AddWithValue("pIdPedido", pedidoProducto.IdPedido);
                cmd.Parameters.AddWithValue("pIdProducto", pedidoProducto.IdProducto);
                cmd.Parameters.AddWithValue("pCantidad", pedidoProducto.Cantidad);
                cmd.Parameters.AddWithValue("pUnidadMedida", pedidoProducto.UnidadMedida);
                cmd.Parameters.AddWithValue("pPrecioUnidadMedida", pedidoProducto.PrecioUnidadMedida);
                cmd.Parameters.AddWithValue("pUnidadCompra", pedidoProducto.UnidadCompra);
                cmd.Parameters.AddWithValue("pPrecioUnidadCompra", pedidoProducto.PrecioUnidadCompra);
                cmd.Parameters.AddWithValue("pCantidadEntregada", pedidoProducto.CantidadEntregada);
                cmd.Parameters.AddWithValue("pModificadoPor", pedidoProducto.ModificadoPor);
                cmd.Parameters.AddWithValue("pFechaModificacion", pedidoProducto.FechaModificacion);

                cmd.ExecuteNonQuery();
                cnn.Desconectar();

                return "";
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
                return "Error al actualizar el PedidoProducto";
            }
        }

        public string PedidoProductoEliminar(PedidoProducto pedidoProducto)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_PedidoProductoEliminar";
                cmd.Connection = cnn.cn;
                cnn.Conectar();
                cmd.Parameters.AddWithValue("pIdPedido", pedidoProducto.IdPedido);
                cmd.Parameters.AddWithValue("pIdPedidoProducto", pedidoProducto.IdPedidoProducto);

                cmd.ExecuteNonQuery();
                cnn.Desconectar();

                return "";
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
                return "Error al eliminar el pedido producto";
            }
        }


        //Elimiar PedidoProducto
    }
}
