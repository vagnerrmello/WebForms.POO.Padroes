using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Interface padrão para os gerenciadores de sessão
    /// </summary>
    public interface IGerenciadorSessao
    {
        /// <summary>
        /// Abre uma sessão
        /// </summary>
        /// <param name="login">Login do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <param name="modulo">Módulo do Stet</param>
        /// <returns>true se a sessão foi aberta,false caso contrário</returns>
        bool Abrir(string login, string senha, string modulo);

        /// <summary>
        /// Fecha a sessão
        /// </summary>
        void Fechar();

        /// <summary>
        /// Verifica se a sessão está aberta
        /// </summary>
        /// <returns>true se a sessão estiver aberta, false caso contrário</returns>
        bool IsOpened();
    }
}
