// Asume que HistorialPuestoD está en AppBarbersAdso.Datos
using AppBarbersAdso.Datos;
using Modelos;
using System.Collections.Generic;
using Vista;

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