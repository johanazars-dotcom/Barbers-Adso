using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBarbersAdso.Datos;
using AppBarbersAdso.Logica;
using AppBarbersAdso.Modelo;

namespace AppBarbersAdso.Vista
{
    public partial class Citas : System.Web.UI.Page
    {
        CitaL logica = new CitaL();
        ClBarberoD barberoD = new ClBarberoD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioLogueado"] == null)
            {
                Response.Redirect("WebForm1.aspx");
                return;
            }

            if (!IsPostBack)
            {
                var usuario = (ClUsuarioM)Session["usuarioLogueado"];
                hfUsuario.Value = usuario.idUsuario.ToString();

                CargarBarberos();
                CargarTabla(usuario.idUsuario);
            }
        }

        private void CargarBarberos()
        {
            ddlBarbero.DataSource = barberoD.MtListarBarberos();
            ddlBarbero.DataTextField = "nombreBarbero";   
            ddlBarbero.DataValueField = "idBarbero";
            ddlBarbero.DataBind();

            ddlBarbero.Items.Insert(0, new ListItem("Seleccione un barbero", "0"));
        }

        private void CargarTabla(int idUsuario)
        {
            gvCitas.DataSource = logica.MtListarCitasCliente(idUsuario);
            gvCitas.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
      
            if (ddlBarbero.SelectedValue == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('⚠ Debe seleccionar un barbero.');", true);
                return;
            }

            int.TryParse(hfIdCita.Value, out int idCita);

            var barbero = barberoD.MtListarBarberos()
                .FirstOrDefault(b => b.idBarbero == int.Parse(ddlBarbero.SelectedValue));

            CitaM c = new CitaM
            {
                idCita = idCita,
                idUsuario = int.Parse(hfUsuario.Value),
                idBarbero = barbero.idBarbero,
                idPuesto = barbero.idPuesto,
                fechaCita = DateTime.Parse(txtFecha.Text),
                hora = txtHora.Text
            };

            string res = logica.MtGuardarCita(c);

            if (res == "ocupado")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    "alert('⚠ El barbero ya tiene una cita a esa fecha y hora.');", true);
                return;
            }

            ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('✔ Cita guardada correctamente');", true);

            Limpiar();
            CargarTabla(int.Parse(hfUsuario.Value));
        }

        protected void gvCitas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvCitas.DataKeys[index].Value);

            if (e.CommandName == "eliminar")
            {
                logica.MtEliminarCita(id);
                CargarTabla(int.Parse(hfUsuario.Value));
            }
        }

        private void Limpiar()
        {
            txtFecha.Text = "";
            txtHora.Text = "";
            ddlBarbero.SelectedIndex = 0;
            hfIdCita.Value = "0";
        }
    }
}

    


