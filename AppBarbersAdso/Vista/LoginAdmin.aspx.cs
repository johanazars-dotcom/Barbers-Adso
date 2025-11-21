using AppBarbersAdso.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBarbersAdso.Vista
{
	public partial class LoginAdmin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                lblMensaje.Text = "Debes llenar todos los campos.";
                return;
            }

            ClAdminL logica = new ClAdminL();
            bool ingreso = logica.MtLoginAdminL(txtUsuario.Text.Trim(), txtClave.Text.Trim());

            if (ingreso)
            {
                Session["usuario"] = txtUsuario.Text;
                Response.Redirect("PaginaAdmin.aspx");
            }
            else
            {
                lblMensaje.Text = "Correo o contraseña incorrectos.";
            }
        }

    }
}