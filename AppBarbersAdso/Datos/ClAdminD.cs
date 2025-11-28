using AppBarbersAdso.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
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


        public List<clContrato> ListarContratosPorBarbero()
        {
            List<clContrato> lista = new List<clContrato>();

            SqlConnection cn = conexion.MtabrirConexion();

            string sql = @"
                SELECT 
                    
                    ISNULL(c.idContrato, 0)                  AS idContrato,
                    ISNULL(c.estado, 'Sin contrato')         AS estadoContrato,
                    
                    ISNULL(c.tipoContrato, 'N/A')            AS tipoContrato,

                    
                    b.nombreBarbero,
                    b.ApellidoBarbero,
                    p.numeroPuesto
                FROM barbero b
                INNER JOIN puesto p 
                    ON b.idPuesto = p.idPuesto
                LEFT JOIN contrato c
                    ON c.idPuesto = p.idPuesto; 
            ";

            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                clContrato item = new clContrato();

                item.idContrato = Convert.ToInt32(dr["idContrato"]);
                item.estadoContrato = dr["estadoContrato"].ToString();

                
                item.tipoContrato = dr["tipoContrato"].ToString();

                item.nombreBarbero = dr["nombreBarbero"].ToString();
                item.apellidoBarbero = dr["ApellidoBarbero"].ToString();
                item.numeroPuesto = dr["numeroPuesto"].ToString();

                lista.Add(item);
            }

            dr.Close();
            conexion.MtcerrarConexion();
            return lista;
        }
        public string ObtenerUltimoPagoContrato(int idContrato)
        {
            
            if (idContrato <= 0)
                return "Sin pagos";

            SqlConnection cn = conexion.MtabrirConexion();

            string sql = @"
                SELECT TOP 1 pago
                FROM finanza
                WHERE idContrato = @idContrato
                ORDER BY idFinanzas DESC";

            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@idContrato", idContrato);

            object result = cmd.ExecuteScalar();
            conexion.MtcerrarConexion();

            if (result == null || result == DBNull.Value)
                return "Sin pagos";

            return result.ToString();
        }
        public DataTable ObtenerPagos()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT idFinanzas, pago, idPuesto, idContrato, idAdministrador FROM finanza",
                conexion.MtabrirConexion()
            );

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            da.Fill(tabla);

            conexion.MtcerrarConexion();
            return tabla;
        }

        public bool RegistrarPago(FinanzaM f)
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO finanza (pago, idPuesto, idContrato, idAdministrador) VALUES (@pago, @idPuesto, @idContrato, @idAdministrador)",
                conexion.MtabrirConexion()
            );

            cmd.Parameters.AddWithValue("@pago", f.Pago);
            cmd.Parameters.AddWithValue("@idPuesto", f.IdPuesto);
            cmd.Parameters.AddWithValue("@idContrato", f.IdContrato);
            cmd.Parameters.AddWithValue("@idAdministrador", f.IdAdministrador);

            int filas = cmd.ExecuteNonQuery();
            conexion.MtcerrarConexion();

            return filas > 0;
        }

    }
}