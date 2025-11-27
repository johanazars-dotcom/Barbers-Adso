<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Citas.aspx.cs" 
    Inherits="AppBarbersAdso.Vista.Citas"
    MasterPageFile="~/Vista/Site1.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css" />

<style>

.card-barbero {
    background: rgba(20,20,20,0.80);
    border-radius: 15px;
    border: 1px solid rgba(212,175,55,0.2);
    box-shadow: 0 0 25px rgba(212,175,55,0.18);
    padding: 30px;
    backdrop-filter: blur(4px);
    color: #ddd;
    transition: .3s ease;
}

.card-barbero:hover {
    box-shadow: 0 0 35px rgba(212,175,55,0.35);
    transform: translateY(-4px);
}

label {
    font-size: 1.05rem;
    color: #f8f8f8;
}

.form-control {
    background: rgba(0,0,0,0.55);
    border: 1px solid #d4af37;
    color: white !important;
    border-radius: 8px;
    font-size: 1rem;
    padding: 10px 12px;
}

.form-control:focus {
    border: 1px solid #ffd86b;
    box-shadow: 0 0 10px rgba(212,175,55,0.5);
    background: rgba(0,0,0,0.7);
}

input[type="date"]::-webkit-calendar-picker-indicator,
input[type="time"]::-webkit-calendar-picker-indicator {
    filter: brightness(0) invert(1); 
    opacity: 1;
}


.btn-dorado {
    background: linear-gradient(90deg, #ffdb59, #d4af37);
    color: black;
    font-weight: 800;
    border-radius: 12px;
    padding: 12px;
    font-size: 1.1rem;
    border: none;
    box-shadow: 0 0 18px rgba(255,215,0,.5);
    transition: .3s ease;
    letter-spacing: .5px;
}

.btn-dorado:hover {
    background: #d4af37;
    box-shadow: 0 0 25px rgba(255,215,0,.9);
    transform: translateY(-3px);
}

.table-dark {
    border-radius: 10px;
    overflow: hidden;
    background: rgba(15,15,15,0.85) !important;
    border: 1px solid rgba(212,175,55,0.2);
}

.table-dark th {
    background: #000 !important;
    color: #d4af37 !important;
    font-size: 1.1rem;
    text-transform: uppercase;
    letter-spacing: 1px;
    padding: 14px;
    border-bottom: 2px solid rgba(212,175,55,0.3);
}

.table-dark td {
    padding: 12px;
    vertical-align: middle;
    border-bottom: 1px solid rgba(212,175,55,0.15);
}

.table-dark tbody tr:hover {
    background: rgba(212,175,55,0.15) !important;
    color: white;
    cursor: pointer;
    transition: .2s ease-in-out;
}

.btn-outline-info,
.btn-outline-danger {
    font-weight: bold;
    border-radius: 8px;
}

.btn-outline-info:hover {
    background: #0dcaf0;
    color: #000 !important;
}

.btn-outline-danger:hover {
    background: #dc3545;
    color: #fff !important;
}

</style>


<div class="container mt-5 mb-5">

    <h2 class="text-center mb-5 gold fw-bold display-5">
        <i class="bi bi-calendar2-check me-2"></i> Agendar Cita
    </h2>

    <asp:HiddenField ID="hfIdCita" runat="server" />
    <asp:HiddenField ID="hfUsuario" runat="server" />

    <div class="card-barbero mb-5">

        <div class="mb-3">
            <label class="fw-bold"><i class="bi bi-person-bounding-box me-2 gold"></i>Barbero:</label>
            <asp:DropDownList ID="ddlBarbero" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>

        <div class="mb-3">
            <label class="fw-bold"><i class="bi bi-calendar-event me-2 gold"></i>Fecha:</label>
            <asp:TextBox ID="txtFecha" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label class="fw-bold"><i class="bi bi-clock me-2 gold"></i>Hora:</label>
            <asp:TextBox ID="txtHora" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <asp:Button ID="btnGuardar" Text="Guardar Cita" CssClass="btn btn-dorado w-100 mt-3"
            runat="server" OnClick="btnGuardar_Click" />

    </div>

    <hr class="border-warning mb-4" />

    <h3 class="text-center gold fw-bold mb-4 display-6">
        <i class="bi bi-list-check me-2"></i> Mis Citas
    </h3>

    <asp:GridView 
        ID="gvCitas" 
        runat="server" 
        CssClass="table table-dark table-hover text-center"
        AutoGenerateColumns="False"
        DataKeyNames="idCita"
        OnRowCommand="gvCitas_RowCommand">

        <Columns>
            <asp:BoundField DataField="nombreUsuario" HeaderText="Usuario" />
            <asp:BoundField DataField="nombreBarbero" HeaderText="Barbero" />
            <asp:BoundField DataField="nombrePuesto" HeaderText="Puesto" />
            <asp:BoundField DataField="fechaCita" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="hora" HeaderText="Hora" />

            <asp:ButtonField Text="Editar" CommandName="editar"
                ControlStyle-CssClass="btn btn-outline-info btn-sm" />

            <asp:ButtonField Text="Eliminar" CommandName="eliminar"
                ControlStyle-CssClass="btn btn-outline-danger btn-sm" />
        </Columns>

    </asp:GridView>

</div>

</asp:Content>
