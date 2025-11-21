<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistorialPuesto.aspx.cs" Inherits="Vista.HistorialPuesto" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Historial de Citas del Puesto</title>
</head>
<body>
    <h2>Historial de Citas del Puesto</h2>
    <form id="form1" runat="server">
        <asp:Label ID="lblPuesto" runat="server" Text="ID del Puesto: "></asp:Label>
        <asp:TextBox ID="txtIdPuesto" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Mostrar Historial" OnClick="btnBuscar_Click" />

        <br /><br />
        <asp:GridView ID="GridHistorial" runat="server" AutoGenerateColumns="false" BorderColor="Black" BorderWidth="1px" CellPadding="5">
            <Columns>
                <asp:BoundField DataField="idCita" HeaderText="ID Cita" />
                <asp:BoundField DataField="idUsuario" HeaderText="ID Usuario" />
                <asp:BoundField DataField="idBarbero" HeaderText="ID Barbero" />
                <asp:BoundField DataField="hora" HeaderText="Hora" />
                <asp:BoundField DataField="fechaCita" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                </Columns>
        </asp:GridView>
    </form>
</body>
</html>