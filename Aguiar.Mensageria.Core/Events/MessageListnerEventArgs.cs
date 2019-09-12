using Aguiar.Mensageria.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.Mensageria.Core.Events
{
    public class MessageListnerEventArgs: EventArgs
    {

        public MessageListnerEventArgs(MessageContent content)
        {
            MessageContent = content;
        }

        public MessageContent MessageContent { get; set; }
    }
}
