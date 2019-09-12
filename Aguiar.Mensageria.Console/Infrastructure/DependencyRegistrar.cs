using Aguiar.Mensageria.Core.Interfaces;
using Aguiar.Mensageria.Core.Models;
using Aguiar.Mensageria.Services.CentralMessage;
using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aguiar.Mensageria.ConsoleApp.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        private static IConfiguration _configuration;

        public void Register(ContainerBuilder builder)
        {
            var cfgBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile($"appsettings.json");
            _configuration = cfgBuilder.Build();

            MessageServiceConfiguration msgConfig = new MessageServiceConfiguration();
            new ConfigureFromConfigurationOptions<MessageServiceConfiguration>(
               _configuration.GetSection("AguiarMessagesConfiguration"))
                   .Configure(msgConfig);
            builder.RegisterInstance(msgConfig).As<IMessageServiceConfiguration>().SingleInstance();

            builder.RegisterType<MessageListner>().As<IMessageListner>().InstancePerLifetimeScope();
            builder.RegisterType<MessageSender>().As<IMessageSender>().InstancePerLifetimeScope();
        }
    }
}
