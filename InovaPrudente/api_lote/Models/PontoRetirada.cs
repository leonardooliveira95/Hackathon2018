using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models
{
    public class PontoRetirada
    {
        public int IdPontoRetirada { get; set; }
        public string NomePonto { get; set; }
        public string EnderecoPonto { get; set; }
        public string TipoEncomenda { get; set; }
        public string NomeContato { get; set; }
        public DateTime DataConvenio { get; set; }
        
        public PontoRetirada()
        {

        }
        public PontoRetirada(int idPontoRetirada, string nomePonto, string enderecoPonto, string tipoEncomenda, string nomeContato, DateTime dataConvenio)
        {
            this.IdPontoRetirada = idPontoRetirada;
            this.NomePonto = nomePonto;
            this.EnderecoPonto = enderecoPonto;
            this.TipoEncomenda = tipoEncomenda;
            this.NomeContato = nomeContato;
            this.DataConvenio = dataConvenio;
        }
    }
}