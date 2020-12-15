//-----------------------------------------------------------------------
// <copyright file="ProdutoFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer.Estoque
{
    using BusinessLayer.Estoque;
    using System.Collections.Generic;
    using ValueObjectLayer;

    /// <summary>
    /// Fachada padrão para o objeto ProdutoFacade
    /// </summary>
    public class ProdutoFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = "SqlServer";//System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Variável para acesso ao repositório de Perfil de usuário
        /// </summary>
        public static IRepositorioProduto  repositorioProduto = new RepositorioProduto();

        /// <summary>
        /// Facade que Insere um novo Produto no Estoque
        /// </summary>
        /// <param name="produto">Objeto Produto</param>
        /// <returns>Retorna o Id do Produto</returns>
        public static int CriarProduto(Produto produto)
        {
             return repositorioProduto.CriarProduto(produto);
        }

        /// <summary>
        /// Facade que altera o produto 
        /// </summary>
        /// <param name="produto">Objeto Produto</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public static bool AlteraProduto(Produto produto)
        {
            return repositorioProduto.AlteraProduto(produto);
        }

        /// <summary>
        /// Facade que recupera uma lista de objetos Produtos com base em pesquisa
        /// </summary>
        /// <param name="produto">Parametro para recuperar produto</param>
        /// <returns>Retorna uma lista de objetos Produto</returns>
        public static IList<Produto> RecuperarProduto(Produto produto)
        {
            return repositorioProduto.RecuperarProduto(produto);
        }

        /// <summary>
        /// Facade que recupera um objeto Produto por seu Id
        /// </summary>
        /// <param name="produto">Parametro para recuperação com o Id de produto e Empresa preenchidos</param>
        /// <returns>Retorna objeto Produto</returns>
        public static Produto RecuperarUmProduto(Produto produto)
        {
            return repositorioProduto.RecuperarUmProduto(produto);
        }

        /// <summary>
        /// Facade que altera o produto 
        /// </summary>
        /// <param name="produto">Objeto Produto</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public static bool AlteraQuantidadeProduto(Produto produto)
        {
            return repositorioProduto.AlteraQuantidadeProduto(produto);
        }

        /// <summary>
        /// Facade que Desativa um produto no sistema
        /// </summary>
        /// <param name="id">Parametro com o id do produto</param>
        /// <returns>Retorna True se ok</returns>
        public static bool DesativarProduto(Produto produto)
        {
            return repositorioProduto.DesativarProduto(produto);
        }

        /// <summary>
        /// Facade que Cria uma nova Movimentação de um Produto
        /// </summary>
        /// <param name="movimentacao">Objeto MovimentacaoEstoque com os Ids de Empresa, Fornecedor, Produto assim como Quantidade, Valor, Data e Status </param>
        /// <returns>Retorna o Id da movimentação</returns>
        public static int CriarMovimentacaoProduto(MovimentacaoEstoque movimentacao)
        {
            return repositorioProduto.CriarMovimentacaoProduto(movimentacao);
        }

    }
}
