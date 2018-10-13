using apiInovaPP.AcessoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace apiInovaPP.Models
{

    public class TipoPessoa
    {
        public int Id { get; set; }
        public String Descricao { get; set; }
        public bool Situacao { get; set; }

        public TipoPessoa()
        {
            LimparAtributos();
        }
        public TipoPessoa(int _Id,String _Descricao)
        {
            this.Id = _Id;
            this.Descricao = _Descricao;
            this.Situacao = false;
        }
        
        public void LimparAtributos()
        {
            Id = 0;
            Descricao = String.Empty;
        }


        
    }
}