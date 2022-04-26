using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Modelos
{
    public class ModelUsuario
    {

        public string identificacion { get; set; }

        public string NombreCompleto { get; set; }

        public string  Nacionalidad { get; set; }

        public string Telefono { get; set; }

        public string CorreoElectronico { get; set; }

        public string Dirrecion { get; set; }

        public string pass { get; set; }

        public string TipoRol { get; set; }


        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        public override string ToString()
        {
            return ToJsonString();
        }
    }
}
