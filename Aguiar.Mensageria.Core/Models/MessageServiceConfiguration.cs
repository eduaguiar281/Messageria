using Aguiar.Mensageria.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.Mensageria.Core.Models
{
    public class MessageServiceConfiguration : IMessageServiceConfiguration
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ServiceId { get; set; }
        public string QueueGroupName { get; set; }
    }
}
