<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinanzaV.aspx.cs" Inherits="AppBarbersAdso.Vista.FinanzaV" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>
