using Aguiar.Mensageria.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.Mensageria.Core.Events
{
    public enum StatusMessage { Accepted, Rejected };
    public class MessageListnerEventArgs: EventArgs
    {
        public MessageListnerEventArgs(string content)
        {
            Content = content;

            TryConvertContent();
                        
        }

        private void TryConvertContent()
        {
            try
            {
                MessageContent = JsonConvert.DeserializeObject<MessageContent>(Content);
                StatusMessage = StatusMessage.Accepted;
            }
            catch (Exception ex)
            {
                //TODO: Logger
                StatusMessage = StatusMessage.Rejected;
            }

        }

        public MessageContent MessageContent { get; set; }

        public StatusMessage StatusMessage { get; private set; }

        public string Content { get; private set; }
    }
}
