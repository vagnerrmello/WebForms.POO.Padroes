using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Steto.FacadeLayer;
using Steto.ValueObjectLayer;
using Steto.Util.Mensagens;

namespace Steto.Paciente
{
    public partial class PacientePesquisa : System.Web.UI.Page
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
                    List<CarregarPerfil> perfisUsuario = (List<CarregarPerfil>)Session["PerfilFuncionalidades"];

                    bool flagPermissaoPagina = false;
                    bool flagCadastrar = false;
                    bool flagEditar = false;
                    bool flagInativar = false;
                    GridView.Columns[3].Visible = false;
                    GridView.Columns[4].Visible = false;
                    GridView.Columns[5].Visible = false;

                    foreach (CarregarPerfil funcionalidade in perfisUsuario)
                    {
                        if (funcionalidade._Funcionalidade.Descricao.Equals("Ficha de Paciente"))
                        {
                            flagPermissaoPagina = true;

                            //if (funcionalidade._Permissao.Nome.Equals("Cadastrar"))
                            //{
                            //    //Botão Editar
                            //    GridView.Columns[3].Visible = true;
                            //    ////Botão visualizar
                            //    //GridView.Columns[4].Visible = false;

                            //    flagCadastrar = true;
                            //}

                            if (funcionalidade._Permissao.Nome.Equals("Editar") && !flagCadastrar)
                            {
                                //Botão Editar
                               GridView.Columns[3].Visible = true;

                                //Botão visualizar
                                //if (!flagCadastrar)
                                    //GridView.Columns[4].Visible = false;

                                flagEditar = true;
                            }

                            if (funcionalidade._Permissao.Nome.Equals("Visualizar") && !flagEditar)
                            {
                                //Botão Editar
                                //GridView.Columns[3].Visible = false;

                                //Botão visualizar
                                GridView.Columns[4].Visible = true;
                            }

                            if (funcionalidade._Permissao.Nome.Equals("Inativar"))
                            {
                                GridView.Columns[5].Visible = true;
                                flagInativar = true;
                            }
                            else
                            {
                                if (!flagInativar)
                                    GridView.Columns[5].Visible = false;
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
                    //int ativo = Convert.ToInt16(ddlAtivoInativo.SelectedValue.ToString());
                    IList<ValueObjectLayer.Paciente> pacientes = new List<ValueObjectLayer.Paciente>();
                    ValueObjectLayer.Paciente paciente = new ValueObjectLayer.Paciente();
                    //if (!string.IsNullOrEmpty(txtPesquisa.Text))
                    //{
                    //    if (ativo == 2)
                    //    {
                    //        usuarios = UsuarioFacade.RecuperarUsuarios(txtPesquisa.Text);
                    //    }
                    //    else if (ativo == 1)
                    //    {
                    //        usuarios = UsuarioFacade.RecuperarUsuarios(txtPesquisa.Text, true);
                    //    }
                    //    else if (ativo == 0)
                    //    {
                    //        usuarios = UsuarioFacade.RecuperarUsuarios(txtPesquisa.Text, false);
                    //    }
                    //}
                    //else
                    //{
                    //    if (ativo == 2)
                    //    {
                    //        usuarios = UsuarioFacade.RecuperarUsuarios();
                    //    }
                    //    else if (ativo == 1)
                    //    {
                    //        usuarios = UsuarioFacade.RecuperarUsuarios(true);
                    //    }
                    //    else if (ativo == 0)
                    //    {
                    //        usuarios = UsuarioFacade.RecuperarUsuarios(false);
                    //    }
                    //}
                    if(!txtPaciente.Text.Equals(""))
                        paciente.Nome = txtPaciente.Text;

                    if (!txtCpf.Text.Equals("") && !txtCpf.Text.Equals("___.___.___-__"))
                        paciente.CPF = txtCpf.Text;

                    pacientes = PacienteFacade.PesquisarPaciente(paciente);
                    GridView.DataSource = pacientes;
                    GridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idPaciente = Convert.ToInt32(GridView.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim());
            if (e.CommandName.Equals("Editar"))
            {
                Session["IdUsuario"] = idPaciente;
                Response.Redirect(@"~/Administrador/Paciente/PacienteEditar.aspx");
            }
            else if (e.CommandName.Equals("Visualizar"))
            {
                Session["IdUsuario"] = idPaciente;
                Response.Redirect(@"~/Administrador/Paciente/PacienteEditar.aspx");
            }
            else if (e.CommandName.Equals("Inativar"))
            {
                if (UsuarioFacade.InativarUsuario(idPaciente))
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
            GridView.PageIndex = e.NewPageIndex;
            CarregaGridView();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregaGridView();
        }
    }
}