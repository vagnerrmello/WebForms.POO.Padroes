//-----------------------------------------------------------------------
// <copyright file="FuncionarioFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer
{
    using Steto.ValueObjectLayer;
    using Steto.BusinessLayer;
    using System.Collections.Generic;

    public class FuncionarioFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Repositório responsável pelos métodos de Funcionario
        /// </summary>
        static IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();

        /// <summary>
        /// Fachada que cria um novo Funcionario
        /// </summary>
        /// <param name="funcionario">Objeto Funcionario</param>
        /// <returns>Id do Funcionário</returns>
        public static int InsereFuncionario(Funcionario funcionario)
        {
            return repositorioFuncionario.InsereFuncionario(funcionario);
        }

        /// <summary>
        /// Método que recupera vários objetos Funcionários por Empresa
        /// </summary>
        /// <param name="funcionario"> Um objeto Funcionario com o Parametro Id da Empresa preenchida</param>
        /// <returns>Retorna uma lista de objetos Empresa Tipo Funcionarios </returns>
        public static IList<Funcionario> RecuperaVariosFuncionariosPorEmpresa(Funcionario funcionario)
        {
            return repositorioFuncionario.RecuperaVariosFuncionariosPorEmpresa(funcionario);
        }

    }
}
