using Steto.FacadeLayer;
using Steto.FacadeLayer.Estoque;
using Steto.Util;
using Steto.ValueObjectLayer;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Steto.Financeiro
{
    public partial class ContasReceber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IniciaPagina();
            }
        }

        protected void IniciaPagina()
        {
            Usuario usuario = (Usuario)Session["UsuarioLogado"];
            Empresa empresa = EmpresaFacade.RecuperaEmpresa(new Empresa());
            lblEmpresaCodigo.Text = string.Empty;
            lblEmpresa.Text = empresa.Nome;
            lblEmpresaCodigo.Text = empresa.Id.ToString();

            txtDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            PreencherClientes();
        }

        protected void rblFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strFormaPagamento = string.Empty;
            if (rblFormaPagamento.SelectedIndex == 0)
            {
                strFormaPagamento = rblFormaPagamento.SelectedItem.Text;
            }
            else if (rblFormaPagamento.SelectedIndex == 1)
            {
                strFormaPagamento = rblFormaPagamento.SelectedItem.Text;
            }
            else if (rblFormaPagamento.SelectedIndex == 2)
            {
                strFormaPagamento = rblFormaPagamento.SelectedItem.Text;
            }
            else
                strFormaPagamento = rblFormaPagamento.SelectedItem.Text;
        }

        protected void PreencherClientes()
        {
            Cliente cliente = new Cliente();
            //cliente.Empresa = new Empresa(Convert.ToInt32(lblEmpresaCodigo.Text));
            IList<Cliente> lstClientes = ClienteFacade.RecuperaVariosClientesPorEmpresa(cliente);

            Cliente objCliente = new Cliente();
            objCliente.Id = 0;
            objCliente.Nome = "Selecione";
            lstClientes.Add(objCliente);

            objCliente = new Cliente();
            objCliente.Id = 1;
            lstClientes.Add(objCliente);

            ddlClientes.DataSource = lstClientes;
            ddlClientes.DataTextField = "Nome";
            ddlClientes.DataValueField = "Id";
            ddlClientes.DataBind();
            ddlClientes.SelectedValue = "0";
        }


        protected bool ValidaNota()
        {
            try
            {
                bool VerifiqueCampo = true;

                bool[] array = new bool[12];

                if (!string.IsNullOrEmpty(txtNumeroDocumento.Text))
                {
                    lblNumeroDocumento.ForeColor = System.Drawing.Color.Black;
                    array[0] = true;
                }
                else
                {
                    lblNumeroDocumento.ForeColor = System.Drawing.Color.Red;
                    array[0] = false;
                }



                if (Convert.ToInt32(ddlClientes.SelectedValue) > 0)
                {

                    lblCliente.ForeColor = System.Drawing.Color.Black;
                    array[1] = true;
                }
                else
                {
                    lblCliente.ForeColor = System.Drawing.Color.Red;
                    array[1] = false;
                }

                if (!string.IsNullOrEmpty(txtDataEmissao.Text))
                {
                    if (Validacao.IsData(txtDataEmissao.Text))
                    {
                        lblDataEmissao.ForeColor = System.Drawing.Color.Black;
                        array[2] = true;
                    }
                    else
                    {
                        string alerta = "Verifique o formato da data de Emissao! Ela deve estar no formato: dd/MM/AAAA ";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                    }
                }
                else
                {
                    lblDataEmissao.ForeColor = System.Drawing.Color.Red;
                    array[2] = false;
                }

                if (!string.IsNullOrEmpty(txtDataVencimento.Text))
                {
                    if (Validacao.IsData(txtDataVencimento.Text))
                    {
                        lblDataVencimento.ForeColor = System.Drawing.Color.Black;
                        array[3] = true;
                    }
                    else
                    {
                        string alerta = "Verifique o formato da data de Vencimento! Ela deve estar no formato: dd/MM/AAAA ";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                    }
                }
                else
                {
                    lblDataVencimento.ForeColor = System.Drawing.Color.Red;
                    array[3] = false;
                }

                if (!string.IsNullOrEmpty(txtDataPagamento.Text))
                {
                    if (Validacao.IsData(txtDataPagamento.Text))
                    {
                        lblDataPagamento.ForeColor = System.Drawing.Color.Black;
                        array[4] = true;
                    }
                    else
                    {
                        string alerta = "Verifique o formato da data de Vencimento! Ela deve estar no formato: dd/MM/AAAA ";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                    }
                }
                else
                {
                    lblDataPagamento.ForeColor = System.Drawing.Color.Red;
                    array[4] = false;
                }

                if (!string.IsNullOrEmpty(txtValorDocumento.Text))
                {
                    lblValorDocumento.ForeColor = System.Drawing.Color.Black;
                    array[5] = true;
                }
                else
                {
                    lblValorDocumento.ForeColor = System.Drawing.Color.Red;
                    array[5] = false;
                }

                if (!string.IsNullOrEmpty(txtDesconto.Text))
                {
                    lblDesconto.ForeColor = System.Drawing.Color.Black;
                    array[6] = true;
                }
                else
                {
                    lblDesconto.ForeColor = System.Drawing.Color.Red;
                    array[6] = false;
                }

                if (!string.IsNullOrEmpty(txtAcrescimo.Text))
                {
                    lblAcrescimo.ForeColor = System.Drawing.Color.Black;
                    array[7] = true;
                }
                else
                {
                    lblAcrescimo.ForeColor = System.Drawing.Color.Red;
                    array[7] = false;
                }

                if (!string.IsNullOrEmpty(txtTotalReceber.Text))
                {
                    lblTotalReceber.ForeColor = System.Drawing.Color.Black;
                    array[8] = true;
                }
                else
                {
                    lblTotalReceber.ForeColor = System.Drawing.Color.Red;
                    array[8] = false;
                }

                if (!string.IsNullOrEmpty(txtObservacao.Text))
                {
                    lblObservacao.ForeColor = System.Drawing.Color.Black;
                    array[9] = true;
                }
                else
                {
                    lblObservacao.ForeColor = System.Drawing.Color.Red;
                    array[9] = false;
                }

                if (Convert.ToInt32(ddlQuantidadeParcela.SelectedValue) > 0)
                {

                    lblParcela.ForeColor = System.Drawing.Color.Black;
                    array[10] = true;
                }
                else
                {
                    lblParcela.ForeColor = System.Drawing.Color.Red;
                    array[10] = false;
                }

                if (!rblFormaPagamento.SelectedValue.Equals(""))
                {
                    lblFormaPagamento.ForeColor = System.Drawing.Color.Black;
                    array[11] = true;
                }
                else
                {
                    lblFormaPagamento.ForeColor = System.Drawing.Color.Red;
                    array[11] = false;
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


        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaNota())
                {
                    int recibos = GridVencimentos.Rows.Count;
                    //Conta conta = null;

                    foreach (GridViewRow item in GridVencimentos.Rows)
                    {
                        //conta = new Conta();

                        //conta.NumeroDocumento = txtNumeroDocumento.Text;
                        //conta.FormaPagamento = rblFormaPagamento.SelectedValue;
                        //conta.Cliente = new Cliente(Convert.ToInt32(ddlClientes.SelectedValue));
                        //conta.Emissao = Convert.ToDateTime(txtDataEmissao.Text);
                        //conta.Vencimento = Convert.ToDateTime((item.FindControl("txtVencimento") as TextBox).Text);
                        //conta.Pagamento = Convert.ToDateTime(txtDataPagamento.Text);
                        //conta.ValorDocumento = Convert.ToDecimal(txtValorDocumento.Text);
                        //conta.Desconto = Convert.ToDecimal(txtDesconto.Text);
                        //conta.Acrescimo = Convert.ToDecimal(txtAcrescimo.Text);
                        //conta.Valor = Convert.ToDecimal((item.FindControl("txtValorParcela") as TextBox).Text);
                        //conta.N_Parcela = ddlQuantidadeParcela.SelectedValue;
                        //conta.Observacao = txtObservacao.Text;
                        //conta.PagarReceber = "R";
                        //conta.Status = "N";
                        //ContaFacade.CadastraConta(conta);
                    }
                }
                else
                {
                    string alerta = "Verifique Campos Obrigatórios! ";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                }
            }
            catch (Exception)
            {
                string alerta = "Favor, entre com contato com o Administrador! ";
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
            }
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            txtTotalReceber.Text = ((Convert.ToDecimal(txtValorDocumento.Text) + Convert.ToDecimal(txtAcrescimo.Text)) - Convert.ToDecimal(txtDesconto.Text)).ToString("#0.00");
        }

        protected void btnEnviarContaReceberAnalise_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlQuantidadeParcela.SelectedValue) > 0)
            {
                lblParcela.ForeColor = System.Drawing.Color.Black;

                if (Validacao.IsData(txtDataVencimento.Text))
                {
                    string value = txtTotalReceber.Text;
                    decimal number;

                    if (Decimal.TryParse(value, out number) && !string.IsNullOrEmpty(txtTotalReceber.Text))
                    {
                        //if (Convert.ToInt32(ddlQuantidadeParcela.SelectedValue) > 1)
                        //{
                        //    btnAlterarDataVencimento.Enabled = true;
                        //}
                        //else
                        //{
                        //    btnAlterarDataVencimento.Enabled = false;
                        //}

                        int idVencimento = 0;
                        Nota objNota = new Nota();
                        objNota.NumeroParcela = ddlQuantidadeParcela.SelectedValue;

                        IList<Nota> lstNotas = new List<Nota>();

                        Nota objNotalst = null;
                        for (int i = 0; i < Convert.ToInt32(objNota.NumeroParcela); i++)
                        {
                            idVencimento = idVencimento + 1;
                            objNotalst = new Nota(idVencimento);
                            objNotalst.NumeroDocumento = txtNumeroDocumento.Text + "/" + idVencimento.ToString();
                            objNotalst.Vencimento = Convert.ToDateTime(txtDataVencimento.Text);
                            DateTime dtProximoVencimento = objNotalst.Vencimento.AddMonths(i);
                            objNotalst.Vencimento = dtProximoVencimento;
                            objNotalst.Valor = Convert.ToDecimal((Convert.ToDecimal(txtTotalReceber.Text) / Convert.ToDecimal(objNota.NumeroParcela)).ToString("#0.00"));
                            lstNotas.Add(objNotalst);
                        }

                        GridVencimentos.DataSource = lstNotas;
                        GridVencimentos.DataBind();

                        //Session["ListaDeVencimentosNotas"] = lstNotas;

                        btnCadastrar.Visible = true;

                    }
                    else
                    {
                        string alerta1 = "Preencha com um valor de parcela válida!";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                        ddlQuantidadeParcela.SelectedValue = "0";
                    }
                }
                else
                {
                    string alerta1 = "Preencha com uma Data Vencimento válida!";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                    ddlQuantidadeParcela.SelectedValue = "0";
                }
            }
            else
            {
                lblParcela.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}