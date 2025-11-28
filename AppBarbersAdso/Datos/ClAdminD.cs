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
        public void ActualizarContrato(int idContrato, string estado, string tipoContrato)
        {
            SqlConnection cn = conexion.MtabrirConexion();

            string sql = @"UPDATE contrato 
                           SET estado = @estado, tipoContrato = @tipo 
                           WHERE idContrato = @id";

            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@estado", estado);
            cmd.Parameters.AddWithValue("@tipo", tipoContrato);
            cmd.Parameters.AddWithValue("@id", idContrato);

            cmd.ExecuteNonQuery();
            conexion.MtcerrarConexion();
        }
        public void ActualizarUltimoPagoContrato(int idContrato, string pago, int idAdmin)
        {
            SqlConnection cn = conexion.MtabrirConexion();

            // Buscar último registro de finanza para ese contrato
            string sqlBuscar = @"
                SELECT TOP 1 idFinanzas, idPuesto
                FROM finanza
                WHERE idContrato = @idContrato
                ORDER BY idFinanzas DESC";

            SqlCommand cmdBuscar = new SqlCommand(sqlBuscar, cn);
            cmdBuscar.Parameters.AddWithValue("@idContrato", idContrato);

            int idFinanzas = 0;
            int idPuesto = 0;

            using (SqlDataReader dr = cmdBuscar.ExecuteReader())
            {
                if (dr.Read())
                {
                    idFinanzas = Convert.ToInt32(dr["idFinanzas"]);
                    if (dr["idPuesto"] != DBNull.Value)
                        idPuesto = Convert.ToInt32(dr["idPuesto"]);
                }
            }

            if (idFinanzas > 0)
            {
                // Actualizar el último pago existente
                string sqlUpdate = @"
                    UPDATE finanza 
                    SET pago = @pago, idAdministrador = @idAdmin
                    WHERE idFinanzas = @idFinanzas";

                SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, cn);
                cmdUpdate.Parameters.AddWithValue("@pago", pago);
                cmdUpdate.Parameters.AddWithValue("@idAdmin", idAdmin);
                cmdUpdate.Parameters.AddWithValue("@idFinanzas", idFinanzas);
                cmdUpdate.ExecuteNonQuery();
            }
            else
            {
                // No existe pago: creamos uno nuevo
                if (idPuesto == 0)
                {
                    string sqlPuesto = "SELECT idPuesto FROM contrato WHERE idContrato = @idContrato";
                    SqlCommand cmdPuesto = new SqlCommand(sqlPuesto, cn);
                    cmdPuesto.Parameters.AddWithValue("@idContrato", idContrato);
                    object res = cmdPuesto.ExecuteScalar();
                    if (res != null && res != DBNull.Value)
                        idPuesto = Convert.ToInt32(res);
                }

                string sqlInsert = @"
                    INSERT INTO finanza (pago, idPuesto, idContrato, idAdministrador)
                    VALUES (@pago, @idPuesto, @idContrato, @idAdmin)";

                SqlCommand cmdInsert = new SqlCommand(sqlInsert, cn);
                cmdInsert.Parameters.AddWithValue("@pago", pago);
                cmdInsert.Parameters.AddWithValue("@idPuesto", idPuesto);
                cmdInsert.Parameters.AddWithValue("@idContrato", idContrato);
                cmdInsert.Parameters.AddWithValue("@idAdmin", idAdmin);
                cmdInsert.ExecuteNonQuery();
            }

            conexion.MtcerrarConexion();
        }
        public void EliminarContrato(int idContrato)
        {
            SqlConnection cn = conexion.MtabrirConexion();

            // (Opcional) eliminar pagos asociados a ese contrato
            string sqlFin = "DELETE FROM finanza WHERE idContrato = @idContrato";
            SqlCommand cmdFin = new SqlCommand(sqlFin, cn);
            cmdFin.Parameters.AddWithValue("@idContrato", idContrato);
            cmdFin.ExecuteNonQuery();

            // Eliminar contrato
            string sql = "DELETE FROM contrato WHERE idContrato = @idContrato";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@idContrato", idContrato);
            cmd.ExecuteNonQuery();

            conexion.MtcerrarConexion();
        }
        public clContrato ObtenerContratoPorId(int idContrato)
        {
            SqlConnection cn = conexion.MtabrirConexion();

            string sql = @"
                SELECT TOP 1
                    c.idContrato,
                    c.estado,
                    c.tipoContrato,
                    p.numeroPuesto,
                    b.nombreBarbero,
                    b.ApellidoBarbero
                FROM contrato c
                INNER JOIN puesto p ON c.idPuesto = p.idPuesto
                LEFT JOIN barbero b ON b.idPuesto = p.idPuesto
                WHERE c.idContrato = @idContrato";

            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@idContrato", idContrato);

            SqlDataReader dr = cmd.ExecuteReader();
            clContrato item = null;

            if (dr.Read())
            {
                item = new clContrato
                {
                    idContrato = Convert.ToInt32(dr["idContrato"]),
                    estadoContrato = dr["estado"].ToString(),
                    tipoContrato = dr["tipoContrato"].ToString(),
                    numeroPuesto = dr["numeroPuesto"].ToString(),
                    nombreBarbero = dr["nombreBarbero"].ToString(),
                    apellidoBarbero = dr["ApellidoBarbero"].ToString()
                };
            }

            dr.Close();
            conexion.MtcerrarConexion();
            return item;
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