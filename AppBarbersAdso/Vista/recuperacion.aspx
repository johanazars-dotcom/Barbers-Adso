<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recuperacion.aspx.cs" Inherits="AppBarbersAdso.Vista.recuperacion" %>

<!DOCTYPE html>

<html lang="es">
<head>
    <meta charset="UTF-8" />
    <title>Restablecer Contraseña</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-5">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h4 class="text-center mb-3">Ingresar código de recuperación</h4>
                        <p class="text-muted text-center">Escribe el código enviado a tu correo</p>


                        <form runat="server">


                            <div class="mb-3">
                                <label class="form-label">Nueva contraseña</label>
                                <asp:TextBox ID="txtNuevaContra" CssClass="form-control" runat="server" TextMode="Password" placeholder="Nueva contraseña" required OnTextChanged="txtNuevaContra_TextChanged"></asp:TextBox>
                            </div>


                            <div class="mb-3">
                                <label class="form-label">Confirmar contraseña</label>
                                <asp:TextBox ID="txtConfirmar" CssClass="form-control" runat="server" TextMode="Password" placeholder="Confirmar contraseña" required></asp:TextBox>
                            </div>


                            <asp:Button ID="btnRestablecer" runat="server" Text="Restablecer contraseña" CssClass="btn btn-success w-100" OnClick="btnRestablecer_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
