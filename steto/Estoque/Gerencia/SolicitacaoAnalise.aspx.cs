using Steto.FacadeLayer;
using Steto.FacadeLayer.Estoque;
using Steto.ValueObjectLayer;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Steto.Estoque.Gerencia
{
    public partial class SolicitacaoAnalise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Usuario usuario = (Usuario)Session["UsuarioLogado"];
                Empresa empresa = EmpresaFacade.RecuperaEmpresa(new Empresa());
                lblEmpresaCodigo.Text = string.Empty;
                lblEmpresa.Text = empresa.Nome;
                lblEmpresaCodigo.Text = empresa.Id.ToString();

                InicializaPagina();
            }

        }

        protected void InicializaPagina()
        {
            PreencheGridVazio();
            btnImprimeTermoEntrega.Visible = false;
            MultiView.ActiveViewIndex = 0;
        }

        protected void PreencheGridVazio()
        {
            Solicitacao solicitacao = new Solicitacao(0);
            solicitacao.Id = 0;
            solicitacao.Data_Solicitacao = DateTime.Now;
            solicitacao.Status = "P";
            IList<Solicitacao> lstSolicitacoes = new List<Solicitacao>();
            lstSolicitacoes.Add(solicitacao);

            GridPesquisa.DataSource = lstSolicitacoes;
            GridPesquisa.DataBind();
            GridPesquisa.Rows[0].Cells[4].Enabled = false;
        }

        protected void btnLimpaPesquisa_Click(object sender, EventArgs e)
        {
            txtNumeroSolicitacaoPesquisa.Text = string.Empty;
            txtDataSolicitacaoPesquisa.Text = string.Empty;
            PreencheGridVazio();
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedItem.Text.Equals("Entregue"))
            {
                
                Solicitacao solicitacao = new Solicitacao();

                switch (ddlStatuSolicitacaoPesquisa.SelectedValue)
                {
                    case "P":
                        solicitacao.Status = "P";
                        break;
                    case "A":
                        solicitacao.Status = "A";
                        break;
                    case "R":
                        solicitacao.Status = "R";
                        break;
                    case "E":
                        solicitacao.Status = "E";
                        break;
                    default:
                        break;
                }

                solicitacao.Id = (!txtNumeroSolicitacaoPesquisa.Text.Equals("")) ? Convert.ToInt32(txtNumeroSolicitacaoPesquisa.Text) : 0;
                if (!txtDataSolicitacaoPesquisa.Text.Equals("")) solicitacao.Data_Solicitacao = Convert.ToDateTime(txtDataSolicitacaoPesquisa.Text);


                IList<Solicitacao> solicitacoes = SolicitacaoFacade.RecuperarListaDeSolicitacoes(solicitacao);

                btnImprimeTermoEntrega.Visible = true;
            }
            else
            {
                btnImprimeTermoEntrega.Visible = false;
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Solicitacao solicitacao = new Solicitacao();

            switch (ddlStatuSolicitacaoPesquisa.SelectedValue)
            {
                case "P":
                    solicitacao.Status = "P";
                    break;
                case "A":
                    solicitacao.Status = "A";
                    break;
                case "R":
                    solicitacao.Status = "R";
                    break;
                case "E":
                    solicitacao.Status = "E";
                    break;
                default:
                    break;
            }

            solicitacao.Id = (!txtNumeroSolicitacaoPesquisa.Text.Equals("")) ? Convert.ToInt32(txtNumeroSolicitacaoPesquisa.Text) : 0;
            if (!txtDataSolicitacaoPesquisa.Text.Equals("")) solicitacao.Data_Solicitacao = Convert.ToDateTime(txtDataSolicitacaoPesquisa.Text);


            IList<Solicitacao> solicitacoes = SolicitacaoFacade.RecuperarListaDeSolicitacoes(solicitacao);

            if(solicitacoes.Count > 0)
            {
                GridPesquisa.DataSource = solicitacoes;
                GridPesquisa.DataBind();
            }
            else
            {
                PreencheGridVazio();
            }
        }

        protected void GridPesquisa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Visualizar"))
            {
                Solicitacao solicitacao = new Solicitacao(Convert.ToInt32(GridPesquisa.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim()));

                switch (ddlStatuSolicitacaoPesquisa.SelectedValue)
                {
                    case "P":
                        solicitacao.Status = "P";
                        break;
                    case "A":
                        solicitacao.Status = "A";
                        break;
                    case "R":
                        solicitacao.Status = "R";
                        break;
                    case "E":
                        solicitacao.Status = "E";
                        break;
                    default:
                        break;
                }

                solicitacao.Id = (!txtNumeroSolicitacaoPesquisa.Text.Equals("")) ? Convert.ToInt32(txtNumeroSolicitacaoPesquisa.Text) : 0;
                if (!txtDataSolicitacaoPesquisa.Text.Equals("")) solicitacao.Data_Solicitacao = Convert.ToDateTime(txtDataSolicitacaoPesquisa.Text);


                IList<Solicitacao> solicitacoes = SolicitacaoFacade.RecuperarSolicitacaoAnalise(solicitacao);

                if (solicitacoes.Count > 0)
                {
                    lblNumeroSolicitacaoImpressao.Text = solicitacoes[0].Id.ToString();
                    lblDataExtensoSolicitacaoImpressao.Text = solicitacoes[0].Data_Solicitacao.ToString("dd/MM/yyyy");
                    string status = string.Empty;
                    switch (solicitacoes[0].Status)
                    {
                        case "P":
                            status = "Pendente";
                            break;
                        case "A":
                            status = "Aprovado";
                            break;
                        case "R":
                            status = "Rejeitada";
                            break;
                        case "E":
                            status = "Entregue";
                            break;
                        default:
                            break;
                    }
                    lblStatusResultadoSolicitacaoImpressao.Text = status;
                    lblNomeFuncionarioImpressao.Text = solicitacoes[0].Funcionario.Nome;
                    lblQuantidadeProdutoDaSolicitacao.Text = solicitacoes.Count.ToString();
                    ddlStatus.SelectedValue = solicitacoes[0].Status;

                    GridProdutosSolicitacao.DataSource = solicitacoes;
                    GridProdutosSolicitacao.DataBind();

                    MultiView.ActiveViewIndex = 1;
                }
            }
        }

        protected void btnEnviaAnalise_Click(object sender, EventArgs e)
        {
            Solicitacao solicitacao = new Solicitacao(Convert.ToInt32(lblNumeroSolicitacaoImpressao.Text));
            solicitacao.Status = ddlStatus.SelectedValue;
            solicitacao.Observacao = txtObservacao.Text;
            solicitacao.Usuario = (Usuario)Session["UsuarioLogado"];
            SolicitacaoFacade.CriarSolicitacaoAnalise(solicitacao);

            if (SolicitacaoFacade.AlteraSolicitacao(solicitacao))
            {
                string alerta = "Análise enviada com sucesso!";
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
            }
        }
    }
}