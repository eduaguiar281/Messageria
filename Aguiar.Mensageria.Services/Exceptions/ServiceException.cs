using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.Mensageria.Services.Exceptions
{
    public class ServiceException: Exception
    {
        public ServiceException(string MessageError)
            :base(MessageError)
        {

        }
        public ServiceException(string MessageError, Exception innerException)
            : base(MessageError, innerException)
        {

        }
    }
}
