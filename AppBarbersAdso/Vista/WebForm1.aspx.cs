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
		protected void Page_Load(object sender, EventArgs e)
		{

		}
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ClUsuarioL logica = new ClUsuarioL();
            bool ingreso = logica.MtLoginL(txtEmail.Text, txtContra.Text);

            if (ingreso)
            {
                Response.Redirect("Actualizar.aspx");
            }
            else
            {
                lblMensaje.Text = "Correo o contraseña incorrectos.";
            }
        }

    }
}