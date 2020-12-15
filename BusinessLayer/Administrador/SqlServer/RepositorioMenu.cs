//-----------------------------------------------------------------------
// <copyright file="RepositorioMenu.cs" company="Steto">
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
    using Steto.BusinessLayer;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Classe de repositório que persiste/consulta as informações para montagem de menu por módulo
    /// </summary>
    public class RepositorioMenu : IRepositorioMenu
    {
        /// <summary>
        /// Método que recupera Menu por Módulo
        /// </summary>
        /// <returns>Retorna uma lista com todos os menus por módulo</returns>
        public IList<Menu> RecuperaMenuPorModulo(Modulo modulo)
        {
            SqlCommand cmd = null;
            IList<Menu> listaMenus = new List<Menu>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select Id, Descricao, IdModulo, CaminhoPagina From TB_Menu  " +
                                    "Where IdModulo = @varIdModulo";

                cmd.Parameters.AddWithValue("@varIdModulo", modulo.Id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Menu menu = new Menu(Convert.ToInt32(reader["Id"]));
                        menu.Descricao = Convert.ToString(reader["Descricao"]);
                        menu.Modulo = new Modulo(Convert.ToInt32(reader["IdModulo"]));
                        menu.CaminhoPagina = Convert.ToString(reader["CaminhoPagina"]);

                        listaMenus.Add(menu);
                    }
                }

                return (listaMenus.Count > 0) ? listaMenus : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        /// <summary>
        /// Método que recupera Sub-Menu por Menu
        /// </summary>
        /// <returns>Retorna uma lista com todos os Sub-Menu por Menu</returns>
        public IList<SubMenu> RecuperaSubMenuPorMenu(Menu menu)
        {
            SqlCommand cmd = null;
            IList<SubMenu> listaSubMenus = new List<SubMenu>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select Id, Descricao, IdMenu, CaminhoPagina From TB_MenuSubMenu  " +
                                    "Where IdMenu = @varIdModulo";

                cmd.Parameters.AddWithValue("@varIdModulo", menu.Id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SubMenu isSubMenu = new SubMenu(Convert.ToInt32(reader["Id"]));
                        isSubMenu.Descricao = Convert.ToString(reader["Descricao"]);
                        isSubMenu.Menu = new Menu(Convert.ToInt32(reader["IdMenu"]));
                        isSubMenu.CaminhoPagina = Convert.ToString(reader["CaminhoPagina"]);

                        listaSubMenus.Add(isSubMenu);
                    }
                }

                return (listaSubMenus.Count > 0) ? listaSubMenus : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        ///// <summary>
        ///// Método que recupera Menu por Módulo
        ///// </summary>
        ///// <returns>Retorna uma lista com todos os menus por módulo</returns>
        //public IList<Menu> RecuperaMenuPorModulo(Modulo modulo)
        //{
        //    SqlCommand cmd = null;
        //    IList<Menu> listaMenus = new List<Menu>();

        //    try
        //    {
        //        cmd = Factory.AcessoDados();

        //        cmd.CommandText = "Select mo.Nome As modulo, me.Descricao As Menu, sm.Descricao As SubMenu, sm.CaminhoPagina From TB_Modulos mo, TB_Menu me, TB_MenuSubMenu sm " +
        //                            "Where me.IdModulo = mo.Id " +
        //                            "And sm.IdMenu = me.Id " +
        //                            "And mo.Id = @varIdModulo";

        //        cmd.Parameters.AddWithValue("@varIdModulo", modulo.Id);

        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                Menu menu = new Menu();
        //                menu.Descricao = Convert.ToString(reader["Menu"]);
        //                Modulo isModulo = new Modulo();
        //                isModulo.Nome = Convert.ToString(reader["modulo"]);
        //                SubMenu submenu = new SubMenu();
        //                submenu.Descricao = Convert.ToString(reader["SubMenu"]);
        //                submenu.CaminhoPagina = Convert.ToString(reader["CaminhoPagina"]);
        //                menu.Modulo = isModulo;
        //                menu.SubMenu = submenu;

        //                listaMenus.Add(menu);
        //            }
        //        }

        //        return (listaMenus.Count > 0) ? listaMenus : null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (cmd != null) cmd.Dispose();
        //    }
        //}

    }
}
