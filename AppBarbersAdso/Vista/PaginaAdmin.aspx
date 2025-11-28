<%@ Page Title="Panel Admin" Language="C#" MasterPageFile="~/Vista/Site1.master" 
    AutoEventWireup="true" CodeBehind="PaginaAdmin.aspx.cs" 
    Inherits="AppBarbersAdso.Vista.PaginaAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css">

<style>

.panel-container {
    margin-top: 50px;
    margin-bottom: 50px;
}

.panel-card {
    background: rgba(20,20,20,0.85);
    border: 1px solid rgba(212,175,55,0.35);
    border-radius: 18px;
    padding: 35px;
    box-shadow: 0 0 35px rgba(212,175,55,0.25);
    backdrop-filter: blur(6px);
    animation: fadeIn 1s ease;
}

@keyframes fadeIn {
    from { opacity:0; transform: translateY(20px); }
    to   { opacity:1; transform: translateY(0); }
}

.panel-title {
    font-size: 2.2rem;
    font-weight: 800;
    color: #d4af37;
    text-align: center;
    text-shadow: 0 0 15px rgba(212,175,55,0.55);
    margin-bottom: 35px;
}

.btn-panel {
    background: linear-gradient(90deg, #ffdb59, #d4af37);
    color: black !important;
    font-weight: 800;
    padding: 12px 20px;
    border: none;
    border-radius: 12px;
    box-shadow: 0 0 20px rgba(255,215,0,.6);
    transition: .3s;
}

.btn-panel:hover {
    transform: translateY(-3px);
    box-shadow: 0 0 28px rgba(255,215,0,.9);
}

/* TABLA PREMIUM */
.table-dark {
    background: rgba(15,15,15,0.88) !important;
    border: 1px solid rgba(212,175,55,0.3);
    border-radius: 10px;
    overflow: hidden;
}

.table-dark th {
    background: rgba(10,10,10,0.95) !important;
    color: #d4af37 !important;
    font-weight: 700;
    font-size: 1.1rem;
    padding: 14px;
    text-transform: uppercase;
    border-bottom: 2px solid rgba(212,175,55,0.4);
}

.table-dark td {
    padding: 12px;
    border-bottom: 1px solid rgba(212,175,55,0.18);
    vertical-align: middle;
}

.table-dark tbody tr:hover {
    background: rgba(212,175,55,0.12) !important;
}

/* Botones CRUD */
.btn-edit {
    border: 1px solid #0dcaf0;
    color: #0dcaf0;
    border-radius: 8px;
    padding: 6px 10px;
    transition: .2s;
}

.btn-edit:hover {
    background: #0dcaf0;
    color: #000 !important;
}

.btn-delete {
    border: 1px solid #dc3545;
    color: #dc3545;
    border-radius: 8px;
    padding: 6px 10px;
    transition: .2s;
}

.btn-delete:hover {
    background: #dc3545;
    color: #fff !important;
}

/* Foto circular */
.foto-barbero {
    width: 60px;
    height: 60px;
    border-radius: 50%;
    object-fit: cover;
    border: 2px solid #d4af37;
}

</style>


<div class="container panel-container">

    <div class="panel-card">

        <h2 class="panel-title">
            <i class="bi bi-tools me-2"></i> Panel de Administración
        </h2>

        <div class="text-center mb-5">
            <asp:Button
                ID="btnRegistrarBarbero"
                runat="server"
                Text="Registrar Barbero"
                CssClass="btn-panel"
                OnClick="btnRegistrarBarbero_Click" />
        </div>

        <h3 class="text-center text-warning fw-bold mb-4">
            Barberos Registrados
        </h3>

        <asp:GridView 
            ID="gvBarberos" 
            runat="server"
            CssClass="table table-dark table-hover text-center"
            AutoGenerateColumns="False"
            GridLines="None">

            <Columns>

                <asp:BoundField DataField="nombreBarbero" HeaderText="Nombre" />
                <asp:BoundField DataField="apellidoBarbero" HeaderText="Apellido" />
                <asp:BoundField DataField="numeroPuesto" HeaderText="Puesto" />
                <asp:BoundField DataField="documento" HeaderText="Documento" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="telefono" HeaderText="Teléfono" />

                <asp:TemplateField HeaderText="Foto">
                    <ItemTemplate>
                        <img src='<%# ResolveUrl("~/Vista/foto/" + Eval("foto")) %>'
                             class="foto-barbero" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Hoja de Vida">
                    <ItemTemplate>
                        <a href='<%# ResolveUrl("~/Vista/hojaVida/" + Eval("hojaVida")) %>'
                           target="_blank"
                           class="btn btn-sm btn-outline-warning fw-bold">
                            PDF
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <a href='ActualizarBarbero.aspx?id=<%# Eval("idBarbero") %>'
                           class="btn-edit"
                           title="Editar">
                            <i class="bi bi-pencil-square"></i>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <button type="button"
                                class="btn-delete"
                                onclick="ConfirmarEliminar(<%# Eval("idBarbero") %>)"
                                title="Eliminar">
                            <i class="bi bi-trash-fill"></i>
                        </button>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        <h3 class="text-center text-warning fw-bold mt-4 mb-3">
    Contratos
</h3>

<div class="table-responsive">
    <table class="table table-dark table-hover text-center">
        <thead>
            <tr>
                <th>PUESTO</th>
                <th>NOMBRE</th>
                <th>APELLIDO</th>
                <th>ESTADO CONTRATO</th>
                <th>TIPO</th>
                <th>ÚLTIMO PAGO</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpContratos" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("numeroPuesto") %></td>
                        <td><%# Eval("nombreBarbero") %></td>
                        <td><%# Eval("apellidoBarbero") %></td>
                        <td><%# Eval("estadoContrato") %></td>
                        <td><%# Eval("tipoContrato") %></td>
                        <td><%# Eval("ultimoPago") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</div>


        
        <div>
            <asp:GridView ID="gvPagos" runat="server" AutoGenerateColumns="False" CssClass="table table-dark">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="idFinanzas" />
                    <asp:BoundField HeaderText="Pago" DataField="pago" />
                    <asp:BoundField HeaderText="Puesto" DataField="idPuesto" />
                    <asp:BoundField HeaderText="Contrato" DataField="idContrato" />
                    <asp:BoundField HeaderText="Administrador" DataField="idAdministrador" />
                </Columns>
            </asp:GridView>

        </div>
    

    </div>
</div>


<script>
    function ConfirmarEliminar(id) {
        var r = confirm("¿Eliminar este barbero?");
        if (r) {
            window.location = "PaginaAdmin.aspx?eliminar=" + id;
        }
    }
</script>

</asp:Content>
