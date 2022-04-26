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
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        NRoles nroles = new NRoles();
        Nusuarios nusuarios = new Nusuarios();
        static string identificacion = "", pass = "";
        static int tipoRol = 0;
        Nusuarios usuario = new Nusuarios();
        NRoles rol = new NRoles();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarusuario(UsuarioLogin.Usuario1);
            }
            if (!IsPostBack)
            {
                cargarusuarios();
            }
            lblerror.Visible = false;
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
    
    protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/AgregarUsuario.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            if (txtcodi.Text.Length <= 0)
            {
                lblerror.Visible = true;
                lblerror.Text = "ERROR: Debe indicar la identificación del usuario a eliminar";
            }
            else
            {
                usuario.Borrarusuario(txtcodi.Text);
                cargarusuarios();
                lblerror.Text = "";
            }
        }

        public void cargarusuarios()
        {
            List<Usuarios> usuarioslist = usuario.ListarUsuarios();

            foreach (Usuarios u in usuarioslist)
            {
                string identificacion = u.Identificacion.ToString();
                string nombre = u.NombreCompleto.ToString();
                string nacionalidad = u.Nacionalidad.ToString();
                string telefono = u.Telefono.ToString();
                string correo = u.CorreoElectronico.ToString();
                string dirreccion = u.Direccion.ToString();
                string pass = u.Pass.ToString();
                string codrol = u.TipoRol.ToString();
                string nombrerol = "";
                List<Roles> roles = rol.ListarRoles();
                ListItem i;
                foreach (Roles r in roles)
                {
                    if (codrol.Equals(r.IdTipoRol.ToString()))
                    {
                        nombrerol = r.NombreRol.ToString();
                    }

                }
                TableRow row = new TableRow();
                TableCell[] cell = new TableCell[] { new TableCell { Text = identificacion }, new TableCell { Text = nombre }, new TableCell { Text = nacionalidad }
                , new TableCell { Text = telefono }, new TableCell { Text = correo }, new TableCell { Text = dirreccion }, new TableCell { Text = pass }
                , new TableCell { Text = nombrerol }};
                //cell.Text = word.ToString();
                row.Cells.AddRange(cell);
                tablausu.Rows.Add(row);
            }
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            if (txtcodi.Text.Length <= 0)
            {
                lblerror.Visible = true;
                lblerror.Text = "ERROR: Debe indicar la identificación del usuario a modificar";
            }
            else
            {
                LUser.identificacion = txtcodi.Text;
                Response.Redirect("../Pages/ActualizarUsuario.aspx");
            }
        }
    }
}