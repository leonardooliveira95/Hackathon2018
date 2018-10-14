using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models.Entrega
{
    public class EntregaDespesa
    {
        public int Id_Edespesa { get; set; }
        public int Id_Despesa { get; set; }
        public string Valor { get; set; }
        public int IdEntrega
        { get; set; }
        public DateTime Data_Despesa { get; set; }
        

        public EntregaDespesa()
        {
            LimparAtributos();   
        }

        public void LimparAtributos()
        {
            Id_Despesa = 0;
            Id_Edespesa = 0;
            Valor = "";
            Data_Despesa = DateTime.Now;
            
        }

    }
}