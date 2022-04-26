using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;
namespace ProyectoSitios.Pages
{
    public partial class VistasSolicitudesTramitador : System.Web.UI.Page
    {
        NRoles nroles = new NRoles();
        Nusuarios nusuarios = new Nusuarios();
        Nsolicitudes soli = new Nsolicitudes();
        NCorreo correos = new NCorreo();
        Nusuarios user = new Nusuarios();
        string nombreAnalista = "";
        string auxprestamo = "";
        static int tipoRol = 0;
        NCalculadora calc = new NCalculadora();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarvistas();
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

     
        public void cargarvistas()
        {

            List<SolicitudesXTramitadores> solcitudCreditos = soli.ListarSolicitudesTramitador();

            foreach (SolicitudesXTramitadores solcitud in solcitudCreditos)
            {
               
                string numSoli = solcitud.NumeroSolicitud.ToString();
                string identificacion = solcitud.identificacionTramitador;

                TableRow row = new TableRow();
                TableCell[] cell = new TableCell[] { new TableCell { Text = numSoli }, new TableCell { Text = identificacion }};

                row.Cells.AddRange(cell);
                TalaVistas.Rows.Add(row);

                //}
                //}
            }
        }

        protected void btntramitar_Click1(object sender, EventArgs e)
        {
            List<SolicitudesXTramitadores> solcitudCreditos = soli.ListarSolicitudesTramitador();

            foreach (SolicitudesXTramitadores solcitud in solcitudCreditos)
            {
                if (solcitud.NumeroSolicitud==Convert.ToInt32(txtTramitar.Text))
                {
                    string numSoli = solcitud.NumeroSolicitud.ToString();
                    string identificacion = solcitud.identificacionTramitador;

                    TableRow row = new TableRow();
                    TableCell[] cell = new TableCell[] { new TableCell { Text = numSoli }, new TableCell { Text = identificacion } };

                    row.Cells.AddRange(cell);
                    TalaVistas.Rows.Add(row);
                }
                else
                {
                    cargarvistas();
                }
              

                //}
                //}
            }
        }

        protected void txtTramitar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}