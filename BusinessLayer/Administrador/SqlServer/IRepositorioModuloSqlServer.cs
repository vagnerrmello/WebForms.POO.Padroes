//-----------------------------------------------------------------------
// <copyright file="IRepositorioModuloSqlServer.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Administrador.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Interface padrão para o repositório Módulo
    /// </summary>
    public interface IRepositorioModuloSqlServer
    {
        /// <summary>
        /// Interface que recupera todos os módulos
        /// </summary>
        /// <returns>Retorna uma lista com todos os módulos pertencentes ao sistema</returns>
        IList<ValueObjectLayer.Modulo> RecuperaTodosOsModulos();

        /// <summary>
        /// Inteface responsável por recuperar os módulos do perfil
        /// </summary>
        /// <param name="idPerfil">Identificador do perfil</param>
        /// <returns>Retorna uma lista de objetos do tipo Modulo</returns>
        IList<ValueObjectLayer.Modulo> RecuperaModulosdoPerfil(int idPerfil);
    }
}
