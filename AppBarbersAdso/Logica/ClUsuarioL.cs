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
        ClUsuarioD datos = new ClUsuarioD();

      
        public bool MtLoginL(string email, string contra)
        {
            email = email.Trim();
            contra = contra.Trim();

            ClUsuarioM oDatos = datos.MtLogin(email, contra);

            if (oDatos != null)
            {
                HttpContext.Current.Session["usuarioLogueado"] = oDatos;
                return true;
            }

            return false;
        }

        
        public string MtActualizarPerfilL(ClUsuarioM usuario)
        {
            usuario.email = usuario.email.Trim();
            usuario.nombre = usuario.nombre.Trim();
            usuario.apellido = usuario.apellido.Trim();
            usuario.documento = usuario.documento.Trim();
            usuario.telefono = usuario.telefono.Trim();

            datos.MtActualizarPerfil(usuario);
            return "Datos actualizados correctamente.";
        }

        public ClUsuarioM MtObtenerUsuarioL(string email)
        {
            return datos.MtObtenerUsuario(email.Trim());
        }

      
        public string MtRegitroUsuario(ClUsuarioM usuario)
        {
            usuario.email = usuario.email.Trim();

            string resultado = datos.MtRegistrarUsuario(usuario);

            if (resultado == "duplicado")
                return "El correo ya está registrado.";

            if (resultado == "ok")
                return "Registro exitoso.";

            return "Ocurrió un error inesperado.";
        }

        
        public bool EnviarToken(string correo)
        {
            correo = correo.Trim();

            var user = datos.ObtenerUsuarioPorCorreo(correo);

            if (user == null)
                return false;

            string token = Guid.NewGuid().ToString().Trim();

            datos.GuardarToken(user.idUsuario, token);

            return EnviarCorreoRecuperacion(correo, token);
        }

        private bool EnviarCorreoRecuperacion(string correo, string token)
        {
            try
            {
                string tokenSeguro = HttpUtility.UrlEncode(token.Trim());

                string url = $"https://localhost:44369/Vista/recuperacion.aspx?token={tokenSeguro}";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("jhonale19pr@gmail.com");
                mail.To.Add(correo.Trim());
                mail.Subject = "Recuperación de contraseña";
                mail.Body =
                    "Haz clic en el siguiente enlace para restablecer tu contraseña:\n\n" +
                    url + "\n\n" +
                    "Este enlace será válido hasta que lo uses.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("jhonale19pr@gmail.com", "dhid mrgg hjxs xsgu");

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
            return datos.ActualizarContraseñaToken(token.Trim(), nuevaPass.Trim());
        }

       
        public bool ConfirmacionCorreo(string correo)
        {
            try
            {
                correo = correo.Trim();

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("jhonale19pr@gmail.com");
                mail.To.Add(correo);
                mail.Subject = "Confirmación de cuenta";
                mail.Body = "¡Gracias por hacer parte de BarbersADSO!";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("jhonale19pr@gmail.com", "dhid mrgg hjxs xsgu");

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

