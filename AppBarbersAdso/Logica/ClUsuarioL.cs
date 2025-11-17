using AppBarbersAdso.Datos;
using AppBarbersAdso.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
		public string MtRegitroUsuario(ClUsuarioM usuario)
		{
			ClUsuarioD usuariodatos = new ClUsuarioD();
			usuariodatos.MtRegistrarUsuario(usuario);
			return "Su usuario ha sido registrado exitosamente";
		}
        
        ClUsuarioD datos = new ClUsuarioD();


        public bool EnviarToken(string correo)
        {
            var user = datos.ObtenerUsuarioPorCorreo(correo);
            if (user == null)
                return false;


            string token = Guid.NewGuid().ToString();
            DateTime expira = DateTime.Now.AddMinutes(15);


            datos.GuardarToken(user.idUsuario, token, expira);


            return enviarCorreoRecuperacion(correo, token);
        }


        private bool enviarCorreoRecuperacion(string correo, string token)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("jhonale19pr@gmail.com");
                mail.To.Add(correo);
                mail.Subject = "Restablecimiento de contraseña";
                mail.Body = $"Tu token es: {token}\nVence en 15 minutos.";


                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("jhonale19pr@gmail.com", "mahz owcn glwx yxf");
                smtp.Send(mail);


                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool RestablecerContrasena(string token, string nuevaPass)
        {
            return datos.ActualizarContraseñaToken(token, nuevaPass);
        }

    }
}