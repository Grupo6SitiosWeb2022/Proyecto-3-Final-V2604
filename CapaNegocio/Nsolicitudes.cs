using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class Nsolicitudes
    {

        private const String SERVICE_URL2 = "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/SolcitudCreditos";
        private const String SERVICE_URL1 = "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/Tramitador";

        Prestamos user = new Prestamos();

        public List<PrestamoSolcitudCredito> ListarVistas()
        {
            try
            {
                using (var solicitud = new HttpClient())
                {
                    var task = Task.Run(
                    async () =>
                    {
                        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, SERVICE_URL2))
                        {
                            var respuesta = await solicitud.SendAsync(requestMessage);
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
                        List<PrestamoSolcitudCredito> soli = SolicitudesCredito.FromJson(resultStr);
                        return soli;
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
        public List<SolicitudesAnalista> ListarAnalistas()
        {
            try
            {
                using (var solicitud = new HttpClient())
                {
                    var task = Task.Run(
                    async () =>
                    {
                        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/SolicitudesAnalistas"))
                        {
                            var respuesta = await solicitud.SendAsync(requestMessage);
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
                        List<SolicitudesAnalista> soli = SolicitudesAnalista.FromJson(resultStr);
                        return soli;
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

        public List<PrestamoSolcitudCredito> ListarFiltro(DateTime fi, DateTime ff)
        {
            List<PrestamoSolcitudCredito> nl = ListarVistas();
            List<PrestamoSolcitudCredito> n2 = new List<PrestamoSolcitudCredito>();

            foreach (PrestamoSolcitudCredito solcitud in nl)
            {
                if (solcitud.FechaSolicitud.Date >= fi.Date && solcitud.FechaSolicitud.Date <= ff.Date)
                {
                    n2.Add(solcitud);
                }
            }
            return n2;
        }
        public List<SolicitudesXTramitadores> ListarSolicitudesTramitador()
        {
            List<SolicitudesAnalista> nl = ListarAnalistas();
            List<PrestamoSolcitudCredito> n2 = ListarVistas();
            List<SolicitudesXTramitadores> n3 = new List<SolicitudesXTramitadores>();

            foreach (PrestamoSolcitudCredito solcitud in n2)
            {
                foreach (SolicitudesAnalista s in nl)
                {
                    if (solcitud.NumSolicitud == s.NumSolicitud)
                    {
                        n3.Add(new SolicitudesXTramitadores() { NumeroSolicitud =Convert.ToInt32(solcitud.NumSolicitud), identificacionTramitador = s.AnalistaEncargado }) ;
                    }
                }
            }
            return n3;
        }
        public List<PrestamoSolcitudCredito> ListarEndeudamiento(int numsoli)
        {
            try
            {
                string url = SERVICE_URL2;
                using (var solicitud = new HttpClient())
                {
                    var task = Task.Run(
                    async () =>
                    {
                        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
                        {
                            var respuesta = await solicitud.SendAsync(requestMessage);
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
                        List<PrestamoSolcitudCredito> soli = SolicitudesCredito.FromJson(resultStr);
                        return soli;



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
        public string EnviarSolicitud(int id, string estado)
        {
            SolicitudesTramitar r = new SolicitudesTramitar()
            {
                NumSolicitud = id
            };

            string json = r.ToJsonString();
            using (HttpClient client = new HttpClient() { BaseAddress = new Uri(SERVICE_URL1) })
            {
                var task = Task.Run(
                        async () =>
                        {
                            using (HttpRequestMessage req = new HttpRequestMessage() { Method = HttpMethod.Post })
                            {

                                req.Content = new StringContent(json, Encoding.UTF8, "application/json");
                                var respuesta = await client.SendAsync(req);
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
                    Modificar(id, estado);
                    return "solicitud enviada con exito";
                   
                }
                else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    return "La solicitud no existe";
                }
                else
                {
                    return "Error";
                }
            }
        }
        public string Modificar(int numsoli, string estado)
        {
            try
            {
                string url = "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/SolcitudCreditos";
               

              

                    PrestamoSolcitudCredito c = new PrestamoSolcitudCredito()
                    {
                        NumSolicitud = numsoli,
                        EstadoSolicitud = estado
                    };



                    string Json = c.ToJsonString();



                    using (var solicitud = new HttpClient())
                    {
                        var task = Task.Run(
                        async () =>
                        {
                            using (var requestMessage = new HttpRequestMessage(HttpMethod.Put, url))
                            {
                                
                                requestMessage.Content = new StringContent(Json, Encoding.UTF8, "application/json");
                                var respuesta = await solicitud.SendAsync(requestMessage);
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
                            return "OK";
                        }
                        else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            return "Datos Incorrectos";
                        }
                        else if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                        {
                            throw new Exception("Errores internos");
                        }
                        else
                        {
                            return "Error";
                        }
                    }                
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
    }
}
