using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Vista
{
    public partial class HistorialPuesto : System.Web.UI.Page
    {
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int idPuesto = 0;

            // Uso de TryParse para entrada segura
            if (int.TryParse(txtIdPuesto.Text, out idPuesto))
            {
                Logica.HistorialPuestoL logica = new Logica.HistorialPuestoL();
                List<Modelos.HistorialPuestoM> lista = logica.ListarHistorial(idPuesto);

                GridHistorial.DataSource = lista;
                GridHistorial.DataBind();
            }
            else
            {
                // Limpiar el GridView si la entrada no es válida
                GridHistorial.DataSource = null;
                GridHistorial.DataBind();
            }
        }
    }
}