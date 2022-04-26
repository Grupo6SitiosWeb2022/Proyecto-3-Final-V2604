using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
using Newtonsoft.Json.Linq;

namespace ProyectoSitios.Pages
{
    public partial class FormularioC : System.Web.UI.Page
    {
        NFormularios nsolicitudes = new NFormularios();
        NCalculadora calc = new NCalculadora();
        string numformulario;
        int ranNum;




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LUser.login != "1")
                {
                    LUser.aux = "1";
                    LUser.mensaje = "Deberá iniciar sesión para tener acceso a los formularios.";
                    Response.Redirect("login.aspx");
                }
            }
            try {
                lblerror.Visible = false;
                Random myObject = new Random();
                 ranNum = myObject.Next(5, 60);
               

            } catch(Exception ex)
            {

            }
        }

        //Método para validar Captcha
        public bool IsReCaptchValid()
        {
            numformulario = Session["Nump"].ToString();
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = ConfigurationManager.AppSettings["SecretKey"];
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }




        protected void btnFormulario_Click(object sender, EventArgs e)
        {
            if (IsReCaptchValid() && CHD.Checked)
            {
                  try
            {
              
                PrestamoSolcitudCreditoClass scp = new PrestamoSolcitudCreditoClass()
                {
                    NumSolicitud = 1,
                    TipoIdentificacion = Convert.ToInt32(ddlTiposIdentificacion.SelectedValue),
                    Identificacion = txtIdetificacion.Text,
                    NombreCompleto = txtNombreC.Text,
                    CorreoElectronico = txtcorreo.Text,
                    Telefono = txtTelefono.Text,
                    Moneda = Convert.ToInt32(ddlTipoMoneda.SelectedValue),
                    Direccion = txtDireccion.Text,
                    MontoSolicitado = Convert.ToInt32(txtMonto.Text),
                    Plazo = Convert.ToInt32(txtPlazo.Text),
                    SalarioLiquido = Convert.ToInt32(txtSalario.Text),
                    CodigoPrestamo=Convert.ToInt32(numformulario),
                    //TO DO Cargar desde la API TASA
                    Tasainteresactual = cargarprestamos(Convert.ToInt32(numformulario)),
                    //TO DO Cargar desde la API TASA
                    PorcentajeEndeudamiento = ranNum,
                    EstadoSolicitud = "Pendiente",
                    FechaSolicitud = DateTime.Now

                };
                    lblerror.BackColor = System.Drawing.ColorTranslator.FromHtml("#9FF781");

                    lblerror.Text = nsolicitudes.CrearFormulario(scp);
                    lblerror.Visible = true;

                }
                catch (Exception ex)
                {
                    lblerror.BackColor = System.Drawing.ColorTranslator.FromHtml("#F46363");
                    lblerror.Text = "Datos incorrectos";
                    lblerror.Visible = true;
                }
            }
            else
            {
                lblerror.BackColor = System.Drawing.ColorTranslator.FromHtml("#F46363");
                lblerror.Text = "Debe seleccionar todos los campos";
                lblerror.Visible = true;
            }


        }
        public long cargarprestamos(int codprestamo)
        {
            List<Prestamos> prest = calc.ListarPrestamos();
            ListItem i;
            foreach (Prestamos prestamo in prest)
            {
                if (codprestamo == prestamo.CodigoPrestamo) {
                    return prestamo.TasaInteres;
                } 
            }
            return 0;
        }
    }
}