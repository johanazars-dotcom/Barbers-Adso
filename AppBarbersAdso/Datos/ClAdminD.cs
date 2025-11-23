using AppBarbersAdso.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppBarbersAdso.Datos
{
    public class ClAdminD
    {
        ClConexion conexion = new ClConexion();
        public ClAdminM MtLoginAdmin(string user, string pass)
        {
            SqlConnection conex = conexion.MtabrirConexion();

            string consulta = $"select * from administrador where email = @user and contraseña = @pass";

            SqlCommand cmd = new SqlCommand(consulta, conex);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            SqlDataReader lea = cmd.ExecuteReader();

            ClAdminM admin = null;

            if (lea.Read())
            {
                admin = new ClAdminM();
                admin.email = lea["email"].ToString();
                admin.contraseña = lea["contraseña"].ToString();
            }

            conexion.MtcerrarConexion();

            return admin;
        }
        public List<ClBarberoM> ListarBarberos()
        {
            List<ClBarberoM> lista = new List<ClBarberoM>();
            SqlConnection cn = conexion.MtabrirConexion();

            string sql = @"SELECT 
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
                   INNER JOIN puesto p ON b.idPuesto = p.idPuesto";

            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader listar = cmd.ExecuteReader();

            while (listar.Read())
            {
                lista.Add(new ClBarberoM()
                {
                    idBarbero = int.Parse(listar["idBarbero"].ToString()),
                    nombreBarbero = listar["nombreBarbero"].ToString(),
                    apellidoBarbero = listar["apellidoBarbero"].ToString(),
                    documento = listar["documento"].ToString(),
                    email = listar["email"].ToString(),
                    contraseña = listar["contraseña"].ToString(),
                    foto = listar["foto"].ToString(),
                    hojaVida = listar["hojaVida"].ToString(),
                    telefono = listar["telefono"].ToString(),
                    idPuesto = int.Parse(listar["idPuesto"].ToString()),
                    numeroPuesto = listar["numeroPuesto"].ToString()
                });
            }

            conexion.MtcerrarConexion();
            return lista;
        }
    }
}