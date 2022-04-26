using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos.Modelos
{
    public class ModelLogin
    {
        public string identificacion { get; set; }

        public string contrasenna { get; set; }


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
