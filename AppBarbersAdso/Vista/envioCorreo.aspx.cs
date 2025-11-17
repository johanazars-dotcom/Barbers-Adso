using AppBarbersAdso.Datos;
using AppBarbersAdso.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBarbersAdso.Vista
{
    public partial class envioCorreo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
           ClUsuarioL logica = new ClUsuarioL();


            bool enviado = logica.EnviarToken(txtCorreo.Text);


            if (enviado)
            {
                Response.Write("<script>alert('Se envió un token a tu correo.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Correo no encontrado.');</script>");
            }

        }
    }
}