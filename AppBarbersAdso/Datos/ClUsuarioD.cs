using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarbersAdso.Datos
{
	public class ClUsuarioD
	{
		ClConexion conexion = new ClConexion();
		public void MtActualizarPerfil(string nombre, string apellido, string documento, string email, string telefono)
		{
			conexion.MtabrirConexion();

			string consulta = "update usuario set nombre = @nombre"
		}
	}
}