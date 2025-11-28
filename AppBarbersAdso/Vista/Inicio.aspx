<%@ Page Title="Inicio" Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="AppBarbersAdso.Vista.Inicio" MasterPageFile="~/Vista/Site1.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css" />

    <style>
        .gold {
            color: #d4af37 !important;
        }


        .btn-gold {
            background: linear-gradient(90deg, #ffda55, #d4af37);
            color: #000 !important;
            border-radius: 40px;
            padding: 15px 40px;
            font-weight: 800;
            font-size: 1.1rem;
            box-shadow: 0 0 20px rgba(255, 215, 0, 0.6);
            border: 2px solid #d4af37;
            transition: .3s ease;
            letter-spacing: 1px;
        }

            .btn-gold:hover {
                background: #d4af37;
                color: #000 !important;
                transform: translateY(-5px);
                box-shadow: 0 0 30px rgba(255, 215, 0, .85);
            }

        #hero {
            position: relative;
        }

        .carousel-item {
            height: 90vh;
            min-height: 600px;
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
        }

        .carousel-overlay {
            position: absolute;
            inset: 0;
            background: rgba(0,0,0,0.55);
            backdrop-filter: blur(2px);
        }

        .carousel-caption-custom {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            text-align: center;
            z-index: 3;
            width: 75%;
            color: white;
            animation: fadeIn 1s ease;
        }

            .carousel-caption-custom h1 {
                font-size: 4.5rem;
                font-weight: 800;
                text-shadow: 0 0 15px rgba(212,175,55,.6);
            }

        @keyframes fadeIn {
            from {
                opacity: 0;
                transform: translate(-50%, -40%);
            }

            to {
                opacity: 1;
                transform: translate(-50%, -50%);
            }
        }

        .about-card,
        .contact-box,
        .exp-box {
            background: rgba(20,20,20,.8);
            backdrop-filter: blur(6px);
            border-radius: 15px;
            padding: 35px;
            border: 1px solid rgba(212,175,55,0.25);
            color: #ddd;
            transition: .3s;
        }

            .about-card:hover,
            .exp-box:hover {
                transform: translateY(-5px);
                box-shadow: 0 0 25px rgba(212,175,55,0.25);
            }

            .exp-box i {
                font-size: 1.7rem;
                color: #d4af37;
            }

        footer {
            border-top: 1px solid rgba(212,175,55,0.3);
        }
    </style>

    <section id="hero">
        <div id="carouselBarber" class="carousel slide" data-bs-ride="carousel">

            <div class="carousel-inner">

                <div class="carousel-item active" style="background-image: url('https://images.unsplash.com/photo-1599351431202-1e0f0137899a?auto=format&fit=crop&w=1950&q=80');">
                    <div class="carousel-overlay"></div>
                    <div class="carousel-caption-custom">
                        <h1 class="gold">Barbers ADSO</h1>
                        <p class="fs-4">Elegancia, técnica y estilo premium para el caballero moderno.</p>
                        <a href="#about" class="btn btn-gold mt-3">DESCUBRIR MÁS</a>
                    </div>
                </div>

                <div class="carousel-item" style="background-image: url('https://i.pinimg.com/736x/5a/5a/41/5a5a41b37da66e400cd4f896840e945c.jpg');">
                    <div class="carousel-overlay"></div>
                    <div class="carousel-caption-custom">
                        <h1 class="gold">Cortes Modernos</h1>
                        <p class="fs-4">Estilo urbano, precisión y tendencias internacionales.</p>
                    </div>
                </div>

                <div class="carousel-item" style="background-image: url('https://barberias.vip/wp-content/uploads/2022/07/mejores-barberias-de-colombia.jpg');">
                    <div class="carousel-overlay"></div>
                    <div class="carousel-caption-custom">
                        <h1 class="gold">Barbería Clásica</h1>
                        <p class="fs-4">Afeitado tradicional, estilo old school y experiencia premium.</p>
                    </div>
                </div>

            </div>

            <button class="carousel-control-prev" type="button" data-bs-target="#carouselBarber" data-bs-slide="prev">
                <span class="carousel-control-prev-icon"></span>
            </button>

            <button class="carousel-control-next" type="button" data-bs-target="#carouselBarber" data-bs-slide="next">
                <span class="carousel-control-next-icon"></span>
            </button>

        </div>
    </section>

    <section id="about" class="bg-black py-5">
        <div class="container">
            <h2 class="fw-bold text-center gold mb-5">Sobre Nosotros</h2>

            <div class="row justify-content-center">
                <div class="col-lg-8">
                    <div class="about-card">
                        <p>
                            En <strong class="gold">BARBERS ADSO</strong> reinventamos la experiencia masculina con cortes modernos,
                        barbería clásica y técnicas avanzadas de precisión que resaltan tu estilo propio.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section id="experiencia" class="bg-black">
        <div class="container py-5">
            <h2 class="fw-bold text-center gold mb-5">Experiencia Premium</h2>

            <div class="row justify-content-center">
                <div class="col-lg-7">

                    <div class="exp-box mb-4">
                        <h4 class="gold"><i class="bi bi-person-check me-2"></i>Atención Personalizada</h4>
                        <p>Asesoramiento profesional basado en tu estilo, rostro y personalidad.</p>
                    </div>

                    <div class="exp-box mb-4">
                        <h4 class="gold"><i class="bi bi-stars me-2"></i>Ambiente Exclusivo</h4>
                        <p>Música, diseño moderno y comodidad premium en un solo lugar.</p>
                    </div>

                    <div class="exp-box mb-4">
                        <h4 class="gold"><i class="bi bi-scissors me-2"></i>Profesionales Certificados</h4>
                        <p>Barberos expertos en cortes modernos, fades y barbería clásica.</p>
                    </div>

                </div>
            </div>
        </div>
    </section>

    <section id="contact" class="py-5 bg-black">
        <div class="container">
            <h2 class="fw-bold text-center gold mb-5">Contáctanos</h2>

            <div class="row justify-content-center">
                <div class="col-lg-6">
                    <div class="contact-box">
                        <h4 class="mb-4 gold">Información</h4>
                        <p><i class="bi bi-geo-alt gold me-2"></i>Calle 45 # 12-34, Sogamoso</p>
                        <p><i class="bi bi-telephone gold me-2"></i>+57 300 123 4567</p>
                        <p><i class="bi bi-envelope gold me-2"></i>contacto@barbersadso.com</p>
                        <div class="mt-3">
                            <iframe
                                src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d1984.9244110527486!2d-72.91275657482929!3d5.7349013817178225!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1ses-419!2sco!4v1764337089590!5m2!1ses-419!2sco" 
                                width="100%"
                                height="350"
                                style="border: 0; border-radius: 12px;"
                                allowfullscreen=""
                                loading="lazy"
                                referrerpolicy="no-referrer-when-downgrade"></iframe>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>

    <footer class="bg-black text-center py-4">
        <div class="container">
            <p class="gold small fw-semibold mb-0"><strong>BARBERS ADSO</strong> – Barbería Premium</p>
            <p class="text-secondary small">© 2025 Todos los derechos reservados</p>
        </div>
    </footer>

</asp:Content>
