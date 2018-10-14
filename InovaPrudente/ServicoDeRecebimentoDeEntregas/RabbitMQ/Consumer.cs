using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoDeRecebimentoDeEntregas.RabbitMQ
{
    public class Consumer
    {
        ConnectionFactory connf;
        IConnection connection;
        IModel canal;
        AsyncEventingBasicConsumer asyncConsumer;
        EventingBasicConsumer basicConsumer;
        DataConsumer _DataConsumer;
        Configuracoes config;
        public Consumer(Configuracoes config, DataConsumer DataConsumer)
        {
            this._DataConsumer = DataConsumer;
            connf = new ConnectionFactory();
            connf.HostName = config.Host;
            connf.UserName = config.User;
            connf.Password = config.Password;
            connf.Port = config.Port;
            connf.AutomaticRecoveryEnabled = true;
            connf.NetworkRecoveryInterval = System.TimeSpan.FromMinutes(1);
            this.config = config;
        }

        public void Subscribe()
        {
            try
            {
                connection = connf.CreateConnection();

                canal = connection.CreateModel();

                canal.QueueDeclare(
                    queue: config.Fila
                    , durable: true
                    , exclusive: false
                    , autoDelete: false
                    , arguments: null
                    );

                basicConsumer = new EventingBasicConsumer(canal);
                basicConsumer.Received += (model, ea) =>
                {
                    var message = Encoding.UTF8.GetString(ea.Body);

                    //_DataConsumer(new Mensa(Encoding.UTF8.GetString(ea.Body)));
                    Mensagem mensagem = JsonConvert.DeserializeObject<Mensagem>(message);
                    _DataConsumer(mensagem);
                };

                canal.BasicConsume(config.Fila, true, basicConsumer);
                canal.CallbackException += canal_CallbackException;

            }
            catch (BrokerUnreachableException ex)
            {

            }
            catch
            {
                throw;
            }
        }

        void canal_CallbackException(object sender, CallbackExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
       
}
