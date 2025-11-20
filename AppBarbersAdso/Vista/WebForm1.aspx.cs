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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta",
                    "alert('Debes llenar todos los campos antes de ingresar');", true);
                return;
            }

<<<<<<< HEAD
		}
        protected void btnLogin_Click(object sender, EventArgs e)
        {
=======
>>>>>>> salazar
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

<<<<<<< HEAD
=======
        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
>>>>>>> salazar
    }
}