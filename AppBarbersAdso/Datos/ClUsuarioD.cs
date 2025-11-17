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

			string consulta = "update usuario " + "set nombre = @nombre, apellido = @apellido, documento = @documento,email = @email, contraseña = @contraseña, telefono = @telefono " + "where email = @email";
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
				usuario.email = lea["email"].ToString();
				usuario.contraseña = lea["contraseña"].ToString();
			}

			conexion.MtcerrarConexion();

			return usuario;
		}

		public void MtRegistrarUsuario(ClUsuarioM datos)
		{
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = "insert into Usuarios (nombre, apellido, documento, email, contraseña, telefono) values (@nom, @ape, @docu, @email, @contraseña, @telefono)";

			SqlCommand cmd = new SqlCommand(consulta, conex);
				cmd.Parameters.AddWithValue("@nom", datos.nombre);
				cmd.Parameters.AddWithValue("@ape", datos.apellido);
				cmd.Parameters.AddWithValue("@docu", datos.documento);
				cmd.Parameters.AddWithValue("@email", datos.email);
				cmd.Parameters.AddWithValue("@contraseña", datos.contraseña);
				cmd.Parameters.AddWithValue("@telefono", datos.telefono);

			conexion.MtcerrarConexion();

		}
        public ClUsuarioM ObtenerUsuarioPorCorreo(string email)
        {
            string cadena = "";
            SqlConnection conexx = conexion.MtabrirConexion();
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE email=@email", conn);
                cmd.Parameters.AddWithValue("@email", email);


                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return new ClUsuarioM
                    {
                        idUsuario = Convert.ToInt32(dr["idUsuario"]),
                        email = dr["email"].ToString(),
                        contraseña = dr["contraseña"].ToString(),
                        TokenRecuperacion = dr["tokenRecuperacion"].ToString(),
                        TokenExpira = dr["tokenExpira"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["TokenExpira"])
                    };
                }
                return null;
            }
        }


        public void GuardarToken(int idUsuario, string token, DateTime expira)
        {
            string cadena = "";
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                "UPDATE Usuarios SET TokenRecuperacion=@token, TokenExpira=@exp WHERE IdUsuario=@id", conn);


                cmd.Parameters.AddWithValue("@token", token);
                cmd.Parameters.AddWithValue("@exp", expira);
                cmd.Parameters.AddWithValue("@id", idUsuario);


                cmd.ExecuteNonQuery();
            }
        }


        public bool ActualizarContraseñaToken(string token, string nuevaPass)
        {
            string cadena = "";
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                "UPDATE Usuarios SET Contrasena=@pass, TokenRecuperacion=NULL, TokenExpira=NULL " +
                "WHERE TokenRecuperacion=@token AND TokenExpira > GETDATE()", conn);


                cmd.Parameters.AddWithValue("@pass", nuevaPass);
                cmd.Parameters.AddWithValue("@token", token);


                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}