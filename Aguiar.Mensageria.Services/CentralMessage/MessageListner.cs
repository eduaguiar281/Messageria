using Aguiar.Mensageria.Core.Events;
using Aguiar.Mensageria.Core.Interfaces;
using Aguiar.Mensageria.Services.Factory;
using Aguiar.Mensageria.Services.Infrastructure;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.Mensageria.Services.CentralMessage
{
    public class MessageListner : IMessageListner
    {
        private IModel model;

        public MessageListner (IMessageServiceConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            InitializeRabbitModel();
        }

        public IMessageServiceConfiguration Configuration { get; set; }

        public event EventHandler<MessageListnerEventArgs> Received;

        private void InitializeRabbitModel()
        {
            model = RabbitMQFactory.CreateRabbitModel(Configuration);
            model.QueueDeclare(queue: MensageriaServiceConsts._QUEUE_KEY,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
            var consumer = new EventingBasicConsumer(model);
            consumer.Received += Consumer_Received;
            model.BasicConsume(queue: MensageriaServiceConsts._QUEUE_KEY,                
                 consumer: consumer);


        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body);
            MessageListnerEventArgs args = new MessageListnerEventArgs(message);
            if (args.StatusMessage == StatusMessage.Accepted)
            {
                //TODO: Logger
                model.BasicAck(e.DeliveryTag, false);
            }
            else
            {
                //TODO: Logger
                model.BasicReject(e.DeliveryTag, false);
            }
            Received?.Invoke(this, args);
        }
    }
}
