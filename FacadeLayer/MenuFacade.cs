//-----------------------------------------------------------------------
// <copyright file="MenuFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer
{
    using System.Collections.Generic;
    using Steto.ValueObjectLayer;
    using BusinessLayer.Administrador.SqlServer;

    /// <summary>
    /// Fachada padrão para o objeto Modulo
    /// </summary>
    public class MenuFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Repositório responsável pelos métodos da base
        /// </summary>
        static IRepositorioMenu repositorioMenu = new RepositorioMenu();

        /// <summary>
        /// Fachada que recupera Menu por Módulo
        /// </summary>
        /// <returns>Retorna uma lista com todos os menus por módulo</returns>
        public static IList<Menu> RecuperaMenuPorModulo(Modulo modulo)
        {
            return repositorioMenu.RecuperaMenuPorModulo(modulo);
        }

        /// <summary>
        /// Fachada que recupera Sub-Menu por Menu
        /// </summary>
        /// <returns>Retorna uma lista com todos os Sub-Menu por Menu</returns>
        public static IList<SubMenu> RecuperaSubMenuPorMenu(Menu menu)
        {
            return repositorioMenu.RecuperaSubMenuPorMenu(menu);
        }
    }
}
