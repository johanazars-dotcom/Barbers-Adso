using AppBarbersAdso.Datos;
using AppBarbersAdso.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AppBarbersAdso.Logica
{
    public class ClAdminL
    {
        public bool MtLoginAdminL(string email, string contra)
        {
            ClAdminD oAdminD = new ClAdminD();
            ClAdminM oDatos = oAdminD.MtLoginAdmin(email, contra);

            if (oDatos != null)
            {
                HttpContext.Current.Session["usuarioLogueado"] = oDatos;
                return true;
            }

            return false;
        }
        public ClAdminM MtLoginAdmin_GetObject(string email, string contra)
        {
            ClAdminD oAdminD = new ClAdminD();
            ClAdminM admin = oAdminD.MtLoginAdmin(email, contra);

            return admin; // Puede ser null si no existe
        }

        public List<ClBarberoM> ListarBarberosL()
        {
            ClAdminD datos = new ClAdminD();
            return datos.ListarBarberos();
        }
        public List<clContrato> ListarContratosPorBarberoL()
        {
            ClAdminD datos = new ClAdminD();
            List<clContrato> lista = datos.ListarContratosPorBarbero();

            // completar el último pago para cada contrato
            foreach (clContrato item in lista)
            {
                item.ultimoPago = datos.ObtenerUltimoPagoContrato(item.idContrato);
            }

            return lista;
        }
        public clContrato ObtenerContratoEditarL(int idContrato)
        {
            ClAdminD datos = new ClAdminD();
            clContrato contrato = datos.ObtenerContratoPorId(idContrato);

            if (contrato != null)
            {
                contrato.ultimoPago = datos.ObtenerUltimoPagoContrato(idContrato);
            }

            return contrato;
        }
        public void ActualizarContratoYUltimoPagoL(int idContrato, string estado, string tipoContrato, string ultimoPago, int idAdmin)
        {
            ClAdminD datos = new ClAdminD();
            datos.ActualizarContrato(idContrato, estado, tipoContrato);
            datos.ActualizarUltimoPagoContrato(idContrato, ultimoPago, idAdmin);
        }
        public void EliminarContratoL(int idContrato)
        {
            ClAdminD datos = new ClAdminD();
            datos.EliminarContrato(idContrato);
        }
        ClAdminD dal = new ClAdminD();

        public DataTable ListarPagos()
        {
            return dal.ObtenerPagos();
        }

        public bool CrearPago(FinanzaM f)
        {
            return dal.RegistrarPago(f);
        }
    }
}