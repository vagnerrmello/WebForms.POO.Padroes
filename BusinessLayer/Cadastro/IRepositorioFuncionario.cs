//-----------------------------------------------------------------------
// <copyright file="IRepositorioEmpresa.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer
{
    using System.Collections.Generic;
    using ValueObjectLayer;

    /// <summary>
    ///  Interface padrão para o repositório Funcionario
    /// </summary>
    public interface IRepositorioFuncionario
    {
        /// <summary>
        /// Interface que cria um novo Funcionario
        /// </summary>
        /// <param name="funcionario">Objeto Funcionario</param>
        /// <returns>Id do Funcionário</returns>
        int InsereFuncionario(Funcionario funcionario);

        /// <summary>
        /// Interface que recupera vários objetos Funcionários por Empresa
        /// </summary>
        /// <param name="funcionario"> Um objeto Funcionario com o Parametro Id da Empresa preenchida</param>
        /// <returns>Retorna uma lista de objetos Funcionarios por Empresa</returns>
        IList<Funcionario> RecuperaVariosFuncionariosPorEmpresa(Funcionario funcionario);

        ///// <summary>
        ///// Interface que Atualiza uma Empresa
        ///// </summary>
        ///// <param name="empresa">Objeto Empresa</param>
        ///// <returns>True se ocorrer tudo ok</returns>
        //bool AtualizarFuncionario(Empresa empresa);

        ///// <summary>
        ///// Interface que recupera um objeto Empresa
        ///// </summary>
        ///// <param name="empresa">Parametro para recuperar um objeto Empresa através ou não do seu Id</param>
        ///// <returns>Retorna o objeto Empresa</returns>
        //Empresa RecuperaFuncionario(Empresa empresa);
    }
}
