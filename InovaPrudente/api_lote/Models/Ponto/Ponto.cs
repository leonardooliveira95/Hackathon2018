using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models.Ponto
{
    public class Ponto
    {
        public int IdPonto { get; set; }
        public int IdPessoa { get; set; }
        public int IdEndereco { get; set; }
        public List<PontoHorarioFuncionamento> HorarioFuncionamento{ get; set; }
        public DateTime DataConvenio { get; set; }
        public int IdTipoEncomenda { get; set; }
        public string NomeContato { get; set; }

        public Ponto()
        {
            LimparAtributos();
        }

        private void LimparAtributos()
        {
            IdPonto = 0;
            IdPessoa = 0;
            IdEndereco = 0;
            HorarioFuncionamento = new List<PontoHorarioFuncionamento>();
            DataConvenio = DateTime.MinValue;
            IdTipoEncomenda = 0;
            NomeContato = string.Empty;
        }
    }
}