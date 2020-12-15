//-----------------------------------------------------------------------
// <copyright file="AuditoriaFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer
{
    using System.Collections.Generic;
    using ValueObjectLayer;

    /// <summary>
    /// Fachada padrão para o objeto Auditoria
    /// </
    public class AuditoriaFacade
    {
        ///// <summary>
        ///// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        ///// </summary>
        //static string dados =  System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Repositório responsável pelos métodos da base SqlServer
        /// </summary>
        static BusinessLayer.Administrador.SqlServer.IRepositorioAuditoria repositorioAuditoria = new BusinessLayer.Administrador.SqlServer.RepositorioAuditoria();

        /// <summary>
        /// Fachada que cria uma Auditoria de um Usuário dentro do sistema
        /// </summary>
        /// <param name="Auditoria">Objeto Auditoria com informações do Usuário, Descrição da ação, e Data da ocorrência</param>
        /// <returns>Retorna o Id do Inserção</returns>
        public static int CriarAuditoria(Auditoria Auditoria)
        {
            return repositorioAuditoria.CriarAuditoria(Auditoria);
        }

        /// <summary>
        /// Fachada que recupera todas ações de um Usuário dentro do sistema
        /// </summary>
        /// <param name="Auditoria">Parametro para recuperar todas as ações de um usuário para auditoria</param>
        /// <returns>Retorna um objeto Auditoria</returns>
        public static IList<Auditoria> RecuperarUsuario(Auditoria Auditoria)
        {
            return repositorioAuditoria.RecuperarUsuario(Auditoria);
        }
    }
}
