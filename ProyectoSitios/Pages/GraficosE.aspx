<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GraficosE.aspx.cs" Inherits="ProyectoSitios.Pages.GraficosE" %>


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
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/TendenciasT.aspx">Tendencias
                        </a>
                    </div>
                    <div class="navbar-end">
                           <a class="navbar-link" style="color: #ee8133;" href="../Pages/VistasInformacionE.aspx">Vistas de información
                        </a>
                    </div>
                    <div class="navbar-end">
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/PantallaCPE.aspx">Configuración
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
        <br />
        <br />
        <br />

        <div style="margin-left: auto; margin-right: auto;">
            <h1 style="text-align: center; color: #061738; font-size: 50px; font-weight: bold;">Gráficos tendencias</h1>
            <br />
            <br />
            <div class="HeaderTable" style="font-size: 30px;">

                <p style="display: inline; color: #ee8133; text-align: center; margin-left: 2%">
                    Fecha inicio:
                     <input style="width: 300px; height: auto;" class="input is-rounded" type="date" placeholder="Contraseña" name="fechaInicio" id="fechainicio" />
                    Fecha fin:
                     <input style="width: 300px; height: auto;" class="input is-rounded" type="date" placeholder="Contraseña" name="fechaFin" id="fechafin" />

                    <p style="display: inline; color: #ee8133; text-align: center;">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="RolesButton" Width="90px" Height="40px" Font-Size="20px" OnClick="btnBuscar_Click1" />
                    </p>
                    
                </p>
             </div>
            <br />
                <asp:Label class="message-header" style="width:90%; height: auto; background-color:#F46363; text-align:center; font-size: 15px;margin-left:5%;margin-right:5%;" ID="lblerror" runat="server"></asp:Label>
           
        </div>
        <br />
        <br />

        <div class="contenedor">
            <div class="GraficosContenedor">
                <div class="PanelAD">
                    <div class="Grafico">
                        <div class="grafico1">
                            <br />
                            <h1  style="color:black;">Créditos más populares</h1>

                            <asp:Chart runat="server" ID="chartclic" BackColor="Transparent" Height="394px" Palette="Chocolate" Width="582px">
                                <Legends>
                                    <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" AutoFitMinFontSize="13" DockedToChartArea="chartareaclic" Font="Microsoft Sans Serif, 13pt" IsDockedInsideChartArea="False" IsEquallySpacedItems="True" MaximumAutoSize="100" TableStyle="Wide" />
                                </Legends>
                                <Series>
                                    <asp:Series Name="serieclic" ChartType="Pie" IsValueShownAsLabel="True" LabelForeColor="White" Font="Microsoft Sans Serif, 15pt"></asp:Series>

                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="chartareaclic">
                                        <AxisX IntervalAutoMode="VariableCount">
                                        </AxisX>
                                    </asp:ChartArea>

                                </ChartAreas>
                            </asp:Chart>
                        </div>
                        <div class="grafico1">
                            <br />
                            <h1 style="color:black;">Posicionamiento de puntero por más de 5 segundos</h1>
       
                            <asp:Chart ID="chartSeg" runat="server" BackColor="Transparent" Height="394px" Palette="Chocolate" Width="582px">
                                <Legends>
                                    <asp:Legend  Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" AutoFitMinFontSize="13" DockedToChartArea="chartareaclic" Font="Microsoft Sans Serif, 13pt" IsDockedInsideChartArea="False" IsEquallySpacedItems="True" MaximumAutoSize="100" TableStyle="Wide" />
                                </Legends>
                                <Series>
                                    <asp:Series  Name="serieseg" ChartType="Pie" IsValueShownAsLabel="True" LabelForeColor="White" Font="Microsoft Sans Serif, 15pt"></asp:Series>
                                </Series>
                                <ChartAreas>
                                     <asp:ChartArea Name="chartareaclic">
                                        <AxisX IntervalAutoMode="VariableCount">
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </div>
                           <div class="grafico1">
                            <br />
                            <h1 style="color:black;">Usuarios autenticados y no autenticados</h1>
                   
                            <asp:Chart ID="chartau" runat="server" BackColor="Transparent" Height="394px" Palette="Chocolate" Width="582px">

                                <Legends>
                                    <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" AutoFitMinFontSize="13" DockedToChartArea="chartareaclic" Font="Microsoft Sans Serif, 13pt" IsDockedInsideChartArea="False" IsEquallySpacedItems="True" MaximumAutoSize="100" TableStyle="Wide"  />
                                </Legends>
                                <Series>
                                    <asp:Series Name="serieau" ChartType="Pie" IsValueShownAsLabel="True" LabelForeColor="White" Font="Microsoft Sans Serif, 15pt"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="chartareaclic">
                                        <AxisX IntervalAutoMode="VariableCount">
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </div>
                        <br />
                        <br />
                        <br />
                    </div>
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
