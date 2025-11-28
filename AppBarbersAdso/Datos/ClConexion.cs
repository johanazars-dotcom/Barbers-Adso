using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AppBarbersAdso.Datos
{
	public class ClConexion
	{
		SqlConnection oConexion;

        public ClConexion()
        {
            oConexion = new SqlConnection("Data Source=JHON\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;User ID=Proyecto;Password=1234;");
        }
        public SqlConnection MtabrirConexion()
        {
            oConexion.Open();
            return oConexion;
        }

        public void MtcerrarConexion()
        {
            oConexion.Close();
        }
    }
}