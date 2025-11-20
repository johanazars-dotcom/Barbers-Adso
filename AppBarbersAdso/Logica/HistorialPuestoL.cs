using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica
{
    public class HistorialPuestoL
    {
        private Datos.HistorialPuestoD datos = new Datos.HistorialPuestoD();

        public System.Collections.Generic.List<Modelos.HistorialPuestoM> ListarHistorial(int idPuesto)
        {
            return datos.ObtenerHistorialPorPuesto(idPuesto);
        }
    }
}
