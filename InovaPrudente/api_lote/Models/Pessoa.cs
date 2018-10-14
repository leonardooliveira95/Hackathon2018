using apiInovaPP.AcessoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace apiInovaPP.Models
{
    public class Pessoa
    {
        
        public int id { get; set; }        
        public string nome { get; set;}
        public string cpf { get; set; }        
        public int tipo { get; set; }
        public string endereco { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string numero { get; set; }        
        public string foneCel{ get; set; }        
        public int cidadeId { get; set; }     
        public List<PessoaEndereco>  Enderecos { get; set; }

        public Pessoa(int Id,  string Nome, string CpfCnpj, 
                        int Tipo_pessoa, string Endereco, string Complemento, string Bairro, string Cep,
                            string TelMovel,int Id_cidade, List<PessoaEndereco> Enderecos)
        {
            this.id = Id;
            this.nome = Nome;
            this.cpf = CpfCnpj;            
            this.tipo = Tipo_pessoa;
            this.endereco = Endereco;
            this.complemento = Complemento;
            this.bairro = Bairro;
            this.cep = Cep;            
            this.foneCel = TelMovel;            
            this.cidadeId = Id_cidade;
            this.Enderecos = Enderecos;

        }
        public Pessoa()
        {
                
        }
       

        public void LimparAtributos()
        {
            this.id = 0;
            
            this.nome = string.Empty;
            this.cpf = string.Empty;;
            this.tipo = 0;
            this.endereco = string.Empty;
            this.complemento = string.Empty;
            this.bairro = string.Empty;
            this.cep = string.Empty;
            this.numero = string.Empty;
            this.foneCel = string.Empty;
            this.Enderecos = new List<PessoaEndereco>();

        }

        

    }
}