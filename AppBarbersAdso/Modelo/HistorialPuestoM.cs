using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelos
{
    public class HistorialPuestoM
    {
        public int idCita { get; set; }
        public int idUsuario { get; set; }
        public int idBarbero { get; set; }
        public int idPuesto { get; set; }
        public string hora { get; set; }
        public DateTime fechaCita { get; set; } // Mapea a la columna 'fecha'
        // idEstado ha sido omitida
    }
}