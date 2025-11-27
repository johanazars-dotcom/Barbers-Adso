using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace Datos
{
    public class CitaD
    {
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-MUT4LN4\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;Integrated Security=True;");

        public List<CitaM> Listar()
        {
            List<CitaM> lista = new List<CitaM>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Cita", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new CitaM
                {
                    idCita = Convert.ToInt32(dr["idCita"]),
                    nombreCliente = dr["nombreCliente"].ToString(),
                    fechaCita = Convert.ToDateTime(dr["fechaCita"]),
                    hora = dr["hora"].ToString()
                });
            }

            cn.Close();
            return lista;
        }

        public void Guardar(CitaM c)
        {
            SqlCommand cmd;

            if (c.idCita == 0)
            {
                cmd = new SqlCommand("INSERT INTO Cita (nombreCliente, fechaCita, hora) VALUES (@nombre, @fecha, @hora)", cn);
            }
            else
            {
                cmd = new SqlCommand("UPDATE Cita SET nombreCliente=@nombre, fechaCita=@fecha, hora=@hora WHERE idCita=@id", cn);
                cmd.Parameters.AddWithValue("@id", c.idCita);
            }

            cmd.Parameters.AddWithValue("@nombre", c.nombreCliente);
            cmd.Parameters.AddWithValue("@fecha", c.fechaCita);
            cmd.Parameters.AddWithValue("@hora", c.hora);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void Eliminar(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Cita WHERE idCita=@id", cn);
            cmd.Parameters.AddWithValue("@id", id);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
