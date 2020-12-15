//-----------------------------------------------------------------------
// <copyright file="IRepositorioMenu.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Administrador.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ValueObjectLayer;

    /// <summary>
    /// Interface padrão para o repositório Menu
    /// </summary>
    public interface IRepositorioMenu
    {
        /// <summary>
        /// Interface que recupera Menu por Módulo
        /// </summary>
        /// <returns>Retorna uma lista com todos os menus por módulo</returns>
        IList<Menu> RecuperaMenuPorModulo(Modulo modulo);

        /// <summary>
        /// Interface que recupera Sub-Menu por Menu
        /// </summary>
        /// <returns>Retorna uma lista com todos os Sub-Menu por Menu</returns>
        IList<SubMenu> RecuperaSubMenuPorMenu(Menu menu);
    }
}
