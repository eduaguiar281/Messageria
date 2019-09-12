using Aguiar.Mensageria.Core.Events;
using Aguiar.Mensageria.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.Mensageria.Services.CentralMessage
{
    public class MessageListner : IMessageListner
    {
        public MessageListner (IMessageServiceConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IMessageServiceConfiguration Configuration { get; set; }

        public event EventHandler<MessageListnerEventArgs> Received;
    }
}
