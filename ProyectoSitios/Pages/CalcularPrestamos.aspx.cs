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
    public partial class CalcularPrestamos : System.Web.UI.Page
    {
        Prestamos prestamos = new Prestamos();
        NCalculadora calc = new NCalculadora();
        NIndicadores ni = new NIndicadores();
        NRoles nroles = new NRoles();
        Nusuarios nusuarios = new Nusuarios();
        static int tipoRol = 0;

        double tasa = 0, montoMensual = 0;
        int montoTotal = 0, plazo = 0, meses = 0;
        string rango = "";
        double intereses = 0;
        double montoI = 0;
        double parte3 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarprestamos();
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

        protected void ddlTipoPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            calc.CargarDatos(ddlTipoPrestamo.SelectedValue);
            lblTasa.Text = calc.tasa.ToString() + "%";
            tasa = calc.tasa/100 ;
            montoTotal = int.Parse(txtMonto.Text);
            rango = Request.Form["input"];
            plazo = int.Parse(rango);
            intereses =  montoTotal * tasa;
            montoI = montoTotal + intereses;
             montoMensual = montoI / plazo;
            //  montoMensual = parte3/12;
            lblCuotaMensual.Text = rango;

            if (ddlMoneda.SelectedValue.Equals("Dolares"))
            {

                lblCuotaMensual.Text = "$" + montoMensual.ToString("N2");
             
            }
            else
            {
                lblCuotaMensual.Text = "₡" + montoMensual.ToString("N2");
            }

            if (string.IsNullOrEmpty(UsuarioLogin.Usuario1))
            {
                ni.AgregarIndicador(Convert.ToInt32(ddlTipoPrestamo.SelectedValue), 4);
            }
            else{
                ni.AgregarIndicador(Convert.ToInt32(ddlTipoPrestamo.SelectedValue), 3);
            }
        }

        public void cargarprestamos()
        {
            List<Prestamos> prest = calc.ListarPrestamos();
            ListItem i;
            foreach (Prestamos prestamo in prest)
            {

                i = new ListItem(prestamo.NombrePrestamo, prestamo.CodigoPrestamo.ToString());
                ddlTipoPrestamo.Items.Add(i);
            }
        }

       
    }
}