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
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;


namespace Amago.Web.Estoque.Vendas
{
    public partial class EstoqueVenda : System.Web.UI.Page
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
            //Produto produto = new Produto(0);
            //produto.Descricao = "";
            //produto.ValorUnitario = Convert.ToDecimal("0");
            //produto.QuantidadeRealEstoque = 0;
            //produto.ValorTotal = 0;
            //produto.QuantidadeMinimaEstoque = 0;

            //IList<Produto> produtos = new List<Produto>();
            //produtos.Add(produto);

            //GridProdutosSolicitacao0.DataSource = produtos;
            //GridProdutosSolicitacao0.DataBind();
            //GridProdutosSolicitacao0.Rows[0].Cells[4].Enabled = false;
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

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            
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

        [WebMethod]
        public static string[] GetClientes(string prefixo)
        {
            List<string> clientes = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["NorthwindConexao"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Descricao, Id, ValorUnitario from TB_Produtos where Descricao like + '%' + @Texto + '%'";
                    cmd.Parameters.AddWithValue("@Texto", prefixo);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            clientes.Add(string.Format("{0}-{1}-{2}", sdr["Descricao"], sdr["Id"], sdr["ValorUnitario"]));
                        }
                    }
                    conn.Close();
                }
            }

            return clientes.ToArray();
        }

        protected void btnVisualizarImpressaoCliente_Click(object sender, ImageClickEventArgs e)
        {
            Redirect("~/Estoque/Gerencia/SolicitacaoImpressao.aspx", "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
        }


    }
}