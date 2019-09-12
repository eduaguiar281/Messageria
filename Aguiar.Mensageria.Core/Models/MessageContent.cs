using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.Mensageria.Core.Models
{
    public class MessageContent
    {
        public string IdService { get; set; }
        public string Message { get; set; }
        public DateTime Data { get; set; }
    }
}
