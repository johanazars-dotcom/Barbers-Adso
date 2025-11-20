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
        public ClUsuarioM MtObtenerUsuarioL(string email)
        {
            ClUsuarioD datos = new ClUsuarioD();
            return datos.MtObtenerUsuario(email);
        }
        public string MtRegitroUsuario(ClUsuarioM usuario)
        {
            ClUsuarioD datos = new ClUsuarioD();
            string resultado = datos.MtRegistrarUsuario(usuario);
            if (resultado==null)
            {
                return "ocurrio un error";
            }
            if (resultado == "duplicado")
            {
                return "El correo ya está registrado.";
            }

            if (resultado == "ok")
            {
                return "Registro exitoso.";
            }

            return "Ocurrió un error inesperado.";
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
        public bool ConfirmacionCorreo(string correo)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("jhonale19pr@gmail.com");
                mail.To.Add(correo);
                mail.Subject = "Envio de correo de confirmacion para creacion de cuenta";
                mail.Body = $"¡Gracias por hacer parte de esta familia BarbersADSO donde tenemos a los mejores Barberos de Colombia! Su link ded confirmacion es el siguiente";


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
    }
}