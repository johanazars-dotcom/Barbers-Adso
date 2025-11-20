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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ClUsuarioM registro = new ClUsuarioM();

            registro.nombre = txtNombre.Text;
            registro.apellido = txtApellidos.Text;
            registro.documento = txtDocumento.Text;
            registro.email = txtEmail.Text;
            registro.contraseña = txtContrasena.Text;
            registro.telefono = txtTelefono.Text;

            ClUsuarioL logica = new ClUsuarioL();

            string mensaje = logica.MtRegitroUsuario(registro);

            lblResultado.Text = mensaje;
        }
<<<<<<< HEAD
=======

        protected void btnRegresarLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
>>>>>>> salazar
    }
}