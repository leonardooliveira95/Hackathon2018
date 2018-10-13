using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models.Entrega
{
    public class EntregaDespesa
    {
        public int Id_Edespesa { get; set; }
        public int Id_Depesa { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data_Despesa { get; set; }
        public int Status { get; set; }

        public EntregaDespesa()
        {
            LimparAtributos();   
        }

        public void LimparAtributos()
        {
            Id_Depesa = 0;
            Id_Edespesa = 0;
            Valor = 0;
            Data_Despesa = DateTime.Now;
            Status = 0;
        }

    }
}