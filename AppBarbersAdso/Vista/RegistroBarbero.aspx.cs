using AppBarbersAdso.Logica;
using AppBarbersAdso.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBarbersAdso.Vista
{
    public partial class RegistroBarbero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string documento = txtDocumento.Text.Trim();

            if (documento == "")
            {
                lblResultado.Text = "El documento es obligatorio.";
                return;
            }

            string rutaFoto = Server.MapPath("~/Vista/foto/");
            string rutaHojaVida = Server.MapPath("~/Vista/hojaVida/");

            string nombreFoto = "";
            string nombrePdf = "";

            if (fuFoto.HasFile)
            {
                string ext = Path.GetExtension(fuFoto.FileName).ToLower();
                int tam = fuFoto.PostedFile.ContentLength;
                int limite = 2000000;

                if (ext != ".jpg" && ext != ".png")
                {
                    lblResultado.Text = "La foto debe ser JPG o PNG.";
                    return;
                }

                if (tam > limite)
                {
                    lblResultado.Text = "La foto no debe superar los 2 MB.";
                    return;
                }

                nombreFoto = documento + ext;
                fuFoto.SaveAs(Path.Combine(rutaFoto, nombreFoto));
            }

            if (fuHojaVida.HasFile)
            {
                string ext = Path.GetExtension(fuHojaVida.FileName).ToLower();
                int tam = fuHojaVida.PostedFile.ContentLength;
                int limite = 5000000;

                if (ext != ".pdf")
                {
                    lblResultado.Text = "La hoja de vida debe ser PDF.";
                    return;
                }

                if (tam > limite)
                {
                    lblResultado.Text = "El PDF no debe superar los 5 MB.";
                    return;
                }

                nombrePdf = documento + ext;
                fuHojaVida.SaveAs(Path.Combine(rutaHojaVida, nombrePdf));
            }

            ClBarberoM registroBarber = new ClBarberoM();

            registroBarber.nombreBarbero = txtNombre.Text;
            registroBarber.apellidoBarbero = txtApellidos.Text;
            registroBarber.documento = documento;
            registroBarber.email = txtEmail.Text;
            registroBarber.contraseña = txtContrasena.Text;
            registroBarber.telefono = txtTelefono.Text;
            registroBarber.foto = nombreFoto;
            registroBarber.hojaVida = nombrePdf;

            ClBarberoL logica = new ClBarberoL();
            string mensaje = logica.MtRegitroBarbero(registroBarber);

            if (mensaje == "duplicado")
            {
                lblResultado.Text = "El correo ya está registrado.";
            }
            else if (mensaje == "ok")
            {
                lblResultado.Text = "Registrado correctamente.";
            }
            
        }
    }

}

