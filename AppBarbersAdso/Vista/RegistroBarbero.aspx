<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroBarbero.aspx.cs" Inherits="AppBarbersAdso.Vista.RegistroBarbero" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro de Barbero</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="formRegistro" runat="server" class="container mt-5">
        <div class="card shadow">
            <div class="card-header bg-primary text-white">
                <h3 class="mb-0">Formulario de Registro</h3>
            </div>
            <div class="card-body">

                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label" />
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblApellidos" runat="server" Text="Apellidos" CssClass="form-label" />
                    <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblDocumento" runat="server" Text="Documento" CssClass="form-label" />
                    <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label" />
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblContrasena" runat="server" Text="Contraseña" CssClass="form-label" />
                    <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono" CssClass="form-label" />
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Foto (JPG/PNG)</label>
                    <asp:FileUpload ID="fuFoto" runat="server" CssClass="form-control" OnChange="previewImage(this)" />
                    <img id="imgPreview" style="max-width: 150px; margin-top: 10px; display: none;" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Hoja de Vida (PDF)</label>
                    <asp:FileUpload ID="fuHojaVida" runat="server" CssClass="form-control" />
                    <p id="pdfNombre" class="mt-2 text-muted"></p>
                </div>
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn btn-success" OnClick="btnRegistrar_Click" />
                
                <asp:Label ID="lblResultado" runat="server" CssClass="form-text mt-3 text-success" />

            </div>
        </div>
    </form>

    <script>
        function previewImage(input) {
            let img = document.getElementById("imgPreview");
            if (input.files && input.files[0]) {
                img.src = URL.createObjectURL(input.files[0]);
                img.style.display = "block";
            }
        }

        document.getElementById("<%= fuHojaVida.ClientID %>").addEventListener("change", function () {
            if (this.files.length > 0) {
                document.getElementById("pdfNombre").textContent = this.files[0].name;
            }
        });
    </script>

</body>
</html>
