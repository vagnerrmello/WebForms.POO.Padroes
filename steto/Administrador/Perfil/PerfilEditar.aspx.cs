using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Steto.ValueObjectLayer;
using Steto.FacadeLayer;
using Steto.Util.Mensagens;

namespace Steto.Administrador.Perfil
{
    public partial class PerfilEditar1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PermissaoPagina();
            if (!Page.IsPostBack)
            {
                int idPerfil = (int)Session["IdPerfil"];
                CarregaPerfil(idPerfil);
            }
        }

        protected void CarregaPerfil(int idPerfil)
        {
            try
            {
                ValueObjectLayer.Perfil perfil = PerfilFacade.RecuperarPerfil(idPerfil);

                txtPerfil.Text = perfil.Descricao;
                if (perfil.Ativo)
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
            txtPerfil.Enabled = false;
            btnSalvar.Visible = false;
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
                        if (funcionalidade._Funcionalidade.Descricao.Equals("Perfil"))
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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ValueObjectLayer.Perfil perfil = new ValueObjectLayer.Perfil();

                if (!string.IsNullOrEmpty(txtPerfil.Text))
                {
                    //if (!PerfilFacade.RecuperarPerfil(txtPerfil.Text))
                    //{
                        perfil.Id = (int)Session["IdPerfil"];
                        perfil.Descricao = txtPerfil.Text;

                        if (PerfilFacade.AlterarPerfil(perfil))
                        {
                            txtPerfil.Text = string.Empty;
                            Session.Remove("IdPerfil");
                            Session["Mensagem"] = 2;
                            Response.Redirect("~/Administrador/Perfil/Perfil.aspx");
                            lblMsg.Text = MensagensValor.GetStringValue(Mensagem.ALTERADO.ToString());
                        }
                        else
                        {
                            lblMsg.Text = MensagensValor.GetStringValue(Mensagem.ALTERADO_NAO_REALIZADO.ToString());
                        }
                    //}
                    //else
                    //{
                    //    lblMsg.Text = BusinessLayer.Mensagens.MensagensValor.GetStringValue(BusinessLayer.Mensagens.Mensagem.PERFIL_EXISTENTE.ToString());
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrador/Perfil/Perfil.aspx");
        }
    }
}