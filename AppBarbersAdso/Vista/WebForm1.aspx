<%@ Page Title="Login" Language="C#" MasterPageFile="~/Vista/Site1.master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AppBarbersAdso.Vista.WebForm1" %>

<<<<<<< HEAD
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Inicio de Sesión</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Iniciar Sesión</h2>

        <asp:Label ID="Label1" runat="server" Text="Correo:"></asp:Label><br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br /><br />

        <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label><br />
        <asp:TextBox ID="txtContra" TextMode="Password" runat="server"></asp:TextBox><br /><br />

        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" /><br /><br />

        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
=======
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="row justify-content-center">
    <div class="col-md-4">
        <div class="card card-barber shadow-lg p-4 rounded-4 text-center">

            <h3 class="mb-4" style="color:#d4af37;">INICIAR SESIÓN</h3>

            <div class="mb-3 text-start">
                <label>Correo</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control bg-dark text-white border-warning" />
            </div>

            <div class="mb-4 text-start">
                <label>Contraseña</label>
                <asp:TextBox ID="txtContra" runat="server" TextMode="Password" CssClass="form-control bg-dark text-white border-warning" />
            </div>

            <asp:Button ID="btnLogin" runat="server" Text="Ingresar"
                CssClass="btn btn-dorado w-100 mb-3" OnClick="btnLogin_Click" />

            <asp:Button ID="btnRegistroCliente" runat="server" Text="Registrarse"
                CssClass="btn btn-outline-light w-100" OnClick="btnRegistro_Click" />

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-3 d-block"></asp:Label>

        </div>
    </div>
</div>

</asp:Content>
>>>>>>> salazar
