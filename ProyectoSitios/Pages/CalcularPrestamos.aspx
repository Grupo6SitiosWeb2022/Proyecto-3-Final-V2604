<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalcularPrestamos.aspx.cs" Inherits="ProyectoSitios.Pages.CalcularPrestamos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
            <button class="buttonmenu" style="background-color: transparent;" type="button" onclick="location.href='https://www.facebook.com'">
                <img style="width: 10%; left: 25px; top: 380px; position: absolute; z-index: 101; display: flex; margin-top: 4px;" src="../img/icono.png" />
                <img style="width: 20%; left: 0px; top: 390px; position: absolute; z-index: 99; display: flex;" src="../img/hexagono.png" />
            </button>
            <div class="demo_wrap">
                <img src="../img/Mascara.jpg" />
                <img class="azul" src="../img/fondo_requisitos.png" />
            </div>
        </div>

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
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
                        <a class="navbar-link" href="../Pages/login.aspx">Inicio sesión
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
            <div class="BloqueCalculadora">
                <p>Realice aquí el cálculo de su cuota</p>
            </div>
            <div class="BloqueCalculadora">
                <h1>Consulte los préstamos personales disponibles aquí</h1>
                <button class="button is-info is-outlined" style="width: 200px; height: 30px;">
                    <a class="enlace" href="../Pages/PrestamoPersonal.aspx">Préstamo personal
                    </a>
                </button>
            </div>
        </div>
        <div class="contenedor">
            <div class="CalculadoraContenedorP">
                <div class="calculadora">
                    <div>
                    </div>
                    <div class="calculadora1">
                        <h1>Tipo de préstamo</h1>
                        <br />
                        <div>
                            <asp:DropDownList ID="ddlTipoPrestamo" runat="server" CssClass="ddl" OnSelectedIndexChanged="ddlTipoPrestamo_SelectedIndexChanged" OnTextChanged="ddlTipoPrestamo_SelectedIndexChanged">
                                <asp:ListItem>--Selecciona un préstamo--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <h1>Moneda</h1>
                        <br />
                        <div>
                            <asp:DropDownList ID="ddlMoneda" runat="server" CssClass="ddl" OnSelectedIndexChanged="ddlMoneda_SelectedIndexChanged">
                                <asp:ListItem>--Selecciona una moneda--</asp:ListItem>
                                <asp:ListItem>Dolares</asp:ListItem>
                                <asp:ListItem>Colones</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <h1>Monto Solicitado</h1>
                        <br />
                        <asp:TextBox ID="txtMonto" runat="server" CssClass="textbox" OnTextChanged="txtMonto_TextChanged"></asp:TextBox>&nbsp;<br />
                        <h1>Plazo en meses</h1>
                        <br />
                 

                        <div class="inputDiv" style="color:white;  font-size:x-large;">
<div id="etiqueta"></div>
<input id="input"  name="input" type="range" value="180" min="0" max="360" autocomplete="off" />
</div>
                               <br />
                        <script>
                            var elInput = document.querySelector('#input');
                            if (elInput) {
                                var etiqueta = document.querySelector('#etiqueta');
                                if (etiqueta) {
                                    etiqueta.innerHTML = elInput.value +" meses";

                                    elInput.addEventListener('input', function () {
                                        etiqueta.innerHTML = elInput.value + " meses";

                                    }, false);
                                }
                            }
                        </script>
                        <h1>Tasa de interés</h1>
                        <asp:Label ID="lblTasa" runat="server" Text="0%" CssClass="label" Font-Size="X-Large" ForeColor="White"></asp:Label>

                        <br />
                        <h2>Cuota Mensual</h2>
                        <asp:Label ID="lblCuotaMensual" runat="server" Text="₡ 000,000.00" CssClass="label" Font-Size="X-Large" ForeColor="White"></asp:Label>

                        <asp:Button class="button is-info is-outlined" Height="45px" ID="Button1" runat="server" Text="Calcular" OnClick="Button1_Click" />
                        <br />
                    </div>

                    <div class="calculadora2">
                        <img src="../img/mujer1.png" style="height: 100%;" />
                    </div>

                </div>
                <div class="CentrarAviso">
                    <div class="aviso">
                        <h1>Importante</h1>
                        <br />
                        <p>
                            El Banco NAV agradece su preferencia y le informa que este servicio es
                        únicamente como referencia para ayudarle en su decisión, sin embargo, 
                        debe considerar que las condiciones pueden variar ya que el precio final
                        esta determinado por otras condiciones como garantía, tasa de interés, 
                        comisiones, seguros y características propias de cada cliente. El Banco NAV
                        aclara que las condiciones de tasa que regirán el contrato serán las que estén 
                        vigentes el día de firma de crédito, posterior a la verificación del cumplimiento 
                        de algunas condiciones.
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
