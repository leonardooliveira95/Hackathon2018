using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.AcessoDados
{
    public class Parametro
    {
        public object Parameter { get; set; }
        public object Valor { get; set; }

        public Parametro(object Parametro, object Valor)
        {
            this.Parameter = Parametro;
            this.Valor = Valor;
        }
    }
}