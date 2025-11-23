using AppBarbersAdso.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppBarbersAdso.Datos
{
    public class ClBarberoD
    {
        ClConexion conexion = new ClConexion();
        public ClBarberoM MtLoginBarbero(string user, string pass)
        {
            SqlConnection conex = conexion.MtabrirConexion();
            string consulta = @"select b.*, p.numeroPuesto from barbero b INNER JOIN puesto p ON b.idPuesto = p.idPuesto where b.email = @user AND b.contraseña = @pass";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            SqlDataReader lea = cmd.ExecuteReader();

            ClBarberoM barbero = null;

            if (lea.Read())
            {
                barbero = new ClBarberoM();
                barbero.idBarbero = Convert.ToInt32(lea["idBarbero"]);
                barbero.nombreBarbero = lea["nombreBarbero"].ToString();
                barbero.apellidoBarbero = lea["apellidoBarbero"].ToString();
                barbero.email = lea["email"].ToString();
                barbero.idPuesto = Convert.ToInt32(lea["idPuesto"]);
                barbero.numeroPuesto = lea["numeroPuesto"].ToString();
            }

            conexion.MtcerrarConexion();
            return barbero;
        }
        public void MtActualizarBarberoPorId(ClBarberoM datos)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = @"
        UPDATE barbero SET
            nombreBarbero = @nombre,
            apellidoBarbero = @apellido,
            documento = @documento,
            email = @correo,
            contraseña = @contra,
            telefono = @telefono,
            idPuesto = @puesto
        WHERE idBarbero = @id";

            SqlCommand cmd = new SqlCommand(consulta, conex);

            cmd.Parameters.AddWithValue("@id", datos.idBarbero);
            cmd.Parameters.AddWithValue("@nombre", datos.nombreBarbero);
            cmd.Parameters.AddWithValue("@apellido", datos.apellidoBarbero);
            cmd.Parameters.AddWithValue("@documento", datos.documento);
            cmd.Parameters.AddWithValue("@correo", datos.email);
            cmd.Parameters.AddWithValue("@contra", datos.contraseña);
            cmd.Parameters.AddWithValue("@telefono", datos.telefono);
            cmd.Parameters.AddWithValue("@puesto", datos.idPuesto);

            cmd.ExecuteNonQuery();
            conex.Close();
        }

        public string MtRegistrarBarbero(ClBarberoM datos)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consultaExiste = "select count(*) from barbero where email = @correo";
            SqlCommand cmdExiste = new SqlCommand(consultaExiste, conex);
            cmdExiste.Parameters.AddWithValue("@correo", datos.email);

            int existe = (int)cmdExiste.ExecuteScalar();

            if (existe > 0)
            {
                conexion.MtcerrarConexion();
                return "duplicado";
            }

            string consulta = @"insert into barbero (nombreBarbero, apellidoBarbero, documento, email, contraseña, foto, hojaVida, telefono, idPuesto) values (@nom, @ape, @docu, @correo, @contra, @foto, @hoja, @tel, @puesto)";

            SqlCommand cmd = new SqlCommand(consulta, conex);

            cmd.Parameters.AddWithValue("@nom", datos.nombreBarbero);
            cmd.Parameters.AddWithValue("@ape", datos.apellidoBarbero);
            cmd.Parameters.AddWithValue("@docu", datos.documento);
            cmd.Parameters.AddWithValue("@correo", datos.email);
            cmd.Parameters.AddWithValue("@contra", datos.contraseña);
            cmd.Parameters.AddWithValue("@foto", datos.foto);
            cmd.Parameters.AddWithValue("@hoja", datos.hojaVida);
            cmd.Parameters.AddWithValue("@tel", datos.telefono);
            cmd.Parameters.AddWithValue("@puesto", datos.idPuesto);
            cmd.ExecuteNonQuery();

            string consultaUpdate = "UPDATE puesto SET estado = 'Ocupado' WHERE idPuesto = @puesto";
            SqlCommand cmd2 = new SqlCommand(consultaUpdate, conex);
            cmd2.Parameters.AddWithValue("@puesto", datos.idPuesto);
            cmd2.ExecuteNonQuery();

            conexion.MtcerrarConexion();
            return "ok";
        }
        public ClBarberoM MtObtenerBarberoPorId(int id)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = @"
        SELECT 
            b.idBarbero,
            b.nombreBarbero,
            b.apellidoBarbero,
            b.documento,
            b.email,
            b.contraseña,
            b.foto,
            b.hojaVida,
            b.telefono,
            b.idPuesto,
            p.numeroPuesto
        FROM barbero b
        INNER JOIN puesto p ON b.idPuesto = p.idPuesto
        WHERE b.idBarbero = @id";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = cmd.ExecuteReader();

            ClBarberoM bar = null;

            if (dr.Read())
            {
                bar = new ClBarberoM()
                {
                    idBarbero = Convert.ToInt32(dr["idBarbero"]),
                    nombreBarbero = dr["nombreBarbero"].ToString(),
                    apellidoBarbero = dr["apellidoBarbero"].ToString(),
                    documento = dr["documento"].ToString(),
                    email = dr["email"].ToString(),
                    contraseña = dr["contraseña"].ToString(),
                    foto = dr["foto"].ToString(),
                    hojaVida = dr["hojaVida"].ToString(),
                    telefono = dr["telefono"].ToString(),
                    idPuesto = Convert.ToInt32(dr["idPuesto"]),
                    numeroPuesto = dr["numeroPuesto"].ToString()
                };
            }

            dr.Close();
            conexion.MtcerrarConexion();

            return bar;
        }
    }
}