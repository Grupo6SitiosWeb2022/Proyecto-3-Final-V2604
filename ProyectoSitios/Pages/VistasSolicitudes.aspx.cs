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
    public partial class VistasSolicitudes : System.Web.UI.Page
    {
        Nsolicitudes soli = new Nsolicitudes();
        NCorreo correos = new NCorreo();
        Nusuarios user = new Nusuarios();
        string nombreAnalista = "";
        string auxprestamo = "";
        NRoles nroles = new NRoles();
        Nusuarios nusuarios = new Nusuarios();
        NCalculadora calc = new NCalculadora();
        static int tipoRol = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
           
            if (!IsPostBack)
            {
                cargarvistas();
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

        public bool validarfechas(DateTime fechaI, DateTime fechaf)
        {
            bool validacion = false;

            if (fechaI > fechaf)
            {
                return true;
            }
            else if (fechaf < fechaI)
            {
                return true;
            }

            return validacion;
        }

        public void cargarvistas()
        {

            List<PrestamoSolcitudCredito> solcitudCreditos = soli.ListarVistas();

                foreach (PrestamoSolcitudCredito solcitud in solcitudCreditos)
                {
                    string estadp = solcitud.EstadoSolicitud.ToLower();

                    //if (estadp.Contains("pendiente"))
                    //{
                        string numSoli = solcitud.NumSolicitud.ToString();
                        string identificacion = solcitud.Identificacion;
                        string nombre = solcitud.NombreCompleto.ToString();
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
                ,  new TableCell { Text = codigoprestamo }, new TableCell { Text = monto } , new TableCell { Text = fecha }, new TableCell { Text = estadp }};
                      
                        row.Cells.AddRange(cell);
                        TablaVistas.Rows.Add(row);

                    //}
                //}
            }
        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            string fechaI = Request.Form["fechainicio"];

            string fechaF = Request.Form["fechafin"];
            if (fechaI.Equals("") && fechaF.Equals(""))
            {
                cargarvistas();
            }
            else
            {
                if (validarfechas(Convert.ToDateTime(fechaI), Convert.ToDateTime(fechaF)) == false)
                {

                    List<PrestamoSolcitudCredito> solcitudCreditos = soli.ListarFiltro(Convert.ToDateTime(fechaI), Convert.ToDateTime(fechaF));

                    foreach (PrestamoSolcitudCredito solcitud in solcitudCreditos)
                    {
                       
                            string estadp = solcitud.EstadoSolicitud.ToLower();

                            //if (estadp.Contains("pendiente"))
                            //{
                            string numSoli = solcitud.NumSolicitud.ToString();
                            string identificacion = solcitud.Identificacion;
                            string nombre = solcitud.NombreCompleto.ToString();
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
                ,  new TableCell { Text = codigoprestamo }, new TableCell { Text = monto } , new TableCell { Text = fecha }, new TableCell { Text = estadp }};

                            row.Cells.AddRange(cell);
                            TablaVistas.Rows.Add(row);
                        
                    }
                }
                else
                {
                    cargarvistas();
                    lblerror.Visible = true;
                    lblerror.Text = "Rango de fechas incorrecto";
                }
            }

        }
    }
}