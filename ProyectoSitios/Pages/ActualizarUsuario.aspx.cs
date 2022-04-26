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
    public partial class ActualizarUsuario : System.Web.UI.Page
    {
        NRoles rol = new NRoles();
        Nusuarios user = new Nusuarios();
        NRoles nroles = new NRoles();
        Nusuarios nusuarios = new Nusuarios();
        static int tipoRol = 0;
        NCorreo correos = new NCorreo();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            if (!IsPostBack)
            {
                cargarinfo();
                txtUser.Enabled = false;
                cargarusuario(UsuarioLogin.Usuario1);
            }
            cargarroles();
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
        public void cargarinfo()
        {
            List<Usuarios> users = user.ListarUsuarios();



            foreach (Usuarios user1 in users)
            {

                if (user1.Identificacion == LUser.identificacion)
                {
                    txtUser.Text = user1.Identificacion.ToString();
                    txtNom.Text = user1.NombreCompleto;
                    txtNacionalidad.Text = user1.Nacionalidad.ToString();
                    txtTel.Text = user1.Telefono.ToString();
                    txtCorreo.Text = user1.CorreoElectronico.ToString();
                    txtDirec.Text = user1.Direccion.ToString();

                }
            }
        }
        public void EnvioCorreo()
        {
            //string identificacion, string nom,  string nacionalidad, string tel, string correo, string direc, string Rol)
            string nomrol = "";
            List<Roles> roles = rol.ListarRoles();
            ListItem i;
            int idrol = Convert.ToInt32(ddltipo.SelectedValue);
            foreach (Roles r in roles)
            {
                if (r.IdTipoRol == idrol)
                {
                    nomrol = r.NombreRol;
                }

            }
            correos.SendMailCambioInfo(txtUser.Text, txtNom.Text, txtNacionalidad.Text, txtTel.Text, txtCorreo.Text, txtDirec.Text, nomrol);
        }
        public void cargarroles()
        {
            List<Roles> roles = rol.ListarRoles();
            ListItem i;
            foreach (Roles r in roles)
            {

                i = new ListItem(r.NombreRol, r.IdTipoRol.ToString());
                ddltipo.Items.Add(i);
            }
        }
        protected void btnactualizar_Click(object sender, EventArgs e)
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
                                int idrol = Convert.ToInt32(ddltipo.SelectedValue);
                                resp = user.ModificarUsuario1(txtUser.Text, txtNom.Text, txtNacionalidad.Text, txtTel.Text, txtCorreo.Text, txtDirec.Text, txtpass1.Text, idrol);
                                if (resp.Equals("1"))
                                {
                                    EnvioCorreo();
                                    lblerror.Visible = true;
                                    Response.Redirect("../Pages/GestionUsuarios.aspx");

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

        protected void ddltipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}