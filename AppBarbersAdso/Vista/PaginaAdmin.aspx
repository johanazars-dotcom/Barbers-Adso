<%@ Page Title="Panel Admin" Language="C#" MasterPageFile="~/Vista/Site1.master"
    AutoEventWireup="true" CodeBehind="PaginaAdmin.aspx.cs" Inherits="AppBarbersAdso.Vista.PaginaAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card card-barber shadow-lg p-4 rounded-4">

        <div class="card card-barber p-4 col-md-6 mx-auto text-center">
            <h2 class="text-warning mb-4">Panel de Registro</h2>

            <asp:Button
                ID="btnRegistrarBarbero"
                runat="server"
                Text="Registrar Barbero"
                CssClass="btn btn-dorado"
                OnClick="btnRegistrarBarbero_Click" />
        </div>

        <br />

        <h3 class="text-center mb-4" style="color: #d4af37;">Listado de Barberos Registrados</h3>

        <asp:GridView ID="gvBarberos" runat="server" CssClass="table table-dark table-bordered text-center"
            AutoGenerateColumns="False">
            <Columns>

                <asp:BoundField DataField="idBarbero" HeaderText="ID" />
                <asp:BoundField DataField="nombreBarbero" HeaderText="Nombre" />
                <asp:BoundField DataField="apellidoBarbero" HeaderText="Apellido" />
                <asp:BoundField DataField="documento" HeaderText="Documento" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="telefono" HeaderText="Teléfono" />

                <asp:TemplateField HeaderText="Foto">
                    <ItemTemplate>
                        <img src='<%# ResolveUrl("~/Vista/foto/" + Eval("foto")) %>'
                             width="60" height="60"
                             style="border-radius:50%; object-fit:cover;" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Hoja de Vida">
                    <ItemTemplate>
                        <a href='<%# ResolveUrl("~/Vista/hojaVida/" + Eval("hojaVida")) %>'
                           target="_blank"
                           class="btn btn-sm btn-outline-warning">
                            Ver PDF
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </div>

</asp:Content>
