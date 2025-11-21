using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Modelos;

namespace Datos
{
    // Usamos el nombre CitaD, ya que maneja la tabla 'cita'.
    public class CitaD
    {
        private readonly string cadenaConexion = "Data Source=DESKTOP-MUT4LN4\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;Integrated Security=True;";

        // Método para listar todas las citas (CRUD Read)
        public List<CitaM> Listar()
        {
            var lista = new List<CitaM>();
            SqlConnection cn = null;
            SqlDataReader dr = null;

            try
            {
                cn = new SqlConnection(cadenaConexion);
                // SELECT con nombres de columna corregidos (usando 'fecha', sin 'idEstado')
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
                        fechaCita = Convert.ToDateTime(dr["fecha"]), // Usando 'fecha' de la DB
                        hora = dr["hora"].ToString(),
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

        // Método para obtener citas por Usuario (Historial)
        public List<CitaM> ObtenerHistorial(int idUsuario)
        {
            List<CitaM> lista = new List<CitaM>();
            SqlConnection conexion = null;
            SqlDataReader lector = null;

            try
            {
                conexion = new SqlConnection(cadenaConexion);

                // Consulta para obtener citas de un usuario específico
                string consulta =
                    "SELECT idCita, idUsuario, idBarbero, idPuesto, fecha, hora FROM Cita WHERE idUsuario = @IdUsuario";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    lista.Add(new CitaM
                    {
                        idCita = Convert.ToInt32(lector["idCita"]),
                        idUsuario = Convert.ToInt32(lector["idUsuario"]),
                        idBarbero = Convert.ToInt32(lector["idBarbero"]),
                        idPuesto = Convert.ToInt32(lector["idPuesto"]),
                        fechaCita = Convert.ToDateTime(lector["fecha"]), // Usando 'fecha'
                        hora = lector["hora"].ToString(),
                    });
                }
            }
            finally
            {
                if (lector != null) lector.Dispose();
                if (conexion != null) conexion.Dispose();
            }

            return lista;
        }

        // Método para guardar (Insert/Update)
        public void Guardar(CitaM c)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;

            try
            {
                cn = new SqlConnection(cadenaConexion);

                if (c.idCita == 0)
                {
                    // INSERT sin la columna de estado
                    cmd = new SqlCommand(
                        "INSERT INTO cita (idUsuario, idBarbero, idPuesto, fecha, hora) " +
                        "VALUES (@idUsuario, @idBarbero, @idPuesto, @fecha, @hora)", cn);
                }
                else
                {
                    // UPDATE sin la columna de estado
                    cmd = new SqlCommand(
                        "UPDATE cita SET idUsuario=@idUsuario, idBarbero=@idBarbero, idPuesto=@idPuesto, fecha=@fecha, hora=@hora " +
                        "WHERE idCita=@id", cn);
                    cmd.Parameters.AddWithValue("@id", c.idCita);
                }

                cmd.Parameters.AddWithValue("@idUsuario", c.idUsuario);
                cmd.Parameters.AddWithValue("@idBarbero", c.idBarbero);
                cmd.Parameters.AddWithValue("@idPuesto", c.idPuesto);
                cmd.Parameters.AddWithValue("@fecha", c.fechaCita);
                cmd.Parameters.AddWithValue("@hora", c.hora);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (cn != null) cn.Dispose();
            }
        }

        // Método para eliminar
        public void Eliminar(int id)
        {
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