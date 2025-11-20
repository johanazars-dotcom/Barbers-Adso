using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelos
{
    public class HistorialPuestoM
    {
        public int IdCita { get; set; }
        public int IdUsuario { get; set; }
        public int IdBarbero { get; set; }
        public int IdPuesto { get; set; }
        public string Hora { get; set; }
        public string FechaCita { get; set; }
        public int IdEstado { get; set; }
    }
}
