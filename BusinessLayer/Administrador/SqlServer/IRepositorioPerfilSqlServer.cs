//-----------------------------------------------------------------------
// <copyright file="IRepositorioPerfilSqlServer.cs" company="Steto">
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
    ///  Interface padrão para o repositório Perfil
    /// </summary>
    public interface IRepositorioPerfilSqlServer
    {
        /// <summary>
        /// Método responsável para criar Perfil do usuário do sistema
        /// </summary>
        /// <param name="perfil">perfil </param>
        /// <returns>true se ok</returns>
        bool CriarPerfil(ValueObjectLayer.Perfil perfil);

        /// <summary>
        /// Método responsável para alterar Perfil do usuário do sistema
        /// </summary>
        /// <param name="perfil">perfil </param>
        /// <returns>true se ok</returns>
        bool AlterarPerfil(ValueObjectLayer.Perfil perfil);

        /// <summary>
        /// Método que Inativa um perfil do sistema
        /// </summary>
        /// <param name="id">Parametro com o id do perfil</param>
        /// <returns>Retorna True se ok</returns>
        bool InativarPerfil(int id);

        /// <summary>
        /// Método responsável para recuperar Perfil pelo id do peril
        /// </summary>
        /// <param name="perfil">perfil </param>
        /// <returns>true se ok</returns>
        ValueObjectLayer.Perfil RecuperarPerfil(int idPerfil);
        
        /// <summary>
        /// Método responsável por verificar se o nome do perfil já existe
        /// </summary>
        /// <param name="perfilNome">Nome do perfil a ser recuperado</param>
        /// <returns>return true se já existir um perfil com o mesmo nome que está querendo ser criado</returns>
        bool RecuperarPerfil(string perfilNome);

        /// <summary>
        /// Método que recupera todos os perfis do sistema
        /// </summary>
        /// <returns>Retorna uma lista de perfis já cadastrados</returns>
        IList<ValueObjectLayer.Perfil> RecuperarPerfis();

        /// <summary>
        /// Recupera os perfis pelo nome 
        /// </summary>
        /// <param name="nomePerfil">Referente ao nome do perfil</param>
        /// <returns>IList<> com o resultado</returns>
        IList<ValueObjectLayer.Perfil> RecuperarPerfis(string nomePerfil);

        /// <summary>
        /// Recupera os perfis pelo nome e o status ativo
        /// </summary>
        /// <param name="nomePerfil">Referente ao nome do perfil</param>
        /// <param name="ativo">Status do perfil</param>
        /// <returns>IList<> com o resultado</returns>
        IList<ValueObjectLayer.Perfil> RecuperarPerfis(string nomePerfil, bool ativo);

        /// <summary>
        /// Recupera os perfis pelo status do perfil
        /// </summary>
        /// <param name="ativo">Status do perfil</param>
        /// <returns>IList<> com o resultado</returns>
        IList<ValueObjectLayer.Perfil> RecuperarPerfis(bool ativo);

        /// <summary>
        /// Recupera os perfis pelo status do perfil
        /// </summary>
        /// <param name="idUsuario">id do usuario</param>
        /// <param name="tipoBuscaPerfil">Passa um um ValueObjectLayer.TipoBuscaPerfil para a recuperação desejada</param>
        /// <returns>Retorna um objeto Perfil_Usuario com o resultado</returns>
        IList<ValueObjectLayer.CarregarPerfil> RecuperarPerfilUsuario(int idUsuario, ValueObjectLayer.TipoBuscaPerfil tipoBuscaPerfil);

        /// <summary>
        /// Método que recupera o perfil do usuário do sistema
        /// </summary>
        /// <param name="idUsuario">Identificação do usuário no sistema</param>
        /// <returns>Retorna um objeto ValueObjectLayer.Perfil_Usuario devidamente preechido</returns>
        ValueObjectLayer.Perfil_Usuario RecuperarPerfilPorId(int idUsuario);
    }
}
