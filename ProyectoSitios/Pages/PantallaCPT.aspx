<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaCPT.aspx.cs" Inherits="ProyectoSitios.Pages.PantallaCPT" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
            <button class="buttonmenu" style="background-color: transparent;" type="button"
                onclick="location.href='https://www.facebook.com'">
                <img style="width: 7%; height: 90px; left: 25px; top: 28px; position: absolute; z-index: 101; display: flex; margin-top: 4px;"
                    src="../img/iconoblanco.png" />
            </button>
        </div>
    <div > 

           <div>
             <nav class="navbar" style="z-index: 100; top: 35px; background-color: #061738; color: white" role="navigation" aria-label="dropdown navigation">
                <div class="navbar-menu" style="color: #ee8133;">
                    <div class="navbar-end" style="color: white;">
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/PanelAdministrativoTramitador.aspx">Panel de administración
                        </a>
                    </div>
                    <div class="navbar-end">
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/TendenciasT.aspx">Tendencias
                        </a>
                    </div>
                    <div class="navbar-end">
                           <a class="navbar-link" style="color: #ee8133;" href="../Pages/VistasInformacionT.aspx">Vistas de información
                        </a>
                    </div>
                    <div class="navbar-end">
                        <a class="navbar-link" style="color: #ee8133;" href="../Pages/PantallaCPT.aspx">Configuración
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
          
</div>


        <br />
        <br />
        <br />
        
        <br />
        <br />
        <br />
        <h1 style="text-align: center; color: #ee8133; font-size: 50px; font-weight: bold;">Configuración de Perfil </h1>   
        <br />
        <br />
    
        <div class="contenedor">
            <div class="CalculadoraContenedorR">
                <div class="calculadora">
                    <div>
                    </div>

                    <div class="calculadora1">
                        <h1>Nombre Completo</h1>
                        <br />
                        <div>
                              <asp:TextBox ID="txtCNombre" runat="server"></asp:TextBox>
                          <%--<asp:TextBox ID="txtCNombre" runat="server" CssClass="textbox" OnTextChanged="txtCNombre_TextChanged"></asp:TextBox>--%>&nbsp;<br />
                        </div>
                        <br />
                        <h1>Nacionalidad</h1>
                        <br />
                        <div>
                              <asp:TextBox ID="txtCNacionalidad" runat="server"></asp:TextBox>
                             <%--<asp:TextBox ID="txtCNacionalidad" runat="server" CssClass="textbox" OnTextChanged="txtCNacionalidad_TextChanged"></asp:TextBox>&nbsp;<br />--%>      
                        </div>
                        <br />
                        <h1>Telefono</h1>
                        <br />
                         <div>
                               <asp:TextBox ID="txtCTelefono" runat="server"></asp:TextBox>
                        <%--<asp:TextBox ID="txtCTelefono" runat="server" CssClass="textbox" OnTextChanged="txtCTelefono_TextChanged"></asp:TextBox>--%>&nbsp;<br />
                     </div>
                        <br />
                         <h1>Correo Electrónico</h1>
                        <br />
                         <div>
                               <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                        <%--<asp:TextBox ID="txtCCorreo" runat="server" CssClass="textbox" OnTextChanged="txtCCorreo_TextChanged"></asp:TextBox>--%>&nbsp;<br />
                     </div>
                        <br />
                         <h1>Dirección</h1>
                        <br />
                         <div>
                             <asp:TextBox ID="TxtCDireccion" runat="server"></asp:TextBox>
                        <%--<asp:TextBox ID="txtCDireccion" runat="server" CssClass="textbox" OnTextChanged="txtCDireccion_TextChanged"></asp:TextBox>--%>&nbsp;<br />
                     </div>
                        <br />
                        <br />
                      
                        <asp:Button class="button is-info is-outlined" Height="45px" ID="btn_Modificar" runat="server" Text="Modificar" OnClick="Button1_Click" />
                        <br />
                      
                         <div>
                           <br />
                           <br />
                           <br />
                              <br />
                        <asp:Label class="message-header" Style="width: 90%; height: auto; background-color: #F46363; text-align: center; font-size: 15px; margin-left: 5%; margin-right: 5%;" ID="lblerror" runat="server"></asp:Label>
                    </div>

                    </div>

                    <div class="calculadora2">
                        <img src="../img/Configuracion.png" style="height:100%;" />
                    </div>
                    
                </div>
            
                  <div class="CentrarAviso">
                    <div class="aviso">
                    <h1>Importante</h1>
                        <br />
                    <p>
                       Se pueden modificar datos importantes del perfil con el que se ingresó,
                        Los datos que se modifcan deben ser correctos, en caso de que no lo sea 
                        puede generar conflictos.
                    </p>
                </div>
                </div>
                
            </div>

        </div>
        <br />
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
