using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRK.COPRODA.Datos
{
    public class ADConexion
    {
        public MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["COPRODA_CONEXION"].ConnectionString);

        public string Conexion()
        {
            return cn.ConnectionString;
        }
        public void Conectar()
        {
            try
            {
                cn.Open();
            }
            catch
            {
            }
        }

        public void Desconectar()
        {
            cn.Close();
        }
    }
}
