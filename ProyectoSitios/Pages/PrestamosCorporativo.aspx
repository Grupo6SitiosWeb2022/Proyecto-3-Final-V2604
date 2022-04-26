<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrestamosCorporativo.aspx.cs" Inherits="ProyectoSitios.Pages.PrestamosCorporativo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Banco NAV</title>
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.1/css/bulma.min.css">
    <link href="https://fonts.googleapis.com/css2?family=Josefin+Sans:wght@500&display=swap" rel="stylesheet" />
    <script src="https://use.fontawesome.com/releases/v5.1.0/js/all.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Arvo:ital@1&display=swap" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css2?family=Syne+Mono&display=swap" rel="stylesheet" />
    <link href="../css/bulma.css" rel="stylesheet" />
   <style>
  body {
    font-size: 25px;
    font-family: 'Josefin Sans', sans-serif;
}
        p{
            font-size:15px;
        }
</style>
</head>

<body>
    <form id="form1" runat="server">
        <div>
    <button class="buttonmenu" style="background-color: transparent;" type="button" onclick="location.href='https://www.facebook.com'">
    <img  style="width: 10%;left: 25px; top: 380px;position:absolute; z-index:101; display: flex; margin-top: 4px;" src="../img/icono.png">
    <img  style="width: 20%;left: 0px; top: 390px;position: absolute; z-index: 99; display: flex;" src="../img/hexagono.png">
        
    </button>



    <div class="demo_wrap">
      <img  src="../img/Mascara.jpg">
      <img class="azul" src="../img/fondo_corporativos.png">
    </div>
  </div>

  <br><br><br><br>
  <br><br>

    <div > 
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
                        <a class="navbar-link" href="../Pages/login.aspx">Calculadora
                        <a class="navbar-link">Iniciar Sesión
                        </a>
                    </div>
                </div>
            </nav>
</div>
       <br><br><br>

  <div class="row" style="text-align:center">
  <div class="side" style="z-index: 101;">
    <div class="cardHorizontal1" style="text-align:center; font-size:50px; font-weight: bold; color:black" > 
        <h1> PRÉSTAMO CORPORATIVO </h1>
    </div>

      <div class="cardHorizontal2" > 


          <h1 style="color:#ee8133; font-size:30px; font-weight: bold;"> ¿Tiene algún imprevisto? </h1>
          <br>
          <p style="font-size:25px"> Haga realidad los planes de expansión de su empresa,
                mejore la productividad y competitividad con el respaldo de Banco NAV.  </p>
          <asp:Button runat="server" ID="btncorreo" style="display:inline; width:auto; height:auto; font-size:15px" class="button is-info is-outlined" Text="Información por correo" OnClick="btncorreo_Click"/>
    </div>

    <div class="cardVertical" style="display: flex; color:white;font-weight: bold;text-align:center">
  
      <div class="card-content">

          <h2> Beneficios</h2>
          <br> 
          <img style="width:40%;height:auto" src="../img/beneficios.png" /> 
          <br> 
          <br> 
          <p> -Historial crediticio alto.</p>
          <br> 
          <p> -Flexibilidad en tipo garantía.</p>
          <br> 
          <p> -Plazos de hasta 240 meses (20 años).</p>
          <br> 
          <p> -Trámites fáciles y agiles. </p>
          
      </div>
      
    </div>
    
    <div class="cardVertical" style="display: flex; color:white;font-weight: bold;" >
      
      <div class="card-content">
          <h2 style="text-align:center"> Requisitos</h2>
          <br> 
          <img style="width:40%;height:auto" src="../img/requisitosvertical.png" /> 
          <br> 
          <br>  
          <p> -Solicitud de crédito junto con los formularios debidamente completos y firmados. </p>
          <p> -Aceptación de los términos y condiciones del banco NAV.</p>
          <p> -Ingresos mensuales mínimo de 400.000 colones (presentar constancia de salario), en caso de ser independiente mostrar los últimos registros de ingresos.</p>
          <p> -Ser mayor de 21 años. </p>
          <p> -Antigüedad laboral mínima deberá ser de 12 meses. </p>

      </div>
      
    </div>
    
      </div>

      <div class="main">        
      

     <div class="cardRequisitos" style="text-align:center;">
    
                <div class="card-content" style="text-align:center">
      
      <div  style="padding-left: 40px; padding-right: 40px;text-align:center">
        <div  style="float:left" class="circulo">  
            <div align="center">  
                <img style="height:80%; width:auto; margin: 0 auto; text-align:center" src="../img/calculadora.png"/> 
            </div> 
        </div>
        <div style="float:right" class="circulo">     
            <img style="height:80%; width:auto; margin: 0 auto; text-align:center" src="../img/monitor.png"/> 
        </div>
      </div>
      
       <br/>
       <br/>
      
      <div >
          
      <asp:Button runat="server" ID="btncalcu" style="display:inline;width:35%;font-size:15px" class="button is-info is-outlined" Text="Calculadora" OnClick="btncalcu_Click"/>
      <asp:Button runat="server" ID="btnformu" style="display:inline; width:35%; font-size:15px; top: 0px; left: 0px;" class="button is-info is-outlined" Text="Formulario" OnClick="btnformu_Click"/>

      </div>
      
    </div>


  </div>
      <div style="text-align:center; ">
    
    <img class="azul1"  src="../img/corporativo.jpg"/>
  </div>
      </div>
      
</div>
       <br>


        <!-- Footer -->
                <!-- Footer -->
          <footer class="footer">
          <div class="content has-text-centered">
              <div>
                  
                  <p style="font-size:10px;"> 
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

