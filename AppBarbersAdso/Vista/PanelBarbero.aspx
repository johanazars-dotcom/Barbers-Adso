<%@ Page Title="Panel Barbero" Language="C#" 
    MasterPageFile="~/Vista/Site1.master"
    AutoEventWireup="true" 
    CodeBehind="PanelBarbero.aspx.cs" 
    Inherits="AppBarbersAdso.Vista.PanelBarbero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" 
      href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css">

<style>

.barber-panel-container {
    padding-top: 50px;
    padding-bottom: 50px;
}

.barber-panel-card {
    background: rgba(15,15,15,0.82);
    border: 1px solid rgba(212,175,55,0.35);
    border-radius: 18px;
    padding: 35px;
    backdrop-filter: blur(6px);
    box-shadow: 0 0 35px rgba(212,175,55,.25);
    animation: fadeIn .9s ease;
}

@keyframes fadeIn {
    from { opacity: 0; transform: translateY(25px); }
    to   { opacity: 1; transform: translateY(0); }
}

.barber-title {
    color: #d4af37;
    text-align: center;
    font-weight: 900;
    font-size: 2.3rem;
    text-shadow: 0 0 14px rgba(212,175,55,.65);
    margin-bottom: 30px;
}

.barber-subtitle {
    text-align: center;
    font-size: 1.3rem;
    color: #f0e6c8;
    margin-bottom: 25px;
}

.table-citas {
    background: rgba(15,15,15,0.90) !important;
    border: 1px solid rgba(212,175,55,0.3);
    color: white !important;
    border-radius: 10px;
    overflow: hidden;
}

.table-citas th {
    background: rgba(0,0,0,0.85) !important;
    color: #d4af37 !important;
    padding: 12px;
    text-transform: uppercase;
    font-weight: 700;
    border-bottom: 2px solid rgba(212,175,55,0.4);
}

.table-citas td {
    padding: 12px;
    border-bottom: 1px solid rgba(212,175,55,0.15);
}

.table-citas tbody tr:hover {
    background: rgba(212,175,55,0.15) !important;
    transition: .2s;
}

.empty-text {
    color: #ffd86b;
    text-align: center;
    font-weight: bold;
    padding-top: 20px;
}

</style>


<div class="container barber-panel-container">

    <div class="barber-panel-card">

        <h2 class="barber-title">
            <i class="bi bi-scissors me-2"></i> Panel del Barbero
        </h2>

        <h4 class="barber-subtitle">
            <i class="bi bi-calendar-check me-2"></i> Mis Citas Asignadas
        </h4>

        <asp:GridView 
            ID="gvCitasBarbero"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="table table-citas table-hover text-center"
            EmptyDataText="No tienes citas asignadas.">

            <Columns>

                <asp:BoundField DataField="nombreUsuario" HeaderText="Cliente" />
                <asp:BoundField DataField="fechaCita" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="hora" HeaderText="Hora" />
                <asp:BoundField DataField="nombrePuesto" HeaderText="Puesto" />

            </Columns>

        </asp:GridView>

    </div>

</div>

</asp:Content>
