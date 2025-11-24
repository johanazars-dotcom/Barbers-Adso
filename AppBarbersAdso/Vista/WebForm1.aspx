<%@ Page Title="Login" Language="C#" MasterPageFile="~/Vista/Site1.master" 
    AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" 
    Inherits="AppBarbersAdso.Vista.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="row justify-content-center mt-5">
    <div class="col-md-4">
        <div class="card shadow-lg p-4 rounded-4 text-center bg-dark text-white">

            <h3 class="mb-4" style="color:#d4af37;">INICIAR SESIÓN</h3>

                  <div class="mb-3 text-start">
                <label>Correo</label>
                <asp:TextBox ID="txtEmail" runat="server" 
                    CssClass="form-control bg-dark text-white border-warning" />
            </div>

            <div class="mb-4 text-start">
                <label>Contraseña</label>
                <asp:TextBox ID="txtContra" runat="server" TextMode="Password" 
                    CssClass="form-control bg-dark text-white border-warning" />
            </div>

            <asp:Button ID="btnLogin" runat="server" Text="Ingresar"
                CssClass="btn btn-warning w-100 mb-3" OnClick="btnLogin_Click" />

            <asp:Button ID="btnRegistroCliente" runat="server" Text="Registrarse"
                CssClass="btn btn-outline-light w-100" OnClick="btnRegistro_Click" />

            <a href="envioCorreo.aspx" 
               class="text-warning d-block mt-3 text-decoration-none">
               ¿Olvidaste tu contraseña?
            </a>

           
            <asp:Label ID="lblMensaje" runat="server" 
                CssClass="text-danger mt-3 d-block"></asp:Label>

        </div>
    </div>
</div>

</asp:Content>
