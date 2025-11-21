using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelos
{
    public class CitaM
    {
        public int idCita { get; set; }        // Columna: idCita
        public int idUsuario { get; set; }     // Columna: idUsuario
        public int idBarbero { get; set; }     // Columna: idBarbero
        public int idPuesto { get; set; }      // Columna: idPuesto

        // Corregido a DateTime para manejar la columna 'fecha' (DATE en SQL)
        public DateTime fechaCita { get; set; }

        public string hora { get; set; }       // Columna: hora

        // La propiedad idEstado ha sido eliminada.
    }
}