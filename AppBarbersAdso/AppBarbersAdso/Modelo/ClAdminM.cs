using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarbersAdso.Modelo
{
	public class ClAdminM
	{
        public int idAdministrador { get; set; }
        public string nombreAdministrador { get; set; }
        public string apellidoAdministrador { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string telefono { get; set; }
    }
}