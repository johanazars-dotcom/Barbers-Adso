<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="AppBarbersAdso.Vista.Registro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro de Usuario</title>
    
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

                <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn btn-success" OnClick="btnRegistrar_Click" />
                <asp:Label ID="lblResultado" runat="server" CssClass="form-text mt-3 text-success" />
            </div>
        </div>
    </form>
 
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
