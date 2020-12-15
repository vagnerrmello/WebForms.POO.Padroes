using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Steto.ValueObjectLayer;

namespace Steto.Administrador
{
    public partial class StetoAdm : System.Web.UI.MasterPage
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
                    string nomeMenu = string.Empty;
                    int status1 = 1;
                    int status2 = 0;
                    int qtdItens = 0;
                    bool flagPesquisarUsu = false;
                    bool flagPesquisarPerfil = false;
                    foreach (ValueObjectLayer.CarregarPerfil func in perfisUsuario)
                    {
                        qtdItens++;

                        if (!func._Funcionalidade.Descricao.Equals(nomeMenu) && func._Modulo.Id == 1)
                        {
                            if (status2 == status1)
                            {
                                Menu2.Items.Add(item1);
                                status1++;
                            }

                            item1 = new MenuItem(func._Funcionalidade.Descricao);
                            nomeMenu = func._Funcionalidade.Descricao;
                            status1 = 0;
                        }
                        
                            if (func._Funcionalidade.Descricao.Equals("Usuário"))
                            {
                                if (func._Permissao.Nome.Equals("Editar"))
                                {
                                if (!flagPesquisarUsu)
                                {
                                    item1.ChildItems.Add(new MenuItem("Pesquisar", "Pesquisar", "", func._Funcionalidade.CaminhoPagina));
                                    flagPesquisarUsu = true;
                                }
                            }

                            if (func._Permissao.Nome.Equals("Cadastrar"))
                            {
                                item1.ChildItems.Add(new MenuItem("Novo", "Novo", "", @"~/Administrador/Usuario/UsuarioNovo.aspx"));
                                if (!flagPesquisarUsu)
                                {
                                    item1.ChildItems.Add(new MenuItem("Pesquisar", "Pesquisar", "", func._Funcionalidade.CaminhoPagina));
                                    flagPesquisarUsu = true;
                                }
                            }

                            if (func._Permissao.Nome.Equals("Visualizar"))
                            {
                                if (!flagPesquisarUsu)
                                {
                                    item1.ChildItems.Add(new MenuItem("Pesquisar", "Pesquisar", "", func._Funcionalidade.CaminhoPagina));
                                    flagPesquisarUsu = true;
                                }
                            }
                        }

                        if (func._Funcionalidade.Descricao.Equals("Perfil"))
                        {
                            if (func._Permissao.Nome.Equals("Editar"))
                            {
                                if (!flagPesquisarPerfil)
                                {
                                    item1.ChildItems.Add(new MenuItem("Pesquisar", "Pesquisar", "", func._Funcionalidade.CaminhoPagina));
                                    flagPesquisarPerfil = true;
                                }
                                item1.ChildItems.Add(new MenuItem("Permissões", "Permissões", "", @"~/Administrador/Perfil/PerfilPermissao.aspx"));
                            }

                            if (func._Permissao.Nome.Equals("Cadastrar"))
                            {
                                item1.ChildItems.Add(new MenuItem("Novo", "Novor", "", @"~/Administrador/Perfil/PerfilNovo.aspx"));
                                if (!flagPesquisarPerfil)
                                {
                                    item1.ChildItems.Add(new MenuItem("Pesquisar", "Pesquisar", "", func._Funcionalidade.CaminhoPagina));
                                    flagPesquisarPerfil = true;
                                }
                            }
                        }

                        if (func._Funcionalidade.Descricao.Equals("Configurações"))
                        {
                            if (func._Permissao.Nome.Equals("Editar"))
                            {
                                item1.ChildItems.Add(new MenuItem("Email", "Email", "", @"~/Administrador/Configuracoes/Email.aspx"));
                                item1.ChildItems.Add(new MenuItem("Empresa", "Empresa", "", @"~/Administrador/Configuracoes/Empresa.aspx"));
                            }
                        }

                        if (perfisUsuario.Count == qtdItens)
                        {
                            Menu2.Items.Add(item1);
                        }
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