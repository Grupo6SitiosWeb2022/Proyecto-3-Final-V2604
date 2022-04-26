using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace ProyectoSitios.Pages
{
    public partial class GestionPrestamos : System.Web.UI.Page
    {
        Nprestamos pres = new Nprestamos();
        string auxprestamo = "";
        NRoles nroles = new NRoles();
        Nusuarios nusuarios = new Nusuarios();
        static string identificacion = "", pass = "";
        static int tipoRol = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarusuario(UsuarioLogin.Usuario1);
            }
            if (!IsPostBack)
            {
                cargarprestamos();
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
    
    public void cargarprestamos()
        {
            List<Prestamos> prestamos = pres.Listarprestamos();

            if (auxprestamo.Equals(" "))
            {

                foreach (Prestamos prestamos1 in prestamos)
                {



                    string codigo = prestamos1.CodigoPrestamo.ToString();
                    string nombre = prestamos1.NombrePrestamo;
                    string descripcion = prestamos1.Descripcion.ToString();
                    string tasa = prestamos1.TasaInteres.ToString();
                    string plazo = prestamos1.CodigoPlazo.ToString();
                    string montomin = prestamos1.MontoMin.ToString();
                    string montomax = prestamos1.MontoMax.ToString();
                    string categoria = prestamos1.CodigoCategoria.ToString();
                    string auxcategoria = "";




                    if (categoria == "4")
                    {
                        auxcategoria = "Personal";
                    }
                    else if (categoria == "5")
                    {
                        auxcategoria = "Pyme";
                    }
                    else if (categoria == "6")
                    {
                        auxcategoria = "Corporativo";
                    }


                    TableRow row = new TableRow();
                    TableCell[] cell = new TableCell[] { new TableCell { Text = codigo }, new TableCell { Text = nombre }
                ,  new TableCell { Text = descripcion }, new TableCell { Text = tasa } , new TableCell { Text = plazo }
                        , new TableCell { Text = montomin }, new TableCell { Text = montomax }, new TableCell { Text = auxcategoria }};
                    //cell.Text = word.ToString();
                    row.Cells.AddRange(cell);
                    tablapres.Rows.Add(row);


                }
            }
            else
            {

                foreach (Prestamos prestamos1 in prestamos)
                {



                    string codigo = prestamos1.CodigoPrestamo.ToString();
                    string nombre = prestamos1.NombrePrestamo;
                    string descripcion = prestamos1.Descripcion.ToString();
                    string tasa = prestamos1.TasaInteres.ToString();
                    string plazo = prestamos1.CodigoPlazo.ToString();
                    string montomin = prestamos1.MontoMin.ToString();
                    string montomax = prestamos1.MontoMax.ToString();
                    string categoria = prestamos1.CodigoCategoria.ToString();
                    string auxcategoria = "";




                    if (categoria == "4")
                    {
                        auxcategoria = "Personal";
                    }
                    else if (categoria == "5")
                    {
                        auxcategoria = "Pyme";
                    }
                    else if (categoria == "6")
                    {
                        auxcategoria = "Corporativo";
                    }


                    TableRow row = new TableRow();
                    TableCell[] cell = new TableCell[] { new TableCell { Text = codigo }, new TableCell { Text = nombre }
                ,  new TableCell { Text = descripcion }, new TableCell { Text = tasa } , new TableCell { Text = plazo }
                        , new TableCell { Text = montomin }, new TableCell { Text = montomax }, new TableCell { Text = auxcategoria }};
                    //cell.Text = word.ToString();
                    row.Cells.AddRange(cell);
                    tablapres.Rows.Add(row);


                }
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/AgregarPrestamo.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtcodi.Text.Length <= 0)
            {
                lblerror.Visible = true;
                lblerror.Text = "ERROR: Debe indicar el codigo del prestamo a eliminar";
            }
            else
            {
                pres.Borrarprestamo(txtcodi.Text);
                cargarprestamos();
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtcodi.Text.Length <= 0)
            {
                lblerror.Visible = true;
                lblerror.Text = "ERROR: Debe indicar el codigo del prestamo a modificar";
            }
            else
            {
                LUser.codigopres = txtcodi.Text;
                Response.Redirect("../Pages/ActualizarPrestamo.aspx");
            }

        }

    }
}