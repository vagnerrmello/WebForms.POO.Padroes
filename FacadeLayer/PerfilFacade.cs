//-----------------------------------------------------------------------
// <copyright file="PerfilFacade.cs" company="Steto">
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

    /// <summary>
    /// Fachada padrão para o objeto Perfil
    /// </summary>
    public class PerfilFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Repositório responsável pelos métodos da base SqlServer
        /// </summary>
        static BusinessLayer.Administrador.SqlServer.IRepositorioPerfilSqlServer repositorioPerfilSqlServer = new BusinessLayer.Administrador.SqlServer.RepositorioPerfilSqlServer();

        /// <summary>
        /// Fachada responsável para criar Perfil do usuário do sistema
        /// </summary>
        /// <param name="perfil">Passa o objeto perfil para a criação do perfil </param>
        /// <returns>true se ok</returns>
        public static bool CriarPerfil(ValueObjectLayer.Perfil  perfil)
        {
            //return BusinessLayer.Administrador.Perfil.CriarPerfil(perfil);
            if (dados.Equals("SqlServer"))
                return repositorioPerfilSqlServer.CriarPerfil(perfil);
            else
                return repositorioPerfilSqlServer.CriarPerfil(perfil);
        }

        /// <summary>
        /// Fachada responsável para alterar Perfil do usuário do sistema
        /// </summary>
        /// <param name="perfil">perfil </param>
        /// <returns>true se ok</returns>
        public static bool AlterarPerfil(ValueObjectLayer.Perfil perfil)
        {
            //return BusinessLayer.Administrador.Perfil.AlterarPerfil(perfil);
            if (dados.Equals("SqlServer"))
                return repositorioPerfilSqlServer.AlterarPerfil(perfil);
            else
                return repositorioPerfilSqlServer.AlterarPerfil(perfil);
        }

        /// <summary>
        /// Fachada que Inativa um perfil do sistema
        /// </summary>
        /// <param name="id">Parametro com o id do perfil</param>
        /// <returns>Retorna True se ok</returns>
        public static bool InativarPerfil(int id)
        {
            //return BusinessLayer.Administrador.Perfil.InativarPerfil(id);
            if (dados.Equals("SqlServer"))
                return repositorioPerfilSqlServer.InativarPerfil(id);
            else
                return repositorioPerfilSqlServer.InativarPerfil(id);
        }

        /// <summary>
        /// Método responsável para recuperar Perfil pelo id do peril
        /// </summary>
        /// <param name="perfil">perfil </param>
        /// <returns>true se ok</returns>
        public static ValueObjectLayer.Perfil RecuperarPerfil(int idPerfil)
        {
            //return BusinessLayer.Administrador.Perfil.RecuperarPerfil(idPerfil);
            if (dados.Equals("SqlServer"))
                return repositorioPerfilSqlServer.RecuperarPerfil(idPerfil);
            else
                return repositorioPerfilSqlServer.RecuperarPerfil(idPerfil);
        }

        /// <summary>
        /// Fachada responsável por recuperar perfil pelo nome
        /// </summary>
        /// <param name="perfilNome">Nome do perfil a ser recuperado</param>
        /// <returns>return true se já existir um perfil com o mesmo nome que está querendo ser criando</returns>
        public static bool RecuperarPerfil(string perfilNome)
        {
            //return BusinessLayer.Administrador.Perfil.RecuperarPerfil(perfilNome);
            if (dados.Equals("SqlServer"))
                return repositorioPerfilSqlServer.RecuperarPerfil(perfilNome);
            else
                return repositorioPerfilSqlServer.RecuperarPerfil(perfilNome);
        }

        /// <summary>
        /// Fachada que recupera todos os perfis do sistema
        /// </summary>
        /// <returns>Retorna uma lista de perfis já cadastrados</returns>
        public static IList<ValueObjectLayer.Perfil> RecuperarPerfis()
        {
            //return BusinessLayer.Administrador.Perfil.RecuperarPerfis();
            if (dados.Equals("SqlServer"))
                return repositorioPerfilSqlServer.RecuperarPerfis();
            else
                return repositorioPerfilSqlServer.RecuperarPerfis();
        }

        /// <summary>
        /// Recupera os perfis pelo nome 
        /// </summary>
        /// <param name="nomePerfil">Referente ao nome do perfil</param>
        /// <returns>IList<> com o resultado</returns>
        public static IList<ValueObjectLayer.Perfil> RecuperarPerfis(string nomePerfil)
        {
            //return BusinessLayer.Administrador.Perfil.RecuperarPerfis(nomePerfil);
            if (dados.Equals("SqlServer"))
                return repositorioPerfilSqlServer.RecuperarPerfis(nomePerfil);
            else
                return repositorioPerfilSqlServer.RecuperarPerfis(nomePerfil);
        }

        /// <summary>
        /// Recupera os perfis pelo nome e o status ativo
        /// </summary>
        /// <param name="nomePerfil">Referente ao nome do perfil</param>
        /// <param name="ativo">Status do perfil</param>
        /// <returns>IList<> com o resultado</returns>
        public static IList<ValueObjectLayer.Perfil> RecuperarPerfis(string nomePerfil, bool ativo)
        {
            //return BusinessLayer.Administrador.Perfil.RecuperarPerfis(nomePerfil, ativo);
            if (dados.Equals("SqlServer"))
                return repositorioPerfilSqlServer.RecuperarPerfis(nomePerfil, ativo);
            else
                return repositorioPerfilSqlServer.RecuperarPerfis(nomePerfil, ativo);
        }

        /// <summary>
        /// Recupera os perfis pelo status do perfil
        /// </summary>
        /// <param name="ativo">Status do perfil</param>
        /// <returns>IList<> com o resultado</returns>
        public static IList<ValueObjectLayer.Perfil> RecuperarPerfis(bool ativo)
        {
            //return BusinessLayer.Administrador.Perfil.RecuperarPerfis(ativo);
            if (dados.Equals("SqlServer"))
                return repositorioPerfilSqlServer.RecuperarPerfis(ativo);
            else
                return repositorioPerfilSqlServer.RecuperarPerfis(ativo);
        }

        /// <summary>
        /// Recupera os perfis pelo status do perfil
        /// </summary>
        /// <param name="idUsuario">id do usuario</param>
        /// <returns>TB_Perfil_Usuario com o resultado</returns>
        public static IList<ValueObjectLayer.CarregarPerfil> RecuperarPerfilUsuario(int idUsuario, ValueObjectLayer.TipoBuscaPerfil tipoBuscaPerfil)
        {
            //return BusinessLayer.Administrador.Perfil.RecuperarPerfilUsuario(idUsuario, status);
            if (dados.Equals("SqlServer"))
                return repositorioPerfilSqlServer.RecuperarPerfilUsuario(idUsuario, tipoBuscaPerfil);
            else
                return repositorioPerfilSqlServer.RecuperarPerfilUsuario(idUsuario, tipoBuscaPerfil);
        }

        /// <summary>
        /// Fachada que recupera o perfil do usuário do sistema
        /// </summary>
        /// <param name="idUsuario">Identificação do usuário no sistema</param>
        /// <returns>Retorna um objeto ValueObjectLayer.Perfil_Usuario devidamente preechido</returns>
        public static ValueObjectLayer.Perfil_Usuario RecuperarPerfilPorId(int idUsuario)
        {
            //return BusinessLayer.Administrador.Perfil.RecuperarPerfilPorId(idUsuario);
            if (dados.Equals("SqlServer"))
                return repositorioPerfilSqlServer.RecuperarPerfilPorId(idUsuario);
            else
                return repositorioPerfilSqlServer.RecuperarPerfilPorId(idUsuario);
        }
    }
}
