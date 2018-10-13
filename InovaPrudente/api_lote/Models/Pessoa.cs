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
        public DateTime Data_cad { get; set; }
        public string nome { get; set;}
        public string cpf { get; set; }
        public string  rg { get; set; }
        public int tipo { get; set; }
        public string endereco { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string numero { get; set; }
        public string foneRes { get; set; }
        public string foneCel{ get; set; }
        public string foneCom { get; set; }
        public int cidadeId { get; set; }
        public int usuarioId { get; set; }
        public string estadoCivil { get; set; }
        public string nomeConjugue { get; set; }
        

        public Pessoa(int Id, DateTime Data_cad, string Nome, string CpfCnpj, string RgIe,
                        int Tipo_pessoa, string Endereco, string Complemento, string Bairro, string Cep,
                            string TelResidencial, string TelMovel, string TelComercial,int Id_cidade, int id_usuario, string EstadoCivil, string NomeConjugue)
        {
            this.id = Id;
            this.Data_cad = Data_cad;
            this.nome = Nome;
            this.cpf = CpfCnpj;
            this.rg = RgIe;
            this.tipo = Tipo_pessoa;
            this.endereco = Endereco;
            this.complemento = Complemento;
            this.bairro = Bairro;
            this.cep = Cep;
      
            this.foneRes = TelResidencial;
            this.foneCel = TelMovel;
            this.foneCom = TelComercial;
            this.cidadeId = Id_cidade;
            this.usuarioId = id_usuario;
            this.estadoCivil = EstadoCivil;
            this.nomeConjugue = NomeConjugue;
        }
        public Pessoa()
        {
                
        }
       

        public void LimparAtributos()
        {
            this.id = 0;
            this.Data_cad = DateTime.Now;
            this.nome = string.Empty;
            this.cpf = string.Empty;;
            this.rg = string.Empty;
            this.tipo = 0;
            this.endereco = string.Empty;
            this.complemento = string.Empty;
            this.bairro = string.Empty;
            this.cep = string.Empty;
            this.numero = string.Empty;
            this.foneRes = string.Empty;
            this.foneCel = string.Empty;
            this.foneCom = string.Empty;
            this.usuarioId = 0;
            this.estadoCivil = string.Empty;
            this.nomeConjugue = string.Empty;
        }

        

    }
}