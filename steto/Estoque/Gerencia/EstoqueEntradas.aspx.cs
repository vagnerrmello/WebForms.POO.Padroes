using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Steto.FacadeLayer.Estoque;
using Steto.ValueObjectLayer;
using Steto.FacadeLayer;

namespace Amago.Web.Estoque.Gerencia
{
    public partial class EstoqueEntradas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PermissaoPagina();
            if (!Page.IsPostBack)
            {
                CarregaPerfis();
                //PreencheGridProdutoVazio();
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

            //GridPoduto.DataSource = produtos;
            //GridPoduto.DataBind();
            //GridPoduto.Rows[0].Cells[6].Enabled = false;
        }

        protected void DesabilitaCampos()
        {
            //ddlPerfil.Enabled = false;
            //txtNome.Enabled = false;
            //txtEmail.Enabled = false;
            //txtLogin.Enabled = false;
            //txtSenha.Enabled = false;
            //txtConfirmarSenha.Enabled = false;
            //btnSalvar.Visible = false;
        }

        protected void LimpaCampos()
        {
            txtEstoqueProdutoDescricao.Text = string.Empty;
            ddlEstoqueProdutoUnidadeMedida.SelectedValue = "0";
            txtEstoqueProdutoValorUnitario.Text = string.Empty;
            txtEstoqueProdutoQuantidadeMinima.Text = string.Empty;
            ChkConsumoInterno.Checked = false;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtEstoqueProdutoDescricao.Text) || string.IsNullOrEmpty(txtEstoqueProdutoValorUnitario.Text) ||
                    string.IsNullOrEmpty(txtEstoqueProdutoQuantidadeMinima.Text) || Convert.ToInt32(ddlEstoqueProdutoUnidadeMedida.SelectedValue) > 10)
                {
                    Usuario usuario = (Usuario)Session["UsuarioLogado"];
                    Produto produto = null;

                    produto = new Produto();
                    produto.Descricao = txtEstoqueProdutoDescricao.Text;
                    produto.UnidadeDeMedida = ddlEstoqueProdutoUnidadeMedida.SelectedValue;
                    produto.ValorUnitario = Convert.ToDecimal(txtEstoqueProdutoValorUnitario.Text);
                    produto.QuantidadeMinimaEstoque = Convert.ToDecimal(txtEstoqueProdutoQuantidadeMinima.Text);
                    produto.ConsumoInterno = (ChkConsumoInterno.Checked) ? 1 : 0;

                    int id = ProdutoFacade.CriarProduto(produto);
                    if (id > 0)
                    {
                        lblCodigo.Text = id.ToString();
                        string alerta1 = "Produto Inserido no Estoque Com Sucesso! ";
                        lblMsg.Text = alerta1;
                        LimpaCampos();


                    }
                }
                else
                {
                    string alerta1 = "Todos os campos são obrigatórios! ";
                    //Session["Msg"] = alerta1;
                    lblMsg.Text = alerta1;
                    //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
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
        
        protected void Redireciona()
        {
            Response.Redirect(@"~/Estoque/Gerencia/EstoqueEntrada.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
