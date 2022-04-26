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
    public partial class login : System.Web.UI.Page


    {
        Nusuarios user = new Nusuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            lblregistro.Visible = false;

            if (!IsPostBack)
            {
                if (LUser.aux == "1")
                {
                    LUser.aux = "0";
                    LUser.mensaje = "Deberá iniciar sesión para tener acceso a los formularios y/o a pedir la información por correo.";
                    lblerror.Visible = true;
                    lblerror.Text = LUser.mensaje;


                }
                if (LUser.RegistroCompletado == "1")
                {
                    lblregistro.Visible = true;
                    lblregistro.Text = "El registro ha sido completado exitosamente, y se le envió la información a su correo electrónico. Por favor iniciar sesión con sus credenciales.";
                    LUser.aux = "";
                }
            }

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
                LUser.aux = "0";
                string resp = user.ValidarNulosIndex(txtUser.Text, txtPass.Text);
                if (resp.Equals("1"))
                {
                    resp = user.ValidarNumero(txtUser.Text);
                    if (resp.Equals("1"))
                    {

                        resp = user.InicioSesion(txtUser.Text, txtPass.Text);
                        if (resp.Equals("El usuario no existe"))
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "Error: " + resp;
                            txtUser.Text = "";
                            txtPass.Text = "";

                        }
                        else if (resp.Equals("Usuario y/o contraseña incorrectos."))
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "Error: " + resp;
                            txtUser.Text = "";
                            txtPass.Text = "";

                        }
                        else
                        {
                            UsuarioLogin.Usuario1 = txtUser.Text;
                            UsuarioLogin.Contrasena1 = txtPass.Text;
                            LUser.login = "1";
                            if (resp.Equals("2"))
                            {
                                LUser.IdentificacionCliente = txtUser.Text;
                                Response.Redirect("../Pages/Index.aspx");
                            }
                            else if (resp.Equals("1"))
                            {
                                Response.Redirect("../Pages/PanelAdministrativoTramitador.aspx");
                            }
                            else if (resp.Equals("3"))
                            {
                                LUser.Analista = txtUser.Text;
                                Response.Redirect("../Pages/PanelAdministrativoAnalista.aspx");
                            }
                            else if (resp.Equals("4"))
                            {
                                LUser.Analista = txtUser.Text;
                                Response.Redirect("../Pages/PanelAdministrativoEditor.aspx");
                            }
                            else
                            {
                                lblerror.Visible = true;
                                lblerror.Text = "Error: " + resp;
                                txtUser.Text = "";
                                txtPass.Text = "";
                            }
                        }
                    }
                    else
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Error: " + resp;
                        txtUser.Text = "";
                        txtPass.Text = "";
                    }
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Error: " + resp;
                    txtUser.Text = "";
                    txtPass.Text = "";
                }
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "Error: Debe de indicar que no es un Robot.";
            }

        }
    }
}