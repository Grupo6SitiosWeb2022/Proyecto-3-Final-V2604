<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProyectoSitios.Pages.Index" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Banco NAV</title>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.1/css/bulma.min.css" />
<link href="https://fonts.googleapis.com/css2?family=Syne+Mono&display=swap" rel="stylesheet" />
<script src="https://use.fontawesome.com/releases/v5.1.0/js/all.js"></script>
<link rel="preconnect" href="https://fonts.googleapis.com" />
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
<link href="https://fonts.googleapis.com/css2?family=Josefin+Sans:wght@500&display=swap" rel="stylesheet" />
<script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>
<link href="../css/bulma1.css" rel="stylesheet" />



</head>



<body>
<form id="form1" runat="server">
<div>
<button class="buttonmenu" style="background-color: transparent;" type="button" onclick="location.href='https://www.facebook.com'">
<img style="width: 10%; left: 25px; top: 380px; position: absolute; z-index: 101; display: flex; margin-top: 4px;" src="../img/icono.png">
<img style="width: 20%; left: 0px; top: 390px; position: absolute; z-index: 99; display: flex;" src="../img/hexagono.png">
</button>





<div class="demo_wrap">
<img src="../img/Mascara.jpg">
<img class="azul" src="../img/20.png">
</div>
</div>



<br>
<br>
<br>
<br />
<br>
<br>
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
<a class="navbar-link" href="../Pages/PrestamosCoorporativos.aspx">Préstamo corporativa
</a>
</div>
<div class="navbar-end">
<a class="navbar-link" href="../Pages/CalcularPrestamos.aspx">Calculadora
</a>
</div>
<div class="navbar-end">
<a class="navbar-link" href="../Pages/login.aspx">Iniciar Sesión
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
<br />
<div style="text-align: center; background-color: #f1893f; margin-left: 2.5%; margin-right: 5%;">
<marquee direction="left">
<asp:Label ID="lblerror" runat="server" Style="height: auto; color:white; text-align: center; font-size: 25px;"></asp:Label>
</marquee>
</div>




<div class="row" style="text-align: center">
<div class="side" style="z-index: 101;">
<br />
<br />



<div class="tarjetaM" >
<div class="cardHorizontal2">
<br />
<div style="font-size: x-large">
<p>Con una de las </p>
<strong style="color: #061738">TASAS MÁS BAJAS</strong>
<p>del mercado </p>
</div>
<div class="cardHorizontal3">
<p>
Su amplio
<strong style="color: #ffffff">PLAN DE INVERSIÓN</strong>
</p>
<p>le permite atender diversas necesidades </p>
</div>
<br />
<strong style="color: #061738">Solicite su crédito </strong>
<br />
<div style="text-align: center;">
<button class="button is-info is-outlined" style="width: 200px; height: 40px">
<span>Aqui</span>



</button>
</div>
<br />
<br />



</div>
<br />



</div>



<br />
<div class="cardHorizontal2A">
<img src="../img/Puno.png" />
</div>
</div>



<div class="main">
<br />
<br />




<div class="tarjetaP">
<div class="prueba" style="width: 300px; height: 500px;">
<div style="margin-left: auto; margin-right: auto;">
<img src="../img/IPI.png">
</div>
<div class="cardVertical" style="display: flex; color: white; font-weight: bold; text-align: center;">
<div class="card-content">
<div>
<p>
Nuestras soluciones
personales le sacan
de apuros.
</p>
</div>



</div>



</div>
<div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
<button class="button is-info is-outlined" style="width: 70%; height: 40px">
<a class="enlace" href="../Pages/PrestamoPersonal.aspx">PERSONAL</a>
</button>
</div>
</div>



<div class="prueba" style="width: 300px;">
<div style="text-align: center">
<img src="../img/IPI.png">
</div>
<div class="cardVertical" style="display: flex; color: white; font-weight: bold; text-align: center">



<div class="card-content">



<div>
<p>
Con las mejores condiciones
según las necesidades
de su empresa.<p />
</div>
</div>



</div>
<div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
<button class="button is-info is-outlined" style="width: 70%; height: 40px">
<a class="enlace" href="../Pages/PrestamoPyme.aspx">PYMES</a>
</button>
</div>
</div>




<div class="prueba" style="width: 300px;">
<div style="text-align: center">
<img src="../img/IPI.png">
</div>
<div class="cardVertical" style="display: flex; color: white; font-weight: bold; text-align: center">



<div class="card-content">



<div>
<p>
Impulsamos su empresa
con nuestros créditos
</p>
</div>
</div>



</div>
<div style="text-align: center; width: 100%; margin-left: auto; margin-right: auto;">
<button class="button is-info is-outlined" style="width: 70%; height: 40px">
<a class="enlace" href="../Pages/PrestamoCoorporativo.aspx">CORPORATIVO</a>
</button>
</div>
</div>



</div>



<br />




<div class="cardHorizontal2A">
<img src="../img/PdosP.png" />
</div>



</div>
<br />
</div>




<!-- Footer -->
<!-- Footer -->
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
</html