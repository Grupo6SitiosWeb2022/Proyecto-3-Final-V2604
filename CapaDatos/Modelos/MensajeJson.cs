using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Modelos
{
   public class MensajeJson
    {
        private String codigo;
        public String descripcion;
        private Object resultado;
        public MensajeJson()
        {

        }
        public MensajeJson(string codigo, Object resultado)
        {
            this.codigo = codigo;
            this.resultado = resultado;
        }
        public MensajeJson(string codigo, string descripcion, Object resultado)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.resultado = resultado;
        }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Object Resultado { get => resultado; set => resultado = value; }

    }
}
