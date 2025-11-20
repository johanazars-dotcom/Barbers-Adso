using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class HistorialPuesto : System.Web.UI.Page
    {
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int idPuesto = Convert.ToInt32(txtIdPuesto.Text);

            Logica.HistorialPuestoL logica = new Logica.HistorialPuestoL();
            List<Modelos.HistorialPuestoM> lista = logica.ListarHistorial(idPuesto);

            GridHistorial.DataSource = lista;
            GridHistorial.DataBind();
        }
    }
}
