using AppBarbersAdso.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBarbersAdso.Vista
{
	public partial class PaginaAdmin : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarBarberos();
            }
        }

        private void CargarBarberos()
        {
            ClAdminL logica = new ClAdminL();
            gvBarberos.DataSource = logica.ListarBarberosL();
            gvBarberos.DataBind();
        }

        protected void btnRegistrarBarbero_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroBarbero.aspx");
        }

    }
}
