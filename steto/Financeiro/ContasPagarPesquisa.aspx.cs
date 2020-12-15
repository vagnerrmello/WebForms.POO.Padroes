using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Steto.FacadeLayer.Estoque;
using Steto.Util;
using Steto.ValueObjectLayer;
using Steto.FacadeLayer;

namespace Amago.Web.Estoque.Gerencia
{
    public partial class ContasPagarPesquisa : System.Web.UI.Page
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

                //InicializaPagina();
            }
        }

        protected void InicializaPagina()
        {
            //ReloadBtnPesquisa();
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
                                //DesabilitaCampos();
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
            produto.ValorUnitario = Convert.ToDecimal("0");
            produto.QuantidadeRealEstoque = 0;
            produto.ValorTotal = 0;
            produto.QuantidadeMinimaEstoque = 0;

            IList<Produto> produtos = new List<Produto>();
            produtos.Add(produto);

            GridContas.DataSource = produtos;
            GridContas.DataBind();
            GridContas.Rows[0].Cells[5].Enabled = false;
        }

        protected void ReloadBtnPesquisa()
        {
            Nota nota = new Nota();



        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescricaoPesquisa.Text))
            {
                Nota nota = new Nota();

                IList<Nota> lsGridtNotas = new List<Nota>();
    

                if (lsGridtNotas.Count > 0)
                {
                    GridContas.DataSource = lsGridtNotas;
                    GridContas.DataBind();
                }
                else
                {
                    string alerta1 = "Nenhum Produto Encontrado Com Os Critéiros de Pesquisas! ";
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
            txtDescricaoPesquisa.Text = string.Empty;
            PreencheGridProdutoVazio();
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

        protected void GridContas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Editar"))
            {
                Nota nota = new Nota(Convert.ToInt32(GridContas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim()));
                nota.NumeroDocumento = Convert.ToString(GridContas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.Trim());
                Usuario usuario = (Usuario)Session["UsuarioLogado"];

                Session["NotaParaEdicao"] = NotaFacade.VerificaNotaExistente(nota);
                Response.Redirect(@"~/Estoque/Gerencia/EstoqueNotaEdicao.aspx");
            }

            if (e.CommandName.Equals("Duplicar"))
            {
                LblDuplicarTituloCodigoConta.Text = GridContas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim();
                LblDuplicarTituloNumero.Text = GridContas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.Trim();
                lblDataVencimento.Text = GridContas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text.Trim();
                lblDuplicarValorDocumento.Text = GridContas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text.Trim();

                MPEDuplicata.Show();
            }

            if (e.CommandName.Equals("Comprovante"))
            {
                lblCodigo.Text = GridContas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim();
                lblTitulo.Text = GridContas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.Trim();
                lblParcela.Text = GridContas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.Trim();
                lblVencimento.Text = GridContas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text.Trim();
                lblValor.Text = GridContas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text.Trim();
                lblPagoSN.Text = GridContas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text.Trim();

                if (lblPagoSN.Text.Equals("N"))
                {
                    btnBaixarTitulo.BackColor = System.Drawing.Color.Red;
                    btnBaixarTitulo.Text = "Baixar?";
                }
                else
                {
                    btnBaixarTitulo.BackColor = System.Drawing.Color.DodgerBlue;
                    btnBaixarTitulo.Text = "Baixado";
                }

                string diretorio = MapPath(@"~\Imagens\Comprovante\");
                string strUrl = diretorio + "Comprovante" + lblCodigo.Text + "." + lblEmpresaCodigo.Text + ".jpg";
                if (File.Exists(strUrl))
                {
                    imgNota.ImageUrl = "~/Imagens/Comprovante/" + "Comprovante" + lblCodigo.Text + "." + lblEmpresaCodigo.Text + ".jpg";
                    imgNota.Enabled = true;
                }
                else
                {
                    imgNota.ImageUrl = "~/imagens/invoice_icon.jpg";
                    imgNota.Enabled = false;
                }

                ModalPopupExtender1.Show();
            }
        }

        protected void resumeupload(Object sender, EventArgs e)

        {
            salvaArquivo();

            imgNota.ImageUrl = "~/Imagens/Comprovante/" + "Comprovante" + lblCodigo.Text + "." + lblEmpresaCodigo.Text + ".jpg";
            imgNota.Visible = true;

            ModalPopupExtender1.Show();
        }

        protected void lnkupclick(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow gvrow = lnk.NamingContainer as GridViewRow;

            //int id = Int32.Parse(GridContas.DataKeys[gvrow.RowIndex].Value.ToString());
            int id = Int32.Parse(GridContas.Rows[1].Cells[0].Text);
            //HiddenField1.Value = id.ToString();
            ModalPopupExtender1.Show();

        }


        protected void GridContas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gvr = e.Row;

            switch (gvr.RowType)
            {
                case DataControlRowType.DataRow:
                    {
                        //e.Row.Cells[e.Row.Cells.Count - 1].Enabled = true;

                        if (gvr.Cells[5].Text.Equals("N"))
                        {
                            //e.Row.Cells[e.Row.Cells.Count - 1].Enabled = false;
                            e.Row.ForeColor = System.Drawing.Color.Red;
                            e.Row.Font.Bold = true;
                        }
                        else
                        {
                            //e.Row.Cells[e.Row.Cells.Count - 1].Enabled = false;
                            e.Row.ForeColor = System.Drawing.Color.Blue;
                            e.Row.Font.Bold = true;
                        }

                        break;
                    }
            }
        }

        protected void btnfileupload_Click(object sender, EventArgs e)
        {
            //int id = Int32.Parse(HiddenField1.Value);

            if (flpup.HasFile)
            {
                string filename = Path.GetFileName(flpup.PostedFile.FileName);
                flpup.SaveAs(Server.MapPath("~/ImagensNota/" + "Comprovante" + filename));//create a folder named 'files' in the solution explorer,the files will be uploaded to this folder //
                ModalPopupExtender1.Show();
            }
        }

        protected void sendclic(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }

        protected void btnBaixarTitulo_Click(object sender, EventArgs e)
        {
                btnBaixarTitulo.BackColor = System.Drawing.Color.DodgerBlue;
                btnBaixarTitulo.Text = "Baixado";
                btnBaixarTitulo.Enabled = false;
                lblPagoSN.Text = "S";

                ModalPopupExtender1.Show();
        }

        protected void btnSalvarBaixa_Click(object sender, EventArgs e)
        {
            
            //if (ContaFacade.BaixaTitulo(conta))
            //{
            //    btnPesquisar_Click(null, null);

            //    string alerta = "Baixa do Título realizada com sucesso!";
            //    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
            //}
            ModalPopupExtender1.Show();
        }


        protected void salvaArquivo()
        {
            string caminho = string.Empty;

            string diretorio = MapPath(@"~\Imagens\Comprovante\");

            HttpPostedFile imagemEnviada;

            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }

            HttpFileCollection imagensEnviadas = Request.Files;

            for (int i = 0; i < imagensEnviadas.Count; i++)
            {
                imagemEnviada = imagensEnviadas[i];

                if (imagemEnviada.ContentLength <= 0) return;

                string auxExt = Path.GetFileName(imagemEnviada.FileName).Substring(Path.GetFileName(imagemEnviada.FileName).Length - 4, 4);

                string strDocumentoNome = Path.GetFileName("Comprovante" + lblCodigo.Text + "." + lblEmpresaCodigo.Text + ".jpg");
                caminho = diretorio + strDocumentoNome;
                imagemEnviada.SaveAs(caminho);
            }
        }

        protected void imgNota_Click(object sender, ImageClickEventArgs e)
        {
            string strUrl = "~/Imagens/Comprovante/" + "Comprovante" + lblCodigo.Text + "." + lblEmpresaCodigo.Text + ".jpg";
            Session["impressao"] = strUrl;
            Redirect("~/Estoque/Gerencia/EstoqueNotaImagem.aspx", "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
            ModalPopupExtender1.Show();
        }

        protected void btnDadosDuplicacao_Click(object sender, EventArgs e)
        {
            lblAltereDadosSeNecessarios.Visible = true;
            btnConfirmarDuplicacao.Enabled = true;



            int idVencimento = 0;
            Nota objNota = new Nota();
            objNota.NumeroParcela = ddlEstoqueNotaQuantidadeParcelamento.SelectedValue;

            IList<Nota> lstNotas = new List<Nota>();

            Nota objNotalst = null;
            for (int i = 0; i < Convert.ToInt32(objNota.NumeroParcela); i++)
            {
                idVencimento += 1;
                objNotalst = new Nota(idVencimento);
                objNotalst.Vencimento = Convert.ToDateTime(lblDataVencimento.Text);
                DateTime dtProximoVencimento = objNotalst.Vencimento.AddMonths(i);
                objNotalst.Vencimento = dtProximoVencimento;
                objNotalst.Valor = Convert.ToDecimal((Convert.ToDecimal(lblDuplicarValorDocumento.Text).ToString("#0.00")));
                lstNotas.Add(objNotalst);
            }

            GridVencimentos.DataSource = lstNotas;
            GridVencimentos.DataBind();

            MPEDuplicata.Show();
        }

        protected void GridContas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConfirmarDuplicacao_Click(object sender, EventArgs e)
        {
            Nota objNota = new Nota();
            string enviarDatasEmail = string.Empty;
            IList<object> Contas = new List<object>();
            foreach (GridViewRow item in GridVencimentos.Rows)
            {
                TextBox txtVencimento = item.FindControl("txtVencimento") as TextBox;
                TextBox txtValorParcela = item.FindControl("txtValorParcela") as TextBox;


            }

            if (Session["UsuarioLogado"] != null)
            {
                Usuario UsuarioLogado = (Usuario)Session["UsuarioLogado"];
                bool enviado = EmailFacade.EnviarEmail(UsuarioLogado, "Foi Adicionado uma Conta Para Pagamento: |" + enviarDatasEmail);

                if (enviado)
                {
                    string alerta = "Duplicação realizada com sucesso!";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                }
            }


            MPEDuplicata.Show();
        }

    }
}