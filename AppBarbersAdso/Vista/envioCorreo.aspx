<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="envioCorreo.aspx.cs" Inherits="AppBarbersAdso.Vista.envioCorreo" %>

<!DOCTYPE html>

<html lang="es">
<head>
    <meta charset="UTF-8" />
    <title>Enviar Código de Recuperación</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-5">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h4 class="text-center mb-3">Restablecer contraseña</h4>
                        <p class="text-muted text-center">Ingresa tu correo para enviarte el código</p>
                        <form runat="server">
                            <div class="mb-3">
                                <label for="txtCorreo" class="form-label">Correo electrónico</label>
                                <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server" TextMode="Email" placeholder="ejemplo@correo.com"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnEnviar" runat="server" Text="Enviar código" CssClass="btn btn-primary w-100" OnClick="btnEnviar_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
