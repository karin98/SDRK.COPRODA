﻿using MySql.Data.MySqlClient;
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

        public Pedido PedidoLeer(string IdPedido)
        {
            Pedido pedido = new Pedido();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_PedidoLeer"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();
                cmd.Parameters.AddWithValue("pIdPedido", IdPedido);

                cmd.ExecuteNonQuery();
                cnn.Desconectar();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    pedido.IdPedido = Funciones.ToInt(dt.Rows[n]["IdPedido"]);
                    pedido.NumeroPedido = Funciones.ToString(dt.Rows[n]["NumeroPedido"]);
                    pedido.IdUsuario = Funciones.ToInt(dt.Rows[n]["IdUsuario"]);
                    pedido.IdCliente = Funciones.ToInt(dt.Rows[n]["IdCliente"]);
                    pedido.DireccionFacturacion = Funciones.ToString(dt.Rows[n]["DireccionFacturacion"]);
                    pedido.IdDireccionEntrega = Funciones.ToInt(dt.Rows[n]["IdDireccionEntrega"]);
                    pedido.TipoEntrega = Funciones.ToString(dt.Rows[n]["TipoEntrega"]);
                    pedido.FechaEntrega = Funciones.ToDateTime(dt.Rows[n]["FechaEntrega"]);
                    pedido.EstadoPedido = Funciones.ToString(dt.Rows[n]["EstadoPedido"]);
                    pedido.FechaCambioEstado = Funciones.ToDateTime(dt.Rows[n]["FechaCambioEstado"]);
                    pedido.CreadoPor = Funciones.ToString(dt.Rows[n]["CreadoPor"]);
                    pedido.FechaCreacion = Funciones.ToDateTime(dt.Rows[n]["FechaCreacion"]);
                    pedido.ModificadoPor = Funciones.ToString(dt.Rows[n]["ModificadoPor"]);
                    pedido.FechaModificacion = Funciones.ToDateTime(dt.Rows[n]["FechaModificacion"]);

                    cnn.Desconectar();
                }
            }
            catch (MySqlException ex)
            {
                cnn.Desconectar();
            }

            return pedido;
        }

        public string PedidoActualizarEstado(string EstadoPedidoedido)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_PedidoActualizarEstado"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();
                cmd.Parameters.AddWithValue("pEstadoPedido", EstadoPedidoedido);

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

        public string PedidoCrear(int IdUsuario, int IdCliente, string DireccionFacturacion, int IdDireccionEntrega, string TipoEntrega, DateTime FechaEntrega, string EstadoPedido, string CreadoPor, DateTime FechaCreacion)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_PedidoCrear"; //Crear Procedimiento //numero de pedido se genera solo
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.Parameters.AddWithValue("pIdUsuario", IdUsuario);
                cmd.Parameters.AddWithValue("pIdCliente", IdCliente);
                cmd.Parameters.AddWithValue("pDireccionFacturacion", DireccionFacturacion);
                cmd.Parameters.AddWithValue("pIdDireccionEntrega", IdDireccionEntrega);
                cmd.Parameters.AddWithValue("pTipoEntrega", TipoEntrega);
                cmd.Parameters.AddWithValue("pFechaEntrega", FechaEntrega);
                cmd.Parameters.AddWithValue("pEstadoPedido", EstadoPedido);
                cmd.Parameters.AddWithValue("pCreadoPor", CreadoPor);
                cmd.Parameters.AddWithValue("pFechaCreacion", FechaCreacion);

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

        public string PedidoActualizar(string DireccionFacturacion, int IdDireccionEntrega, string TipoEntrega, DateTime FechaEntrega, string EstadoPedido, DateTime FechaCambioEstado, string ModificadoPor, DateTime FechaModificacion)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_PedidoActualizar"; //Crear Procedimiento
                cmd.Connection = cnn.cn;
                cnn.Conectar();

                cmd.Parameters.AddWithValue("pDireccionFacturacion", DireccionFacturacion);
                cmd.Parameters.AddWithValue("pIdDireccionEntrega", IdDireccionEntrega);
                cmd.Parameters.AddWithValue("pTipoEntrega", TipoEntrega);
                cmd.Parameters.AddWithValue("pFechaEntrega", FechaEntrega);
                cmd.Parameters.AddWithValue("pEstadoPedido", EstadoPedido);
                cmd.Parameters.AddWithValue("pFechaCambioEstado", FechaCambioEstado);
                cmd.Parameters.AddWithValue("pModificadoPor", ModificadoPor);
                cmd.Parameters.AddWithValue("pFechaModificacion", FechaModificacion);

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

    }
}