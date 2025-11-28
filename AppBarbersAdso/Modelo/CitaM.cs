using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarbersAdso.Modelo
{
    public class CitaM
    {
        public int idCita { get; set; }
        public int idUsuario { get; set; }
        public int idBarbero { get; set; }
        public int idPuesto { get; set; }
        public DateTime fechaCita { get; set; }
        public string hora { get; set; }
        public string nombreUsuario { get; set; }
        public string nombreBarbero { get; set; }
        public string nombrePuesto { get; set; }
        public bool ocultarCliente { get; set; }
    }
}