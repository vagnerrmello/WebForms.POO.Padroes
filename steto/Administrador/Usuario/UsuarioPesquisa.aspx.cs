using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Steto.ValueObjectLayer;
using Steto.FacadeLayer;
using System.Text.RegularExpressions;
using Steto.Util.Mensagens;

namespace Steto.Administrador
{
    public partial class PainelDeControle : System.Web.UI.Page
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

        #region Usuário
        protected IList<ValueObjectLayer.Usuario> RecuperaUsuarios(string nomeUsuario)
        {
            try
            {
                IList<ValueObjectLayer.Usuario> usuarios = UsuarioFacade.RecuperarUsuarios(txtPesquisa.Text);

                if (usuarios != null)
                {
                    return usuarios;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregaGridViewPesquisa();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CarregaGridViewPesquisa()
        {
            try
            {
                int ativo = Convert.ToInt16(ddlAtivoInativo.SelectedValue.ToString());
                IList<ValueObjectLayer.Usuario> usuarios = null;
                if (!string.IsNullOrEmpty(txtPesquisa.Text))
                {
                    if (ativo == 2)
                    {
                        usuarios = UsuarioFacade.RecuperarUsuarios(txtPesquisa.Text);
                    }
                    else if (ativo == 1)
                    {
                        usuarios = UsuarioFacade.RecuperarUsuarios(txtPesquisa.Text, true);
                    }
                    else if (ativo == 0)
                    {
                        usuarios = UsuarioFacade.RecuperarUsuarios(txtPesquisa.Text, false);
                    }
                }
                else
                {
                    if (ativo == 2)
                    {
                        usuarios = UsuarioFacade.RecuperarUsuarios();
                    }
                    else if (ativo == 1)
                    {
                        usuarios = UsuarioFacade.RecuperarUsuarios(true);
                    }
                    else if (ativo == 0)
                    {
                        usuarios = UsuarioFacade.RecuperarUsuarios(false);
                    }
                }
                GridView.DataSource = usuarios;
                GridView.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            CarregaGridViewPesquisa();
            GridView.PageIndex = e.NewPageIndex;
            //CarregaGridView();
        }

        protected void CarregaGridView()
        {
            try
            {
                if (PermissaoPagina())
                {
                    int ativo = Convert.ToInt16(ddlAtivoInativo.SelectedValue.ToString());
                    IList<ValueObjectLayer.Usuario> usuarios = null;
                    if (!string.IsNullOrEmpty(txtPesquisa.Text))
                    {
                        if (ativo == 2)
                        {
                            usuarios = UsuarioFacade.RecuperarUsuarios(txtPesquisa.Text);
                        }
                        else if (ativo == 1)
                        {
                            usuarios = UsuarioFacade.RecuperarUsuarios(txtPesquisa.Text, true);
                        }
                        else if (ativo == 0)
                        {
                            usuarios = UsuarioFacade.RecuperarUsuarios(txtPesquisa.Text, false);
                        }
                    }
                    else
                    {
                        if (ativo == 2)
                        {
                            usuarios = UsuarioFacade.RecuperarUsuarios();
                        }
                        else if (ativo == 1)
                        {
                            usuarios = UsuarioFacade.RecuperarUsuarios(true);
                        }
                        else if (ativo == 0)
                        {
                            usuarios = UsuarioFacade.RecuperarUsuarios(false);
                        }
                    }

                    GridView.DataSource = usuarios;
                    GridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                    bool flagUsuCadastrar = false;
                    bool flagUsuEditar = false;
                    bool flagUsuInativar = false;
                    foreach (ValueObjectLayer.CarregarPerfil funcionalidade in perfisUsuario)
                    {
                        //if (funcionalidade.NomeFuncionalidade.Equals("Usuário"))
                        if (funcionalidade._Funcionalidade.Descricao.Equals("Usuário"))
                        {
                            flagPermissaoPagina = true;

                            //if (funcionalidade.NomePermissao.Equals("Cadastrar"))
                            if (funcionalidade._Permissao.Nome.Equals("Cadastrar"))
                            {
                                //Botão visualizar
                                GridView.Columns[6].Visible = false;
                                //Botão Editar
                                GridView.Columns[5].Visible = true;
                                flagUsuCadastrar = true;
                            }

                            //if (funcionalidade.NomePermissao.Equals("Editar"))
                            if (funcionalidade._Permissao.Nome.Equals("Editar"))
                            {
                                //Botão visualizar
                                GridView.Columns[6].Visible = false;
                                //Botão Editar
                                if (!flagUsuCadastrar)
                                    GridView.Columns[5].Visible = true;
                                flagUsuEditar = true;
                            }

                            //if (funcionalidade.NomePermissao.Equals("Visualizar") && !flagUsuEditar)
                            if (funcionalidade._Permissao.Nome.Equals("Visualizar") && !flagUsuEditar)
                            {
                                //Botão visualizar
                                GridView.Columns[6].Visible = true;
                                //Botão Editar
                                GridView.Columns[5].Visible = false;
                            }


                            //if (funcionalidade.NomePermissao.Equals("Inativar"))
                            if (funcionalidade._Permissao.Nome.Equals("Inativar"))
                            {
                                GridView.Columns[7].Visible = true;
                                flagUsuInativar = true;
                            }
                            else
                            {
                                if (!flagUsuInativar)
                                    GridView.Columns[7].Visible = false;
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

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idUsuario = Convert.ToInt32(GridView.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim());
            if (e.CommandName.Equals("Editar"))
            {
                Session["IdUsuario"] = idUsuario;
                Response.Redirect(@"~/Administrador/Usuario/UsuarioEditar.aspx");
            }
            else if (e.CommandName.Equals("Visualizar"))
            {
                Session["IdUsuario"] = idUsuario;
                Response.Redirect(@"~/Administrador/Usuario/UsuarioEditar.aspx");
            }
            else if (e.CommandName.Equals("Inativar"))
            {
                if (UsuarioFacade.InativarUsuario(idUsuario))
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
        #endregion

        protected void btnLimpaPesquisa_Click(object sender, EventArgs e)
        {
            txtPesquisa.Text = string.Empty;
            ddlAtivoInativo.SelectedValue = "1";
            CarregaGridView();
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gvr = e.Row;

            switch (gvr.RowType)
            {
                case DataControlRowType.DataRow:
                    {
                        if (gvr.Cells[4].Text.Equals("True"))
                        {
                            gvr.Cells[4].Text = "Ativo";
                        }
                        else
                        {
                            gvr.Cells[4].Text = "Inativo";
                            e.Row.Cells[e.Row.Cells.Count - 1].Enabled = false;
                            e.Row.ForeColor = System.Drawing.Color.Red;
                        }

                        break;
                    }
            }
        }
    }
}