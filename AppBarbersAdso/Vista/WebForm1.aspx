<%@ Page Title="Login" Language="C#" MasterPageFile="~/Vista/Site1.master" 
    AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" 
    Inherits="AppBarbersAdso.Vista.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css">

<style>

.login-page {
    display: flex;
    justify-content: center;
    align-items: center;
    min-height: 90vh;
    padding: 40px 0;
}

.login-card {
    width: 100%;
    max-width: 430px;
    background: rgba(15, 15, 15, 0.88);
    border-radius: 22px;
    padding: 45px 35px;
    border: 1px solid rgba(212,175,55,0.35);
    box-shadow: 0 0 40px rgba(212,175,55,0.25);
    backdrop-filter: blur(8px);
    animation: fadeIn .9s ease;
    color: white;
}

@keyframes fadeIn {
    from {opacity: 0; transform: translateY(30px);}
    to   {opacity: 1; transform: translateY(0);}
}

.login-title {
    font-size: 2.2rem;
    color: #d4af37;
    text-align: center;
    margin-bottom: 30px;
    font-weight: 800;
    text-shadow: 0 0 12px rgba(212,175,55,.5);
}

.input-group-custom {
    position: relative;
    margin-bottom: 28px;
}

.input-group-custom label {
    font-size: 1rem;
    font-weight: 600;
    color: #f1f1f1;
    margin-bottom: 6px;
    display: block;
}

.input-icon {
    position: absolute;
    left: 14px;
    top: 50%;
    transform: translateY(5%);
    font-size: 1.3rem;
    color: #d4af37;
    pointer-events: none;
}

.form-control-custom {
    width: 100%;
    background: rgba(0,0,0,0.55);
    border: 1px solid #d4af37;
    border-radius: 12px;
    color: white !important;
    padding: 12px 15px 12px 50px;
    font-size: 1.05rem;
    height: 50px;
    outline: none;
    transition: .3s ease;
}

.form-control-custom:focus {
    background: rgba(0,0,0,0.75);
    border: 1px solid #ffda63;
    box-shadow: 0 0 15px rgba(212,175,55,.55);
}

.btn-login {
    width: 100%;
    background: linear-gradient(90deg, #ffdf6b, #d4af37);
    border: none;
    border-radius: 14px;
    padding: 12px;
    font-weight: 800;
    font-size: 1.1rem;
    color: black !important;
    margin-top: 8px;
    box-shadow: 0 0 20px rgba(255,215,0,.55);
    transition: .3s ease;
}

.btn-login:hover {
    transform: translateY(-3px);
    box-shadow: 0 0 28px rgba(255,215,0,.95);
}

.btn-register {
    width: 100%;
    padding: 12px;
    border-radius: 14px;
    font-weight: 600;
    margin-top: 10px;
}

.forgot-link {
    display: block;
    text-align: center;
    margin-top: 18px;
    color: #ffdf6b;
    font-weight: 500;
    text-decoration: none;
    transition: .3s;
}

.forgot-link:hover {
    color: white;
    text-shadow: 0 0 12px #d4af37;
}

</style>



<div class="login-page">

    <div class="login-card">

        <div class="login-title">
            <i class="bi bi-person-fill-lock me-2"></i> Iniciar Sesión
        </div>

        <div class="input-group-custom">
            <label>Correo</label>
            <i class="bi bi-envelope-fill input-icon"></i>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control-custom" />
        </div>

        <div class="input-group-custom">
            <label>Contraseña</label>
            <i class="bi bi-key-fill input-icon"></i>
            <asp:TextBox ID="txtContra" runat="server" TextMode="Password" CssClass="form-control-custom" />
        </div>

        <asp:Button ID="btnLogin" runat="server" Text="Ingresar"
            CssClass="btn-login" OnClick="btnLogin_Click" />

        <asp:Button ID="btnRegistroCliente" runat="server" Text="Registrarse"
            CssClass="btn btn-outline-light btn-register"
            OnClick="btnRegistro_Click" />

        <a href="envioCorreo.aspx" class="forgot-link">¿Olvidaste tu contraseña?</a>

        <asp:Label ID="lblMensaje" runat="server" 
            CssClass="text-danger mt-3 d-block text-center"></asp:Label>

    </div>

</div>

</asp:Content>
