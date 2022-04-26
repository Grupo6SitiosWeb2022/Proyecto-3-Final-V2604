<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PConfiguracionG.aspx.cs" Inherits="ProyectoSitios.Pages.PConfiguracionG" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Tendencias NAV</title>
    <meta name="viewport" content="width=device-width" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.1/css/bulma.min.css">
    <link href="https://fonts.googleapis.com/css2?family=Syne+Mono&display=swap" rel="stylesheet">
    <script src="https://use.fontawesome.com/releases/v5.1.0/js/all.js"></script>
    <link href="https://fonts.googleapis.com/css2?family=Josefin+Sans:wght@500&display=swap" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

    <link href="../css/bulma1.css" rel="stylesheet" />

</head>
<body class="body2">
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
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/PConfiguracionG.aspx">Panel de administración
                        </a>
                    </div>
                    <div class="navbar-end">
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/tendencias.aspx">Tendencias
                        </a>
                    </div>
                    <div class="navbar-end">
                           <a class="navbar-link" style="color: #ee8133;" href="../Pages/solicitudestramitar.aspx">Solicitudes
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
                       <div style="display:block;">
                         <div>
                                <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                         </div>
                         <div style="text-align:right">
                               <asp:Label ID="lblRol" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                </div>
            </nav>
        </div>



        <div style="padding-left: 150px">
            <div class="row" style="text-align: center">
                <div class="side" style="z-index: 101;">
                    <div>
                        <div class="MPContenedor">
                            <div style="text-align: center">
                                <div class="cardVerticalM" style="display: flex; color: white; font-weight: bold; padding-left: 90px">
                                    <br />
                                    <div>

                                        <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">

                                            <div style="height: 100px; width: 200px; padding-top: 40px">
                                                <img src="../img/IAS.png">
                                                <a class="enlace" href="http://es.stackoverflow.com">Indicadores</a>
                                            </div>

                                        </div>
                                        <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                                            <div style="height: 100px; width: 200px; padding-top: 40px">
                                                <img src="../img/IES.png">
                                                <a class="enlace" href="http://es.stackoverflow.com">Estadisticas de
                                        indicadores
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <br />
                                    <div>
                                        <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                                            <div style="height: 100px; width: 200px; padding-top: 40px">
                                                <img src="../img/VistaInformacion.png">
                                                <a class="enlace" href="http://es.stackoverflow.com">Vistas de información</a>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="cardVerticalM" style="display: block; color: white; font-weight: bold; padding-left: 150px">
                                    <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                                        <div style="height: 100px; width: 200px; padding-top: 40px">
                                            <img src="../img/ICUSER.png">
                                            <a class="enlace" href="http://es.stackoverflow.com">Usuarios</a>
                                        </div>
                                    </div>


                                    <div>
                                        <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                                            <div style="height: 100px; width: 200px; padding-top: 40px">
                                                <img src="../img/IGP.png">
                                                <a class="enlace" href="http://es.stackoverflow.com">Préstamos</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="main">
                    <div>
                        <div class="MPContenedor">
                            <div style="text-align: center">
                                <div class="cardVerticalM" style="display: block; color: white; font-weight: bold; padding-left: 150px">
                                    <div>
                                        <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                                            <div style="height: 100px; width: 200px; padding-top: 40px">
                                                <img src="../img/IASS.png">
                                                <a class="enlace" href="http://es.stackoverflow.com">Asignación de Solicitud</a>
                                            </div>
                                        </div>
                                    </div>

                                    <div>
                                        <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                                            <div style="height: 100px; width: 200px; padding-top: 40px">
                                                <img src="../img/IAC.png">
                                                <a class="enlace" href="http://es.stackoverflow.com">Recepción de solicitud</a>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="cardVerticalM" style="display: block; color: white; font-weight: bold; padding-left: 150px">
                                    <div>
                                        <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                                            <div style="height: 100px; width: 200px; padding-top: 40px">
                                                <img src="../img/ICU.png">
                                                <a class="enlace" href="../Pages/PantallaCP.aspx">Configuración</a>
                                            </div>
                                        </div>
                                    </div>


                                    <div>
                                        <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                                            <div style="height: 100px; width: 200px; padding-top: 40px">
                                                <img src="../img/IRU.png">
                                                <a class="enlace" href="http://es.stackoverflow.com">Asignación de Roles</a>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        </div>
          </div>
   
       
   
        
              <!-- Footer -->
        <footer class="footer1">
            <div class="content has-text-centered">
                <div>

                    <p style="text-align: center">
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
