using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models.Entrega
{
    public class Entrega
    {
        public int Id_Entrega { get; set; }
        public string Descricao { get; set; }
        public string Nome_Cliente { get; set; }
        public int IdEndereco { get; set; }
        public DateTime DataPrevista { get; set; }
        public int IdTipoEntrega { get; set; }
        public int IdEmpresa { get; set; }
        public int Status { get; set; }

        public Entrega()
        {
            LimparAtributos();

        }

        private void LimparAtributos()
        {
            Id_Entrega = 0;
            Descricao = string.Empty;
            Nome_Cliente = string.Empty;
            IdEndereco = 0;
            DataPrevista = DateTime.MinValue;
            IdTipoEntrega = 0;
            IdEmpresa = 0;
            Status = 0;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}