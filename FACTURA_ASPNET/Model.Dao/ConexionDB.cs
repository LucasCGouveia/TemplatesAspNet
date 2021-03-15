using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
   public class ConexionDB
    {


        private static ConexionDB objConexionDB=null;
        private SqlConnection con;
        string StringConexao = @"Data Source=NOTNEWMIGHT\SQNPRD001;Initial Catalog=ventas;Persist Security Info=True;User ID=sa;Password=010921";

        private ConexionDB()
        {
            //con = new SqlConnection("Data Source=NOTNEWMIGHT\SQNPRD001;Initial Catalog=ventas;Integrated Security=True");
            SqlConnection conn = new SqlConnection(StringConexao);
            conn.ConnectionString = StringConexao;
            //conn.Open();
            con = conn;
        }

        public static ConexionDB saberEstado()
        {
            if (objConexionDB == null)
            {
                objConexionDB = new ConexionDB();

            }
            return objConexionDB;
        }

        public SqlConnection getCon()
        {
            return con;
        }

        public void closeDB()
        {
            objConexionDB = null;
        }
    }
}
