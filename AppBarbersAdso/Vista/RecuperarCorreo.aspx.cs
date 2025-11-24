using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBarbersAdso.Logica;

namespace AppBarbersAdso.Vista
{
    public partial class RecuperarCorreo : System.Web.UI.Page
    {
        ClUsuarioL logica = new ClUsuarioL();

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;

            bool enviado = logica.EnviarToken(correo);

            if (enviado)
            {
                lblMsg.CssClass = "text-success";
                lblMsg.Text = "Te enviamos un enlace para restablecer tu contraseña.";
            }
            else
            {
                lblMsg.CssClass = "text-danger";
                lblMsg.Text = "Ese correo no está registrado.";
            }
        }
    }
}