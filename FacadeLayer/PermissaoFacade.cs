//-----------------------------------------------------------------------
// <copyright file="PermissaoFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Steto.ValueObjectLayer;
    using Steto.BusinessLayer;

    /// <summary>
    /// Fachada padrão para o objeto Permissao
    /// </summary>
    public class PermissaoFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Repositório responsável pelos métodos da base SqlServer
        /// </summary>
        static BusinessLayer.Administrador.SqlServer.IRepositorioPermissaoSqlServer repositorioPermissaoSqlServer = new BusinessLayer.Administrador.SqlServer.RepositorioPermissaoSqlServer();

        /// <summary>
        /// Fachada responsável por recuperar as permissões da funcionalidade
        /// </summary>
        /// <param name="idFuncionalidade">Identificação da funcionalidade</param>
        /// <returns>Retorna uma lista de objeto do tipo ValueObjectLayer.Permissao_Funcionalidade</returns>
        public static IList<ValueObjectLayer.Permissao_Funcionalidade> RecuperaPermissaoPorFuncionalidade(int idFuncionalidade)
        {
            //return BusinessLayer.Administrador.Permissao.RecuperaPermissaoPorFuncionalidade(idFuncionalidade);
            if (dados.Equals("SqlServer"))
                return repositorioPermissaoSqlServer.RecuperaPermissaoPorFuncionalidade(idFuncionalidade);
            else
                return repositorioPermissaoSqlServer.RecuperaPermissaoPorFuncionalidade(idFuncionalidade);
        }

        /// <summary>
        /// Fachada responsável por recuperar as permissões da funcionalidade pelo perfil
        /// </summary>
        /// <param name="idPerfil">Identidade do perfil</param>
        /// <returns>Retorna um objeto com uma lista de ValueObjectLayer.Perfil_Permissao_Funcionalidade</returns>
        public static IList<ValueObjectLayer.Perfil_Permissao_Funcionalidade> RecuperaPermissaoDaFuncionalidadePorPerfil(int idPerfil)
        {
            //return BusinessLayer.Administrador.Permissao.RecuperaPermissaoDaFuncionalidadePorPerfil(idPerfil);
            if (dados.Equals("SqlServer"))
                return repositorioPermissaoSqlServer.RecuperaPermissaoDaFuncionalidadePorPerfil(idPerfil);
            else
                return repositorioPermissaoSqlServer.RecuperaPermissaoDaFuncionalidadePorPerfil(idPerfil);
        }

        /// <summary>
        /// Fachada responsável por recuperar todas as permissões do perfil que existe para o usuário do sistema
        /// </summary>
        /// <param name="idPerfil">identificador do perfil do usuário no sistema</param>
        /// <returns>Retorna uma lista de objeto com os acessos deste perfil</returns>
        public static IList<ValueObjectLayer.CarregarPerfil> RecuperaTodasPermissoesPerfil(int idPerfil)
        {
            //return BusinessLayer.Administrador.Permissao.RecuperaTodasPermissoesPerfil(idPerfil);
            if (dados.Equals("SqlServer"))
                return repositorioPermissaoSqlServer.RecuperaTodasPermissoesPerfil(idPerfil);
            else
                return repositorioPermissaoSqlServer.RecuperaTodasPermissoesPerfil(idPerfil);
        }

        /// <summary>
        /// Fachada responsável para recuperar todas as permissões do perfil para popular a TreeView
        /// </summary>
        /// <param name="idPerfil">identificador do perfil do usuário no sistema</param>
        /// <returns>Retorna uma lista de objeto com os acessos deste perfil</returns>
        public static IList<ValueObjectLayer.CarregarPerfil> RecuperaTodasPermissoesPerfilTreeView(int idPerfil)
        {
            //return BusinessLayer.Administrador.Permissao.RecuperaTodasPermissoesPerfilTreeView(idPerfil);
            if (dados.Equals("SqlServer"))
                return repositorioPermissaoSqlServer.RecuperaTodasPermissoesPerfilTreeView(idPerfil);
            else
                return repositorioPermissaoSqlServer.RecuperaTodasPermissoesPerfilTreeView(idPerfil);
        }

        /// <summary>
        /// Fachada responsável por permitir o salvamento das permissões para o perfil
        /// </summary>
        /// <param name="idPerfil">Identificador do perfil</param>
        /// <returns>Retorna um booleano se ok</returns>
        public static bool SalvarPermissaoPerfil(IList<ValueObjectLayer.CarregarPerfil> pmfps)
        {
            //return BusinessLayer.Administrador.Permissao.SalvarPermissaoPerfil(pmfps);
            if (dados.Equals("SqlServer"))
                return repositorioPermissaoSqlServer.SalvarPermissaoPerfil(pmfps);
            else
                return repositorioPermissaoSqlServer.SalvarPermissaoPerfil(pmfps);
        }

        /// <summary>
        /// Fachada responsável por recuperar o perfil para montar o sub-menu
        /// </summary>
        /// <param name="idPerfil">identificador do perfil do usuário no sistema</param>
        /// <returns>Retorna uma lista de objeto com os acessos deste perfil</returns>
        public static IList<ValueObjectLayer.CarregarPerfil> RecuperaTodasFuncionalidadesPerfil(int idPerfil)
        {
            //return BusinessLayer.Administrador.Permissao.RecuperaTodasFuncionalidadesPerfil(idPerfil);
            if (dados.Equals("SqlServer"))
                return repositorioPermissaoSqlServer.RecuperaFuncionalidadesPerfil(idPerfil);
            else
                return repositorioPermissaoSqlServer.RecuperaFuncionalidadesPerfil(idPerfil);
        }

        /// <summary>
        /// Método responsável para recuperar os nomes das permissões relacionadas ao perfil
        /// </summary>
        /// <param name="idPerfil">Identificador do perfil</param>
        /// <returns>Retorna uma lista de objeto com as permissões deste perfil</returns>
        public static IList<ValueObjectLayer.CarregarPerfil> RecuperaTodasPermissoesDoPerfil(int idPerfil)
        {
            ///return BusinessLayer.Administrador.Permissao.RecuperaTodasPermissoesDoPerfil(idPerfil);
            if (dados.Equals("SqlServer"))
                return repositorioPermissaoSqlServer.RecuperaPermissoes(idPerfil);
            else
                return repositorioPermissaoSqlServer.RecuperaPermissoes(idPerfil);
        }

        /// <summary>
        /// Fachada responsável por deletar as permissões e suas funcionalidades do perfil
        /// </summary>
        /// <param name="ppf">Recebe um objeto do tipo ValueObjectLayer.Perfil_Permissao_Funcionalidade</param>
        public static void DeletaPermissaoPerfil(ValueObjectLayer.Perfil_Permissao_Funcionalidade ppf)
        {
            //BusinessLayer.Administrador.Permissao.DeletaPermissaoPerfil(ppf);
            if (dados.Equals("SqlServer"))
                repositorioPermissaoSqlServer.DeletaPermissaoPerfil(ppf);
            else
                repositorioPermissaoSqlServer.DeletaPermissaoPerfil(ppf);
        }

        /// <summary>
        /// Fachada que deleta todos os registro do perfil
        /// </summary>
        /// <param name="idPerfil">Perfil a ser registrado</param>
        public static void DeletaPerfilModulo(int idPerfil)
        {
            //BusinessLayer.Administrador.Permissao.DeletaPerfilModulo(idPerfil);
            if (dados.Equals("SqlServer"))
                repositorioPermissaoSqlServer.DeletaPerfilModulo(idPerfil);
            else
                repositorioPermissaoSqlServer.DeletaPerfilModulo(idPerfil);
        }

        /// <summary>
        /// Fachada responsável por salvar a permissão de um determinado módulo ao perfil
        /// </summary>
        /// <param name="pm">Objeto ValueObjectLayer.Perfil_Modulo com os parâmetros preenchidos a ser cadastrados</param>
        /// <returns>Retorna true se a inserção tenha ocorrido ok</returns>
        public static bool SalvarPerfilModulo(ValueObjectLayer.Perfil_Modulo pm)
        {
            //return BusinessLayer.Administrador.Permissao.SalvarPerfilModulo(pm);
            if (dados.Equals("SqlServer"))
                return repositorioPermissaoSqlServer.SalvarPerfilModulo(pm);
            else
                return repositorioPermissaoSqlServer.SalvarPerfilModulo(pm); ;
        }
    }
}
