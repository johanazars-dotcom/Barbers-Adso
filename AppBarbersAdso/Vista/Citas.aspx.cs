using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Modelos;

namespace Vista
{
    public partial class Citas : System.Web.UI.Page
    {
        private CitaL logica = new CitaL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarTabla();
        }

        private void CargarTabla()
        {
            gvCitas.DataSource = logica.Listar();
            gvCitas.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CitaM c = new CitaM
            {
                idCita = string.IsNullOrEmpty(hfIdCita.Value) ? 0 : int.Parse(hfIdCita.Value),
                idUsuario = int.Parse(txtIdUsuario.Text),
                idBarbero = int.Parse(txtIdBarbero.Text),
                idPuesto = int.Parse(txtIdPuesto.Text),
                fechaCita = DateTime.Parse(txtFecha.Text),
                hora = txtHora.Text,
                idEstado = int.Parse(txtIdEstado.Text)
            };

            logica.GuardarCita(c);
            Limpiar();
            CargarTabla();
        }

        protected void gvCitas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvCitas.Rows[index].Cells[0].Text);

            if (e.CommandName == "editar")
            {
                hfIdCita.Value = gvCitas.Rows[index].Cells[0].Text;
                txtIdUsuario.Text = gvCitas.Rows[index].Cells[1].Text;
                txtIdBarbero.Text = gvCitas.Rows[index].Cells[2].Text;
                txtIdPuesto.Text = gvCitas.Rows[index].Cells[3].Text;
                txtFecha.Text = Convert.ToDateTime(gvCitas.Rows[index].Cells[4].Text).ToString("yyyy-MM-dd");
                txtHora.Text = gvCitas.Rows[index].Cells[5].Text;
                txtIdEstado.Text = gvCitas.Rows[index].Cells[6].Text;
            }
            else if (e.CommandName == "eliminar")
            {
                logica.Eliminar(id);
                CargarTabla();
            }
        }

        private void Limpiar()
        {
            hfIdCita.Value = "";
            txtIdUsuario.Text = "";
            txtIdBarbero.Text = "";
            txtIdPuesto.Text = "";
            txtFecha.Text = "";
            txtHora.Text = "";
            txtIdEstado.Text = "";
        }
    }
}
