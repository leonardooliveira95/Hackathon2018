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
        public string CodigoRastreio { get; set; }
        public string Status { get; set; }
        public List<Historico> Historico { get; set; }
        public Pessoa Pessoa { get; set; }
        public string Logradouro { get; set; }
        public List<EntregaDespesa> Despesas { get; set; }

        public Entrega(int Id_Entrega, string Descricao , string Nome_Cliente,
            int IdEndereco, DateTime DataPrevista, int IdTipoEntrega,
            int IdEmpresa, string CodigoRastreio, string Status, List<Historico> Historico,
            Pessoa pessoa, string Logradouro, List<EntregaDespesa> Despesas)
        {
            this.Id_Entrega = Id_Entrega;
            this.Descricao = Descricao;
            this.Nome_Cliente = Nome_Cliente;
            this.IdEndereco = IdEndereco;
            this.DataPrevista = DataPrevista;
            this.IdTipoEntrega = IdTipoEntrega;
            this.IdEmpresa = IdEmpresa;
            this.CodigoRastreio = CodigoRastreio;
            this.Status = Status;
            if (Historico == null)
            {
                this.Historico = new List<Models.Entrega.Historico>();
            }
            else
            {
                this.Historico = Historico;
            }
            this.Pessoa = pessoa;
            this.Logradouro = Logradouro;
            if (Despesas == null)
            {
                this.Despesas = new List<EntregaDespesa>();
            }
            else
            {
                this.Despesas = Despesas;
            }


        }

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
            Status  = string.Empty;
            CodigoRastreio = string.Empty;
            Historico = new List<Models.Entrega.Historico>();
            Despesas = new List<EntregaDespesa>();

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}