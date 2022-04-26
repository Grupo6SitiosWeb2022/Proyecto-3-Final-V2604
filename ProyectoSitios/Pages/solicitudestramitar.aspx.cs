using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaDatos;
using CapaNegocio;
namespace ProyectoSitios.Pages
{
    public partial class solicitudestramitar : System.Web.UI.Page
    {
        Nsolicitudes soli = new Nsolicitudes();
        NCorreo correos = new NCorreo();
        Nusuarios user = new Nusuarios();
        string nombreAnalista = "";
        string auxprestamo = "";
        NCalculadora calc = new NCalculadora();
        NRoles nroles = new NRoles();
        Nusuarios nusuarios = new Nusuarios();
        static int tipoRol = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            if (!IsPostBack)
            {
                cargarprestamos();
                cargarSolicitudes();
                cargarusuario(UsuarioLogin.Usuario1);
            }
        }
        public void cargarusuario(string identificacion)
        {
            string resultado;
            try
            {
                List<Roles> roleslist = nroles.ListarRoles();
                List<Usuarios> usuariolist = nusuarios.ListarUsuarios();

                foreach (Usuarios usuario in usuariolist)
                {
                    if (identificacion.Equals(usuario.Identificacion))
                    {
                        identificacion = usuario.Identificacion;

                        tipoRol = Convert.ToInt32(usuario.TipoRol);
                        foreach (Roles rol in roleslist)
                        {
                            if (tipoRol == rol.IdTipoRol)
                            {
                                lblRol.Text = rol.NombreRol;
                            }
                        }

                        lblUsuario.Text = usuario.NombreCompleto.ToString();
                    }

                }



            }
            catch (Exception ex)
            {
                resultado = "Hubo un error";
            }

        }
        public void cargarSolicitudes()
        {
            List<PrestamoSolcitudCredito> solcitudCreditos = soli.ListarVistas();

            if (auxprestamo.Equals(" ")|| auxprestamo.Equals("--Selecciona un préstamo--"))
            {

                foreach (PrestamoSolcitudCredito solcitud in solcitudCreditos)
                {
                    string estadp = solcitud.EstadoSolicitud.ToLower();

                    if (estadp.Contains("pendiente"))
                    {
                        string numSoli = solcitud.NumSolicitud.ToString();
                        string identificacion = solcitud.Identificacion;
                        string nombre = solcitud.NombreCompleto.ToString();
                        string telefono = solcitud.Telefono.ToString();
                        string moneda = solcitud.Moneda.ToString();
                        string monto = solcitud.MontoSolicitado.ToString();
                        string plazo = solcitud.Plazo.ToString();
                        string codigoprestamo="";
                        List<Prestamos> prest = calc.ListarPrestamos();
                        ListItem i;
                        foreach (Prestamos prestamo in prest)
                        {
                            if (prestamo.CodigoPrestamo.ToString().Equals(solcitud.CodigoPrestamo.ToString()))
                            {
                                 codigoprestamo = prestamo.NombrePrestamo.ToString();
                            }
                        }

                       
                        string fecha = solcitud.FechaSolicitud.ToString("dd-MM-yyyy");
                        string auxmoneda = "";
                        if (moneda == "1")
                        {
                            auxmoneda = "Dolares";
                        }
                        else if (moneda == "2")
                        {
                            auxmoneda = "Colones";
                        }
                        TableRow row = new TableRow();
                        TableCell[] cell = new TableCell[] { new TableCell { Text = numSoli }, new TableCell { Text = identificacion }
                ,  new TableCell { Text = codigoprestamo }, new TableCell { Text = monto } , new TableCell { Text = fecha }};
                        //cell.Text = word.ToString();
                        row.Cells.AddRange(cell);
                        TablaSolicitudes.Rows.Add(row);

                    }
                }
            }
            else
            {
                foreach (PrestamoSolcitudCredito solcitud in solcitudCreditos)
                {
                    string estadp = solcitud.EstadoSolicitud.ToLower();

                    if (solcitud.CodigoPrestamo.ToString().Contains(auxprestamo) && estadp.Contains("pendiente"))
                    {
                        string numSoli = solcitud.NumSolicitud.ToString();
                        string identificacion = solcitud.Identificacion;
                        string telefono = solcitud.Telefono.ToString();
                        string moneda = solcitud.Moneda.ToString();
                        string monto = solcitud.MontoSolicitado.ToString();
                        string plazo = solcitud.Plazo.ToString();
                        string codigoprestamo = "";
                        List<Prestamos> prest = calc.ListarPrestamos();
                        ListItem i;
                        foreach (Prestamos prestamo in prest)
                        {
                            if (prestamo.CodigoPrestamo.ToString().Equals(solcitud.CodigoPrestamo.ToString()))
                            {
                                codigoprestamo = prestamo.NombrePrestamo.ToString();
                            }
                        }
                        string fecha = solcitud.FechaSolicitud.ToString("dd-MM-yyyy");
                        string auxmoneda = "";
                        if (moneda == "1")
                        {
                            auxmoneda = "Dolares";
                        }
                        else if (moneda == "2")
                        {
                            auxmoneda = "Colones";
                        }
                        TableRow row = new TableRow();
                        TableCell[] cell = new TableCell[] { new TableCell { Text = numSoli }, new TableCell { Text = identificacion }
                , new TableCell { Text = codigoprestamo }, new TableCell { Text = monto } , new TableCell { Text =  fecha}};

                        //cell.Text = word.ToString();
                        row.Cells.AddRange(cell);
                        TablaSolicitudes.Rows.Add(row);

                    }
                }
            }
        }

