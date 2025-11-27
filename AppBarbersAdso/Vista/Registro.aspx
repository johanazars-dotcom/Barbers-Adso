<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Vista/Site1.Master"
    AutoEventWireup="true" CodeBehind="Registro.aspx.cs"
    Inherits="AppBarbersAdso.Vista.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css">

<style>

.registro-container {
    display: flex;
    justify-content: center;
    padding-top: 60px;
    padding-bottom: 60px;
}

.registro-card {
    background: rgba(15,15,15,0.85);
    border: 1px solid rgba(212,175,55,0.35);
    border-radius: 22px;
    padding: 40px 35px;
    width: 100%;
    max-width: 500px;
    backdrop-filter: blur(7px);
    box-shadow: 0 0 40px rgba(212,175,55,0.30);
    animation: fadeIn .9s ease;
    color: white;
}

@keyframes fadeIn {
    from {opacity: 0; transform: translateY(25px);}
    to   {opacity: 1; transform: translateY(0);}
}

.registro-title {
    text-align: center;
    font-size: 2.2rem;
    font-weight: 900;
    color: #d4af37;
    text-shadow: 0 0 15px rgba(212,175,55,.7);
    margin-bottom: 35px;
}

.form-label {
    font-weight: 600;
    color: #f6f6f6 !important;
}

.registro-group {
    margin-bottom: 25px;
    position: relative;
}

.registro-icon {
    position: absolute;
    left: 14px;
    top: 52%;
    transform: translateY(-50%);
    color: #d4af37;
    font-size: 1.2rem;
    pointer-events: none;
}

.registro-input {
    background: rgba(0,0,0,0.55);
    border: 1px solid #d4af37;
    border-radius: 10px;
    padding-left: 48px;
    height: 48px;
    color: white !important;
    transition: .30s;
}

.registro-input:focus {
    background: rgba(0,0,0,0.7);
    border: 1px solid #ffd86b;
    box-shadow: 0 0 14px rgba(212,175,55,.6);
}

.btn-registro {
    background: linear-gradient(90deg, #ffdf6b, #d4af37);
    border: none;
    border-radius: 14px;
    padding: 13px;
    font-weight: 800;
    color: black !important;
    font-size: 1.15rem;
    box-shadow: 0 0 25px rgba(255,215,0,.6);
    transition: .3s;
    letter-spacing: 0.5px;
}

.btn-registro:hover {
    transform: translateY(-3px);
    box-shadow: 0 0 35px rgba(255,215,0,1);
}

.btn-regresar {
    border-radius: 14px;
    font-weight: 600;
    padding: 12px;
}

.msg-registro {
    text-align: center;
    margin-top: 15px;
    font-weight: 700;
    color: #ffdf6b;
}

</style>


<div class="registro-container">

    <div class="registro-card">

        <h2 class="registro-title">
            <i class="bi bi-person-plus-fill me-2"></i> Registro de Usuario
        </h2>

        <!-- NOMBRE -->
        <div class="registro-group">
            <label class="form-label">Nombre</label>
            <i class="bi bi-person-fill registro-icon"></i>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control registro-input"></asp:TextBox>
        </div>

        <!-- APELLIDOS -->
        <div class="registro-group">
            <label class="form-label">Apellidos</label>
            <i class="bi bi-people-fill registro-icon"></i>
            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control registro-input"></asp:TextBox>
        </div>

        <!-- DOCUMENTO -->
        <div class="registro-group">
            <label class="form-label">Documento</label>
            <i class="bi bi-file-earmark-text-fill registro-icon"></i>
            <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control registro-input"></asp:TextBox>
        </div>

        <!-- EMAIL -->
        <div class="registro-group">
            <label class="form-label">Email</label>
            <i class="bi bi-envelope-fill registro-icon"></i>
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control registro-input"></asp:TextBox>
        </div>

        <!-- CONTRASEÑA -->
        <div class="registro-group">
            <label class="form-label">Contraseña</label>
            <i class="bi bi-key-fill registro-icon"></i>
            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" CssClass="form-control registro-input"></asp:TextBox>
        </div>

        <!-- TELÉFONO -->
        <div class="registro-group">
            <label class="form-label">Teléfono</label>
            <i class="bi bi-telephone-fill registro-icon"></i>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control registro-input"></asp:TextBox>
        </div>

        <div class="d-grid gap-2">
            <asp:Button ID="btnRegistrar" runat="server"
                Text="Registrarse"
                CssClass="btn-registro"
                OnClick="btnRegistrar_Click" />

            <asp:Button ID="btnRegresar" runat="server"
                Text="Iniciar Sesión"
                CssClass="btn btn-outline-warning btn-regresar"
                OnClick="btnRegresarLogin_Click" />
        </div>

        <asp:Label ID="lblResultado" runat="server" CssClass="msg-registro"></asp:Label>

    </div>

</div>


</asp:Content>
