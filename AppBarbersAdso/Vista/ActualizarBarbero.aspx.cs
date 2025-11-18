using AppBarbersAdso.Logica;
using AppBarbersAdso.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBarbersAdso.Vista
{
	public partial class ActualizarBarbero : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClBarberoM usuario = (ClBarberoM)Session["usuarioLogueado"];
                if (usuario == null) Response.Redirect("WebForm1.aspx");

                txtNombre.Text = usuario.nombreBarbero;
                txtApellido.Text = usuario.apellidoBarbero;
                txtTelefono.Text = usuario.telefono;
                txtDocumento.Text = usuario.documento;
                txtContra.Text = usuario.contraseña;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ClBarberoM usuarioSesion = (ClBarberoM)Session["usuarioLogueado"];
            if (usuarioSesion == null) Response.Redirect("WebForm1.aspx");

            ClBarberoM nuevosDatos = new ClBarberoM
            {
                email = usuarioSesion.email,
                nombreBarbero = txtNombre.Text,
                apellidoBarbero = txtApellido.Text,
                telefono = txtTelefono.Text,
                documento = txtDocumento.Text,
                contraseña = txtContra.Text
            };

            ClBarberoL logica = new ClBarberoL();
            lblMensaje.Text = logica.MtActualizarPerfilBarberoL(nuevosDatos);
            Session["usuarioLogueado"] = nuevosDatos;
        }
    }
}
