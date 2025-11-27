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
	public partial class Actualizar : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClUsuarioM usuarioSesion = (ClUsuarioM)Session["usuarioLogueado"];
                if (usuarioSesion == null) Response.Redirect("WebForm1.aspx");

                ClUsuarioL logica = new ClUsuarioL();
                ClUsuarioM usuarioBD = logica.MtObtenerUsuarioL(usuarioSesion.email);

                if (usuarioBD != null)
                {
                    txtNombre.Text = usuarioBD.nombre;
                    txtApellido.Text = usuarioBD.apellido;
                    txtTelefono.Text = usuarioBD.telefono;
                    txtDocumento.Text = usuarioBD.documento;
                    txtContra.Text = usuarioBD.contraseña;
                }
                else
                {
                    lblMensaje.Text = "No se encontraron datos del usuario.";
                }
            }
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ClUsuarioM usuarioSesion = (ClUsuarioM)Session["usuarioLogueado"];
            if (usuarioSesion == null) Response.Redirect("WebForm1.aspx");

            ClUsuarioM nuevosDatos = new ClUsuarioM
            {
                email = usuarioSesion.email,
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                telefono = txtTelefono.Text,
                documento = txtDocumento.Text,
                contraseña = txtContra.Text
            };

            ClUsuarioL logica = new ClUsuarioL();
            lblMensaje.Text = logica.MtActualizarPerfilL(nuevosDatos);
            Session["usuarioLogueado"] = nuevosDatos;
        }
    }
}
	
