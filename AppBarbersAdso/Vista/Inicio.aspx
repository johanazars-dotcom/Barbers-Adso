<%@ Page Title="Inicio" Language="C#" AutoEventWireup="true"
    CodeBehind="Inicio.aspx.cs"
    Inherits="AppBarbersAdso.Vista.Inicio"
    MasterPageFile="~/Vista/Site1.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="inicio" class="text-center d-flex align-items-center justify-content-center"
        style="height: 60vh; background: url('https://wallpapercave.com/wp/wp9537038.jpg') center/cover no-repeat; position: relative;">

        <div class="position-absolute top-0 w-100 h-100" style="background: rgba(0,0,0,0.75);"></div>

        <div class="container position-relative">
            <h1 class="display-3 fw-bold gold">Estilo, Precisión & Arte</h1>
            <p class="lead my-3">La mejor experiencia de barbería para caballeros exigentes.</p>
            <a href="#services" class="btn btn-gold btn-lg fw-bold">Conoce Nuestros Servicios</a>
        </div>
    </section>

    <section id="about" class="py-5">
        <div class="container text-center">
            <h2 class="fw-bold mb-4 gold">Sobre Nosotros</h2>

            <div class="row justify-content-center">
                <div class="col-lg-8">
                    <div class="section-box">
                        <p>
                            En <strong class="gold">BARBERS ADSO</strong> elevamos la barbería tradicional a un nivel superior.
                            Nuestros barberos profesionales se especializan en cortes modernos, barbería clásica y cuidado estético
                            con técnica, precisión y pasión.
                        </p>
                    </div>
                </div>
            </div>

        </div>
    </section>

    <section id="services" class="py-5 text-center bg-black">
        <div class="container">
            <h2 class="fw-bold gold mb-5">Servicios</h2>

            <div class="row">
                <div class="col-md-4 mb-4">
                    <div class="section-box">
                        <i class="bi bi-person-fill gold fs-1 mb-3"></i>
                        <h4 class="gold">Corte Clásico</h4>
                        <p>Estilo tradicional y elegante para cualquier ocasión.</p>
                    </div>
                </div>

                <div class="col-md-4 mb-4">
                    <div class="section-box">
                        <i class="bi bi-beard gold fs-1 mb-3"></i>
                        <h4 class="gold">Diseño de Barba</h4>
                        <p>Perfilado profesional y afeitado de precisión.</p>
                    </div>
                </div>

                <div class="col-md-4 mb-4">
                    <div class="section-box">
                        <i class="bi bi-brush gold fs-1 mb-3"></i>
                        <h4 class="gold">Tinte y Estética</h4>
                        <p>Color, sombreado y técnicas avanzadas para realzar tu estilo.</p>
                    </div>
                </div>
            </div>

        </div>
    </section>

    <section id="contact" class="py-5">
        <div class="container">
            <h2 class="fw-bold gold mb-4 text-center">Contáctanos</h2>

            <div class="row">
                <div class="col-lg-6 mb-4">
                    <div class="section-box">
                        <h4 class="mb-4 gold">Información</h4>
                        <p><i class="bi bi-geo-alt gold me-2"></i>Calle 45 # 12-34, Sogamoso</p>
                        <p><i class="bi bi-telephone gold me-2"></i>+57 300 123 4567</p>
                        <p><i class="bi bi-envelope gold me-2"></i>contacto@barbersadso.com</p>
                    </div>
                </div>

            </div>

        </div>
    </section>

    <footer class="bg-black text-center py-4" style="border-top: 1px solid #d4af37;">
        <div class="container">

            <p class="mb-0 small gold fw-semibold">
                <span class="fw-bold">BARBERS ADSO</span> — Sistema de Gestión de Barbería
            </p>
        </div>
    </footer>

</asp:Content>
