using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models.Financeiro
{
    public class CustoFrete
    {
        public int IdCusto { get; set; }
        public int Km { get; set; }
        public int IdCidade { get; set; }
        public int IdTipoEncomenda { get; set; }
        public decimal Custo { get; set; }

        public CustoFrete()
        {
            LimparAtributos();

        }

        private void LimparAtributos()
        {
            IdCusto = 0;
            Km = 0;
            IdCidade = 0;
            IdTipoEncomenda = 0;
            Custo = 0;
        }
    }
}