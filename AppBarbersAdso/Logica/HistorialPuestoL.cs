using AppBarbersAdso.Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica
{
    public class HistorialPuestoL
    {
        private HistorialPuestoD datos = new HistorialPuestoD();
        public List<HistorialPuestoM> ListarHistorial(int idPuesto)
        {
            return datos.ObtenerHistorialPorPuesto(idPuesto);
        }

    }
}
