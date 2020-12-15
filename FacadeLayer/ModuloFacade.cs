//-----------------------------------------------------------------------
// <copyright file="ModuloFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Steto.BusinessLayer;
    using Steto.ValueObjectLayer;

    /// <summary>
    /// Fachada padrão para o objeto Modulo
    /// </summary>
    public class ModuloFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Repositório responsável pelos métodos da base SqlServer
        /// </summary>
        static BusinessLayer.Administrador.SqlServer.IRepositorioModuloSqlServer repositorioModuloSqlServer = new BusinessLayer.Administrador.SqlServer.RepositorioModuloSqlServer();

        /// <summary>
        /// Fachada que recupera todos os módulos
        /// </summary>
        /// <returns>Retorna uma lista com todos os módulos pertencentes ao sistema</returns>
        public static IList<ValueObjectLayer.Modulo> RecuperaTodosOsModulos()
        {
            //return BusinessLayer.Administrador.Modulo.RecuperaTodosOsModulos();
            if (dados.Equals("SqlServer"))
                return repositorioModuloSqlServer.RecuperaTodosOsModulos();
            else
                return repositorioModuloSqlServer.RecuperaTodosOsModulos();
        }

        /// <summary>
        /// Fachada responsável por recuperar os módulos do perfil
        /// </summary>
        /// <param name="idPerfil">Identificador do perfil</param>
        /// <returns>Retorna uma lista de objetos do tipo Modulo</returns>
        public static IList<ValueObjectLayer.Modulo> RecuperaModulosdoPerfil(int idPerfil)
        {
            //return BusinessLayer.Administrador.Modulo.RecuperaModulosdoPerfil(idPerfil);
            if (dados.Equals("SqlServer"))
                return repositorioModuloSqlServer.RecuperaModulosdoPerfil(idPerfil);
            else
                return repositorioModuloSqlServer.RecuperaModulosdoPerfil(idPerfil);
        }
    }
}
