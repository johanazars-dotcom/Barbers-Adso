<%@ Page Title="Actualizar Barbero" Language="C#" MasterPageFile="~/Vista/Site1.master"
    AutoEventWireup="true" CodeBehind="ActualizarBarbero.aspx.cs" Inherits="AppBarbersAdso.Vista.ActualizarBarbero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card card-barber shadow-lg p-4 rounded-4 col-md-6 mx-auto">

        <h2 class="text-center text-warning mb-4">Actualizar Perfil del Barbero</h2>

        <div class="mb-3">
            <label>Nombre del Barbero:</label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label>Apellido:</label>
            <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label>Teléfono:</label>
            <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label>Documento:</label>
            <asp:TextBox ID="txtDocumento" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label>Email:</label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label>Contraseña:</label>
            <asp:TextBox ID="txtContra" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label>Puesto:</label>
            <asp:DropDownList ID="ddlPuesto" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>

        <div class="text-center mt-4">
            <asp:Button ID="btnActualizar" runat="server" Text="Guardar Cambios"
                CssClass="btn btn-dorado px-4"
                OnClick="btnActualizar_Click" />
        </div>

        <asp:Label ID="lblMensaje" CssClass="text-center mt-3 text-warning" runat="server"></asp:Label>

    </div>

</asp:Content>
