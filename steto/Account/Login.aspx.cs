using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Steto.FacadeLayer;
using Steto.ValueObjectLayer;

namespace steto.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //if (UsuarioFacade.Logar(LoginUser.UserName, LoginUser.Password))
            //{
            //    TB_Usuario usuario = UsuarioFacade.Logando(LoginUser.UserName, LoginUser.Password);
            //    //List<PerfilModuloFuncionalidadePermissao> perfilUsuario = PerfilFacade.RecuperarPerfilUsuario(usuario.Id);
                
            //    //Session["Perfil"] = perfilUsuario;

            //    //Response.Redirect(@"Principal.aspx");
            //    RegisterHyperLink.NavigateUrl = "Principal.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //}
            //else
            //{
            //    lblMsg.Text = "Login ou Senha inválida!";
            //}
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            //if (UsuarioFacade.Logar(LoginUser.UserName, LoginUser.Password))
            //{
            //    //RegisterHyperLink.NavigateUrl = "Principal.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //    //Response.Redirect("Principal.aspx");
            //}
            //else
            //{
            //    lblMsg.Text = "Login ou Senha inválida!";
            //}
        }
    }
}
