using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using CapaDatos;

using System.Net.Mime;
using System.Net.Http;

namespace CapaNegocio
{
    public class NCorreo
    {

        public string sendMail(string destinatario, string asunto, string body)
        {
            string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
            string from = "banconav20@gmail.com";
            string displayName = "Banco Nav";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(destinatario);

                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Host y puerto
                client.Credentials = new NetworkCredential(from, "proyectoGrupo6");
                client.EnableSsl = true;


                client.Send(mail);
                msge = "Correo enviado";

            }
            catch (Exception ex)
            {
                msge = ex.Message + "Error: al enviar el correo.";
            }

            return msge;
        }
        public void SendMailPrestamo(string destinatario, string nom, string nomPrestamo, string Titulollamativo, string texto)
        {
            string body1 = @"<style>
                            h1{color:#ee8133;font-size: 25px; font-weight: bold; text-align: center;}
                            h6{color:black; font-size: medium;}
                            h5{color:#ee8133;font-size: medium; font-weight: bold; text-align: center;}
                            img {text-align: center; width: 450px; height: auto;}
                            </style>
                           " +

                            $"<center><img src='https://drive.google.com/uc?export=download&id=1Xkt39Q8Xh8R53hEmTxPVh535AcRKF-_I'> </img></center>" +
                            $"<h1> Información del préstamo {nomPrestamo}</ h1 > " +

                            $"<h6> Estimad@ {nom}, usted ha solicitado información del préstamo {nomPrestamo} la cual es adjuntada en el siguiente correo. </ h6 >" +

                            $"<h5> {Titulollamativo} </ h6 >" +

                            $"<h6> {texto} </ h6 >" +

                            $"<center><img src='https://drive.google.com/uc?export=download&id=16YFelVXmJqo5Un4iL4a_uqDkZDeK5FT-'> </img></center>" +

                            $"<h6> Si desea más información puede presentarse a cualquiera de nuestras oficinas, también recordarle que puede comunicarse al número de teléfono 2211-1135. </h6>" +

                            $"<h6> Estimado cliente, esta notificación es generada de forma automática de acuerdo con lo establecido por el Banco NAV, en su reglamento interno, por lo que agradecemos no responder este correo. </h6>" +

                            $"<h6> Saludos. </h6>";



            sendMail(destinatario, "Información préstamo.", body1);
        }

        public void SendMailCambioInfo(string identificacion, string nom, string nacionalidad, string tel, string correo, string direc, string Rol)
        {
            string body1 = @"<style>
                            h1{color:#ee8133;font-size: 25px; font-weight: bold; text-align: center;}
                            h6{color:black; font-size: medium; }
                            h5{color:black;font-size: medium; text-align: center;}
                            img {text-align: center; width: 450px; height: auto;}
                            </style>
                           " +

                            $"<center><img src='https://drive.google.com/uc?export=download&id=1Xkt39Q8Xh8R53hEmTxPVh535AcRKF-_I'> </img></center>" +
                            $"<h1> Aviso cambio de información</ h1 > " +

                            $"<h6> Estimad@ {nom}, se le ha realizado un cambio en la información de su usuario los cambios son:. </ h6 >" +

                            $"<h5> Identificación: {identificacion} </ h6 >" +
                            $"<h5> Nombre: {nom} </ h6 >" +
                            $"<h5> Nacionalidad: {nacionalidad} </ h6 >" +
                            $"<h5> Teléfono: {tel} </ h6 >" +
                            $"<h5> Correo: {correo} </ h6 >" +
                            $"<h5> Dirrección: {direc} </ h6 >" +
                            $"<h5> Rol: {Rol} </ h6 >" +

                            $"<h6> Si usted no está enterado de dicho cambio, por favor asistir a recursos humanos para explicar la situación. </ h6 >" +

                            $"<h6> Estimado usuario, esta notificación es generada de forma automática de acuerdo con lo establecido por el Banco NAV, en su reglamento interno, por lo que agradecemos no responder este correo. </h6>" +

                            $"<h6> Saludos. </h6>";



            sendMail(correo, "Aviso cambio de información", body1);
        }

        public void SendMailNuevoUsuario(string identificacion, string nom, string nacionalidad, string tel, string correo, string direc, string Rol)
        {

            if (Rol == "Cliente")
            {
                string fecha = DateTime.Now.ToString();


                string body1 = @"<style>
                            h1{color:#ee8133;font-size: 25px; font-weight: bold; text-align: center;}
                            h6{color:black; font-size: medium;}
                            img {text-align: center; width: 450px; height: auto;}
                            </style>
                           " +

                            $"<center><img src='https://drive.google.com/uc?export=download&id=1Xkt39Q8Xh8R53hEmTxPVh535AcRKF-_I'> </img></center>" +
                            $"<h1> Registro completado</ h1 > " +

                            $"<h6> Estimad@ {nom}, realizo un registro en el sitio Web de Banco Nav, el día {fecha}. </ h6 >" +

                            $"<h6> El motivo de este correo es agradecerle por su preferencia hacia nosotros, ya puede utilizar nuestro sitio web, además de poder llenar solicitudes de préstamos y/o pedir información de estos por correo electrónico, el cual nos brindó en el formulario de registro. </ h6 >" +

                            $"<h6> Si desea más información puede presentarse a cualquiera de nuestras oficinas, también recordarle que puede comunicarse al número de teléfono 2211-1135. </h6>" +

                            $"<h6> Estimado cliente, esta notificación es generada de forma automática de acuerdo con lo establecido por el Banco NAV, en su reglamento interno, por lo que agradecemos no responder este correo. </h6>" +

                            $"<h6> Saludos. </h6>";

                sendMail(correo, "Registro completado.", body1);
            }
            else
            {


                string body1 = @"<style>
                            h1{color:#ee8133;font-size: 25px; font-weight: bold; text-align: center;}
                            h6{color:black; font-size: medium; }
                            h5{color:black;font-size: medium; text-align: center;}
                            img {text-align: center; width: 450px; height: auto;}
                            </style>
                           " +

                                $"<center><img src='https://drive.google.com/uc?export=download&id=1Xkt39Q8Xh8R53hEmTxPVh535AcRKF-_I'> </img></center>" +
                                $"<h1> Usuario nuevo</ h1 > " +

                                $"<h6> Estimad@ {nom}, se le ha realizado la creación de un usuario para la empresa, es un gusto contar con usted, los datos con los que fue registrado son:. </ h6 >" +

                                $"<h5> Identificación: {identificacion} </ h6 >" +
                                $"<h5> Nombre: {nom} </ h6 >" +
                                $"<h5> Nacionalidad: {nacionalidad} </ h6 >" +
                                $"<h5> Teléfono: {tel} </ h6 >" +
                                $"<h5> Correo: {correo} </ h6 >" +
                                $"<h5> Dirrección: {direc} </ h6 >" +
                                $"<h5> Rol: {Rol} </ h6 >" +

                                $"<h6> Si algún dato esta incorrecto, por favor asistir a recursos humanos para explicar la situación y que se pueda hacer el cambio lo antes posible. </ h6 >" +

                                $"<h6> Estimado usuario, esta notificación es generada de forma automática de acuerdo con lo establecido por el Banco NAV, en su reglamento interno, por lo que agradecemos no responder este correo. </h6>" +

                                $"<h6> Saludos. </h6>";

                sendMail(correo, "Usuario nuevo", body1);

            }



        }
        private const String SERVICE_URL2 = "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/SolicitudesAnalistas";

        SolicitudesAnalista analista = new SolicitudesAnalista();

        public List<SolicitudesAnalista> Listarsolianalistas()
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

    }
}

