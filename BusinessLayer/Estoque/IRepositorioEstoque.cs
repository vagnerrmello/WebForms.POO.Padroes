//-----------------------------------------------------------------------
// <copyright file="IRepositorioEstoque.cs" company="Vikn">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Estoque
{
    using Steto.ValueObjectLayer;
    using System.Collections.Generic;

    /// <summary>
    ///  Interface padrão para o repositório Estoque
    /// </summary>
    public interface IRepositorioEstoque
    {
        /// <summary>
        /// Interface que Insere um Produto no Estoque
        /// </summary>
        /// <param name="estoque">Objeto Estoque</param>
        /// <returns>Retorna o Id do Estoque</returns>
        int InserirEstoque(Estoque estoque);

        /// <summary>
        /// Interface que recupera um objeto Estoque 
        /// </summary>
        /// <param name="estoque">Parametro para recuperar Estoque</param>
        /// <returns>Retorna um objeto Estoque</returns>
        Estoque RecuperarProdutoNoEstoque(Estoque estoque);

        /// <summary>
        /// Interface que recupera uma Lista de Produtos no Estoque Relacionadas a Nota
        /// </summary>
        /// <param name="ProdutoNota">Parametro para recuperar Produto(s) vinculado(s) a Nota Existentes no Estoque</param>
        /// <returns>Retorna uma lista de Produtos Existentes no Estoque vinculadas a Nota</returns>
        IList<Produto> RecuperaUmaListaDeProdutosNoEstoqueRelacionadasANota(ProdutoNota ProdutoNota);

        /// <summary>
        /// Interface que recupera uma Lista de Produtos no Estoque Relacionadas a Empresa
        /// </summary>
        /// <param name="Produto">Parametro para recuperar Produto(s) vinculado(s) a Empresa</param>
        /// <returns>Retorna uma lista de Produtos Existentes no Estoque vinculadas a Empresa</returns>
        IList<Produto> RecuperaUmaListaDeProdutosNoEstoquePorEmpresa(Produto Produto);

        /// <summary>
        /// Interface que altera a quantidade do produto no estoque 
        /// </summary>
        /// <param name="estoque">Objeto Estoque com a quantidade a ser alterada</param>
        /// <returns>True se ocorrer tudo ok</returns>
        bool AlteraQuantidadeDoProdutoNoEstoque(Estoque estoque);

        /// <summary>
        /// Interface que deleta um produto em estoque
        /// </summary>
        /// <param name="estoque">Objeto Estoque com Id da Empresa e do Produto preenchidos para deleção</param>
        /// <returns>Retorna True se sucesso na deleção</returns>
        bool ExcluiProdutoNoEstoque(Estoque estoque);
    }
}
