//-----------------------------------------------------------------------
// <copyright file="IRepositorioPerfilUsuarioSqlServer.cs" company="Steto">
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
    ///  Interface padrão para o repositório PerfilUsuario
    /// </summary>
    public interface IRepositorioPerfilUsuarioSqlServer
    {
        /// <summary>
        /// Método responsável por alterar o perfil do usuário
        /// </summary>
        /// <param name="perfilUsuario">Objeto Perfil_Usuario para </param>
        /// <returns></returns>
        bool AlteraPerfilUsuario(ValueObjectLayer.Perfil_Usuario perfilUsuario);
        
        /// <summary>
        /// Método responsável por recuperar o perfil do usuário
        /// </summary>
        /// <param name="idUsuario">Id que indentifica o perfil do usuário</param>
        /// <returns>Retorna um objeto perfil do usuário</returns>
        ValueObjectLayer.Perfil_Usuario RecuperarPerfilUsuario(int idUsuario);
    }
}
