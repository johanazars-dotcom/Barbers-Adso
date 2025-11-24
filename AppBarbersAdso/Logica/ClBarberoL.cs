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
        ClBarberoD datos = new ClBarberoD();
        public bool EnviarToken(string correo)
        {
            var barber = datos.ObtenerBarberoPorCorreo(correo);
            if (barber == null)
            {
                return false;
            }

            string token = Guid.NewGuid().ToString();

            datos.GuardarToken(barber.idBarbero, token);

            return EnviarCorreoRecuperacion(correo, token);
        }

        private bool EnviarCorreoRecuperacion(string correo, string token)
        {
            try
            {
                
                string tokenSeguro = HttpUtility.UrlEncode(token);

                string url = $"https://localhost:44369/Vista/recuperacionBarbero.aspx?token={tokenSeguro}";  

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("jhonale19pr@gmail.com");
                mail.To.Add(correo);
                mail.Subject = "Recuperación de contraseña";
                mail.Body =
                    "Haz clic en el siguiente enlace para restablecer tu contraseña:\n" +
                    url + "\n\n" +
                    "Este enlace no expira hasta que lo uses.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("jhonale19pr@gmail.com", "hcwh xqbr uwod ysas");
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