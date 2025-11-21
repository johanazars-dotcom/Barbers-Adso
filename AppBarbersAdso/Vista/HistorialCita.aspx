<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistorialCitas.aspx.cs" Inherits="Vista.HistorialCitas" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Historial de Citas Clientes</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Historial de Citas</h2>

        <asp:GridView ID="gvHistorial" runat="server" AutoGenerateColumns="False" BorderWidth="1" CellPadding="5">
            <Columns>
                <asp:BoundField DataField="idCita" HeaderText="ID Cita" />
                <asp:BoundField DataField="idBarbero" HeaderText="ID Barbero" /> 
                <asp:BoundField DataField="idPuesto" HeaderText="ID Puesto" /> 
                <asp:BoundField DataField="hora" HeaderText="Hora" />
                <%-- DataField='fechaCita' debe coincidir con la propiedad del modelo --%>
                <asp:BoundField DataField="fechaCita" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" /> 
                <%-- Eliminada la columna de Estado --%>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>