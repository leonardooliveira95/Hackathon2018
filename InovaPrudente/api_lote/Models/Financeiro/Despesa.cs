using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models.Financeiro
{
    public class Despesa
    {
        public int Id_despesa { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public Despesa()
        {
            LimparAtributos();
        }
        public void LimparAtributos()
        {
            Id_despesa = 0;
            Descricao = string.Empty;
            Valor = 0;
        }

    }
}