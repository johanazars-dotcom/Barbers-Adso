<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="envioCorreo.aspx.cs"
    Inherits="AppBarbersAdso.Vista.envioCorreo"
    MasterPageFile="~/Vista/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center">
        <div class="col-md-5">
            <div class="card shadow-sm">
                <div class="card-body bg-dark text-white" style="border:1px solid #d4af37;">
                    <h4 class="text-center mb-3">Restablecer contraseña</h4>
                    <p class="text-muted text-center">Ingresa tu correo para enviarte el código</p>

                    <div class="mb-3">
                        <label for="txtCorreo" class="form-label">Correo electrónico</label>
                        <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server"
                                     TextMode="Email" placeholder="ejemplo@correo.com"></asp:TextBox>
                    </div>

                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar código"
                                CssClass="btn btn-primary w-100" OnClick="btnEnviar_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
