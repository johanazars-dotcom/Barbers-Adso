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

            string consulta = "UPDATE usuario " +
                              "SET nombre = @nombre, apellido = @apellido, documento = @documento, email = @correo, contraseña = @contraseña, telefono = @telefono " +
                              "WHERE email = @correo";

            SqlCommand cmd = new SqlCommand(consulta, conex);

            cmd.Parameters.AddWithValue("@nombre", actualizar.nombre.Trim());
            cmd.Parameters.AddWithValue("@apellido", actualizar.apellido.Trim());
            cmd.Parameters.AddWithValue("@documento", actualizar.documento.Trim());
            cmd.Parameters.AddWithValue("@correo", actualizar.email.Trim());
            cmd.Parameters.AddWithValue("@contraseña", actualizar.contraseña.Trim());
            cmd.Parameters.AddWithValue("@telefono", actualizar.telefono.Trim());

            cmd.ExecuteNonQuery();
            conexion.MtcerrarConexion();
        }

        public ClUsuarioM MtObtenerUsuario(string email)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = "SELECT * FROM usuario WHERE email = @correo";
            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@correo", email.Trim());

            SqlDataReader lea = cmd.ExecuteReader();

            ClUsuarioM usuario = null;

            if (lea.Read())
            {
                usuario = new ClUsuarioM
                {
                    nombre = lea["nombre"].ToString(),
                    apellido = lea["apellido"].ToString(),
                    documento = lea["documento"].ToString(),
                    email = lea["email"].ToString(),
                    contraseña = lea["contraseña"].ToString(),
                    telefono = lea["telefono"].ToString()
                };
            }

            lea.Close();
            conexion.MtcerrarConexion();
            return usuario;
        }

   
        public ClUsuarioM MtLogin(string user, string pass)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = "SELECT * FROM usuario WHERE email = @user AND contraseña = @pass";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@user", user.Trim());
            cmd.Parameters.AddWithValue("@pass", pass.Trim());

            SqlDataReader lea = cmd.ExecuteReader();

            ClUsuarioM usuario = null;

            if (lea.Read())
            {
                usuario = new ClUsuarioM
                {
                    idUsuario = Convert.ToInt32(lea["idUsuario"]),
                    nombre = lea["nombre"].ToString(),
                    apellido = lea["apellido"].ToString(),
                    documento = lea["documento"].ToString(),
                    email = lea["email"].ToString(),
                    contraseña = lea["contraseña"].ToString(),
                    telefono = lea["telefono"].ToString()
                };
            }

            lea.Close();
            conexion.MtcerrarConexion();
            return usuario;
        }

  
        public string MtRegistrarUsuario(ClUsuarioM datos)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consultaExiste = "SELECT COUNT(*) FROM usuario WHERE email = @correo";
            SqlCommand cmdExiste = new SqlCommand(consultaExiste, conex);
            cmdExiste.Parameters.AddWithValue("@correo", datos.email.Trim());

            int existe = (int)cmdExiste.ExecuteScalar();

            if (existe > 0)
            {
                conexion.MtcerrarConexion();
                return "duplicado";
            }

            string consulta = "INSERT INTO usuario (nombre, apellido, documento, email, contraseña, telefono) " +
                              "VALUES (@nom, @ape, @docu, @correo, @contra, @tel)";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@nom", datos.nombre.Trim());
            cmd.Parameters.AddWithValue("@ape", datos.apellido.Trim());
            cmd.Parameters.AddWithValue("@docu", datos.documento.Trim());
            cmd.Parameters.AddWithValue("@correo", datos.email.Trim());
            cmd.Parameters.AddWithValue("@contra", datos.contraseña.Trim());
            cmd.Parameters.AddWithValue("@tel", datos.telefono.Trim());

            cmd.ExecuteNonQuery();
            conexion.MtcerrarConexion();

            return "ok";
        }

  
        public ClUsuarioM ObtenerUsuarioPorCorreo(string email)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = "SELECT * FROM usuario WHERE email=@correo";
            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@correo", email.Trim());

            SqlDataReader dr = cmd.ExecuteReader();

            ClUsuarioM usuario = null;

            if (dr.Read())
            {
                usuario = new ClUsuarioM
                {
                    idUsuario = Convert.ToInt32(dr["idUsuario"]),
                    nombre = dr["nombre"].ToString(),
                    apellido = dr["apellido"].ToString(),
                    documento = dr["documento"].ToString(),
                    email = dr["email"].ToString(),
                    contraseña = dr["contraseña"].ToString(),
                    telefono = dr["telefono"].ToString(),
                    TokenRecuperacion = dr["tokenRecuperacion"].ToString()
                };
            }

            dr.Close();
            conexion.MtcerrarConexion();
            return usuario;
        }

 
        public void GuardarToken(int idUsuario, string token)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = "UPDATE usuario SET tokenRecuperacion=@token WHERE idUsuario=@id";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@token", token.Trim());
            cmd.Parameters.AddWithValue("@id", idUsuario);

            cmd.ExecuteNonQuery();
            conexion.MtcerrarConexion();
        }

      
        public bool ActualizarContraseñaToken(string token, string nuevaPass)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = @"UPDATE usuario 
                                SET contraseña=@pass, tokenRecuperacion=NULL
                                WHERE tokenRecuperacion=@token";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@pass", nuevaPass.Trim());
            cmd.Parameters.AddWithValue("@token", token.Trim());

            bool actualizado = cmd.ExecuteNonQuery() > 0;

            conexion.MtcerrarConexion();
            return actualizado;
        }
    }
}    
