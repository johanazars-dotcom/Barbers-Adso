<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Vista/Site1.Master" CodeBehind="RegistroBarbero.aspx.cs" Inherits="AppBarbersAdso.Vista.RegistroBarbero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .card-barbero {
            background: rgba(0, 0, 0, 0.90);
            border: 1px solid #d4af37;
            border-radius: 15px;
            color: #f2f2f2;
            padding: 25px;
            max-width: 600px;
            margin: 0 auto;
        }

        .card-header-adso {
            background: #d4af37;
            color: #000;
            font-weight: bold;
            text-align: center;
            border-top-left-radius: 15px;
            border-top-right-radius: 15px;
            padding: 15px;
            font-size: 22px;
            letter-spacing: 1px;
        }

        label, .form-label {
            color: #d4af37 !important;
            font-weight: 600;
        }

        .form-control, .form-select {
            background-color: #ffffff !important;
            color: #000 !important;
            border: 1px solid #d4af37 !important;
        }

        .btn-dorado {
            background: linear-gradient(135deg, #d4af37, #b8860b);
            border: none;
            color: #000;
            font-weight: bold;
            width: 100%;
        }

        .btn-dorado:hover {
            background: #e6c200;
            color: #000;
        }
    </style>

    <div class="container mt-5 mb-5">

        <div class="card-barbero shadow">

            <div class="card-header-adso">
                Registro de Barbero
            </div>

            <div class="card-body">

                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label" />
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblApellidos" runat="server" Text="Apellidos" CssClass="form-label" />
                    <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblDocumento" runat="server" Text="Documento" CssClass="form-label" />
                    <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblEmail" runat="server" Text="Correo Electrónico" CssClass="form-label" />
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblContrasena" runat="server" Text="Contraseña" CssClass="form-label" />
                    <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono" CssClass="form-label" />
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblPuesto" runat="server" Text="Puesto de la Barbería" CssClass="form-label" />
                    <asp:DropDownList 
                        ID="ddlPuestos" 
                        runat="server" 
                        CssClass="form-control form-select"
                        Style="background:white; color:black; font-weight:bold;">
                    </asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label class="form-label">Foto (JPG / PNG)</label>
                    <asp:FileUpload ID="fuFoto" runat="server" CssClass="form-control" onchange="previewImage(this)" />
                    <img id="imgPreview" style="max-width: 150px; margin-top: 10px; display: none;" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Hoja de Vida (PDF)</label>
                    <asp:FileUpload ID="fuHojaVida" runat="server" CssClass="form-control" />
                    <p id="pdfNombre" class="mt-2 text-warning"></p>
                </div>

                <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn-dorado" OnClick="btnRegistrar_Click" />

                <br /><br />

                <asp:Label ID="lblResultado" runat="server" CssClass="mt-3 fw-bold text-success" />

            </div>
        </div>
    </div>

    <script>
        function previewImage(input) {
            let img = document.getElementById("imgPreview");
            if (input.files && input.files[0]) {
                img.src = URL.createObjectURL(input.files[0]);
                img.style.display = "block";
            }
        }

        document.getElementById("<%= fuHojaVida.ClientID %>").addEventListener("change", function () {
            if (this.files.length > 0) {
                document.getElementById("pdfNombre").textContent = this.files[0].name;
            }
        });
    </script>

</asp:Content>
