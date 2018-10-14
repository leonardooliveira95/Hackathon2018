using ServicoDeRecebimentoDeEntregas.RabbitMQ;
using System;
using System.Configuration;
using System.ServiceProcess;

namespace ServicoDeRecebimentoDeEntregas
{
    public partial class Service1 : ServiceBase
    {
        Consumer consumer;
        Configuracoes config;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
#if DEBUG
            AoIniciar();
#endif
        }

        protected override void OnStop()
        {
        }

        public void AoIniciar()
        {
            try
            {
                LerConfiguracoes();
                Subscribe();
            }
            catch (Exception ex)
            {
                
            }

        }

        private void Subscribe()
        {
            try
            {
                consumer  = new Consumer(config, DataConsumer);
                consumer.Subscribe();
            }
            catch (Exception ex)
            {             
            }

        }

        public void DataConsumer(object mensagem)
        {
            Console.WriteLine(mensagem);
            //Chamar api para gravar
            
        }

        private void LerConfiguracoes()
        {      
            string host = ConfigurationManager.AppSettings["HOST"].ToString();
            string port = ConfigurationManager.AppSettings["PORT"].ToString();
            string queue = ConfigurationManager.AppSettings["QUEUE"].ToString();
            string user = ConfigurationManager.AppSettings["USER"].ToString();
            string password = ConfigurationManager.AppSettings["PASSWORD"].ToString();
            config = new Configuracoes()
            {
                Host = host,
                Port = Convert.ToInt32(port),
                Fila = queue,
                User = user,
                Password = password
            };

        }
    }
}
