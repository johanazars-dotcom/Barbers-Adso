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
            oConexion = new SqlConnection("Data Source=.;Initial Catalog=dbBarbersAdso;Integrated Security=True;");
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