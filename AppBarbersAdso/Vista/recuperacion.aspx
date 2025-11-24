<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recuperacion.aspx.cs" Inherits="AppBarbersAdso.Vista.recuperacion" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Restablecer Contraseña</title>

    <!-- BOOTSTRAP 5 -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        body {
            background: #f0f2f5;
        }
        .card {
            border-radius: 12px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="container d-flex justify-content-center align-items-center" style="min-height: 100vh;">
            <div class="card p-4 shadow" style="width: 100%; max-width: 400px;">
                
                <h4 class="text-center mb-3">Restablecer contraseña</h4>

                <!-- Token oculto -->
                <asp:HiddenField ID="hfToken" runat="server" />

                <div class="mb-3">
                    <label class="form-label">Nueva contraseña</label>
                    <asp:TextBox ID="txtNuevaPass" runat="server" TextMode="Password" CssClass="form-control" placeholder="Ingresa tu nueva contraseña"></asp:TextBox>
                </div>

                <asp:Button ID="btnGuardar" runat="server" Text="Guardar contraseña"
                    CssClass="btn btn-primary w-100" OnClick="btnGuardar_Click" />

                <br /><br />
                <asp:Label ID="lblMsg" runat="server" CssClass="text-center d-block"></asp:Label>

            </div>
        </div>

    </form>

    <!-- BOOTSTRAP JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>
