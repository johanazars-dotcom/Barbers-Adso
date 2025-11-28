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
    public partial class ActualizarBarbero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    lblMensaje.Text = "Error: No se encontró el ID del barbero.";
                    return;
                }

                int id = int.Parse(Request.QueryString["id"]);
                CargarDatos(id);
            }
        }

        private void CargarDatos(int id)
        {
            ClBarberoL log = new ClBarberoL();
            ClPuestosL logP = new ClPuestosL();

            var b = log.MtObtenerBarberoPorIdL(id);

            if (b != null)
            {
                txtNombre.Text = b.nombreBarbero;
                txtApellido.Text = b.apellidoBarbero;
                txtTelefono.Text = b.telefono;
                txtDocumento.Text = b.documento;
                txtContra.Text = b.contraseña;
                txtEmail.Text = b.email;
              
                var puestos = logP.ListarPuestosDisponiblesSoloL();

                ddlPuesto.DataSource = puestos;
                ddlPuesto.DataTextField = "numeroPuesto";
                ddlPuesto.DataValueField = "idPuesto";
                ddlPuesto.DataBind();

                ddlPuesto.SelectedValue = b.idPuesto.ToString();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);

            ClBarberoL logB = new ClBarberoL();
            ClPuestosL logP = new ClPuestosL();

            
            var antiguo = logB.MtObtenerBarberoPorIdL(id);

            ClBarberoM datos = new ClBarberoM();
            datos.idBarbero = id;
            datos.nombreBarbero = txtNombre.Text;
            datos.apellidoBarbero = txtApellido.Text;
            datos.telefono = txtTelefono.Text;
            datos.documento = txtDocumento.Text;
            datos.contraseña = txtContra.Text;
            datos.email = antiguo.email;

           
            datos.idPuesto = int.Parse(ddlPuesto.SelectedValue);

           
            if (datos.idPuesto != antiguo.idPuesto)
            {
                
                logP.CambiarEstadoPuestoL(antiguo.idPuesto, "Disponible");


                logP.CambiarEstadoPuestoL(datos.idPuesto, "Ocupado");
            }


            logB.MtActualizarBarberoPorIdL(datos);

            lblMensaje.Text = "Perfil actualizado correctamente ✔";
        }

    }
}
