using Aguiar.Mensageria.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.Mensageria.Core.Interfaces
{
    public interface IMessageSender
    {
        IMessageServiceConfiguration Configuration { get; set; }

        void SendMessage(MessageContent content);

        int MensagensEnviadas { get; }
    }
}
