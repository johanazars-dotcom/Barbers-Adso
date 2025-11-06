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
				HttpContext.Current.Session["usuarioLogueado"] = oDatos;
				return true;
			}

			return false;
		}
        public string MtActualizarPerfilL(ClUsuarioM usuario)
        {
            ClUsuarioD oUsuarioD = new ClUsuarioD();
            oUsuarioD.MtActualizarPerfil(usuario);
            return "Datos actualizados correctamente.";
        }

    }
}