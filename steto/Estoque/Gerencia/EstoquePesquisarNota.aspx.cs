using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using Steto.FacadeLayer.Estoque;
using Steto.ValueObjectLayer;
using Steto.FacadeLayer;

namespace Amago.Web.Estoque.Gerencia
{
    public partial class EstoquePesquisarNota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PermissaoPagina();
            if (!Page.IsPostBack)
            {
                Usuario usuario = (Usuario)Session["UsuarioLogado"];
                Steto.ValueObjectLayer.Empresa empresa = EmpresaFacade.RecuperaEmpresa(new Steto.ValueObjectLayer.Empresa());
                lblEmpresaCodigo.Text = string.Empty;
                lblEmpresa.Text = empresa.Nome;
                lblEmpresaCodigo.Text = empresa.Id.ToString();

                InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {
            DesabilitaCampos();
            lblResultadoPesquisa.Visible = false;
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
                        if (funcionalidade._Funcionalidade.Descricao.Equals("Usuário"))
                        {
                            flagPermissaoPagina = true;

                            if (funcionalidade._Permissao.Nome.Equals("Cadastrar"))
                            {
                                flagUsuEditar = true;
                            }

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

        protected void PreencheGridVazio()
        {
            Nota nota = new Nota(0);
            nota.NumeroDocumento = "0";
            nota.Vencimento = DateTime.Now;
            nota.Valor = 0;
            IList<Nota> lstNotas = new List<Nota>();
            lstNotas.Add(nota);

            GridPesquisa.DataSource = lstNotas;
            GridPesquisa.DataBind();
            GridPesquisa.Rows[0].Cells[4].Enabled = false;
        }

        protected void HabilitaCampos()
        {
            txtEstoqueNumeroNota.Text = string.Empty;
            txtEstoqueNumeroNota.Enabled = true;

            txtEstoqueNotaDataPagamento.Text = string.Empty;
            txtEstoqueNotaDataPagamento.Enabled = true;
        }

        protected void DesabilitaCampos()
        {
            txtEstoqueNumeroNota.Text = string.Empty;
            txtEstoqueNotaDataPagamento.Text = string.Empty;
        }

        protected void ReloadBtnPesquisa()
        {
            //Produto produto = new Produto();
            //produto.Descricao = (txtDescricaoPesquisa.Text != string.Empty) ? txtDescricaoPesquisa.Text : string.Empty;
            //produto.ConsumoInterno = Convert.ToInt32(ddlEstoqueProduto.SelectedValue);
            //produto.Empresa = new Steto.ValueObjectLayer.Empresa(Convert.ToInt32(lblEmpresaCodigo.Text));

            //IList<Produto> lstProdutos = ProdutoFacade.RecuperarProduto(produto);

            //if (lstProdutos.Count > 0)
            //{
            //    GridPoduto.DataSource = lstProdutos;
            //    GridPoduto.DataBind();
            //}
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEstoqueNumeroNota.Text) || !string.IsNullOrEmpty(txtEstoqueNotaDataPagamento.Text))
            {
                Nota nota = new Nota();
                nota.NumeroDocumento = (txtEstoqueNumeroNota.Text != string.Empty) ? txtEstoqueNumeroNota.Text : string.Empty;
                if (txtEstoqueNotaDataPagamento.Text != string.Empty){ nota.Vencimento = Convert.ToDateTime(txtEstoqueNotaDataPagamento.Text); }

                IList<Nota> lstNotas =  NotaFacade.RecuperaNotas(nota);





                if (lstNotas.Count > 0)
                {
                    GridPesquisa.DataSource = lstNotas;
                    GridPesquisa.DataBind();
                }
                else
                {
                    string alerta1 = "Nenhuma lstNotas Encontrada Com Os Critéiros de Pesquisas! ";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                }
            }
            else
            {
                string alerta1 = "Você Precisa Inserir Algum Critéiro Para Pesquisa! ";
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
            }
        }

        protected void btnLimpaPesquisa_Click(object sender, EventArgs e)
        {
            txtEstoqueNumeroNota.Text = string.Empty;
            txtEstoqueNotaDataPagamento.Text = string.Empty;
            PreencheGridVazio();
        }



        protected void GridPesquisa_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            Nota nota = new Nota(Convert.ToInt32(GridPesquisa.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim()));
            nota.NumeroDocumento = Convert.ToString(GridPesquisa.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.Trim());
            Usuario usuario = (Usuario)Session["UsuarioLogado"];

            if (e.CommandName.Equals("Editar"))
            {
                Session["NotaParaEdicao"] = NotaFacade.VerificaNotaExistente(nota);
                //Response.Redirect(@"~/Estoque/Gerencia/EstoqueNotaEdicao.aspx");
                Response.Redirect(@"~/Estoque/Gerencia/EstoqueNota.aspx");
            }
        }

        protected void Redirect(string url, string target, string windowFeatures)
        {
            if ((String.IsNullOrEmpty(target) || target.Equals("_self", StringComparison.OrdinalIgnoreCase)) && String.IsNullOrEmpty(windowFeatures))
            {
                Response.Redirect(url);
            }
            else
            {
                Page page = (Page)HttpContext.Current.Handler;

                if (page == null)
                {
                    throw new InvalidOperationException("Cannot redirect to new window outside Page context.");
                }
                url = page.ResolveClientUrl(url);

                string script;
                if (!String.IsNullOrEmpty(windowFeatures))
                {
                    script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
                }
                else
                {
                    script = @"window.open(""{0}"", ""{1}"");";
                }
                script = String.Format(script, url, target, windowFeatures);
                ScriptManager.RegisterStartupScript(page, typeof(Page), "Redirect", script, true);
            }
        }

    }
}