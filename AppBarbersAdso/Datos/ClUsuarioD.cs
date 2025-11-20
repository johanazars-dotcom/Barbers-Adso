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

            cmd.Parameters.AddWithValue("@nombre", actualizar.nombre);
            cmd.Parameters.AddWithValue("@apellido", actualizar.apellido);
            cmd.Parameters.AddWithValue("@documento", actualizar.documento);
            cmd.Parameters.AddWithValue("@email", actualizar.email);
            cmd.Parameters.AddWithValue("@contraseña", actualizar.contraseña);
            cmd.Parameters.AddWithValue("@telefono", actualizar.telefono);

            cmd.ExecuteNonQuery();

            conexion.MtcerrarConexion();
        }
        public ClUsuarioM MtObtenerUsuario(string email)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = "select * from usuario where email = @correo";
            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@correo", email);

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

            lea.Close();

            conexion.MtcerrarConexion();
            return usuario;
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
        public string MtRegistrarUsuario(ClUsuarioM datos)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consultaExiste = "select count(*) from usuario where email = @correo";
            SqlCommand cmdExiste = new SqlCommand(consultaExiste, conex);
            cmdExiste.Parameters.AddWithValue("@correo", datos.email);

            int existe = (int)cmdExiste.ExecuteScalar();

            if (existe > 0)
            {
                conexion.MtcerrarConexion();
                return "duplicado";
            }


            string consulta = "insert into usuario (nombre, apellido, documento, email, contraseña, telefono) " + "values (@nom, @ape, @docu, @email, @contra, @tel)";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@nom", datos.nombre);
            cmd.Parameters.AddWithValue("@ape", datos.apellido);
            cmd.Parameters.AddWithValue("@docu", datos.documento);
            cmd.Parameters.AddWithValue("@email", datos.email);
            cmd.Parameters.AddWithValue("@contra", datos.contraseña);
            cmd.Parameters.AddWithValue("@tel", datos.telefono);

            cmd.ExecuteNonQuery();
            conexion.MtcerrarConexion();

            return "ok";
        }
        public ClUsuarioM ObtenerUsuarioPorCorreo(string email)
        {
            string cadena = "Data Source=JHON\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;Integrated Security=True;Encrypt=False;";
            SqlConnection conexx = conexion.MtabrirConexion();
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuario WHERE email=@email", conn);
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
            string cadena = "Data Source=JHON\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;Integrated Security=True;Encrypt=False;";
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                "UPDATE usuario SET tokenRecuperacion=@token, tokenExpira=@exp WHERE idUsuario=@id", conn);


                cmd.Parameters.AddWithValue("@token", token);
                cmd.Parameters.AddWithValue("@exp", expira);
                cmd.Parameters.AddWithValue("@id", idUsuario);


                cmd.ExecuteNonQuery();
            }
        }


        public bool ActualizarContraseñaToken(string token, string nuevaPass)
        {
            string cadena = "Data Source=JHON\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;Integrated Security=True;Encrypt=False;";
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                "UPDATE usuario SET contraseña=@pass, tokenRecuperacion=NULL, tokenExpira=NULL " +
                "WHERE tokenRecuperacion=@token AND tokenExpira > GETDATE()", conn);


                cmd.Parameters.AddWithValue("@pass", nuevaPass);
                cmd.Parameters.AddWithValue("@token", token);


                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}