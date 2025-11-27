<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistorialPuesto.aspx.cs" Inherits="Vista.HistorialPuesto" %>

<!DOCTYPE html>
<html>
<head>
    <title>Historial de Citas del Puesto</title>
</head>
<body>
    <h2>Historial de Citas del Puesto</h2>

    <form id="form1" runat="server">
        <asp:Label ID="lblPuesto" runat="server" Text="ID del Puesto: "></asp:Label>
        <asp:TextBox ID="txtIdPuesto" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Mostrar Historial" OnClick="btnBuscar_Click" />

        <br /><br />
        <asp:GridView ID="GridHistorial" runat="server" AutoGenerateColumns="false" BorderColor="Black" BorderWidth="1px">
            <Columns>
                <asp:BoundField DataField="IdCita" HeaderText="ID Cita" />
                <asp:BoundField DataField="IdUsuario" HeaderText="Usuario" />
                <asp:BoundField DataField="IdBarbero" HeaderText="Barbero" />
                <asp:BoundField DataField="Hora" HeaderText="Hora" />
                <asp:BoundField DataField="FechaCita" HeaderText="Fecha" />
                <asp:BoundField DataField="IdEstado" HeaderText="Estado" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
