using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Steto.ValueObjectLayer;
using System.Text.RegularExpressions;
using Steto.FacadeLayer;
using System.Text;
using Steto.Util.Mensagens;

namespace Steto.Administrador.Usuario
{
    public partial class UsuarioPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PermissaoPagina();
            if (!Page.IsPostBack)
            {
                int idUsuario = (int)Session["idUsuario"];
                LimpaCampos();
                CarregaPerfis();
                PreencheCampos(idUsuario);
                DesabilitaCampos();
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
                        if (funcionalidade._Funcionalidade.Descricao.Equals("Usuário"))
                        {
                            flagPermissaoPagina = true;
                            if (funcionalidade._Permissao.Nome.Equals("Editar"))
                            {
                                flagUsuEditar = true;
                            }

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

        protected void LimpaCampos()
        {
            txtNome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtLogin.Text = string.Empty;
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
            }
        }

        protected void PreencheCampos(int idUsuario)
        {
            try
            {
                ValueObjectLayer.Usuario ObjUsuario = new ValueObjectLayer.Usuario(idUsuario);
                ValueObjectLayer.Usuario SssUsuario = (ValueObjectLayer.Usuario)Session["UsuarioLogado"];
                ValueObjectLayer.Empresa empresa = EmpresaFacade.RecuperaEmpresa(new ValueObjectLayer.Empresa());
                //ObjUsuario.Empresa = empresa;

                ValueObjectLayer.Usuario usuario = UsuarioFacade.RecuperarUsuario(ObjUsuario);
                ValueObjectLayer.Perfil_Usuario perfilUsuario = UsuarioPerfilFacade.RecuperarPerfilUsuario(usuario.Id);

                if (perfilUsuario != null)
                {
                    ddlPerfil.SelectedValue = perfilUsuario._Perfil.Id.ToString();
                }
                else
                {
                    ddlPerfil.SelectedValue = "0";
                }

                txtNome.Text = usuario.Nome;
                txtEmail.Text = usuario.Email;
                txtLogin.Text = usuario.Login;
                if (usuario.Ativo)
                {
                    lblAtivo.Text = "Sim";
                }
                else 
                {
                    lblAtivo.Text = "Não";
                    DesabilitaCampos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DesabilitaCampos()
        {
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtLogin.Enabled = false;
            btnAlterar.Visible = false;
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                //if(UsuarioFacade.Logar(txtLogin.Text, txtSenhaAtual.Text))
                //{
                if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtEmail.Text) &&
                    !string.IsNullOrEmpty(txtLogin.Text))
                {
                    //if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtEmail.Text) &&
                    //    !string.IsNullOrEmpty(txtLogin.Text) && !string.IsNullOrEmpty(txtSenha.Text) && !string.IsNullOrEmpty(txtCSenha.Text))
                    //{
                    if (EmailFacade.ValidarEmail(txtEmail.Text))
                    {
                        //if (txtSenha.Text.Equals(txtCSenha.Text))
                        //{
                            //if (txtSenha.Text.Length > 5)
                            //{
                                ValueObjectLayer.Usuario usuario = new ValueObjectLayer.Usuario();
                                usuario.Id = (int)Session["idUsuario"];
                                usuario.Nome = txtNome.Text;
                                usuario.Email = txtEmail.Text;
                                usuario.Login = txtLogin.Text;
                                //usuario.Senha = txtSenha.Text;

                                ValueObjectLayer.Perfil_Usuario perfilUsuario = new ValueObjectLayer.Perfil_Usuario();
                                //perfilUsuario.IdPerfil = Convert.ToInt32(ddlPerfil.SelectedValue);
                                perfilUsuario._Perfil.Id = Convert.ToInt32(ddlPerfil.SelectedValue);
                                perfilUsuario._Usuario.Id = usuario.Id;
                                UsuarioPerfilFacade.AlteraPerfilUsuario(perfilUsuario);

                                if (UsuarioFacade.AlteraUsuario(usuario))
                                {
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append("Sr/Sra: " + txtNome.Text + "\n\r");
                                    sb.Append("Seu cadastro foi criado com sucesso!\n\r");
                                    sb.Append("Login: " + txtNome.Text + "\n\r");
                                    string msgEmail = sb.ToString();

                                    Session.Remove("idUsuario");
                                    Session["Mensagem"] = 2;
                                    Response.Redirect(@"~/Administrador/Usuario/UsuarioPesquisa.aspx");
                                }
                                else
                                {
                                    lblMsg.Text = MensagensValor.GetStringValue(Mensagem.CADASTRO_NAO_REALIZADO.ToString());
                                }
                            //}
                            //else
                            //{
                            //    lblMsg.Text = BusinessLayer.Mensagens.MensagensValor.GetStringValue(BusinessLayer.Mensagens.Mensagem.TAMANHO_SENHA_INVALIDA.ToString());
                            //}
                        //}
                        //else
                        //{
                        //    lblMsg.Text = BusinessLayer.Mensagens.MensagensValor.GetStringValue(BusinessLayer.Mensagens.Mensagem.SENHA_NAO_CONFERE.ToString());
                        //}

                    }
                    else
                    {
                        lblMsg.Text = MensagensValor.GetStringValue(Mensagem.EMAIL_INVALIDO.ToString());
                    }
                }
                else
                {
                    lblMsg.Text = MensagensValor.GetStringValue(Mensagem.CAMPO_OBRIGATORIO.ToString());
                }
                //}
                //else
                //{
                //    lblMsg.Text = BusinessLayer.Mensagens.MensagensValor.GetStringValue(BusinessLayer.Mensagens.Mensagem.LOGIN_INVALIDO.ToString());
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
    }
}