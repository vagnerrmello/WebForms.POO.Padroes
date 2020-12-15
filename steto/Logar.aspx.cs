using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Steto.FacadeLayer;
using Steto.ValueObjectLayer;
using Steto.Util.Mensagens;

namespace Steto
{
    public partial class Logar : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            txtLogin.Focus();
            if (!Page.IsPostBack)
            {
                inicializar();
            }
        }

        protected void inicializar()
        {
            Session.Remove("tentativa");
            if (Session["tentativa"] == null)
            {
                Tentativa tentativa = new Tentativa();
                tentativa.NTentativa = 0;
                Session["tentativa"] = tentativa;
            }
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            lblInicio.Visible = false;

            Tentativa tentativa = (Tentativa)Session["tentativa"];
            ValueObjectLayer.Usuario usuario = null;

            if (tentativa.NTentativa == 0)
                tentativa.Login = txtLogin.Text;

            if (tentativa.Login != null)
            {
                if (!tentativa.Login.Equals(txtLogin.Text))
                {
                    inicializar();
                    tentativa = (Tentativa)Session["tentativa"];
                    tentativa.Login = txtLogin.Text;
                }
            }

            if (!UsuarioFacade.RecuperarUsuarioBloqueado(txtLogin.Text, txtSenha.Text))
            {
                usuario = UsuarioFacade.Logar(txtLogin.Text, txtSenha.Text);

                if (usuario != null)
                {
                    IList<ValueObjectLayer.CarregarPerfil> perfisUsuario = PerfilFacade.RecuperarPerfilUsuario(usuario.Id, ValueObjectLayer.TipoBuscaPerfil.RecuperaTodasPermissoesPerfil);
                    IList<ValueObjectLayer.CarregarPerfil> perfisPermissao = PerfilFacade.RecuperarPerfilUsuario(usuario.Id, ValueObjectLayer.TipoBuscaPerfil.RecuperaPermissoes);
                    ValueObjectLayer.Perfil_Usuario perfilUsuario = PerfilFacade.RecuperarPerfilPorId(usuario.Id);
                    if (perfilUsuario != null)
                    {
                        IList<ValueObjectLayer.Modulo> modulos = ModuloFacade.RecuperaModulosdoPerfil(perfilUsuario._Perfil.Id);

                        Session["UsuarioLogado"] = usuario;
                        Session["Modulos"] = modulos;
                        Session["PerfilFuncionalidades"] = perfisUsuario;
                        Session["PerfilPermissao"] = perfisPermissao;
                        //RegisterHyperLink.NavigateUrl = "Principal.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
                        Session.Remove("tentativa");
                        Response.Redirect(@"~/Principal.aspx");
                    }
                    else
                    {
                        lblMsg.Text = MensagensValor.GetStringValue(Mensagem.USUARIO_SEM_PERFIL.ToString());
                    }
                }
                else
                {
                    lblMsg.Text = MensagensValor.GetStringValue(Mensagem.LOGIN_INVALIDO.ToString());
                    tentativa.NTentativa++;
                    Session["tentativa"] = tentativa;

                    if (tentativa.NTentativa > 2)
                    {
                        usuario = UsuarioFacade.RecuperarPorLogin(txtLogin.Text);

                        if (usuario != null)
                        {
                            UsuarioFacade.BloquearUsuario(usuario);
                            lblMsg.Text = MensagensValor.GetStringValue(Mensagem.TENTATIVA_LOGIN_EXCEDIDA.ToString());
                            inicializar();
                        }
                        else
                        {
                            inicializar();
                        }
                    }
                }
            }
            else
            {
                lblMsg.Text = MensagensValor.GetStringValue(Mensagem.BLOQUEADO.ToString());
            }
        }
    }
}