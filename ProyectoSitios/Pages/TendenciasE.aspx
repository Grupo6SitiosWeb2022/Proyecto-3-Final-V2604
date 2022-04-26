<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TendenciasE.aspx.cs" Inherits="ProyectoSitios.Pages.TendenciasE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Tendencias NAV</title>
    <meta name="viewport" content="width=device-width"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.1/css/bulma.min.css">
    <link href="https://fonts.googleapis.com/css2?family=Syne+Mono&display=swap" rel="stylesheet">
    <script src="https://use.fontawesome.com/releases/v5.1.0/js/all.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Arvo:ital@1&display=swap" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css2?family=Syne+Mono&display=swap" rel="stylesheet" />
    <link href="../css/bulma.css" rel="stylesheet" />
   <link href="../css/bulma2.css" rel="stylesheet" />
    <link href="../css/bulma.css" rel="stylesheet" />
    <style>
        .auto-style1 {
            height: 57px;
        }
    </style>
</head>
<body style="width: 100%; margin-left: auto; margin-right: auto;" >
    <form id="form1" runat="server">
          <div>
            <button class="buttonmenu" style="background-color: transparent;" type="button"
                onclick="location.href='https://www.facebook.com'">
                <img style="width: 7%; height: 70px; left: 25px; top: 28px; position: absolute; z-index: 101; display: flex; margin-top: 4px;"
                    src="../img/iconoblanco.png" />
            </button>
        </div>
        
          <div > 

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

            <div style="margin-left: auto; margin-right: auto;">
            <h1 style="text-align: center; color: #061738; font-size: 50px; font-weight: bold;">Tendencia de créditos</h1>
            <br />
            <br />
            <div class="HeaderTable" style="font-size: 30px;">

                <p style="display: inline; color: #ee8133; text-align: center; margin-left: 2%">
                    Fecha inicio:
                     <input style="width: 300px; height: auto;" class="input is-rounded" type="date" placeholder="Contraseña" name="fechaInicio" id="txtfechaini" />
                    Fecha fin:
                     <input style="width: 300px; height: auto;" class="input is-rounded" type="date" placeholder="Contraseña" name="fechaFin" id="txtfechafin" />

                    <p style="display: inline; color: #ee8133; text-align: center;">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="RolesButton" Width="90px" Height="40px" Font-Size="20px" OnClick="btnBuscar_Click" />
                    </p>
                    
                </p>
             </div>
            <br />
                <asp:Label class="message-header" style="width:90%; height: auto; background-color:#F46363; text-align:center; font-size: 15px;margin-left:5%;margin-right:5%;" ID="lblerror" runat="server"></asp:Label>
           
        </div>
        <br />
        <br />

               <!-- Fin parte de arriba -->

                      <div class="contenedor">
            <div class="GraficosContenedor">
                <div class="PanelAD">

                                    <div class="MPContenedor">
                    <div style="text-align:center">
                        <div class="cardVerticalM" style="display: flex; color: white; font-weight: bold;padding-left:90px">

                            <div>        
                            <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">

                                <div>
                                
                                     <img style="width:40%;height:auto;display:inline" src="../img/primerlugar.png"/> 

    

                                    <h1 style="color:#ee8133; font-size:18px;text-align:center;font-weight:bold">Primer lugar crédito con más click´s</h1>
                                    <asp:Label class="message-header" style="width:90%; height: auto; background-color:transparent; text-align:center; font-size: 18px; margin-left:5%;margin-right:5%" ID="lblclick1nom" runat="server"></asp:Label>
  
                                
                                    
                                    <asp:Label class="message is-info" style="width:90%; height: auto; background-color:transparent;   text-align:center; font-size: 18px;" ID="lblclick1cant" runat="server"></asp:Label>
  
                               
                                    </div>
                            </div> <!-- Card pequeña 1 -->
                                  <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                                      <div>
                                
                                     <img style="width:40%;height:auto;display:inline" src="../img/tercero.png"/> 

                                    <h1 style="color:#ee8133; font-size:18px;text-align:center;font-weight:bold">Tercer lugar crédito con más click´s</h1>

                                    <asp:Label class="message-header" style="width:90%; height: auto; background-color:transparent; text-align:center; font-size: 18px;" ID="lblclick3nom" runat="server"></asp:Label>
  
                                    
                                    
                                    <asp:Label class="message is-info" style="width:90%; height: auto; background-color:transparent;  text-align:center; font-size: 18px;" ID="lblclick3cant" runat="server"></asp:Label>
  
                               
                                    </div>
                            </div>  <!-- Card pequeña 2 -->
                                </div>
                            <br/>
                            <br/>
                            <br/>
                            <div>
                                    <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                                         
                                      <div>
                                
                                     <img style="width:40%;height:auto;display:inline" src="../img/segundo.png"/> 

                                    <h1 style="color:#ee8133; font-size:18px;text-align:center;font-weight:bold">Segundo lugar crédito con más click´s</h1>

                                    <asp:Label class="message-header" style="width:90%; height: auto; background-color:transparent; text-align:center; font-size: 18px;margin-left:5%;margin-right:5%;" ID="lblclick2nom" runat="server"></asp:Label>
  
                                    
                                    
                                    <asp:Label class="message is-info" style="width:90%; height: auto; background-color:transparent;  text-align:center; font-size: 18px;" ID="lblclick2cant" runat="server"></asp:Label>
  
                               
                                    </div>
                            </div>  <!-- Card pequeña 3 -->
                                </div>


                             
                        </div>  <!-- Card Grande 1 -->
                        <div class="cardVerticalM" style="display: flex; color: white; font-weight: bold;padding-left:90px">
                             
                            <div>        
                            <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                            <div>
                                
                                     <img style="width:40%;height:auto;display:inline" src="../img/primerlugar.png"/> 

                                    <h1 style="color:#ee8133; font-size:18px;text-align:center;font-weight:bold">Primer lugar posicionamiento 5 seg</h1>


                                    <asp:Label class="message-header" style="width:90%; height: auto; background-color:transparent; text-align:center; font-size: 18px;margin-left:5%;margin-right:5%; font-size: 20px;" ID="lblposi1nom" runat="server"></asp:Label>
  
                               
                                    
                                    <asp:Label class="message is-info" style="width:80%; height: auto; background-color:transparent;  text-align:center; font-size: 18px;font-size: 20px;" ID="lblposi1cant" runat="server"></asp:Label>
  
                               
                                    </div>
                            </div> <!-- Card pequeña 1 -->
                                  <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                                      <div>
                                
                                     <img style="width:40%;height:auto;display:inline" src="../img/tercero.png"/> 

                                   <h1 style="color:#ee8133; font-size:18px;text-align:center;font-weight:bold">Tercer lugar posicionamiento 5 seg</h1>


                                    <asp:Label class="message-header" style="width:90%; height: auto; background-color:transparent; text-align:center; font-size: 18px;margin-left:5%;margin-right:5%; font-size: 20px;" ID="lblposi3nom" runat="server"></asp:Label>
  
                                  
                                    
                                    <asp:Label class="message is-info" style="width:80%; height: auto; background-color:transparent;  text-align:center; font-size: 18px;font-size: 20px;" ID="lblposi3cant" runat="server"></asp:Label>
  
                               
                                    </div>
                            </div>  <!-- Card pequeña 2 -->
                                </div>
                            <br/>
                            <br/>
                            <br/>
                            <div>
                                    <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                                         
                                      <div>
                                
                                     <img style="width:40%;height:auto;display:inline" src="../img/segundo.png"/> 

                                    <h1 style="color:#ee8133; font-size:18px;text-align:center;font-weight:bold">Segundo lugar posicionamiento 5 seg</h1>



                                    <asp:Label class="message-header" style="width:90%; height: auto; background-color:transparent; text-align:center; font-size: 18px;margin-left:5%;margin-right:5%; font-size: 20px;" ID="lblposi2nom" runat="server"></asp:Label>
  
                                    
                                    
                                    <asp:Label class="message is-info" style="width:80%; height: auto; background-color:transparent;  text-align:center; font-size: 18px;font-size: 20px;" ID="lblposi2cant" runat="server"></asp:Label>
  
                               
                                    </div>
                            </div>  <!-- Card pequeña 3 -->
                                </div>
                              
                               
                        </div>  <!-- Card Grande 2 -->
                    </div>
                </div>  <!-- Fin contenedor 1 -->
                                        <div class="MPContenedor">
                        <div style="text-align:center">
                            <div class="cardVerticalM" style="display: block; color: white; font-weight: bold;padding-left:125px">
                                                               <div>


                                 <h1 style="text-align:center; font-size: 20px; color: #ee8133"> Usuarios autenticados que realizan pre-cálculos</h1>
                                   
                            </div>
                             <div>    
                            <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                                     <div>
                                
                                      
                                    
                                     <img style="width:50%;height:auto;display:inline" src="../img/registrado.png"/> 

                                    <br />
                                    <br />

                                    
                                    <asp:Label class="message is-info" style="width:80%; height: auto; background-color:transparent;  text-align:center; font-size: 10px;margin-left:5%;margin-right:5%; font-size:20px" ID="lblAuten" runat="server"></asp:Label>
  
                               
                                    </div>
                            </div>
                                   </div>
                      
                            <div>
                                    
                                </div>

                            </div> <!-- Card Grande 3 -->
                            <div class="cardVerticalM" style="display: block; color: white; font-weight: bold;padding-left:125px">
                                 <div>


                                 <h1 style="text-align:center; font-size: 20px; color: #ee8133"> Usuarios NO autenticados que realizan pre-cálculos</h1>
                                   
                            </div>
                                    <div>    
                            <div class="cardVerticalMP" style="display: flex; color: white; font-weight: bold;">
                                <div>
                                
                                     <img style="width:50%;height:auto;display:inline" src="../img/incognito.png"/> 

                                    <br />
                                    <br />

                                    
                                    <asp:Label class="message is-info" style="width:80%; height: auto; background-color:transparent;  text-align:center; font-size: 10px;margin-left:5%;margin-right:5%; font-size:20px" ID="lblincognitocant" runat="server"></asp:Label>
  
                               
                                    </div>
                            </div>
                                   </div>
                      
                              
                            </div> <!-- Card Grande 4 -->
                        </div>
                    </div>
                </div>

            </div>
        </div>

               <!-- Fin tarjeta Grande -->
          
<br />
        
              <!-- Footer -->
          <footer class="footer1">
          <div class="content has-text-centered">
              <div>
                  
                  <p style="text-align: center"> 
                  <p class="p1" style="display:inline"> <img style="width:20px;height:auto;display:inline" src="../img/c.png"/> 2020Banco NAV. Todos los derechos reservados.</p>
                  <p class="p1" style="display:inline"> <img style="width:20px;height:auto;display:inline" src="../img/correo.png"/> Contáctenos: bancona@gmail.com </p>
                  <p class="p1" style="display:inline"> <img style="width:20px;height:auto;display:inline" src="../img/tel.png"/> Teléfono: 2211-1135</p>
                  <p/> 
              </div>
           

          </div>
        </footer>
    </form>
</body>
</html>

