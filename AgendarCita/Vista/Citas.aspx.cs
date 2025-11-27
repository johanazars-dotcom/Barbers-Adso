using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Modelos;

namespace TuProyecto
{
    public partial class Citas : System.Web.UI.Page
    {
        CitaL logica = new CitaL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarTabla();
        }

        void CargarTabla()
        {
            gvCitas.DataSource = logica.Listar();
            gvCitas.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CitaM c = new CitaM
            {
                idCita = string.IsNullOrEmpty(hfIdCita.Value) ? 0 : int.Parse(hfIdCita.Value),
                nombreCliente = txtNombre.Text,
                fechaCita = DateTime.Parse(txtFecha.Text),
                hora = txtHora.Text
            };

            logica.GuardarCita(c);
            Limpiar();
            CargarTabla();
        }

        protected void gvCitas_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvCitas.Rows[index].Cells[0].Text);

            if (e.CommandName == "editar")
            {
                hfIdCita.Value = gvCitas.Rows[index].Cells[0].Text;
                txtNombre.Text = gvCitas.Rows[index].Cells[1].Text;
                txtFecha.Text = Convert.ToDateTime(gvCitas.Rows[index].Cells[2].Text).ToString("yyyy-MM-dd");
                txtHora.Text = gvCitas.Rows[index].Cells[3].Text;
            }
            else if (e.CommandName == "eliminar")
            {
                logica.Eliminar(id);
                CargarTabla();
            }
        }

        void Limpiar()
        {
            hfIdCita.Value = "";
            txtNombre.Text = "";
            txtFecha.Text = "";
            txtHora.Text = "";
        }
    }
}
