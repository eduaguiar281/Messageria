using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.Mensageria.Core.Interfaces
{
    public interface IMessageServiceConfiguration
    {
        string HostName { get; set; }
        int Port { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string ServiceId { get; set; }
    }
}
