using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Bot.Connector;

namespace Bot_App
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            string chatFlow = activity.Code != null ? activity.Code : "";
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                // calculate something for us to return
                int length = (activity.Text ?? string.Empty).Length;
                Activity reply = activity.CreateReply("");

                // return our reply to the user
                if (chatFlow == "")
                {
                    switch (activity.Text.ToLower())
                    {
                        case "oi":
                        case "olá":
                            reply = activity.CreateReply($"{activity.Text} amigo, Como posso te ajudar ?");
                            break;
                        case "como você está":
                            reply = activity.CreateReply($"Tudo bem, e você ?");
                            break;
                        case "Onde você está ?":
                            reply = activity.CreateReply($"Presidente Prudente, e você ?");
                            break;
                        case "tchau":
                            reply = activity.CreateReply($"Tchau, obrigado !!");
                            break;
                        case "confirmar entrega":
                            //comunicar com ws da transportadora para confirmar a data de entrega
                            reply = activity.CreateReply($"Deseja confirmar entrega para o dia " + DateTime.Now.ToShortDateString() + " entre 08:00 e 18:00 horas ?");
                            chatFlow = "confirmar entrega";
                            break;
                        case "alterar data entrega":
                            //comunicar com ws da transportadora para alterar a data de entrega
                            reply = activity.CreateReply($"Altera data de entrega para qual dia ? Digite uma data no formato dd/mm/aaaa ");
                            chatFlow = "alterar data entrega";
                            break;
                        case "alterar local entrega":
                            //abrir mapa para escolher o local
                            reply = activity.CreateReply($"Selecione o novo local de entrega no mapa ");
                            chatFlow = "alterar local entrega";
                            break;
                        case "rastrear entrega":
                            //comunicar com ws da transportadora para rastrear
                            reply = activity.CreateReply($"Clique no link para rastrear sua entrega. http://www.ssw.inf.br/2/rastreamento_dest_pf ");
                            chatFlow = "rastrear entrega";
                            break;
                        default:
                            reply = activity.CreateReply($"Este é um chat automatizado, digite uma das opções: Confirmar entrega, Alterar data entrega, Alterar local entrega ou Rastrear entrega");
                            break;
                    }
                }
                else
                {
                    switch(chatFlow)
                    {
                        case "confirmar entrega":
                            if (activity.Text.Contains("sim"))
                            {
                                //comunicar com ws da transportadora para confirmar a data de entrega
                                reply = activity.CreateReply($" Entrega confirmada para a data selecionada. Deseja mais alguma informação? ");
                                chatFlow = "";
                            }
                            break;

                        case "alterar data entrega":

                            if (activity.Text.Contains("//"))
                            {
                                try
                                {
                                    DateTime data = DateTime.Parse(activity.Text);
                                    //comunicar com ws da transportadora para alterar a data de entrega
                                    reply = activity.CreateReply($" Entrega alterada para a data selecionada. Deseja mais alguma informação? ");
                                    chatFlow = "";
                                }
                                catch (Exception excErro)
                                {
                                    reply = activity.CreateReply($"Digite uma data no formato dd/mm/aaaa ");
                                    chatFlow = "alterar data entrega";
                                }
                            }
                            break;

                        case "alterar local entrega":
                            //validar se o endereco enviado é válido
                            //comunicar com ws da transportadora para calcular o custo da alteracao
                            reply = activity.CreateReply($"A alteração de endereço gerará um custo de R$ 12,00, deseja confirmar? ");
                            chatFlow = "confirmar alteracao endereco com custo";
                            break;

                        case "confirmar alteracao endereco com custo":
                            //comunicar com ws da transportadora para alterar o endereco e gerar um novo custo na entrega
                            if (activity.Text.Contains("sim"))
                            {
                                reply = activity.CreateReply($"Endereço alterado com sucesso. Deseja mais alguma informação? ");
                                chatFlow = "";
                            }
                            break;
                    }
                }

                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                HandleSystemMessage(activity);
            }

            //Retorno ret = new Retorno(1, chatFlow);
            var response = Request.CreateResponse(HttpStatusCode.OK, chatFlow);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
                IConversationUpdateActivity update = message;
                var client = new ConnectorClient(new Uri(message.ServiceUrl), new MicrosoftAppCredentials());
                if (update.MembersAdded != null && update.MembersAdded.Any())
                {
                    foreach (var newMember in update.MembersAdded)
                    {
                        if (newMember.Id != message.Recipient.Id)
                        {
                            var reply = message.CreateReply();
                            //reply.Text = $"Bem vindo {newMember.Name}!";
                            reply.Text = $"Bem vindo Carlos!";
                            client.Conversations.ReplyToActivityAsync(reply);
                        }
                    }
                }
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }

}