using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;


namespace CapaNegocio
{
    public class NCalculadora
    {
        private const String SERVICE_URL = "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/Prestamos";
        Prestamos prestamos = new Prestamos();

        public int codigoPrestamo;
        public double tasa, montomin, montomax;
        public string nombrePrestamo, descripcion, mensaje;
        //    "codigoPrestamo": 0,
        //"nombrePrestamo": "string",
        //"descripcion": "string",
        //"tasaInteres": 0,
        //"codigoPlazo": 0,
        //"montoMin": 0,
        //"montoMax": 0,

        public List<Prestamos> ListarPrestamos()
        {
            try
            {
                using (var prestamos = new HttpClient())
                {
                    var task = Task.Run(
                    async () =>
                    {
                        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/Prestamos"))
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
                        List<Prestamos> prest = Prestamos.FromJson(resultStr);
                        return prest;
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

        public void CargarDatos(string tipo)
        {
            List<Prestamos> prest = ListarPrestamos();

            if (prest.Count > 0)
            {
                foreach (Prestamos prestamo in prest)
                {
                    if (prestamo.CodigoPrestamo == Convert.ToInt32(tipo))
                    {
                        tasa = prestamo.TasaInteres;
                        montomax = prestamos.MontoMax;
                        montomin = prestamos.MontoMin;
                        break;
                    }
                }
            }
            else
            {
                mensaje = "no se encontro el prestamo";
            }
        }
    //    public  CargarDatos()
    //    {
    //        try
    //        {
    ////            Usuario u = new Usuario()
    ////            {
    ////                Identificacion = Usuario,
    ////                Contrasenna = Contrasenna
    ////            };



    ////            string Json = u.ToJsonString();



    ////            using (var usuario = new HttpClient())
    ////            {
    ////                var task = Task.Run(
    ////                async () =>
    ////                {
    ////                    return await usuario.PostAsync(SERVICE_URL,
    ////new StringContent(Json, Encoding.UTF8, "application/json")
    ////);



    ////                }
    ////                );
    ////                HttpResponseMessage message = task.Result;
    ////                if (message.StatusCode == System.Net.HttpStatusCode.OK)
    ////                {
    ////                    var task2 = Task<string>.Run(async () =>
    ////                    {
    ////                        return await message.Content.ReadAsStringAsync();
    ////                    }
    ////                    );
    ////                    string resultStr = task2.Result;
    ////                    token.Usuario = Usuario;
    ////                    token.Contrasenna = Contrasenna;
    ////                    string newstr = resultStr.Replace("\"", "");
    ////                    token.Token1 = newstr;



    ////                    return "OK";
    ////                }
    ////                else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
    ////                {
    ////                    return "Datos Incorrectos";
    ////                }
    ////                else if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
    ////                {
    ////                    return "Error";
    ////                }
    ////                else
    ////                {
    ////                    return "Error";
    ////                }
    ////            }
    //        }
    //        catch (Exception ex)
    //        {
    //          //  return "Error";
    //        }
    //    }
    }
}
