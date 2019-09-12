using Aguiar.Mensageria.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.Mensageria.Core.Interfaces
{
    public interface IMessageListner
    {
        IMessageServiceConfiguration Configuration { get; set; }

        event EventHandler<MessageListnerEventArgs> Received;
    }
}
