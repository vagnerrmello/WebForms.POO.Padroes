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
    public partial class EstoqueSaida : System.Web.UI.Page
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
            lblDataAtualSolicitacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //PreencheComboFornecedor();
            //DesabilitaCampos();
            MultiViewNota.Visible = true;
            lblResultadoPesquisa.Visible = true;
            MultiViewNota.ActiveViewIndex = 0;
            PreencherFuncionarios();
        }

        protected void PreencherFuncionarios()
        {
            Funcionario funcionario = new Funcionario();
            IList <Funcionario> lstFuncionarios = FuncionarioFacade.RecuperaVariosFuncionariosPorEmpresa(funcionario);

            Funcionario objFuncionario = new Funcionario();
            objFuncionario.Id = 0;
            objFuncionario.Nome = "Selecione";
            lstFuncionarios.Add(objFuncionario);

            ddlSolicitante.DataSource = lstFuncionarios;
            ddlSolicitante.DataTextField = "Nome";
            ddlSolicitante.DataValueField = "Id";
            ddlSolicitante.DataBind();
            ddlSolicitante.SelectedValue = "0";
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
            IList<Fornecedor> lstFornecedores = FornecedorFacade.RecuperarFornecedores(fornece);

            Fornecedor objFornecedor = new Fornecedor();
            objFornecedor.Id = 0;
            objFornecedor.Nome = "Selecione";
            lstFornecedores.Add(objFornecedor);
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
            GridPoduto.Rows[0].Cells[4].Enabled = false;
        }

        protected void HabilitaCampos()
        {

        }

        protected void DesabilitaCampos()
        {

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

                //string strDocumentoNome = Path.GetFileName("Nota" + lblEstoqueisCodigoNota.Text + "." + lblEmpresaCodigo.Text + ".jpg");
                //caminho = diretorio + strDocumentoNome;
                //imagemEnviada.SaveAs(caminho);
            }
        }

        protected void ReloadBtnPesquisa()
        {
            Produto produto = new Produto();
            produto.Descricao = (txtDescricaoPesquisa.Text != string.Empty) ? txtDescricaoPesquisa.Text : string.Empty;
            //produto.ConsumoInterno = Convert.ToInt32(ddlEstoqueProduto.SelectedValue);

            IList<Produto> lstProdutos = ProdutoFacade.RecuperarProduto(produto);

            if (lstProdutos.Count > 0)
            {
                GridPoduto.DataSource = lstProdutos;
                GridPoduto.DataBind();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescricaoPesquisa.Text))
            {
                Produto produto = new Produto();
                produto.Descricao = (txtDescricaoPesquisa.Text != string.Empty) ? txtDescricaoPesquisa.Text : string.Empty;
                //produto.ConsumoInterno = Convert.ToInt32(ddlEstoqueProduto.SelectedValue);

                IList<Produto> lstProdutos = ProdutoFacade.RecuperarProduto(produto);

                IList<Produto> lstProdutosAtualizados = new List<Produto>();
                foreach (Produto ProdutoItem in lstProdutos)
                {
                    Steto.ValueObjectLayer.Estoque estoque = new Steto.ValueObjectLayer.Estoque();
                    estoque.Produto = ProdutoItem;
                    estoque  = EstoqueFacade.RecuperarProdutoNoEstoque(estoque);
                    if (estoque != null)
                    {
                        if (estoque.Quantidade > 0)
                        {
                            ProdutoItem.Id = estoque.Id;
                            ProdutoItem.QuantidadeRealEstoque = estoque.Quantidade;
                        }
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
            txtDescricaoPesquisa.Text = string.Empty;
            PreencheGridProdutoVazio();
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            MultiViewNota.ActiveViewIndex = 1;
        }

        protected void BtnFecharCasdro_Click(object sender, EventArgs e)
        {
            PreencheGridProdutoVazio();
            MultiViewNota.ActiveViewIndex = 0;
        }

        protected void GridPoduto_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            Empresa objEmpresa = new Empresa(Convert.ToInt32(lblEmpresaCodigo.Text));

            int idProduto = Convert.ToInt32(GridPoduto.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.Trim());

            decimal QtdAtualEstoque = Convert.ToDecimal(GridPoduto.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text.Trim());
            Produto objProduto = new Produto(idProduto);
            TextBox txtValor = new TextBox();
            //bool numerico = false;

            if (e.CommandName.Equals("Solicitar"))
            {
                objProduto.Descricao = GridPoduto.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.Trim();

                foreach (GridViewRow item in GridPoduto.Rows)
                {
                    TextBox txtValor2 = item.FindControl("txtCodigo") as TextBox;
                    txtValor = item.FindControl("txtValorEntrada") as TextBox;
                    //if (Steto.Util.Validacao.IsNumeric(txtValor.Text))
                    //{
                    //    numerico = true;
                    //}

                    if (Steto.Util.Validacao.IsNumeric(txtValor.Text))
                    {
                        if (idProduto.ToString().Equals(txtValor2.Text))
                        {
                            if (Convert.ToInt32(txtValor.Text) > 0)
                            {
                                Steto.ValueObjectLayer.Estoque EstoqueParaVerificacao = new Steto.ValueObjectLayer.Estoque(idProduto);
                                EstoqueParaVerificacao = EstoqueFacade.RecuperarProdutoNoEstoque(EstoqueParaVerificacao);
                                if (Convert.ToDecimal(GridPoduto.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text.Trim()) >= Convert.ToDecimal(txtValor.Text))
                                {
                                    decimal QueFicaNoEstoque = Convert.ToDecimal(GridPoduto.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text.Trim()) - Convert.ToDecimal(txtValor.Text);

                                    if (QueFicaNoEstoque < EstoqueParaVerificacao.Produto.QuantidadeMinimaEstoque)
                                    {
                                        string alerta1 = "Produto abaixo da Quantidade mínima no estoque! Providencie entrada para este produto!";
                                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                                    }
                                    objProduto.QuantidadeRealEstoque = Convert.ToDecimal(txtValor.Text);

                                    PreencheGridProdutosSolicitados(objProduto);
                                }
                                else
                                {
                                    string alerta1 = "Você está solicitando uma quantidade maior que a existente no Estoque! Providencie entrada para este produto!";
                                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                                }
                            }
                            else
                            {
                                string alerta1 = "Não pode dar SAÍDA em um produto com Quantidade Zero!";
                                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                            }
                        }
                    }
                    else
                    {
                        string alerta1 = "Valor NÃO numérico!";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                    }
                }

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

        protected void btnPesquisarProduto_Click(object sender, EventArgs e)
        {
            PreencheGridProdutoVazio();
            MultiViewNota.ActiveViewIndex = 0;
        }

        protected void PreencheGridProdutosSolicitados(Produto produto)
        {
            IList<Produto> lstProdutos = new List<Produto>();

            lstProdutos.Add(produto);

            foreach (GridViewRow row in GridProdutosSolicitacao.Rows)
            {
                Produto produtoGrid = new Produto(Convert.ToInt32(row.Cells[0].Text));
                produtoGrid.Descricao = row.Cells[1].Text;
                produtoGrid.QuantidadeRealEstoque = Convert.ToDecimal(row.Cells[2].Text);
                if(produto.Id != produtoGrid.Id) //Se produto já estiver no grid, não adicione
                    lstProdutos.Add(produtoGrid);
            }

            if (lstProdutos.Count > 0)
            {
                GridProdutosSolicitacao.DataSource = lstProdutos;
                GridProdutosSolicitacao.DataBind();
                lblProdutosSolicitados.Visible = true;
            }
        }

        protected void btnEnviarSolicitacao_Click(object sender, EventArgs e)
        {
            Solicitacao solicitacao = new Solicitacao();

            solicitacao.Funcionario = new Funcionario(Convert.ToInt32(ddlSolicitante.SelectedValue));
            solicitacao.Funcionario.Nome = ddlSolicitante.SelectedItem.Text;

            solicitacao.Data_Solicitacao = Convert.ToDateTime(lblDataAtualSolicitacao.Text);
            solicitacao.Status = "P";

            int idSolicitacao = SolicitacaoFacade.CriarSolicitacao(solicitacao);

            Produto produto = new Produto();
            IList<Solicitacao> lstSolicitacoes = new List<Solicitacao>();
            string listadeprodutos = string.Empty;
            foreach (GridViewRow row in GridProdutosSolicitacao.Rows)
            {
                solicitacao = new Solicitacao(idSolicitacao);
                solicitacao.Data_Solicitacao = Convert.ToDateTime(lblDataAtualSolicitacao.Text);
                solicitacao.Status = "P";

                solicitacao.Funcionario = new Funcionario(Convert.ToInt32(ddlSolicitante.SelectedValue));
                solicitacao.Funcionario.Nome = ddlSolicitante.SelectedItem.Text;

                solicitacao.Estoque = new Steto.ValueObjectLayer.Estoque(Convert.ToInt32(row.Cells[0].Text));

                solicitacao.Produto = new Produto();
                solicitacao.Produto.Descricao = Convert.ToString(row.Cells[1].Text);

                solicitacao.Quantidade = Convert.ToDecimal(row.Cells[2].Text);

                lstSolicitacoes.Add(solicitacao);

                lblNumeroSolicitacaoImpressao.Text = SolicitacaoFacade.CriarSolicitacaoEstoque(solicitacao).ToString();
                listadeprodutos += " " + solicitacao.Quantidade + " - " + solicitacao.Produto.Descricao + ";";
            }

            if (Session["UsuarioLogado"] != null)
            {
                Usuario UsuarioLogado = (Usuario)Session["UsuarioLogado"];
                bool enviado = EmailFacade.EnviarEmail(UsuarioLogado, "Solicitação de número " + solicitacao.Id.ToString() + " eviada com sucesso! Aguarde liberação do(s) produto(s): " + listadeprodutos);
            }

            GerarSolicitacao(lstSolicitacoes);
            MultiViewNota.ActiveViewIndex = 1;

            lblNomeEmpresaImpressao.Text = lblEmpresa.Text;
            //lblNumeroSolicitacaoImpressao.Text = "0000";
            lblDataExtensoSolicitacaoImpressao.Text = solicitacao.Data_Solicitacao.ToString("dd/MM/yyyy");
            lblStatusResultadoSolicitacaoImpressao.Text = solicitacao.Status;
            lblNomeFuncionarioImpressao.Text = solicitacao.Funcionario.Nome;
        }

        protected void GerarSolicitacao(IList<Solicitacao> lstSolicitacoes)
        {
            Session["lstSolicitacoes"] = lstSolicitacoes;
            Usuario usuario = (Usuario)Session["UsuarioLogado"];
            // Criando Variaveis
            // Representa uma linha da tabela
            TableRow lnhNomeEmpresa, lnhNomeJudiciario, lnhNumeroSelo, lnhConfiraDados, lnhQuebraLinha, Linha6, Linha7;
            // Representa uma celula da tabela
            TableCell CelInfo, CelDesc, clNomeEmpresa, clNomeJudiciario, CelLblSelo, CelConfiraDados, CelQuebraLinha, Celula4,
                CelNSelosPagina, CelSeloInicial, CelSeloFinal, CeltxtNSelosPaginas, CeltxtSeloInicial, CeltxtSeloFinal, CelCancelarMultiplasPaginas,
                CelbtnGeraMultiplosSelos;
            // Representa um campo TextBox
            TextBox txtDesc, txtRes, txtSelo,
                txtNSelosPaginas, txtSeloInicial, txtSeloFinal;
            // Representa um Label
            Label lblInfoAto, lblDesc, lblNomeEmpresa, lblNomeJudiciario, lblnNumeroSelo, lblConfiraDados, lblQuebraLinha;
            // Representa o Botão Gerar Selo
            Button btnGerarSelo, btnMultiplasPaginas, btnCancelarMultiplasPaginas, btnGeraMultiplosSelos;
            // Variavel para gerenciar contador
            int nCont = 0;
            // Variavel que presenta a quantidade de campos a ser criado
            int nCampos = 0;
            // Variavel que presenta numeros aleatório
            Random RandomClass = new Random();

            // Verificando se na URL existe o parametro "num" Request["num"].ToString())
            //if (Request["num"] != null)
            if (lstSolicitacoes.Count > 0)
            {
                //IList<Selo> selos = (IList<Selo>)Session["ImpressaoSelos"];
                // Criando nova linha, calula e campo
                lnhNomeEmpresa = new TableRow();
                lnhNomeJudiciario = new TableRow();
                lnhNumeroSelo = new TableRow();
                lnhConfiraDados = new TableRow();
                lnhQuebraLinha = new TableRow();
                Linha6 = new TableRow();
                Linha7 = new TableRow();

                CelInfo = new TableCell();
                CelDesc = new TableCell();
                clNomeEmpresa = new TableCell();
                clNomeJudiciario = new TableCell();
                CelConfiraDados = new TableCell();
                CelQuebraLinha = new TableCell();
                Celula4 = new TableCell();
                CelLblSelo = new TableCell();
                CelNSelosPagina = new TableCell();
                CelSeloInicial = new TableCell();
                CelSeloFinal = new TableCell();
                CeltxtNSelosPaginas = new TableCell();
                CeltxtSeloInicial = new TableCell();
                CeltxtSeloFinal = new TableCell();
                CelCancelarMultiplasPaginas = new TableCell();
                CelbtnGeraMultiplosSelos = new TableCell();

                //Conjunto de Labels
                lblInfoAto = new Label();
                lblDesc = new Label();
                lblNomeEmpresa = new Label();
                lblNomeJudiciario = new Label();
                lblnNumeroSelo = new Label();
                lblConfiraDados = new Label();
                lblQuebraLinha = new Label();

                //Conjunto de TextBox
                txtDesc = new TextBox();
                txtRes = new TextBox();
                txtSelo = new TextBox();
                txtNSelosPaginas = new TextBox();
                txtSeloInicial = new TextBox();
                txtSeloFinal = new TextBox();

                btnGerarSelo = new Button();
                btnMultiplasPaginas = new Button();
                btnCancelarMultiplasPaginas = new Button();
                btnGeraMultiplosSelos = new Button();

                // Setando propriedades do Label para a TextBox Ressalva  
                clNomeEmpresa.Controls.Add(new LiteralControl("&nbsp;"));
                lblNomeEmpresa.ID = "lblNomeEmpresa" + nCont.ToString();
                lblNomeEmpresa.Text = "Código";
                lblNomeEmpresa.Font.Bold = true;
                clNomeEmpresa.Controls.Add(lblNomeEmpresa);
                lnhNomeEmpresa.Cells.Add(clNomeEmpresa);

                // Setando propriedades do campo Nome Judiciário 
                //clNomeJudiciario.Controls.Add(new LiteralControl("<br /><br />"));
                lblNomeJudiciario.ID = "lblNomeJudiciario" + nCont.ToString();
                lblNomeJudiciario.Text = "Produto";
                lblNomeJudiciario.Width = Unit.Pixel(400);
                lblNomeJudiciario.Enabled = true;
                lblNomeJudiciario.Font.Bold = true;
                // Adiciono o campo Descrição criado e setado a celula
                clNomeJudiciario.Controls.Add(lblNomeJudiciario);
                // Adiciono a celula com o campo Descrição a linha
                //lnhNomeJudiciario.Cells.Add(clNomeJudiciario);
                lnhNomeEmpresa.Cells.Add(clNomeJudiciario);
                //IList<SeloComprado> selos = (IList<SeloComprado>)Session["NumerosSelos"];

                // Setando propriedades do Label da TextBox Número Selo
                //CelLblSelo.Controls.Add(new LiteralControl("<br /><br />"));
                lblnNumeroSelo.ID = "lblnNumeroSelo" + nCont.ToString();
                lblnNumeroSelo.Text = "Qtd. Solicitada";
                lblnNumeroSelo.Font.Bold = true;
                CelLblSelo.Controls.Add(lblnNumeroSelo);
                //lnhNumeroSelo.Cells.Add(CelLblSelo);
                lnhNomeEmpresa.Cells.Add(CelLblSelo);

                this.TbDinamica.Rows.Add(lnhNomeEmpresa);
                //this.TbDinamica.Rows.Add(lnhNomeJudiciario);
                //this.TbDinamica.Rows.Add(lnhNumeroSelo);
                //this.TbDinamica.Rows.Add(lnhConfiraDados);
                //this.TbDinamica.Rows.Add(lnhQuebraLinha);
                this.TbDinamica.Controls.Add(lnhQuebraLinha);
                // Recebo o valor existe no parametro e o converto de STRING para INT
                // porque a variavel nCampos é do tipo INTEIRO

                nCampos = lstSolicitacoes.Count;// Convert.ToInt32(Request["num"].ToString());
                int index = 0;
                // Iniciando contador que vai criar os campos
                for (nCont = 1; nCont <= nCampos; nCont++)
                {


                    //foreach (var solicitacao in lstSolicitacoes)
                    //{
                        lnhNomeEmpresa = new TableRow();
                        lnhNomeJudiciario = new TableRow();
                        lnhNumeroSelo = new TableRow();
                        lnhConfiraDados = new TableRow();
                        lnhQuebraLinha = new TableRow();
                        Linha6 = new TableRow();
                        Linha7 = new TableRow();

                        CelInfo = new TableCell();
                        CelDesc = new TableCell();
                        clNomeEmpresa = new TableCell();
                        clNomeJudiciario = new TableCell();
                        CelConfiraDados = new TableCell();
                        CelQuebraLinha = new TableCell();
                        Celula4 = new TableCell();
                        CelLblSelo = new TableCell();
                        CelNSelosPagina = new TableCell();
                        CelSeloInicial = new TableCell();
                        CelSeloFinal = new TableCell();
                        CeltxtNSelosPaginas = new TableCell();
                        CeltxtSeloInicial = new TableCell();
                        CeltxtSeloFinal = new TableCell();
                        CelCancelarMultiplasPaginas = new TableCell();
                        CelbtnGeraMultiplosSelos = new TableCell();

                        //Conjunto de Labels
                        lblInfoAto = new Label();
                        lblDesc = new Label();
                        lblNomeEmpresa = new Label();
                        lblNomeJudiciario = new Label();
                        lblnNumeroSelo = new Label();
                        lblConfiraDados = new Label();
                        lblQuebraLinha = new Label();

                        //Conjunto de TextBox
                        txtDesc = new TextBox();
                        txtRes = new TextBox();
                        txtSelo = new TextBox();
                        txtNSelosPaginas = new TextBox();
                        txtSeloInicial = new TextBox();
                        txtSeloFinal = new TextBox();

                        btnGerarSelo = new Button();
                        btnMultiplasPaginas = new Button();
                        btnCancelarMultiplasPaginas = new Button();
                        btnGeraMultiplosSelos = new Button();




                        // Setando propriedades do Label para a TextBox Ressalva  
                        clNomeEmpresa.Controls.Add(new LiteralControl("&nbsp;"));
                        lblNomeEmpresa.ID = "lblNomeEmpresa" + nCont.ToString();
                        lblNomeEmpresa.Text = lstSolicitacoes[index].Estoque.Id.ToString();
                        clNomeEmpresa.Controls.Add(lblNomeEmpresa);
                        lnhNomeEmpresa.Cells.Add(clNomeEmpresa);

                        // Setando propriedades do campo Nome Judiciário 
                        //clNomeJudiciario.Controls.Add(new LiteralControl("<br /><br />"));
                        lblNomeJudiciario.ID = "lblNomeJudiciario" + nCont.ToString();
                        lblNomeJudiciario.Text = lstSolicitacoes[index].Produto.Descricao; 
                        lblNomeJudiciario.Width = Unit.Pixel(400);
                        lblNomeJudiciario.Enabled = true;
                        // Adiciono o campo Descrição criado e setado a celula
                        clNomeJudiciario.Controls.Add(lblNomeJudiciario);
                        // Adiciono a celula com o campo Descrição a linha
                        //////lnhNomeJudiciario.Cells.Add(clNomeJudiciario);
                        lnhNomeEmpresa.Cells.Add(clNomeJudiciario);

                        //IList<SeloComprado> selos = (IList<SeloComprado>)Session["NumerosSelos"];

                        // Setando propriedades do Label da TextBox Número Selo
                        //CelLblSelo.Controls.Add(new LiteralControl("<br /><br />"));
                        lblnNumeroSelo.ID = "lblnNumeroSelo" + nCont.ToString();
                        lblnNumeroSelo.Text = lstSolicitacoes[index].Quantidade.ToString();
                        //lblnNumeroSelo.Font.Bold = true;
                        CelLblSelo.Controls.Add(lblnNumeroSelo);
                        //////lnhNumeroSelo.Cells.Add(CelLblSelo);
                        lnhNomeEmpresa.Cells.Add(CelLblSelo);

                        // Setando propriedades do campo Confira Dados 
                        //////CelConfiraDados.Controls.Add(new LiteralControl("<br /><br />"));
                        //////lblConfiraDados.ID = "lblConfiraDados" + nCont.ToString();
                        //////lblConfiraDados.Text = "Confira os dados do ato em: selo.tjal.jus.br";
                        ////////txtRes.Width = Unit.Pixel(250);
                        ////////txtRes.Enabled = true;
                        //////// Adiciono o campo Ressalva criado e setado a celula
                        //////CelConfiraDados.Controls.Add(lblConfiraDados);
                        //////// Adiciono a celula com o campo Ressalva a linha
                        //////lnhConfiraDados.Cells.Add(CelConfiraDados);

                        // Setando propriedades do Label da TextBox Número Selo
                        CelQuebraLinha.Controls.Add(new LiteralControl("<div style='page -break-after: always'></div>"));
                        //lblnNumeroSelo.ID = "lblnNumeroSelo" + nCont.ToString();
                        //lblnNumeroSelo.Text = item.Numero_Selo;
                        //lblnNumeroSelo.Font.Bold = true;
                        //CelLblSelo.Controls.Add(lblnNumeroSelo);
                        //lnhQuebraLinha.Cells.Add(CelQuebraLinha);
                        lnhNomeEmpresa.Cells.Add(CelQuebraLinha);

                        //// Adiciono as linhas com as celulas e com os campos setado a tabela
                        this.TbDinamica.Rows.Add(lnhNomeEmpresa);
                        //this.TbDinamica.Rows.Add(lnhNomeJudiciario);
                        //this.TbDinamica.Rows.Add(lnhNumeroSelo);
                        //this.TbDinamica.Rows.Add(lnhConfiraDados);
                        //this.TbDinamica.Rows.Add(lnhQuebraLinha);
                        this.TbDinamica.Controls.Add(lnhQuebraLinha);
                        index++;
                    //}



                }
            }
        }

        protected void GridProdutosSolicitacao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idProduto = Convert.ToInt32(GridProdutosSolicitacao.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim());
            if (e.CommandName.Equals("Excluir"))
            {
                IList<Produto> lstProdutos = new List<Produto>();
                
                Produto objProduto = null;
                foreach (GridViewRow row in GridProdutosSolicitacao.Rows)
                {
                    objProduto = new Produto(Convert.ToInt32(row.Cells[0].Text));
                    objProduto.Descricao = row.Cells[1].Text;
                    objProduto.QuantidadeRealEstoque = Convert.ToDecimal(row.Cells[2].Text);
                    if(objProduto.Id != idProduto)
                        lstProdutos.Add(objProduto);
                }

                if (lstProdutos.Count > 0)
                {
                    GridProdutosSolicitacao.DataSource = lstProdutos;
                    GridProdutosSolicitacao.DataBind();
                }
            }
        }

        protected void btnVisualizarImpressaoCliente_Click(object sender, ImageClickEventArgs e)
        {
            Redirect("~/Estoque/Gerencia/SolicitacaoImpressao.aspx", "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
        }
    }
}