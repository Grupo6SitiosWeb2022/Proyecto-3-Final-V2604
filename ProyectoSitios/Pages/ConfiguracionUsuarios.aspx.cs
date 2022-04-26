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
    public partial class ConfiguracionUsuarios : System.Web.UI.Page
    {
        NRoles rol = new NRoles();
        Nusuarios usuario = new Nusuarios();
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
            if (!IsPostBack)
            {
                cargarroles();
                cargarusuarios();
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

        public void cargarusuarios()
        {
            List<Usuarios> usuarioslist = usuario.ListarUsuarios();
            //if (info.Equals(" "))
            //{
            foreach (Usuarios u in usuarioslist)
            {
                string cod = u.Identificacion.ToString();
                string nom = u.NombreCompleto.ToString();
                string codrol = u.TipoRol.ToString();
                string nobrerol = "";
                List<Roles> roles = rol.ListarRoles();
                ListItem i;
                foreach (Roles r in roles)
                {
                    if (codrol.Equals(r.IdTipoRol.ToString()))
                    {
                        nobrerol = r.NombreRol.ToString();
                    }

                }
                TableRow row = new TableRow();
                TableCell[] cell = new TableCell[] { new TableCell { Text = cod }, new TableCell { Text = nom }, new TableCell { Text = nobrerol } };
                //cell.Text = word.ToString();
                row.Cells.AddRange(cell);
                TablaUsuarios.Rows.Add(row);
            }
            //}
            //else
            //{
            //foreach (Roles rol in roleslist)
            //{
            //    if (rol.NombreRol.Contains(info))
            //    {
            //        string cod = rol.IdTipoRol.ToString();
            //        string nom = rol.NombreRol;
            //        TableRow row = new TableRow();
            //        TableCell[] cell = new TableCell[] { new TableCell { Text = cod }, new TableCell { Text = nom } };
            //        //cell.Text = word.ToString();
            //        row.Cells.AddRange(cell);
            //        TablaRolesn.Rows.Add(row);
            //    }
            //}

            //}
        }

        protected void btnAgregar_Click1(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFiltro.Text))
            {
                lblerror.Text = "Datos incorrectos";

                lblerror.Visible = true;
                lblerror.BackColor = System.Drawing.ColorTranslator.FromHtml("#F46363");
            }
            else
            {
                //asignar rol
                List<Usuarios> usuarioslist = usuario.ListarUsuarios();
                //if (info.Equals(" "))
                //{
                Usuarios u = new Usuarios();
                string id = txtFiltro.Text;
                int idrol = Convert.ToInt32(ddltipo.SelectedValue);
                foreach (Usuarios ul in usuarioslist)
                {
                    if (ul.Identificacion.Equals(id))
                    {
                        u = ul;
                        u.TipoRol = idrol;
                        u.Pass = DesEncrytarPassword(ul.Pass);
                    }

                }

                usuario.ModificarRolUsuario(u);
                cargarusuarios();

                lblerror.Visible = true;
                lblerror.BackColor = System.Drawing.ColorTranslator.FromHtml("#9FF781");
                lblerror.Text = "Usuario actualizado con exito";

            }
        }
        private string DesEncrytarPassword(string password)
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

        protected void ddltipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}