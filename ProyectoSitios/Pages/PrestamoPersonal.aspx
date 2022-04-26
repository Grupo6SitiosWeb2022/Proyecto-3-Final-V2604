<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrestamoPersonal.aspx.cs" Inherits="ProyectoSitios.Pages.PrestamoPersonal" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Banco NAV</title>
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Josefin+Sans:wght@500&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.1/css/bulma.min.css" />
    <link href="https://fonts.googleapis.com/css2?family=Syne+Mono&display=swap" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="../css/bulma2.css" rel="stylesheet" />

</head>

<body>
    <form id="form1" runat="server">
        <div>

            <img style="width: 10%; left: 25px; top: 380px; position: absolute; z-index: 101; display: flex; margin-top: 4px;" src="../img/icono.png" />
            <img style="width: 20%; left: 0px; top: 390px; position: absolute; z-index: 99; display: flex;" src="../img/hexagono.png" />
        </div>

        <div class="demo_wrap">
            <img src="../img/Mascara.jpg" />
            <img class="azul" src="../img/FondoPP.jpg" />
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div>
            <nav class="navbar" style="z-index: 100; top: 95px" role="navigation" aria-label="dropdown navigation">
                <div class="navbar-menu">
 <div class="navbar-end">
                        <a class="navbar-link" href="../Pages/PrestamoPersonal.aspx">Préstamo personal
                        </a>
                    </div>
                    <div class="navbar-end">
                        <a class="navbar-link" href="../Pages/PrestamoPyme.aspx">Préstamo pymes
                        </a>
                    </div>
                    <div class="navbar-end">
                        <a class="navbar-link"  href="../Pages/PrestamosCoorporativos.aspx">Préstamo corporativa
                        </a>
                    </div>
                    <div class="navbar-end">
                        <a class="navbar-link" href="../Pages/CalcularPrestamos.aspx">Calculadora
                        </a>
                    </div>
                    <div class="navbar-end">
                         <a class="navbar-link" href="../Pages/login.aspx">Iniciar sesión
                        </a>
                    </div>
                </div>
            </nav>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
          <h1 style="text-align: center; color: #ee8133; font-size: 50px; font-weight: bold;">Préstamos Personales </h1>
        <br />
        <br />
        <div class="contenedor">
            <div class="tarjeta">
                <img src="../img/5.png" />
                <div class="descripcion">
                    <h1>Préstamo personal</h1>
                    <p>
                        Solicita tu prestamo personal y hacé realidad
                    todos los planes que has estado posponiendo:
                    tus sueños, metas y proyectos.
                    </p>
                    <div class="TarjetaBTN">

                                                     <asp:Button ID="btnSolicitarP" runat="server" Width="130px" Height="30px" Text="Solicitar" CssClass="RolesButton" OnClick="btnSolicitarP_Click" />
                   
 
                             <asp:Button ID="btnVerMasP" runat="server" Width="130px" Height="30px" Text="+ Ver más" CssClass="RolesButton" OnClick="btnVerMasP_Click"  />
                   
                    </div>
                </div>
            </div>
            <div class="tarjeta">
                <img src="../img/7.png" />
                <div>
                    <h1>Préstamo vehicular</h1>
                    <p>
                        Te ofrecemos tasas competitivas y rápidos tiempos
                    de respuesta para comprar tu carro nuevo, seminuevo y usado;
                    con opciones leasing y crédito prendario.
                    </p>
                    <div class="TarjetaBTN">
                                                       <asp:Button ID="btnSolicitarV" runat="server" Width="130px" Height="30px" Text="Solicitar" CssClass="RolesButton" OnClick="btnSolicitarV_Click" />
                   
 
                             <asp:Button ID="btnVerMasV" runat="server" Width="130px" Height="30px" Text="+ Ver más" CssClass="RolesButton" OnClick="btnVerMasV_Click"  />
                   
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="contenedor">
            <div class="tarjeta">
                <img src="../img/6.png" />
                <div class="descripcion">
                    <h1>Préstamo de vivienda</h1>
                    <p>
                        Te ofrecemos una solución ágil de financiamiento
                    para que estrenés en menor tiempo tu nuevo hogar.
                    </p>
                    <div class="TarjetaBTN">
                                                    <asp:Button ID="btnSolicitarVI" runat="server" Width="130px" Height="30px" Text="Solicitar" CssClass="RolesButton" OnClick="btnSolicitarVI_Click" />
                   
 
                             <asp:Button ID="btnVerMasVI" runat="server" Width="130px" Height="30px" Text="+ Ver más" CssClass="RolesButton" OnClick="btnVerMasVI_Click"  />
                   
                    </div>
                </div>
            </div>
            <div class="tarjeta">
                <img src="../img/8.png" />
                <div class="descripcion">
                    <h1>Préstamo de salud</h1>
                    <p>
                       Es hora de pasar de los dichos a los hechos y ponerle fecha y hora a ese momento,
                        para lograr sanar lo que te molesta hace tiempo o solucionar ese imprevisto que 
                        te haya generado un gasto por hospitalización.
                    </p>
                    <div class="TarjetaBTN">
                                                    <asp:Button ID="btnSolicitarS" runat="server" Width="130px" Height="30px" Text="Solicitar" CssClass="RolesButton" OnClick="btnSolicitarS_Click" />
                   
 
                             <asp:Button ID="btnVerMasS" runat="server" Width="130px" Height="30px" Text="+ Ver más" CssClass="RolesButton" OnClick="btnVerMasS_Click"  />
                   
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="contenedor">
            <div class="ContenedorDCreditos">
                <div class="Dcredito">
                    <h1>¿Qué pasa cuando solicita un crédito?</h1>
                    <h3>Estos son los 5 pasos para hacer realidad sus proyectos</h3>
                    <div class="DcreditoContenedor">
                        <div class="Dcredito-columna">
                            <div class="DescripcionPasos">
                                <img src="../img/busqueda.png" style="height: 70px; width: 80px;" />
                                <p>1. Después de realizada su solicitud le daremos seguimiento</p>
                            </div>
                            <div class="DescripcionPasos">
                                <img src="../img/dinero.png" style="height: 70px; width: 80px;" />
                                <p>2. Le solicitaremos información para brindarle las mejores condiciones</p>
                            </div>
                            <div class="DescripcionPasos">
                                <img src="../img/confirma.png" style="height: 70px; width: 80px;" />
                                <p>3. Confirmaremos los datos para evitar inconvenientes en el registro</p>
                            </div>
                        </div>
                        <div class="Dcredito-columna">

                            <div class="DescripcionPasos">
                                <img src="../img/anota.png" style="height: 70px; width: 80px;" />
                                <p>4. Presentese en la oficina que elija para firmar la documentación del crédito</p>
                            </div>
                            <div class="DescripcionPasos">
                                <img src="../img/tasa.png" style="height: 70px; width: 80px;" />
                                <p>5. Se desembolsará el dinero del crédito</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="Dcredito-pensar">
                    <img src="../img/credito-de-nomina-que-es-portada1_preview_rev_1.png" />
                </div>
            </div>
        </div>
        <br />
        <footer class="footer">
            <div class="content has-text-centered">
                <div>

                    <p style="font-size: 10px;">
                        <p class="p1" style="display: inline">
                            <img style="width: 20px; height: auto; display: inline" src="../img/c.png" />
                            2020Banco NAV. Todos los derechos reservados.
                        </p>
                        <p class="p1" style="display: inline">
                            <img style="width: 20px; height: auto; display: inline" src="../img/correo.png" />
                            Contáctenos: bancona@gmail.com
                        </p>
                        <p class="p1" style="display: inline">
                            <img style="width: 20px; height: auto; display: inline" src="../img/tel.png" />
                            Teléfono: 2211-1135
                        </p>
                        <p />
                </div>

            </div>
        </footer>


    </form>
</body>
</html>
