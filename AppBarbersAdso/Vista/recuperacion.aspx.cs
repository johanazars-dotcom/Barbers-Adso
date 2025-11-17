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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
            


            string token = Request.QueryString["token"];
            string nuevaPass = txtNuevaContra.Text;
            string confirmar = txtConfirmar.Text;

            if (nuevaPass != confirmar)
            {
                Response.Write("<script>alert('Las contraseñas no coinciden');</script>");
                return;
            }

            ClUsuarioL logica = new ClUsuarioL();
            bool cambiado = logica.RestablecerContrasena(token, nuevaPass);

            if (cambiado)
                Response.Write("<script>alert('Contraseña actualizada correctamente');</script>");
            else
                Response.Write("<script>alert('Token inválido o expirado');</script>");
        }

        protected void txtNuevaContra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}