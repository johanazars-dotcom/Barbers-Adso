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
<<<<<<< HEAD
            oConexion = new SqlConnection("Data Source=JHON\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;Integrated Security=True;Encrypt=False;");
=======
            oConexion = new SqlConnection("Data Source=DESKTOP-8S6S2G8\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;Integrated Security=True;");
>>>>>>> salazar
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