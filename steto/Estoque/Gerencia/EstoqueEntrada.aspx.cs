using System;
using System.Collections.Generic;
using System.Web.UI;
using Steto.ValueObjectLayer;
using Steto.FacadeLayer.Estoque;
using Steto.FacadeLayer;

namespace Amago.Web.Estoque.Gerencia
{
    public partial class EstoqueEntrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PermissaoPagina();
            if (!Page.IsPostBack)
            {
                CarregaPerfis();
                PreencheGridProdutoVazio();
                MultiViewProduto.Visible = false;
                PreencheGridProdutoVazio();
                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                DesabilitaCampos();
            }
        }

        protected bool PermissaoPagina()
        {
            try
            {
                if (Session["PerfilFuncionalidades"] != null)
                {
                    List<CarregarPerfil> perfisUsuario = (List<CarregarPerfil>)Session["PerfilFuncionalidades"];
                    bool flagPermissaoPagina = false;
                    bool flagUsuEditar = false;
                    foreach (CarregarPerfil funcionalidade in perfisUsuario)
                    {
                        //if (funcionalidade.NomeFuncionalidade.Equals("Usuário"))
                        if (funcionalidade._Funcionalidade.Descricao.Equals("Usuário"))
                        {
                            flagPermissaoPagina = true;
                            //if (funcionalidade.NomePermissao.Equals("Cadastrar"))
                            if (funcionalidade._Permissao.Nome.Equals("Cadastrar"))
                            {
                                flagUsuEditar = true;
                            }

                            //if (funcionalidade.NomePermissao.Equals("Visualizar") && !flagUsuEditar)
                            if (funcionalidade._Permissao.Nome.Equals("Visualizar") && !flagUsuEditar)
                            {
                                DesabilitaCampos();
                            }
                        }
                    }

                    if (!flagPermissaoPagina)
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

        protected void PreencheGridProdutoVazio()
        {
            Produto produto = new Produto(0);
            produto.Descricao = "";
            produto.ValorUnitario = Convert.ToDecimal("0,00");
            produto.QuantidadeRealEstoque = 0;
            produto.ValorTotal = produto.ValorUnitario * produto.QuantidadeRealEstoque;
            produto.QuantidadeMinimaEstoque = 0;

            IList<Produto> produtos = new List<Produto>();
            produtos.Add(produto);
        }

        protected void DesabilitaCampos()
        {
            txtEstoqueProdutoDescricao.Enabled = false;
            ddlEstoqueProdutoUnidadeMedida.Enabled = false;
            txtEstoqueProdutoValorUnitario.Enabled = false;
            txtEstoqueProdutoQuantidadeMinima.Enabled = false;
            ChkConsumoInterno.Enabled = false;
        }

        protected void HabilitaCampos()
        {
            txtEstoqueProdutoDescricao.Enabled = true;
            ddlEstoqueProdutoUnidadeMedida.Enabled = true;
            txtEstoqueProdutoValorUnitario.Enabled = true;
            txtEstoqueProdutoQuantidadeMinima.Enabled = true;
            ChkConsumoInterno.Enabled = true;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtEstoqueProdutoDescricao.Text) || string.IsNullOrEmpty(txtEstoqueProdutoValorUnitario.Text) ||
                    string.IsNullOrEmpty(txtEstoqueProdutoQuantidadeMinima.Text) || Convert.ToInt32(ddlEstoqueProdutoUnidadeMedida.SelectedValue) > 10)
                {
                    Usuario usuario = (Usuario)Session["UsuarioLogado"];
                    Empresa empresa = EmpresaFacade.RecuperaEmpresa(new Empresa());
                    Produto produto = null;

                    produto = new Produto();
                    produto.Descricao = txtEstoqueProdutoDescricao.Text;
                    produto.UnidadeDeMedida = ddlEstoqueProdutoUnidadeMedida.SelectedValue;
                    produto.ValorUnitario = Convert.ToDecimal(txtEstoqueProdutoValorUnitario.Text);
                    produto.QuantidadeMinimaEstoque = Convert.ToDecimal(txtEstoqueProdutoQuantidadeMinima.Text);
                    produto.ConsumoInterno = (ChkConsumoInterno.Checked) ? 1 : 0;


                    int id = ProdutoFacade.CriarProduto(produto);

                    lblCodigo.Text = id.ToString();

                    if (id > 0)
                    {
                        produto.Id = id;
                        Produto ObjProduto = ProdutoFacade.RecuperarUmProduto(produto);
                        IList<Produto> produtos = new List<Produto>();
                        produtos.Add(ObjProduto);

                        if (produtos.Count > 0)
                        {
                            GridProduto.DataSource = produtos;
                            GridProduto.DataBind();
                        }
                    }
                }
                else
                {
                    string alerta1 = "Todos os campos são obrigatórios! ";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CarregaPerfis()
        {
            //IList<ValueObjectLayer.Perfil> perfis = PerfilFacade.RecuperarPerfis(true);
            //ValueObjectLayer.Perfil perfil = new ValueObjectLayer.Perfil();
            //perfil.Id = 0;
            //perfil.Descricao = "Nenhum";
            //perfis.Add(perfil);

            //if (perfis != null)
            //{
            //    ddlPerfil.DataSource = perfis;
            //    ddlPerfil.DataTextField = "Descricao";
            //    ddlPerfil.DataValueField = "Id";
            //    ddlPerfil.DataBind();
            //    ddlPerfil.SelectedValue = "0";
            //}
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Administrador/Usuario/UsuarioPesquisa.aspx");
        }

        protected void btnAlterarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDescricaoProdutoAlterar.Text) || string.IsNullOrEmpty(txtValorUnitarioAlterar.Text) ||
                    string.IsNullOrEmpty(txtQuantidadeMinimoAlterar.Text) || Convert.ToInt32(ddlUnidadeMedidaAlterar.SelectedValue) > 10)
                {
                    Usuario usuario = (Usuario)Session["UsuarioLogado"];
                    Empresa empresa = EmpresaFacade.RecuperaEmpresa(new Empresa());
                    Produto produto = null;

                    produto = new Produto(Convert.ToInt32(lblCodigoAlterar.Text));
                    produto.Descricao = txtDescricaoProdutoAlterar.Text;
                    produto.UnidadeDeMedida = ddlUnidadeMedidaAlterar.SelectedValue;
                    produto.ValorUnitario = Convert.ToDecimal(txtValorUnitarioAlterar.Text);
                    produto.QuantidadeMinimaEstoque = Convert.ToDecimal(txtQuantidadeMinimoAlterar.Text);
                    produto.ConsumoInterno = (chkConsumoInternoAlterarProduto.Checked) ? 1 : 0;

                    if(ProdutoFacade.AlteraProduto(produto))
                    {
                        string alerta1 = "Produto atualizado com sucesso! ";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                    }
                    else
                    {
                        string alerta1 = "Falha ao tentar atualizar o Produto! ";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                    }
                }
                else
                {
                    string alerta1 = "Todos os campos são obrigatórios! ";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelarAlterarProduto_Click(object sender, EventArgs e)
        {
            MultiViewProduto.Visible = false;
        }

        protected void GridProdutoNota_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiViewProduto.Visible = true;
            MultiViewProduto.ActiveViewIndex = 0;
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!txtProdutoPesquisa.Text.Equals(""))
            {
                Usuario usuario = (Usuario)Session["UsuarioLogado"];
                Produto produto = new Produto();
                if(Steto.Util.Validacao.IsNumeric(txtProdutoPesquisa.Text))
                    produto.Id = Convert.ToInt32(txtProdutoPesquisa.Text);

                produto.Descricao = txtProdutoPesquisa.Text;
                Empresa empresa = new Empresa();

                IList<Produto> produtos = ProdutoFacade.RecuperarProduto(produto);

                IList<Produto> lstProdutos = new List<Produto>();
                foreach (var item in produtos)
                {
                    Steto.ValueObjectLayer.Estoque isEstoque = new Steto.ValueObjectLayer.Estoque();
                    isEstoque.Produto = item;
                    isEstoque = EstoqueFacade.RecuperarProdutoNoEstoque(isEstoque);
                    if (isEstoque != null)
                        lstProdutos.Add(isEstoque.Produto);
                    else
                        lstProdutos.Add(item);
                }
                
                if (lstProdutos.Count > 0)
                {
                    GridProduto.DataSource = lstProdutos;
                    GridProduto.DataBind();
                }
                else
                {
                    string alerta1 = "Nenhum Fornecedor encontrado para este critério de pesquisa! ";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                }
            }
            else
            {
                string alerta1 = "Digite o nome do Fornecedor para pesquisar! ";
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
            }
        }

        protected void btnLimpaPesquisa_Click(object sender, EventArgs e)
        {
            txtProdutoPesquisa.Text = string.Empty;
        }

        protected void GridProduto_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int idProduto = Convert.ToInt32(GridProduto.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim());

            if (e.CommandName.Equals("Editar"))
            {
                Usuario usuario = (Usuario)Session["UsuarioLogado"];
                Empresa empresa = EmpresaFacade.RecuperaEmpresa(new Empresa());
                Produto produto = new Produto(idProduto);

                IList<Produto> produtos = ProdutoFacade.RecuperarProduto(produto);
                lblCodigoAlterar.Text = produtos[0].Id.ToString();
                txtDescricaoProdutoAlterar.Text = produtos[0].Descricao;
                ddlUnidadeMedidaAlterar.SelectedValue = produtos[0].UnidadeDeMedida;
                txtValorUnitarioAlterar.Text = produtos[0].ValorUnitario.ToString() ;
                txtQuantidadeMinimoAlterar.Text = produtos[0].QuantidadeMinimaEstoque.ToString();
                chkConsumoInternoAlterarProduto.Checked = (produtos[0].ConsumoInterno == 1)? true : false;

                MultiViewProduto.Visible = true;
                MultiViewProduto.ActiveViewIndex = 0;
            }

            if (e.CommandName.Equals("Desativar"))
            {
                decimal ExisteEstoque = Convert.ToDecimal(GridProduto.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.Trim());
                if(ExisteEstoque > 0)
                {
                    lblMensagemDesativar.Text = "Produto NÃO pode ser desativado! O produto EXISTE NO ESTOQUE!";
                    lblMensagemDesativar.ForeColor = System.Drawing.Color.Red;
                    btnConfirmarExclusaoProduto.Visible = false;
                }
                else
                {
                    lblMensagemDesativar.Text = "Tem certeza que deseja EXCLUIR o Produto?";
                    lblMensagemDesativar.ForeColor = System.Drawing.Color.Black;
                    btnConfirmarExclusaoProduto.Visible = true;
                }

                lblCodigoProdutoExclusao.Text = idProduto.ToString();
                lblDescricaoProdutoExclusao.Text = GridProduto.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.Trim();

                MultiViewProduto.Visible = true;
                MultiViewProduto.ActiveViewIndex = 1;
            }
        }

        protected void btnCancelarExcluirProduto_Click(object sender, EventArgs e)
        {
            MultiViewProduto.Visible = false;
        }

        protected void btnConfirmarExclusaoProduto_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto(Convert.ToInt32(lblCodigoProdutoExclusao.Text));

            string alerta1 = string.Empty;
            if (ProdutoFacade.DesativarProduto(produto))
            {
                alerta1 = "Produto DESATIVADO com Sucesso! ";
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                //MultiViewProduto.ActiveViewIndex = 0;
            }
            else
            {
                alerta1 = "FALHA ao tentar desativar o Produto " + lblDescricaoProdutoExclusao.Text;
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
            }
        }

        protected void btnNovoProduto_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            HabilitaCampos();
        }
    }
}