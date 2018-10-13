using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models.Entrega
{
    public class Historico
    {
        public int Id_Historico { get; set; }
        public int IdEntrega { get; set; }
        public DateTime Data_Historico { get; set; }
        public String Mensagem { get; set; }
        public Historico()
        {
            LimparAtributos();
        }

        public void LimparAtributos()
        {
            Id_Historico = 0;
            Data_Historico = DateTime.Now;
            Mensagem = string.Empty;
            IdEntrega = 0;
        }
    }
}