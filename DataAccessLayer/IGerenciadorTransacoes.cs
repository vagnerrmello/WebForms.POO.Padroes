using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Steto.ValueObjectLayer
{
    interface IGerenciadorTransacoes
    {
        /// <summary>
        /// Inicia uma transação
        /// </summary>
        void IniciarTransacao();

        /// <summary>
        /// Cancela a transação(rollback)
        /// </summary>
        void CancelarTransacao();

        /// <summary>
        /// Finaliza a transação(commit)
        /// </summary>
        void FinalizarTransacao();
    }
}
