<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aprobacioncreditos.aspx.cs" Inherits="ProyectoSitios.Pages.aprobacioncreditos" %>
<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Analisis solicitudes</title>
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Josefin+Sans:wght@500&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.1/css/bulma.min.css" />
    <link href="https://fonts.googleapis.com/css2?family=Syne+Mono&display=swap" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <<link href="../css/bulma2.css" rel="stylesheet" />
    <link href="../css/bulma.css" rel="stylesheet" />
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
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/PanelAdministrativoAnalista.aspx">Panel de administración
                        </a>
                    </div>
                    <div class="navbar-end">
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/tendencias.aspx">Tendencias
                        </a>
                    </div>
                    <div class="navbar-end">
                           <a class="navbar-link" style="color: #ee8133;" href="../Pages/VistasInformacion.aspx">Vistas de información
                        </a>
                    </div>
                    <div class="navbar-end">
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/PantallaCPA.aspx">Configuración
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
            <h1 style="text-align: center; color: #061738; font-size: 50px; font-weight: bold;">Análisis de solicitudes</h1>
            <br />
            <br />
            <div class="HeaderTable" style="font-size: xx-large;">
                <p style="display: inline; color: #ee8133; text-align: center; margin-left: 2%">Filtrar por tipo de préstamo solicitado: 
                    <asp:DropDownList ID="ddltipo" runat="server" CssClass="input is-rounded" Width="354px" OnSelectedIndexChanged="ddltipo_SelectedIndexChanged" Font-Size="Large">
                        <asp:ListItem>--Selecciona un préstamo--</asp:ListItem>
                    </asp:DropDownList>
                    
                    <p style="display: inline; color: #ee8133; text-align: center;">
                        <asp:Button ID="btnBuscar" runat="server" Text=" Buscar " CssClass="RolesButton" OnClick="btnBuscar_Click1" Font-Size="X-Large" />
                    </p>

                </p>
            </div>
                    <br />
        <br />
            <div class="HeaderTable" style="font-size: xx-large;">
                <p style="display: inline; color: #ee8133; text-align: center; margin-left: 2%"> 

                    <p style=" color: #ee8133; text-align: center; margin-left: 2%">Número de solicitud: 

                </p>
                    <asp:TextBox runat="server" class="input is-info" type="text" style="width:250px; height:50px; margin-left:1%; margin-right:1%" placeholder="Número de solicitud" id="txtnumsoli"/> 
                    
                    <p style="display: inline;margin-right:3%; color: #ee8133; text-align: center;">
                        <asp:LinkButton runat="server" class="button is-danger is-outlined" OnClick="Unnamed1_Click" ID="LinkButton1" >
    
                  <span class="icon is-small" >
                    
                  </span>
                  <span>X Denegar</span>
                </asp:LinkButton> 
                    </p>

                    <p style="display: inline; color: #ee8133; text-align: center;">
                        <asp:LinkButton runat="server" class="button is-success" OnClick="Unnamed2_Click" ID="LinkButton2" >
                  <span class="icon is-small">
                    
                  </span>
                  <span>✓ Aceptar</span>
                </asp:LinkButton>
                    </p>

                </p>

                <br />
                <br />
                <asp:Label class="message-header" style="width:100%; height: auto; background-color:#F46363; text-align:center; font-size: 15px;margin-left:5%;margin-right:5%;" ID="lblerror" runat="server"></asp:Label>
 
            </div>
                    

               
            </div>

        <br />
        <br />

        <div class="contenedor">
            <div class="GraficosContenedor">
                <div class="PanelAD">
                    <div class="Grafico">

                        <div class="grafico1" style="border-radius: 0%; height:100%">
                            <br />
                            <br />
                            <div style="width: 90%; height:auto; text-align: center; align-items: center; margin-left: auto; margin-right: auto;">
                                
                                    <asp:Table ID="tablausu" runat="server" style="height:auto" CssClass="table is-striped" ForeColor="#0B0550" HorizontalAlign="Center" Width="100%" Height="90%" Font-Size="18px">
                                    <asp:TableHeaderRow ID="Table1HeaderRow" Style="color: white;" CssClass="CabezaTabla"
                                        ForeColor="white"
                                        BackColor="#061738"
                                        runat="server">

                                        <asp:TableHeaderCell ForeColor="#ee8133" Font-Size="X-Large"
                                            Scope="Column"
                                            Text="Num Solicitud" />
                                        <asp:TableHeaderCell ForeColor="#ee8133" Font-Size="X-Large"
                                            Scope="Column"
                                            Text="Identificación" />
                                        <asp:TableHeaderCell ForeColor="#ee8133" Font-Size="X-Large"
                                            Scope="Column"
                                            Text="Teléfono" />
                                        <asp:TableHeaderCell ForeColor="#ee8133" Font-Size="X-Large"
                                            Scope="Column"
                                            Text="Moneda" />
                                        <asp:TableHeaderCell ForeColor="#ee8133" Font-Size="X-Large"
                                            Scope="Column"
                                            Text="Monto Solicitado" />
                                        <asp:TableHeaderCell ForeColor="#ee8133" Font-Size="X-Large"
                                            Scope="Column"
                                            Text="SalarioLiquido" />
                                        <asp:TableHeaderCell ForeColor="#ee8133" Font-Size="X-Large"
                                            Scope="Column"
                                            Text="Plazo" />
                                        <asp:TableHeaderCell ForeColor="#ee8133" Font-Size="X-Large"
                                            Scope="Column"
                                            Text="Préstamo" />
                                        <asp:TableHeaderCell ForeColor="#ee8133" Font-Size="X-Large"
                                            Scope="Column"
                                            Text="Endeudamiento" />
                                    </asp:TableHeaderRow>

                                </asp:Table>

                                <br />
                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- fin tabla --%>

        
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

