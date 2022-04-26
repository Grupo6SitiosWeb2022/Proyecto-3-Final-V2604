using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;

namespace ProyectoSitios.Pages
{
    public partial class aprobacioncreditos : System.Web.UI.Page
    {

        Nsolicitudes soli = new Nsolicitudes();
        Nprestamos pres = new Nprestamos();
        NCorreo correos = new NCorreo();
        Nusuarios user = new Nusuarios();
        NRoles nroles = new NRoles();
        Nusuarios nusuarios = new Nusuarios();
        static int tipoRol = 0;
        string auxprestamo = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            if (!IsPostBack)
            {
                cargarSolicitudes();

                cargarprestamos();
                cargarusuario(UsuarioLogin.Usuario1);

            }
            lblerror.Visible = false;
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
        public void cargarprestamos()
        {
            List<Prestamos> prest = pres.Listarprestamos();
            ListItem i;
            foreach (Prestamos prestamo in prest)
            {

                i = new ListItem(prestamo.NombrePrestamo, prestamo.CodigoPrestamo.ToString());
                ddltipo.Items.Add(i);
            }
        }
        public void cargarSolicitudes()
        {
            List<SolicitudesAnalista> analistas = correos.Listarsolianalistas();
            List<PrestamoSolcitudCredito> solcitudCreditos = soli.ListarVistas();

            if (auxprestamo.Equals(""))
            {

                foreach (SolicitudesAnalista solcitud1 in analistas)
                {
                    if (solcitud1.AnalistaEncargado.Equals(LUser.Analista))
                    {
                        string numSoli = solcitud1.NumSolicitud.ToString();

                        foreach (PrestamoSolcitudCredito solcitud in solcitudCreditos)
                        {
                            if (solcitud.EstadoSolicitud.Contains("Tramitando") && solcitud.NumSolicitud == Convert.ToInt32(numSoli))
                            {
                                string numSoli1 = solcitud.NumSolicitud.ToString();
                                string identificacion = solcitud.Identificacion;
                                string telefono = solcitud.Telefono.ToString();
                                string moneda = solcitud.Moneda.ToString();
                                string monto = solcitud.MontoSolicitado.ToString();

                                string salario = solcitud.SalarioLiquido.ToString();
                                string plazo = solcitud.Plazo.ToString();
                                string codigoprestamo = solcitud.CodigoPrestamo.ToString();
                                string endudamiento = solcitud.PorcentajeEndeudamiento.ToString();

                                List<Prestamos> prest = pres.Listarprestamos();
                                ListItem i;
                                foreach (Prestamos prestamo in prest)
                                {
                                    if (prestamo.CodigoPrestamo.ToString().Equals(solcitud.CodigoPrestamo.ToString()))
                                    {
                                        codigoprestamo = prestamo.NombrePrestamo.ToString();
                                    }
                                }
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
                                TableCell[] cell = new TableCell[] { new TableCell { Text = numSoli1 }, new TableCell { Text = identificacion }
                ,  new TableCell { Text = telefono } , new TableCell { Text = auxmoneda }
                , new TableCell { Text = monto } , new TableCell { Text = salario }
                , new TableCell { Text = plazo }
                , new TableCell { Text = codigoprestamo } , new TableCell { Text = endudamiento }};
                                //cell.Text = word.ToString();
                                row.Cells.AddRange(cell);
                                tablausu.Rows.Add(row);

                            }
                        }

                    }
                }
            }
            else
            {
                foreach (SolicitudesAnalista solcitud1 in analistas)
                {
                    if (solcitud1.AnalistaEncargado.Equals(LUser.Analista))
                    {
                        string numSoli = solcitud1.NumSolicitud.ToString();

                        foreach (PrestamoSolcitudCredito solcitud in solcitudCreditos)
                        {
                            if (solcitud.EstadoSolicitud.Contains("Tramitando") && solcitud.NumSolicitud == Convert.ToInt32(numSoli) && solcitud.CodigoPrestamo.ToString().Contains(auxprestamo))
                            {
                                string numSoli1 = solcitud.NumSolicitud.ToString();
                                string identificacion = solcitud.Identificacion;
                                string telefono = solcitud.Telefono.ToString();
                                string moneda = solcitud.Moneda.ToString();
                                string monto = solcitud.MontoSolicitado.ToString();

                                string salario = solcitud.SalarioLiquido.ToString();
                                string plazo = solcitud.Plazo.ToString();
                                string codigoprestamo = solcitud.CodigoPrestamo.ToString();
                                string endudamiento = solcitud.PorcentajeEndeudamiento.ToString();

                                List<Prestamos> prest = pres.Listarprestamos();
                                ListItem i;
                                foreach (Prestamos prestamo in prest)
                                {
                                    if (prestamo.CodigoPrestamo.ToString().Equals(solcitud.CodigoPrestamo.ToString()))
                                    {
                                        codigoprestamo = prestamo.NombrePrestamo.ToString();
                                    }
                                }
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
                                TableCell[] cell = new TableCell[] { new TableCell { Text = numSoli1 }, new TableCell { Text = identificacion }
                ,  new TableCell { Text = telefono } , new TableCell { Text = auxmoneda }
                , new TableCell { Text = monto } , new TableCell { Text = salario }
                , new TableCell { Text = plazo }
                , new TableCell { Text = codigoprestamo } , new TableCell { Text = endudamiento }};
                                //cell.Text = word.ToString();
                                row.Cells.AddRange(cell);
                                tablausu.Rows.Add(row);

                            }
                        }

                    }
                }
            }
        }

