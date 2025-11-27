<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarCorreo.aspx.cs" Inherits="AppBarbersAdso.Vista.RecuperarCorreo" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Recuperar Contraseña</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>

<body>
<form id="form1" runat="server">

<div class="container d-flex justify-content-center align-items-center" style="min-height: 100vh;">
  <div class="card p-4 shadow" style="width: 100%; max-width: 400px;">

    <h4 class="text-center mb-3">Recuperar contraseña</h4>

    <label>Ingresa tu correo</label>
    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo"></asp:TextBox>

    <br />

    <asp:Button ID="btnEnviar" runat="server" Text="Enviar enlace"
                CssClass="btn btn-primary w-100" OnClick="btnEnviar_Click" />

    <br /><br />
    <asp:Label ID="lblMsg" runat="server" CssClass="text-center d-block"></asp:Label>

  </div>
</div>

</form>
</body>
</html>
