//-----------------------------------------------------------------------
// <copyright file="SolicitacaoFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer.Estoque
{
    using BusinessLayer.Estoque;
    using System.Collections.Generic;
    using ValueObjectLayer;

    /// <summary>
    /// Fachada padrão para o objeto SolicitacaoFacade
    /// </summary>
    public class SolicitacaoFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = "SqlServer";//System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Variável para acesso ao repositório de Solicitacao
        /// </summary>
        public static IRepositorioSolicitacao repositorioSolicitacao = new RepositorioSolicitacao();


        /// <summary>
        /// Facade que Insere uma nova Solicitacao
        /// </summary>
        /// <param name="solicitacao">Objeto Solicitacao</param>
        /// <returns>Retorna o Id da Solicitacao</returns>
        public static int CriarSolicitacao(Solicitacao solicitacao)
        {
            return repositorioSolicitacao.CriarSolicitacao(solicitacao);
        }

        /// <summary>
        /// Facade que altera uma Solicitação 
        /// </summary>
        /// <param name="solicitacao">Objeto Solicitação</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public static bool AlteraSolicitacao(Solicitacao solicitacao)
        {
            return repositorioSolicitacao.AlteraSolicitacao(solicitacao);
        }

        /// <summary>
        /// Facade que Insere uma nova Solicitacao em Estoque
        /// </summary>
        /// <param name="solicitacao">Objeto Solicitacao</param>
        /// <returns>Retorna o Id da Solicitacao em Estoque</returns>
        public static int CriarSolicitacaoEstoque(Solicitacao solicitacao)
        {
             return repositorioSolicitacao.CriarSolicitacaoEstoque(solicitacao);
        }

        /// <summary>
        /// Facade que Insere uma nova Solicitacao em Estoque
        /// </summary>
        /// <param name="solicitacao">Objeto Solicitacao</param>
        /// <returns>Retorna o Id da Solicitacao em Estoque</returns>
        public static int CriarSolicitacaoAnalise(Solicitacao solicitacao)
        {
            return repositorioSolicitacao.CriarSolicitacaoAnalise(solicitacao);
        }

        /// <summary>
        /// Facade que recupera uma lista de Solicitações Para Análise
        /// </summary>
        /// <param name="solicitacao">Parametro para recuperar várias solicitações</param>
        /// <returns>Retorna uma lista de solicitações</returns>
        public static IList<Solicitacao> RecuperarSolicitacaoAnalise(Solicitacao solicitacao)
        {
            return repositorioSolicitacao.RecuperarSolicitacaoAnalise(solicitacao);
        }

        /// <summary>
        /// Facade que recupera uma lista de Solicitações 
        /// </summary>
        /// <param name="solicitacao">Parametro para recuperar uma lista de solicitações. Obrigatório passa a empresa</param>
        /// <returns>Retorna uma lista de solicitações</returns>
        public static IList<Solicitacao> RecuperarListaDeSolicitacoes(Solicitacao solicitacao)
        {
            return repositorioSolicitacao.RecuperarListaDeSolicitacoes(solicitacao);
        }
    }
}
