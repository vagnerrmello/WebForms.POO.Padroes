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
using System.Text;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

namespace Amago.Web.Estoque.Gerencia
{
    public partial class EstoqueNota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PermissaoPagina();
            if (!Page.IsPostBack)
            {
                Usuario usuario = (Usuario)Session["UsuarioLogado"];
                lblEmpresaCodigo.Text = string.Empty;

                InicializaPagina();

                if (Session["NotaParaEdicao"] != null)
                {
                    BtnNovaNota_Click(null, null);
                    BtnNovaNota.Visible = false;
                    btnCriarNota.Visible = false;

                    Nota nota = (Nota)Session["NotaParaEdicao"];

                    lblEstoqueisCodigoNota.Text = nota.Id.ToString();
                    lblDataDoCadastro.Text = nota.Cadastro.ToString("dd/MM/yyyy");
                    txtEstoqueNumeroNota.Text = nota.NumeroDocumento;
                    ddlFornecedor.SelectedValue = nota.Fornecedor.Id.ToString();
                    txtEstoqueNotaDataEmissao.Text = nota.Emissao.ToString("dd/MM/yyyy");
                    txtEstoqueNotaDataVencimento.Text = nota.Vencimento.ToString("dd/MM/yyyy");
                    ddlEstoqueNotaQuantidadeParcelamento.SelectedValue = nota.NumeroParcela;
                    txtEstoqueValorParcelaNota.Text = nota.Valor.ToString("#0.00");
                    chkEstoqueNotaLancarContasAPagar.Checked = (nota.ContasPagar == 1) ? true : false;





                    ProdutoNota objProdutoNota = new ProdutoNota();

                    objProdutoNota.Nota = nota;
                    //objProdutoNota.Produto = objProduto;
                    PreencheListaDeProdutosNaNota(objProdutoNota);

                    MultiViewNota.Visible = true;
                    MultiViewNota.ActiveViewIndex = 2;
                    Session["NotaParaEdicao"] = null;
                }
               
            }
        }

        protected void InicializaPagina()
        {
            PreencheComboFornecedor();
            DesabilitaCampos();
            btnAlterarDataVencimento.Enabled = false;
            MultiViewNota.Visible = false;
            lblResultadoPesquisa.Visible = false;
            //lblItensInseridos.Visible = false;
            lblDataDoCadastro.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblLabelTotal.Visible = false;
            lblTotalValorEntradas.Text = string.Empty;
            lblTotalValorEntradas.Visible = false;
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
            GridPoduto.Rows[0].Cells[4].Enabled = false;
        }

        protected void HabilitaCampos()
        {
            UploadImagem.Enabled = false;
            EnviarImagem.Enabled = false;
            imgNota.Enabled = false;

            //lblEmpresaCodigo.Text = string.Empty;
            //lblEmpresaCodigo.Enabled = true;
            txtEstoqueNumeroNota.Text = string.Empty;
            txtEstoqueNumeroNota.Enabled = true;
            ddlFornecedor.SelectedValue = "0";
            ddlFornecedor.Enabled = true;

            ddlEstoqueNotaQuantidadeParcelamento.SelectedValue = "0";
            ddlEstoqueNotaQuantidadeParcelamento.Enabled = true;
            txtEstoqueValorParcelaNota.Text = string.Empty;
            txtEstoqueValorParcelaNota.Enabled = true;
            txtEstoqueNotaDataVencimento.Text = string.Empty;
            txtEstoqueNotaDataVencimento.Enabled = true;
            txtEstoqueNotaDataEmissao.Enabled = true;
            chkEstoqueNotaLancarContasAPagar.Checked = true;
            chkEstoqueNotaLancarContasAPagar.Enabled = true;
            btnCriarNota.Enabled = false;

            lblTotalValorEntradas.Text = string.Empty;
            lblTotalValorEntradas.Visible = true;

            ////btnEnviarParaNota.Visible = true;
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
            txtEstoqueNotaDataVencimento.Text = string.Empty;
            txtEstoqueNotaDataVencimento.Enabled = false;
            txtEstoqueNotaDataEmissao.Enabled = false;
            chkEstoqueNotaLancarContasAPagar.Checked = false;
            chkEstoqueNotaLancarContasAPagar.Enabled = false;
            btnCriarNota.Enabled = false;

            lblTotalValorEntradas.Text = string.Empty;
            lblTotalValorEntradas.Visible = false;

            btnEnviarParaNota.Visible = false;
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

                if (!string.IsNullOrEmpty(txtEstoqueNotaDataVencimento.Text))
                {
                    if (Validacao.IsData(txtEstoqueNotaDataVencimento.Text))
                    {
                        lblEstoqueNotaDataVencimento.ForeColor = System.Drawing.Color.Black;
                        array[4] = true;
                    }
                    else
                    {
                        string alerta1 = "Verifique o formato da data de Vencimento! Ela deve estar no formato: dd/MM/AAAA ";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                    }
                }
                else
                {
                    lblEstoqueNotaDataVencimento.ForeColor = System.Drawing.Color.Red;
                    array[4] = false;
                }

                if (!string.IsNullOrEmpty(txtEstoqueNotaDataEmissao.Text))
                {
                    if (Validacao.IsData(txtEstoqueNotaDataEmissao.Text))
                    {
                        txtEstoqueNotaDataEmissao.ForeColor = System.Drawing.Color.Black;
                        array[5] = true;
                    }
                    else
                    {
                        string alerta1 = "Verifique o formato da data de Emissão! Ela deve estar no formato: dd/MM/AAAA ";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                    }
                }
                else
                {
                    txtEstoqueNotaDataEmissao.ForeColor = System.Drawing.Color.Red;
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

        protected void btnCriarNota_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaNota())
                {
                    Nota objNota = new Nota();
                    objNota.Cadastro = DateTime.Now;
                    objNota.NumeroDocumento = txtEstoqueNumeroNota.Text;
                    objNota.Fornecedor = new Fornecedor(Convert.ToInt32(ddlFornecedor.SelectedValue));
                    objNota.NumeroParcela = ddlEstoqueNotaQuantidadeParcelamento.SelectedValue;
                    objNota.Valor = Convert.ToDecimal(txtEstoqueValorParcelaNota.Text);
                    objNota.Vencimento = Convert.ToDateTime(txtEstoqueNotaDataVencimento.Text);
                    objNota.Emissao = Convert.ToDateTime(txtEstoqueNotaDataEmissao.Text);
                    objNota.ContasPagar = (chkEstoqueNotaLancarContasAPagar.Checked) ? 1 : 0;

                    int codNota = 0;
                    if (!lblEstoqueisCodigoNota.Text.Equals(""))
                    {
                        objNota.Id = Convert.ToInt32(lblEstoqueisCodigoNota.Text);
                        NotaFacade.AtualizaNota(objNota);
                    }
                    else
                    {
                        codNota = NotaFacade.CriarNota(objNota);

                        string enviarDatasEmail = string.Empty;
                        //IList<Conta> Contas = new List<Conta>();
                        if (chkEstoqueNotaLancarContasAPagar.Checked)
                        {
                            foreach (GridViewRow item in GridVencimentos.Rows)
                            {
                                TextBox txtVencimento = item.FindControl("txtVencimento") as TextBox;
                                TextBox txtValorParcela = item.FindControl("txtValorParcela") as TextBox;

                                objNota.Id = codNota;
                                objNota.Vencimento = Convert.ToDateTime(txtVencimento.Text);
                                objNota.Valor = Convert.ToDecimal(txtValorParcela.Text);


                                //Contas.Add(conta);
                                enviarDatasEmail += "Vencimento: " + objNota.Vencimento.ToString("dd/MM/yyyy") + "|" + " Valor: " + objNota.Valor.ToString() + "; ";
                            }

                            if (Session["UsuarioLogado"] != null)
                            {
                                Usuario UsuarioLogado = (Usuario)Session["UsuarioLogado"];
                                bool enviado = EmailFacade.EnviarEmail(UsuarioLogado, "Foi Adicionado uma Conta Para Pagamento: |" + enviarDatasEmail);
                            }
                        }

                        if (codNota > 0)
                        {
                            btnCriarNota.Visible = false;
                            BtnNovaNota.Visible = false;
                            lblEstoqueisCodigoNota.Text = codNota.ToString();
                            UploadImagem.Enabled = true;
                            EnviarImagem.Enabled = true;
                            MultiViewNota.Visible = true;
                            MultiViewNota.ActiveViewIndex = 2;
                            lblResultadoPesquisa.Visible = true;
                        }
                    }
                }
                else
                {
                    string alerta = "Verifique se existe algum campo vazio! ";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
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



        [WebMethod]
        public static string[] GetClientes(string prefixo)
        {
            //Produto produto = null;
            //IList<Produto> lstprodutos = new List<Produto>();

            List<string> clientes = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["NorthwindConexao"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Descricao, Id from TB_Produtos where Descricao like + '%' + @Texto + '%'";
                    cmd.Parameters.AddWithValue("@Texto", prefixo);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            clientes.Add(string.Format("{0}-{1}", sdr["Descricao"], sdr["Id"]));
                            //produto = new Produto(Convert.ToInt32(sdr["Id"]));
                            //produto.Descricao = sdr["Descricao"].ToString();
                            //lstprodutos.Add(produto);
                        }
                    }
                    conn.Close();
                }
            }

            return clientes.ToArray();
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
                    estoque  = EstoqueFacade.RecuperarProdutoNoEstoque(estoque);
                    if (estoque != null)
                    {
                        if (estoque.Quantidade > 0)
                            ProdutoItem.QuantidadeRealEstoque = estoque.Quantidade;
                    }
                    //////////////////////////////
                    ProdutoItem.ValorUnitario = 0;
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
            ModalPopupExtender1.Show();
        }

        protected void btnLimpaPesquisa_Click(object sender, EventArgs e)
        {
            ddlEstoqueProduto.SelectedValue = "10";
            txtDescricaoPesquisa.Text = string.Empty;
            PreencheGridProdutoVazio();
            ModalPopupExtender1.Show();
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            MultiViewNota.ActiveViewIndex = 1;
        }

        protected void BtnFecharCasdro_Click(object sender, EventArgs e)
        {
            btnPesquisarProduto_Click(null, null);
            //txtDescricaoPesquisa.Text = string.Empty;
            //txtDescricaoPesquisa.Focus();
            //PreencheGridProdutoVazio();
            //ModalPopupExtender1.Show();
            ////PreencheGridProdutoVazio();
            ////MultiViewNota.ActiveViewIndex = 0;
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
                            //lblItensInseridos.Visible = true;
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
                ////decimal totalValorEntradas = 0;
                for (int i = 0; i < lstProdutos.Count; i++)
                {
                    lstProdutos[i].ValorTotal = lstProdutos[i].ValorUnitario * lstProdutos[i].Entrada;
                    //totalValorEntradas += lstProdutos[i].ValorTotal;
                }

                //lblTotalValorEntradas.Text = "R$ " + totalValorEntradas.ToString("#0.00");
                //lblTotalValorEntradas.Visible = true;

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
            HabilitaCampos();
            btnCriarNota.Enabled = true;
            BtnNovaNota.Enabled = false;
        }

        protected void btnPesquisarProduto_Click(object sender, EventArgs e)
        {
            //txtDescricaoPesquisa.Text = string.Empty;
            //txtDescricaoPesquisa.Focus();
            //PreencheGridProdutoVazio();
            //MultiViewNota.ActiveViewIndex = 0;

            txtDescricaoPesquisa.Text = string.Empty;
            txtDescricaoPesquisa.Focus();
            PreencheGridProdutoVazio();
            ModalPopupExtender1.Show();
        }

        protected void GridProdutoNota_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //GridProdutoNota.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Enabled = false;
            //GridProdutoNota.Rows[Convert.ToInt32(e.CommandArgument)].ForeColor = System.Drawing.Color.Red;
            //GridProdutoNota.Row.Cells[e.Row.Cells.Count - 1].Enabled = false;
            //e.Row.ForeColor = System.Drawing.Color.Red;

            if (e.CommandName.Equals("Excluir"))
            {
                ProdutoNota objProdutoNota = new ProdutoNota();
                objProdutoNota.Nota = new Nota(Convert.ToInt32(lblEstoqueisCodigoNota.Text));
                objProdutoNota.Produto = new Produto(Convert.ToInt32(GridProdutoNota.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim()));

                Steto.ValueObjectLayer.Estoque estoque = new Steto.ValueObjectLayer.Estoque();
                estoque.Fornecedor = new Fornecedor(Convert.ToInt32(ddlFornecedor.SelectedValue));
                estoque.Produto = new Produto(Convert.ToInt32(GridProdutoNota.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim()));
                estoque = EstoqueFacade.RecuperarProdutoNoEstoque(estoque);

                decimal entrada = estoque.Quantidade - Convert.ToDecimal(GridProdutoNota.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text.Replace("R$ ", "").Trim());

                if (entrada >= 0)
                {
                    estoque.Quantidade = entrada;
                    if (entrada > 0) EstoqueFacade.AlteraQuantidadeDoProdutoNoEstoque(estoque);

                    if (entrada == 0) EstoqueFacade.ExcluiProdutoNoEstoque(estoque);

                    Nota nota = new Nota(Convert.ToInt32(lblEstoqueisCodigoNota.Text));
                    nota.Produto = new Produto(Convert.ToInt32(GridProdutoNota.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim()));
                    nota.Produto.Entrada = Convert.ToDecimal(GridProdutoNota.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text.Trim());
                    nota.Produto.ValorUnitario = Convert.ToDecimal(GridProdutoNota.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text.Replace("R$ ", "").Trim());
                    nota.Produto.Ativo = "N";
                    NotaFacade.AlteraProdutoNaNota(nota);

                    MovimentacaoEstoque movimentacao = new MovimentacaoEstoque();
                    movimentacao.Fornecedor = estoque.Fornecedor;
                    movimentacao.Produto = nota.Produto;
                    movimentacao.Status = "S";
                    movimentacao.Data = DateTime.Now;
                    movimentacao.Usuario = (Usuario)Session["UsuarioLogado"];
                    ProdutoFacade.CriarMovimentacaoProduto(movimentacao);
                }
                else
                {
                    string alerta = "Exclusão do Produto NÃO pode ser realizada! ";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                }

                PreencheListaDeProdutosNaNota(objProdutoNota);
            }
            //if (e.CommandName.Equals("Excluir"))
            //{
            //    Steto.ValueObjectLayer.Estoque estoque = new Steto.ValueObjectLayer.Estoque();
            //    estoque.Empresa = objProdutoNota.Empresa;
            //    estoque.Produto = objProdutoNota.Produto;
            //    Steto.ValueObjectLayer.Estoque EstoqueRecuperado = EstoqueFacade.RecuperarProdutoNoEstoque(estoque);

            //    if (EstoqueRecuperado != null)
            //    {
            //        estoque.Quantidade = EstoqueRecuperado.Quantidade - Convert.ToDecimal(GridProdutoNota.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.Trim());
            //        if (estoque.Quantidade > 0)
            //        {
            //            EstoqueFacade.AlteraQuantidadeDoProdutoNoEstoque(estoque);
            //        }
            //        else
            //        {
            //            EstoqueFacade.ExcluiProdutoNoEstoque(estoque);
            //        }

            //        NotaFacade.ExcluirProdutoDaNota(objProdutoNota);

            //        string alerta1 = "Exclusão do Produto da Nota foi realizada com sucesso! ";
            //        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
            //    }

            //    PreencheListaDeProdutosNaNota(objProdutoNota);
            //}
        }

        protected void ddlEstoqueNotaQuantidadeParcelamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Validacao.IsData(txtEstoqueNotaDataVencimento.Text))
            {
                string value = txtEstoqueValorParcelaNota.Text;
                decimal number;

                if (Decimal.TryParse(value, out number)  && !string.IsNullOrEmpty(txtEstoqueValorParcelaNota.Text))
                {
                    if (Convert.ToInt32(ddlEstoqueNotaQuantidadeParcelamento.SelectedValue) > 1)
                    {
                        btnAlterarDataVencimento.Enabled = true;
                    }
                    else
                    {
                        btnAlterarDataVencimento.Enabled = false;
                    }

                    int idVencimento = 0;
                    Nota objNota = new Nota();
                    objNota.NumeroParcela = ddlEstoqueNotaQuantidadeParcelamento.SelectedValue;

                    IList<Nota> lstNotas = new List<Nota>();

                    Nota objNotalst = null;
                    for (int i = 0; i < Convert.ToInt32(objNota.NumeroParcela); i++)
                    {
                        idVencimento = idVencimento + 1;
                        objNotalst = new Nota(idVencimento);
                        objNotalst.Vencimento = Convert.ToDateTime(txtEstoqueNotaDataVencimento.Text);
                        DateTime dtProximoVencimento = objNotalst.Vencimento.AddMonths(i);
                        objNotalst.Vencimento = dtProximoVencimento;
                        objNotalst.Valor = Convert.ToDecimal((Convert.ToDecimal(txtEstoqueValorParcelaNota.Text) / Convert.ToDecimal(objNota.NumeroParcela)).ToString("#0.00"));
                        lstNotas.Add(objNotalst);
                    }

                    GridVencimentos.DataSource = lstNotas;
                    GridVencimentos.DataBind();

                    Session["ListaDeVencimentosNotas"] = lstNotas;

                }
                else
                {
                    string alerta1 = "Preencha com um valor de parcela válida!";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                    ddlEstoqueNotaQuantidadeParcelamento.SelectedValue = "0";
                }
            }
            else
            {
                string alerta1 = "Preencha com uma Data Vencimento válida!";
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                ddlEstoqueNotaQuantidadeParcelamento.SelectedValue = "0";
            }
        }

        protected void btnEnviarVencimentos_Click(object sender, EventArgs e)
        {
            bool numerico = false;
            IList<Nota> lstNotas = new List<Nota>();
            Nota nota = null;

            foreach (GridViewRow item in GridVencimentos.Rows)
            {
                TextBox txtVencimento = item.FindControl("txtVencimento") as TextBox;
                TextBox txtValorParcela = item.FindControl("txtValorParcela") as TextBox;
                if (Steto.Util.Validacao.IsNumeric(txtValorParcela.Text))
                    numerico = true;

                if (numerico)
                {
                    nota = new Nota();
                    nota.Valor = Convert.ToDecimal(txtValorParcela.Text);
                    nota.Vencimento = Convert.ToDateTime(txtVencimento.Text);
                    lstNotas.Add(nota);
                }
            }

            Session["ListaDeVencimentosNotas"] = lstNotas;
        }

        protected void btnAlterarDataVencimento_Click(object sender, EventArgs e)
        {

        }

        public static void moeda(ref TextBox txt)
        {
            try
            {
                string n = string.Empty;
                double v = 0;

                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "000";

                n = n.PadLeft(3, '0');

                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);

                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                //txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSelecionar_Click(object sender, EventArgs e)
        {
            //Nota objNota = new Nota(Convert.ToInt32(lblEstoqueisCodigoNota.Text));
            //Empresa objEmpresa = new Empresa(Convert.ToInt32(lblEmpresaCodigo.Text));

            //int idProduto = Convert.ToInt32(GridPoduto.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.Trim());

            //decimal dcmQuantidadeEntrada = 0;
            //decimal QtdAtualEstoque = Convert.ToDecimal(GridPoduto.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text.Trim());
            //Produto objProduto = new Produto(idProduto);
            //TextBox txtValor = new TextBox();
            //bool numerico = false;

            //if (e.CommandName.Equals("Entrada"))
            //{
            //    foreach (GridViewRow item in GridPoduto.Rows)
            //    {
            //        TextBox txtValor2 = item.FindControl("txtCodigo") as TextBox;
            //        txtValor = item.FindControl("txtValorEntrada") as TextBox;
            //        if (Steto.Util.Validacao.IsNumeric(txtValor.Text))
            //        {
            //            numerico = true;
            //        }

            //        if (numerico)
            //        {
            //            if (idProduto.ToString().Equals(txtValor2.Text))
            //            {
            //                txtValor = item.FindControl("txtValorEntrada") as TextBox;

            //                dcmQuantidadeEntrada = Convert.ToDecimal(txtValor.Text);
            //                objProduto.Entrada = Convert.ToDecimal(txtValor.Text);
            //                objProduto.QuantidadeRealEstoque = QtdAtualEstoque + dcmQuantidadeEntrada;
            //                lblItensInseridos.Visible = true;
            //            }
            //        }
            //    }

            //    if (numerico)
            //    {
            //        if (Convert.ToInt32(txtValor.Text) > 0)
            //        {
            //            ProdutoNota objProdutoNota = new ProdutoNota();
            //            objProdutoNota.Empresa = objEmpresa;
            //            objProdutoNota.Nota = objNota;
            //            objProdutoNota.Produto = objProduto;

            //            if (NotaFacade.RecuperarProdutoNaNota(objProdutoNota) == null)
            //            {
            //                //ProdutoFacade.AlteraQuantidadeProduto(objProduto);
            //                NotaFacade.InserirProdutoNaNota(objProdutoNota);
            //                //PreencheListaDeProdutosNaNota(objProdutoNota);

            //                /****Adicionando Produto e sua Quantidade ao Estoque da Empresa****/
            //                Steto.ValueObjectLayer.Estoque estoque = new Steto.ValueObjectLayer.Estoque();
            //                estoque.Empresa = objEmpresa;
            //                estoque.Produto = objProduto;
            //                estoque.Fornecedor = new Fornecedor(Convert.ToInt32(ddlFornecedor.SelectedValue));
            //                Steto.ValueObjectLayer.Estoque EstoqueRecuperado = EstoqueFacade.RecuperarProdutoNoEstoque(estoque);
            //                if (EstoqueRecuperado != null)
            //                {
            //                    estoque.Quantidade = EstoqueRecuperado.Quantidade + dcmQuantidadeEntrada;
            //                    EstoqueFacade.AlteraQuantidadeDoProdutoNoEstoque(estoque);
            //                }
            //                else
            //                {
            //                    estoque.Quantidade = dcmQuantidadeEntrada;
            //                    EstoqueFacade.InserirEstoque(estoque);
            //                }
            //                /****FIM: Adicionando Produto e sua Quantidade ao Estoque da Empresa****/

            //                //ReloadBtnPesquisa();
            //                PreencheListaDeProdutosNaNota(objProdutoNota);
            //                MultiViewNota.ActiveViewIndex = 2;
            //            }
            //            else
            //            {
            //                string alerta1 = "Produto já existe na Nota! Por favor escolher outro Produto para Inserir na Nota!";
            //                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
            //            }
            //        }
            //        else
            //        {
            //            string alerta1 = "Não pode dar entrada em um produto com valor Zero!";
            //            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
            //        }
            //    }
            //    else
            //    {
            //        string alerta1 = "Valor NÃO numérico!";
            //        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
            //    }
            //}

            ///////////*************////////////////////
            IList<Produto> lstProdutos = new List<Produto>();
            
            Produto produtoJaExiste = null;
            IList<Produto> produtosExistentes = new List<Produto>(); 
            decimal totalValorEntradas = 0;

            int linha = 0;
            foreach (GridViewRow griprodutoNt in GridProdutoNota.Rows)
            {
                produtoJaExiste = new Produto(Convert.ToInt32(GridProdutoNota.Rows[linha].Cells[0].Text));
                produtoJaExiste.Descricao = GridProdutoNota.Rows[linha].Cells[1].Text;
                produtoJaExiste.QuantidadeRealEstoque = Convert.ToDecimal(GridProdutoNota.Rows[linha].Cells[2].Text);
                produtoJaExiste.Entrada = Convert.ToDecimal(GridProdutoNota.Rows[linha].Cells[3].Text);
                produtoJaExiste.ValorUnitario = Convert.ToDecimal(GridProdutoNota.Rows[linha].Cells[4].Text.Replace("R$ ", ""));
                produtoJaExiste.ValorTotal = Convert.ToDecimal(GridProdutoNota.Rows[linha].Cells[5].Text.Replace("R$ ", ""));

                produtosExistentes.Add(produtoJaExiste);
                lstProdutos.Add(produtoJaExiste);
                linha += 1;
            }

            Produto produto = null;
            
            //StringBuilder str = new StringBuilder();
            linha = 0;
            foreach (GridViewRow item in GridPoduto.Rows)
            {
                bool produtoSelecionado = (item.FindControl("chkSelect") as CheckBox).Checked;

                if (produtoSelecionado)
                {
                    produto = new Produto(Convert.ToInt32(GridPoduto.Rows[linha].Cells[1].Text));

                    if (produtosExistentes.Count > 0)
                    {
                        foreach (var jaexiste in produtosExistentes)
                        {
                            if (produto.Id != jaexiste.Id)
                            {
                                produto.Descricao = GridPoduto.Rows[linha].Cells[2].Text;
                                produto.QuantidadeRealEstoque = Convert.ToDecimal(GridPoduto.Rows[linha].Cells[3].Text) + produto.Entrada;
                                produto.Entrada = Convert.ToDecimal((item.FindControl("txtValorEntrada") as TextBox).Text);
                                produto.ValorUnitario = Convert.ToDecimal((item.FindControl("txtValorUnitario") as TextBox).Text.Replace("R$ ", ""));
                                produto.ValorTotal = produto.Entrada * produto.ValorUnitario;

                                lstProdutos.Add(produto);
                            }
                            else
                            {
                                string alerta = "Produto que está tentando inserir já existe na Nota! Por favor escolher outro Produto para Inserir na Nota!";
                                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                            }
                        }
                    }
                    else
                    {
                        produto.Descricao = GridPoduto.Rows[linha].Cells[2].Text;
                        produto.QuantidadeRealEstoque = Convert.ToDecimal(GridPoduto.Rows[linha].Cells[3].Text) + produto.Entrada;
                        produto.Entrada = Convert.ToDecimal((item.FindControl("txtValorEntrada") as TextBox).Text);
                        produto.ValorUnitario = Convert.ToDecimal((item.FindControl("txtValorUnitario") as TextBox).Text.Replace("R$ ", ""));
                        produto.ValorTotal = produto.Entrada * produto.ValorUnitario;
                        produto.Ativo = "S";

                        lstProdutos.Add(produto);
                    }
                }

                linha += 1;
            }

            linha = 0;

            if (lstProdutos.Count > 0)
            {
                GridProdutoNota.DataSource = lstProdutos;
                GridProdutoNota.DataBind();
                MultiViewNota.ActiveViewIndex = 2;

                foreach (GridViewRow griprodutoNt in GridProdutoNota.Rows)
                {
                    totalValorEntradas += Convert.ToDecimal(GridProdutoNota.Rows[linha].Cells[5].Text.Replace("R$ ", ""));
                    lblTotalValorEntradas.Text = totalValorEntradas.ToString("#0.00");

                    linha += 1;
                }
            }

            lblTotalValorEntradas.Visible = true;
            lblLabelTotal.Visible = true;
            btnEnviarParaNota.Visible = true;

           
        }

        protected void btnEnviarParaNota_Click(object sender, EventArgs e)
        {
            IList<Produto> lstProdutos = new List<Produto>();
            int linha = 0;
            Produto produtoJaExiste = null;
            IList<Produto> produtosExistentes = new List<Produto>();
            foreach (GridViewRow griprodutoNt in GridProdutoNota.Rows)
            {
                produtoJaExiste = new Produto(Convert.ToInt32(GridProdutoNota.Rows[linha].Cells[0].Text));
                produtoJaExiste.Entrada = Convert.ToDecimal(GridProdutoNota.Rows[linha].Cells[3].Text);
                produtoJaExiste.ValorUnitario = Convert.ToDecimal(GridProdutoNota.Rows[linha].Cells[4].Text.Replace("R$ ", ""));
                produtosExistentes.Add(produtoJaExiste);
                linha += 1;
            }

            if (produtosExistentes.Count > 0)
            {
                Nota objNota = new Nota(Convert.ToInt32(lblEstoqueisCodigoNota.Text));
                Empresa objEmpresa = new Empresa(Convert.ToInt32(lblEmpresaCodigo.Text));

                foreach (var produtoEnviaEstoque in produtosExistentes)
                {
                    ProdutoNota objProdutoNota = new ProdutoNota();
                    objProdutoNota.Nota = objNota;
                    objProdutoNota.Produto = produtoEnviaEstoque;
                    objProdutoNota.Ativo = "S";
                    produtoEnviaEstoque.Fornecedor = new Fornecedor(Convert.ToInt32(ddlFornecedor.SelectedValue));

                    NotaFacade.InserirProdutoNaNota(objProdutoNota);

                    /****Adicionando Produto e sua Quantidade ao Estoque da Empresa****/
                    Steto.ValueObjectLayer.Estoque estoque = new Steto.ValueObjectLayer.Estoque();
                    estoque.Produto = produtoEnviaEstoque;
                    estoque.Fornecedor = new Fornecedor(Convert.ToInt32(ddlFornecedor.SelectedValue));

                    Steto.ValueObjectLayer.Estoque EstoqueRecuperado = EstoqueFacade.RecuperarProdutoNoEstoque(estoque);
                    if (EstoqueRecuperado != null)
                    {
                        estoque.Quantidade = EstoqueRecuperado.Produto.QuantidadeRealEstoque + produtoEnviaEstoque.QuantidadeRealEstoque;
                        EstoqueFacade.AlteraQuantidadeDoProdutoNoEstoque(estoque);
                    }
                    else
                    {
                        estoque.Quantidade = produtoEnviaEstoque.QuantidadeRealEstoque;
                        EstoqueFacade.InserirEstoque(estoque);
                    }
                    /****FIM: Adicionando Produto e sua Quantidade ao Estoque da Empresa****/


                    /****CRIA uma movimentação de cada produto****/
                    Usuario usuario = (Usuario)Session["UsuarioLogado"];
                    MovimentacaoEstoque movimentacao = new MovimentacaoEstoque();
                    movimentacao.Fornecedor = new Fornecedor(Convert.ToInt32(ddlFornecedor.SelectedValue));
                    movimentacao.Produto = produtoEnviaEstoque;
                    movimentacao.Quantidade = produtoEnviaEstoque.QuantidadeRealEstoque;
                    movimentacao.Valor = produtoEnviaEstoque.ValorUnitario;
                    movimentacao.Data = DateTime.Now;
                    movimentacao.Status = "E";
                    movimentacao.Usuario = usuario;
                    int idMovimento = ProdutoFacade.CriarMovimentacaoProduto(movimentacao);

                    //if (idMovimento > 0)
                    //{
                    //    btnPesquisarProduto.Enabled = false;
                    //    GridProdutoNota.Enabled = false;
                    //    btnCriarNota.Enabled = false;
                    //    btnAlterarDataVencimento.Enabled = false;
                    //}
                }
            }
        }


        protected void resumeupload(Object sender, EventArgs e)

        {
            //int id = Int32.Parse(HiddenField1.Value);

            if (flpup.HasFile)
            {
                string filename = Path.GetFileName(flpup.PostedFile.FileName);
                flpup.SaveAs(Server.MapPath("~/ImagensNota/" + "Comprovante" + filename));//create a folder named 'files' in the solution explorer,the files will be uploaded to this folder //
                ModalPopupExtender1.Show();
            }
        }

        protected void lnkupclick(object sender, EventArgs e)
        {
            //LinkButton lnk = sender as LinkButton;
            //GridViewRow gvrow = lnk.NamingContainer as GridViewRow;

            //int id = Int32.Parse(GridContas.DataKeys[gvrow.RowIndex].Value.ToString());
            //int id = Int32.Parse(GridContas.Rows[1].Cells[0].Text);
            //HiddenField1.Value = id.ToString();

            txtDescricaoPesquisa.Text = string.Empty;
            txtDescricaoPesquisa.Focus();
            PreencheGridProdutoVazio();
            ModalPopupExtender1.Show();
        }

        protected void GridProdutoNota_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gvr = e.Row;
            
            switch (gvr.RowType)
            {
                case DataControlRowType.DataRow:
                {
                    e.Row.Cells[e.Row.Cells.Count - 1].Enabled = true;

                    if (gvr.Cells[6].Text.Equals("N"))
                    {
                        e.Row.Cells[e.Row.Cells.Count - 1].Enabled = false;
                        e.Row.ForeColor = System.Drawing.Color.Red;
                        e.Row.Font.Bold = true;
                    }

                    if (gvr.Cells[6].Text.Equals("S"))
                    {
                        if (!lblTotalValorEntradas.Text.Equals(""))
                        {
                            lblTotalValorEntradas.Text = "R$ " + (Convert.ToDecimal(lblTotalValorEntradas.Text.Replace("R$ ", "")) + Convert.ToDecimal(gvr.Cells[5].Text.Replace("R$ ", ""))).ToString();
                            lblTotalValorEntradas.Visible = true;
                        }
                        else
                        {
                            lblTotalValorEntradas.Text = gvr.Cells[5].Text;
                        }
                    }

                    break;
                }
            }
        }
    }
}