using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Steto.ValueObjectLayer;
using System.Text;
using Steto.FacadeLayer;
using Steto.Util.Mensagens;

namespace Steto.Administrador.Usuario
{
    public partial class UsuarioNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PermissaoPagina();
            if (!Page.IsPostBack)
            {
                CarregaPerfis();
            }
        }

        protected bool PermissaoPagina()
        {
            try
            {
                if (Session["PerfilFuncionalidades"] != null)
                {
                    List<ValueObjectLayer.CarregarPerfil> perfisUsuario = (List<ValueObjectLayer.CarregarPerfil>)Session["PerfilFuncionalidades"];
                    bool flagPermissaoPagina = false;
                    bool flagUsuEditar = false;
                    foreach (ValueObjectLayer.CarregarPerfil funcionalidade in perfisUsuario)
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

        protected void DesabilitaCampos()
        {
            ddlPerfil.Enabled = false;
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtLogin.Enabled = false;
            txtSenha.Enabled = false;
            txtConfirmarSenha.Enabled = false;
            btnSalvar.Visible = false;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ValueObjectLayer.Usuario usuario = new ValueObjectLayer.Usuario();
            bool enviarEmail = true;
            bool emailPreenchido = true;
            try
            {
                if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtLogin.Text) &&
                    !string.IsNullOrEmpty(txtSenha.Text) && !string.IsNullOrEmpty(txtConfirmarSenha.Text))
                {
                    //if (UsuarioFacade.ValidarEmail(txtEmailN.Text))
                    //{
                        if (UsuarioFacade.ValidarLogin(txtLogin.Text))
                        {
                            if (txtSenha.Text.Equals(txtConfirmarSenha.Text))
                            {
                                if (txtSenha.Text.Length > 5)
                                {
                                    
                                    usuario.Nome = txtNome.Text;
                                    usuario.Email = txtEmail.Text;
                                    usuario.Login = txtLogin.Text;
                                    usuario.Senha = txtSenha.Text;

                                    emailPreenchido = (string.IsNullOrEmpty(txtEmail.Text)) ? false : true;
                                    if (emailPreenchido)
                                        enviarEmail =  EmailFacade.ValidarEmail(txtEmail.Text);

                                    if (enviarEmail)
                                    {
                                        int newID = UsuarioFacade.CriarUsuario(usuario);
                                        if (newID > 0)
                                        {
                                            ValueObjectLayer.Usuario usuario_ = new ValueObjectLayer.Usuario();
                                            ValueObjectLayer.Perfil perfil_ = new ValueObjectLayer.Perfil();
                                            ValueObjectLayer.Perfil_Usuario perfilUsuario = new ValueObjectLayer.Perfil_Usuario();
                                            perfil_.Id = Convert.ToInt32(ddlPerfil.SelectedValue);
                                            usuario_.Id = newID;
                                            perfilUsuario._Usuario = usuario_;
                                            perfilUsuario._Perfil = perfil_;

                                            if (!ddlPerfil.SelectedValue.Equals("0"))
                                                UsuarioPerfilFacade.AlteraPerfilUsuario(perfilUsuario);

                                            if (emailPreenchido && enviarEmail)
                                            {
                                                ValueObjectLayer.Email email = EmailFacade.RecuperarConfiguracaoEmail(ValueObjectLayer.TipoEmail.Empresa);

                                                if (email.EnviarEmail)
                                                {
                                                    email = new ValueObjectLayer.Email();
                                                    StringBuilder sb = new StringBuilder();
                                                    sb.Append("Sr/Sra: " + txtNome.Text + "\n\r");
                                                    sb.Append("Seu cadastro foi criado com sucesso!\n\r");
                                                    sb.Append("Abaixo veja os seus dados para acesso ao sistema:\n\r");
                                                    sb.Append("Login: " + txtLogin.Text + "\n\r");
                                                    sb.Append("Senha: " + txtSenha.Text + "\n\r");
                                                    string msgUsuario = sb.ToString();
                                                    EmailFacade.EnviarEmail(usuario, msgUsuario);
                                                }
                                            }
                                            Session["Mensagem"] = 1;
                                            Response.Redirect(@"~/Administrador/Usuario/UsuarioPesquisa.aspx");
                                            //lblMsg.Text = BusinessLayer.Mensagens.MinhaMensagem.GetStringValue(BusinessLayer.Mensagens.Mensagen.CADASTRO.ToString());
                                        }
                                        else
                                        {
                                            lblMsg.Text = MensagensValor.GetStringValue(Mensagem.CADASTRO_NAO_REALIZADO.ToString());
                                        }
                                    }
                                    else
                                    {
                                            lblMsg.Text = MensagensValor.GetStringValue(Mensagem.EMAIL_INVALIDO.ToString());
                                    }
                                }
                                else
                                {
                                    lblMsg.Text = MensagensValor.GetStringValue(Mensagem.TAMANHO_SENHA_INVALIDA.ToString());
                                }
                            }
                            else
                            {
                                lblMsg.Text = MensagensValor.GetStringValue(Mensagem.SENHA_NAO_CONFERE.ToString());
                            }
                        }
                        else 
                        {
                            lblMsg.Text = MensagensValor.GetStringValue(Mensagem.LOGIN_EXISTE.ToString());
                        }
                    //}
                    //else
                    //{
                    //    lblMsg.Text = BusinessLayer.Mensagens.MensagensValor.GetStringValue(BusinessLayer.Mensagens.Mensagem.EMAIL_INVALIDO.ToString());
                    //}
                }
                else
                {
                    lblMsg.Text = MensagensValor.GetStringValue(Mensagem.CAMPO_OBRIGATORIO.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CarregaPerfis()
        {
            IList<ValueObjectLayer.Perfil> perfis = PerfilFacade.RecuperarPerfis(true);
            ValueObjectLayer.Perfil perfil = new ValueObjectLayer.Perfil();
            perfil.Id = 0;
            perfil.Descricao = "Nenhum";
            perfis.Add(perfil);

            if (perfis != null)
            {
                ddlPerfil.DataSource = perfis;
                ddlPerfil.DataTextField = "Descricao";
                ddlPerfil.DataValueField = "Id";
                ddlPerfil.DataBind();
                ddlPerfil.SelectedValue = "0";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Administrador/Usuario/UsuarioPesquisa.aspx");
        }
    }
}