using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models.Tipo
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Tipo(int Id = 0, string Descricao = "")
        {
            this.Id = Id;
            this.Descricao = Descricao;
        }

        public void LimparAtributos()
        {

            this.Id = 0;
            this.Descricao = string.Empty;
        }
    }
}