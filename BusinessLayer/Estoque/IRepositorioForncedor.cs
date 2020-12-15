//-----------------------------------------------------------------------
// <copyright file="IRepositorioForncedor.cs" company="Vikn">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Estoque
{
    using System.Collections.Generic;
    using Steto.ValueObjectLayer;

    /// <summary>
    ///  Interface padrão para o repositório Forncedor
    /// </summary>
    public interface IRepositorioForncedor
    {
        /// <summary>
        /// Interface que Cria uma novo Fornecedor
        /// </summary>
        /// <param name="fornecedor">Objeto Fornecedor</param>
        /// <returns>Retorna o Id do Fornecedor criado</returns>
        int CriarFornecedor(Fornecedor fornecedor);

        /// <summary>
        /// Interface responsável para alterar Fornecedor 
        /// </summary>
        /// <param name="fornecedor">Fornecedor </param>
        /// <returns>true se ok</returns>
        bool AlterarFornecedor(Fornecedor fornecedor);

        /// <summary>
        /// Interface que recupera um objeto Fornecedor por Id
        /// </summary>
        /// <param name="fornecedor">Parametro para recuperar uma Fornecedor por seu id</param>
        /// <returns>Retorna um objeto Fornecedor</returns>
        Fornecedor RecuperarFornecedor(Fornecedor fornecedor);

        /// <summary>
        /// Interface que recupera uma lista de objetos Fornecedor
        /// </summary>
        /// <param name="fornecedor">Parametro para recuperar uma lista de Fornecedores por empresa</param>
        /// <returns>Retorna uma lista de objetos Fornecedor</returns>
        IList<Fornecedor> RecuperarFornecedores(Fornecedor fornecedor);

        /// <summary>
        /// Interface que deleta dados de objetos Fornecedor
        /// </summary>
        /// <param name="fornecedor">Objeto Fornecedor com Id preenchido para deleção</param>
        /// <returns>Retorna True se sucesso na deleção</returns>
        bool ExcluiFornecedor(Fornecedor fornecedor);
    }
}
