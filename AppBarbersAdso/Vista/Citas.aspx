<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Citas.aspx.cs" 
    Inherits="AppBarbersAdso.Vista.Citas"
    MasterPageFile="~/Vista/Site1.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

        <h2 class="text-center mb-4 gold fw-bold">Agendar Cita</h2>

        <asp:HiddenField ID="hfIdCita" runat="server" />
        <asp:HiddenField ID="hfUsuario" runat="server" />

        <div class="card card-barber p-4">

            <div class="mb-3">
                <label class="text-white fw-bold">Barbero:</label>
                <asp:DropDownList ID="ddlBarbero" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>

             <div class="mb-3">
                <label class="text-white fw-bold">Fecha:</label>
                <asp:TextBox ID="txtFecha" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="text-white fw-bold">Hora:</label>
                <asp:TextBox ID="txtHora" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="btnGuardar" Text="Guardar Cita" CssClass="btn btn-dorado w-100 fw-bold"
                runat="server" OnClick="btnGuardar_Click" />

        </div>

        <hr class="border-warning" />

        <h3 class="text-center gold fw-bold mb-3">Mis Citas</h3>

        <asp:GridView 
            ID="gvCitas" 
            runat="server" 
            CssClass="table table-dark table-bordered text-center"
            AutoGenerateColumns="False"
            DataKeyNames="idCita"
            OnRowCommand="gvCitas_RowCommand">

            <Columns>

                <asp:BoundField DataField="nombreUsuario" HeaderText="Usuario" />

                <asp:BoundField DataField="nombreBarbero" HeaderText="Barbero" />

                <asp:BoundField DataField="nombrePuesto" HeaderText="Puesto" />

                <asp:BoundField DataField="fechaCita" HeaderText="Fecha"
                    DataFormatString="{0:yyyy-MM-dd}" />

                <asp:BoundField DataField="hora" HeaderText="Hora" />

                <asp:ButtonField Text="Editar" CommandName="editar"
                    ControlStyle-CssClass="btn btn-outline-info btn-sm" />

                <asp:ButtonField Text="Eliminar" CommandName="eliminar"
                    ControlStyle-CssClass="btn btn-outline-danger btn-sm" />

            </Columns>

        </asp:GridView>

    </div>

</asp:Content>
