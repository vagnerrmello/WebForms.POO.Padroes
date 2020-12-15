//-----------------------------------------------------------------------
// <copyright file="IRepositorioFuncionalidadeSqlServer.cs" company="Steto">
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
    /// Interface padrão para o repositório Funcionalidade
    /// </summary>
    public interface IRepositorioFuncionalidadeSqlServer
    {
        /// <summary>
        /// Recupera todos as funcionalidades por módulo
        /// </summary>
        /// <param name="idModulo">Id do módulo para recuperar a funcionalidade</param>
        /// <returns>Retorna uma lista de funcionalidade por módulo</returns>
        IList<ValueObjectLayer.Funcionalidade> RecuperaFuncionalidadesPorModulo(int idModulo);
    }
}
