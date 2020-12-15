using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Steto.FacadeLayer;
using Steto.ValueObjectLayer;
using Steto.Util.Mensagens;

namespace Steto.Administrador.Perfil
{
    public partial class PerfilNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PermissaoPagina();
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
                        if (funcionalidade._Funcionalidade.Descricao.Equals("Perfil"))
                        {
                            flagPermissaoPagina = true;
                            if (funcionalidade._Permissao.Nome.Equals("Cadastrar"))
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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ValueObjectLayer.Perfil perfil = new ValueObjectLayer.Perfil();

                if (!string.IsNullOrEmpty(txtPerfil.Text))
                {
                    if (!PerfilFacade.RecuperarPerfil(txtPerfil.Text))
                    {
                        perfil.Descricao = txtPerfil.Text;
                        if (PerfilFacade.CriarPerfil(perfil))
                        {
                            txtPerfil.Text = string.Empty;
                            Session["Mensagem"] = 1;
                            Response.Redirect(@"~/Administrador/Perfil/Perfil.aspx");
                            lblMsg.Text = MensagensValor.GetStringValue(Mensagem.CADASTRO.ToString());
                        }
                        else
                        {
                            lblMsg.Text = MensagensValor.GetStringValue(Mensagem.CADASTRO_NAO_REALIZADO.ToString());
                        }
                    }
                    else
                    {
                        lblMsg.Text = MensagensValor.GetStringValue(Mensagem.PERFIL_EXISTENTE.ToString());
                    }
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Administrador/Perfil/Perfil.aspx");
        }
    }
}