<%@ Page Title="Login Barbero" Language="C#" MasterPageFile="~/Vista/Site1.master"
    AutoEventWireup="true" CodeBehind="LoginBarbero.aspx.cs"
    Inherits="AppBarbersAdso.Vista.LoginBarbero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="row justify-content-center mt-5">
    <div class="col-md-4">

        <div class="card card-barber shadow-lg p-4 rounded-4 text-center">

            <h3 class="mb-4" style="color:#d4af37;">LOGIN BARBERO</h3>

            <!-- CORREO -->
            <div class="mb-3 text-start">
                <label class="text-warning">Correo</label>
                <asp:TextBox ID="txtEmail" runat="server"
                    CssClass="form-control bg-dark text-white border-warning" />
            </div>

            <!-- CONTRASEÑA -->
            <div class="mb-4 text-start">
                <label class="text-warning">Contraseña</label>
                <asp:TextBox ID="txtContra" runat="server" TextMode="Password"
                    CssClass="form-control bg-dark text-white border-warning" />
            </div>

            <!-- BOTÓN INGRESAR -->
            <asp:Button ID="btnLogin" runat="server" Text="Ingresar"
                CssClass="btn btn-dorado w-100 mb-3" OnClick="btnLogin_Click" />

            <!-- MENSAJE -->
            <asp:Label ID="lblMensaje" runat="server"
                CssClass="text-danger mt-3 d-block fw-bold"></asp:Label>

        </div>
    </div>
</div>

</asp:Content>

