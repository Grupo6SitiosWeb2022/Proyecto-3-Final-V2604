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
    public partial class PrestamosCoorporativos : System.Web.UI.Page
    {
        NIndicadores ni = new NIndicadores();
        int formularioPE;


        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnVerMas_Click(object sender, EventArgs e)
        {
            ni.AgregarIndicador(10, 1);
           
            Response.Redirect("../Pages/PrestamosCorporativo.aspx");
       

        }

        protected void btnSolicitar_Click(object sender, EventArgs e)
        {
            formularioPE = 10;
            System.Web.HttpContext.Current.Session["NumpE"] = formularioPE;
            Response.Redirect("../Pages/FormularioE.aspx");

        }
    }
}