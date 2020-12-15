using Steto.FacadeLayer;
using Steto.ValueObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Steto.Estoque.Gerencia
{
    public partial class SolicitacaoImpressao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<Solicitacao> lstSolicitacoes = (IList<Solicitacao>)Session["lstSolicitacoes"];
            GerarSolicitacao(lstSolicitacoes);

         
            lblNumeroSolicitacaoImpressao.Text = lstSolicitacoes[0].Id.ToString();
            lblDataExtensoSolicitacaoImpressao.Text = lstSolicitacoes[0].Data_Solicitacao.ToString("dd/MM/yyyy");
            lblStatusResultadoSolicitacaoImpressao.Text = lstSolicitacoes[0].Status;
            lblNomeFuncionarioImpressao.Text = lstSolicitacoes[0].Funcionario.Nome;
        }

        protected void GerarSolicitacao(IList<Solicitacao> lstSolicitacoes)
        {
            Usuario usuario = (Usuario)Session["UsuarioLogado"];
            Empresa empresa = EmpresaFacade.RecuperaEmpresa(new Empresa());
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
    }
}