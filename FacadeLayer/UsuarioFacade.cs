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
    using Steto.BusinessLayer;
    using Steto.ValueObjectLayer;
    using Steto.BusinessLayer.Administrador.SqlServer;

    /// <summary>
    /// Fachada padrão para o objeto Usuario
    /// </
    public class UsuarioFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados =  System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Repositório responsável pelos métodos da base SqlServer
        /// </summary>
        static BusinessLayer.Administrador.SqlServer.IRepositorioUsuarioSqlServer repositorioUsuarioSqlServer = new BusinessLayer.Administrador.SqlServer.RepositorioUsuarioSqlServer();

        /// <summary>
        /// Fachada responsável por logar o usuário no sistema
        /// </summary>
        /// <param name="login">Login do usuário do sistema</param>
        /// <param name="senha">Senha do usuário do sistema</param>
        /// <returns>Retorna um objeto usuário</returns>
        public static Steto.ValueObjectLayer.Usuario Logar(string login, string senha)
        {
            if (dados.Equals("SqlServer"))
                return repositorioUsuarioSqlServer.Logar(login, senha);
            else
                return repositorioUsuarioSqlServer.Logar(login, senha);
        }

        /// <summary>
        /// Fachada que cria um novo usuário para acesso ao sistema
        /// </summary>
        /// <param name="usuario">Objeto usuário</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public static int CriarUsuario(ValueObjectLayer.Usuario usuario)
        {
            if (dados.Equals("SqlServer"))
                return repositorioUsuarioSqlServer.CriarUsuario(usuario);
            else
                return repositorioUsuarioSqlServer.CriarUsuario(usuario);

        }

        /// <summary>
        /// Fachada que recupera o usuário do sistema pelo Id
        /// </summary>
        /// <param name="idUsuario">Parametro com o id do usuário do sistema</param>
        /// <returns>Retorna True se ok</returns>
        public static ValueObjectLayer.Usuario RecuperarUsuario(Usuario ObjUsuario)
        {
            if (dados.Equals("SqlServer"))
                return repositorioUsuarioSqlServer.RecuperarUsuario(ObjUsuario);
            else
                return repositorioUsuarioSqlServer.RecuperarUsuario(ObjUsuario);
        }

        /// <summary>
        /// Fachada que recupera o login do usuário do sistema
        /// </summary>
        /// <param name="login">Parametro para recuperar o usuário</param>
        /// <returns>Retorna um objeto TB_Usuario</returns>
        public static ValueObjectLayer.Usuario RecuperarPorLogin(string login)
        {
            if (dados.Equals("SqlServer"))
                return repositorioUsuarioSqlServer.RecuperarPorLogin(login);
            else
                return repositorioUsuarioSqlServer.RecuperarPorLogin(login);
        }

        /// <summary>
        /// Fachada que recupera uma lista de usuários do sistema pelo nome
        /// </summary>
        /// <param name="nome">Parametro para recuperar o usuário</param>
        /// <returns>Retorna um objeto usuário</returns>
        public static IList<ValueObjectLayer.Usuario> RecuperarUsuarios(string nome)
        {
            if (dados.Equals("SqlServer"))
                return repositorioUsuarioSqlServer.RecuperarUsuarios(nome);
            else
                return repositorioUsuarioSqlServer.RecuperarUsuarios(nome);
        }

        /// <summary>
        /// Fachada que recupera todos os usuários do sistema
        /// </summary>
        /// <returns>Retorna True se ok</returns>
        public static IList<ValueObjectLayer.Usuario> RecuperarUsuarios()
        {
            if (dados.Equals("SqlServer"))
                return repositorioUsuarioSqlServer.RecuperarUsuarios();
            else
                return repositorioUsuarioSqlServer.RecuperarUsuarios();
        }

        /// <summary>
        /// Fachada que recupera o usuário do sistema pelo Nome e se está ativo
        /// </summary>
        /// <param name="nomeUsuario">Parametro com o nome do usuário do sistema</param>
        /// <param name="ativo">Parametro se o usuário está ativo ou não no sistema</param>
        /// <returns>Retorna True se ok</returns>
        public static IList<ValueObjectLayer.Usuario> RecuperarUsuarios(string nomeUsuario, bool ativo)
        {
            if (dados.Equals("SqlServer"))
                return repositorioUsuarioSqlServer.RecuperarUsuarios(nomeUsuario, ativo);
            else
                return repositorioUsuarioSqlServer.RecuperarUsuarios(nomeUsuario, ativo);
        }

        /// <summary>
        /// Fachada que recupera todos os usuários do sistema
        /// </summary>
        /// <param name="ativo">Parametro com o status do usuário do sistema</param>
        /// <returns>Retorna True se ok</returns>
        public static IList<ValueObjectLayer.Usuario> RecuperarUsuarios(bool ativo)
        {
            if (dados.Equals("SqlServer"))
                return repositorioUsuarioSqlServer.RecuperarUsuarios(ativo);
            else
                return repositorioUsuarioSqlServer.RecuperarUsuarios(ativo);
        }

        /// <summary>
        /// Fachada que altera o usuário para acesso ao sistema
        /// </summary>
        /// <param name="usuario">Objeto usuário</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public static bool AlteraUsuario(ValueObjectLayer.Usuario usuario)
        {
            if (dados.Equals("SqlServer"))
                return repositorioUsuarioSqlServer.AlteraUsuario(usuario);
            else
                return repositorioUsuarioSqlServer.AlteraUsuario(usuario);
        }

        /// <summary>
        /// Fachada que Inativa um usuário do sistema
        /// </summary>
        /// <param name="id">Parametro com o id do usuário</param>
        /// <returns>Retorna True se ok</returns>
        public static bool InativarUsuario(int id)
        {
            if (dados.Equals("SqlServer"))
                return repositorioUsuarioSqlServer.InativarUsuario(id);
            else
                return repositorioUsuarioSqlServer.InativarUsuario(id);
        }

        /// <summary>
        /// Fachada que bloqueia um usuário do sistema
        /// </summary>
        /// <param name="id">Parametro com o id do usuário</param>
        /// <returns>Retorna True se ok</returns>
        public static bool BloquearUsuario(ValueObjectLayer.Usuario usuario)
        {
            if (dados.Equals("SqlServer"))
                return repositorioUsuarioSqlServer.BloquearUsuario(usuario);
            else
                return repositorioUsuarioSqlServer.BloquearUsuario(usuario);
        }

        /// <summary>
        /// Fachada responsável por recuperar usuário do sistema bloqueado no momento do login
        /// </summary>
        /// <param name="login">Login do usuário do sistema</param>
        /// <param name="senha">Senha do usuário do sistema</param>
        /// <returns>Retorna True se ok</returns>
        public static bool RecuperarUsuarioBloqueado(string login, string senha)
        {
            if (dados.Equals("SqlServer"))
                return repositorioUsuarioSqlServer.RecuperarUsuarioBloqueado(login, senha);
            else
                return repositorioUsuarioSqlServer.RecuperarUsuarioBloqueado(login, senha);
        }

        /// <summary>
        /// Fachada para validar se login já existe no momento do cadastro
        /// </summary>
        /// <param name="isLogin">parametro que passa o login para validação</param>
        /// <returns>retorna true se ok</returns>
        public static bool ValidarLogin(string isLogin)
        {
            if (dados.Equals("SqlServer"))
                return repositorioUsuarioSqlServer.ValidarLogin(isLogin);
            else
                return repositorioUsuarioSqlServer.ValidarLogin(isLogin);
        }

    }
}
