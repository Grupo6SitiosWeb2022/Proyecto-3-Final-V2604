using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;


namespace CapaNegocio
{
    public class Nusuarios
    {

        public usuarios usuario = new usuarios();


        private const String SERVICE_URL = "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/Usuarios/InicioSesion";
        private const String SERVICE_URL2 = "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/Usuarios";
        Prestamos  user = new Prestamos();

        public List<Usuarios> ListarUsuarios()
        {
            try
            {
                using (var prestamos = new HttpClient())
                {
                    var task = Task.Run(
                    async () =>
                    {
                        using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/Usuarios"))
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
                        List<Usuarios> rol = Usuarios.FromJson(resultStr);
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
        public string InicioSesion(string identificacion, string pass)
        {
            try
            {
                string res = usuario.InicioSesion(new CapaDatos.Modelos.ModelLogin()
                {
                    identificacion = identificacion,
                    contrasenna = pass,

                });

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string crearUsuario(string identificacion, string nombre, string nacionalidad, string telefono, string Correo, string direccion, string pass, string tiporol)
        {
            try
            {
                string res = usuario.crearUsuarios(new CapaDatos.Modelos.ModelUsuario()
                {
                    identificacion = identificacion,
                    NombreCompleto = nombre,
                    Nacionalidad = nacionalidad,
                    Telefono = telefono,
                    CorreoElectronico = Correo,
                    Dirrecion = direccion,
                    pass = pass,
                    TipoRol = tiporol

                });

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string crearUsuario2(string identificacion, string nombre, string nacionalidad, string telefono, string Correo, string direccion, string pass, int tiporol)
        {
            try
            {
                string res = CrearContacto(new Usuarios()
                {
                    Identificacion = identificacion,
                    NombreCompleto = nombre,
                    Nacionalidad = nacionalidad,
                    Telefono = telefono,
                    CorreoElectronico = Correo,
                    Direccion = direccion,
                    Pass = pass,
                    TipoRol = tiporol

                });

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CrearContacto(Usuarios contacto)
        {
            if (string.IsNullOrEmpty(contacto.Identificacion) || string.IsNullOrEmpty(contacto.NombreCompleto) || string.IsNullOrEmpty(contacto.Nacionalidad) || string.IsNullOrEmpty(contacto.Telefono) ||
                string.IsNullOrEmpty(contacto.CorreoElectronico) || string.IsNullOrEmpty(contacto.Direccion) || string.IsNullOrEmpty(contacto.Pass) )
            {
                return "Los datos estan incompletos";
            }
            
            string json = contacto.ToJsonString();
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
                    return "El usuario ya existe";
                }
                return "0";
            }
        }

        public string ValidarNulosRegistro(string Identificacion, string Nombre, string Nacionalidad, string tel, string correo, string direccion, string pass)
        {
            try
            {
                if (Identificacion.Length != 0)
                {
                    if (Nombre.Length != 0)
                    {
                        if (Nacionalidad.Length != 0)
                        {
                            if (tel.Length != 0)
                            {
                                if (correo.Length != 0)
                                {
                                    if (direccion.Length != 0)
                                    {
                                        if (pass.Length != 0)
                                        {
                                            return "1";
                                        }
                                        else
                                        {
                                            return "El campo de la contraseña es Obligatorio";
                                        }
                                    }
                                    else
                                    {
                                        return "El campo de la direccion es Obligatorio";
                                    }
                                }
                                else
                                {
                                    return "El campo del correo es Obligatorio";
                                }
                            }
                            else
                            {
                                return "El campo del telefono es Obligatorio";
                            }
                        }
                        else
                        {
                            return "El campo de la nacionalidad es Obligatorio";
                        }
                    }
                    else
                    {
                        return "El campo del Nombre es Obligatorio";
                    }
                }
                else
                {
                    return "El campo de la Identificacion es Obligatorio";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarTexto(string Nombre, string nacionalidad)
        {
            try
            {
                Nombre = Nombre.Replace(" ", String.Empty);
                if (Nombre.All(char.IsLetter))
                {
                    nacionalidad = nacionalidad.Replace(" ", String.Empty);
                    if (nacionalidad.All(char.IsLetter))
                    {
                        return "1";
                    }
                    else
                    {
                        return "El campo Apellidos solo permite letras";
                    }
                }
                else
                {
                    return "El campo Nombre solo permite letras";
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string ValidarNumero(string Identificacion)
        {
            try
            {
                Identificacion = Identificacion.Replace(" ", String.Empty);
                if (Identificacion.All(char.IsDigit))
                {
                    return "1";
                }
                else
                {
                    return "El campo identificacion solo permite numeros";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ValidarNulosIndex(string Identificacion, string Contrasena)
        {
            try
            {
                if (Identificacion.Length != 0)
                {

                    if (Contrasena.Length != 0)
                    {
                        return "1";
                    }
                    else
                    {
                        return "El campo de Contraseña es Obligatorio";
                    }
                }
                else
                {
                    return "El campo de Identificacion es Obligatorio";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ModificarRolUsuario(Usuarios u)
        {
            try
            {
                string url = "https://tiusr3pl.cuc-carrera-ti.ac.cr/ProyectoPPII/api/Usuarios/" + u.Identificacion; 
                string Json = u.ToJsonString(); using (var solicitud = new HttpClient())
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
                    if (message.StatusCode == System.Net.HttpStatusCode.NoContent)
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

        public string ModificarUsuario(string identificacion,string pass,int tipoRol,string NombreCompleto, string Nacionalidad,string Telefono,string CorreoElectronico,string Direccion)
        {
            try
            {
                string resultado;
              resultado =  usuario.ModificarUsuarios(identificacion, pass, tipoRol,NombreCompleto, Nacionalidad, Telefono, CorreoElectronico, Direccion);
                
                return resultado;
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }

        public string ModificarUsuario1(string identificacion, string nombre, string nacionalidad, string telefono, string Correo, string direccion, string pass, int tiporol)
        {
            try
            {



                Usuarios p = new Usuarios()
                {
                    Identificacion = identificacion,
                    NombreCompleto = nombre,
                    Nacionalidad = nacionalidad,
                    Telefono = telefono,
                    CorreoElectronico = Correo,
                    Direccion = direccion,
                    Pass = pass,
                    TipoRol = Convert.ToInt32(tiporol)



                };



                string Json = p.ToJsonString();




                string url = SERVICE_URL2 + "/" + identificacion;
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
                    else if (message.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        return "Los datos ingresados son incorrectos.";
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

        public string Borrarusuario(string identificacion)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.DeleteAsync(
                        SERVICE_URL2 + "/" + identificacion);



                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "El usuario no se encuentra registrado";
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
