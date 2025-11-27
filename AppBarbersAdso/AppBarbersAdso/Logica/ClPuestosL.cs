using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppBarbersAdso.Datos;
using AppBarbersAdso.Modelo;

namespace AppBarbersAdso.Logica
{
    public class ClPuestosL
    {
        public List<ClPuestosM> ListarPuestosDisponiblesL()
        {
            ClPuestosD datos = new ClPuestosD();
            return datos.ListarPuestosDisponibles();
        }

        public void CambiarEstadoPuestoL(int idPuesto, string estado)
        {
            ClPuestosD datos = new ClPuestosD();
            datos.CambiarEstadoPuesto(idPuesto, estado);
        }
        public List<ClPuestosM> ListarPuestosParaEditarL(int idPuestoActual)
        {
            ClPuestosD d = new ClPuestosD();
            return d.ListarPuestosParaEditar(idPuestoActual);
        }
        public List<ClPuestosM> ListarPuestosDisponiblesSoloL()
        {
            ClPuestosD d = new ClPuestosD();
            return d.ListarPuestosDisponiblesSolo();
        }

    }
}
