using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Steto.ValueObjectLayer;
using System.Text;
using Steto.Util.Mensagens;
using System.Web.Mail;
using Steto.FacadeLayer.Estoque;
using Steto.FacadeLayer;

namespace Amago.Web.Estoque.Gerencia
{
    public partial class EstoquePesquisa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PermissaoPagina();
            if (!Page.IsPostBack)
            {
                PreencheGridProdutoVazio();
                MultiViewProduto.Visible = false;
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
            produto.QuantidadeRealEstoque = 10;
            produto.ValorTotal = produto.ValorUnitario * produto.QuantidadeRealEstoque;
            produto.QuantidadeMinimaEstoque = 0;

            IList<Produto> produtos = new List<Produto>();
            produtos.Add(produto);

            GridPoduto.DataSource = produtos;
            GridPoduto.DataBind();
            GridPoduto.Rows[0].Cells[4].Enabled = false;
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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                //if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtLogin.Text) &&
                //    !string.IsNullOrEmpty(txtSenha.Text) && !string.IsNullOrEmpty(txtConfirmarSenha.Text))
                //{
                //    //if (UsuarioFacade.ValidarEmail(txtEmailN.Text))
                //    //{
                //        if (UsuarioFacade.ValidarLogin(txtLogin.Text))
                //        {
                //            if (txtSenha.Text.Equals(txtConfirmarSenha.Text))
                //            {
                //                if (txtSenha.Text.Length > 5)
                //                {

                //                    usuario.Nome = txtNome.Text;
                //                    usuario.Email = txtEmail.Text;
                //                    usuario.Login = txtLogin.Text;
                //                    usuario.Senha = txtSenha.Text;

                //                    emailPreenchido = (string.IsNullOrEmpty(txtEmail.Text)) ? false : true;
                //                    if (emailPreenchido)
                //                        enviarEmail =  EmailFacade.ValidarEmail(txtEmail.Text);

                //                    if (enviarEmail)
                //                    {
                //                        int newID = UsuarioFacade.CriarUsuario(usuario);
                //                        if (newID > 0)
                //                        {
                //                            ValueObjectLayer.Usuario usuario_ = new ValueObjectLayer.Usuario();
                //                            ValueObjectLayer.Perfil perfil_ = new ValueObjectLayer.Perfil();
                //                            ValueObjectLayer.Perfil_Usuario perfilUsuario = new ValueObjectLayer.Perfil_Usuario();
                //                            perfil_.Id = Convert.ToInt32(ddlPerfil.SelectedValue);
                //                            usuario_.Id = newID;
                //                            perfilUsuario._Usuario = usuario_;
                //                            perfilUsuario._Perfil = perfil_;

                //                            if (!ddlPerfil.SelectedValue.Equals("0"))
                //                                UsuarioPerfilFacade.AlteraPerfilUsuario(perfilUsuario);

                //                            if (emailPreenchido && enviarEmail)
                //                            {
                //                                ValueObjectLayer.Email email = EmailFacade.RecuperarConfiguracaoEmail(ValueObjectLayer.TipoEmail.Empresa);

                //                                if (email.EnviarEmail)
                //                                {
                //                                    email = new ValueObjectLayer.Email();
                //                                    StringBuilder sb = new StringBuilder();
                //                                    sb.Append("Sr/Sra: " + txtNome.Text + "\n\r");
                //                                    sb.Append("Seu cadastro foi criado com sucesso!\n\r");
                //                                    sb.Append("Abaixo veja os seus dados para acesso ao sistema:\n\r");
                //                                    sb.Append("Login: " + txtLogin.Text + "\n\r");
                //                                    sb.Append("Senha: " + txtSenha.Text + "\n\r");
                //                                    string msgUsuario = sb.ToString();
                //                                    EmailFacade.EnviarEmail(usuario, msgUsuario);
                //                                }
                //                            }
                //                            Session["Mensagem"] = 1;
                //                            Response.Redirect(@"~/Administrador/Usuario/UsuarioPesquisa.aspx");
                //                            //lblMsg.Text = BusinessLayer.Mensagens.MinhaMensagem.GetStringValue(BusinessLayer.Mensagens.Mensagen.CADASTRO.ToString());
                //                        }
                //                        else
                //                        {
                //                            lblMsg.Text = MensagensValor.GetStringValue(Mensagem.CADASTRO_NAO_REALIZADO.ToString());
                //                        }
                //                    }
                //                    else
                //                    {
                //                            lblMsg.Text = MensagensValor.GetStringValue(Mensagem.EMAIL_INVALIDO.ToString());
                //                    }
                //                }
                //                else
                //                {
                //                    lblMsg.Text = MensagensValor.GetStringValue(Mensagem.TAMANHO_SENHA_INVALIDA.ToString());
                //                }
                //            }
                //            else
                //            {
                //                lblMsg.Text = MensagensValor.GetStringValue(Mensagem.SENHA_NAO_CONFERE.ToString());
                //            }
                //        }
                //        else 
                //        {
                //            lblMsg.Text = MensagensValor.GetStringValue(Mensagem.LOGIN_EXISTE.ToString());
                //        }
                //    //}
                //    //else
                //    //{
                //    //    lblMsg.Text = BusinessLayer.Mensagens.MensagensValor.GetStringValue(BusinessLayer.Mensagens.Mensagem.EMAIL_INVALIDO.ToString());
                //    //}
                //}
                //else
                //{
                //    lblMsg.Text = MensagensValor.GetStringValue(Mensagem.CAMPO_OBRIGATORIO.ToString());
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Administrador/Usuario/UsuarioPesquisa.aspx");
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtDescricaoPesquisa.Text) || Convert.ToInt32(ddlEstoqueProduto.SelectedValue) <= 1)
            {
                Usuario usuario = (Usuario)Session["UsuarioLogado"];

                Produto produto = new Produto();
                produto.Descricao = (txtDescricaoPesquisa.Text != string.Empty) ? txtDescricaoPesquisa.Text : string.Empty;
                produto.ConsumoInterno = Convert.ToInt32(ddlEstoqueProduto.SelectedValue);

                IList<Produto> lstProdutos = ProdutoFacade.RecuperarProduto(produto);

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

        protected void BtnFecharCadastro_Click(object sender, EventArgs e)
        {
            MultiViewProduto.Visible = false;
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            MultiViewProduto.Visible = true;
        }
    }
}