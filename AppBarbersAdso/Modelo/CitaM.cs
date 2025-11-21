using System;

namespace Modelos
{
    public class CitaM
    {
        public int idCita { get; set; }
        public int idUsuario { get; set; }
        public int idBarbero { get; set; }
        public int idPuesto { get; set; }
        public DateTime fechaCita { get; set; }
        public string hora { get; set; }
        public int idEstado { get; set; }
    }
}
