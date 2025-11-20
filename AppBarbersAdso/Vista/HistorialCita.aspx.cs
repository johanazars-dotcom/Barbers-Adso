using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class HistorialCitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Datos.HistorialCitaD datos = new Datos.HistorialCitaD();
                var historial = datos.ObtenerHistorial(1); // Cambia el ID según el usuario logueado

                gvHistorial.DataSource = historial;
                gvHistorial.DataBind();
            }
        }
    }
}

