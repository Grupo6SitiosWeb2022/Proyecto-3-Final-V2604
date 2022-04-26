<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioRegistro.aspx.cs" Inherits="ProyectoSitios.Pages.FormularioRegistro" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login NAV</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.1/css/bulma.min.css">
    <link href="https://fonts.googleapis.com/css2?family=Syne+Mono&display=swap" rel="stylesheet">
    <script src="https://use.fontawesome.com/releases/v5.1.0/js/all.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
<link href="https://fonts.googleapis.com/css2?family=Arvo:ital@1&display=swap" rel="stylesheet">
    <link href="../css/bulma.css" rel="stylesheet" />
   <style>
        body {
	font-family:  'Arvo', serif;  font-size: 25px;
    
}
        p{
            font-size:15px;
        }

</style>
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>
</head>
<body class="body" >

    <form id="form1" runat="server">

  <div class="row" style="text-align:center">
  <div class="side" style="z-index: 101;text-align:center ">
    

      <div class="cardLogin" style="text-align:center;color:white;font-weight: bold;">
      <div class="card-content" style="text-align:center">
              <div>
                  
                  <p style="text-align: center"> 
                  <p class="p1" style="display:inline; font-size:50px"> <img style="width:120px;height:auto;display:inline" src="../img/icono1.png"/> Banco NAV</p>
                  <p/> 

                  <h1 style="font-size:15px; color:transparent">2020Banco NAV. Todos los derechos reservhghghhhhghghghados. 2020Banco NAV. Todos los derechos reservados. 2020Bsdsdsdsdsd</h1>

                  <p class="p1" style="display:inline"> <img style="width:40px;height:auto;display:inline" src="../img/usuario.png"/> 
                      <asp:TextBox runat="server" style="width:70%;height:auto;" class="input is-rounded" type="text" placeholder="Nombre de usuario(identificación)" id="txtUser"/> </p>

                  <br />
                  <br />

                  <p class="p1" style="display:inline"> <img style="width:50px;height:auto;display:inline" src="../img/nombre.png"/> 
                      <asp:TextBox runat="server" style="width:70%;height:auto;" class="input is-rounded" type="text" placeholder="Nombre completo" ID="txtNom"/> </p>
                  <br />

                       <p class="p1" style="display:inline"> <img style="width:50px;height:auto;display:inline" src="../img/nacionalidad.png"/> 
                      <asp:TextBox runat="server" style="width:70%;height:auto;" class="input is-rounded" type="text" placeholder="Nacionalidad" ID="txtNacionalidad"/> </p>
                  <br />

                       <p class="p1" style="display:inline"> <img style="width:50px;height:auto;display:inline" src="../img/telefono.png"/> 
                      <asp:TextBox runat="server" style="width:70%;height:auto;" class="input is-rounded" type="text" placeholder="Teléfono" ID="txtTel"/> </p>
                  <br />

                       <p class="p1" style="display:inline"> <img style="width:50px;height:auto;display:inline" src="../img/correo2.png"/> 
                      <asp:TextBox runat="server" style="width:70%;height:auto;" class="input is-rounded" type="text" placeholder="Correo electronico" ID="txtCorreo"/> </p>
                  <br />

                       <p class="p1" style="display:inline"> <img style="width:50px;height:auto;display:inline" src="../img/direccion.png"/> 
                      <asp:TextBox runat="server" style="width:70%;height:auto;" class="input is-rounded" type="text" placeholder="Dirreción" ID="txtDirec"/> </p>
                  <br />

                       <p class="p1" style="display:inline"> <img style="width:50px;height:auto;display:inline" src="../img/pass.png"/> 
                      <asp:TextBox runat="server" style="width:70%;height:auto;" class="input is-rounded" type="password" placeholder="Contraseña" ID="txtpass1"/> </p>
                  <br />

                      <p class="p1" style="display:inline"> <img style="width:50px;height:auto;display:inline" src="../img/pass.png"/> 
                      <asp:TextBox runat="server" style="width:70%;height:auto;" class="input is-rounded" type="password" placeholder="Escribir nuevamente la contraseña" ID="txtpass2"/> </p>
                  <br />
                      
                  <br />
                        
<div class="col-sm-3" style="text-align:center; margin-left: 33% ; margin-right:auto">
<div class="g-recaptcha" style="text-align:center; margin-left: auto ; margin-right:auto" data-sitekey="6Lfg9HkfAAAAAIW_ZYXaYq4NrFxHS1HieA039D5W"></div>
</div>



                  <asp:Button class="button is-info is-outlined" style="width: 30%" ID="btnLogin" runat="server" Text="Registrarse" OnClick="btnLogin_Click"  />

                      <br />
                      <br />

                      <asp:Label class="message-header" style="width:90%; height: auto; background-color:#F46363; text-align:center; font-size: 15px;margin-left:5%;margin-right:5%;" ID="lblerror" runat="server"></asp:Label>
  
                  
              </div>



                   </div>
          </div>

    
      
</div>
            </div>

       <br>

                <!-- Footer -->
          <footer class="footer1">
          <div class="content has-text-centered">
              <div>               
                  <p style="text-align: center;font-size:10px;float:left"> 
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
