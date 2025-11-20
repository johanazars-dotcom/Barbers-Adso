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
        public ClBarberoM MtObtenerBarberoL(string email)
        {
            ClBarberoD datos = new ClBarberoD();
            return datos.MtObtenerBarbero(email);
        }
        public string MtRegitroBarbero(ClBarberoM barbero)
        {
            ClBarberoD datos = new ClBarberoD();
            string resultado = datos.MtRegistrarBarbero(barbero);

            if (resultado == "duplicado")
            {
                return "el correo ya está registrado";
            }
            if (resultado == "ok")
            {
                return "registro exitoso";
            }
            return resultado;
        }

    }
}