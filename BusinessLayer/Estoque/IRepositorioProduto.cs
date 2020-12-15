//-----------------------------------------------------------------------
// <copyright file="IRepositorioProduto.cs" company="Vikn">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Estoque
{
    using System.Collections.Generic;
    using Steto.ValueObjectLayer;

    /// <summary>
    ///  Interface padrão para o repositório Produto
    /// </summary>
    public interface IRepositorioProduto
    {
        /// <summary>
        /// Interface responsável por Inserir um novo Produto no Estoque
        /// </summary>
        /// <param name="produto">Objeto Produto</param>
        /// <returns>Retorna o Id do Produto inserido</returns>
        int CriarProduto(Produto produto);

        /// <summary>
        /// Interface que altera o produto 
        /// </summary>
        /// <param name="produto">Objeto Produto</param>
        /// <returns>True se ocorrer tudo ok</returns>
        bool AlteraProduto(Produto produto);

        /// <summary>
        /// Interface que recupera uma lista de objetos Produtos com base em pesquisa
        /// </summary>
        /// <param name="produto">Parametro para recuperar produto</param>
        /// <returns>Retorna uma lista de objetos Produto</returns>
        IList<Produto> RecuperarProduto(Produto produto);

        /// <summary>
        /// Interface que recupera um objeto Produto por seu Id
        /// </summary>
        /// <param name="produto">Parametro para recuperar produto com Id preenchido</param>
        /// <returns>Retorna objeto Produto</returns>
        Produto RecuperarUmProduto(Produto produto);

        /// <summary>
        /// Interface que altera o produto 
        /// </summary>
        /// <param name="produto">Objeto Produto</param>
        /// <returns>True se ocorrer tudo ok</returns>
        bool AlteraQuantidadeProduto(Produto produto);

        /// <summary>
        /// Interface que Desativa um produto no sistema
        /// </summary>
        /// <param name="id">Parametro com o id do produto</param>
        /// <returns>Retorna True se ok</returns>
        bool DesativarProduto(Produto produto);

        /// <summary>
        /// Interface que Cria uma nova Movimentação de um Produto
        /// </summary>
        /// <param name="movimentacao">Objeto MovimentacaoEstoque com os Ids de Empresa, Fornecedor, Produto assim como Quantidade, Valor, Data e Status </param>
        /// <returns>Retorna o Id da movimentação</returns>
        int CriarMovimentacaoProduto(MovimentacaoEstoque movimentacao);

        /// <summary>
        /// Interface que Insere um novo Produto relacionado a uma conta
        /// </summary>
        /// <param name="conta">Objeto Conta</param>
        /// <returns>Retorna o Id </returns>

    }
}
