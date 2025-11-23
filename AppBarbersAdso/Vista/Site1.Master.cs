using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBarbersAdso.Vista
{
	public partial class Site1 : System.Web.UI.MasterPage
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            // Nada extra, todo se controla desde el Session directamente
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Eliminar toda la sesión
            Session.Clear();
            Session.Abandon();

            // Redirigir al inicio general del sitio
            Response.Redirect("Inicio.aspx");
        }
    }
}
