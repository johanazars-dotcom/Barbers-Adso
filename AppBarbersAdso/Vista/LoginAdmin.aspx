<%@ Page Title="Login Admin" Language="C#" MasterPageFile="~/Vista/Site1.master" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="AppBarbersAdso.Vista.LoginAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="card card-barber p-4 col-md-5 mx-auto">
    <h3 class="text-center text-warning mb-4">Login Administrador</h3>

    <asp:Label Text="Correo" runat="server" />
    <asp:TextBox ID="txtUsuario" CssClass="form-control mb-3" runat="server" />

    <asp:Label Text="Contraseña" runat="server" />
    <asp:TextBox ID="txtClave" TextMode="Password" CssClass="form-control mb-3" runat="server" />

    <asp:Label ID="lblMensaje" CssClass="text-danger" runat="server" />

    <asp:Button ID="btnIngresar" runat="server" 
        Text="Ingresar" 
        CssClass="btn btn-dorado w-100 mt-3"
        OnClick="btnIngresar_Click" />
</div>

</asp:Content>