        public void au()
        {
            List<SolicitudesAnalista> analistas = correos.Listarsolianalistas();
            List<PrestamoSolcitudCredito> solcitudCreditos = soli.ListarVistas();

            foreach (SolicitudesAnalista solcitud1 in analistas)
            {
                if (solcitud1.AnalistaEncargado.Equals(LUser.Analista))
                {
                    string numSoli = solcitud1.NumSolicitud.ToString();

                    foreach (PrestamoSolcitudCredito solcitud in solcitudCreditos)
                    {
                        if (solcitud.EstadoSolicitud.Contains("Tramitando") && solcitud.NumSolicitud == Convert.ToInt32(numSoli))
                        {
                            string numSoli1 = solcitud.NumSolicitud.ToString();
                            string identificacion = solcitud.Identificacion;
                            string telefono = solcitud.Telefono.ToString();
                            string moneda = solcitud.Moneda.ToString();
                            string monto = solcitud.MontoSolicitado.ToString();

                            string salario = solcitud.SalarioLiquido.ToString();
                            string plazo = solcitud.Plazo.ToString();
                            string codigoprestamo = solcitud.CodigoPrestamo.ToString();
                            string endudamiento = solcitud.PorcentajeEndeudamiento.ToString();

                            List<Prestamos> prest = pres.Listarprestamos();
                            ListItem i;
                            foreach (Prestamos prestamo in prest)
                            {
                                if (prestamo.CodigoPrestamo.ToString().Equals(solcitud.CodigoPrestamo.ToString()))
                                {
                                    codigoprestamo = prestamo.NombrePrestamo.ToString();
                                }
                            }
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
                            TableCell[] cell = new TableCell[] { new TableCell { Text = numSoli1 }, new TableCell { Text = identificacion }
                ,  new TableCell { Text = telefono } , new TableCell { Text = auxmoneda }
                , new TableCell { Text = monto } , new TableCell { Text = salario }
                , new TableCell { Text = plazo }
                , new TableCell { Text = codigoprestamo } , new TableCell { Text = endudamiento }};
                            //cell.Text = word.ToString();
                            row.Cells.AddRange(cell);
                            tablausu.Rows.Add(row);

                        }
                    }

                }
            }
        }
        public void EnvioCorreo(int numsoli)
        {
            List<PrestamoSolcitudCredito> solcitudCreditos = soli.ListarVistas();
            string numSoli = "";
            string nombre = "";
            string identificacion = "";
            string estado = "";
            string fecha = "";
            string correocliente = "";
            foreach (PrestamoSolcitudCredito solcitud in solcitudCreditos)
            {
                if (solcitud.NumSolicitud == numsoli)
                {
                    numSoli = solcitud.NumSolicitud.ToString();
                    nombre = solcitud.NombreCompleto.ToString();
                    identificacion = solcitud.Identificacion;
                    estado = solcitud.EstadoSolicitud.ToString();
                    fecha = solcitud.FechaSolicitud.ToString();
                    correocliente = solcitud.CorreoElectronico.ToString();

                    string salario = solcitud.SalarioLiquido.ToString();
                    string plazo = solcitud.Plazo.ToString("MMMM dd, yyyy");
                    string codigoprestamo = solcitud.CodigoPrestamo.ToString();
                    string endudamiento = solcitud.PorcentajeEndeudamiento.ToString();
                }
            }
            if (estado.Equals("Denegada"))
            {
                string body1 = @"<style>
                            h1{color:#ee8133;font-size: 25px; font-weight: bold; text-align: center;}
                            h6{color:black; font-size: medium;}
                            img {text-align: center; width: 450px; height: auto;}
                            </style>
                           " +

                            $"<center><img src='https://drive.google.com/uc?export=download&id=1Xkt39Q8Xh8R53hEmTxPVh535AcRKF-_I'> </img></center>" +
                            $"<h1> Solicitud de préstamo</ h1 > " +

                            $"<h6> Estimad@ {nombre}, usted solicitó un crédito con banco NAV, el día {fecha}. </ h6 >" +

                            $"<h6> El motivo de este correo es informarle que la solicitud número {numSoli}, cuya identificación de la persona encarga es {identificacion}, ha sido DENEGADA debido a que se sale de las políticas internas del banco. </ h6 >" +

                            $"<h6> Si desea más información puede presentarse a cualquiera de nuestras oficinas, también recordarle que comunicarse al número de teléfono 2211-1135. </h6>" +

                            $"<h6> Estimado cliente, esta notificación es generada de forma automática de acuerdo con lo establecido por el Banco NAV, en su reglamento interno, por lo que agradecemos no responder este correo. </h6>" +

                            $"<h6> Saludos. </h6>";

                correos.sendMail(correocliente, "Respuesta solicitud de préstamo.", body1);
            }
            else if (estado.Equals("Aprobada"))
            {
                string body1 = @"<style>
                            h1{color:#ee8133;font-size: 25px; font-weight: bold; text-align: center;}
                            h6{color:black; font-size: medium;}
                            img {text-align: center; width: 450px; height: auto;}
                            </style>
                            " +

                            $"<center><img src='https://drive.google.com/uc?export=download&id=1Xkt39Q8Xh8R53hEmTxPVh535AcRKF-_I'> </img></center>" +
                            $"<h1> Solicitud de préstamo</ h1 > " +
                            $"<h6> Estimad@ {nombre}, usted solicitó un crédito con banco NAV, el día {fecha}. </ h6 >" +
                            $"<h6> El motivo de este correo es informarle que la solicitud número {numSoli}, cuya identificación de la persona encarga es {identificacion}, ha sido Aceptada y cumple con todas las políticas del banco. </ h6 >" +
                            $"<h6> Presentarse lo más rápido posible a nuestras oficinas ubicadas en el país, para llevar a cabo la formalización del préstamo. </h6>" +
                            $"<h6> Si desea más información puede presentarse a cualquiera de nuestras oficinas, también recordarle que comunicarse al número de teléfono 2211-1135. </h6>" +
                            $"<h6> Estimado cliente, esta notificación es generada de forma automática de acuerdo con lo establecido por el Banco NAV, en su reglamento interno, por lo que agradecemos no responder este correo. </h6>" +

                            $"<h6> Saludos, Muchas gracias por elegirnos. </h6>";

                correos.sendMail(correocliente, "Respuesta solicitud de préstamo.", body1);

            }
        }



        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            List<PrestamoSolcitudCredito> solcitudCreditos = soli.ListarEndeudamiento(Convert.ToInt32(txtnumsoli.Text));
            string aux = "0";
            foreach (PrestamoSolcitudCredito solcitud in solcitudCreditos)
            {
                if (solcitud.NumSolicitud == Convert.ToInt32(txtnumsoli.Text) && solcitud.EstadoSolicitud == "Tramitando")
                {
                    aux = "1";
                }
            }
            if (txtnumsoli.Text.Length > 0 && aux.Equals("1"))
            {

                string estado = "Denegada";
                string resultado = soli.Modificar(Convert.ToInt32(txtnumsoli.Text), estado);
                int numsoli = Convert.ToInt32(txtnumsoli.Text);

                if (resultado.Equals("OK"))
                {
                    cargarSolicitudes();
                    EnvioCorreo(numsoli);
                }
                else
                {
                    cargarSolicitudes();
                    lblerror.Visible = true;
                    lblerror.Text = "Error: " + resultado;
                    txtnumsoli.Text = "";
                }

            }
            else
            {
                cargarSolicitudes();
                lblerror.Visible = true;
                lblerror.Text = "Error: " + "Numero de solicitud no válido.";
                txtnumsoli.Text = "";
            }

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {

            List<PrestamoSolcitudCredito> solcitudCreditos = soli.ListarEndeudamiento(Convert.ToInt32(txtnumsoli.Text));
            string aux = "";
            foreach (PrestamoSolcitudCredito solcitud in solcitudCreditos)
            {
                if (solcitud.NumSolicitud == Convert.ToInt32(txtnumsoli.Text))
                {
                    string endudamiento = solcitud.PorcentajeEndeudamiento.ToString();
                    aux = endudamiento;
                }
            }


            string aux1 = "0";
            foreach (PrestamoSolcitudCredito solcitud in solcitudCreditos)
            {
                if (solcitud.NumSolicitud == Convert.ToInt32(txtnumsoli.Text) && solcitud.EstadoSolicitud == "Tramitando")
                {
                    aux1 = "1";
                }
            }

            if (aux1.Equals("1"))
            {
                int numsoli = Convert.ToInt32(txtnumsoli.Text);
                if (txtnumsoli.Text.Length > 0)
                {
                    if (Convert.ToInt32(aux) > 40)
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Error: El porcentaje de endeudamiento es muy alto y no es aceptado por las políticas del Banco NAV.";
                        cargarSolicitudes();
                    }
                    else
                    {
                        string estado = "Aprobada";
                        string resultado = soli.Modificar(Convert.ToInt32(txtnumsoli.Text), estado);

                        if (resultado.Equals("OK"))
                        {

                            cargarSolicitudes();
                            EnvioCorreo(numsoli);

                        }
                        else
                        {
                            cargarSolicitudes();
                            lblerror.Visible = true;
                            lblerror.Text = "Error: " + resultado;
                            txtnumsoli.Text = "";

                        }
                    }
                }
                else
                {
                    cargarSolicitudes();
                    lblerror.Visible = true;
                    lblerror.Text = "Error: " + "Debe indicar un número de solicitud";
                    txtnumsoli.Text = "";
                }
            }
            else
            {
                cargarSolicitudes();
                lblerror.Visible = true;
                lblerror.Text = "Error: " + "Numero de solicitud no válido.";
                txtnumsoli.Text = "";
            }
        }

        protected void ddlTipoPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            auxprestamo = ddltipo.SelectedValue;
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            cargarSolicitudes();
        }

        protected void ddltipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            auxprestamo = ddltipo.SelectedValue;
            cargarSolicitudes();
            auxprestamo = " ";
        }
    }
}