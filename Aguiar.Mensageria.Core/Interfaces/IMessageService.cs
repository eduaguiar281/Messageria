using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.Mensageria.Core.Interfaces
{
    public interface IMessageService
    {
        IMessageListner Listner { get; set; }

        IMessageServiceConfiguration Configuration { get; set; }

        IMessageSender Sender { get; set; }

    }
}
