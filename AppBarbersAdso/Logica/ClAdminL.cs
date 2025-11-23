using AppBarbersAdso.Datos;
using AppBarbersAdso.Modelo;
using System;
using System.Collections.Generic;
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
    }
}