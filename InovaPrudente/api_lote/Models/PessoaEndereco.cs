using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models
{
    public class PessoaEndereco
    {
        public int IdEndereco { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public int Idcidade { get; set; }
        public string  NomeCidade { get; set; }
        public string  Estado { get; set; }
        public int IdPessoa { get; set; }
        public int IdEntrega { get; set; }
        public bool Atualizar { get; set; }
        public PessoaEndereco()
        {
            LimparAtributos();
        }
        
        public void LimparAtributos()
        {
            IdEndereco = 0;
            Endereco = string.Empty;
            Cep = string.Empty;
            Bairro = string.Empty;
            Complemento = string.Empty;
            Idcidade = 0;
            NomeCidade = string.Empty;
            Estado = string.Empty;
            IdPessoa = 0;
            IdEntrega = 0;
            Atualizar = false;
        }
        
    }
}