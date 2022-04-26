using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NIndicadores
    {
        private string SERVICE_URL = "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/Indicadores";

        public int ListAutenticados()
        {
            List<Indicadores> ListI = ListarIndicadores();
            int cantidad = 0;
            string codigo = "";

            foreach (Indicadores i in ListI)
            {
                if ((i.CodigotipoIndicador == 3))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigoIndicador.ToString();
                }
            }

            return cantidad;
        }

        public int ListNoAutenticados()
        {
            List<Indicadores> ListI = ListarIndicadores();
            int cantidad = 0;
            string codigo = "";
            foreach (Indicadores i in ListI)
            {
                if ((i.CodigotipoIndicador == 4))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigoIndicador.ToString();
                }
            }
            return cantidad;
        }

        public int ListAutenticadosFiltros(string fechaini, string fechafin)
        {
            List<Indicadores> ListI = ListarIndicadores();
            int cantidad = 0;
            string codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.Fecha > Convert.ToDateTime(fechaini) && i.Fecha < Convert.ToDateTime(fechafin))
                {
                    if ((i.CodigotipoIndicador == 3))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoIndicador.ToString();
                    }
                }
            }

            return cantidad;
        }

        public int ListNoAutenticadosFiltros(string fechaini, string fechafin)
        {
            List<Indicadores> ListI = ListarIndicadores();
            int cantidad = 0;
            string codigo = "";
            foreach (Indicadores i in ListI)
            {
                if (i.Fecha > Convert.ToDateTime(fechaini) && i.Fecha < Convert.ToDateTime(fechafin))
                {
                    if ((i.CodigotipoIndicador == 4))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoIndicador.ToString();
                    }
                }
            }
            return cantidad;
        }

        public List<Indicadores> ListarIndicadores()
        {
            try
            {
                using (var i = new HttpClient())
                {
                    var task = Task.Run(
                    async () =>
                    {
                        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, SERVICE_URL))
                        {
                            var respuesta = await i.SendAsync(requestMessage);
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
                        List<Indicadores> indica = Indicadores.FromJson(resultStr);
                        return indica;
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


        public string[,] ListarClick()
        {
            List <Indicadores>  ListI= ListarIndicadores();
            string[,] ListaDatos = new string[6,3];
            int cantidad = 0;
            string codigo="";
            foreach (Indicadores i in ListI)
            {
                
                if ((i.CodigoPrestamo==2) && (i.CodigotipoIndicador==1))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigoPrestamo.ToString();
                }
            }
            ListaDatos[0,0] = cantidad.ToString();
            ListaDatos[0,1] = codigo.ToString();


            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.CodigoPrestamo == 5 && (i.CodigotipoIndicador == 1))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigoPrestamo.ToString();
                }
            }
            ListaDatos[1, 0] = cantidad.ToString();
            ListaDatos[1, 1] = codigo.ToString();

            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.CodigoPrestamo == 6 && (i.CodigotipoIndicador == 1))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigoPrestamo.ToString();
                }
            }
            ListaDatos[2, 0] = cantidad.ToString();
            ListaDatos[2, 1] = codigo.ToString();

            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.CodigoPrestamo == 8 && (i.CodigotipoIndicador == 1))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigoPrestamo.ToString();
                }
            }
            ListaDatos[3, 0] = cantidad.ToString();
            ListaDatos[3, 1] = codigo.ToString();

            
            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.CodigoPrestamo == 9 && (i.CodigotipoIndicador == 1))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigoPrestamo.ToString();
                }
            }
            ListaDatos[4, 0] = cantidad.ToString();
            ListaDatos[4, 1] = codigo.ToString();

            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.CodigoPrestamo == 10 && (i.CodigotipoIndicador == 1))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigoPrestamo.ToString();
                }
            }
            ListaDatos[5, 0] = cantidad.ToString();
            ListaDatos[5, 1] = codigo.ToString();

            return ListaDatos;
        }

        public string[,] ListarSegundos()
        {
            List<Indicadores> ListI = ListarIndicadores();
            string[,] ListaDatos = new string[6, 3];
            int cantidad = 0;
            string codigo = "";
            foreach (Indicadores i in ListI)
            {

                if ((i.CodigoPrestamo == 2) && (i.CodigotipoIndicador == 2))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigoPrestamo.ToString();
                }
            }
            ListaDatos[0, 0] = cantidad.ToString();
            ListaDatos[0, 1] = codigo.ToString();


            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.CodigoPrestamo == 5 && (i.CodigotipoIndicador == 2))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigoPrestamo.ToString();
                }
            }
            ListaDatos[1, 0] = cantidad.ToString();
            ListaDatos[1, 1] = codigo.ToString();

            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.CodigoPrestamo == 6 && (i.CodigotipoIndicador == 2))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigoPrestamo.ToString();
                }
            }
            ListaDatos[2, 0] = cantidad.ToString();
            ListaDatos[2, 1] = codigo.ToString();

            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.CodigoPrestamo == 8 && (i.CodigotipoIndicador == 2))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigoPrestamo.ToString();
                }
            }
            ListaDatos[3, 0] = cantidad.ToString();
            ListaDatos[3, 1] = codigo.ToString();


            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.CodigoPrestamo == 9 && (i.CodigotipoIndicador == 2))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigoPrestamo.ToString();
                }
            }
            ListaDatos[4, 0] = cantidad.ToString();
            ListaDatos[4, 1] = codigo.ToString();

            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.CodigoPrestamo == 10 && (i.CodigotipoIndicador == 2))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigoPrestamo.ToString();
                }
            }
            ListaDatos[5, 0] = cantidad.ToString();
            ListaDatos[5, 1] = codigo.ToString();

            return ListaDatos;
        }

        public string[,] ListarAutenticados()
        {
            List<Indicadores> ListI = ListarIndicadores();
            string[,] ListaDatos = new string[2, 3];
            int cantidad = 0;
            string codigo = "";
            foreach (Indicadores i in ListI)
            {
                if ( (i.CodigotipoIndicador == 3))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigotipoIndicador.ToString();
                }
            }
            ListaDatos[0, 0] = cantidad.ToString();
            ListaDatos[0, 1] = codigo.ToString();


            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if ((i.CodigotipoIndicador == 4))
                {
                    cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                    codigo = i.CodigotipoIndicador.ToString();
                }
            }
            ListaDatos[1, 0] = cantidad.ToString();
            ListaDatos[1, 1] = codigo.ToString();

          
            return ListaDatos;
        }

        public string[,] ListarClickf(DateTime fechaI, DateTime fechaf)
        {
            List<Indicadores> ListI = ListarIndicadores();
            string[,] ListaDatos = new string[6, 3];
            int cantidad = 0;
            string codigo = "";
            foreach (Indicadores i in ListI)
            {
                if (i.Fecha.Date >= fechaI.Date && i.Fecha.Date <= fechaf.Date)
                {
                    if ((i.CodigoPrestamo == 2) && (i.CodigotipoIndicador == 1))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoPrestamo.ToString();
                    }
                }
            }
            ListaDatos[0, 0] = cantidad.ToString();
            ListaDatos[0, 1] = codigo.ToString();


            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.Fecha.Date >= fechaI.Date && i.Fecha.Date <= fechaf.Date)
                {
                    if (i.CodigoPrestamo == 5 && (i.CodigotipoIndicador == 1))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoPrestamo.ToString();
                    }
                }
            }
            ListaDatos[1, 0] = cantidad.ToString();
            ListaDatos[1, 1] = codigo.ToString();

            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.Fecha.Date >= fechaI.Date && i.Fecha.Date <= fechaf.Date)
                {
                    if (i.CodigoPrestamo == 6 && (i.CodigotipoIndicador == 1))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoPrestamo.ToString();
                    }
                }
            }
            ListaDatos[2, 0] = cantidad.ToString();
            ListaDatos[2, 1] = codigo.ToString();

            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.Fecha.Date >= fechaI.Date && i.Fecha.Date <= fechaf.Date)
                {
                    if (i.CodigoPrestamo == 8 && (i.CodigotipoIndicador == 1))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoPrestamo.ToString();
                    }
                }
            }
            ListaDatos[3, 0] = cantidad.ToString();
            ListaDatos[3, 1] = codigo.ToString();


            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.Fecha.Date >= fechaI.Date && i.Fecha.Date <= fechaf.Date)
                {
                    if (i.CodigoPrestamo == 9 && (i.CodigotipoIndicador == 1))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoPrestamo.ToString();
                    }
                }
            }
            ListaDatos[4, 0] = cantidad.ToString();
            ListaDatos[4, 1] = codigo.ToString();

            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.Fecha.Date >= fechaI.Date && i.Fecha.Date <= fechaf.Date)
                {
                    if (i.CodigoPrestamo == 10 && (i.CodigotipoIndicador == 1))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoPrestamo.ToString();
                    }
                }
            }
            ListaDatos[5, 0] = cantidad.ToString();
            ListaDatos[5, 1] = codigo.ToString();

            return ListaDatos;
        }

        public string[,] ListarSegundosf(DateTime fechaI, DateTime fechaf)
        {
            List<Indicadores> ListI = ListarIndicadores();
            string[,] ListaDatos = new string[6, 3];
            int cantidad = 0;
            string codigo = "";
            foreach (Indicadores i in ListI)
            {
                if (i.Fecha.Date >= fechaI.Date && i.Fecha.Date <= fechaf.Date)
                {
                    if ((i.CodigoPrestamo == 2) && (i.CodigotipoIndicador == 2))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoPrestamo.ToString();
                    }
                }
               
            }
            ListaDatos[0, 0] = cantidad.ToString();
            ListaDatos[0, 1] = codigo.ToString();


            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.Fecha.Date >= fechaI.Date && i.Fecha.Date <= fechaf.Date)
                {
                    if (i.CodigoPrestamo == 5 && (i.CodigotipoIndicador == 2))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoPrestamo.ToString();
                    }
                }
            }
            ListaDatos[1, 0] = cantidad.ToString();
            ListaDatos[1, 1] = codigo.ToString();

            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.Fecha.Date >= fechaI.Date && i.Fecha.Date <= fechaf.Date)
                {
                    if (i.CodigoPrestamo == 6 && (i.CodigotipoIndicador == 2))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoPrestamo.ToString();
                    }
                }
            }
            ListaDatos[2, 0] = cantidad.ToString();
            ListaDatos[2, 1] = codigo.ToString();

            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.Fecha.Date >= fechaI.Date && i.Fecha.Date <= fechaf.Date)
                {
                    if (i.CodigoPrestamo == 8 && (i.CodigotipoIndicador == 2))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoPrestamo.ToString();
                    }
                }
            }
            ListaDatos[3, 0] = cantidad.ToString();
            ListaDatos[3, 1] = codigo.ToString();


            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.Fecha.Date >= fechaI.Date && i.Fecha.Date <= fechaf.Date)
                {
                    if (i.CodigoPrestamo == 9 && (i.CodigotipoIndicador == 2))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoPrestamo.ToString();
                    }
                }
            }
            ListaDatos[4, 0] = cantidad.ToString();
            ListaDatos[4, 1] = codigo.ToString();

            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.Fecha.Date >= fechaI.Date && i.Fecha.Date <= fechaf.Date)
                {
                    if (i.CodigoPrestamo == 10 && (i.CodigotipoIndicador == 2))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoPrestamo.ToString();
                    }
                }
            }
            ListaDatos[5, 0] = cantidad.ToString();
            ListaDatos[5, 1] = codigo.ToString();

            return ListaDatos;
        }

        public string[,] ListarAutenticadosf(DateTime fechaI, DateTime fechaf)
        {
            List<Indicadores> ListI = ListarIndicadores();
            string[,] ListaDatos = new string[2, 3];
            int cantidad = 0;
            string codigo = "";
            foreach (Indicadores i in ListI)
            {
                if (i.Fecha.Date >= fechaI.Date && i.Fecha.Date <= fechaf.Date)
                {
                    if ((i.CodigotipoIndicador == 3))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoIndicador.ToString();
                    }
                }
            }
            ListaDatos[0, 0] = cantidad.ToString();
            ListaDatos[0, 1] = codigo.ToString();


            cantidad = 0;
            codigo = "";

            foreach (Indicadores i in ListI)
            {
                if (i.Fecha.Date >= fechaI.Date && i.Fecha.Date <= fechaf.Date)
                {
                    if ((i.CodigotipoIndicador == 4))
                    {
                        cantidad = cantidad + Convert.ToInt32(i.Cantidad);
                        codigo = i.CodigoIndicador.ToString();
                    }
                }
            }
            ListaDatos[1, 0] = cantidad.ToString();
            ListaDatos[1, 1] = codigo.ToString();


            return ListaDatos;
        }

        public string AgregarIndicador(int Prestamos, int Indicador)
        {
            DateTime fechah=DateTime.Now;
            Indicadores indicador = new Indicadores
            {
                Cantidad = 1,
                CodigoIndicador=Indicador,
                CodigoPrestamo=Prestamos,
                Fecha=fechah,
                CodigotipoIndicador=Indicador

            };
            string json = indicador.ToJsonString();
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
                    return "indicador insertado con exito";
                }
                else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    return "El indicador ya existe";
                }
                else
                {
                    return "Error";
                }
            }
        }
    }
}
