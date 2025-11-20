<<<<<<< HEAD
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="AppBarbersAdso.Vista.Registro" %>

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
=======
﻿<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Vista/Site1.Master"
    AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="AppBarbersAdso.Vista.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center">
        <div class="col-md-8 col-lg-6">

            <div class="card shadow-lg" style="background:#111;border:1px solid #d4af37;border-radius:15px;">
                <div class="card-header text-center" style="background:#000;border-bottom:1px solid #d4af37;">
                    <h3 style="color:#d4af37;margin:0;">Registro de Usuario</h3>
                </div>

                <div class="card-body text-white">

                    <div class="mb-3">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label" />
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control bg-dark text-white border-warning" />
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblApellidos" runat="server" Text="Apellidos" CssClass="form-label" />
                        <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control bg-dark text-white border-warning" />
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblDocumento" runat="server" Text="Documento" CssClass="form-label" />
                        <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control bg-dark text-white border-warning" />
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label" />
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control bg-dark text-white border-warning" />
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblContrasena" runat="server" Text="Contraseña" CssClass="form-label" />
                        <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" CssClass="form-control bg-dark text-white border-warning" />
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono" CssClass="form-label" />
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control bg-dark text-white border-warning" />
                    </div>

                    <div class="d-grid gap-2">
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse"
                            CssClass="btn btn-warning fw-bold"
                            OnClick="btnRegistrar_Click" />

                        <asp:Button ID="btnRegresar" runat="server" Text="Iniciar Sesión"
                            CssClass="btn btn-outline-warning"
                            OnClick="btnRegresarLogin_Click" />
                    </div>

                    <div class="mt-3 text-center">
                        <asp:Label ID="lblResultado" runat="server" CssClass="text-warning fw-bold" />
                    </div>

                </div>
            </div>

        </div>
    </div>

</asp:Content>

>>>>>>> salazar
