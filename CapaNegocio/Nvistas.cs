using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Web;
using CapaNegocio;
namespace CapaNegocio
{
    public class Nvistas
    {

        NCalculadora calc = new NCalculadora();
        private const String SERVICE_URL2 = "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/VistasDeInformacions";
        Prestamos user = new Prestamos();
        Nsolicitudes sol = new Nsolicitudes();

        public List<InfoVistas> ListarVistas()
        {
            try
            {
                using (var vistas = new HttpClient())
                {
                    var task = Task.Run(
                    async () =>
                    {
                        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, SERVICE_URL2))
                        {
                            var respuesta = await vistas.SendAsync(requestMessage);
                            return respuesta;
                        }
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        }
                        );
                        string resultStr = task2.Result;
                        List<InfoVistas> vista = Vistas.FromJson(resultStr);
                        return vista;
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        throw new Exception("Error");
                    }
                    else
                    {
                        throw new Exception("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VistaCompleta> ConteoVistas()
        {
            //List<DateTime> listaFechas = new List<DateTime>();

            //var query = from item in listaFechas
            //            group item by item.ToString("dd-MM-yy") into g
            //            select new { Fecha = g.Key, NumeroRegistros = g.Count() };
            List<Prestamos> prest = calc.ListarPrestamos();
            List<VistaAprobadas> listaA = new List<VistaAprobadas>();
            List<VistaPendientes> listaP = new List<VistaPendientes>();
            List<VistaDenegadas> listaD = new List<VistaDenegadas>();
            List<VistaTramitando> listaTr = new List<VistaTramitando>();
            List<VistaCompleta> listaC = new List<VistaCompleta>();
            List<VistaTotales> listaT = new List<VistaTotales>();
            List<InfoVistas> lista = new List<InfoVistas>();
            List<PrestamoSolcitudCredito> listaCP = new List<PrestamoSolcitudCredito>();
            listaCP = sol.ListarVistas();

            // List<Vista> vistalist = new List<Vista>();
            foreach (Prestamos pre in prest)
            {
                //Listar solicitudes totales
                var t = from p in listaCP
                        where p.CodigoPrestamo == pre.CodigoPrestamo
                        group p by new { fecha = p.FechaSolicitud }
                         into d0
                        select new
                        {
                            prestamo = pre.NombrePrestamo,
                            fecha = d0.Key.fecha,
                            total = d0.Count()
                        };


                foreach (var item in t)
                {
                    listaT.Add(new VistaTotales() { nombrePrestamo = item.prestamo, fecha = item.fecha.DateTime, numeroSsolicitudes = item.total });
                }
                //Listar solicitudes Pendientes
                var pe = from p in listaCP
                         where p.CodigoPrestamo == pre.CodigoPrestamo && p.EstadoSolicitud.Equals("Pendiente")
                         group p by new { fecha = p.FechaSolicitud }
                      into d1
                         select new
                         {
                             prestamo = pre.NombrePrestamo,
                             fecha = d1.Key.fecha,
                             total = d1.Count()
                         };


                foreach (var item in pe)
                {
                    listaP.Add(new VistaPendientes() { nombrePrestamo = item.prestamo, fecha = item.fecha.DateTime, solicitudespendientes = item.total });
                }
                //Listar solicitudes Aprobadas

                var a = from p in listaCP
                        where p.CodigoPrestamo == pre.CodigoPrestamo && p.EstadoSolicitud.Equals("Aprobada")
                        group p by new { fecha = p.FechaSolicitud }
                    into d2
                        select new
                        {
                            prestamo = pre.NombrePrestamo,
                            fecha = d2.Key.fecha,
                            total = d2.Count()
                        };


                foreach (var item in a)
                {
                    listaA.Add(new VistaAprobadas() { nombrePrestamo = item.prestamo, fecha = item.fecha.DateTime, solicitudesAprobadas = item.total });
                }

                //Listar solicitudes denegadas
                var d = from p in listaCP
                        where p.CodigoPrestamo == pre.CodigoPrestamo && p.EstadoSolicitud == "Denegada"
                        group p by new { fecha = p.FechaSolicitud }
                    into d3
                        select new
                        {
                            prestamo = pre.NombrePrestamo,
                            fecha = d3.Key.fecha,
                            total = d3.Count()
                        };


                foreach (var item in d)
                {
                    listaD.Add(new VistaDenegadas() { nombrePrestamo = item.prestamo, fecha = item.fecha.DateTime, solicitudesdenegadas = item.total });

                }

                //Listar solicitudes tramitando
                var tr = from p in listaCP
                         where p.CodigoPrestamo == pre.CodigoPrestamo && p.EstadoSolicitud == "Tramitando"
                         group p by new { fecha = p.FechaSolicitud }
                    into d4
                         select new
                         {
                             prestamo = pre.NombrePrestamo,
                             fecha = d4.Key.fecha,
                             total = d4.Count()
                         };


                foreach (var item in tr)
                {
                    listaTr.Add(new VistaTramitando() { nombrePrestamo = item.prestamo, fecha = item.fecha.DateTime, solicitudesTramitando = item.total });
                }

            }

            foreach (Prestamos pre in prest)
            {
                long pendientes = 0, totales = 0, denegadas = 0, aprobadas = 0, tramitanto = 0;

                foreach (var VistaTramitando in listaTr)
                {
                    if (pre.NombrePrestamo.Equals(VistaTramitando.nombrePrestamo))
                    {
                        tramitanto = tramitanto + VistaTramitando.solicitudesTramitando;
                    }
                }
                foreach (var VistaAprobada in listaA)
                {
                    if (pre.NombrePrestamo.Equals(VistaAprobada.nombrePrestamo))
                    {
                        aprobadas = aprobadas + VistaAprobada.solicitudesAprobadas;
                    }
                }
                foreach (var VistaDenegada in listaD)
                {
                    if (pre.NombrePrestamo.Equals(VistaDenegada.nombrePrestamo))
                    {
                        denegadas = denegadas + VistaDenegada.solicitudesdenegadas;
                    }
                }
                foreach (var vistaPendiente in listaP)
                {
                    if (pre.NombrePrestamo.Equals(vistaPendiente.nombrePrestamo))
                    {
                        pendientes = pendientes + vistaPendiente.solicitudespendientes;
                    }
                }
                foreach (var VistaTotal in listaT)
                {
                    if (pre.NombrePrestamo.Equals(VistaTotal.nombrePrestamo))
                    {
                        totales = totales + VistaTotal.numeroSsolicitudes;
                    }
                }
                listaC.Add(new VistaCompleta() { nombrePrestamo = pre.NombrePrestamo, solicitudesAprobadas = aprobadas, solicitudesDenegadas = denegadas, solicitudesPendientes = pendientes, solicitudestramitando = tramitanto, numeroSsolicitudes = totales });

            }

            return listaC;
        }

        public List<VistaCompleta> ConteoVistasFiltro(DateTime fechaini, DateTime fechafin)
        {
            //List<DateTime> listaFechas = new List<DateTime>();

            //var query = from item in listaFechas
            //            group item by item.ToString("dd-MM-yy") into g
            //            select new { Fecha = g.Key, NumeroRegistros = g.Count() };
            List<Prestamos> prest = calc.ListarPrestamos();
            List<VistaAprobadas> listaA = new List<VistaAprobadas>();
            List<VistaPendientes> listaP = new List<VistaPendientes>();
            List<VistaDenegadas> listaD = new List<VistaDenegadas>();
            List<VistaTramitando> listaTr = new List<VistaTramitando>();
            List<VistaCompleta> listaC = new List<VistaCompleta>();
            List<VistaTotales> listaT = new List<VistaTotales>();
            List<InfoVistas> lista = new List<InfoVistas>();
            List<PrestamoSolcitudCredito> listaCP = new List<PrestamoSolcitudCredito>();
            listaCP = sol.ListarVistas();

            // List<Vista> vistalist = new List<Vista>();
            foreach (Prestamos pre in prest)
            {
                //Listar solicitudes totales
                var t = from p in listaCP
                        where p.CodigoPrestamo == pre.CodigoPrestamo && p.FechaSolicitud > Convert.ToDateTime(fechaini) && p.FechaSolicitud < Convert.ToDateTime(fechafin)

                        group p by new { fecha = p.FechaSolicitud }
                         into d0
                        select new
                        {
                            prestamo = pre.NombrePrestamo,
                            fecha = d0.Key.fecha,
                            total = d0.Count()
                        };


                foreach (var item in t)
                {
                    listaT.Add(new VistaTotales() { nombrePrestamo = item.prestamo, fecha = item.fecha.DateTime, numeroSsolicitudes = item.total });
                }
                //Listar solicitudes Pendientes
                var pe = from p in listaCP
                         where p.CodigoPrestamo == pre.CodigoPrestamo && p.EstadoSolicitud.Equals("Pendiente") && p.FechaSolicitud > Convert.ToDateTime(fechaini) && p.FechaSolicitud < Convert.ToDateTime(fechafin)
                         group p by new { fecha = p.FechaSolicitud }
                      into d1
                         select new
                         {
                             prestamo = pre.NombrePrestamo,
                             fecha = d1.Key.fecha,
                             total = d1.Count()
                         };


                foreach (var item in pe)
                {
                    listaP.Add(new VistaPendientes() { nombrePrestamo = item.prestamo, fecha = item.fecha.DateTime, solicitudespendientes = item.total });
                }
                //Listar solicitudes Aprobadas

                var a = from p in listaCP
                        where p.CodigoPrestamo == pre.CodigoPrestamo && p.EstadoSolicitud.Equals("Aprobada") && p.FechaSolicitud > Convert.ToDateTime(fechaini) && p.FechaSolicitud < Convert.ToDateTime(fechafin)
                        group p by new { fecha = p.FechaSolicitud }
                    into d2
                        select new
                        {
                            prestamo = pre.NombrePrestamo,
                            fecha = d2.Key.fecha,
                            total = d2.Count()
                        };


                foreach (var item in a)
                {
                    listaA.Add(new VistaAprobadas() { nombrePrestamo = item.prestamo, fecha = item.fecha.DateTime, solicitudesAprobadas = item.total });
                }

                //Listar solicitudes denegadas
                var d = from p in listaCP
                        where p.CodigoPrestamo == pre.CodigoPrestamo && p.EstadoSolicitud == "Denegada" && p.FechaSolicitud > Convert.ToDateTime(fechaini) && p.FechaSolicitud < Convert.ToDateTime(fechafin)
                        group p by new { fecha = p.FechaSolicitud }
                    into d3
                        select new
                        {
                            prestamo = pre.NombrePrestamo,
                            fecha = d3.Key.fecha,
                            total = d3.Count()
                        };


                foreach (var item in d)
                {
                    listaD.Add(new VistaDenegadas() { nombrePrestamo = item.prestamo, fecha = item.fecha.DateTime, solicitudesdenegadas = item.total });

                }

                //Listar solicitudes tramitando
                var tr = from p in listaCP
                         where p.CodigoPrestamo == pre.CodigoPrestamo && p.EstadoSolicitud == "Tramitando" && p.FechaSolicitud > Convert.ToDateTime(fechaini) && p.FechaSolicitud < Convert.ToDateTime(fechafin)
                         group p by new { fecha = p.FechaSolicitud }
                    into d4
                         select new
                         {
                             prestamo = pre.NombrePrestamo,
                             fecha = d4.Key.fecha,
                             total = d4.Count()
                         };


                foreach (var item in tr)
                {
                    listaTr.Add(new VistaTramitando() { nombrePrestamo = item.prestamo, fecha = item.fecha.DateTime, solicitudesTramitando = item.total });
                }

            }

            foreach (Prestamos pre in prest)
            {
                long pendientes = 0, totales = 0, denegadas = 0, aprobadas = 0, tramitanto = 0;

                foreach (var VistaTramitando in listaTr)
                {
                    if (pre.NombrePrestamo.Equals(VistaTramitando.nombrePrestamo))
                    {
                        tramitanto = tramitanto + VistaTramitando.solicitudesTramitando;
                    }
                }
                foreach (var VistaAprobada in listaA)
                {
                    if (pre.NombrePrestamo.Equals(VistaAprobada.nombrePrestamo))
                    {
                        aprobadas = aprobadas + VistaAprobada.solicitudesAprobadas;
                    }
                }
                foreach (var VistaDenegada in listaD)
                {
                    if (pre.NombrePrestamo.Equals(VistaDenegada.nombrePrestamo))
                    {
                        denegadas = denegadas + VistaDenegada.solicitudesdenegadas;
                    }
                }
                foreach (var vistaPendiente in listaP)
                {
                    if (pre.NombrePrestamo.Equals(vistaPendiente.nombrePrestamo))
                    {
                        pendientes = pendientes + vistaPendiente.solicitudespendientes;
                    }
                }
                foreach (var VistaTotal in listaT)
                {
                    if (pre.NombrePrestamo.Equals(VistaTotal.nombrePrestamo))
                    {
                        totales = totales + VistaTotal.numeroSsolicitudes;
                    }
                }
                listaC.Add(new VistaCompleta() { nombrePrestamo = pre.NombrePrestamo, solicitudesAprobadas = aprobadas, solicitudesDenegadas = denegadas, solicitudesPendientes = pendientes, solicitudestramitando = tramitanto, numeroSsolicitudes = totales });

            }

            return listaC;
        }
    }
}
