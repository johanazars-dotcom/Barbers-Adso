<%@ Page Title="Login Admin" Language="C#" MasterPageFile="~/Vista/Site1.master" 
    AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" 
    Inherits="AppBarbersAdso.Vista.LoginAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css">

<style>

.admin-container {
    display: flex;
    justify-content: center;
    align-items: center;
    min-height: 85vh;
    padding: 50px 0;
}

.admin-card {
    width: 100%;
    max-width: 420px;
    background: rgba(15, 15, 15, 0.85);
    border-radius: 20px;
    padding: 40px 30px;
    border: 1px solid rgba(212,175,55,0.35);
    backdrop-filter: blur(7px);
    box-shadow: 0 0 40px rgba(212,175,55,0.25);
    animation: fadeIn .8s ease;
    color: white;
}

@keyframes fadeIn {
    from {opacity: 0; transform: translateY(25px);}
    to   {opacity: 1; transform: translateY(0);}
}

.admin-title {
    text-align: center;
    font-size: 2.1rem;
    font-weight: 800;
    color: #d4af37;
    text-shadow: 0 0 12px rgba(212,175,55,.5);
    margin-bottom: 30px;
}

.input-group-admin {
    position: relative;
    margin-bottom: 28px;
}

.input-group-admin label {
    font-weight: 600;
    color: #f1f1f1;
    margin-bottom: 5px;
    display: block;
}

.icon-admin {
    position: absolute;
    left: 14px;
    top: 50%;
    transform: translateY(5%);
    font-size: 1.25rem;
    color: #d4af37;
    pointer-events: none;
}

.input-admin {
    width: 100%;
    background: rgba(0,0,0,0.55);
    border: 1px solid #d4af37;
    border-radius: 10px;
    color: white !important;
    padding: 12px 15px 12px 50px;
    font-size: 1.05rem;
    height: 50px;
    transition: .3s ease;
}

.input-admin:focus {
    background: rgba(0,0,0,0.75);
    border: 1px solid #ffd86b;
    box-shadow: 0 0 15px rgba(212,175,55,.55);
}

.btn-admin {
    width: 100%;
    background: linear-gradient(90deg, #ffdf6b, #d4af37);
    border: none;
    border-radius: 14px;
    padding: 12px;
    font-weight: 800;
    font-size: 1.1rem;
    color: black !important;
    margin-top: 5px;
    box-shadow: 0 0 20px rgba(255,215,0,.55);
    transition: .3s ease;
    letter-spacing: 1px;
}

.btn-admin:hover {
    transform: translateY(-3px);
    box-shadow: 0 0 30px rgba(255,215,0,.95);
}

.msg-error {
    color: #ff6e6e;
    font-weight: 600;
    text-align: center;
    margin-bottom: 10px;
}

</style>


<div class="admin-container">

    <div class="admin-card">

        <div class="admin-title">
            <i class="bi bi-shield-lock-fill me-2"></i> Login Admin
        </div>

        <asp:Label ID="lblMensaje" runat="server" CssClass="msg-error"></asp:Label>

        <div class="input-group-admin">
            <label>Correo</label>
            <i class="bi bi-person-fill icon-admin"></i>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="input-admin" />
        </div>

        <div class="input-group-admin">
            <label>Contraseña</label>
            <i class="bi bi-key-fill icon-admin"></i>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password" CssClass="input-admin" />
        </div>

        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar"
            CssClass="btn-admin" OnClick="btnIngresar_Click" />

    </div>

</div>

</asp:Content>
