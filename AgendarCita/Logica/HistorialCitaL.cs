using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica
{
    public class HistorialCitaL
    {
        private Datos.HistorialCitaD datos = new Datos.HistorialCitaD();

        public System.Collections.Generic.List<Modelos.HistorialCitaM> ObtenerHistorial(int idUsuario)
        {
            return datos.ObtenerHistorial(idUsuario);
        }
    }
}
