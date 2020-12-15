//-----------------------------------------------------------------------
// <copyright file="ContaFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer.Estoque
{
    using BusinessLayer.Estoque;
    using System.Collections.Generic;
    using ValueObjectLayer;

    /// <summary>
    /// Fachada padrão para o objeto ContaFacade
    /// </summary>
    public class ContaFacade
    {
        /// <summary>
        /// Variável para acesso ao repositório de Contas (Pagar/Receber)
        /// </summary>
        protected static IRepositorioConta  repositorioConta = new RepositorioConta();

        /// <summary>
        /// Facade que Insere uma conta (Pagar/Receber)
        /// </summary>
        /// <param name="conta">Objeto do tipo Conta</param>
        /// <returns>Retorna o Id da Conta Cadastrada</returns>

    }
}
