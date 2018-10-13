using apiInovaPP.AcessoDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace apiInovaPP.Models
{
    public class Cidade
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }

        public Cidade()
        {
            
        }
        public Cidade(int Id,string Cidade, string Uf)
        {
            this.id = Id;
            this.nome = Cidade;
            this.uf = Uf;

        }
            
        
    }
}