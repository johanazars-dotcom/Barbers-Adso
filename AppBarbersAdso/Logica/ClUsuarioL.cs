using AppBarbersAdso.Datos;
using AppBarbersAdso.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarbersAdso.Logica
{
	public class ClUsuarioL
	{
		public bool MtLoginL(string email, string contra)
		{
			ClUsuarioD oUsuarioD = new ClUsuarioD();
			ClUsuarioM oDatos = oUsuarioD.MtLogin(email, contra);

			if (oDatos != null)
			{
				HttpContext.Current.Session["usuarioLogueado"] = oDatos.email;
				return true;
			}

			return false;
		}
    }
}