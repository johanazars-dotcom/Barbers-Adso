using AppBarbersAdso.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBarbersAdso.Vista
{
    public partial class envioCorreoBarbero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            ClBarberoL logica = new ClBarberoL();


            bool enviado = logica.EnviarToken(txtCorreo.Text);


            if (enviado == true)
            {
                Response.Write("<script>alert('Se envió un link de restablecimiento a tu correo.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Correo no encontrado.');</script>");
            }

        }
    }
}