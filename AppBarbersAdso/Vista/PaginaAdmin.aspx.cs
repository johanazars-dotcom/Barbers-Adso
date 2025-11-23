using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBarbersAdso.Logica;
using AppBarbersAdso.Modelo;

namespace AppBarbersAdso.Vista
{
	public partial class PaginaAdmin : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioLogueado"] == null)
            {
                Response.Redirect("LoginAdmin.aspx");
                return;
            }

            if (!IsPostBack)
            {
               
                var admin = (ClAdminM)Session["usuarioLogueado"];

                // Cargar barberos en la tabla
                CargarBarberos();
            }

            // PROCESAR ELIMINACIÓN
            if (Request.QueryString["eliminar"] != null)
            {
                int id = int.Parse(Request.QueryString["eliminar"]);

                ClBarberoL logica = new ClBarberoL();
                string resultado = logica.MtEliminarBarberoL(id);

                // Alerta simple
                ScriptManager.RegisterStartupScript(this, GetType(), "alerta",
                    $"alert('{resultado}');", true);

                // Recargar la página sin parámetros
                Response.AddHeader("Refresh", "1;URL=PaginaAdmin.aspx");
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

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // CERRAR SESIÓN
            Session.Clear();
            Session.Abandon();
            Response.Redirect("LoginAdmin.aspx");
        }
    }
}
  

