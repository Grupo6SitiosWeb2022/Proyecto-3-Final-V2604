using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class NRoles
    {
        private const String SERVICE_URL = "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/Roles";

        public List<Roles> ListarRoles()
        {
            try
            {
                using (var prestamos = new HttpClient())
                {
                    var task = Task.Run(
                    async () =>
                    {
                        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/Roles"))
                        {
                            var respuesta = await prestamos.SendAsync(requestMessage);
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
                        List<Roles> rol = Roles.FromJson(resultStr);
                        return rol;
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

        public string Modificar(int codigo, string nombre)
        {
            try
            {



                if (!nombre.Equals(""))
                {
                    Roles c = new Roles()
                    {
                        NombreRol = nombre,
                        IdTipoRol = codigo
                    };

                    string Json = c.ToJsonString();



                    using (var rolt = new HttpClient())
                    {
                        var task = Task.Run(
                        async () =>
                        {
                            using (var requestMessage = new HttpRequestMessage(HttpMethod.Put, "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/Roles"))
                            {
                                requestMessage.Content = new StringContent(Json, Encoding.UTF8, "application/json");
                                var respuesta = await rolt.SendAsync(requestMessage);

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
                            throw new Exception("Token Vencido");
                        }
                        else
                        {
                            return "Error";
                        }
                    }
                }
                else
                {
                    return "Datos Incorrectos";
                }
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
        public string EliminarRol(int id, string nombre)

        {
            Roles r = new Roles()
            {
                IdTipoRol = id,
                NombreRol = nombre
            };
            string Json = r.ToJsonString();

            using (var rolt = new HttpClient())

            {

                var task = Task.Run(

                async () =>

                {

                    using (var requestMessage = new HttpRequestMessage(HttpMethod.Delete, "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/Roles"))
                    {
                        requestMessage.Content = new StringContent(Json, Encoding.UTF8, "application/json");
                        var respuesta = await rolt.SendAsync(requestMessage);

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

                    return "Rol borrado con exito";

                }

                else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)

                {

                    return "Rol no encontrado, Codigo: 404";

                }
                else
                {
                    return "Error";
                }


            }

        }
        //Se crea un contacto nuevo
        public string CrearRol(int id, string nombre)
        {
            Roles r = new Roles()
            {
                IdTipoRol = id,
                NombreRol = nombre
            };

            string json = r.ToJsonString();
            using (HttpClient client = new HttpClient() { BaseAddress = new Uri(SERVICE_URL) })
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
                    return "rol insertado con exito";
                }
                else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    return "El rol ya existe";
                }
                else
                {
                    return "Error";
                }
            }
        }
    }
}

