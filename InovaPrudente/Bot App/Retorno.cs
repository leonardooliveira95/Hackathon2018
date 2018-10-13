using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_App
{
    public class Retorno
    {
        public int id { get; set; }
        public string mensagem { get; set; }
        
        public Retorno()
        {

        }
        public Retorno(int Id, string Mensagem)
        {
            this.id = Id;
            this.mensagem = Mensagem;
        }
    }
}