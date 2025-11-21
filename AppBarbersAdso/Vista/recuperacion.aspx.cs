using AppBarbersAdso.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBarbersAdso.Vista
{
    public partial class recuperacion : System.Web.UI.Page
    {
        ClUsuarioL logica = new ClUsuarioL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string token = Request.QueryString["token"];

                if (string.IsNullOrEmpty(token))
                {
                    lblMsg.CssClass = "text-danger";
                    lblMsg.Text = "Token inválido.";
                    btnGuardar.Enabled = false;
                    return;
                }

                hfToken.Value = token;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string token = hfToken.Value;
            string nuevaPass = txtNuevaPass.Text;

            bool ok = logica.RestablecerContrasena(token, nuevaPass);

            if (ok)
            {
                lblMsg.CssClass = "text-success";
                lblMsg.Text = "Contraseña actualizada correctamente.";
            }
            else
            {
                lblMsg.CssClass = "text-danger";
                lblMsg.Text = "El enlace ha expirado o el token no es válido.";
            }
        }
    }
}