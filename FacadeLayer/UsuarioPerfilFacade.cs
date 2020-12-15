//-----------------------------------------------------------------------
// <copyright file="UsuarioFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Steto.BusinessLayer.Administrador.SqlServer;

    /// <summary>
    /// Fachada padrão para o objeto UsuarioPerfil
    /// </summary>
    public class UsuarioPerfilFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Variável para acesso ao repositório de Perfil de usuário
        /// </summary>
        public static IRepositorioPerfilUsuarioSqlServer repositorioPerfilUsuario = new RepositorioPerfilUsuarioSqlServer();

        /// <summary>
        /// Método responsável por alterar o perfil do usuário
        /// </summary>
        /// <param name="perfilUsuario">Objeto Perfil_Usuario para </param>
        /// <returns>true a alteração ocorreu com sucesso</returns>
        public static bool AlteraPerfilUsuario(ValueObjectLayer.Perfil_Usuario perfilUsuario)
        {
            if (dados.Equals("SqlServer"))
                return repositorioPerfilUsuario.AlteraPerfilUsuario(perfilUsuario);
            else
                return repositorioPerfilUsuario.AlteraPerfilUsuario(perfilUsuario);
        }

        /// <summary>
        /// Método responsável por recuperar o perfil do usuário
        /// </summary>
        /// <param name="idUsuario">Id que indentifica o perfil do usuário</param>
        /// <returns>Retorna um objeto perfil do usuário</returns>
        public static ValueObjectLayer.Perfil_Usuario RecuperarPerfilUsuario(int idUsuario)
        {
            if (dados.Equals("SqlServer"))
                return repositorioPerfilUsuario.RecuperarPerfilUsuario(idUsuario);
            else
                return repositorioPerfilUsuario.RecuperarPerfilUsuario(idUsuario);
        }
    }
}
