//-----------------------------------------------------------------------
// <copyright file="NotaFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer.Estoque
{
    using BusinessLayer.Estoque;
    using System.Collections.Generic;
    using ValueObjectLayer;

    /// <summary>
    /// Fachada padrão para o objeto Nota
    /// </summary>
    public class NotaFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = "SqlServer";//System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Variável para acesso ao repositório Notas
        /// </summary>
        public static IRepositorioNota  repositorioNota = new RepositorioNota();

        /// <summary>
        /// Facade que Cria uma nova Nota
        /// </summary>
        /// <param name="nota">Objeto Nota</param>
        /// <returns>Retorna o Id da Nota</returns>
        public static int CriarNota(Nota nota)
        {
             return repositorioNota.CriarNota(nota);
        }

        /// <summary>
        /// Facade responsável para Atualizar uma Nota
        /// </summary>
        /// <param name="Nota">Objeto com todas propriedades preenchidas</param>
        /// <returns>Retorna um booleano</returns>
        public static bool AtualizaNota(Nota Nota)
        {
            return repositorioNota.AtualizaNota(Nota);
        }

        /// <summary>
        /// Facade que recupera um objeto ProdutoNota 
        /// </summary>
        /// <param name="ProdutoNota">Parametro para recuperar um Produto vinculado a Nota para verificação</param>
        /// <returns>Retorna um Produto vinculado a nota</returns>
        public static ProdutoNota RecuperarProdutoNaNota(ProdutoNota ProdutoNota)
        {
            return repositorioNota.RecuperarProdutoNaNota(ProdutoNota);
        }

        /// <summary>
        /// Facade que recupera um objeto ProdutoNota para inserção
        /// </summary>
        /// <param name="ProdutoNota">Parametro para recuperar Produto(s) vinculado(s) a Nota</param>
        /// <returns>Retorna uma lista de Produtos vinculadas a nota</returns>
        public static IList<Produto> RecuperaUmaListaDeProdutosNaNota(ProdutoNota ProdutoNota)
        {
            return repositorioNota.RecuperaUmaListaDeProdutosNaNota(ProdutoNota);
        }

        /// <summary>
        /// Facade responsável para inserir o produto na Nota
        /// </summary>
        /// <param name="InserirProdutoNaNota">Objeto preenchido com o id da nota, id</param>
        /// <returns>Retorna o Id da Nota</returns>
        public static int InserirProdutoNaNota(ProdutoNota InserirProdutoNaNota)
        {
            return repositorioNota.InserirProdutoNaNota(InserirProdutoNaNota);
        }

        /// <summary>
        /// Facade responsável para Alterar um produto na Nota
        /// </summary>
        /// <param name="Nota">Objeto com todas propriedades preenchidas</param>
        /// <returns>Retorna True se alteração realizada com sucesso</returns>
        public static bool AlteraProdutoNaNota(Nota nota)
        {
            return repositorioNota.AlteraProdutoNaNota(nota);
        }

        /// <summary>
        /// Facade responsável para Excluir um Produto da Nota
        /// </summary>
        /// <param name="ExcluirProdutoDaNota">Objeto preenchido com o id da Nota e Produto</param>
        public static void ExcluirProdutoDaNota(ProdutoNota ExcluirProdutoDaNota)
        {
            repositorioNota.ExcluirProdutoDaNota(ExcluirProdutoDaNota);
        }

        /// <summary>
        /// Facade que recupera uma lista de Notas
        /// </summary>
        /// <param name="Nota">Parametro para recuperar Notas de uma empresa com o número Vencimento e empresa que pertence a nota</param>
        /// <returns>Retorna uma lista de Notas</returns>
        public static IList<Nota> RecuperaNotas(Nota Nota)
        {
            return repositorioNota.RecuperaNotas(Nota);
        }

        /// <summary>
        /// Facade que Verifica se uma Nota já existe
        /// </summary>
        /// <param name="conta">Objeto do tipo Nota</param>
        /// <returns>Retorna uma Nota Existente</returns>
        public static Nota VerificaNotaExistente(Nota nota)
        {
            return repositorioNota.VerificaNotaExistente(nota);
        }

    }
}
