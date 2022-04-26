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
    public partial class PantallaCPT : System.Web.UI.Page
    {
        NRoles nroles = new NRoles();
        Nusuarios nusuarios = new Nusuarios();
        static string identificacion = "", pass = "";
        static int tipoRol = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            if (!IsPostBack)
            {
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
                        txtCNombre.Text = usuario.NombreCompleto.ToString();
                        txtCNacionalidad.Text = usuario.Nacionalidad.ToString();
                        txtCTelefono.Text = usuario.Telefono.ToString();
                        txtCorreo.Text = usuario.CorreoElectronico.ToString();
                        TxtCDireccion.Text = usuario.Direccion.ToString();
                        pass = Desencriptar(usuario.Pass);
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string Nombre = txtCNombre.Text;
                string Nacionalidad = txtCNacionalidad.Text;
                string Telefono = txtCTelefono.Text;
                string Correo = txtCorreo.Text;
                string Direccion = TxtCDireccion.Text;
                string resultado;

                resultado = nusuarios.ModificarUsuario(UsuarioLogin.Usuario1, pass, tipoRol, Nombre, Nacionalidad, Telefono, Correo, Direccion);
                if (resultado.Equals("OK"))
                {
                    lblerror.Visible = true;
                    lblerror.Text = ("Se ha modificado correctamente");
                    lblerror.BackColor = System.Drawing.ColorTranslator.FromHtml("#9FF781");

                }
                else
                {
                    lblerror.BackColor = System.Drawing.ColorTranslator.FromHtml("#F46363");
                    lblerror.Visible = true;
                    lblerror.Text = ("No se ha modificado correctamente");
                }

            }
            catch (Exception ex)
            {
                lblerror.Visible = true;
                lblerror.BackColor = System.Drawing.ColorTranslator.FromHtml("#F46363");
                lblerror.Text = ("No se ha modificado correctamente");
            }

        }


        public string Desencriptar(string password)
        {
            try
            {
                string result = string.Empty;
                byte[] dencryted = Convert.FromBase64String(password);
                result = System.Text.Encoding.Unicode.GetString(dencryted);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}