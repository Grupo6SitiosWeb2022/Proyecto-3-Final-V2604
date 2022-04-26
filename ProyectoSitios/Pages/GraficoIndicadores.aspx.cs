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
    public partial class GraficoIndicadores : System.Web.UI.Page
    {
        Nsolicitudes soli = new Nsolicitudes();
        string auxprestamo = "";
        NCalculadora calc = new NCalculadora();
        NIndicadores ni = new NIndicadores();
        NRoles nroles = new NRoles();
        Nusuarios nusuarios = new Nusuarios();
        static string identificacion = "", pass = "";
        static int tipoRol = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarusuario(UsuarioLogin.Usuario1);
            }
            lblerror.Visible = false;
            cargarClic();
            cargarSegundos();
            cargarau();
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

        public void cargarClic()
        {
            string[,] ListaDatos = new string[6, 3];
            ListaDatos = ni.ListarClick();
            int[] barras = new int[6];
            string[] prestamo = new string[6];
            string nprestamo = "";
            for (int i = 0; i < 6; i++)
            {
                List<Prestamos> prest = calc.ListarPrestamos();
                ListItem ip;
                foreach (Prestamos pr in prest)
                {
                    if (pr.CodigoPrestamo.ToString().Equals(ListaDatos[i, 1]))
                    {
                        nprestamo = pr.NombrePrestamo.ToString();
                    }
                }
                int n = Convert.ToInt32(ListaDatos[i, 0]);
                barras[i] = n;
                prestamo[i] = nprestamo;
            }

            ListaDatos = ni.ListarClick();
            chartclic.Series["serieclic"].Points.DataBindXY(prestamo, barras);
        }
        public void cargarSegundos()
        {
            string[,] ListaDatos = new string[6, 3];
            ListaDatos = ni.ListarSegundos();
            int[] barras = new int[6];
            string[] prestamo = new string[6];
            string nprestamo = "";

            for (int i = 0; i < 6; i++)
            {
                List<Prestamos> prest = calc.ListarPrestamos();
                ListItem ip;
                foreach (Prestamos pr in prest)
                {
                    if (pr.CodigoPrestamo.ToString().Equals(ListaDatos[i, 1]))
                    {
                        nprestamo = pr.NombrePrestamo.ToString();
                    }
                }
                int n = Convert.ToInt32(ListaDatos[i, 0]);
                barras[i] = n;
                prestamo[i] = nprestamo;

            }

            ListaDatos = ni.ListarSegundos();
            chartSeg.Series["serieseg"].Points.DataBindXY(prestamo, barras);
        }

        public void cargarau()
        {
            string[,] ListaDatos = new string[2, 3];
            ListaDatos = ni.ListarAutenticados();
            int[] barras = new int[6];
            string[] prestamo = new string[6];
            string nprestamo = "";

            for (int i = 0; i < 2; i++)
            {
                int n = Convert.ToInt32(ListaDatos[i, 0]);
                barras[i] = n;
                if (Convert.ToInt32(ListaDatos[i, 1]) == 3)
                {
                    nprestamo = "Autenticados";
                }
                else
                {
                    nprestamo = "No autenticados";
                }
                prestamo[i] = nprestamo;
            }

            ListaDatos = ni.ListarClick();
            chartau.Series["serieau"].Points.DataBindXY(prestamo, barras);
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

        public void cargarClicf(DateTime fechaI, DateTime fechaf)
        {
            string[,] ListaDatos = new string[6, 3];
            ListaDatos = ni.ListarClickf(fechaI, fechaf);
            int[] barras = new int[6];
            string[] prestamo = new string[6];
            string nprestamo = "";
            if ((ListaDatos[0, 1].Equals("")) && ListaDatos[1, 1].Equals("") && ListaDatos[2, 1].Equals("") &&
                ListaDatos[3, 1].Equals("") && ListaDatos[4, 1].Equals("") && ListaDatos[5, 1].Equals(""))
            {
                prestamo[0] = "Préstamo personal";
                prestamo[1] = "Préstamo vehicular";
                prestamo[2] = "Préstamo salud";
                prestamo[3] = "Préstamo pyme";
                prestamo[4] = "Préstamo cooperativa";
                prestamo[5] = "Préstamo vivienda";
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    List<Prestamos> prest = calc.ListarPrestamos();
                    ListItem ip;
                    foreach (Prestamos pr in prest)
                    {
                        if (pr.CodigoPrestamo.ToString().Equals(ListaDatos[i, 1]))
                        {
                            nprestamo = pr.NombrePrestamo.ToString();
                        }
                    }
                    int n = Convert.ToInt32(ListaDatos[i, 0]);
                    barras[i] = n;
                    prestamo[i] = nprestamo;
                }
            }

            ListaDatos = ni.ListarClickf(fechaI, fechaf);
            chartclic.Series["serieclic"].Points.DataBindXY(prestamo, barras);
        }

        public void cargarSegundosf(DateTime fechaI, DateTime fechaf)
        {
            string[,] ListaDatos = new string[6, 3];
            ListaDatos = ni.ListarSegundosf(fechaI, fechaf);
            int[] barras = new int[6];
            string[] prestamo = new string[6];
            string nprestamo = "";
            if ((ListaDatos[0, 1].Equals("")) && ListaDatos[1, 1].Equals("") && ListaDatos[2, 1].Equals("") &&
                ListaDatos[3, 1].Equals("") && ListaDatos[4, 1].Equals("") && ListaDatos[5, 1].Equals(""))
            {
                prestamo[0] = "Préstamo personal";
                prestamo[1] = "Préstamo vehicular";
                prestamo[2] = "Préstamo salud";
                prestamo[3] = "Préstamo pyme";
                prestamo[4] = "Préstamo cooperativa";
                prestamo[5] = "Préstamo vivienda";
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    List<Prestamos> prest = calc.ListarPrestamos();
                    ListItem ip;
                    foreach (Prestamos pr in prest)
                    {
                        if (pr.CodigoPrestamo.ToString().Equals(ListaDatos[i, 1]))
                        {
                            nprestamo = pr.NombrePrestamo.ToString();
                        }
                    }
                    int n = Convert.ToInt32(ListaDatos[i, 0]);
                    barras[i] = n;
                    prestamo[i] = nprestamo;
                }
            }

            ListaDatos = ni.ListarSegundosf(fechaI, fechaf);
            chartSeg.Series["serieseg"].Points.DataBindXY(prestamo, barras);
        }

        public void cargarauf(DateTime fechaI, DateTime fechaf)
        {
            string[,] ListaDatos = new string[2, 3];
            ListaDatos = ni.ListarAutenticadosf(fechaI, fechaf);
            int[] barras = new int[6];
            string[] prestamo = new string[6];
            string nprestamo = "";
            if ((ListaDatos[0, 1].Equals("")) && ListaDatos[1, 1].Equals(""))
            {
                prestamo[0] = "Autenticados";
                prestamo[1] = "No autenticados";
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    int n = Convert.ToInt32(ListaDatos[i, 0]);
                    barras[i] = n;
                    int p = Convert.ToInt32(ListaDatos[i, 0]);
                    if (p == 3)
                    {
                        nprestamo = "Autenticados";
                    }
                    else
                    {
                        nprestamo = "No autenticados";
                    }
                    prestamo[i] = nprestamo;
                }
            }

            ListaDatos = ni.ListarClick();
            chartau.Series["serieau"].Points.DataBindXY(prestamo, barras);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void ddlTipoPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {

            string fechaI = Request.Form["fechainicio"];

            string fechaF = Request.Form["fechafin"];

            if (fechaI.Equals("") && fechaF.Equals(""))
            {
                cargarClic();
                cargarSegundos();
                cargarau();
            }
            else
            {
                if (validarfechas(Convert.ToDateTime(fechaI), Convert.ToDateTime(fechaF)) == false)
                {
                    cargarClicf(Convert.ToDateTime(fechaI), Convert.ToDateTime(fechaF));
                    cargarSegundosf(Convert.ToDateTime(fechaI), Convert.ToDateTime(fechaF));
                    cargarauf(Convert.ToDateTime(fechaI), Convert.ToDateTime(fechaF));
                }
                else
                {
                    cargarClic();
                    cargarSegundos();
                    cargarau();
                    lblerror.Visible = true;
                    lblerror.Text = "Rango de fechas incorrecto";
                }

            }
        }
    }
}