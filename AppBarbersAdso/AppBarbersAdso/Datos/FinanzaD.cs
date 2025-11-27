using AppBarbersAdso.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class FinanzaD
{
    private ConexionFinanzaD conexion = new ConexionFinanzaD();

    public DataTable ObtenerPagos()
    {
        SqlCommand cmd = new SqlCommand(
            "SELECT idFinanzas, pago, idPuesto, idContrato, idAdministrador FROM finanza",
            conexion.AbrirConexion()
        );

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tabla = new DataTable();
        da.Fill(tabla);

        conexion.CerrarConexion();
        return tabla;
    }

    public bool RegistrarPago(FinanzaM f)
    {
        SqlCommand cmd = new SqlCommand(
            "INSERT INTO finanza (pago, idPuesto, idContrato, idAdministrador) VALUES (@pago, @idPuesto, @idContrato, @idAdministrador)",
            conexion.AbrirConexion()
        );

        cmd.Parameters.AddWithValue("@pago", f.Pago);
        cmd.Parameters.AddWithValue("@idPuesto", f.IdPuesto);
        cmd.Parameters.AddWithValue("@idContrato", f.IdContrato);
        cmd.Parameters.AddWithValue("@idAdministrador", f.IdAdministrador);

        int filas = cmd.ExecuteNonQuery();
        conexion.CerrarConexion();

        return filas > 0;
    }
}
