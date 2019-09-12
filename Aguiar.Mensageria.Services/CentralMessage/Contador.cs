using System;
using System.Collections.Generic;
using System.Text;

namespace Aguiar.Mensageria.Services.CentralMessage
{
    internal class Contador
    {
        private int _valorAtual = 0;

        public int ValorAtual { get => _valorAtual; }

        public void Incrementar()
        {
            _valorAtual++;
        }
    }
}
