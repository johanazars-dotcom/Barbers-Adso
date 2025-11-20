<%@ Page Title="Login" Language="C#" MasterPageFile="~/Vista/Site1.master"AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs"Inherits="AppBarbersAdso.Vista.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center">
        <div class="col-md-5">
            <div class="card shadow-lg p-4 rounded">
                <h3 class="text-center mb-4">Iniciar Sesión</h3>

                <div class="mb-3">
                    <label class="form-label">Correo</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Contraseña</label>
                    <asp:TextBox ID="txtContra" runat="server" TextMode="Password" CssClass="form-control" />
                </div>

                <div class="d-grid gap-2">
                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar"
                        CssClass="btn btn-dark" OnClick="btnLogin_Click" />

                    <asp:Button ID="btnRegistroCliente" runat="server" Text="Registrarse"
                        CssClass="btn btn-outline-secondary" OnClick="btnRegistro_Click" />
                </div>

                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-3 d-block text-center"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>