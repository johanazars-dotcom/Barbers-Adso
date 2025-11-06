using AppBarbersAdso.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppBarbersAdso.Datos
{
	public class ClUsuarioD
	{
		ClConexion conexion = new ClConexion();
		public void MtActualizarPerfil(ClUsuarioM actualizar)
		{
			SqlConnection conex = conexion.MtabrirConexion();

			string consulta = "update usuario " + "set nombre = @nombre, apellido = @apellido, documento = @documento,email = @email, contraseña = @contraseña, telefono = @telefono " + "where email = @email AND contraseña = @contraseña";
			SqlCommand cmd = new SqlCommand(consulta, conex);

			cmd.Parameters.AddWithValue("@nombre",actualizar.nombre);
            cmd.Parameters.AddWithValue("@apellido",actualizar.apellido);
            cmd.Parameters.AddWithValue("@documento",actualizar.documento);
            cmd.Parameters.AddWithValue("@email",actualizar.email);
            cmd.Parameters.AddWithValue("@contraseña",actualizar.contraseña);
            cmd.Parameters.AddWithValue("@telefono",actualizar.telefono);

			cmd.ExecuteNonQuery();

			conexion.MtcerrarConexion();


        }
		public ClUsuarioM MtLogin(string user, string pass)
		{
			SqlConnection conex = conexion.MtabrirConexion();

			string consulta = $"select * from usuario where email = @user and contraseña = @pass";

			SqlCommand cmd = new SqlCommand(consulta, conex);
			cmd.Parameters.AddWithValue("@user", user);
			cmd.Parameters.AddWithValue("@pass", pass);

			SqlDataReader lea = cmd.ExecuteReader();

			ClUsuarioM usuario = null;

			if (lea.Read())
			{
				usuario = new ClUsuarioM();
				usuario.nombre = lea["nombre"].ToString();
				usuario.apellido = lea["apellido"].ToString();
				usuario.documento = lea["documento"].ToString();
				usuario.email = lea["email"].ToString();
				usuario.contraseña = lea["contraseña"].ToString();
				usuario.telefono = lea["telefono"].ToString();
			}

			conexion.MtcerrarConexion();

			return usuario;
		}
	}
}