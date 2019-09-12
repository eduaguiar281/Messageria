using Aguiar.Mensageria.Core.Interfaces;
using Aguiar.Mensageria.Core.Models;
using Aguiar.Mensageria.Services.Factory;
using Aguiar.Mensageria.Services.Infrastructure;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.Mensageria.Services.CentralMessage
{
    public class MessageSender : IMessageSender
    {
        private static Contador _CONTADOR = new Contador();

        public MessageSender(IMessageServiceConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IMessageServiceConfiguration Configuration { get; set; }

        public int MensagensEnviadas
        { 
            get
            {
                return _CONTADOR.ValorAtual;
            }
        }

        public void SendMessage(MessageContent content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            using (var model = RabbitMQFactory.CreateRabbitModel(Configuration))
            {
                model.QueueDeclare(queue: MensageriaServiceConsts._QUEUE_KEY,
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);
                string json = JsonConvert.SerializeObject(content);

                var body = Encoding.UTF8.GetBytes(json);
                model.BasicPublish(exchange: "",
                                   routingKey: MensageriaServiceConsts._QUEUE_KEY,
                                   basicProperties: null,
                                   body: body);
            }

        }
    }
}
