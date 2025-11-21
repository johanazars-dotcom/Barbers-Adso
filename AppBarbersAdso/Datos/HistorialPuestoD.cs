using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

// Asume que este es el namespace de tu capa de datos
namespace AppBarbersAdso.Datos
{
    public class HistorialPuestoD
    {
        // 1. Cadena de Conexión declarada como constante o readonly
        private const string cadenaConexion = "Data Source=DESKTOP-MUT4LN4\\SQLEXPRESS;Initial Catalog=dbBarbersAdso;Integrated Security=True;";

        public List<HistorialPuestoM> ObtenerHistorialPorPuesto(int idPuesto)
        {
            List<HistorialPuestoM> lista = new List<HistorialPuestoM>();

            // 2. USO DE 'USING': Garantiza que la conexión se cierre y libere automáticamente.
            using (SqlConnection conex = new SqlConnection(cadenaConexion))
            {
                // Consulta corregida: usa 'fecha', sin 'idEstado', filtrando por idPuesto
                string consulta = "SELECT idCita, idUsuario, idBarbero, idPuesto, hora, fecha FROM cita WHERE idPuesto = @idPuesto";

                using (SqlCommand cmd = new SqlCommand(consulta, conex))
                {
                    cmd.Parameters.AddWithValue("@idPuesto", idPuesto);

                    try
                    {
                        conex.Open();

                        // 3. USO DE 'USING' para SqlDataReader: Garantiza que el lector se cierre.
                        using (SqlDataReader lector = cmd.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                lista.Add(new HistorialPuestoM
                                {
                                    idCita = Convert.ToInt32(lector["idCita"]),
                                    idUsuario = Convert.ToInt32(lector["idUsuario"]),
                                    idBarbero = Convert.ToInt32(lector["idBarbero"]),
                                    idPuesto = Convert.ToInt32(lector["idPuesto"]),
                                    hora = lector["hora"].ToString(),
                                    fechaCita = Convert.ToDateTime(lector["fecha"]) // Columna 'fecha'
                                });
                            }
                        } // El lector se cierra aquí automáticamente
                    }
                    catch (Exception ex)
                    {
                        // Manejar el error (por ejemplo, registrarlo o relanzarlo)
                        // Console.WriteLine(ex.Message); 
                        throw new Exception("Error al obtener historial por puesto: " + ex.Message, ex);
                    }
                } // El comando se libera aquí automáticamente
            } // La conexión se cierra y libera aquí automáticamente

            return lista;
        }
    }
}