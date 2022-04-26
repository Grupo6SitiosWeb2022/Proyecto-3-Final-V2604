using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NPlazosCatego
    {
        private const String SERVICE_URL = "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/Plazos";
        private const String SERVICE_URL2 = "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/CategoriasPrestamos";

        public List<PrestamoPlazosClass> ListarPlazos()
        {
            try
            {
                using (var prestamos = new HttpClient())
                {
                    var task = Task.Run(
                    async () =>
                    {
                        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, SERVICE_URL))
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
                        List<PrestamoPlazosClass> plazo = PrestamoPlazosClass.FromJson(resultStr);
                        return plazo;
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

        public List<PurpleCategoriasPrestamos> ListarCategoria()
        {
            try
            {
                using (var prestamos = new HttpClient())
                {
                    var task = Task.Run(
                    async () =>
                    {
                        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, SERVICE_URL2))
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
                        List<PurpleCategoriasPrestamos> catego = PurpleCategoriasPrestamos.FromJson(resultStr);
                        return catego;
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
    }
}