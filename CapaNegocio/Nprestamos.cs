using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class Nprestamos
    {
        private const String SERVICE_URL2 = "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/Prestamos";

        Prestamos prestamos = new Prestamos();

        public List<Prestamos> Listarprestamos()
        {
            try
            {
                using (var prestamo = new HttpClient())
                {
                    var task = Task.Run(
                    async () =>
                    {
                        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, SERVICE_URL2))
                        {
                            var respuesta = await prestamo.SendAsync(requestMessage);
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
                        List<Prestamos> pres = Prestamos.FromJson(resultStr);
                        return pres;
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

        public string ValidarNulosNewPrestamo(string nombre, string descrip, string tasa, string plazo, string montomin, string montomax, string categoria)
        {
            try
            {
                if (nombre.Length != 0)
                {
                    if (descrip.Length != 0)
                    {
                        if (Convert.ToString(tasa).Length != 0)
                        {
                            if (Convert.ToString(plazo).Length != 0)
                            {
                                if (Convert.ToString(montomin).Length != 0)
                                {
                                    if (Convert.ToString(montomax).Length != 0)
                                    {
                                        if (Convert.ToString(categoria).Length != 0)
                                        {
                                            return "1";
                                        }
                                        else
                                        {
                                            return "El campo de la categoría es Obligatorio";
                                        }
                                    }
                                    else
                                    {
                                        return "El campo del monto máximo es Obligatorio";
                                    }
                                }
                                else
                                {
                                    return "El campo del monto mínimo es Obligatorio";
                                }
                            }
                            else
                            {
                                return "El campo del código plazo es Obligatorio";
                            }
                        }
                        else
                        {
                            return "El campo de la tasa de interés es Obligatorio";
                        }
                    }
                    else
                    {
                        return "El campo de la descripción es Obligatorio";
                    }
                }
                else
                {
                    return "El campo del nombre es Obligatorio";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ModificarPrestamo(string codipres, string nombre, string descrip, string tasa, string plazo, string montomin, string montomax, string categoria)
        {
            try
            {

                Prestamos p = new Prestamos()
                {
                    CodigoPrestamo = Convert.ToInt32(codipres),
                    NombrePrestamo = nombre,
                    Descripcion = descrip,
                    TasaInteres = Convert.ToInt32(tasa),
                    CodigoPlazo = Convert.ToInt32(plazo),
                    MontoMin = Convert.ToInt32(montomin),
                    MontoMax = Convert.ToInt32(montomax),
                    CodigoCategoria = Convert.ToInt32(categoria)

                };

                string Json = p.ToJsonString();


                string url = SERVICE_URL2 + "/" + codipres;
                using (var rolt = new HttpClient())
                {
                    var task = Task.Run(
                    async () =>
                    {
                        using (var requestMessage = new HttpRequestMessage(HttpMethod.Put, url))
                        {
                            requestMessage.Content = new StringContent(Json, Encoding.UTF8, "application/json");
                            var respuesta = await rolt.SendAsync(requestMessage);

                            return respuesta;
                        }
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        }
                        );

                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "Datos Incorrectos";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        throw new Exception("ERROR");
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
        public string CrearPrestamo(string nombre, string descrip, string tasa, string plazo, string montomin, string montomax, string categoria)
        {
            Prestamos p = new Prestamos()
            {
                CodigoPrestamo = 0,
                NombrePrestamo = nombre,
                Descripcion = descrip,
                TasaInteres = Convert.ToInt32(tasa),
                CodigoPlazo = Convert.ToInt32(plazo),
                MontoMin = Convert.ToInt32(montomin),
                MontoMax = Convert.ToInt32(montomax),
                CodigoCategoria = Convert.ToInt32(categoria)

            };

            string json = p.ToJsonString();
            using (HttpClient client = new HttpClient() { BaseAddress = new Uri(SERVICE_URL2) })
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
                if (message.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var task2 = Task<string>.Run(async () =>
                    {
                        return await message.Content.ReadAsStringAsync();
                    }
                    );
                    return "1";
                }
                else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    return "El prestamo ya existe";
                }
                else
                {
                    return "Error";
                }
            }
        }

        public string Borrarprestamo(string codigo)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.DeleteAsync(
                             SERVICE_URL2 + "/" + codigo);

                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "El prestamo no se encuentra registrado";
                    }
                    else
                    {
                        return "ERROR";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
