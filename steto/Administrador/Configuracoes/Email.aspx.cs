using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Steto.FacadeLayer;
using Steto.Util.Mensagens;

namespace Steto.Administrador.Configuracoes
{
    public partial class Email : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PermissaoPagina();
            if (!Page.IsPostBack)
            {
                string url = string.Empty;
                if (HttpContext.Current.Request.PathInfo.Length == 0)
                    url = "";
                else
                    url = HttpContext.Current.Request.PathInfo.Substring(1);

                string baseUrl = string.Format("{0}://{1}{2}/", HttpContext.Current.Request.Url.Scheme, 
                HttpContext.Current.Request.Url.Authority, 
                HttpContext.Current.Request.ApplicationPath);

                CarregaGrid();
                if (Session["Alteracao"] != null)
                    if ((bool)Session["Alteracao"])
                        lblMsg.Text = MensagensValor.GetStringValue(Mensagem.ALTERADO.ToString());
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
                    GridEmail.Columns[2].Visible = true;
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
                                GridEmail.Columns[2].Visible = true;
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

        protected void CarregaGrid()
        {
            try
            {
                IList<ValueObjectLayer.Email_Tipo> tiposEmail = EmailFacade.RecuperaTipoEmail(ValueObjectLayer.TipoEmail.Empresa);

                GridEmail.DataSource = tiposEmail;
                GridEmail.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridEmail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idEmail = Convert.ToInt32(GridEmail.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim());
            if (e.CommandName.Equals("Editar"))
            {
                Session["IdEmail"] = idEmail;
                //Response.Redirect(@"~/Administrador/Configuracoes/EmailEditar.aspx");
                Response.Redirect("~/Administrador/Configuracoes/EmailEditar.aspx?id="
                          + Cryptography.GerarCriptografia("Editar", "36?@#!$a"));
            }
        }
    }
}