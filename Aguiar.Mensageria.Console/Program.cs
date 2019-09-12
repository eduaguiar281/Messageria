using Aguiar.Mensageria.ConsoleApp.Infrastructure;
using Aguiar.Mensageria.Core.Events;
using Aguiar.Mensageria.Core.Interfaces;
using Aguiar.Mensageria.Core.Models;
using Autofac;
using System;
using System.Timers;

namespace Aguiar.Mensageria.ConsoleApp
{
    class Program
    {
        private static IContainer _container;

        private static IMessageListner _listner;

        private static IMessageSender _sender;

        private static IMessageServiceConfiguration _config;

        private static Timer _timer;

        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            DependencyRegistrar registrar = new DependencyRegistrar();
            registrar.Register(containerBuilder);

            _container = containerBuilder.Build();

            _listner = _container.Resolve<IMessageListner>();
            _listner.Received += ListnerOnRecive;
            _sender = _container.Resolve<IMessageSender>();
            _config = _container.Resolve<IMessageServiceConfiguration>();


            _timer = new Timer(5000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();

            Console.WriteLine("Pressione 'q' para sair!");
            string input = string.Empty;
            do
            {
                input = Console.ReadLine();
            }
            while (input != "q");
        }

        private static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _sender.SendMessage(new MessageContent { Data = DateTime.Now, IdService = _config.ServiceId, Message = "Olá Mundo!" });
        }

        

        static void ListnerOnRecive (object sender, MessageListnerEventArgs args)
        {
            if (args.StatusMessage == StatusMessage.Rejected)
            {
                Console.WriteLine($"[{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] Mensagem recebida '{args.Content}' foi rejeitada! Origem desconhecida!");
                //TODO: Logger
            }
            else
            {
                var msg = args.MessageContent;
                Console.WriteLine($"Mensagem recebida [{msg.Data.ToString("dd/MM/yyyy hh:mm:ss")}] de {msg.IdService} Mensagem: {msg.Message}");
            }

        }
            

    }
}
