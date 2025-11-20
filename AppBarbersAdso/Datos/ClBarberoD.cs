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

            string consulta = $"select * from barbero where email = @user and contraseña = @pass";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            SqlDataReader lea = cmd.ExecuteReader();

            ClBarberoM barbero = null;

            if (lea.Read())
            {
                barbero = new ClBarberoM();
                barbero.email = lea["email"].ToString();
                barbero.contraseña = lea["contraseña"].ToString();
            }

            conexion.MtcerrarConexion();

            return barbero;
        }

        public void MtActualizarPerfilBarbero(ClBarberoM actualizar)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = "update barbero " + "set nombreBarbero = @nombre, apellidoBarbero = @apellido, documento = @documento, email = @email, contraseña = @contraseña, telefono = @telefono " + "where email = @email";
            SqlCommand cmd = new SqlCommand(consulta, conex);

            cmd.Parameters.AddWithValue("@nombre", actualizar.nombreBarbero);
            cmd.Parameters.AddWithValue("@apellido", actualizar.apellidoBarbero);
            cmd.Parameters.AddWithValue("@documento", actualizar.documento);
            cmd.Parameters.AddWithValue("@email", actualizar.email);
            cmd.Parameters.AddWithValue("@contraseña", actualizar.contraseña);
            cmd.Parameters.AddWithValue("@telefono", actualizar.telefono);

            cmd.ExecuteNonQuery();

            conexion.MtcerrarConexion();
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

      
            string consulta = "insert into barbero (nombreBarbero, apellidoBarbero, documento, email, contraseña, foto, hojaVida,  telefono) " + "values (@nom, @ape, @docu, @email, @contra, @foto, @hojaVida, @tel)";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@nom", datos.nombreBarbero);
            cmd.Parameters.AddWithValue("@ape", datos.apellidoBarbero);
            cmd.Parameters.AddWithValue("@docu", datos.documento);
            cmd.Parameters.AddWithValue("@email", datos.email);
            cmd.Parameters.AddWithValue("@contra", datos.contraseña);
            cmd.Parameters.AddWithValue("@foto", datos.foto);
            cmd.Parameters.AddWithValue("@hojaVida", datos.hojaVida);
            cmd.Parameters.AddWithValue("@tel", datos.telefono);

            cmd.ExecuteNonQuery();
            conexion.MtcerrarConexion();

            return "ok";
        }
        public ClBarberoM MtObtenerBarbero(string email)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = "select * from barbero where email = @correo";
            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@correo", email);

            SqlDataReader lea = cmd.ExecuteReader();

            ClBarberoM barbero = null;

            if (lea.Read())
            {
                barbero = new ClBarberoM();
                barbero.nombreBarbero = lea["nombreBarbero"].ToString();
                barbero.apellidoBarbero = lea["apellidoBarbero"].ToString();
                barbero.documento = lea["documento"].ToString();
                barbero.email = lea["email"].ToString();
                barbero.contraseña = lea["contraseña"].ToString();
                barbero.telefono = lea["telefono"].ToString();
            }

            lea.Close();

            conexion.MtcerrarConexion();
            return barbero;
        }
    }
}