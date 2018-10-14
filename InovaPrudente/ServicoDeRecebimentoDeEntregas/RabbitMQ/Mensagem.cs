using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoDeRecebimentoDeEntregas.RabbitMQ
{
    public class Mensagem
    {
        public Entrega Entrega { get; set; } 
        
    }

    public class Entrega
    {
        public int Id_Entrega { get; set; }
        public string Nome_Cliente { get; set; }
        public int IdEndereco { get; set; }
        public DateTime DataPrevista { get; set; }
        public int IdTipoEntrega { get; set; }
        public int IdEmpresa { get; set; }
        public string CodigoRastreio { get; set; }
        public string Status { get; set; }
        public string Logradouro { get; set; }
    }
}
