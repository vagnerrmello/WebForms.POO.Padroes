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
    public partial class PerfilEditar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PermissaoPagina();
            if (!Page.IsPostBack)
            {
                CarregaGridView();
                if (Session["Mensagem"] != null)
                {
                    if ((int)Session["Mensagem"] == 1)
                        lblMsg.Text = MensagensValor.GetStringValue(Mensagem.CADASTRO.ToString());
                    if ((int)Session["Mensagem"] == 2)
                        lblMsg.Text = MensagensValor.GetStringValue(Mensagem.ALTERADO.ToString());
                    Session.Remove("Mensagem");
                }
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
                    bool flagUsuInativar = false;
                    foreach (ValueObjectLayer.CarregarPerfil funcionalidade in perfisUsuario)
                    {
                        //if (funcionalidade.NomeFuncionalidade.Equals("Perfil"))
                        if (funcionalidade._Funcionalidade.Descricao.Equals("Perfil"))
                        {
                            flagPermissaoPagina = true;

                            //if (funcionalidade.NomePermissao.Equals("Editar"))
                            if (funcionalidade._Permissao.Nome.Equals("Editar"))
                            {
                                //Botão visualizar
                                GridPerfil.Columns[4].Visible = false;
                                //Botão Editar
                                //if (!flagUsuCadastrar)
                                GridPerfil.Columns[3].Visible = true;
                                flagUsuEditar = true;
                            }

                            //if (funcionalidade.NomePermissao.Equals("Visualizar") && !flagUsuEditar)
                            if (funcionalidade._Permissao.Nome.Equals("Visualizar") && !flagUsuEditar)
                            {
                                //Botão visualizar
                                GridPerfil.Columns[4].Visible = true;
                                //Botão Editar
                                GridPerfil.Columns[3].Visible = false;
                            }


                            if (funcionalidade._Permissao.Nome.Equals("Inativar"))
                            {
                                GridPerfil.Columns[5].Visible = true;
                                flagUsuInativar = true;
                            }
                            else
                            {
                                if (!flagUsuInativar)
                                    GridPerfil.Columns[5].Visible = false;
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

        protected void CarregaGridView()
        {
            try
            {
                if (PermissaoPagina())
                {
                    int ativo = Convert.ToInt16(ddlAtivoInativo.SelectedValue.ToString());
                    IList<ValueObjectLayer.Perfil> perfis = null;
                    if (!string.IsNullOrEmpty(txtPesquisa.Text))
                    {
                        if (ativo == 2)
                        {
                            perfis = PerfilFacade.RecuperarPerfis(txtPesquisa.Text);
                        }
                        else if (ativo == 1)
                        {
                            perfis = PerfilFacade.RecuperarPerfis(txtPesquisa.Text, true);
                        }
                        else if (ativo == 0)
                        {
                            perfis = PerfilFacade.RecuperarPerfis(txtPesquisa.Text, false);
                        }
                    }
                    else
                    {
                        if (ativo == 2)
                        {
                            perfis = PerfilFacade.RecuperarPerfis();
                        }
                        else if (ativo == 1)
                        {
                            perfis = PerfilFacade.RecuperarPerfis(true);
                        }
                        else if (ativo == 0)
                        {
                            perfis = PerfilFacade.RecuperarPerfis(false);
                        }
                    }

                    GridPerfil.DataSource = perfis;
                    GridPerfil.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idPerfil = Convert.ToInt32(GridPerfil.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim());
            if (e.CommandName.Equals("Editar"))
            {
                Session["IdPerfil"] = idPerfil;
                Response.Redirect(@"~/Administrador/Perfil/PerfilEditar.aspx");
            }
            else if (e.CommandName.Equals("Visualizar"))
            {
                Session["IdPerfil"] = idPerfil;
                Response.Redirect(@"~/Administrador/Perfil/PerfilEditar.aspx");
            }
            else if (e.CommandName.Equals("Inativar"))
            {
                if (PerfilFacade.InativarPerfil(idPerfil))
                {
                    lblMsg.Text = MensagensValor.GetStringValue(Mensagem.INATIVADO.ToString());
                    CarregaGridView();
                }
                else
                {
                    lblMsg.Text = MensagensValor.GetStringValue(Mensagem.INATIVADO_NAO_REALIZADO.ToString());
                }
            }
        }

        protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridPerfil.PageIndex = e.NewPageIndex;
            CarregaGridView();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregaGridView();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnLimpaPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                txtPesquisa.Text = string.Empty;
                ddlAtivoInativo.SelectedValue = "1";
                CarregaGridView();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridPerfil_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gvr = e.Row;

            switch (gvr.RowType)
            {
                case DataControlRowType.DataRow:
                    {
                        if (gvr.Cells[2].Text.Equals("True"))
                        {
                            gvr.Cells[2].Text = "Ativo";
                        }
                        else
                        {
                            gvr.Cells[2].Text = "Inativo";
                            e.Row.Cells[e.Row.Cells.Count - 1].Enabled = false;
                        }

                        break;
                    }
            }
        }
    }
}