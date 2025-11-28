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
                CargarContratosHtml();
                CargarPagos();
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
        private void CargarContratosHtml()
        {
            ClAdminL logica = new ClAdminL();
            rpContratos.DataSource = logica.ListarContratosPorBarberoL();
            rpContratos.DataBind();
        }
        protected void rpContratos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int idContrato;
            if (!int.TryParse(e.CommandArgument.ToString(), out idContrato) || idContrato <= 0)
            {
                // fila sin contrato real (idContrato = 0)
                return;
            }

            if (e.CommandName == "Editar")
            {
                CargarFormularioEdicion(idContrato);
            }
            else if (e.CommandName == "Eliminar")
            {
                EliminarContrato(idContrato);
                pnlEditarContrato.Visible = false;
                CargarContratosHtml();   // recarga la tabla
            }
        }

        private void CargarFormularioEdicion(int idContrato)
        {
            ClAdminL logica = new ClAdminL();
            clContrato contrato = logica.ObtenerContratoEditarL(idContrato);

            if (contrato != null)
            {
                hfIdContrato.Value = contrato.idContrato.ToString();

                // selecciona los valores actuales
                if (ddlEstadoContrato.Items.FindByValue(contrato.estadoContrato) != null)
                    ddlEstadoContrato.SelectedValue = contrato.estadoContrato;

                if (ddlTipoContrato.Items.FindByValue(contrato.tipoContrato) != null)
                    ddlTipoContrato.SelectedValue = contrato.tipoContrato;

                txtUltimoPago.Text = contrato.ultimoPago;

                pnlEditarContrato.Visible = true;
            }
        }
        private void EliminarContrato(int idContrato)
        {
            ClAdminL logica = new ClAdminL();
            logica.EliminarContratoL(idContrato);
        }
        protected void btnGuardarContrato_Click(object sender, EventArgs e)
        {
            int idContrato;
            if (!int.TryParse(hfIdContrato.Value, out idContrato) || idContrato <= 0)
                return;

            string estado = ddlEstadoContrato.SelectedValue;
            string tipo = ddlTipoContrato.SelectedValue;
            string ultimoPago = txtUltimoPago.Text.Trim();

            // admin de la sesión
            int idAdmin = 0;
            if (Session["usuarioLogueado"] != null)
            {
                ClAdminM admin = (ClAdminM)Session["usuarioLogueado"];
                idAdmin = admin.idAdministrador;
            }

            ClAdminL logica = new ClAdminL();
            logica.ActualizarContratoYUltimoPagoL(idContrato, estado, tipo, ultimoPago, idAdmin);

            pnlEditarContrato.Visible = false;
            CargarContratosHtml();
        }
        protected void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            pnlEditarContrato.Visible = false;
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
        private void CargarPagos()
        {
            ClAdminL logica = new ClAdminL();
            gvPagos.DataSource = logica.ListarPagos();
            gvPagos.DataBind();
        }

    }
}
  

