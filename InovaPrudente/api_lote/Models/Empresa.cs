using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models
{
    public class Empresa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cnpj { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public int cidadeId { get; set; }
        public string complemento { get; set; }
        public string telefone1 { get; set; }
        public string telefone2 { get; set; }        
        public DateTime DataCad { get; set; }
        public int usuarioId { get; set; }

        public Empresa(string Nome, DateTime DataCad, int Id, string Cnpj, string Endereco, string Bairro, string Cep, int CidadeId, string Complemento, string Telefone1, string Telefone2, int UsuarioId)
        {
            this.id = Id;
            this.nome = Nome;
            this.cnpj = Cnpj;
            this.endereco = Endereco;
            this.bairro = Bairro;
            this.cep = Cep;
            this.cidadeId = CidadeId;
            this.complemento = Complemento;
            this.telefone1 = Telefone1;
            this.telefone2 = Telefone2;
            this.DataCad = DataCad;
            this.usuarioId = UsuarioId;
        }
        public Empresa()
        {
                
        }
    }
}