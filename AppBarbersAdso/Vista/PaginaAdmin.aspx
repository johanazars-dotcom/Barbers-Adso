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

<div class="contratos-container mt-3">
    
    <div class="row contratos-header text-uppercase fw-bold text-warning text-center">
        <div class="col-2">PUESTO</div>
        <div class="col-3">BARBERO</div>
        <div class="col-2">ESTADO</div>
        <div class="col-2">TIPO</div>
        <div class="col-2">ÚLTIMO PAGO</div>
        <div class="col-1">ACCIONES</div>
    </div>

  
    <asp:Repeater ID="rpContratos" runat="server" OnItemCommand="rpContratos_ItemCommand">
        <ItemTemplate>
            <div class="row contratos-row text-center align-items-center">
                <div class="col-2">
                    <%# Eval("numeroPuesto") %>
                </div>

                <div class="col-3">
                    <%# Eval("nombreBarbero") %> <%# Eval("apellidoBarbero") %>
                </div>

                <div class="col-2">
                    <%# Eval("estadoContrato") %>
                </div>

                <div class="col-2">
                    <%# Eval("tipoContrato") %>
                </div>

                <div class="col-2">
                    <%# Eval("ultimoPago") %>
                </div>

                <div class="col-1">
                    
                    <asp:PlaceHolder ID="phAcciones" runat="server"
                        Visible='<%# Convert.ToInt32(Eval("idContrato")) > 0 %>'>

                        <asp:LinkButton ID="btnEditarContrato" runat="server"
                            CommandName="Editar"
                            CommandArgument='<%# Eval("idContrato") %>'
                            CssClass="btn btn-sm btn-outline-info me-1"
                            ToolTip="Editar contrato">
                            <i class="bi bi-pencil"></i>
                        </asp:LinkButton>

                        <asp:LinkButton ID="btnEliminarContrato" runat="server"
                            CommandName="Eliminar"
                            CommandArgument='<%# Eval("idContrato") %>'
                            CssClass="btn btn-sm btn-outline-danger"
                            ToolTip="Eliminar contrato"
                            OnClientClick="return confirm('¿Seguro que deseas eliminar este contrato?');">
                            <i class="bi bi-trash"></i>
                        </asp:LinkButton>

                    </asp:PlaceHolder>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>

<div class="contrato-edicion mt-4">
    <asp:Panel ID="pnlEditarContrato" runat="server" Visible="false" CssClass="contrato-edit-panel">
        <h4 class="text-warning fw-bold mb-3">Editar contrato</h4>

        <asp:HiddenField ID="hfIdContrato" runat="server" />

        <div class="row mb-3">
            <div class="col-md-4 mb-3">
                <label class="form-label text-light">Estado</label>
                <asp:DropDownList ID="ddlEstadoContrato" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Activo" Value="Activo" />
                    <asp:ListItem Text="No activo" Value="No activo" />
                    <asp:ListItem Text="Finalizado" Value="Finalizado" />
                </asp:DropDownList>
            </div>

            <div class="col-md-4 mb-3">
                <label class="form-label text-light">Tipo</label>
                <asp:DropDownList ID="ddlTipoContrato" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Fijo" Value="Fijo" />
                    <asp:ListItem Text="Temporal" Value="Temporal" />
                </asp:DropDownList>
            </div>

            <div class="col-md-4 mb-3">
                <label class="form-label text-light">Último pago</label>
                <asp:TextBox ID="txtUltimoPago" runat="server" CssClass="form-control" />
            </div>
        </div>

        <asp:Button ID="btnGuardarContrato" runat="server"
            Text="Guardar cambios"
            CssClass="btn btn-warning me-2"
            OnClick="btnGuardarContrato_Click" />

        <asp:Button ID="btnCancelarEdicion" runat="server"
            Text="Cancelar"
            CssClass="btn btn-outline-light"
            OnClick="btnCancelarEdicion_Click" />
    </asp:Panel>
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
