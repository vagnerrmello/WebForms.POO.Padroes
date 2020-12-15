//-----------------------------------------------------------------------
// <copyright file="IRepositorioSolicitacao.cs" company="Vikn">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Estoque
{
    using System.Collections.Generic;
    using Steto.ValueObjectLayer;

    /// <summary>
    ///  Interface padrão para o repositório Solicitacao
    /// </summary>
    public interface IRepositorioSolicitacao
    {
        /// <summary>
        /// Interface que Insere uma nova Solicitacao
        /// </summary>
        /// <param name="solicitacao">Objeto Solicitacao</param>
        /// <returns>Retorna o Id da Solicitacao</returns>
        int CriarSolicitacao(Solicitacao solicitacao);

        /// <summary>
        /// Interface que altera uma Solicitação 
        /// </summary>
        /// <param name="solicitacao">Objeto Solicitação</param>
        /// <returns>True se ocorrer tudo ok</returns>
        bool AlteraSolicitacao(Solicitacao solicitacao);

        /// <summary>
        /// Interface que Insere uma nova Solicitacao em Estoque
        /// </summary>
        /// <param name="solicitacao">Objeto Solicitacao</param>
        /// <returns>Retorna o Id da Solicitacao em Estoque</returns>
        int CriarSolicitacaoEstoque(Solicitacao solicitacao);

        /// <summary>
        /// Interface que Insere uma nova Solicitacao em Estoque
        /// </summary>
        /// <param name="solicitacao">Objeto Solicitacao</param>
        /// <returns>Retorna o Id da Solicitacao em Estoque</returns>
        int CriarSolicitacaoAnalise(Solicitacao solicitacao);

        /// <summary>
        /// Interface que recupera uma lista de Solicitações 
        /// </summary>
        /// <param name="solicitacao">Parametro para recuperar uma lista de solicitações. Obrigatório passa a empresa</param>
        /// <returns>Retorna uma lista de solicitações</returns>
        IList<Solicitacao> RecuperarListaDeSolicitacoes(Solicitacao solicitacao);

        /// <summary>
        /// Interface que recupera uma lista de Solicitações Para Análise
        /// </summary>
        /// <param name="solicitacao">Parametro para recuperar várias solicitações</param>
        /// <returns>Retorna uma lista de solicitações</returns>
        IList<Solicitacao> RecuperarSolicitacaoAnalise(Solicitacao solicitacao);

    }
}
