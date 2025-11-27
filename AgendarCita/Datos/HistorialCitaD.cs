using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Modelos;

namespace Datos
{
    public class HistorialCitaD
    {
        private string cadenaConexion = "Data Source=DESKTOP-MUT4LN4\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;Integrated Security=True;";

        public System.Collections.Generic.List<Modelos.HistorialCitaM> ObtenerHistorial(int idUsuario)
        {
            System.Collections.Generic.List<Modelos.HistorialCitaM> lista = new System.Collections.Generic.List<Modelos.HistorialCitaM>();

            string cadenaConexion = "Data Source=DESKTOP-MUT4LN4\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;Integrated Security=True;";
            System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection(cadenaConexion);

            // ✅ Consulta corregida — asegúrate de que el nombre de la tabla sea igual al de tu base de datos (Cita o Citas)
            string consulta =
                "SELECT idCita, nombreCliente, fechaCita, hora FROM Cita";


            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

            conexion.Open();
            System.Data.SqlClient.SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Modelos.HistorialCitaM cita = new Modelos.HistorialCitaM();
                cita.IdCita = System.Convert.ToInt32(lector["idCita"]);
                cita.nombreCliente = lector["idBarbero"].ToString();
                cita.Hora = lector["idPuesto"].ToString();
                cita.FechaCita = lector["fechaCita"].ToString();


                lista.Add(cita);
            }

            lector.Close();
            conexion.Close();

            return lista;
        }

    }
}
