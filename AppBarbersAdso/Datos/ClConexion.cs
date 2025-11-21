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
            oConexion = new SqlConnection("Data Source=DESKTOP-PT3DB8G;Initial Catalog=dbBarbersAdso;Integrated Security=True;Encrypt=False;");
=======
            oConexion = new SqlConnection("Data Source=DESKTOP-MUT4LN4\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;Integrated Security=True;");
>>>>>>> Manrique
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