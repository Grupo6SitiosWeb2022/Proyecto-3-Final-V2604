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
        NIndicadores ni = new NIndicadores();
        int formularioPPP;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerMas_Click(object sender, EventArgs e)
        {
            ni.AgregarIndicador(9, 1);
            Response.Redirect("../Pages/PrestamosPymes.aspx");

        }

        protected void btnSolicitar_Click(object sender, EventArgs e)
        {
            formularioPPP = 9;
            System.Web.HttpContext.Current.Session["NumpP"] = formularioPPP;
            Response.Redirect("../Pages/FormularioP.aspx");

        }
    }
}