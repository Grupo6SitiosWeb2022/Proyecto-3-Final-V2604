<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelAdministrativoEditor.aspx.cs" Inherits="ProyectoSitios.Pages.PanelAdministrativoEditor" %>

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
    <link href="../css/bulma4.css" rel="stylesheet" />
     <link href="../css/bulma5.css" rel="stylesheet" />
    <style>
        .auto-style1 {
            height: 57px;
        }
    </style>
</head>

<body style="width: 100%; margin-left: auto; margin-right: auto;">
    <form id="form1" runat="server">
        <div>
            <button class="buttonmenu" style="background-color: transparent;" type="button"
                onclick="location.href='https://www.facebook.com'">
                <img style="width: 7%; height: 70px; left: 25px; top: 28px; position: absolute; z-index: 101; display: flex; margin-top: 4px;"
                    src="../img/iconoblanco.png" />
            </button>
        </div>
        <div>
            <nav class="navbar" style="z-index: 100; top: 35px; background-color: #061738; color: white" role="navigation" aria-label="dropdown navigation">
                <div class="navbar-menu" style="color: #ee8133;">
                    <div class="navbar-end" style="color: white;">
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/PanelAdministrativoEditor.aspx">Panel de administración
                        </a>
                    </div>
                    <div class="navbar-end">
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/TendenciasE.aspx">Tendencias
                        </a>
                    </div>
                    <div class="navbar-end">
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/ConfiguracionRoles.aspx">Configuracion Roles
                        </a>
                    </div>
                   
                      <div class="navbar-end">
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/Index.aspx">Cerrar sesión
                        </a>
                    </div>
                    <div style="display: block;">
                        <div>
                            <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="text-align: right">
                            <asp:Label ID="lblRol" runat="server" Text=""></asp:Label>
                        </div>

                    </div>
                </div>
            </nav>
        </div>
        <br />
        <br />
        <br />
        <div style="margin-left: auto; margin-right: auto;">
            <h1 style="text-align: center; color: #061738; font-size: 50px; font-weight: bold;">Panel de administración</h1>
            <br />
        </div>
        <div class="contenedor">
            <div class="GraficosContenedor" style="display: block;">
                <div class="PanelAD">
                    <div class="Grafico">
                        <div class="grafico1" style="margin-left: auto; margin-right: auto;">
                            <br />
                            <h1>Estadisticas</h1>
                            <br />
                            <div style="margin-left: 34px; margin-right: auto; width: 100%;">
                                <div style="display: flex; margin-left: auto; margin-right: auto;">
                                    <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">

                                        <div style="height: 100px; width: 200px; padding-top: 40px">
                                            <img src="../img/IAS.png">
                                            <a class="enlace" href="../Pages/TendenciasE.aspx">Indicadores</a>
                                        </div>

                                    </div>

                                    <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold; margin-left: 0px;">
                                        <div style="height: 100px; width: 200px; padding-top: 40px">
                                            <img src="../img/IES.png">
                                            <a class="enlace" href="../Pages/GraficosE.aspx">Estadisticas de
                                        indicadores
                                        </a>
                                        </div>
                                    </div>

                                </div>
                            </div>


                                 <div style="margin-left: 34px; margin-right: auto; width: 100%;">
                                <div style="display: flex; margin-left: auto; margin-right: auto;">
                                    <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">

                                        <div style="height: 100px; width: 200px; padding-top: 40px">
                                            <img src="../img/VistaInformacion.png"/>
                                              <a class="enlace" href="../Pages/VistasInformacionE.aspx">Vistas de información</a>
                                        </div>

                                    </div>

                                    <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold; margin-left: 0px;">
                                        <div style="height: 100px; width: 200px; padding-top: 40px">
                                             <img src="../img/VistaInformacion.png"/>
                                            <a class="enlace" href="../Pages/VistasSolicitudes.aspx">Solicitudes
                                        </a>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>

                        <div class="grafico1" style="margin-left: auto; margin-right: auto;">
                             <br />
                            <h1>Estadisticas</h1>
                            <br />
                            <div style="margin-left: 34px; margin-right: auto; width: 100%;">
                                <div style="display: flex; margin-left: auto; margin-right: auto;">
                                    <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">

                                        <div style="height: 100px; width: 200px; padding-top: 40px">
                                             <img src="../img/IRU.png"/>
                                            <a class="enlace" href="../Pages/ConfiguracionRoles.aspx">Asignación de Roles</a>
                                        </div>

                                    </div>

                                    <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold; margin-left: 0px;">
                                        <div style="height: 100px; width: 200px; padding-top: 40px">
                                             <img src="../img/IRU.png"/>
                                            <a class="enlace" href="../Pages/ConfiguracionUsuarios.aspx">Asignación de rol a usuarios</a>
                                        </div>
                                    </div>

                                </div>
                            </div>


                                 <div style="margin-left: 34px; margin-right: auto; width: 100%;">
                                <div style="display: flex; margin-left: auto; margin-right: auto;">
                                    <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">

                                        <div style="height: 100px; width: 200px; padding-top: 40px">
                                           <img src="../img/ICU.png"/>
                                            <a class="enlace" href="../Pages/PantallaCPE.aspx">Configuración</a>
                                        </div>

                                    </div>

                                    <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold; margin-left: 0px;">
                                        <div style="height: 100px; width: 200px; padding-top: 40px">
                                             <img src="../img/VistaInformacion.png"/>
                                            <a class="enlace" href="../Pages/VistasSolicitudesTramitador.aspx">Solicitudes de tramitadores
                                        </a>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="Grafico">
                        <div class="grafico1" style="display: block; margin-left: auto; margin-right: auto;">
                            <br />
                            <h1>Gestiones</h1>
                            <br />
                            <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold; margin-left: auto; margin-right: auto;">
                                <div style="height: 100px; width: 200px; padding-top: 40px">
                                    <img src="../img/ICUSER.png">
                                    <a class="enlace" href="../Pages/GestionUsuarios.aspx">Usuarios</a>
                                </div>
                            </div>


                            <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold; margin-left: auto; margin-right: auto;">
                                <div style="height: 100px; width: 200px; padding-top: 40px">
                                    <img src="../img/IGP.png">
                                    <a class="enlace" href="../Pages/GestionPrestamos.aspx">Préstamos</a>
                                </div>
                            </div>

                        </div>

                    </div>
                    <br />
                    <br />
                </div>
            </div>
        </div>
        <br />
        <br />

        <footer class="footer1">
            <div class="content has-text-centered">
                <div>
                    <p style="text-align: center; font-size: 10px; float: left;">
                        <p class="p1" style="margin: 10px 10px; display: inline">
                            <img style="width: 20px; height: auto; display: inline" src="../img/c.png" />
                            2020 Banco NAV. Todos los derechos reservados.
                       
                        </p>
                        <p class="p1" style="margin: 10px 10px; display: inline">
                            <img style="width: 20px; height: auto; display: inline" src="../img/correo.png" />
                            Contáctenos: bancona@gmail.com
                       
                        </p>
                        <p class="p1" style="margin: 10px 10px; display: inline">
                            <img style="width: 20px; height: auto; display: inline" src="../img/tel.png" />
                            Teléfono: 2211-1135
                       
                        </p>
                    </p>
                </div>

            </div>
        </footer>
    </form>
</body>
</html>
