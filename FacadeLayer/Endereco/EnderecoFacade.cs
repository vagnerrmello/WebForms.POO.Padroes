//-----------------------------------------------------------------------
// <copyright file="EnderecoFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer.Endereco
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Steto.ValueObjectLayer;
    using Steto.BusinessLayer.Endereco;
    using Steto.ValueObjectLayer.Endereco;

    public class EnderecoFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Repositório responsável pelos métodos de Endereco
        /// </summary>
        static IRepositorioEndereco repositorioEndereco = new RepositorioEndereco();

        /// <summary>
        /// Fachada que recupera todos os Bairros de uma Cidade
        /// </summary>
        /// <param name="cidade">Parametro para recuperar uma lista de Bairros</param>
        /// <returns>Retorna uma lista de objetos Bairro</returns>
        public static IList<Bairro> RecuperarBairros(Cidade cidade)
        {
            return repositorioEndereco.RecuperarBairros(cidade);
        }

        /// <summary>
        /// Fachada que recupera Cidade
        /// </summary>
        /// <param name="estado">Parametro para recuperar uma lista de cidades</param>
        /// <returns>Retorna uma lista de objetos Cidade</returns>
        public static IList<Cidade> RecuperarCidade(Estado estado)
        {
            return repositorioEndereco.RecuperarCidade(estado);
        }

        /// <summary>
        /// Fachada que recupera Estado
        /// </summary>
        /// <returns>Retorna uma lista de objetos Estado</returns>
        public static IList<Estado> RecuperarEstado()
        {
            return repositorioEndereco.RecuperarEstado();
        }


        /// <summary>
        /// Método que recupera Cidade com código do ibge
        /// </summary>
        /// <param name="estado">Parametro para recuperar uma lista de cidades</param>
        /// <returns>Retorna uma lista de objetos Cidade</returns>
        public static IList<Cidade> RecuperarCidadeIBGE(Estado estado)
        {
            return repositorioEndereco.RecuperarCidadeIBGE(estado);
        }

        /// <summary>
        /// Fachada que recupera Pais
        /// </summary>
        /// <param name="pais">Parametro para recuperar uma lista de paises</param>
        /// <returns>Retorna uma lista de objetos Pais</returns>
        public static IList<Pais> RecuperarPais()
        {
            return repositorioEndereco.RecuperarPais();
        }

        /// <summary>
        /// Fachada que insere um Logradouro
        /// </summary>
        /// <param name="logradouro">Parametro para inserção de Logradouro</param>
        /// <returns>Retorna True caso a inserção tenha sido com sucesso</returns>
        public static bool InsereLogradouro(ValueObjectLayer.Endereco.Logradouro logradouro)
        {
            return repositorioEndereco.InsereLogradouro(logradouro);

        }


        /// <summary>
        /// Fachada que recupera um Logradouro
        /// </summary>
        /// <param name="IsLogradouro">Parametro para recuperar um Objeto tipo Logradouro através do seu Id Parte</param>
        /// <returns>Retorna um objeto Logradouro</returns>
        public static ValueObjectLayer.Endereco.Logradouro RecuperaLogradouro(ValueObjectLayer.Endereco.Logradouro IsLogradouro)
        {
            return repositorioEndereco.RecuperaLogradouro(IsLogradouro);
        }

        /// <summary>
        /// Fachada que atualiza um Logradouro
        /// </summary>
        /// <param name="logradouro">Parametro para atualização de Logradouro</param>
        /// <returns>Retorna True caso a atualização tenha sido com sucesso</returns>
        public static bool AtualizaLogradouro(ValueObjectLayer.Endereco.Logradouro logradouro)
        {
            return repositorioEndereco.AtualizaLogradouro(logradouro);
        }

        /// <summary>
        /// Fachada responsável por deletar um logradouro de uma parte
        /// </summary>
        /// <param name="logradouro">Recebe um objeto Logradouro</param>
        public static bool DeletaLogradouro(ValueObjectLayer.Endereco.Logradouro logradouro)
        {
            return repositorioEndereco.DeletaLogradouro(logradouro);
        }

        /// <summary>
        /// Fachada que insere um Logradouro
        /// </summary>
        /// <param name="logradouro">Parametro para inserção de Logradouro</param>
        /// <returns>Retorna True caso a inserção tenha sido com sucesso</returns>
        public static bool InsereEndereco(ValueObjectLayer.Endereco.Logradouro logradouro)
        {
            return repositorioEndereco.InsereEndereco(logradouro);
        }
    }
}
