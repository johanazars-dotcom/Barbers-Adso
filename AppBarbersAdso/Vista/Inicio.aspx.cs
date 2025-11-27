using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBarbersAdso.Vista
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();     
            Session.Abandon();   
            Response.Redirect("Inicio.aspx");
        }

        protected void btnCitas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Citas.aspx");
        }
    }

}