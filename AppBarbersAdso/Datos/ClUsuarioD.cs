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
	}
}