using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Steto.ValueObjectLayer;
using Steto.FacadeLayer;
using Steto.Util.Mensagens;

namespace Steto.Administrador.Perfil
{
    public partial class PerfilPermissao : System.Web.UI.Page
    {
        IList<ValueObjectLayer.ConfigurarPerfilModulo> cPerfilModulo = new List<ValueObjectLayer.ConfigurarPerfilModulo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            bool permissao = PermissaoPagina();
            if (!Page.IsPostBack)
            {
                Tree.Attributes.Add("onclick", "OnTreeClick(event)");
                //Tree.Attributes.Add("onclick", "OnCheckBoxCheckChanged(event)"); 

                if (permissao)
                {
                    CarregarPagina();
                    CarregaArvore();
                    PercorreTreeView();
                }
                else
                {
                    Response.Redirect(@"~/Principal.aspx");
                }
            }
        }

        protected bool PermissaoPagina()
        {
            try
            {
                if (Session["PerfilFuncionalidades"] != null)
                {
                    List<ValueObjectLayer.CarregarPerfil> perfisUsuario = (List<ValueObjectLayer.CarregarPerfil>)Session["PerfilFuncionalidades"];

                    bool flagPermissaoPagina = false;
                    bool flagPerfilEditar = true;
                    foreach (ValueObjectLayer.CarregarPerfil funcionalidade in perfisUsuario)
                    {
                        if (funcionalidade._Funcionalidade.Descricao.Equals("Perfil"))
                        {
                            flagPermissaoPagina = true;
                            if (funcionalidade._Permissao.Nome.Equals("Editar"))
                            {
                                flagPerfilEditar = true;
                            }
                        }
                    }

                    if (!flagPermissaoPagina || !flagPerfilEditar)
                    {
                        Response.Redirect(@"~/Principal.aspx");
                    }
                    else
                    {
                        return true;
                    }

                    return false;
                }
                else
                {
                    Response.Redirect(@"~/Default.aspx");
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CarregarPagina()
        {
            CarregaPerfis();
        }

        protected void CarregaPerfis()
        {
            try
            {
                IList<ValueObjectLayer.Perfil> perfis = PerfilFacade.RecuperarPerfis(true);

                if (perfis != null)
                {
                    ddlPerfil.DataSource = perfis;
                    ddlPerfil.DataTextField = "Descricao";
                    ddlPerfil.DataValueField = "Id";
                    ddlPerfil.DataBind();
                }
                else
                {
                    Desabilita();
                    lblMsg.Text = MensagensValor.GetStringValue(Mensagem.PERFIL_NAO_EXISTENTE.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Desabilita()
        {
            btnSalvar.Visible = false;
            ddlPerfil.Enabled = false;
            Tree.Enabled = false;
        }

        /// <summary>
        /// Carregando todo o TreeView
        /// </summary>
        protected void CarregaArvore()
        {
            cPerfilModulo.Clear();
            Tree.ExpandDepth = 1;
            //CARREGANDO O TREEVIEW 
            for (int i = 0; i < 1; i++)
            {
                TreeNode masterNode = new TreeNode("Módulos");
                Tree.Nodes.Add(masterNode);

                //IList<TB_Modulo> modulos = ModuloFacade.RecuperaTodosOsModulos();
                IList<ValueObjectLayer.Modulo> modulos = ModuloFacade.RecuperaTodosOsModulos();

                //foreach (TB_Modulo modulo in modulos)
                foreach (ValueObjectLayer.Modulo modulo in modulos)
                {
                    //carregando o 1º nivel
                    TreeNode NodeModulo = new TreeNode();
                    NodeModulo.Text =  modulo.Nome;
                    NodeModulo.Value =  modulo.Id.ToString();
                    
                    cPerfilModulo.Add(new ConfigurarPerfilModulo(
                        Convert.ToInt32(ddlPerfil.SelectedValue), modulo.Id, false));
                    Tree.Nodes.Add(NodeModulo);
                    masterNode.ChildNodes.Add(NodeModulo);
                    //carregando o 2º nivel
                    IList<ValueObjectLayer.Funcionalidade> funcionalidades = FuncionalidadeFacade.RecuperaFuncionalidadesPorModulo(modulo.Id);
                    foreach (ValueObjectLayer.Funcionalidade funcionalidade in funcionalidades)
                    {
                        TreeNode childNode = new TreeNode();
                        childNode.Text = funcionalidade.Descricao;
                        childNode.Value = funcionalidade.Id.ToString();
                        NodeModulo.ChildNodes.Add(childNode);

                    //carregando o 3º nivel
                        IList<ValueObjectLayer.Permissao_Funcionalidade> permissoes = PermissaoFacade.RecuperaPermissaoPorFuncionalidade(funcionalidade.Id);
                        //foreach (TB_Permissao_Funcionalidade permissao in permissoes)
                        foreach (ValueObjectLayer.Permissao_Funcionalidade permissao in permissoes)
                        {
                            TreeNode childNodePerm = new TreeNode();
                            //switch (permissao.IdPermissao)
                            switch (permissao._Permissao.Id)
                            {
                                case 1:
                                        childNodePerm.Text = "Cadastrar";
                                        childNodePerm.Value = permissao.Id.ToString();
                                        break;
                                case 2:
                                        childNodePerm.Text = "Editar";
                                        childNodePerm.Value = permissao.Id.ToString();
                                        break;
                                case 3:
                                        childNodePerm.Text = "Inativar";
                                        childNodePerm.Value = permissao.Id.ToString();
                                        break;
                                case 4:
                                        childNodePerm.Text = "Visualizar";
                                        childNodePerm.Value = permissao.Id.ToString();
                                        break;
                                default:
                                    break;
                            }

                            childNode.ChildNodes.Add(childNodePerm);
                        }
                    }
                }
            }
            Session["ConfiguracaoPM"] = cPerfilModulo;
        }

        private void Invoca(TreeView tree)
        {
            foreach (TreeNode n in tree.Nodes)
            {
                n.Checked = false;
                LimpaCheckBoxes(n);
            }
        }

        private void LimpaCheckBoxes(TreeNode treeNode)
        {
            foreach (TreeNode n in treeNode.ChildNodes)
            {
                n.Checked = false;
                LimpaCheckBoxes(n);
            }
        }

        /// <summary>
        /// Recupera as funcionalidades por perfil
        /// </summary>
        protected void PercorreTreeView()
        {
            IList<ValueObjectLayer.CarregarPerfil> pmfps = PermissaoFacade.RecuperaTodasPermissoesPerfilTreeView(Convert.ToInt32(ddlPerfil.SelectedValue));
            //Tree.ExpandDepth = 4;
            Invoca(Tree);
            foreach (TreeNode node in Tree.Nodes)
            {
                string nodeTexto = node.Text;
                string nodeValor = node.Value;
                //Módulos
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    string isModuloTexto = node.ChildNodes[i].Text;
                    string isModuloValor = node.ChildNodes[i].Value;

                    //Funcionalidades
                    for (int x = 0; x < node.ChildNodes[i].ChildNodes.Count; x++)
                    {
                        string isFuncionalidadeTexto = node.ChildNodes[i].ChildNodes[x].Text;
                        string isFuncionalidadeValor = node.ChildNodes[i].ChildNodes[x].Value;
                        //Permissões
                        for (int y = 0; y < node.ChildNodes[i].ChildNodes[x].ChildNodes.Count; y++)
                        {
                            string isPermissaoTexto = node.ChildNodes[i].ChildNodes[x].ChildNodes[y].Text;
                            string isPermissaoValor = node.ChildNodes[i].ChildNodes[x].ChildNodes[y].Value;
                            if (pmfps != null)
                            {
                                foreach (ValueObjectLayer.CarregarPerfil pmfp in pmfps)
                                {
                                    //if (Convert.ToInt32(node.ChildNodes[i].Value) == pmfp.IdModulo &&
                                    //    Convert.ToInt32(node.ChildNodes[i].ChildNodes[x].Value) == pmfp.IdFuncionalidade &&
                                    //    Convert.ToInt32(node.ChildNodes[i].ChildNodes[x].ChildNodes[y].Value) == pmfp.IdPermissao)
                                    if (Convert.ToInt32(node.ChildNodes[i].Value) == pmfp._Modulo.Id &&
                                        Convert.ToInt32(node.ChildNodes[i].ChildNodes[x].Value) == pmfp._Funcionalidade.Id &&
                                        Convert.ToInt32(node.ChildNodes[i].ChildNodes[x].ChildNodes[y].Value) == pmfp._Permissao_Funcionalidade.Id)
                                    {
                                        node.Checked = true;
                                        node.ChildNodes[i].Checked = true;
                                        node.ChildNodes[i].ChildNodes[x].Checked = true;
                                        node.ChildNodes[i].ChildNodes[x].ChildNodes[y].Checked = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void ddlPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            PercorreTreeView();
        }

        protected void Salvar_PerfilModulo()
        {
            //IList<TB_Perfil_Modulo> listaPerfilModulo = new List<TB_Perfil_Modulo>();
            IList<ValueObjectLayer.Perfil_Modulo> listaPerfilModulo = new List<ValueObjectLayer.Perfil_Modulo>();

            try
            {
                PermissaoFacade.DeletaPerfilModulo(Convert.ToInt32(ddlPerfil.SelectedValue));

                foreach (TreeNode node in Tree.Nodes)
                {
                    string nodeTexto = node.Text;
                    string nodeValor = node.Value;
                    //Módulos
                    for (int i = 0; i < node.ChildNodes.Count; i++)
                    {
                        string isModuloTexto = node.ChildNodes[i].Text;
                        string isModuloValor = node.ChildNodes[i].Value;

                        if (node.ChildNodes[i].Checked)
                        {
                            //listaPerfilModulo.Add(
                            //    new TB_Perfil_Modulo(
                            //        Convert.ToInt32(node.ChildNodes[i].Value),
                            //        Convert.ToInt32(ddlPerfil.SelectedValue)));

                            listaPerfilModulo.Add(
                                new ValueObjectLayer.Perfil_Modulo(
                                    new ValueObjectLayer.Modulo(Convert.ToInt32(node.ChildNodes[i].Value)),
                                    new ValueObjectLayer.Perfil(Convert.ToInt32(ddlPerfil.SelectedValue))
                                    ));
                        }
                    }
                }

                if (listaPerfilModulo.Count > 0)
                {
                    //foreach (TB_Perfil_Modulo iPerfilModulo in listaPerfilModulo)
                    foreach (ValueObjectLayer.Perfil_Modulo iPerfilModulo in listaPerfilModulo)
                    {
                        PermissaoFacade.SalvarPerfilModulo(iPerfilModulo);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            //PerfilModuloFuncionalidadePermissao pmfp = new PerfilModuloFuncionalidadePermissao();
            //IList<PerfilModuloFuncionalidadePermissao> pmfps = new List<PerfilModuloFuncionalidadePermissao>();
            //IList<TB_Perfil_Modulo> perfilModulo = new List<TB_Perfil_Modulo>();
            //IList<ValueObjectLayer.Perfil_Modulo> perfilModulo = new List<ValueObjectLayer.Perfil_Modulo>();
                ////ValueObjectLayer.CarregarPerfil pmfp = new ValueObjectLayer.CarregarPerfil();            
            IList<ValueObjectLayer.CarregarPerfil> pmfps = new List<ValueObjectLayer.CarregarPerfil>();

            bool chekModulo = false;
            bool checkFuncionalidade = false;
            bool checkPermissao = false;

            try
            {

                if (PermissaoPagina())
                {

                    foreach (TreeNode node in Tree.Nodes)
                    {
                        string nodeTexto = node.Text;
                        string nodeValor = node.Value;
                        //Módulos
                        for (int i = 0; i < node.ChildNodes.Count; i++)
                        {
                            string isModuloTexto = node.ChildNodes[i].Text;
                            string isModuloValor = node.ChildNodes[i].Value;
                            if (node.ChildNodes[i].Checked)
                            {
                                chekModulo = node.ChildNodes[i].Checked;
                            }
                            //Funcionalidades
                            for (int x = 0; x < node.ChildNodes[i].ChildNodes.Count; x++)
                            {
                                string isFuncionalidadeTexto = node.ChildNodes[i].ChildNodes[x].Text;
                                string isFuncionalidadeValor = node.ChildNodes[i].ChildNodes[x].Value;
                                if (node.ChildNodes[i].ChildNodes[x].Checked)
                                {
                                    checkFuncionalidade = node.ChildNodes[i].ChildNodes[x].Checked;
                                }
                                //Permissões
                                for (int y = 0; y < node.ChildNodes[i].ChildNodes[x].ChildNodes.Count; y++)
                                {
                                    string isPermissaoTexto = node.ChildNodes[i].ChildNodes[x].ChildNodes[y].Text;
                                    string isPermissaoValor = node.ChildNodes[i].ChildNodes[x].ChildNodes[y].Value;

                                    if (node.ChildNodes[i].ChildNodes[x].ChildNodes[y].Checked)
                                    {
                                        checkPermissao = node.ChildNodes[i].ChildNodes[x].ChildNodes[y].Checked;
                                        //pmfp.IdPerfil = Convert.ToInt32(ddlPerfil.SelectedValue);
                                        //pmfp.IdModulo = Convert.ToInt32(node.ChildNodes[i].Value);
                                        //pmfp.IdFuncionalidade = Convert.ToInt32(node.ChildNodes[i].ChildNodes[x].Value);
                                        //pmfp.IdPermissao = Convert.ToInt32(node.ChildNodes[i].ChildNodes[x].ChildNodes[y].Value);
                                        ////pmfp._Perfil.Id = Convert.ToInt32(ddlPerfil.SelectedValue);
                                        ////pmfp._Modulo.Id = Convert.ToInt32(node.ChildNodes[i].Value);
                                        ////pmfp._Funcionalidade.Id = Convert.ToInt32(node.ChildNodes[i].ChildNodes[x].Value);
                                        ////pmfp._Permissao.Id = Convert.ToInt32(node.ChildNodes[i].ChildNodes[x].ChildNodes[y].Value);
                                        //pmfps.Add(new PerfilModuloFuncionalidadePermissao(
                                        //                                                    pmfp.IdPerfil,
                                        //                                                    pmfp.IdModulo,
                                        //                                                    pmfp.IdFuncionalidade,
                                        //                                                    pmfp.IdPermissao));
                                        //ValueObjectLayer.Permissao_Funcionalidade pfun = new ValueObjectLayer.Permissao_Funcionalidade();
                                        pmfps.Add(
                                            new ValueObjectLayer.CarregarPerfil(
                                                new ValueObjectLayer.Perfil(Convert.ToInt32(ddlPerfil.SelectedValue)),
                                                new ValueObjectLayer.Modulo(Convert.ToInt32(node.ChildNodes[i].Value)),
                                                new ValueObjectLayer.Funcionalidade(Convert.ToInt32(node.ChildNodes[i].ChildNodes[x].Value)),
                                                new ValueObjectLayer.Permissao_Funcionalidade(),
                                                new ValueObjectLayer.Permissao(Convert.ToInt32(node.ChildNodes[i].ChildNodes[x].ChildNodes[y].Value))
                                            ));
                                    }
                                }
                            }
                        }
                    }

                    if (pmfps.Count > 0)
                    {
                        if (PermissaoFacade.SalvarPermissaoPerfil(pmfps))
                        {
                            lblMsg.Text = MensagensValor.GetStringValue(Mensagem.PERMISSAO.ToString());
                        }
                        else
                        {
                            lblMsg.Text = MensagensValor.GetStringValue(Mensagem.PERMISSAO_NAO_REALIZADA.ToString());
                        }
                    }
                    else
                    {
                        //TB_Perfil_Permissao_Funcionalidade ppf = new TB_Perfil_Permissao_Funcionalidade();
                        ValueObjectLayer.Perfil_Permissao_Funcionalidade ppf = new ValueObjectLayer.Perfil_Permissao_Funcionalidade();
                        ppf._Perfil = new ValueObjectLayer.Perfil(Convert.ToInt32(ddlPerfil.SelectedValue));
                        PermissaoFacade.DeletaPermissaoPerfil(ppf);
                    }
                    PercorreTreeView();
                    Salvar_PerfilModulo();
                }
                else
                {
                    Response.Redirect(@"~/Principal.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}