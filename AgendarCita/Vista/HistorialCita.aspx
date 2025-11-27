<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistorialCitas.aspx.cs" Inherits="Vista.HistorialCitas" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Historial de Citas</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Historial de Citas</h2>

        <asp:GridView ID="gvHistorial" runat="server" AutoGenerateColumns="False" BorderWidth="1" CellPadding="5">
            <Columns>
                <asp:BoundField DataField="IdCita" HeaderText="ID Cita" />
                <asp:BoundField DataField="IdBarbero" HeaderText="Barbero" />
                <asp:BoundField DataField="idPuesto" HeaderText="Puesto" />
                <asp:BoundField DataField="hora" HeaderText="Hora" />
                <asp:BoundField DataField="FechaCita" HeaderText="Fecha" />
                <asp:BoundField DataField="IdEstado" HeaderText="Estado" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
