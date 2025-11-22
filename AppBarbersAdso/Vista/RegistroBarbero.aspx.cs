using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppBarbersAdso.Logica;
using AppBarbersAdso.Modelo;

namespace AppBarbersAdso.Vista
{
    public partial class RegistroBarbero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPuestos();
            }
        }

        private void CargarPuestos()
        {
            ClPuestosL logica = new ClPuestosL();

            ddlPuestos.DataSource = logica.ListarPuestosDisponiblesL();
            ddlPuestos.DataTextField = "numeroPuesto";
            ddlPuestos.DataValueField = "idPuesto";
            ddlPuestos.DataBind();

            // 👉 ESTO HACE VISIBLE EL TEXTO SIEMPRE
            ddlPuestos.Attributes.Add("style", "background:white; color:black; font-weight:bold;");
        }

        private bool HayCamposVacios(Control contenedor)
        {
            foreach (Control ctrl in contenedor.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    if (string.IsNullOrWhiteSpace(txt.Text))
                        return true;
                }

                if (ctrl.HasControls())
                {
                    if (HayCamposVacios(ctrl))
                        return true;
                }
            }
            return false;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (HayCamposVacios(this))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta",
                    "alert('Debes llenar todos los campos antes de registrar');", true);
                return;
            }

            string documento = txtDocumento.Text.Trim();

            string rutaFoto = Server.MapPath("~/Vista/foto/");
            string rutaHojaVida = Server.MapPath("~/Vista/hojaVida/");

            string nombreFoto = "";
            string nombrePdf = "";

            // --- FOTO ---
            if (fuFoto.HasFile)
            {
                string ext = Path.GetExtension(fuFoto.FileName).ToLower();
                int tam = fuFoto.PostedFile.ContentLength;

                if (ext != ".jpg" && ext != ".png")
                {
                    lblResultado.Text = "La foto debe ser JPG o PNG.";
                    return;
                }

                if (tam > 3000000)
                {
                    lblResultado.Text = "La foto no debe superar los 2 MB.";
                    return;
                }

                nombreFoto = documento + ext;
                fuFoto.SaveAs(Path.Combine(rutaFoto, nombreFoto));
            }

            // --- HOJA DE VIDA ---
            if (fuHojaVida.HasFile)
            {
                string ext = Path.GetExtension(fuHojaVida.FileName).ToLower();
                int tam = fuHojaVida.PostedFile.ContentLength;

                if (ext != ".pdf")
                {
                    lblResultado.Text = "La hoja de vida debe ser PDF.";
                    return;
                }

                if (tam > 5000000)
                {
                    lblResultado.Text = "El PDF no debe superar los 5 MB.";
                    return;
                }

                nombrePdf = documento + ext;
                fuHojaVida.SaveAs(Path.Combine(rutaHojaVida, nombrePdf));
            }

            // --- MODELO ---
            ClBarberoM registroBarber = new ClBarberoM();
            registroBarber.nombreBarbero = txtNombre.Text;
            registroBarber.apellidoBarbero = txtApellidos.Text;
            registroBarber.documento = documento;
            registroBarber.email = txtEmail.Text;
            registroBarber.contraseña = txtContrasena.Text;
            registroBarber.telefono = txtTelefono.Text;
            registroBarber.foto = nombreFoto;
            registroBarber.hojaVida = nombrePdf;
            registroBarber.idPuesto = int.Parse(ddlPuestos.SelectedValue);

            // --- LÓGICA ---
            ClBarberoL logicaBarbero = new ClBarberoL();
            string mensaje = logicaBarbero.MtRegitroBarbero(registroBarber);

            if (mensaje == null)
            {
                lblResultado.Text = "Mensaje llegó vacío";
                return;
            }

            string r = mensaje.Trim().ToLower();

            if (r == "duplicado")
            {
                lblResultado.Text = "El correo ya está registrado.";
                lblResultado.CssClass = "text-danger";
            }
            else if (r == "ok")
            {
                lblResultado.Text = "Registrado correctamente.";
                lblResultado.CssClass = "text-success";
            }
            else
            {
                lblResultado.Text = "Ocurrió un error.";
                lblResultado.CssClass = "text-danger";
            }
        }
    }
}

