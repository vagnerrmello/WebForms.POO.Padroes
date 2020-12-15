using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Steto.ValueObjectLayer;
using Steto.FacadeLayer;
using Steto.Util.Mensagens;

namespace Steto.Administrador.Configuracoes
{
    public partial class EmailEditar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PermissaoPagina();

            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                string teste = Cryptography.GerarDescriptografia(Request.QueryString["id"].ToString(), "36?@#!$a");
            }
            if (!Page.IsPostBack)
            {
                int idEmail = (int)Session["IdEmail"];
                PreencheCampos(idEmail);
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
                    bool flagEmailEditar = false;
                    foreach (ValueObjectLayer.CarregarPerfil funcionalidade in perfisUsuario)
                    {
                        //if (funcionalidade.NomeFuncionalidade.Equals("Configurações"))
                        if (funcionalidade._Funcionalidade.Descricao.Equals("Configurações"))
                        {
                            flagPermissaoPagina = true;
                            //if (funcionalidade.NomePermissao.Equals("Editar"))
                            if (funcionalidade._Permissao.Nome.Equals("Editar"))
                            {
                                flagEmailEditar = true;
                            }
                        }
                    }

                    if (!flagPermissaoPagina || !flagEmailEditar)
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


        protected void PreencheCampos(int idEmail) 
        {
            try
            {
                ValueObjectLayer.Email email = EmailFacade.RecuperarConfiguracaoEmail(ValueObjectLayer.TipoEmail.Empresa);



                    if (Convert.ToBoolean(email.EnviarEmail))
                    {
                        CheckEnviarEmail.Checked = true;
                    }
                    else
                    {
                        CheckEnviarEmail.Checked = false;
                    }

                    if (Convert.ToBoolean(email.EnviarEmailAdm))
                    {
                        CheckAdm.Checked = true;
                    }
                    else
                    {
                        CheckAdm.Checked = false;
                    }

                    if (Convert.ToBoolean(email.EnviarEmailGestor))
                    {
                        CheckGestor.Checked = true;
                    }
                    else
                    {
                        CheckGestor.Checked = false;
                    }

                    if (Convert.ToBoolean(email.Ssl))
                    {
                        CheckSsl.Checked = true;
                    }
                    else
                    {
                        CheckSsl.Checked = false;
                    }

                    txtPorta.Text = email.Porta.ToString();
                    if (Convert.ToBoolean(email.UsarPorta))
                    {
                        CheckPorta.Checked = true;
                        lblPorta.Enabled = true;
                        txtPorta.Enabled = true;
                    }
                    else
                    {
                        CheckPorta.Checked = false;
                        lblPorta.Enabled = false;
                        txtPorta.Enabled = false;
                    }

                    txtSmtp.Text = email.Smtp;
                    txtAssunto.Text = email.Assunto;
                    txtCorpoEmail.Text = email.CorpoEmail;
                    txtEmailEmpresa.Text = email.Email_Empresa;
                    txtUsuario.Text = email.UsuarioEmailEmpresa;
                    txtSenha.Text = email.SenhaEmailEmpresa;

                    if (Convert.ToBoolean(email.EnviarEmail))
                    {
                        HabilitaCampos();
                    }
                    else
                    {
                        DesabilitaCampos();
                    }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void HabilitaCampos()
        {
            CheckAdm.Enabled = true;
            CheckGestor.Enabled = true;
            txtPorta.Enabled = true;
            CheckPorta.Enabled = true;
            CheckSsl.Enabled = true;
            txtSmtp.Enabled = true;
            txtAssunto.Enabled = true;
            txtCorpoEmail.Enabled = true;
            txtEmailEmpresa.Enabled = true;
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
            btnAlterar.Enabled = true;
        }

        protected void DesabilitaCampos()
        {
                CheckAdm.Enabled = false;
                CheckGestor.Enabled = false;
                txtPorta.Enabled = false;
                CheckPorta.Enabled = false;
                CheckSsl.Enabled = false;
                txtSmtp.Enabled = false;
                txtAssunto.Enabled = false;
                txtCorpoEmail.Enabled = false;
                txtEmailEmpresa.Enabled = false;
                txtUsuario.Enabled = false;
                txtSenha.Enabled = false;
                //btnAlterar.Enabled = false;
        }

        protected void CheckAdm_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckAdm.Checked)
            {
                lblEmailAdm.Enabled = true;
                txtEmailAdm.Enabled = true;
            }
            else
            {
                lblEmailAdm.Enabled = false;
                txtEmailAdm.Enabled = false;
            }
        }

        protected void CheckGestor_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckGestor.Checked)
            {
                lblEmailGestor.Enabled = true;
                txtEmailGestor.Enabled = true;
            }
            else
            {
                lblEmailGestor.Enabled = false;
                txtEmailGestor.Enabled = false;
            }
        }

        protected void CheckPorta_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckPorta.Checked)
            {
                lblPorta.Enabled = true;
                txtPorta.Enabled = true;
            }
            else
            {
                lblPorta.Enabled = false;
                txtPorta.Enabled = false;
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                ValueObjectLayer.Email email = new ValueObjectLayer.Email();

                ValueObjectLayer.Email_Tipo emailtipo = new Email_Tipo(Convert.ToInt32(ValueObjectLayer.TipoEmail.Empresa));
                ValueObjectLayer.Funcionalidade funcionalidade = new ValueObjectLayer.Funcionalidade(6);
                email.Id = (int)Session["IdEmail"];
                email._Email_Tipo = emailtipo;
                email._Funcionalidade = funcionalidade;
                email.EnviarEmail = CheckEnviarEmail.Checked;
                email.Ssl = CheckSsl.Checked;

                if (CheckAdm.Checked)
                {
                    email.EnviarEmailAdm = true;
                    //email.EmailAdm = txtEmailAdm.Text;
                }
                else
                {
                    email.EnviarEmailAdm = false;
                    email.EmailAdm = string.Empty; 
                }

                if (CheckGestor.Checked)
                {
                    email.EnviarEmailGestor = true;
                    //email.EmailGestor = txtEmailGestor.Text;
                }
                else
                {
                    email.EnviarEmailGestor = false;
                    email.EmailGestor = string.Empty;
                }

                if (CheckPorta.Checked)
                {
                    email.UsarPorta = true;
                    int valor;

                    if (Int32.TryParse(txtPorta.Text, out valor))
                    {
                        email.Porta = valor;
                    }
                    else
                    {
                        lblMsg.Text =  MensagensValor.GetStringValue(Mensagem.VALOR_NAO_NUMERICO.ToString());
                        return;
                    }
                }
                else
                {
                    email.UsarPorta = false;
                }
                
                email.Smtp = txtSmtp.Text;
                email.Assunto = txtAssunto.Text;
                email.CorpoEmail = txtCorpoEmail.Text;
                email.Email_Empresa = txtEmailEmpresa.Text;
                email.UsuarioEmailEmpresa = txtUsuario.Text;
                email.SenhaEmailEmpresa = txtSenha.Text;

                if (EmailFacade.SalvaConfiguracaoEmail(email))
                {
                    lblMsg.Text = MensagensValor.GetStringValue(Mensagem.ALTERADO.ToString());
                    Session["Alteracao"] = true;
                    Response.Redirect(@"~/Administrador/Configuracoes/Email.aspx");
                }
                else
                {
                    lblMsg.Text = MensagensValor.GetStringValue(Mensagem.ALTERADO_NAO_REALIZADO.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Administrador/Configuracoes/Email.aspx");
        }

        protected void CheckEnviarEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckEnviarEmail.Checked)
            {
                HabilitaCampos();
            }
            else
            {
                DesabilitaCampos();
            }
        }

    }
}