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
    public class ADProducto
    {
        ADConexion cnn = new ADConexion();

        public List<Producto> ProductoLeer(int idProducto)
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ProductoLeer";
                cmd.Connection = cnn.cn;
                cnn.Conectar();
                cmd.Parameters.AddWithValue("pIdProducto", idProducto);

                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    Producto producto = new Producto();
                    producto.IdProducto = Funciones.ToInt(dt.Rows[n]["IdProducto"]);
                    producto.NombreCorto = Funciones.ToString(dt.Rows[n]["NombreCorto"]);
                    producto.Nombre = Funciones.ToString(dt.Rows[n]["Nombre"]);
                    producto.Descripcion = Funciones.ToString(dt.Rows[n]["Descripcion"]);
                    producto.Marca = Funciones.ToString(dt.Rows[n]["Marca"]);
                    producto.Presentacion = Funciones.ToString(dt.Rows[n]["Presentacion"]);
                    producto.UnidadMedida = Funciones.ToString(dt.Rows[n]["UnidadMedida"]);
                    producto.PrecioUnidadMedida = Funciones.ToDecimal(dt.Rows[n]["PrecioUnidadMedida"]);
                    producto.UnidadCompra = Funciones.ToString(dt.Rows[n]["UnidadCompra"]);
                    producto.PrecioUnidadCompra = Funciones.ToDecimal(dt.Rows[n]["PrecioUnidadCompra"]);
                    producto.Estado = Funciones.ToString(dt.Rows[n]["Estado"]);
                    producto.CreadoPor = Funciones.ToString(dt.Rows[n]["CreadoPor"]);
                    producto.FechaCreacion = Funciones.ToDateTime(dt.Rows[n]["FechaCreacion"]);
                    producto.ModificadoPor = Funciones.ToString(dt.Rows[n]["ModificadoPor"]);
                    producto.FechaModificacion = Funciones.ToDateTime(dt.Rows[n]["FechaModificacion"]);


                    productos.Add(producto);

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

            return productos;
        }
    }
}
