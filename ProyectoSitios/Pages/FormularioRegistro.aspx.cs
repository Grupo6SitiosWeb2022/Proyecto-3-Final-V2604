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
    public partial class FormularioRegistro : System.Web.UI.Page
    {
        Nusuarios user = new Nusuarios();
        NCorreo correos = new NCorreo();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
        }
        public bool IsReCaptchValid()
        {
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
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsReCaptchValid())
            {
                try
                {
                    if (!txtpass1.Text.Equals(txtpass2.Text))
                    {
                        string resp1 = "Los campos de la contraseña no coinciden.";
                        lblerror.Visible = true;
                        lblerror.Text = "Error:  " + resp1;
                    }
                    else
                    {

                        string resp = user.ValidarNulosRegistro(txtUser.Text, txtNom.Text, txtNacionalidad.Text, txtTel.Text, txtCorreo.Text, txtDirec.Text, txtpass1.Text);
                        if (resp.Equals("1"))
                        {
                            resp = user.validarTexto(txtNom.Text, txtNacionalidad.Text);
                            if (resp.Equals("1"))
                            {
                                resp = user.ValidarNumero(txtUser.Text);
                                if (resp.Equals("1"))
                                {
                                    int tiporol = 2;
                                    resp = user.crearUsuario2(txtUser.Text, txtNom.Text, txtNacionalidad.Text, txtTel.Text, txtCorreo.Text, txtDirec.Text, txtpass1.Text, tiporol);
                                    if (resp.Equals("1"))
                                    {
                                        EnvioCorreo();
                                        LUser.RegistroCompletado = "1";
                                        lblerror.Visible = true;
                                        Response.Redirect("../Pages/login.aspx");

                                    }
                                    else
                                    {
                                        lblerror.Visible = true;
                                        lblerror.Text = "Error: " + resp;
                                    }
                                }
                                else
                                {
                                    lblerror.Visible = true;
                                    lblerror.Text = "Error: " + resp;
                                }
                            }
                            else
                            {
                                lblerror.Visible = true;
                                lblerror.Text = "Error: " + resp;
                            }
                        }

                        else
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "Error:  " + resp;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Error:  " + ex.Message;
                }
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "Error: Debe de indicar que no es un Robot.";
            }

        }
        public void EnvioCorreo()
        {


            string fecha = DateTime.Now.ToString();


            string body1 = @"<style>
                            h1{color:#ee8133;font-size: 25px; font-weight: bold; text-align: center;}
                            h6{color:black; font-size: medium;}
                            img {text-align: center; width: 450px; height: auto;}
                            </style>
                           " +

                        $"<center><img src='https://drive.google.com/uc?export=download&id=1Xkt39Q8Xh8R53hEmTxPVh535AcRKF-_I'> </img></center>" +
                        $"<h1> Registro completado</ h1 > " +

                        $"<h6> Estimad@ {txtNom.Text}, realizo un registro en el sitio Web de Banco Nav, el día {fecha}. </ h6 >" +

                        $"<h6> El motivo de este correo es agradecerle por su preferencia hacia nosotros, ya puede utilizar nuestro sitio web, además de poder llenar solicitudes de préstamos y/o pedir información de estos por correo electrónico, el cual nos brindó en el formulario de registro. </ h6 >" +

                        $"<h6> Si desea más información puede presentarse a cualquiera de nuestras oficinas, también recordarle que puede comunicarse al número de teléfono 2211-1135. </h6>" +

                        $"<h6> Estimado cliente, esta notificación es generada de forma automática de acuerdo con lo establecido por el Banco NAV, en su reglamento interno, por lo que agradecemos no responder este correo. </h6>" +

                        $"<h6> Saludos. </h6>";

            correos.sendMail(txtCorreo.Text, "Registro completado.", body1);
        }
    }
}