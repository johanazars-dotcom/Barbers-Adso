<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="envioCorreo.aspx.cs"
    Inherits="AppBarbersAdso.Vista.envioCorreo"
    MasterPageFile="~/Vista/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css">

<style>

.recover-container {
    display: flex;
    justify-content: center;
    padding-top: 70px;
    padding-bottom: 70px;
}

.recover-card {
    background: rgba(15,15,15,0.85);
    border: 1px solid rgba(212,175,55,0.35);
    border-radius: 20px;
    padding: 40px 35px;
    width: 100%;
    max-width: 430px;
    backdrop-filter: blur(7px);
    box-shadow: 0 0 40px rgba(212,175,55,0.25);
    animation: fadeIn .8s ease;
    color: white;
    text-align: center;
}

@keyframes fadeIn {
    from { opacity: 0; transform: translateY(25px); }
    to { opacity: 1; transform: translateY(0); }
}

.recover-icon {
    font-size: 3.5rem;
    color: #d4af37;
    text-shadow: 0 0 15px rgba(212,175,55,.6);
    margin-bottom: 15px;
}

.recover-title {
    font-size: 1.9rem;
    font-weight: 800;
    color: #d4af37;
    margin-bottom: 10px;
}

.recover-text {
    color: #ccc;
    font-size: 0.95rem;
    margin-bottom: 25px;
}

.recover-group {
    position: relative;
    margin-bottom: 22px;
    text-align: left;
}

.recover-group label {
    font-weight: 600;
    color: #f5f5f5;
}

.recover-icon-input {
    position: absolute;
    left: 14px;
    top: 54%;
    transform: translateY(-50%);
    font-size: 1.2rem;
    color: #d4af37;
}

.recover-input {
    background: rgba(0,0,0,0.55);
    border: 1px solid #d4af37;
    border-radius: 10px;
    padding-left: 48px;
    height: 48px;
    color: white !important;
    transition: .25s ease;
}

.recover-input:focus {
    background: rgba(0,0,0,0.75);
    border-color: #ffd86b;
    box-shadow: 0 0 12px rgba(212,175,55,.55);
}

.btn-recover {
    width: 100%;
    background: linear-gradient(90deg, #ffdf6b, #d4af37);
    border: none;
    border-radius: 14px;
    padding: 12px;
    font-weight: 800;
    color: black !important;
    box-shadow: 0 0 22px rgba(255,215,0,.55);
    font-size: 1.1rem;
    transition: .3s ease;
}

.btn-recover:hover {
    transform: translateY(-3px);
    box-shadow: 0 0 32px rgba(255,215,0,1);
}

</style>


<div class="recover-container">

    <div class="recover-card">

        <i class="bi bi-shield-lock-fill recover-icon"></i>

        <h3 class="recover-title">Restablecer Contraseña</h3>

        <p class="recover-text">
            Ingresa tu correo electrónico para enviarte un código de recuperación.
        </p>

        <div class="recover-group">
            <label>Correo electrónico</label>
            <i class="bi bi-envelope-fill recover-icon-input"></i>
            <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email"
                CssClass="form-control recover-input"
                placeholder="ejemplo@correo.com" />
        </div>

        <asp:Button ID="btnEnviar" runat="server" Text="Enviar Código"
            CssClass="btn-recover" OnClick="btnEnviar_Click" />

    </div>

</div>

</asp:Content>
