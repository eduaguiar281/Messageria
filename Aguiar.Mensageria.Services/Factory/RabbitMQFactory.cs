using Aguiar.Mensageria.Core.Interfaces;
using Aguiar.Mensageria.Services.Exceptions;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Aguiar.Mensageria.Services.Factory
{
    internal class RabbitMQFactory
    {
        public static IModel CreateRabbitModel(IMessageServiceConfiguration configuration)
        {
            int contador = 0;
            Exception lastException;
            do
            {
                var factory = new ConnectionFactory()
                {
                    HostName = configuration.HostName,
                    Port = configuration.Port,
                    UserName = configuration.UserName,
                    Password = configuration.Password
                };

                try
                {
                    var conn = factory.CreateConnection();
                    var model = conn.CreateModel();
                    return conn.CreateModel();
                    //TODO:Logger
                }
                catch (BrokerUnreachableException e)
                {
                    lastException = e;
                    contador++;
                    Thread.Sleep(1000);
                    //TODO:Logger
                }
                catch (Exception ex)
                {
                    lastException = ex;
                    contador++;
                    Thread.Sleep(1000);
                    //TODO:Logger
                }

            }
            while (contador <= 10);
            //TODO:Logger
            throw new ServiceException("Não foi possível conectar ao servidor RabbitMq após 10 tentativas", lastException);
        }
    }
}
