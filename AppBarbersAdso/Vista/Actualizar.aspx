<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Vista/Site1.Master"
    CodeBehind="Actualizar.aspx.cs"
    Inherits="AppBarbersAdso.Vista.Actualizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css">

<style>

.update-container {
    display: flex;
    justify-content: center;
    padding-top: 60px;
    padding-bottom: 60px;
}

.update-card {
    background: rgba(15,15,15,0.85);
    border: 1px solid rgba(212,175,55,0.35);
    border-radius: 20px;
    padding: 40px 30px;
    width: 100%;
    max-width: 480px;
    backdrop-filter: blur(6px);
    box-shadow: 0 0 35px rgba(212,175,55,0.25);
    animation: fadeIn 0.9s ease;
    color: white;
}

@keyframes fadeIn {
    from { opacity: 0; transform: translateY(25px); }
    to { opacity: 1; transform: translateY(0); }
}

.update-title {
    text-align: center;
    font-size: 2rem;
    font-weight: 800;
    color: #d4af37;
    text-shadow: 0 0 12px rgba(212,175,55,.6);
    margin-bottom: 25px;
}

.form-label {
    font-weight: 600;
    color: #f1f1f1 !important;
}

.update-group {
    margin-bottom: 22px;
    position: relative;
}

.update-icon {
    position: absolute;
    left: 14px;
    top: 52%;
    transform: translateY(-50%);
    font-size: 1.2rem;
    color: #d4af37;
    pointer-events: none;
}

.update-input {
    background: rgba(0,0,0,0.55);
    border: 1px solid #d4af37;
    border-radius: 10px;
    height: 48px;
    padding-left: 45px;
    color: white !important;
    transition: .25s ease;
}

.update-input:focus {
    border: 1px solid #ffd86b;
    background: rgba(0,0,0,0.75);
    box-shadow: 0 0 12px rgba(212,175,55,.55);
}

.btn-update {
    background: linear-gradient(90deg, #ffdf6b, #d4af37);
    border: none;
    border-radius: 12px;
    padding: 12px;
    font-weight: 800;
    color: black !important;
    box-shadow: 0 0 20px rgba(255,215,0,.6);
    font-size: 1.1rem;
    transition: .3s ease;
}

.btn-update:hover {
    transform: translateY(-3px);
    box-shadow: 0 0 30px rgba(255,215,0,1);
}

.msg {
    text-align: center;
    margin-top: 12px;
    font-weight: 600;
}

</style>


<div class="update-container">

    <div class="update-card">

        <div class="update-title">
            <i class="bi bi-person-lines-fill me-2"></i> Actualizar Perfil
        </div>

        
        <div class="update-group">
            <label class="form-label">Nombre</label>
            <i class="bi bi-person-fill update-icon"></i>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control update-input"></asp:TextBox>
        </div>

        
        <div class="update-group">
            <label class="form-label">Apellido</label>
            <i class="bi bi-person-badge-fill update-icon"></i>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control update-input"></asp:TextBox>
        </div>

   
        <div class="update-group">
            <label class="form-label">Teléfono</label>
            <i class="bi bi-telephone-fill update-icon"></i>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control update-input"></asp:TextBox>
        </div>

        <div class="update-group">
            <label class="form-label">Documento</label>
            <i class="bi bi-file-earmark-text-fill update-icon"></i>
            <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control update-input"></asp:TextBox>
        </div>

        
        <div class="update-group">
            <label class="form-label">Contraseña</label>
            <i class="bi bi-key-fill update-icon"></i>
            <asp:TextBox ID="txtContra" runat="server" CssClass="form-control update-input"></asp:TextBox>
        </div>

       
        <div class="d-grid">
            <asp:Button ID="btnActualizar" runat="server"
                Text="Guardar Cambios" CssClass="btn-update"
                OnClick="btnActualizar_Click" />
        </div>

        
        <asp:Label ID="lblMensaje" runat="server" CssClass="msg text-success"></asp:Label>

    </div>

</div>

</asp:Content>
