//-----------------------------------------------------------------------
// <copyright file="ForncedorFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer.Estoque
{
    using BusinessLayer.Estoque;
    using System.Collections.Generic;
    using ValueObjectLayer;

    /// <summary>
    /// Fachada padrão para o objeto ForncedorFacade
    /// </summary>
    public class FornecedorFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = "SqlServer";//System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Variável para acesso ao repositório de Fornecedor
        /// </summary>
        public static IRepositorioForncedor repositorioFornecdedor = new RepositorioFornecedor();

        /// <summary>
        /// Facade que Cria uma novo Fornecedor 
        /// </summary>
        /// <param name="fornecedor">Objeto Fornecedor</param>
        /// <returns>Retorna o Id do Fornecedor criado</returns>
        public static int CriarFornecedor(Fornecedor fornecedor)
        {
            return repositorioFornecdedor.CriarFornecedor(fornecedor);
        }

        /// <summary>
        /// Facade responsável para alterar Fornecedor 
        /// </summary>
        /// <param name="fornecedor">Fornecedor </param>
        /// <returns>true se ok</returns>
        public static bool AlterarFornecedor(Fornecedor fornecedor)
        {
            return repositorioFornecdedor.AlterarFornecedor(fornecedor);
        }

        /// <summary>
        /// Facade que recupera um objeto Fornecedor por Id
        /// </summary>
        /// <param name="fornecedor">Parametro para recuperar uma Fornecedor por seu id</param>
        /// <returns>Retorna um objeto Fornecedor</returns>
        public static Fornecedor RecuperarFornecedor(Fornecedor fornecedor)
        {
            return repositorioFornecdedor.RecuperarFornecedor(fornecedor);
        }
        /// <summary>
        /// Facade que recupera uma lista de objetos Fornecedor
        /// </summary>
        /// <param name="fornecedor">Parametro para recuperar uma lista de Fornecedores por empresa</param>
        /// <returns>Retorna uma lista de objetos Fornecedor</returns>
        public static IList<Fornecedor> RecuperarFornecedores(Fornecedor fornecedor)
        {
            return repositorioFornecdedor.RecuperarFornecedores(fornecedor);
        }

        /// <summary>
        /// Facade que deleta dados de objetos Fornecedor
        /// </summary>
        /// <param name="fornecedor">Objeto Fornecedor com Id preenchido para deleção</param>
        /// <returns>Retorna True se sucesso na deleção</returns>
        public static bool ExcluiFornecedor(Fornecedor fornecedor)
        {
            return repositorioFornecdedor.ExcluiFornecedor(fornecedor);
        }
    }
}
