//-----------------------------------------------------------------------
// <copyright file="EstoqueFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer.Estoque
{
    using BusinessLayer.Estoque;
    using System.Collections.Generic;
    using ValueObjectLayer;

    /// <summary>
    /// Fachada padrão para o objeto EstoqueFacade
    /// </summary>
    public class EstoqueFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = "SqlServer";//System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Variável para acesso ao repositório Estoque 
        /// </summary>
        public static IRepositorioEstoque repositorioEstoque = new RepositorioEstoque();

        /// <summary>
        /// Facade que Insere um Produto no Estoque
        /// </summary>
        /// <param name="estoque">Objeto Estoque</param>
        /// <returns>Retorna o Id do Estoque</returns>
        public static int InserirEstoque(Estoque estoque)
        {
            return repositorioEstoque.InserirEstoque(estoque);
        }

        /// <summary>
        /// Facade que recupera um objeto Estoque 
        /// </summary>
        /// <param name="estoque">Parametro para recuperar Estoque</param>
        /// <returns>Retorna um objeto Estoque</returns>
        public static Estoque RecuperarProdutoNoEstoque(Estoque estoque)
        {
            return repositorioEstoque.RecuperarProdutoNoEstoque(estoque);
        }

        /// <summary>
        /// Facade que recupera uma Lista de Produtos no Estoque Relacionadas a Nota
        /// </summary>
        /// <param name="ProdutoNota">Parametro para recuperar Produto(s) vinculado(s) a Nota Existentes no Estoque</param>
        /// <returns>Retorna uma lista de Produtos Existentes no Estoque vinculadas a Nota</returns>
        public static IList<Produto> RecuperaUmaListaDeProdutosNoEstoqueRelacionadasANota(ProdutoNota ProdutoNota)
        {
            return repositorioEstoque.RecuperaUmaListaDeProdutosNoEstoqueRelacionadasANota(ProdutoNota);
        }

        /// <summary>
        /// Método que recupera uma Lista de Produtos no Estoque Relacionadas a Empresa
        /// </summary>
        /// <param name="Produto">Parametro para recuperar Produto(s) vinculado(s) a Empresa</param>
        /// <returns>Retorna uma lista de Produtos Existentes no Estoque vinculadas a Empresa</returns>
        public static IList<Produto> RecuperaUmaListaDeProdutosNoEstoquePorEmpresa(Produto Produto)
        {
            return repositorioEstoque.RecuperaUmaListaDeProdutosNoEstoquePorEmpresa(Produto);
        }

        /// <summary>
        /// Facade que altera a quantidade do produto no estoque 
        /// </summary>
        /// <param name="estoque">Objeto Estoque com a quantidade a ser alterada</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public static bool AlteraQuantidadeDoProdutoNoEstoque(Estoque estoque)
        {
            return repositorioEstoque.AlteraQuantidadeDoProdutoNoEstoque(estoque);
        }

        /// <summary>
        /// Facade que deleta um produto em estoque
        /// </summary>
        /// <param name="estoque">Objeto Estoque com Id da Empresa e do Produto preenchidos para deleção</param>
        /// <returns>Retorna True se sucesso na deleção</returns>
        public static bool ExcluiProdutoNoEstoque(Estoque estoque)
        {
            return repositorioEstoque.ExcluiProdutoNoEstoque(estoque);
        }
    }
}
