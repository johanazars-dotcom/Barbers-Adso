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
        public void MtActualizarBarberoPorIdL(ClBarberoM datos)
        {
            ClBarberoD d = new ClBarberoD();
            d.MtActualizarBarberoPorId(datos);
        }
        public ClBarberoM MtObtenerBarberoPorIdL(int id)
        {
            ClBarberoD datos = new ClBarberoD();
            return datos.MtObtenerBarberoPorId(id);
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
            return "ha ocurrido un error";
        }

    }
}