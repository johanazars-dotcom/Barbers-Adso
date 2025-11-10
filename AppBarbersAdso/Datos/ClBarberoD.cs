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
    }
}