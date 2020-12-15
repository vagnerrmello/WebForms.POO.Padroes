//-----------------------------------------------------------------------
// <copyright file="IRepositorioPermissaoSqlServer.cs" company="Steto">
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
    ///  Interface padrão para o repositório Permissao
    /// </summary>
    public interface IRepositorioPermissaoSqlServer
    {
        /// <summary>
        /// Interface responsável por recuperar as permissões da funcionalidade
        /// </summary>
        /// <param name="idFuncionalidade">Identificação da funcionalidade</param>
        /// <returns>Retorna uma lista de objeto do tipo ValueObjectLayer.Permissao_Funcionalidade</returns>
        IList<ValueObjectLayer.Permissao_Funcionalidade> RecuperaPermissaoPorFuncionalidade(int idFuncionalidade);

        /// <summary>
        /// Interface responsável por recuperar as permissões da funcionalidade pelo perfil
        /// </summary>
        /// <param name="idPerfil">Identidade do perfil</param>
        /// <returns>Retorna um objeto com uma lista de ValueObjectLayer.Perfil_Permissao_Funcionalidade</returns>
        IList<ValueObjectLayer.Perfil_Permissao_Funcionalidade> RecuperaPermissaoDaFuncionalidadePorPerfil(int idPerfil);

        /// <summary>
        /// Interface responsável por recuperar todas as permissões do perfil que existe para o usuário do sistema
        /// </summary>
        /// <param name="idPerfil">identificador do perfil do usuário no sistema</param>
        /// <returns>Retorna uma lista de objeto com os acessos deste perfil</returns>
        IList<ValueObjectLayer.CarregarPerfil> RecuperaTodasPermissoesPerfil(int idPerfil);

        /// <summary>
        /// Interface responsável para recuperar todas as permissões do perfil para popular a TreeView
        /// </summary>
        /// <param name="idPerfil">identificador do perfil do usuário no sistema</param>
        /// <returns>Retorna uma lista de objeto com os acessos deste perfil</returns>
        IList<ValueObjectLayer.CarregarPerfil> RecuperaTodasPermissoesPerfilTreeView(int idPerfil);

        /// <summary>
        /// Interface responsável por recuperar o perfil para montar o sub-menu
        /// </summary>
        /// <param name="idPerfil">identificador do perfil do usuário no sistema</param>
        /// <returns>Retorna uma lista de objeto com os acessos deste perfil</returns>
        IList<ValueObjectLayer.CarregarPerfil> RecuperaFuncionalidadesPerfil(int idPerfil);

        /// <summary>
        /// Interface responsável para recuperar os nomes das permissões relacionadas ao perfil
        /// </summary>
        /// <param name="idPerfil">Identificador do perfil</param>
        /// <returns>Retorna uma lista de objeto com as permissões deste perfil</returns>
        IList<ValueObjectLayer.CarregarPerfil> RecuperaPermissoes(int idPerfil);

        /// <summary>
        /// Interface responsável por permitir o salvamento das permissões para o perfil
        /// </summary>
        /// <param name="idPerfil">Identificador do perfil</param>
        /// <returns>Retorna um booleano se ok</returns>
        bool SalvarPermissaoPerfil(IList<ValueObjectLayer.CarregarPerfil> pmfps);

        /// <summary>
        /// Interface responsável por deletar as permissões e suas funcionalidades do perfil
        /// </summary>
        /// <param name="ppf">Recebe um objeto do tipo ValueObjectLayer.Perfil_Permissao_Funcionalidade</param>
        void DeletaPermissaoPerfil(ValueObjectLayer.Perfil_Permissao_Funcionalidade ppf);

        /// <summary>
        /// Interface responsável por deletar as permissões que o perfil tem em relação aos módulos do sistema
        /// </summary>
        /// <param name="idPerfil">Identificador do perfil</param>
        void DeletaPerfilModulo(ValueObjectLayer.Perfil_Modulo PerfilModulo);

        /// <summary>
        /// Interface responsável por deletar todas as permissões do perfil
        /// </summary>
        /// <param name="idPerfil">Identificador do perfil</param>
        void DeletaPerfilModulo(int idPerfil);

        /// <summary>
        /// Interface responsável por verificar se existe um determinado módulo cadastrado para um perfil
        /// </summary>
        /// <param name="perfilModulo">Objeto ValueObjectLayer.Perfil_Modulo que contém os dados identificadore para o Módulo e Perfil a ser pesquisados</param>
        /// <returns>Retorna true se a pesquisa encontrar um módulo cadastrado para o perfil</returns>
        bool RetornaPerfilModulo(ValueObjectLayer.Perfil_Modulo perfilModulo);

        /// <summary>
        /// Interface responsável por salvar a permissão de um determinado módulo ao perfil
        /// </summary>
        /// <param name="pm">Objeto ValueObjectLayer.Perfil_Modulo com os parâmetros preenchidos a ser cadastrados</param>
        /// <returns>Retorna true se a inserção tenha ocorrido ok</returns>
        bool SalvarPerfilModulo(ValueObjectLayer.Perfil_Modulo pm);
    }
}
