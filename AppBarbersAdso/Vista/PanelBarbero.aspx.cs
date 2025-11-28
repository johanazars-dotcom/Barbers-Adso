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
    public partial class PanelBarbero : System.Web.UI.Page
    {
        CitaL logica = new CitaL();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Validar si hay un usuario en sesión
            if (Session["usuarioLogueado"] == null)
            {
                Response.Redirect("LoginBarbero.aspx");
                return;
            }

            // Convertir la sesión en barbero
            var barbero = (ClBarberoM)Session["usuarioLogueado"];

            if (!IsPostBack)
            {
                CargarCitasBarbero(barbero.idBarbero);
            }
        }

        private void CargarCitasBarbero(int idBarbero)
        {
            gvCitasBarbero.DataSource = logica.MtListarCitasBarbero(idBarbero);
            gvCitasBarbero.DataBind();
        }
    }
}