        public void cargarprestamos()
        {
            List<Prestamos> prest = calc.ListarPrestamos();
            ListItem i;
            foreach (Prestamos prestamo in prest)
            {

                i = new ListItem(prestamo.NombrePrestamo, prestamo.CodigoPrestamo.ToString());
                ddltipo.Items.Add(i);
            }
        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            //boton
            auxprestamo = ddltipo.SelectedValue;
            cargarSolicitudes();
            auxprestamo = " ";

        }

        protected void btnAgregar_Click1(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlTipoPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddltipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtTramitar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btntramitar_Click1(object sender, EventArgs e)
        {
            int numerosolicitud = Convert.ToInt32(txtTramitar.Text);
            soli.EnviarSolicitud(numerosolicitud, "Tramitando");
            EnvioCorreo(Convert.ToInt32(numerosolicitud));
            cargarSolicitudes();
            auxprestamo = " ";
            lblerror.Visible = true;
            lblerror.Text = ("Se ha enviado la solicitud correctamente");
            lblerror.BackColor = System.Drawing.ColorTranslator.FromHtml("#9FF781");
        }

        public string cargarinfoanalista(int nums)
        {
            List<SolicitudesAnalista> prest = correos.Listarsolianalistas();
            ListItem i;
            string identificacionAnalista = "";
            foreach (SolicitudesAnalista soliana in prest)
            {




                if (soliana.NumSolicitud == nums)
                {
                    string numSoli = soliana.NumSolicitud.ToString();
                    identificacionAnalista = soliana.AnalistaEncargado;



                }
            }
            return identificacionAnalista;
        }
        public void EnvioCorreo(int numsoli)
        {



            string identificacion = cargarinfoanalista(numsoli);
            string correoanalista = cargarcorreoanalista(numsoli);



            string body1 = @"<style>
h1{color:#ee8133;font-size: 25px; font-weight: bold; text-align: center;}
h6{color:black; font-size: medium;}
img {text-align: center; width: 450px; height: auto;}
</style>
" +



            $"<center><img src='https://drive.google.com/uc?export=download&id=1Xkt39Q8Xh8R53hEmTxPVh535AcRKF-_I'> </img></center>" +
            $"<h1> Nueva solicitud a analizar</ h1 > " +



            $"<h6> Estimad@ analista {nombreAnalista}, cuya identificación es {identificacion} tiene una nueva solicitud para realizar su debido análisis. </ h6 >" +




            $"<h6> Si la solicitud {numsoli} no se refleja para analizar, por favor reportar el problema con el departamento de TI. </h6>" +



            $"<h6> Estimado usuario, esta notificación es generada de forma automática de acuerdo con lo establecido por el Banco NAV, en su reglamento interno, por lo que agradecemos no responder este correo. </h6>" +



            $"<h6> Saludos. </h6>";



            correos.sendMail(correoanalista, "Nueva solicitud a analizar.", body1);


        }



        public string cargarcorreoanalista(int nums)
        {
            string identificacion = cargarinfoanalista(nums);
            List<Usuarios> prest = user.ListarUsuarios();
            ListItem i;
            string correoanalista = "";
            foreach (Usuarios usuarios in prest)
            {



                if (usuarios.Identificacion == identificacion)
                {

                    correoanalista = usuarios.CorreoElectronico;
                    nombreAnalista = usuarios.NombreCompleto;



                }



            }
            return correoanalista;
        }


    }
}