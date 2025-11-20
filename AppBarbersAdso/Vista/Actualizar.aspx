<<<<<<< HEAD
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Actualizar.aspx.cs" Inherits="AppBarbersAdso.Vista.Actualizar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Actualizar Datos</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Actualizar Perfil</h2>

        <asp:Label runat="server" Text="Nombre:"></asp:Label><br />
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><br /><br />

        <asp:Label runat="server" Text="Apellido:"></asp:Label><br />
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox><br /><br />

        <asp:Label runat="server" Text="Teléfono:"></asp:Label><br />
        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox><br /><br />

        <asp:Label runat="server" Text="Documento:"></asp:Label><br />
        <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox><br /><br />

        <asp:Label runat="server" Text="Contraseña:"></asp:Label><br />
        <asp:TextBox ID="txtContra" TextMode="Password" runat="server"></asp:TextBox><br /><br />

        <asp:Button ID="btnActualizar" runat="server" Text="Guardar Cambios" OnClick="btnActualizar_Click" /><br /><br />
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </form>
</body>
</html>
=======
﻿<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Vista/Site1.Master"
    CodeBehind="Actualizar.aspx.cs"
    Inherits="AppBarbersAdso.Vista.Actualizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-5">

                <div class="card shadow">
                    <div class="card-header bg-dark text-warning text-center">
                        <h4 class="mb-0">Actualizar Perfil</h4>
                    </div>

                    <div class="card-body">

                        <div class="mb-3">
                            <asp:Label runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" Text="Apellido" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" Text="Teléfono" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" Text="Documento" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" Text="Contraseña" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtContra" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="d-grid">
                            <asp:Button ID="btnActualizar" runat="server"
                                Text="Guardar Cambios"
                                CssClass="btn btn-warning fw-bold"
                                OnClick="btnActualizar_Click" />
                        </div>

                        <div class="text-center mt-3">
                            <asp:Label ID="lblMensaje" runat="server" CssClass="text-success"></asp:Label>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
>>>>>>> salazar
