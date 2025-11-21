using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Modelos;

namespace Datos
{
    public class CitaD
    {
        private readonly string cadenaConexion = "Data Source=DESKTOP-MUT4LN4\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;Integrated Security=True;";

        public List<CitaM> Listar()
        {
            var lista = new List<CitaM>();
            SqlConnection cn = null;
            SqlDataReader dr = null;

            try
            {
                cn = new SqlConnection(cadenaConexion);
                // **CORRECCIÓN:** SELECT sin la columna de estado. Asumo que la fecha se llama 'fecha'.
                SqlCommand cmd = new SqlCommand("SELECT idCita, idUsuario, idBarbero, idPuesto, fecha, hora FROM cita;", cn);

                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new CitaM
                    {
                        idCita = Convert.ToInt32(dr["idCita"]),
                        idUsuario = Convert.ToInt32(dr["idUsuario"]),
                        idBarbero = Convert.ToInt32(dr["idBarbero"]),
                        idPuesto = Convert.ToInt32(dr["idPuesto"]),
                        // Lectura con el nombre de columna 'fecha'
                        fechaCita = Convert.ToDateTime(dr["fecha"]),
                        hora = dr["hora"].ToString(),
                        // Eliminada la referencia a idEstado/estado
                    });
                }
            }
            finally
            {
                if (dr != null) dr.Dispose();
                if (cn != null) cn.Dispose();
            }

            return lista;
        }

        public void Guardar(CitaM c)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;

            try
            {
                cn = new SqlConnection(cadenaConexion);

                if (c.idCita == 0)
                {
                    cmd = new SqlCommand(
                        // **CORRECCIÓN:** INSERT sin la columna 'estado'
                        "INSERT INTO cita (idUsuario, idBarbero, idPuesto, fecha, hora) " +
                        "VALUES (@idUsuario, @idBarbero, @idPuesto, @fecha, @hora)", cn);
                }
                else
                {
                    cmd = new SqlCommand(
                        // **CORRECCIÓN:** UPDATE sin la columna 'estado'
                        "UPDATE cita SET idUsuario=@idUsuario, idBarbero=@idBarbero, idPuesto=@idPuesto, fecha=@fecha, hora=@hora " +
                        "WHERE idCita=@id", cn);
                    cmd.Parameters.AddWithValue("@id", c.idCita);
                }

                cmd.Parameters.AddWithValue("@idUsuario", c.idUsuario);
                cmd.Parameters.AddWithValue("@idBarbero", c.idBarbero);
                cmd.Parameters.AddWithValue("@idPuesto", c.idPuesto);
                cmd.Parameters.AddWithValue("@fecha", c.fechaCita);
                cmd.Parameters.AddWithValue("@hora", c.hora);
                // Eliminado el parámetro @idEstado

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (cn != null) cn.Dispose();
            }
        }

        public void Eliminar(int id)
        {
            // Este método no requiere cambios
            SqlConnection cn = null;
            SqlCommand cmd = null;

            try
            {
                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("DELETE FROM cita WHERE idCita=@id", cn);

                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (cn != null) cn.Dispose();
            }
        }
    }
}