using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datos
{
    public class HistorialPuestoD
    {
        private string cadenaConexion = "Data Source=DESKTOP-MUT4LN4\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;Integrated Security=True;";

        public System.Collections.Generic.List<Modelos.HistorialPuestoM> ObtenerHistorialPorPuesto(int idPuesto)
        {
            System.Collections.Generic.List<Modelos.HistorialPuestoM> lista = new System.Collections.Generic.List<Modelos.HistorialPuestoM>();

            System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection(cadenaConexion);
            string consulta = "SELECT idCita, idUsuario, idBarbero, idPuesto, hora, fechaCita, idEstado FROM cita WHERE idPuesto = @idPuesto";
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@idPuesto", idPuesto);

            conexion.Open();
            System.Data.SqlClient.SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Modelos.HistorialPuestoM cita = new Modelos.HistorialPuestoM();
                cita.IdCita = System.Convert.ToInt32(lector["idCita"]);
                cita.IdUsuario = System.Convert.ToInt32(lector["idUsuario"]);
                cita.IdBarbero = System.Convert.ToInt32(lector["idBarbero"]);
                cita.IdPuesto = System.Convert.ToInt32(lector["idPuesto"]);
                cita.Hora = lector["hora"].ToString();
                cita.FechaCita = lector["fechaCita"].ToString();
                cita.IdEstado = System.Convert.ToInt32(lector["idEstado"]);

                lista.Add(cita);
            }

            lector.Close();
            conexion.Close();

            return lista;
        }
    }
}
