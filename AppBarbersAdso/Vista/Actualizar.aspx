<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Actualizar.aspx.cs" Inherits="AppBarbersAdso.Vista.Actualizar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Actualizar Datos</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Actualizar Perfil</h2>

        <asp:Label runat="server" Text="Nombre:"></asp:Label><br />
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><br /><br />

        <asp:Label runat="server" Text="Apellido:"></asp:Label><br />
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox><br /><br />

        <asp:Label runat="server" Text="Teléfono:"></asp:Label><br />
        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox><br /><br />

        <asp:Label runat="server" Text="Documento:"></asp:Label><br />
        <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox><br /><br />

        <asp:Label runat="server" Text="Contraseña:"></asp:Label><br />
        <asp:TextBox ID="txtContra" TextMode="Password" runat="server"></asp:TextBox><br /><br />

        <asp:Button ID="btnActualizar" runat="server" Text="Guardar Cambios" OnClick="btnActualizar_Click" /><br /><br />
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </form>
</body>
</html>