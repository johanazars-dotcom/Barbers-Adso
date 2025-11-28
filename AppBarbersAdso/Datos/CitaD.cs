using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AppBarbersAdso.Modelo;

namespace AppBarbersAdso.Datos
{
    public class CitaD
    {

        ClConexion conexion = new ClConexion();

        public List<CitaM> MtListarCitasBarbero(int idBarbero)
        {
            List<CitaM> lista = new List<CitaM>();
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = @"
                SELECT 
                    c.idCita,
                    c.idUsuario,
                    c.idBarbero,
                    c.idPuesto,
                    c.fecha,
                    c.hora,
                    c.ocultarCliente,
                    u.nombre + ' ' + u.apellido AS nombreUsuario,
                    p.numeroPuesto AS nombrePuesto
                FROM cita c
                INNER JOIN usuario u ON u.idUsuario = c.idUsuario
                INNER JOIN puesto p ON p.idPuesto = c.idPuesto
                WHERE c.idBarbero = @idBarbero
                ORDER BY c.fecha, c.hora
            ";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@idBarbero", idBarbero);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new CitaM
                {
                    idCita = Convert.ToInt32(dr["idCita"]),
                    idUsuario = Convert.ToInt32(dr["idUsuario"]),
                    idBarbero = Convert.ToInt32(dr["idBarbero"]),
                    idPuesto = Convert.ToInt32(dr["idPuesto"]),
                    fechaCita = Convert.ToDateTime(dr["fecha"]),
                    hora = dr["hora"].ToString(),
                    ocultarCliente = Convert.ToBoolean(dr["ocultarCliente"]),
                    nombreUsuario = dr["nombreUsuario"].ToString(),
                    nombrePuesto = dr["nombrePuesto"].ToString()
                });
            }

            dr.Close();
            conexion.MtcerrarConexion();
            return lista;
        }


        public List<CitaM> MtListarCitasCliente(int idUsuario)
        {
            List<CitaM> lista = new List<CitaM>();
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = @"
        SELECT 
            c.idCita,
            c.idUsuario,
            c.idBarbero,
            c.idPuesto,
            c.fecha,
            c.hora,
            c.ocultarCliente,
            u.nombre AS nombreUsuario,    -- SOLO NOMBRE
            b.nombreBarbero,
            p.numeroPuesto AS nombrePuesto
        FROM cita c
        INNER JOIN usuario u ON u.idUsuario = c.idUsuario   -- ALIAS CORRECTO
        INNER JOIN barbero b ON b.idBarbero = c.idBarbero
        INNER JOIN puesto p ON p.idPuesto = c.idPuesto
        WHERE c.idUsuario = @idUsuario
          AND c.ocultarCliente = 0
        ORDER BY c.fecha, c.hora
    ";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new CitaM
                {
                    idCita = Convert.ToInt32(dr["idCita"]),
                    idUsuario = Convert.ToInt32(dr["idUsuario"]),
                    idBarbero = Convert.ToInt32(dr["idBarbero"]),
                    idPuesto = Convert.ToInt32(dr["idPuesto"]),
                    fechaCita = Convert.ToDateTime(dr["fecha"]),
                    hora = dr["hora"].ToString(),
                    ocultarCliente = Convert.ToBoolean(dr["ocultarCliente"]),
                    nombreUsuario = dr["nombreUsuario"].ToString(),
                    nombreBarbero = dr["nombreBarbero"].ToString(),
                    nombrePuesto = dr["nombrePuesto"].ToString()
                });
            }

            dr.Close();
            conexion.MtcerrarConexion();

            return lista;
        }



        public void MtGuardarCita(CitaM cita)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta;

            if (cita.idCita == 0)
            {
                consulta = @"INSERT INTO cita 
                             (idUsuario, idBarbero, idPuesto, fecha, hora, ocultarCliente)
                             VALUES (@idUsuario, @idBarbero, @idPuesto, @fecha, @hora, 0)";
            }
            else
            {
                consulta = @"UPDATE cita 
                             SET idUsuario=@idUsuario, 
                                 idBarbero=@idBarbero, 
                                 idPuesto=@idPuesto, 
                                 fecha=@fecha, 
                                 hora=@hora 
                             WHERE idCita=@idCita";
            }

            SqlCommand cmd = new SqlCommand(consulta, conex);

            cmd.Parameters.AddWithValue("@idUsuario", cita.idUsuario);
            cmd.Parameters.AddWithValue("@idBarbero", cita.idBarbero);
            cmd.Parameters.AddWithValue("@idPuesto", cita.idPuesto);
            cmd.Parameters.AddWithValue("@fecha", cita.fechaCita);
            cmd.Parameters.AddWithValue("@hora", cita.hora);

            if (cita.idCita != 0)
            {
                cmd.Parameters.AddWithValue("@idCita", cita.idCita);
            }

            cmd.ExecuteNonQuery();
            conexion.MtcerrarConexion();
        }



        public void MtEliminarCita(int id)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = @"
                UPDATE cita 
                SET ocultarCliente = 1
                WHERE idCita = @id";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conexion.MtcerrarConexion();
        }


  
        public bool BarberoOcupado(int idBarbero, DateTime fecha, string hora)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = @"SELECT COUNT(*) 
                                FROM cita 
                                WHERE idBarbero=@idBarbero 
                                  AND fecha=@fecha 
                                  AND hora=@hora
                                  AND ocultarCliente = 0";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@idBarbero", idBarbero);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.Parameters.AddWithValue("@hora", hora);

            int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
            conexion.MtcerrarConexion();

            return cantidad > 0;
        }
    }
}


