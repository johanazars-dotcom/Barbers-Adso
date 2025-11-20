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
        protected void btnBuscar_Click(object sender, System.EventArgs e)
        {
            int idPuesto = System.Convert.ToInt32(txtIdPuesto.Text);

            Logica.HistorialPuestoL logica = new Logica.HistorialPuestoL();
            System.Collections.Generic.List<Modelos.HistorialPuestoM> lista = logica.ListarHistorial(idPuesto);

            GridHistorial.DataSource = lista;
            GridHistorial.DataBind();
        }
    }
}
