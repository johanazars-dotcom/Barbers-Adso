using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

public class ConexionFinanzaD
{
    private SqlConnection conn;

    public ConexionFinanzaD()
    {
        conn = new SqlConnection("Data Source=DESKTOP-MUT4LN4\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;Integrated Security=True;TrustServerCertificate=True");
    }

    public SqlConnection AbrirConexion()
    {
        if (conn.State == System.Data.ConnectionState.Closed)
            conn.Open();

        return conn;
    }

    public void CerrarConexion()
    {
        if (conn.State == System.Data.ConnectionState.Open)
            conn.Close();
    }
}
