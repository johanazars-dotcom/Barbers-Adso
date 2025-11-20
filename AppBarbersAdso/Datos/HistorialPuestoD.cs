using AppBarbersAdso.Modelo;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppBarbersAdso.Datos
{
    public class HistorialPuestoD
    {
        ClConexion conexion = new ClConexion();

        public List<HistorialPuestoM> ObtenerHistorialPorPuesto(int idPuesto)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = "SELECT idCita, idUsuario, idBarbero, idPuesto, hora, fechaCita, idEstado " +
                              "FROM cita WHERE idPuesto = @idPuesto";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@idPuesto", idPuesto);

            SqlDataReader lector = cmd.ExecuteReader();

            List<HistorialPuestoM> lista = new List<HistorialPuestoM>();

            while (lector.Read())
            {
                HistorialPuestoM cita = new HistorialPuestoM();

                cita.IdCita = Convert.ToInt32(lector["idCita"]);
                cita.IdUsuario = Convert.ToInt32(lector["idUsuario"]);
                cita.IdBarbero = Convert.ToInt32(lector["idBarbero"]);
                cita.IdPuesto = Convert.ToInt32(lector["idPuesto"]);
                cita.Hora = lector["hora"].ToString();
                cita.FechaCita = lector["fechaCita"].ToString();
                cita.IdEstado = Convert.ToInt32(lector["idEstado"]);

                lista.Add(cita);
            }

            conexion.MtcerrarConexion();
            return lista;
        }
    }
}
