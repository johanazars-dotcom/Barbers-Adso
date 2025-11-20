<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Citas.aspx.cs" Inherits="TuProyecto.Citas" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Citas</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
<form runat="server" class="container mt-4">

    <h2 class="text-center mb-4">Agendar Cita</h2>

    <asp:HiddenField ID="hfIdCita" runat="server" />

    <div class="mb-3">
        <label>Nombre del cliente:</label>
        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label>Fecha:</label>
        <asp:TextBox ID="txtFecha" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label>Hora:</label>
        <asp:TextBox ID="txtHora" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-success w-100"
        runat="server" OnClick="btnGuardar_Click" />

    <hr />

    <asp:GridView ID="gvCitas" runat="server" CssClass="table table-bordered mt-3"
        AutoGenerateColumns="False"
        OnRowCommand="gvCitas_RowCommand">
        <Columns>

            <asp:BoundField DataField="idCita" HeaderText="ID" />
            <asp:BoundField DataField="nombreCliente" HeaderText="Cliente" />
            <asp:BoundField DataField="fechaCita" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="hora" HeaderText="Hora" />

            <asp:ButtonField Text="Editar" CommandName="editar" ControlStyle-CssClass="btn btn-primary btn-sm" />
            <asp:ButtonField Text="Eliminar" CommandName="eliminar" ControlStyle-CssClass="btn btn-danger btn-sm" />

        </Columns>
    </asp:GridView>

</form>
</body>
</html>
