<%@ Page Title="Restablecer Contraseña" Language="C#" 
    MasterPageFile="~/Vista/Site1.Master"
    AutoEventWireup="true" 
    CodeBehind="recuperacion.aspx.cs" 
    Inherits="AppBarbersAdso.Vista.recuperacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css">

<style>

.recoverpass-container {
    display: flex;
    justify-content: center;
    align-items: center;
    padding-top: 70px;
    padding-bottom: 70px;
}

.recoverpass-card {
    background: rgba(15,15,15,0.85);
    border-radius: 20px;
    border: 1px solid rgba(212,175,55,0.35);
    padding: 40px 35px;
    width: 100%;
    max-width: 430px;
    backdrop-filter: blur(6px);
    box-shadow: 0 0 40px rgba(212,175,55,.25);
    animation: fadeIn .8s ease;
    color: white;
    text-align: center;
}

@keyframes fadeIn {
    from {opacity: 0; transform: translateY(25px);}
    to   {opacity: 1; transform: translateY(0);}
}

.recoverpass-icon {
    font-size: 3.5rem;
    color: #d4af37;
    text-shadow: 0 0 15px rgba(212,175,55,.6);
    margin-bottom: 12px;
}

.recoverpass-title {
    color: #d4af37;
    font-weight: 800;
    font-size: 1.9rem;
    margin-bottom: 10px;
}

.recoverpass-text {
    color: #ccc;
    font-size: 0.95rem;
    margin-bottom: 25px;
}

.group-recoverpass {
    position: relative;
    margin-bottom: 25px;
    text-align: left;
}

.group-recoverpass label {
    color: #eee;
    font-weight: 600;
}

.recoverpass-input-icon {
    position: absolute;
    left: 14px;
    top: 54%;
    transform: translateY(-50%);
    font-size: 1.2rem;
    color: #d4af37;
}

.recoverpass-input {
    background: rgba(0,0,0,0.55);
    border: 1px solid #d4af37;
    border-radius: 10px;
    height: 48px;
    padding-left: 48px;
    color: white !important;
    transition: .25s ease;
}

.recoverpass-input:focus {
    background: rgba(0,0,0,0.75);
    border-color: #ffd86b;
    box-shadow: 0 0 12px rgba(212,175,55,.55);
}

.btn-recoverpass {
    width: 100%;
    background: linear-gradient(90deg, #ffdf6b, #d4af37);
    border: none;
    border-radius: 14px;
    padding: 12px;
    font-weight: 800;
    font-size: 1.1rem;
    color: black !important;
    box-shadow: 0 0 22px rgba(255,215,0,.55);
    transition: .3s ease;
}

.btn-recoverpass:hover {
    transform: translateY(-3px);
    box-shadow: 0 0 32px rgba(255,215,0,1);
}

.msg-recoverpass {
    margin-top: 15px;
    font-weight: 600;
    text-align: center;
    color: #ffd86b;
}

</style>


<div class="recoverpass-container">

    <div class="recoverpass-card">

        <i class="bi bi-lock-fill recoverpass-icon"></i>

        <h3 class="recoverpass-title">Restablecer Contraseña</h3>

        <p class="recoverpass-text">
            Ingresa tu nueva contraseña para completar el proceso.
        </p>

        <!-- Token oculto -->
        <asp:HiddenField ID="hfToken" runat="server" />

        <div class="group-recoverpass">
            <label>Nueva contraseña</label>
            <i class="bi bi-key-fill recoverpass-input-icon"></i>
            <asp:TextBox ID="txtNuevaPass" runat="server" TextMode="Password"
                CssClass="form-control recoverpass-input"
                placeholder="Ingresa tu nueva contraseña"></asp:TextBox>
        </div>

        <asp:Button ID="btnGuardar" runat="server"
            Text="Guardar Contraseña"
            CssClass="btn-recoverpass"
            OnClick="btnGuardar_Click" />

        <asp:Label ID="lblMsg" runat="server" CssClass="msg-recoverpass"></asp:Label>

    </div>

</div>

</asp:Content>
