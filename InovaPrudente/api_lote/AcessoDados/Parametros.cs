using apiInovaPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.AcessoDados
{
    public class Parametros
    {
      
        public List<Parametro> Params { get; set; }
        public Parametros()
        {
            Params = new List<Parametro>();    
        }
       
        public void Add(object _Parametro, object _Valor)
        {
            Params.Add(new Parametro(_Parametro,_Valor));
        }

        public int Count()
        {
            return Params.Count;
        }

        public void Clear()
        {
            Params.Clear();
        }


    }
}