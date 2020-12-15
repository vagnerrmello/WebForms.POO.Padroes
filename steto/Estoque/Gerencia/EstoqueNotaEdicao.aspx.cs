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
    public partial class EstoqueNotaEdicao : System.Web.UI.Page
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
                PreencheNota();
            }
        }

        protected void InicializaPagina()
        {
            PreencheComboFornecedor();
            btnCriarNota.Enabled = true;
            HabilitaCampos();
            MultiViewNota.Visible = true;
            lblResultadoPesquisa.Visible = true;
            lblItensInseridos.Visible = true;

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

        protected void PreencheComboFornecedor()
        {
            Usuario usuario = (Usuario)Session["UsuarioLogado"];
            Fornecedor fornece = new Fornecedor();
            //fornece.Empresa = new Empresa(usuario.Empresa.Id);
            IList<Fornecedor> lstFornecedores = FornecedorFacade.RecuperarFornecedores(fornece);

            Fornecedor objFornecedor = new Fornecedor();
            objFornecedor.Id = 0;
            //objFornecedor.Empresa = new Empresa();
            objFornecedor.Nome = "Selecione";
            lstFornecedores.Add(objFornecedor);

            ddlFornecedor.DataSource = lstFornecedores;
            ddlFornecedor.DataTextField = "Nome";
            ddlFornecedor.DataValueField = "Id";
            ddlFornecedor.DataBind();
            ddlFornecedor.SelectedValue = "0";
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

            GridPoduto.DataSource = produtos;
            GridPoduto.DataBind();
            GridPoduto.Rows[0].Cells[5].Enabled = false;
        }

        protected void HabilitaCampos()
        {
            UploadImagem.Enabled = true;
            EnviarImagem.Enabled = true;
            imgNota.Enabled = true;

            //lblEmpresaCodigo.Text = string.Empty;
            //lblEmpresaCodigo.Enabled = true;
            txtEstoqueNumeroNota.Text = string.Empty;
            txtEstoqueNumeroNota.Enabled = false;
            ddlFornecedor.SelectedValue = "0";
            ddlFornecedor.Enabled = true;

            ddlEstoqueNotaQuantidadeParcelamento.SelectedValue = "0";
            ddlEstoqueNotaQuantidadeParcelamento.Enabled = true;
            txtEstoqueValorParcelaNota.Text = string.Empty;
            txtEstoqueValorParcelaNota.Enabled = true;
            txtEstoqueNotaDataPagamento.Text = string.Empty;
            txtEstoqueNotaDataPagamento.Enabled = true;
            chkEstoqueNotaLancarContasAPagar.Checked = true;
            chkEstoqueNotaLancarContasAPagar.Enabled = true;
            txtObsNota.Text = string.Empty;
            btnCriarNota.Enabled = false;
        }

        protected void DesabilitaCampos()
        {
            UploadImagem.Enabled = false;
            EnviarImagem.Enabled = false;
            imgNota.Enabled = false;

            txtEstoqueNumeroNota.Text = string.Empty;
            txtEstoqueNumeroNota.Enabled = false;
            ddlFornecedor.SelectedValue = "0";
            ddlFornecedor.Enabled = false;

            ddlEstoqueNotaQuantidadeParcelamento.SelectedValue = "0";
            ddlEstoqueNotaQuantidadeParcelamento.Enabled = false;
            txtEstoqueValorParcelaNota.Text = string.Empty;
            txtEstoqueValorParcelaNota.Enabled = false;
            txtEstoqueNotaDataPagamento.Text = string.Empty;
            txtEstoqueNotaDataPagamento.Enabled = false;
            chkEstoqueNotaLancarContasAPagar.Checked = false;
            chkEstoqueNotaLancarContasAPagar.Enabled = false;
            txtObsNota.Enabled = false;
            btnCriarNota.Enabled = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect(@"~/Administrador/Usuario/UsuarioPesquisa.aspx");
        }

        protected void salvaArquivo()
        {
            string caminho = string.Empty;

            string diretorio = MapPath(@"~\ImagensNota\");

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

                string strDocumentoNome = Path.GetFileName("Nota" + lblEstoqueisCodigoNota.Text + "." + lblEmpresaCodigo.Text + ".jpg");
                caminho = diretorio + strDocumentoNome;
                imagemEnviada.SaveAs(caminho);
            }
        }

        protected bool ValidaNota()
        {
            try
            {
                bool VerifiqueCampo = true;

                bool[] array = new bool[6];

                if (!string.IsNullOrEmpty(txtEstoqueNumeroNota.Text))
                {
                    lblEstoqueNumeroNota.ForeColor = System.Drawing.Color.Black;
                    array[0] = true;
                }
                else
                {
                    lblEstoqueNumeroNota.ForeColor = System.Drawing.Color.Red;
                    array[0] = false;
                }

                if (Convert.ToInt32(ddlFornecedor.SelectedValue) > 0)
                {
                    lblFornecedor.ForeColor = System.Drawing.Color.Black;
                    array[1] = true;
                }
                else
                {
                    lblFornecedor.ForeColor = System.Drawing.Color.Red;
                    array[1] = false;
                }

                if (Convert.ToInt32(ddlEstoqueNotaQuantidadeParcelamento.SelectedValue) > 0)
                {
                    lblEstoqueNotaQuantidadeParcelamento.ForeColor = System.Drawing.Color.Black;
                    array[2] = true;
                }
                else
                {
                    lblEstoqueNotaQuantidadeParcelamento.ForeColor = System.Drawing.Color.Red;
                    array[2] = false;
                }

                if (!string.IsNullOrEmpty(txtEstoqueValorParcelaNota.Text))
                {
                    lblEstoqueValorParcelaNota.ForeColor = System.Drawing.Color.Black;
                    array[3] = true;
                }
                else
                {
                    lblEstoqueValorParcelaNota.ForeColor = System.Drawing.Color.Red;
                    array[3] = false;
                }

                if (!string.IsNullOrEmpty(txtEstoqueNotaDataPagamento.Text))
                {
                    if (Validacao.IsData(txtEstoqueNotaDataPagamento.Text))
                    {
                        lblEstoqueNotaDataVencimento.ForeColor = System.Drawing.Color.Black;
                        array[4] = true;
                    }
                    else
                    {
                        string alerta1 = "Verifique o formato da data! Ela deve estar no formato: dd/MM/AAAA ";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                    }
                }
                else
                {
                    lblEstoqueNotaDataVencimento.ForeColor = System.Drawing.Color.Red;
                    array[4] = false;
                }

                if (!string.IsNullOrEmpty(txtObsNota.Text))
                {
                    lblObsNota.ForeColor = System.Drawing.Color.Black;
                    array[5] = true;
                }
                else
                {
                    lblObsNota.ForeColor = System.Drawing.Color.Red;
                    array[5] = false;
                }

                foreach (var item in array)
                {
                    if (!item)
                    {
                        VerifiqueCampo = false;
                    }
                }

                return VerifiqueCampo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void PreencheNota()
        {
            try
            {
                Nota objNota = (Nota)Session["NotaParaEdicao"];
                lblEstoqueisCodigoNota.Text = objNota.Id.ToString();
                //objNota.Empresa = new Empresa(Convert.ToInt32(lblEmpresaCodigo.Text));
                txtEstoqueNumeroNota.Text = objNota.NumeroDocumento;
                ddlFornecedor.SelectedValue = objNota.Fornecedor.Id.ToString();
                ddlEstoqueNotaQuantidadeParcelamento.SelectedValue = objNota.NumeroParcela;
                txtEstoqueValorParcelaNota.Text = objNota.Valor.ToString();
                txtEstoqueNotaDataPagamento.Text = objNota.Vencimento.ToString("dd/MM/yyyy");
                chkEstoqueNotaLancarContasAPagar.Checked = (objNota.ContasPagar == 1) ? true : false;
                txtObsNota.Text = objNota.Observacao;

                imgNota.ImageUrl = "~/ImagensNota/" + "Nota" + lblEstoqueisCodigoNota.Text + "." + lblEmpresaCodigo.Text + ".jpg";

                Empresa objEmpresa = new Empresa(Convert.ToInt32(lblEmpresaCodigo.Text));

                ProdutoNota objProdutoNota = new ProdutoNota();
                //objProdutoNota.Empresa = objEmpresa;
                objProdutoNota.Nota = objNota;

                PreencheListaDeProdutosNaNota(objProdutoNota);
                ReloadBtnPesquisa();
                MultiViewNota.Visible = true;
                MultiViewNota.ActiveViewIndex = 2;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCriarNota_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaNota())
                {
                    Nota objNota = new Nota();
                    objNota.NumeroDocumento = txtEstoqueNumeroNota.Text;
                    objNota.Fornecedor = new Fornecedor(Convert.ToInt32(ddlFornecedor.SelectedValue));
                    objNota.NumeroParcela = ddlEstoqueNotaQuantidadeParcelamento.SelectedValue;
                    objNota.Valor = Convert.ToDecimal(txtEstoqueValorParcelaNota.Text);

                    objNota.Vencimento = Convert.ToDateTime(txtEstoqueNotaDataPagamento.Text);
                    objNota.ContasPagar = (chkEstoqueNotaLancarContasAPagar.Checked) ? 1 : 0;
                    objNota.Observacao = txtObsNota.Text;
                    NotaFacade.AtualizaNota(objNota);

                    //Insere no Repositório Contas(Pagar/Receber)
                    string enviarDatasEmail = string.Empty;
                    //IList<Conta> Contas = new List<Conta>();
                    for (int i = 0; i < Convert.ToInt32(objNota.NumeroParcela); i++)
                    {
                        objNota.Id = Convert.ToInt32(lblEstoqueisCodigoNota.Text);
                        //intMesVencimento = objNota.Vencimento.Month;
                        objNota.Vencimento = Convert.ToDateTime(txtEstoqueNotaDataPagamento.Text);
                        DateTime dtProximoVencimento = objNota.Vencimento.AddMonths(i);
                        objNota.Vencimento = dtProximoVencimento;
                        //Conta conta = new Conta();
                        //conta.Nota = objNota;
                        //conta.Status = "A";
                        //conta.PagarReceber = "P";
                        //ContaFacade.ExcluirConta(conta);
                        //ContaFacade.InserirConta(conta);
                        //Contas.Add(conta);
                        enviarDatasEmail += objNota.Vencimento.ToString() + "|";
                    }

                    if (Session["UsuarioLogado"] != null)
                    {
                        Usuario UsuarioLogado = (Usuario)Session["UsuarioLogado"];
                        bool enviado = EmailFacade.EnviarEmail(UsuarioLogado, "Foi Adicionado uma Conta Para Pagamento com Vencimento: |" + enviarDatasEmail);
                    }

                    if (Convert.ToInt32(lblEstoqueisCodigoNota.Text) > 0)
                    {
                        UploadImagem.Enabled = true;
                        EnviarImagem.Enabled = true;
                        MultiViewNota.Visible = true;
                        MultiViewNota.ActiveViewIndex = 2;
                        lblItensInseridos.Visible = true;
                        lblItensInseridos.Text = "Clique no botão para inserir itens a nota. ";
                        lblResultadoPesquisa.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ReloadBtnPesquisa()
        {
            Produto produto = new Produto();
            produto.Descricao = (txtDescricaoPesquisa.Text != string.Empty) ? txtDescricaoPesquisa.Text : string.Empty;
            produto.ConsumoInterno = Convert.ToInt32(ddlEstoqueProduto.SelectedValue);

            IList<Produto> lstProdutos = ProdutoFacade.RecuperarProduto(produto);

            if (lstProdutos.Count > 0)
            {
                GridPoduto.DataSource = lstProdutos;
                GridPoduto.DataBind();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescricaoPesquisa.Text) || Convert.ToInt32(ddlEstoqueProduto.SelectedValue) <= 1)
            {
                Produto produto = new Produto();
                produto.Descricao = (txtDescricaoPesquisa.Text != string.Empty) ? txtDescricaoPesquisa.Text : string.Empty;
                produto.ConsumoInterno = Convert.ToInt32(ddlEstoqueProduto.SelectedValue);

                IList<Produto> lstProdutos = ProdutoFacade.RecuperarProduto(produto);

                IList<Produto> lstProdutosAtualizados = new List<Produto>();
                foreach (Produto ProdutoItem in lstProdutos)
                {
                    Steto.ValueObjectLayer.Estoque estoque = new Steto.ValueObjectLayer.Estoque();
                    estoque.Produto = ProdutoItem;
                    estoque = EstoqueFacade.RecuperarProdutoNoEstoque(estoque);
                    if (estoque != null)
                    {
                        if (estoque.Quantidade > 0)
                            ProdutoItem.QuantidadeRealEstoque = estoque.Quantidade;
                    }

                    lstProdutosAtualizados.Add(ProdutoItem);
                }

                if (lstProdutosAtualizados.Count > 0)
                {
                    GridPoduto.DataSource = lstProdutosAtualizados;
                    GridPoduto.DataBind();
                }
                else
                {
                    if (lstProdutos.Count > 0)
                    {
                        GridPoduto.DataSource = lstProdutos;
                        GridPoduto.DataBind();
                    }
                    else
                    {
                        string alerta1 = "Nenhum Produto Encontrado Com Os Critéiros de Pesquisas! ";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                    }

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
            ddlEstoqueProduto.SelectedValue = "10";
            txtDescricaoPesquisa.Text = string.Empty;
            PreencheGridProdutoVazio();
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            MultiViewNota.ActiveViewIndex = 1;
        }

        protected void BtnFecharCasdro_Click(object sender, EventArgs e)
        {
            MultiViewNota.ActiveViewIndex = 0;
        }

        protected void GridPoduto_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            Nota objNota = new Nota(Convert.ToInt32(lblEstoqueisCodigoNota.Text));
            Empresa objEmpresa = new Empresa(Convert.ToInt32(lblEmpresaCodigo.Text));

            int idProduto = Convert.ToInt32(GridPoduto.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.Trim());

            decimal dcmQuantidadeEntrada = 0;
            decimal QtdAtualEstoque = Convert.ToDecimal(GridPoduto.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text.Trim());
            Produto objProduto = new Produto(idProduto);
            TextBox txtValor = new TextBox();
            bool numerico = false;

            if (e.CommandName.Equals("Entrada"))
            {
                foreach (GridViewRow item in GridPoduto.Rows)
                {
                    TextBox txtValor2 = item.FindControl("txtCodigo") as TextBox;
                    txtValor = item.FindControl("txtValorEntrada") as TextBox;
                    if (Steto.Util.Validacao.IsNumeric(txtValor.Text))
                    {
                        numerico = true;
                    }

                    if (numerico)
                    {

                        if (idProduto.ToString().Equals(txtValor2.Text))
                        {
                            txtValor = item.FindControl("txtValorEntrada") as TextBox;

                            dcmQuantidadeEntrada = Convert.ToDecimal(txtValor.Text);
                            objProduto.Entrada = Convert.ToDecimal(txtValor.Text);
                            objProduto.QuantidadeRealEstoque = QtdAtualEstoque + dcmQuantidadeEntrada;
                            lblItensInseridos.Visible = true;
                        }
                    }
                }

                if (numerico)
                {
                    if (Convert.ToInt32(txtValor.Text) > 0)
                    {
                        ProdutoNota objProdutoNota = new ProdutoNota();
                        objProdutoNota.Nota = objNota;
                        objProdutoNota.Produto = objProduto;

                        if (NotaFacade.RecuperarProdutoNaNota(objProdutoNota) == null)
                        {
                            //ProdutoFacade.AlteraQuantidadeProduto(objProduto);
                            NotaFacade.InserirProdutoNaNota(objProdutoNota);
                            //PreencheListaDeProdutosNaNota(objProdutoNota);

                            /****Adicionando Produto e sua Quantidade ao Estoque da Empresa****/
                            Steto.ValueObjectLayer.Estoque estoque = new Steto.ValueObjectLayer.Estoque();
                            estoque.Produto = objProduto;
                            estoque.Fornecedor = new Fornecedor(Convert.ToInt32(ddlFornecedor.SelectedValue));
                            Steto.ValueObjectLayer.Estoque EstoqueRecuperado = EstoqueFacade.RecuperarProdutoNoEstoque(estoque);
                            if (EstoqueRecuperado != null)
                            {
                                estoque.Quantidade = EstoqueRecuperado.Quantidade + dcmQuantidadeEntrada;
                                EstoqueFacade.AlteraQuantidadeDoProdutoNoEstoque(estoque);
                            }
                            else
                            {
                                estoque.Quantidade = dcmQuantidadeEntrada;
                                EstoqueFacade.InserirEstoque(estoque);
                            }
                            /****FIM: Adicionando Produto e sua Quantidade ao Estoque da Empresa****/

                            //ReloadBtnPesquisa();
                            PreencheListaDeProdutosNaNota(objProdutoNota);
                            MultiViewNota.ActiveViewIndex = 2;
                        }
                        else
                        {
                            string alerta1 = "Produto já existe na Nota! Por favor escolher outro Produto para Inserir na Nota!";
                            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                        }
                    }
                    else
                    {
                        string alerta1 = "Não pode dar entrada em um produto com valor Zero!";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                    }
                }
                else
                {
                    string alerta1 = "Valor NÃO numérico!";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                }
            }
        }

        protected void PreencheListaDeProdutosNaNota(ProdutoNota objProdutoNota)
        {
            IList<Produto> lstProdutos = EstoqueFacade.RecuperaUmaListaDeProdutosNoEstoqueRelacionadasANota(objProdutoNota);

            if (lstProdutos.Count > 0)
            {
                GridProdutoNota.DataSource = lstProdutos;
                GridProdutoNota.DataBind();
            }
            else
            {
                string alerta1 = "Nenhum Produto Encontrado Com Os Critéiros de Pesquisas! ";
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
            }
        }

        protected void EnviarImagem_Click(object sender, ImageClickEventArgs e)
        {
            salvaArquivo();

            imgNota.ImageUrl = "~/ImagensNota/" + "Nota" + lblEstoqueisCodigoNota.Text + "." + lblEmpresaCodigo.Text + ".jpg";
            imgNota.Visible = true;
        }

        protected void Redirect(string url, string target, string windowFeatures)
        {
            //HttpResponse response = @"~/Default.aspx";

            if ((String.IsNullOrEmpty(target) || target.Equals("_self", StringComparison.OrdinalIgnoreCase)) && String.IsNullOrEmpty(windowFeatures))
            {
                //this.Redirect(url);
                Response.Redirect(url);
                //response.Redirect(url);
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

        protected void imgNota_Click(object sender, ImageClickEventArgs e)
        {
            string strUrl = "~/ImagensNota/" + "Nota" + lblEstoqueisCodigoNota.Text + "." + lblEmpresaCodigo.Text + ".jpg";
            Session["impressao"] = strUrl;
            Redirect("~/Estoque/Gerencia/EstoqueNotaImagem.aspx", "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
        }

        protected void BtnNovaNota_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Estoque/Gerencia/EstoquePesquisarNota.aspx");
        }

        protected void btnPesquisarProduto_Click(object sender, EventArgs e)
        {
            PreencheGridProdutoVazio();
            MultiViewNota.ActiveViewIndex = 0;
        }

        protected void GridProdutoNota_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ProdutoNota objProdutoNota = new ProdutoNota();
            objProdutoNota.Nota = new Nota(Convert.ToInt32(lblEstoqueisCodigoNota.Text));
            objProdutoNota.Produto = new Produto(Convert.ToInt32(GridProdutoNota.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim()));

            if (e.CommandName.Equals("Excluir"))
            {
                Steto.ValueObjectLayer.Estoque estoque = new Steto.ValueObjectLayer.Estoque();
                estoque.Produto = objProdutoNota.Produto;
                Steto.ValueObjectLayer.Estoque EstoqueRecuperado = EstoqueFacade.RecuperarProdutoNoEstoque(estoque);

                if (EstoqueRecuperado != null)
                {
                    estoque.Quantidade = EstoqueRecuperado.Quantidade - Convert.ToDecimal(GridProdutoNota.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.Trim());
                    if (estoque.Quantidade > 0)
                    {
                        EstoqueFacade.AlteraQuantidadeDoProdutoNoEstoque(estoque);
                    }
                    else
                    {
                        EstoqueFacade.ExcluiProdutoNoEstoque(estoque);
                    }

                    NotaFacade.ExcluirProdutoDaNota(objProdutoNota);

                    string alerta1 = "Exclusão do Produto da Nota foi realizada com sucesso! ";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                }

                PreencheListaDeProdutosNaNota(objProdutoNota);
            }
        }

        protected void btnCancelarPesquisaProduto_Click(object sender, EventArgs e)
        {
            MultiViewNota.Visible = true;
            MultiViewNota.ActiveViewIndex = 2;
        }
    }
}