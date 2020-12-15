//-----------------------------------------------------------------------
// <copyright file="IRepositorioEndereco.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Endereco
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Steto.ValueObjectLayer;
    using Steto.ValueObjectLayer.Endereco;


    /// <summary>
    ///  Interface padrão para o repositório Endereco
    /// </summary>
    public interface IRepositorioEndereco
    {
        /// <summary>
        /// Interface que recupera Pais
        /// </summary>
        /// <param name="pais">Parametro para recuperar uma lista de paises</param>
        /// <returns>Retorna uma lista de objetos Pais</returns>
        IList<Pais> RecuperarPais();

        /// <summary>
        /// Interface que recupera Estado
        /// </summary>
        /// <returns>Retorna uma lista de objetos Estado</returns>
        IList<Estado> RecuperarEstado();

        /// <summary>
        /// Interface que recupera Cidade
        /// </summary>
        /// <param name="estado">Parametro para recuperar uma lista de cidades</param>
        /// <returns>Retorna uma lista de objetos Cidade</returns>
        IList<Cidade> RecuperarCidade(Estado estado);

        /// <summary>
        /// Interface que recupera Cidade com código do ibge
        /// </summary>
        /// <param name="estado">Parametro para recuperar uma lista de cidades</param>
        /// <returns>Retorna uma lista de objetos Cidade</returns>
        IList<Cidade> RecuperarCidadeIBGE(Estado estado);

        /// <summary>
        /// Interface que recupera Bairro
        /// </summary>
        /// <param name="cidade">Parametro para recuperar uma lista de Bairros</param>
        /// <returns>Retorna uma lista de objetos Bairro</returns>
        IList<Bairro> RecuperarBairros(Cidade cidade);

        /// <summary>
        /// Interface que insere um Logradouro
        /// </summary>
        /// <param name="logradouro">Parametro para inserção de Logradouro</param>
        /// <returns>Retorna True caso a inserção tenha sido com sucesso</returns>
        bool InsereLogradouro(ValueObjectLayer.Endereco.Logradouro logradouro);


        /// <summary>
        /// Interface que recupera um Logradouro
        /// </summary>
        /// <param name="IsLogradouro">Parametro para recuperar um Objeto tipo Logradouro através do seu Id Parte</param>
        /// <returns>Retorna um objeto Logradouro</returns>
        ValueObjectLayer.Endereco.Logradouro RecuperaLogradouro(ValueObjectLayer.Endereco.Logradouro IsLogradouro);

        /// <summary>
        /// Interface que atualiza um Logradouro
        /// </summary>
        /// <param name="logradouro">Parametro para atualização de Logradouro</param>
        /// <returns>Retorna True caso a atualização tenha sido com sucesso</returns>
        bool AtualizaLogradouro(ValueObjectLayer.Endereco.Logradouro logradouro);

        /// <summary>
        /// Interface responsável por deletar um logradouro de uma parte
        /// </summary>
        /// <param name="logradouro">Recebe um objeto Logradouro</param>
        bool DeletaLogradouro(ValueObjectLayer.Endereco.Logradouro logradouro);

        /// <summary>
        /// Interface que insere um Logradouro
        /// </summary>
        /// <param name="logradouro">Parametro para inserção de Logradouro</param>
        /// <returns>Retorna True caso a inserção tenha sido com sucesso</returns>
        bool InsereEndereco(ValueObjectLayer.Endereco.Logradouro logradouro);
    }
}
