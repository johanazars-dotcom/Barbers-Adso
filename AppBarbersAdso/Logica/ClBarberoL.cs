using AppBarbersAdso.Datos;
using AppBarbersAdso.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarbersAdso.Logica
{
	public class ClBarberoL
	{
        public bool MtLoginBarberoL(string email, string contra)
        {
            ClBarberoD oUsuarioD = new ClBarberoD();
            ClBarberoM oDatos = oUsuarioD.MtLoginBarbero(email, contra);

            if (oDatos != null)
            {
                HttpContext.Current.Session["usuarioLogueado"] = oDatos;
                return true;
            }

            return false;
        }
        public string MtActualizarPerfilBarberoL(ClBarberoM barbero)
        {
            ClBarberoD oBarberoD = new ClBarberoD();
            oBarberoD.MtActualizarPerfilBarbero(barbero);
            return "Datos actualizados correctamente.";
        }
    }
}