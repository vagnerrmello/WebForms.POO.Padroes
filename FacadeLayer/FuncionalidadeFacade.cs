//-----------------------------------------------------------------------
// <copyright file="FuncionalidadeFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Steto.ValueObjectLayer;

    /// <summary>
    /// Fachada padrão para o objeto Funcionalidade
    /// </summary>
    public class FuncionalidadeFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Repositório responsável pelos métodos da base SqlServer
        /// </summary>
        static BusinessLayer.Administrador.SqlServer.IRepositorioFuncionalidadeSqlServer repositorioModuloSqlServer = new BusinessLayer.Administrador.SqlServer.RepositorioFuncionalidadeSqlServer();

        /// <summary>
        /// Recupera todos as funcionalidades por módulo
        /// </summary>
        /// <param name="idModulo">Id do módulo para recuperar a funcionalidade</param>
        /// <returns>Retorna uma lista de funcionalidade por módulo</returns>
        public static IList<ValueObjectLayer.Funcionalidade> RecuperaFuncionalidadesPorModulo(int idModulo)
        {
            //return BusinessLayer.Administrador.Funcionalidade.RecuperaFuncionalidadesPorModulo(idModulo);
            if (dados.Equals("SqlServer"))
                return repositorioModuloSqlServer.RecuperaFuncionalidadesPorModulo(idModulo);
            else
                return repositorioModuloSqlServer.RecuperaFuncionalidadesPorModulo(idModulo);
        }
    }
}
