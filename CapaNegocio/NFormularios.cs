using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NFormularios
    {

        public string CrearFormulario(PrestamoSolcitudCreditoClass Solicitud)
        {
            //if (string.IsNullOrEmpty(Solicitud.Identificacion) || string.IsNullOrEmpty(contactoNuevo.Nombre) || string.IsNullOrEmpty(contactoNuevo.Apellidos) || string.IsNullOrEmpty(contactoNuevo.Facebook) ||
            //string.IsNullOrEmpty(contactoNuevo.Twitter) || string.IsNullOrEmpty(contactoNuevo.Instagram))
            //{
            //    return "Los datos estan incompletos";
            //}

            string json = Solicitud.ToJsonString();
            using (HttpClient client = new HttpClient() { BaseAddress = new Uri("https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/SolcitudCreditos") })
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
                    return "Formulario enviado con éxito";
                }
                else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    return "Error en el envío del formulario";
                }
                return "Error en el envío del formulario";
            }
        }
    }
}
