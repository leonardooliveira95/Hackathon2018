using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoDeRecebimentoDeEntregas.RabbitMQ
{
    public class Configuracoes
    {
        public Configuracoes()
        {

        }

        public string Host { get; set; }
        public string Fila { get; set; }
        public string DataBase { get; set; }
        public string DbServer { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }

        public override string ToString()
        {
            return "Host Mensageria: " + Host + " Port: " + this.Port.ToString() + " Fila: " + Fila + " DataBase: " + DataBase + " DbServer: " + DbServer;
        }
        public Configuracoes Clone()
        {
            return (Configuracoes)this.MemberwiseClone();
        }
    }
}
