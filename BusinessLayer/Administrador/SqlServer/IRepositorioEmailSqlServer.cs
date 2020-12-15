//-----------------------------------------------------------------------
// <copyright file="IRepositorioEmailSqlServer.cs" company="Steto">
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
    /// Interface padrão para o repositório Email
    /// </summary>
    public interface IRepositorioEmailSqlServer
    {
        /// <summary>
        /// Inteface que recupera todos os tipos de email
        /// </summary>
        /// <returns>Retorna uma lista de objetos do tio ValueObjectLayer.Email</returns>
        IList<ValueObjectLayer.Email_Tipo> RecuperaTipoEmail(ValueObjectLayer.TipoEmail tipoEmail);

        /// <summary>
        /// Inteface responsável por recuperar as configurações de um email
        /// </summary>
        /// <param name="idEmail">Identificador da configuração do email</param>
        /// <returns>Retorna um objeto Email</returns>
        ValueObjectLayer.Email RecuperarConfiguracaoEmail(ValueObjectLayer.TipoEmail tipoEmail);

        /// <summary>
        /// Inteface responsável por salvar as configurações de email
        /// </summary>
        /// <param name="email">Objeto do tipo ValueObjectLayer.Email</param>
        /// <returns>Retorna um bool se ok</returns>
        bool SalvaConfiguracaoEmail(ValueObjectLayer.Email email);

        /// <summary>
        /// Inteface que envia email do sistema
        /// </summary>
        /// <param name="email">Email requerido para envio</param>
        /// <param name="email">Objeto ValueObjectLayer.Email com os dados de email</param>
        /// <param name="usuario">Objeto ValueObjectLayer.Usuario com os dados do email do usuário</param>
        /// <returns>Retorna true se ok</returns>
        bool EnviarEmail(ValueObjectLayer.Usuario usuario, string msgUsuario);

        /// <summary>
        /// Inteface responsável por validar email
        /// </summary>
        /// <param name="inputEmail">email a ser validado</param>
        /// <returns>Retorna true se email for um email válido</returns>
        bool ValidarEmail(string inputEmail);

    }
}
