//-----------------------------------------------------------------------
// <copyright file="IRepositorioCepSqlServer.cs" company="Steto">
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
    /// Classe padrão para o repositório Cep
    /// </summary>
    public interface IRepositorioCepSqlServer
    {
        /// <summary>
        /// Inteface que recupera todos os tipos de Cep
        /// </summary>
        /// <returns>Retorna uma lista de objetos do tio ValueObjectLayer.Email</returns>
        IList<ValueObjectLayer.Email_Tipo> RecuperaTipoEmail(ValueObjectLayer.TipoEmail tipoEmail);
    }
}
