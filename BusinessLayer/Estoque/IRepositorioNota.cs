//-----------------------------------------------------------------------
// <copyright file="IRepositorioNota.cs" company="Vikn">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Estoque
{
    using System.Collections.Generic;
    using Steto.ValueObjectLayer;

    /// <summary>
    ///  Interface padrão para o repositório Nota
    /// </summary>
    public interface IRepositorioNota
    {
        /// <summary>
        /// Interface ue Cria uma nova Nota
        /// </summary>
        /// <param name="nota">Objeto Nota</param>
        /// <returns>Retorna o Id da Nota</returns>
        int CriarNota(Nota nota);

        /// <summary>
        /// Interface responsável para Atualizar uma Nota
        /// </summary>
        /// <param name="Nota">Objeto com todas propriedades preenchidas</param>
        /// <returns>Retorna um booleano</returns>
        bool AtualizaNota(Nota Nota);

        /// <summary>
        /// Interface responsável para inserir o produto na Nota
        /// </summary>
        /// <param name="InserirProdutoNaNota">Objeto preenchido com o id da nota, id</param>
        /// <returns>Retorna o Id da Nota</returns>
        int InserirProdutoNaNota(ProdutoNota InserirProdutoNaNota);

        /// <summary>
        /// Interface responsável para Alterar um produto na Nota
        /// </summary>
        /// <param name="Nota">Objeto com todas propriedades preenchidas</param>
        /// <returns>Retorna True se alteração realizada com sucesso</returns>
        bool AlteraProdutoNaNota(Nota Nota);

        /// <summary>
        /// Interface responsável para Excluir um Produto da Nota
        /// </summary>
        /// <param name="ExcluirProdutoDaNota">Objeto preenchido com o id da Nota e Produto</param>
        void ExcluirProdutoDaNota(ProdutoNota ExcluirProdutoDaNota);

        /// <summary>
        /// Interface que recupera um objeto ProdutoNota 
        /// </summary>
        /// <param name="ProdutoNota">Parametro para recuperar um Produto vinculado a Nota para verificação</param>
        /// <returns>Retorna um Produto vinculado a nota</returns>
        ProdutoNota RecuperarProdutoNaNota(ProdutoNota ProdutoNota);

        /// <summary>
        /// Interface que recupera um objeto ProdutoNota para inserção
        /// </summary>
        /// <param name="ProdutoNota">Parametro para recuperar Produto(s) vinculado(s) a Nota</param>
        /// <returns>Retorna uma lista de Produtos vinculadas a nota</returns>
        IList<Produto> RecuperaUmaListaDeProdutosNaNota(ProdutoNota ProdutoNota);

        /// <summary>
        /// Interface que recupera uma lista de Notas
        /// </summary>
        /// <param name="Nota">Parametro para recuperar Notas de uma empresa com o número Vencimento e empresa que pertence a nota</param>
        /// <returns>Retorna uma lista de Notas</returns>
        IList<Nota> RecuperaNotas(Nota Nota);


        /// <summary>
        /// Interface que Verifica se uma Nota já existe
        /// </summary>
        /// <param name="conta">Objeto do tipo Nota</param>
        /// <returns>Retorna uma Nota Existente</returns>
        Nota VerificaNotaExistente(Nota nota);

    }
}
