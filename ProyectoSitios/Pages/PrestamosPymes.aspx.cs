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
    public partial class PrestamosPymes : System.Web.UI.Page
    {

        NCorreo correos = new NCorreo();
        string correo, nombre;
        Nusuarios user = new Nusuarios();
        protected void btncalcu_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/CalcularPrestamos.aspx");
        }

        protected void btnformu_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/FormularioP.aspx");
        }

        protected void btncorreo_Click(object sender, EventArgs e)
        {
            string nombreprestamo = "PRÉSTAMO PYMES";
            string titulollamativo = "¿Tiene algún imprevisto?";
            string texto = "Haga realidad los planes de expansión de su empresa, mejore la productividad y competitividad con el respaldo de Banco NAV.";
            if (LUser.login != "1")
            {
                LUser.aux = "1";
                LUser.mensaje = "Deberá iniciar sesión para tener acceso a la información por correo.";
                Response.Redirect("login.aspx");
            }
            else
            {
                cargarinfoUsuarios();
                correos.SendMailPrestamo(correo, nombre, nombreprestamo, titulollamativo, texto);
            }
        }
        public void cargarinfoUsuarios()
        {
            List<Usuarios> users = user.ListarUsuarios();

            foreach (Usuarios user1 in users)
            {

                if (user1.Identificacion == LUser.IdentificacionCliente)
                {
                    correo = user1.CorreoElectronico.ToString();
                    nombre = user1.NombreCompleto;
                }
            }
        }
    }
}