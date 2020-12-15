using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Steto.ValueObjectLayer;
using Steto.FacadeLayer;

namespace Steto.Estoque
{
    public partial class ViknCadastro : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Permissoes();
        }

        protected void Permissoes()
        {
            try
            {
                if (Session["PerfilFuncionalidades"] != null)
                {
                    IList<ValueObjectLayer.Modulo> modulos = (IList<ValueObjectLayer.Modulo>)Session["Modulos"];
                    IList<MenuItem> itensMenu = new List<MenuItem>();
                    foreach (ValueObjectLayer.Modulo modulo in modulos)
                    {
                        itensMenu.Add(new MenuItem(modulo.Nome, modulo.Nome, "", modulo.CaminhoPagina));
                    }
                    foreach (MenuItem item in itensMenu)
                    {
                        MenuPrincipal.Items.Add(item);
                    }

                    List<ValueObjectLayer.CarregarPerfil> perfisUsuario = (List<ValueObjectLayer.CarregarPerfil>)Session["PerfilFuncionalidades"];
                    IList<MenuItem> itensMenuFuncionalidades = new List<MenuItem>();
                    IList<MenuItem> itensMenuFuncionalidadesFilho = new List<MenuItem>();

                    MenuItem item1 = null;
                    bool blTemPefil = false;

                    Modulo isModulo = null;
                    foreach (ValueObjectLayer.CarregarPerfil func in perfisUsuario)
                    {
                        if (func._Modulo.Nome.Equals("Cadastro"))
                        {
                            blTemPefil = true;
                            isModulo = new Modulo(func._Modulo.Id);
                        }
                    }

                    if (blTemPefil)
                    {

                        if (isModulo != null)
                        {
                            IList<ValueObjectLayer.Menu> lstMenu = MenuFacade.RecuperaMenuPorModulo(isModulo);

                            foreach (var menu in lstMenu)
                            {
                                item1 = new MenuItem(menu.Descricao, "", "", menu.CaminhoPagina);

                                IList<SubMenu> lstSubMenu = MenuFacade.RecuperaSubMenuPorMenu(menu);
                                if (lstSubMenu.Count > 0)
                                {
                                    foreach (var submenu in lstSubMenu)
                                    {
                                        item1.ChildItems.Add(new MenuItem(submenu.Descricao, "", "", submenu.CaminhoPagina));
                                    }
                                }

                                Menu2.Items.Add(item1);
                            }
                        }

                    }
                    else
                    {
                        Response.Redirect(@"~/Default.aspx");
                    }
                }
                else
                {
                    Response.Redirect(@"~/Default.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}