using AppBarbersAdso.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBarbersAdso.Vista
{
    public partial class FinanzaV : System.Web.UI.Page
    {
        FinanzaL logica = new FinanzaL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPagos();
            }
        }

        void CargarPagos()
        {
            gvPagos.DataSource = logica.ListarPagos();
            gvPagos.DataBind();
        }
    }
}
