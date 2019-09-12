using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.Mensageria.Core.Interfaces
{
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// Registrar serviços e interface
        /// </summary>
        /// <param name="builder">Container builder</param>
        void Register(ContainerBuilder builder);

    }
}
