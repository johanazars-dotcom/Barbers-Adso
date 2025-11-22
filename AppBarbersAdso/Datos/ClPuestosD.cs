using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AppBarbersAdso.Logica;
using AppBarbersAdso.Modelo;

namespace AppBarbersAdso.Datos
{
    public class ClPuestosD
    {
        ClConexion conexion = new ClConexion();

        public void CambiarEstadoPuesto(int idPuesto, string estado)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = "UPDATE puesto SET estado = @estado WHERE idPuesto = @idPuesto";
            SqlCommand cmd = new SqlCommand(consulta, conex);

            cmd.Parameters.AddWithValue("@estado", estado);
            cmd.Parameters.AddWithValue("@idPuesto", idPuesto);

            cmd.ExecuteNonQuery();
            conexion.MtcerrarConexion();
        }

        public List<ClPuestosM> ListarPuestosDisponibles()
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = "SELECT * FROM puesto WHERE estado = 'Disponible'";
            SqlCommand cmd = new SqlCommand(consulta, conex);
            SqlDataReader lea = cmd.ExecuteReader();

            List<ClPuestosM> lista = new List<ClPuestosM>();

            while (lea.Read())
            {
                lista.Add(new ClPuestosM()
                {
                    idPuesto = int.Parse(lea["idPuesto"].ToString()),
                    numeroPuesto = lea["numeroPuesto"].ToString(),
                    estado = lea["estado"].ToString()
                });
            }

            lea.Close();
            conexion.MtcerrarConexion();
            return lista;
        }

        public List<ClPuestosM> ListarTodosLosPuestos()
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = "SELECT * FROM puesto";
            SqlCommand cmd = new SqlCommand(consulta, conex);
            SqlDataReader lea = cmd.ExecuteReader();

            List<ClPuestosM> lista = new List<ClPuestosM>();

            while (lea.Read())
            {
                lista.Add(new ClPuestosM()
                {
                    idPuesto = int.Parse(lea["idPuesto"].ToString()),
                    numeroPuesto = lea["numeroPuesto"].ToString(),
                    estado = lea["estado"].ToString()
                });
            }

            lea.Close();
            conexion.MtcerrarConexion();
            return lista;
        }
    }
}


