<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vistasinfo.aspx.cs" Inherits="ProyectoSitios.Pages.vistasinfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Vistas NAV</title>
    <meta name="viewport" content="width=device-width"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.1/css/bulma.min.css">
    <link href="https://fonts.googleapis.com/css2?family=Syne+Mono&display=swap" rel="stylesheet">
    <script src="https://use.fontawesome.com/releases/v5.1.0/js/all.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Arvo:ital@1&display=swap" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css2?family=Syne+Mono&display=swap" rel="stylesheet" />
    <link href="../css/bulma.css" rel="stylesheet" />
   <style>
        body {
	    font-family: 'Josefin Sans', sans-serif;
    font-size: 25px;
}
        p{
            font-size:15px;
        }


</style>
</head>
<body>
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
              <div style="margin-left: auto; margin-right: auto;">
            <h1 style="text-align: center; color: #061738; font-size: 50px; font-weight: bold;">Vistas de información</h1>
            <br />
            <br />
              <div class="HeaderTable" style="font-size:xx-large;">
                    <p style="display: inline; color: #ee8133; text-align: center; margin-left: 2%">
                    Rol:
              <asp:TextBox ID="txtFiltro" runat="server" CssClass="btnRoles" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
                    <p style="display: inline; color: #ee8133; text-align: center;">
                        <asp:Button ID="btnBuscar" runat="server" Text=" Buscar " CssClass="RolesButton" OnClick="btnBuscar_Click1" Font-Size="X-Large" />
                    </p>

                </p>
                <p style="display: inline; color: #ee8133; text-align: center; margin-left: 2%">
                    Código rol:
              <asp:TextBox ID="txtCodRol" runat="server" CssClass="btnRoles"> </asp:TextBox>
                    Nombre rol:
              <asp:TextBox ID="txtNombreRol" runat="server" CssClass="btnRoles"> </asp:TextBox>

                    <asp:Button ID="btnAgregar" runat="server" Text=" Agregar " CssClass="RolesButton" OnClick="btnAgregar_Click1" Font-Size="X-Large"  />

                    <asp:Button ID="btnModificar" runat="server" Text=" Modificar " CssClass="RolesButton" OnClick="btnModificar_Click" Font-Size="X-Large"  />

                    <asp:Button ID="btnEliminar" runat="server" Text=" Eliminar " CssClass="RolesButton" OnClick="btnEliminar_Click" Font-Size="X-Large" />

                </p>

                </p>
            </div>
        </div>

        <div class="row4" style="text-align:center">
        <div class="side4" style="z-index: 101;text-align:center ">
    

      <div class="cardtendencias1" style="text-align:center;color:white;font-weight: bold;">
      <div class="card-content" style="text-align:center">
              <div>
                  
                  <h1 style="text-align: center;color:#061738;font-size:50px"> Vista de información</h1>
                  <h1 style="font-size:15px; color:transparent">__________________ ___________________ _________________ _____________ _______________ ____________  ____________ ______________ ____________ ______________ </h1>
                  <h4 style="text-align: center;color:#061738;font-size:20px"> Importante: Se mostrarán todos los creditos con sus respectivos valores, pero se permitira realizar filtrados por fechas.</h4>                  
                  <br />

                                 
              </div>


                    <div class="card-content" style="text-align:center; padding-left:25px;padding-right:25px;background-color:#061738;color:#ee8133; text-align:center; font-size:20px;border-radius: 15px;">

                                    <h2 style="text-align: center;color:white;font-size:25px"> Filtros </h2>
                         <br />
                      
                        Fecha ini:  <input style="width:30%;height:auto; margin-left: 5%" class="input is-rounded" type="date" placeholder="Fecha inicio"/>  
                        <br />
                      <br />
                        Fecha fin:  <input style="width:30%;height:auto;  margin-left: 5%" class="input is-rounded" type="date" placeholder="Fecha fin"/> 


                       <br />
                      <br />


                  <p style="text-align:center">
                     
                   
                 <p style="color:#ee8133; text-align:center;"> 

                       

                <select style=" width: 40%; height: 30px;">

                    <option>--Selecciona un tipo préstamo--</option>

                    <option>Personal</option>

                    <option>Salud</option>

                    <option>Vehículo</option>

                    <option>Vivienda</option>

                </select>
                     <p style="color:#ee8133; text-align:center;"><button class="button is-info is-outlined" style="width: 40%; height: auto;">
                        <span class="icon is-small">
                            <span class="material-icons">search</span>
                           
                        </span>

                    </button>
                        
              </p></p> 
       </div>  
    </div>
   </div>

 </div>
             </div>

            <!-- Fin tarjeta 1.2 -->
        
        <!-- Inicio tabla -->

       
         <div class="row" style="text-align:center">
        <div class="side" style="z-index: 101;text-align:center ">
    
        <div style="width: 90%; text-align:center; align-items:center;  margin-left:auto; margin-right:auto;">
        <asp:Table ID="tablevistas" runat="server" CssClass="table is-striped" ForeColor="black" HorizontalAlign="Center" Width="100%">
            <asp:TableHeaderRow ID="Table1HeaderRow" Style="color:black;" CssClass="CabezaTabla"
                ForeColor="black"
                BackColor="#061738"
                runat="server">
                <asp:TableHeaderCell
                    Scope="Column"
                    Text="Nombre Préstamo" />
                <asp:TableHeaderCell
                    Scope="Column"
                    Text="Num Solicitudes" />
                <asp:TableHeaderCell
                    Scope="Column"
                    Text="Soli. Pendientes" />
                <asp:TableHeaderCell
                    Scope="Column"
                    Text="Soli. Aceptadas" />
                <asp:TableHeaderCell
                    Scope="Column"
                    Text="Soli. Denegadas" />
            </asp:TableHeaderRow>              

        </asp:Table>
        
    </div>

   </div>
 </div>

                      <!-- Fin tabla -->
        

        

        
          
       <!-- Footer -->
          <footer class="footer1" style="margin-top:5%">
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



                  