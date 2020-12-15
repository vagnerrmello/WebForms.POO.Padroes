//-----------------------------------------------------------------------
// <copyright file="IRepositorioUsuarioSqlServer.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Administrador.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Steto.ValueObjectLayer;

    /// <summary>
    ///  Interface padrão para o repositório Usuario
    /// </summary>
    public interface IRepositorioUsuarioSqlServer
    {
        /// <summary>
        /// Método que cria um novo usuário para acesso ao sistema
        /// </summary>
        /// <param name="usuario">Objeto usuário</param>
        /// <returns>True se ocorrer tudo ok</returns>
        int CriarUsuario(ValueObjectLayer.Usuario usuario);

        /// <summary>
        /// Método que recupera o login do usuário do sistema
        /// </summary>
        /// <param name="login">Parametro para recuperar o usuário</param>
        /// <returns>Retorna um objeto Usuario</returns>
        ValueObjectLayer.Usuario RecuperarPorLogin(string login);

        /// <summary>
        /// Método que bloqueia um usuário no sistema
        /// </summary>
        /// <param name="usuario">Parametro com o objeto usuário para o bloqueio no sistema</param>
        /// <returns>Retorna True se ok</returns>
        bool BloquearUsuario(ValueObjectLayer.Usuario usuario);

        /// <summary>
        /// Método responsável por recuperar usuário do sistema bloqueado
        /// </summary>
        /// <param name="login">Login do usuário do sistema</param>
        /// <param name="senha">Senha do usuário do sistema</param>
        /// <returns>Retorna True se ok</returns>
        bool RecuperarUsuarioBloqueado(string login, string senha);

        /// <summary>
        /// Método responsável por logar o usuário no sistema
        /// </summary>
        /// <param name="login">Login do usuário do sistema</param>
        /// <param name="senha">Senha do usuário do sistema</param>
        /// <returns>Retorna um objeto usuário</returns>
        ValueObjectLayer.Usuario Logar(string login, string senha);

        /// <summary>
        /// Método que altera o usuário para acesso ao sistema
        /// </summary>
        /// <param name="usuario">Objeto usuário</param>
        /// <returns>True se ocorrer tudo ok</returns>
        bool AlteraUsuario(ValueObjectLayer.Usuario usuario);

        /// <summary>
        /// Método que recupera todos os usuários do sistema
        /// </summary>
        /// <returns>Retorna True se ok</returns>
        IList<ValueObjectLayer.Usuario> RecuperarUsuarios();

        /// <summary>
        /// Método que recupera um usuário do sistema
        /// </summary>
        /// <param name="idUsuario">Parametro para recuperar o usuário</param>
        /// <returns>Retorna um objeto usuário</returns>
        ValueObjectLayer.Usuario RecuperarUsuario(Usuario ObjUsuario);

        /// <summary>
        /// Método que recupera o usuário do sistema pelo Nome
        /// </summary>
        /// <param name="nomeUsuario">Parametro com o nome do usuário no sistema</param>
        /// <returns>Retorna True se ok</returns>
        IList<ValueObjectLayer.Usuario> RecuperarUsuarios(string nomeUsuario);

        /// <summary>
        /// Método que recupera o usuário do sistema pelo Nome e se está ativo
        /// </summary>
        /// <param name="nome">Parametro com o nome do usuário no sistema</param>
        /// <param name="ativo">Parametro se o usuário está ativo ou não no sistema</param>
        /// <returns>Retorna True se ok</returns>
        IList<ValueObjectLayer.Usuario> RecuperarUsuarios(string nome, bool ativo);

        /// <summary>
        /// Método que recupera todos os usuários do sistema
        /// </summary>
        /// <param name="ativo">Parametro com o status do usuário no sistema</param>
        /// <returns>Retorna True se ok</returns>
        IList<ValueObjectLayer.Usuario> RecuperarUsuarios(bool ativo);

        /// <summary>
        /// Método que Inativa um usuário no sistema
        /// </summary>
        /// <param name="id">Parametro com o id do usuário</param>
        /// <returns>Retorna True se ok</returns>
        bool InativarUsuario(int id);

        /// <summary>
        /// Validar se login já existe no momento do cadastro
        /// </summary>
        /// <param name="isLogin">parametro que passa o login para validação</param>
        /// <returns>bool</returns>
        bool ValidarLogin(string isLogin);
    }
}
