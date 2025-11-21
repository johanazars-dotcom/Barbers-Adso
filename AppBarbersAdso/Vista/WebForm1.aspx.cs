using AppBarbersAdso.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBarbersAdso.Vista
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtContra.Text))
            {
                lblMensaje.Text = "Debes llenar todos los campos.";
                return;
            }

            ClUsuarioL logica = new ClUsuarioL();
            bool ingreso = logica.MtLoginL(txtEmail.Text.Trim(), txtContra.Text.Trim());

            if (ingreso)
            {
                Session["usuario"] = txtEmail.Text;
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                lblMensaje.Text = "Correo o contraseña incorrectos.";
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}