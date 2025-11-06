<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AppBarbersAdso.Vista.WebForm1" %>

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