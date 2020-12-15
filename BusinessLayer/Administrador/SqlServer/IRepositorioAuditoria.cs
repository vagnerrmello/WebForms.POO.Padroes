//-----------------------------------------------------------------------
// <copyright file="IRepositorioAuditoria.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Administrador.SqlServer
{
    using System.Collections.Generic;
    using ValueObjectLayer;

    /// <summary>
    /// Classe padrão que persiste/consulta as informações provenientes da base de dados de RepositorioAuditoria para retorno das ações de usuários do sistema
    /// </summary>
    public interface IRepositorioAuditoria
    {
        /// <summary>
        /// Inteface que cria uma Auditoria de um Usuário dentro do sistema
        /// </summary>
        /// <param name="Auditoria">Objeto Auditoria com informações do Usuário, Descrição da ação, e Data da ocorrência</param>
        /// <returns>Retorna o Id do Inserção</returns>
        int CriarAuditoria(Auditoria Auditoria);

        /// <summary>
        /// Inteface que recupera todas ações de um Usuário dentro do sistema
        /// </summary>
        /// <param name="Auditoria">Parametro para recuperar todas as ações de um usuário para auditoria</param>
        /// <returns>Retorna um objeto Auditoria</returns>
        IList<Auditoria> RecuperarUsuario(Auditoria Auditoria);
    }
}
