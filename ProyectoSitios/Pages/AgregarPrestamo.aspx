<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarPrestamo.aspx.cs" Inherits="ProyectoSitios.Pages.AgregarPrestamo" %>
<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Agregar prestamo</title>
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
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/PanelAdministrativo.aspx">Panel de administración
                        </a>
                    </div>
                    <div class="navbar-end">
                          <a class="navbar-link" style="color:#ee8133;" href="../Pages/tendencias.aspx">Tendencias
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
        <br />
        <br />
        <br />
               

        <br />
        <br />

        <div class="contenedor">
            <div  class="GraficosContenedor">
                <div class="PanelAD">
                                 <div class="Grafico">
                  
                     <div class="grafico1" style="border-radius: 0%;">
                         <br />
                         <br />
                         <div style="width: 90%; text-align: center; align-items: center; margin-left: auto; margin-right: auto;">
      <div class="cardLogin" style="text-align:center;color:white;font-weight: bold; padding:5%;">
      <div class="card-content" style="text-align:center">
              <div>
                  

                  <h1 style="font-size:35px; color:#ee8133; font-weight:bold">Agregar préstamo</h1>

                  <h1 style="font-size:15px; color:transparent">2020Banco NAV. Todos los derechos reservhghghhhhghghghados. 2020Banco NAV. Todos los derechos reservados. 2020Bsdsdsdsdsd</h1>

                  
                  <br />
                  <br />

                  <p class="p1" style="display:inline"> <img style="width:50px;height:auto;display:inline" src="../img/g2.png"/> 
                      <asp:TextBox runat="server" style="width:70%;height:auto;" class="input is-rounded" type="text" placeholder="Nombre" ID="txtNom" OnTextChanged="txtNom_TextChanged"/> </p>
                  <br />

                       <p class="p1" style="display:inline"> <img style="width:50px;height:auto;display:inline" src="../img/g2.png"/> 
                      <asp:TextBox runat="server" style="width:70%;height:auto;" class="input is-rounded" type="text" placeholder="Descripción" ID="txtDescri" OnTextChanged="txtDescri_TextChanged"/> </p>
                  <br />

                       <p class="p1" style="display:inline"> <img style="width:50px;height:auto;display:inline" src="../img/g3.png"/> 
                      <asp:TextBox runat="server" style="width:70%;height:auto;" class="input is-rounded" type="text" placeholder="Tasa de interés" ID="txtTasa" OnTextChanged="txtTasa_TextChanged"/> </p>
                  <br />

                       <br />

                       <p class="p1" style="display:inline"> <img style="width:50px;height:auto;display:inline" src="../img/g5.png"/> 
                      <asp:TextBox runat="server" style="width:70%;height:auto;" class="input is-rounded" type="text" placeholder="Monto mínimo" ID="txtMontoMin" OnTextChanged="txtMontoMin_TextChanged"/> </p>
                  <br />

                       <p class="p1" style="display:inline"> <img style="width:50px;height:auto;display:inline" src="../img/g5.png"/> 
                      <asp:TextBox runat="server" style="width:70%;height:auto;" class="input is-rounded" type="text" placeholder="Monto máximo" ID="txtMontoMax" OnTextChanged="txtMontoMax_TextChanged"/> </p>
                  <br />

                      <br />
                  <asp:DropDownList ID="ddlplazo" runat="server" CssClass="input is-rounded" Width="354px"  Font-Size="Large" OnSelectedIndexChanged="ddlplazo_SelectedIndexChanged">
                        <asp:ListItem>--Selecciona un plazo--</asp:ListItem>
                    </asp:DropDownList>
                      
                  <br />
                  <br /> 
                  <asp:DropDownList ID="ddlcatego" runat="server" CssClass="input is-rounded" Width="354px"  Font-Size="Large" OnSelectedIndexChanged="ddlcatego_SelectedIndexChanged">
                        <asp:ListItem>--Selecciona una categoría--</asp:ListItem>
                    </asp:DropDownList>
                       <br /> 
                 

                  <asp:Button class="button is-info is-outlined" style="width: 30%; height:auto; top: 3px; left: -19px;" ID="btnagregar" runat="server" Text="Agregar" OnClick="btnagregar_Click" />

                      <br />
                      <br />

                      <asp:Label class="message-header" style="width:90%; height: auto; background-color:#F46363; text-align:center; font-size: 15px;margin-left:5%;margin-right:5%;" ID="lblerror" runat="server"></asp:Label>
  
                  
              </div>



                   </div>
          </div>
                </div>
                </div>
   </div>
                    </div>
            </div>
        </div>
        <%-- fin nuevo --%>

  
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