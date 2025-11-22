using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarbersAdso.Modelo
{
	public class ClBarberoM
	{
        public int idBarbero { get; set; }
        public string nombreBarbero { get; set; }
        public string apellidoBarbero { get; set; }
        public string documento { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string foto { get; set; }
        public string hojaVida { get; set; }
        public string telefono { get; set; }
        public int idPuesto { get; set; }
        public string numeroPuesto { get; set; }
    }
}