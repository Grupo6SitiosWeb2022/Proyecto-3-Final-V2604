using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaDatos;
using CapaNegocio;
namespace ProyectoSitios.Pages
{
    public partial class Index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioLogin.Contrasena1 = "";
            UsuarioLogin.Usuario1 = "";
            try {
                string Date = DateTime.Now.ToString("dd/MM/yyyy");
                cr.fi.bccr.gee.wsindicadoreseconomicos cliente = new cr.fi.bccr.gee.wsindicadoreseconomicos();

                DataSet tipocambio1 = cliente.ObtenerIndicadoresEconomicos("317", Date, Date, "Valeria Quiros", "N", "valee60280@gmail.com", "PRRG2AA22I");
                DataSet tipocambio = cliente.ObtenerIndicadoresEconomicos("318", Date, Date, "Valeria Quiros", "N", "valee60280@gmail.com", "PRRG2AA22I");
                double CmbioI = Convert.ToDouble(tipocambio1.Tables[0].Rows[0].ItemArray[2].ToString());
                double CmbioII =Convert.ToDouble(tipocambio.Tables[0].Rows[0].ItemArray[2].ToString());



                lblerror.Text = "                                          Venta:       " +  "                                                                                              "+CmbioI.ToString("N2")
                    + "                                                                                     Compra:        " + CmbioII.ToString("N2"); 










            } catch (Exception ex) {
                lblerror.Text=("Sucede algo");
            }
         
        }
    }
}