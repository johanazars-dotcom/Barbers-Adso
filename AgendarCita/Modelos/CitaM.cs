using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelos
{
    public class CitaM
    {
        public int idCita { get; set; }
        public string nombreCliente { get; set; }
        public DateTime fechaCita { get; set; }
        public string hora { get; set; }
    }
}
