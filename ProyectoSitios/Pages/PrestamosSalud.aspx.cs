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
    public partial class PrestamosSalud : System.Web.UI.Page
    {
        NCorreo correos = new NCorreo();
        string correo, nombre;
        Nusuarios user = new Nusuarios();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncalcu_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/CalcularPrestamos.aspx");
        }

        protected void btnformu_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/FormularioC.aspx");
        }

        protected void btncorreo_Click(object sender, EventArgs e)
        {
            string nombreprestamo = "PRÉSTAMO SALUD";
            string titulollamativo = "¿Tiene algún imprevisto?";
            string texto = "Es hora de pasar de los dichos a los hechos y ponerle fecha y hora a ese momento, para lograr sanar lo que te molesta hace tiempo o solucionar ese imprevisto que te haya generado un gasto por hospitalización";
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