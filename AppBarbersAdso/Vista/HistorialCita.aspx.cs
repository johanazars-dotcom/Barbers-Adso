using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelos;

namespace Vista
{
    public partial class HistorialCitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Usando la clase CitaD corregida
                Datos.CitaD datos = new Datos.CitaD();

                // Usando el modelo CitaM corregido
                List<Modelos.CitaM> historial = datos.ObtenerHistorial(1);

                gvHistorial.DataSource = historial;
                gvHistorial.DataBind();
            }
        }
    }
}