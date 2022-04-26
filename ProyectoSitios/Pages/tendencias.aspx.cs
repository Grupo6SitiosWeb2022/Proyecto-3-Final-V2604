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
    public partial class tendencias : System.Web.UI.Page
    {
        NRoles nroles = new NRoles();
        Nusuarios nusuarios = new Nusuarios();
        static string identificacion = "", pass = "";
        static int tipoRol = 0;
        NIndicadores indicadores = new NIndicadores();

        string fechafin, fechaini;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarindicadoresclick();
            cargarindicadoresposi();
            cargarAu();
            cargarNOAu();

            if (!IsPostBack)
            {
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

        public void cargarindicadoresclick()
        {
            //Vectores
            string[] prestamo1;
            prestamo1 = new string[3];
            string[] prestamo2;
            prestamo2 = new string[3];
            string[] prestamo3;
            prestamo3 = new string[3];
            string[] prestamo4;
            prestamo4 = new string[3];
            string[] prestamo5;
            prestamo5 = new string[3];
            string[] prestamo6;
            prestamo6 = new string[3];

            //Vectores finales
            string[] lugar1;
            lugar1 = new string[3];
            string[] lugar2;
            lugar2 = new string[3];
            string[] lugar3;
            lugar3 = new string[3];

            //Variable bool
            bool primerlugar = false;
            bool segundolugar = false;
            bool tercerlugar = false;


            List<Indicadores> auxindica = indicadores.ListarIndicadores();

            foreach (Indicadores indicadores in auxindica)
            {
                if (indicadores.CodigotipoIndicador == 1)
                {
                    string fecha = indicadores.Fecha.ToString();
                    string codpres = indicadores.CodigoPrestamo.ToString();
                    string codTipo = indicadores.CodigotipoIndicador.ToString();
                    string cant = indicadores.Cantidad.ToString();

                    if (codpres == "2")
                    {

                        prestamo1[0] = "Personal";
                        prestamo1[1] = fecha;
                        int aux = (Convert.ToInt32(prestamo1[2]) + Convert.ToInt32(cant));
                        prestamo1[2] = Convert.ToString(aux);
                    }
                    if (codpres == "5")
                    {
                        prestamo2[0] = "Salud";
                        prestamo2[1] = fecha;
                        int aux = (Convert.ToInt32(prestamo2[2]) + Convert.ToInt32(cant));
                        prestamo2[2] = Convert.ToString(aux);
                    }
                    if (codpres == "6")
                    {
                        prestamo3[0] = "Vehicular";
                        prestamo3[1] = fecha;
                        int aux = (Convert.ToInt32(prestamo3[2]) + Convert.ToInt32(cant));
                        prestamo3[2] = Convert.ToString(aux);
                    }
                    if (codpres == "8")
                    {
                        prestamo4[0] = "Vivienda";
                        prestamo4[1] = fecha;
                        int aux = (Convert.ToInt32(prestamo4[2]) + Convert.ToInt32(cant));
                        prestamo4[2] = Convert.ToString(aux);
                    }
                    if (codpres == "9")
                    {
                        prestamo5[0] = "Préstamo pymes";
                        prestamo5[1] = fecha;
                        int aux = (Convert.ToInt32(prestamo5[2]) + Convert.ToInt32(cant));
                        prestamo5[2] = Convert.ToString(aux);
                    }
                    if (codpres == "10")
                    {
                        prestamo6[0] = "Préstamo corporativo";
                        prestamo6[1] = fecha;
                        int aux = (Convert.ToInt32(prestamo6[2]) + Convert.ToInt32(cant));
                        prestamo6[2] = Convert.ToString(aux);
                    }
                }
            }

            string aux1 = prestamo1[2];
            while (primerlugar == false || segundolugar == false || tercerlugar == false)
            {
                int n1 = Convert.ToInt32(prestamo1[2]);
                int n2 = Convert.ToInt32(prestamo2[2]);
                int n3 = Convert.ToInt32(prestamo3[2]);
                int n4 = Convert.ToInt32(prestamo4[2]);
                int n5 = Convert.ToInt32(prestamo5[2]);
                int n6 = Convert.ToInt32(prestamo6[2]);


                if (n1 > n2 && n1 > n3 && n1 > n4 && n1 > n5 && n1 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo1[0];
                        lugar1[1] = prestamo1[1];
                        lugar1[2] = prestamo1[2];
                        primerlugar = true;
                        prestamo1[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo1[0];
                        lugar2[1] = prestamo1[1];
                        lugar2[2] = prestamo1[2];
                        segundolugar = true;
                        prestamo1[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo1[0];
                        lugar3[1] = prestamo1[1];
                        lugar3[2] = prestamo1[2];
                        tercerlugar = true;
                        prestamo1[2] = "0";
                        continue;
                    }
                }
                if (n2 > n1 && n2 > n3 && n2 > n4 && n2 > n5 && n2 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo2[0];
                        lugar1[1] = prestamo2[1];
                        lugar1[2] = prestamo2[2];
                        primerlugar = true;
                        prestamo2[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo2[0];
                        lugar2[1] = prestamo2[1];
                        lugar2[2] = prestamo2[2];
                        segundolugar = true;
                        prestamo2[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo2[0];
                        lugar3[1] = prestamo2[1];
                        lugar3[2] = prestamo2[2];
                        tercerlugar = true;
                        prestamo2[2] = "0";
                        continue;
                    }
                }
                if (n3 > n1 && n3 > n2 && n3 > n4 && n3 > n5 && n3 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo3[0];
                        lugar1[1] = prestamo3[1];
                        lugar1[2] = prestamo3[2];
                        primerlugar = true;
                        prestamo3[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo3[0];
                        lugar2[1] = prestamo3[1];
                        lugar2[2] = prestamo3[2];
                        segundolugar = true;
                        prestamo3[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo3[0];
                        lugar3[1] = prestamo3[1];
                        lugar3[2] = prestamo3[2];
                        tercerlugar = true;
                        prestamo3[2] = "0";
                        continue;
                    }
                }
                if (n4 > n1 && n4 > n2 && n4 > n3 && n4 > n5 && n4 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo4[0];
                        lugar1[1] = prestamo4[1];
                        lugar1[2] = prestamo4[2];
                        primerlugar = true;
                        prestamo4[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo4[0];
                        lugar2[1] = prestamo4[1];
                        lugar2[2] = prestamo4[2];
                        segundolugar = true;
                        prestamo4[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo4[0];
                        lugar3[1] = prestamo4[1];
                        lugar3[2] = prestamo4[2];
                        tercerlugar = true;
                        prestamo4[2] = "0";
                        continue;
                    }
                }
                if (n5 > n1 && n5 > n2 && n5 > n3 && n5 > n4 && n5 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo5[0];
                        lugar1[1] = prestamo5[1];
                        lugar1[2] = prestamo5[2];
                        primerlugar = true;
                        prestamo5[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo5[0];
                        lugar2[1] = prestamo5[1];
                        lugar2[2] = prestamo5[2];
                        segundolugar = true;
                        prestamo5[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo5[0];
                        lugar3[1] = prestamo5[1];
                        lugar3[2] = prestamo5[2];
                        tercerlugar = true;
                        prestamo5[2] = "0";
                        continue;
                    }
                }
                if (n6 > n1 && n6 > n2 && n6 > n3 && n6 > n4 && n6 > n5)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo6[0];
                        lugar1[1] = prestamo6[1];
                        lugar1[2] = prestamo6[2];
                        primerlugar = true;
                        prestamo6[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo6[0];
                        lugar2[1] = prestamo6[1];
                        lugar2[2] = prestamo6[2];
                        segundolugar = true;
                        prestamo6[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo6[0];
                        lugar3[1] = prestamo6[1];
                        lugar3[2] = prestamo6[2];
                        tercerlugar = true;
                        prestamo6[2] = "0";
                        continue;
                    }
                }
                if (primerlugar == false)
                {
                    lugar1[0] = "No hay registros";
                    lugar1[1] = "";
                    lugar1[2] = "0";
                    primerlugar = true;
                    continue;

                }
                if (segundolugar == false)
                {
                    lugar2[0] = "No hay registros";
                    lugar2[1] = "";
                    lugar2[2] = "0";
                    segundolugar = true;
                    continue;
                }
                if (tercerlugar == false)
                {
                    lugar3[0] = "No hay registros";
                    lugar3[1] = "";
                    lugar3[2] = "0";
                    tercerlugar = true;
                    continue;
                }
            }

            lblclick1nom.Text = "Crédito: " + lugar1[0];
            lblclick1cant.Text = "Clik´s: " + lugar1[2];

            lblclick2nom.Text = "Crédito: " + lugar2[0];
            lblclick2cant.Text = "Clik´s: " + lugar2[2];

            lblclick3nom.Text = "Crédito: " + lugar3[0];
            lblclick3cant.Text = "Clik´s: " + lugar3[2];


        }

        public void cargarindicadoresposi()
        {
            //Vectores
            string[] prestamo1;
            prestamo1 = new string[3];
            string[] prestamo2;
            prestamo2 = new string[3];
            string[] prestamo3;
            prestamo3 = new string[3];
            string[] prestamo4;
            prestamo4 = new string[3];
            string[] prestamo5;
            prestamo5 = new string[3];
            string[] prestamo6;
            prestamo6 = new string[3];

            //Vectores finales
            string[] lugar1;
            lugar1 = new string[3];
            string[] lugar2;
            lugar2 = new string[3];
            string[] lugar3;
            lugar3 = new string[3];

            //Variable bool
            bool primerlugar = false;
            bool segundolugar = false;
            bool tercerlugar = false;


            List<Indicadores> auxindica = indicadores.ListarIndicadores();

            foreach (Indicadores indicadores in auxindica)
            {
                if (indicadores.CodigotipoIndicador == 2)
                {
                    string fecha = indicadores.Fecha.ToString();
                    string codpres = indicadores.CodigoPrestamo.ToString();
                    string codTipo = indicadores.CodigotipoIndicador.ToString();
                    string cant = indicadores.Cantidad.ToString();

                    if (codpres == "2")
                    {

                        prestamo1[0] = "Personal";
                        prestamo1[1] = fecha;
                        int aux = (Convert.ToInt32(prestamo1[2]) + Convert.ToInt32(cant));
                        prestamo1[2] = Convert.ToString(aux);
                    }
                    if (codpres == "5")
                    {
                        prestamo2[0] = "Salud";
                        prestamo2[1] = fecha;
                        int aux = (Convert.ToInt32(prestamo2[2]) + Convert.ToInt32(cant));
                        prestamo2[2] = Convert.ToString(aux);
                    }
                    if (codpres == "6")
                    {
                        prestamo3[0] = "Vehicular";
                        prestamo3[1] = fecha;
                        int aux = (Convert.ToInt32(prestamo3[2]) + Convert.ToInt32(cant));
                        prestamo3[2] = Convert.ToString(aux);
                    }
                    if (codpres == "8")
                    {
                        prestamo4[0] = "Vivienda";
                        prestamo4[1] = fecha;
                        int aux = (Convert.ToInt32(prestamo4[2]) + Convert.ToInt32(cant));
                        prestamo4[2] = Convert.ToString(aux);
                    }
                    if (codpres == "9")
                    {
                        prestamo5[0] = "Préstamo pymes";
                        prestamo5[1] = fecha;
                        int aux = (Convert.ToInt32(prestamo5[2]) + Convert.ToInt32(cant));
                        prestamo5[2] = Convert.ToString(aux);
                    }
                    if (codpres == "10")
                    {
                        prestamo6[0] = "Préstamo corporativo";
                        prestamo6[1] = fecha;
                        int aux = (Convert.ToInt32(prestamo6[2]) + Convert.ToInt32(cant));
                        prestamo6[2] = Convert.ToString(aux);
                    }
                }
            }

            string aux1 = prestamo1[2];
            while (primerlugar == false || segundolugar == false || tercerlugar == false)
            {
                int n1 = Convert.ToInt32(prestamo1[2]);
                int n2 = Convert.ToInt32(prestamo2[2]);
                int n3 = Convert.ToInt32(prestamo3[2]);
                int n4 = Convert.ToInt32(prestamo4[2]);
                int n5 = Convert.ToInt32(prestamo5[2]);
                int n6 = Convert.ToInt32(prestamo6[2]);


                if (n1 > n2 && n1 > n3 && n1 > n4 && n1 > n5 && n1 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo1[0];
                        lugar1[1] = prestamo1[1];
                        lugar1[2] = prestamo1[2];
                        primerlugar = true;
                        prestamo1[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo1[0];
                        lugar2[1] = prestamo1[1];
                        lugar2[2] = prestamo1[2];
                        segundolugar = true;
                        prestamo1[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo1[0];
                        lugar3[1] = prestamo1[1];
                        lugar3[2] = prestamo1[2];
                        tercerlugar = true;
                        prestamo1[2] = "0";
                        continue;
                    }
                }
                if (n2 > n1 && n2 > n3 && n2 > n4 && n2 > n5 && n2 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo2[0];
                        lugar1[1] = prestamo2[1];
                        lugar1[2] = prestamo2[2];
                        primerlugar = true;
                        prestamo2[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo2[0];
                        lugar2[1] = prestamo2[1];
                        lugar2[2] = prestamo2[2];
                        segundolugar = true;
                        prestamo2[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo2[0];
                        lugar3[1] = prestamo2[1];
                        lugar3[2] = prestamo2[2];
                        tercerlugar = true;
                        prestamo2[2] = "0";
                        continue;
                    }
                }
                if (n3 > n1 && n3 > n2 && n3 > n4 && n3 > n5 && n3 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo3[0];
                        lugar1[1] = prestamo3[1];
                        lugar1[2] = prestamo3[2];
                        primerlugar = true;
                        prestamo3[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo3[0];
                        lugar2[1] = prestamo3[1];
                        lugar2[2] = prestamo3[2];
                        segundolugar = true;
                        prestamo3[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo3[0];
                        lugar3[1] = prestamo3[1];
                        lugar3[2] = prestamo3[2];
                        tercerlugar = true;
                        prestamo3[2] = "0";
                        continue;
                    }
                }
                if (n4 > n1 && n4 > n2 && n4 > n3 && n4 > n5 && n4 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo4[0];
                        lugar1[1] = prestamo4[1];
                        lugar1[2] = prestamo4[2];
                        primerlugar = true;
                        prestamo4[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo4[0];
                        lugar2[1] = prestamo4[1];
                        lugar2[2] = prestamo4[2];
                        segundolugar = true;
                        prestamo4[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo4[0];
                        lugar3[1] = prestamo4[1];
                        lugar3[2] = prestamo4[2];
                        tercerlugar = true;
                        prestamo4[2] = "0";
                        continue;
                    }
                }
                if (n5 > n1 && n5 > n2 && n5 > n3 && n5 > n4 && n5 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo5[0];
                        lugar1[1] = prestamo5[1];
                        lugar1[2] = prestamo5[2];
                        primerlugar = true;
                        prestamo5[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo5[0];
                        lugar2[1] = prestamo5[1];
                        lugar2[2] = prestamo5[2];
                        segundolugar = true;
                        prestamo5[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo5[0];
                        lugar3[1] = prestamo5[1];
                        lugar3[2] = prestamo5[2];
                        tercerlugar = true;
                        prestamo5[2] = "0";
                        continue;
                    }
                }
                if (n6 > n1 && n6 > n2 && n6 > n3 && n6 > n4 && n6 > n5)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo6[0];
                        lugar1[1] = prestamo6[1];
                        lugar1[2] = prestamo6[2];
                        primerlugar = true;
                        prestamo6[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo6[0];
                        lugar2[1] = prestamo6[1];
                        lugar2[2] = prestamo6[2];
                        segundolugar = true;
                        prestamo6[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo6[0];
                        lugar3[1] = prestamo6[1];
                        lugar3[2] = prestamo6[2];
                        tercerlugar = true;
                        prestamo6[2] = "0";
                        continue;
                    }
                }
                if (primerlugar == false)
                {
                    lugar1[0] = "No hay registros";
                    lugar1[1] = "";
                    lugar1[2] = "0";
                    primerlugar = true;
                    continue;

                }
                if (segundolugar == false)
                {
                    lugar2[0] = "No hay registros";
                    lugar2[1] = "";
                    lugar2[2] = "0";
                    segundolugar = true;
                    continue;
                }
                if (tercerlugar == false)
                {
                    lugar3[0] = "No hay registros";
                    lugar3[1] = "";
                    lugar3[2] = "0";
                    tercerlugar = true;
                    continue;
                }
            }

            lblposi1nom.Text = "Crédito: " + lugar1[0];
            lblposi1cant.Text = "Cant: " + lugar1[2];

            lblposi2nom.Text = "Crédito: " + lugar2[0];
            lblposi2cant.Text = "Cant: " + lugar2[2];

            lblposi3nom.Text = "Crédito: " + lugar3[0];
            lblposi3cant.Text = "Cant: " + lugar3[2];


        }

        public void cargarAu()
        {

            int cant = indicadores.ListAutenticados();
            lblAuten.Text = "Cantidad: " + Convert.ToString(cant);

        }

        public void cargarNOAu()
        {

            int cant = indicadores.ListNoAutenticados();
            lblincognitocant.Text = "Cantidad: " + Convert.ToString(cant);

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

            string fechaI = Request.Form["fechainicio"];

            string fechaF = Request.Form["fechafin"];

            fechaini = fechaI;
            fechafin = fechaF;
            IndicadorclickFiltro(fechaini, fechafin);
            IndicadorposiFiltro(fechaini, fechafin);

            cargarAuFiltros(fechaini, fechafin);
            cargarNOAuFiltros(fechaini, fechafin);

        }
        public void cargarAuFiltros(string fechaini, string fechafin)
        {

            int cant = indicadores.ListAutenticadosFiltros(fechaini, fechafin);
            lblAuten.Text = "Cantidad: " + Convert.ToString(cant);

        }

        public void cargarNOAuFiltros(string fechaini, string fechafin)
        {

            int cant = indicadores.ListNoAutenticadosFiltros(fechaini, fechafin);
            lblincognitocant.Text = "Cantidad: " + Convert.ToString(cant);

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            string fechaI = Request.Form["fechainicio"];

            string fechaF = Request.Form["fechafin"];

            if (fechaI.Equals("") && fechaF.Equals(""))
            {
                cargarindicadoresclick();
                cargarindicadoresposi();
                cargarAu();
                cargarNOAu();
                lblerror.Visible = true;
                lblerror.Text = "ERROR: Debe de indicar un rango de fechas.";
            }
            else
            {
                if (validarfechas(Convert.ToDateTime(fechaI), Convert.ToDateTime(fechaF)) == false)
                {
                    fechaini = fechaI;
                    fechafin = fechaF;
                    IndicadorclickFiltro(fechaini, fechafin);
                    IndicadorposiFiltro(fechaini, fechafin);

                    cargarAuFiltros(fechaini, fechafin);
                    cargarNOAuFiltros(fechaini, fechafin);
                }
                else
                {
                    cargarindicadoresclick();
                    cargarindicadoresposi();
                    cargarAu();
                    cargarNOAu();
                    lblerror.Visible = true;
                    lblerror.Text = "ERROR: Indicar un rango de fechas correcto.";
                }

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

        public void IndicadorposiFiltro(string fechaini, string fechafin)
        {
            //Vectores
            string[] prestamo1;
            prestamo1 = new string[3];
            string[] prestamo2;
            prestamo2 = new string[3];
            string[] prestamo3;
            prestamo3 = new string[3];
            string[] prestamo4;
            prestamo4 = new string[3];
            string[] prestamo5;
            prestamo5 = new string[3];
            string[] prestamo6;
            prestamo6 = new string[3];

            //Vectores finales
            string[] lugar1;
            lugar1 = new string[3];
            string[] lugar2;
            lugar2 = new string[3];
            string[] lugar3;
            lugar3 = new string[3];

            //Variable bool
            bool primerlugar = false;
            bool segundolugar = false;
            bool tercerlugar = false;


            List<Indicadores> auxindica = indicadores.ListarIndicadores();

            foreach (Indicadores indicadores in auxindica)
            {
                if (indicadores.Fecha >= Convert.ToDateTime(fechaini) && indicadores.Fecha <= Convert.ToDateTime(fechafin))
                {
                    if (indicadores.CodigotipoIndicador == 2)
                    {
                        string fecha = indicadores.Fecha.ToString();
                        string codpres = indicadores.CodigoPrestamo.ToString();
                        string codTipo = indicadores.CodigotipoIndicador.ToString();
                        string cant = indicadores.Cantidad.ToString();

                        if (codpres == "2")
                        {

                            prestamo1[0] = "Personal";
                            prestamo1[1] = fecha;
                            int aux = (Convert.ToInt32(prestamo1[2]) + Convert.ToInt32(cant));
                            prestamo1[2] = Convert.ToString(aux);
                        }
                        if (codpres == "5")
                        {
                            prestamo2[0] = "Salud";
                            prestamo2[1] = fecha;
                            int aux = (Convert.ToInt32(prestamo2[2]) + Convert.ToInt32(cant));
                            prestamo2[2] = Convert.ToString(aux);
                        }
                        if (codpres == "6")
                        {
                            prestamo3[0] = "Vehicular";
                            prestamo3[1] = fecha;
                            int aux = (Convert.ToInt32(prestamo3[2]) + Convert.ToInt32(cant));
                            prestamo3[2] = Convert.ToString(aux);
                        }
                        if (codpres == "8")
                        {
                            prestamo4[0] = "Vivienda";
                            prestamo4[1] = fecha;
                            int aux = (Convert.ToInt32(prestamo4[2]) + Convert.ToInt32(cant));
                            prestamo4[2] = Convert.ToString(aux);
                        }
                        if (codpres == "9")
                        {
                            prestamo5[0] = "Préstamo pymes";
                            prestamo5[1] = fecha;
                            int aux = (Convert.ToInt32(prestamo5[2]) + Convert.ToInt32(cant));
                            prestamo5[2] = Convert.ToString(aux);
                        }
                        if (codpres == "10")
                        {
                            prestamo6[0] = "Préstamo corporativo";
                            prestamo6[1] = fecha;
                            int aux = (Convert.ToInt32(prestamo6[2]) + Convert.ToInt32(cant));
                            prestamo6[2] = Convert.ToString(aux);
                        }
                    }
                }


            }

            string aux1 = prestamo1[2];
            while (primerlugar == false || segundolugar == false || tercerlugar == false)
            {
                int n1 = Convert.ToInt32(prestamo1[2]);
                int n2 = Convert.ToInt32(prestamo2[2]);
                int n3 = Convert.ToInt32(prestamo3[2]);
                int n4 = Convert.ToInt32(prestamo4[2]);
                int n5 = Convert.ToInt32(prestamo5[2]);
                int n6 = Convert.ToInt32(prestamo6[2]);


                if (n1 > n2 && n1 > n3 && n1 > n4 && n1 > n5 && n1 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo1[0];
                        lugar1[1] = prestamo1[1];
                        lugar1[2] = prestamo1[2];
                        primerlugar = true;
                        prestamo1[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo1[0];
                        lugar2[1] = prestamo1[1];
                        lugar2[2] = prestamo1[2];
                        segundolugar = true;
                        prestamo1[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo1[0];
                        lugar3[1] = prestamo1[1];
                        lugar3[2] = prestamo1[2];
                        tercerlugar = true;
                        prestamo1[2] = "0";
                        continue;
                    }
                }
                if (n2 > n1 && n2 > n3 && n2 > n4 && n2 > n5 && n2 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo2[0];
                        lugar1[1] = prestamo2[1];
                        lugar1[2] = prestamo2[2];
                        primerlugar = true;
                        prestamo2[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo2[0];
                        lugar2[1] = prestamo2[1];
                        lugar2[2] = prestamo2[2];
                        segundolugar = true;
                        prestamo2[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo2[0];
                        lugar3[1] = prestamo2[1];
                        lugar3[2] = prestamo2[2];
                        tercerlugar = true;
                        prestamo2[2] = "0";
                        continue;
                    }
                }
                if (n3 > n1 && n3 > n2 && n3 > n4 && n3 > n5 && n3 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo3[0];
                        lugar1[1] = prestamo3[1];
                        lugar1[2] = prestamo3[2];
                        primerlugar = true;
                        prestamo3[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo3[0];
                        lugar2[1] = prestamo3[1];
                        lugar2[2] = prestamo3[2];
                        segundolugar = true;
                        prestamo3[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo3[0];
                        lugar3[1] = prestamo3[1];
                        lugar3[2] = prestamo3[2];
                        tercerlugar = true;
                        prestamo3[2] = "0";
                        continue;
                    }
                }
                if (n4 > n1 && n4 > n2 && n4 > n3 && n4 > n5 && n4 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo4[0];
                        lugar1[1] = prestamo4[1];
                        lugar1[2] = prestamo4[2];
                        primerlugar = true;
                        prestamo4[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo4[0];
                        lugar2[1] = prestamo4[1];
                        lugar2[2] = prestamo4[2];
                        segundolugar = true;
                        prestamo4[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo4[0];
                        lugar3[1] = prestamo4[1];
                        lugar3[2] = prestamo4[2];
                        tercerlugar = true;
                        prestamo4[2] = "0";
                        continue;
                    }
                }
                if (n5 > n1 && n5 > n2 && n5 > n3 && n5 > n4 && n5 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo5[0];
                        lugar1[1] = prestamo5[1];
                        lugar1[2] = prestamo5[2];
                        primerlugar = true;
                        prestamo5[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo5[0];
                        lugar2[1] = prestamo5[1];
                        lugar2[2] = prestamo5[2];
                        segundolugar = true;
                        prestamo5[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo5[0];
                        lugar3[1] = prestamo5[1];
                        lugar3[2] = prestamo5[2];
                        tercerlugar = true;
                        prestamo5[2] = "0";
                        continue;
                    }
                }
                if (n6 > n1 && n6 > n2 && n6 > n3 && n6 > n4 && n6 > n5)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo6[0];
                        lugar1[1] = prestamo6[1];
                        lugar1[2] = prestamo6[2];
                        primerlugar = true;
                        prestamo6[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo6[0];
                        lugar2[1] = prestamo6[1];
                        lugar2[2] = prestamo6[2];
                        segundolugar = true;
                        prestamo6[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo6[0];
                        lugar3[1] = prestamo6[1];
                        lugar3[2] = prestamo6[2];
                        tercerlugar = true;
                        prestamo6[2] = "0";
                        continue;
                    }
                }

                if (primerlugar == false)
                {
                    lugar1[0] = "No hay registros";
                    lugar1[1] = "";
                    lugar1[2] = "0";
                    primerlugar = true;
                    continue;

                }
                if (segundolugar == false)
                {
                    lugar2[0] = "No hay registros";
                    lugar2[1] = "";
                    lugar2[2] = "0";
                    segundolugar = true;
                    continue;
                }
                if (tercerlugar == false)
                {
                    lugar3[0] = "No hay registros";
                    lugar3[1] = "";
                    lugar3[2] = "0";
                    tercerlugar = true;
                    continue;
                }
            }

            lblposi1nom.Text = lugar1[0];
            lblposi1cant.Text = "Cant: " + lugar1[2];

            lblposi2nom.Text = lugar2[0];
            lblposi2cant.Text = "Cant: " + lugar2[2];

            lblposi3nom.Text = lugar3[0];
            lblposi3cant.Text = "Cant: " + lugar3[2];


        }

        public void IndicadorclickFiltro(string fechaini, string fechafin)
        {
            //Vectores
            string[] prestamo1;
            prestamo1 = new string[3];
            string[] prestamo2;
            prestamo2 = new string[3];
            string[] prestamo3;
            prestamo3 = new string[3];
            string[] prestamo4;
            prestamo4 = new string[3];
            string[] prestamo5;
            prestamo5 = new string[3];
            string[] prestamo6;
            prestamo6 = new string[3];

            //Vectores finales
            string[] lugar1;
            lugar1 = new string[3];
            string[] lugar2;
            lugar2 = new string[3];
            string[] lugar3;
            lugar3 = new string[3];

            //Variable bool
            bool primerlugar = false;
            bool segundolugar = false;
            bool tercerlugar = false;


            List<Indicadores> auxindica = indicadores.ListarIndicadores();

            foreach (Indicadores indicadores in auxindica)
            {
                if (indicadores.Fecha >= Convert.ToDateTime(fechaini) && indicadores.Fecha <= Convert.ToDateTime(fechafin))
                {
                    if (indicadores.CodigotipoIndicador == 1)
                    {
                        string fecha = indicadores.Fecha.ToString();
                        string codpres = indicadores.CodigoPrestamo.ToString();
                        string codTipo = indicadores.CodigotipoIndicador.ToString();
                        string cant = indicadores.Cantidad.ToString();

                        if (codpres == "2")
                        {

                            prestamo1[0] = "Personal";
                            prestamo1[1] = fecha;
                            int aux = (Convert.ToInt32(prestamo1[2]) + Convert.ToInt32(cant));
                            prestamo1[2] = Convert.ToString(aux);
                        }
                        if (codpres == "5")
                        {
                            prestamo2[0] = "Salud";
                            prestamo2[1] = fecha;
                            int aux = (Convert.ToInt32(prestamo2[2]) + Convert.ToInt32(cant));
                            prestamo2[2] = Convert.ToString(aux);
                        }
                        if (codpres == "6")
                        {
                            prestamo3[0] = "Vehicular";
                            prestamo3[1] = fecha;
                            int aux = (Convert.ToInt32(prestamo3[2]) + Convert.ToInt32(cant));
                            prestamo3[2] = Convert.ToString(aux);
                        }
                        if (codpres == "8")
                        {
                            prestamo4[0] = "Vivienda";
                            prestamo4[1] = fecha;
                            int aux = (Convert.ToInt32(prestamo4[2]) + Convert.ToInt32(cant));
                            prestamo4[2] = Convert.ToString(aux);
                        }
                        if (codpres == "9")
                        {
                            prestamo5[0] = "Préstamo pymes";
                            prestamo5[1] = fecha;
                            int aux = (Convert.ToInt32(prestamo5[2]) + Convert.ToInt32(cant));
                            prestamo5[2] = Convert.ToString(aux);
                        }
                        if (codpres == "10")
                        {
                            prestamo6[0] = "Préstamo corporativo";
                            prestamo6[1] = fecha;
                            int aux = (Convert.ToInt32(prestamo6[2]) + Convert.ToInt32(cant));
                            prestamo6[2] = Convert.ToString(aux);
                        }
                    }
                }

            }

            string aux1 = prestamo1[2];
            while (primerlugar == false || segundolugar == false || tercerlugar == false)
            {
                int n1 = Convert.ToInt32(prestamo1[2]);
                int n2 = Convert.ToInt32(prestamo2[2]);
                int n3 = Convert.ToInt32(prestamo3[2]);
                int n4 = Convert.ToInt32(prestamo4[2]);
                int n5 = Convert.ToInt32(prestamo5[2]);
                int n6 = Convert.ToInt32(prestamo6[2]);


                if (n1 > n2 && n1 > n3 && n1 > n4 && n1 > n5 && n1 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo1[0];
                        lugar1[1] = prestamo1[1];
                        lugar1[2] = prestamo1[2];
                        primerlugar = true;
                        prestamo1[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo1[0];
                        lugar2[1] = prestamo1[1];
                        lugar2[2] = prestamo1[2];
                        segundolugar = true;
                        prestamo1[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo1[0];
                        lugar3[1] = prestamo1[1];
                        lugar3[2] = prestamo1[2];
                        tercerlugar = true;
                        prestamo1[2] = "0";
                        continue;
                    }
                }
                if (n2 > n1 && n2 > n3 && n2 > n4 && n2 > n5 && n2 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo2[0];
                        lugar1[1] = prestamo2[1];
                        lugar1[2] = prestamo2[2];
                        primerlugar = true;
                        prestamo2[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo2[0];
                        lugar2[1] = prestamo2[1];
                        lugar2[2] = prestamo2[2];
                        segundolugar = true;
                        prestamo2[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo2[0];
                        lugar3[1] = prestamo2[1];
                        lugar3[2] = prestamo2[2];
                        tercerlugar = true;
                        prestamo2[2] = "0";
                        continue;
                    }
                }
                if (n3 > n1 && n3 > n2 && n3 > n4 && n3 > n5 && n3 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo3[0];
                        lugar1[1] = prestamo3[1];
                        lugar1[2] = prestamo3[2];
                        primerlugar = true;
                        prestamo3[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo3[0];
                        lugar2[1] = prestamo3[1];
                        lugar2[2] = prestamo3[2];
                        segundolugar = true;
                        prestamo3[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo3[0];
                        lugar3[1] = prestamo3[1];
                        lugar3[2] = prestamo3[2];
                        tercerlugar = true;
                        prestamo3[2] = "0";
                        continue;
                    }
                }
                if (n4 > n1 && n4 > n2 && n4 > n3 && n4 > n5 && n4 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo4[0];
                        lugar1[1] = prestamo4[1];
                        lugar1[2] = prestamo4[2];
                        primerlugar = true;
                        prestamo4[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo4[0];
                        lugar2[1] = prestamo4[1];
                        lugar2[2] = prestamo4[2];
                        segundolugar = true;
                        prestamo4[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo4[0];
                        lugar3[1] = prestamo4[1];
                        lugar3[2] = prestamo4[2];
                        tercerlugar = true;
                        prestamo4[2] = "0";
                        continue;
                    }
                }
                if (n5 > n1 && n5 > n2 && n5 > n3 && n5 > n4 && n5 > n6)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo5[0];
                        lugar1[1] = prestamo5[1];
                        lugar1[2] = prestamo5[2];
                        primerlugar = true;
                        prestamo5[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo5[0];
                        lugar2[1] = prestamo5[1];
                        lugar2[2] = prestamo5[2];
                        segundolugar = true;
                        prestamo5[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo5[0];
                        lugar3[1] = prestamo5[1];
                        lugar3[2] = prestamo5[2];
                        tercerlugar = true;
                        prestamo5[2] = "0";
                        continue;
                    }
                }
                if (n6 > n1 && n6 > n2 && n6 > n3 && n6 > n4 && n6 > n5)
                {
                    if (primerlugar == false)
                    {
                        lugar1[0] = prestamo6[0];
                        lugar1[1] = prestamo6[1];
                        lugar1[2] = prestamo6[2];
                        primerlugar = true;
                        prestamo6[2] = "0";
                        continue;

                    }
                    if (segundolugar == false)
                    {
                        lugar2[0] = prestamo6[0];
                        lugar2[1] = prestamo6[1];
                        lugar2[2] = prestamo6[2];
                        segundolugar = true;
                        prestamo6[2] = "0";
                        continue;
                    }
                    if (tercerlugar == false)
                    {
                        lugar3[0] = prestamo6[0];
                        lugar3[1] = prestamo6[1];
                        lugar3[2] = prestamo6[2];
                        tercerlugar = true;
                        prestamo6[2] = "0";
                        continue;
                    }
                }
                if (primerlugar == false)
                {
                    lugar1[0] = "No hay registros";
                    lugar1[1] = "";
                    lugar1[2] = "0";
                    primerlugar = true;
                    continue;

                }
                if (segundolugar == false)
                {
                    lugar2[0] = "No hay registros";
                    lugar2[1] = "";
                    lugar2[2] = "0";
                    segundolugar = true;
                    continue;
                }
                if (tercerlugar == false)
                {
                    lugar3[0] = "No hay registros";
                    lugar3[1] = "";
                    lugar3[2] = "0";
                    tercerlugar = true;
                    continue;
                }
            }

            lblclick1nom.Text = "Crédito: " + lugar1[0];
            lblclick1cant.Text = "Clik´s: " + lugar1[2];

            lblclick2nom.Text = "Crédito: " + lugar2[0];
            lblclick2cant.Text = "Clik´s: " + lugar2[2];

            lblclick3nom.Text = "Crédito: " + lugar3[0];
            lblclick3cant.Text = "Clik´s: " + lugar3[2];
        }
    }
}