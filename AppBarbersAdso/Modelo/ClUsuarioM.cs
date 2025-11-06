using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarbersAdso.Modelo
{
	public class ClUsuarioM
	{
		public int idUsuario { get; set; }
		public string nombre { get; set; }
		public string apellido { get; set; }
		public int documento { get; set; }
		public string email { get; set; }
		public string contraseña { get; set; }
		public string telefono { get; set; }
	}
}