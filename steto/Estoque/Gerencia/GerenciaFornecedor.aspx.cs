using Steto.FacadeLayer;
using Steto.FacadeLayer.Estoque;
using Steto.ValueObjectLayer;
using System;
using System.Collections.Generic;

namespace Steto.Estoque.Gerencia
{
    public partial class GerenciaFornecedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PermissaoPagina();
            if(!Page.IsPostBack)
                Inicializa();
        }

        protected bool PermissaoPagina()
        {
            try
            {
                if (Session["PerfilFuncionalidades"] != null)
                {
                    List<CarregarPerfil> perfisUsuario = (List<CarregarPerfil>)Session["PerfilFuncionalidades"];
                    bool flagPermissaoPagina = false;
                    bool flagUsuEditar = false;
                    foreach (CarregarPerfil funcionalidade in perfisUsuario)
                    {
                        //if (funcionalidade.NomeFuncionalidade.Equals("Usuário"))
                        if (funcionalidade._Funcionalidade.Descricao.Equals("Usuário"))
                        {
                            flagPermissaoPagina = true;
                            //if (funcionalidade.NomePermissao.Equals("Cadastrar"))
                            if (funcionalidade._Permissao.Nome.Equals("Cadastrar"))
                            {
                                flagUsuEditar = true;
                            }

                            //if (funcionalidade.NomePermissao.Equals("Visualizar") && !flagUsuEditar)
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

        private void DesabilitaCampos()
        {
        }

        private void LimpaCampos()
        {
            txtNome.Text = string.Empty;
            txtCpf_Cnpj.Text = string.Empty;
            txtInscricaoEstadual.Text = string.Empty;
            ddlPessoaFisicaJurida.SelectedValue = "0";
            txtEmail.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtLogradouro.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCep.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtEstado.Text = string.Empty;
        }

        private void LimpaCamposInsere()
        {
            txtNomeInsere.Text = string.Empty;
            ttxtCpf_CnpjInsere.Text = string.Empty;
            txtInscricaoEstadualInsere.Text = string.Empty;
            ddlPessoaFisicaJuridaInsere.SelectedValue = "0";
            txtEmailInsere.Text = string.Empty;
            txtTelefoneInsere.Text = string.Empty;
            txtLogradouroInsere.Text = string.Empty;
            txtBairroInsere.Text = string.Empty;
            txtCepInsere.Text = string.Empty;
            txtCidadeInsere.Text = string.Empty;
            txtEstadoInsere.Text = string.Empty;
        }

        protected void Inicializa()
        {
            MultiViewNota.ActiveViewIndex = 0;
        }

        protected bool ValidaFornecedor()
        {
            bool[] valido = new bool[11];
            bool retorno = true;
            valido[0] = (txtNome.Text.Equals("")) ? false : true;
            valido[1] = (txtCpf_Cnpj.Text.Equals("")) ? false : true;
            valido[2] = (txtInscricaoEstadual.Text.Equals("")) ? false : true;
            valido[3] = (ddlPessoaFisicaJurida.SelectedValue.Equals("")) ? false : true;
            valido[4] = (txtEmail.Text.Equals("")) ? false : true;
            valido[5] = (txtTelefone.Text.Equals("")) ? false : true;
            valido[6] = (txtLogradouro.Text.Equals("")) ? false : true;
            valido[7] = (txtBairro.Text.Equals("")) ? false : true;
            valido[8] = (txtCep.Text.Equals("")) ? false : true;
            valido[9] = (txtCidade.Text.Equals("")) ? false : true;
            valido[10] = (txtEstado.Text.Equals("")) ? false : true;

            for (int i = 0; i < valido.Length; i++)
            {
                if(valido[i] == false) retorno = false;
            }

            return retorno;
        }

        protected void btnSalvarFornecedor_Click(object sender, EventArgs e)
        {
            string alerta1 = string.Empty;
            if (ValidaFornecedor())
            {
                Usuario usuario = (Usuario)Session["UsuarioLogado"];
                Fornecedor fornecedor = new Fornecedor(Convert.ToInt32(lblCodigoFornecedor.Text));
                ValueObjectLayer.Empresa empresa = new ValueObjectLayer.Empresa();
                empresa.Nome = txtNome.Text;
                empresa.Cpf_Cnpj = txtCpf_Cnpj.Text;
                empresa.PessoaFisicaJuridica = ddlPessoaFisicaJurida.SelectedValue;
                empresa.Email = txtEmail.Text;
                empresa.Fone = txtTelefone.Text;

                Logradouro logradouro = new Logradouro();
                logradouro.Descricao = txtLogradouro.Text;
                logradouro.Descricao_Bairro = txtBairro.Text;
                logradouro.Cep = txtCep.Text;
                logradouro.Cidade = txtCidade.Text;
                logradouro.Uf = txtEstado.Text;

                fornecedor.Logradouro = logradouro;
                
                if (FornecedorFacade.AlterarFornecedor(fornecedor))
                {
                    alerta1 = "Registro alterado com sucesso! ";
                }
                else
                {
                    alerta1 = "Falha ao tentar alterar o registro! ";
                }
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
            }
            else
            {
                alerta1 = "Todos Os Campos São De Preenchimento Obrigatório! ";
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
            }
        }

        protected void GridFornecedores_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int idFornecedor = Convert.ToInt32(GridFornecedores.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.Trim());

            if (e.CommandName.Equals("Editar"))
            {
                Usuario usuario = (Usuario)Session["UsuarioLogado"];
                Fornecedor fornecedor = new Fornecedor(idFornecedor);
                
                Fornecedor rtnFornecedor = FornecedorFacade.RecuperarFornecedor(fornecedor);

                lblCodigoFornecedor.Text = rtnFornecedor.Id.ToString();
  
                txtLogradouro.Text = rtnFornecedor.Logradouro.Descricao;
                txtBairro.Text = rtnFornecedor.Logradouro.Descricao_Bairro;
                txtCep.Text = rtnFornecedor.Logradouro.Cep;
                txtCidade.Text = rtnFornecedor.Logradouro.Cidade;
                txtEstado.Text = rtnFornecedor.Logradouro.Uf;

                MultiViewNota.ActiveViewIndex = 1;
            }

            if (e.CommandName.Equals("Excluir"))
            {

                lblCodigoFornecedorExclusao.Text = idFornecedor.ToString();
                lblNomeForcedorExluir.Text = GridFornecedores.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.Trim();
                lblCpf_CnpjExcluir.Text = GridFornecedores.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text.Trim();



                MultiViewNota.ActiveViewIndex = 3;
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!txtFornecedorPesquisa.Text.Equals(""))
            {
                Usuario usuario = (Usuario)Session["UsuarioLogado"];
                Fornecedor fornecedor = new Fornecedor();
                ValueObjectLayer.Empresa empresa = new ValueObjectLayer.Empresa();
                empresa.Nome = txtFornecedorPesquisa.Text;

                IList<Fornecedor> fornecedores = FornecedorFacade.RecuperarFornecedores(fornecedor);

                if (fornecedores.Count > 0)
                {
                    GridFornecedores.DataSource = fornecedores;
                    GridFornecedores.DataBind();
                }
                else
                {
                    string alerta1 = "Nenhum Fornecedor encontrado para este critério de pesquisa! ";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                }
            }
            else
            {
                string alerta1 = "Digite o nome do Fornecedor para pesquisar! ";
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
            }
        }

        protected void InserirFornecedor_Click(object sender, EventArgs e)
        {
            string alerta1 = string.Empty;

            Usuario usuario = (Usuario)Session["UsuarioLogado"];
            Fornecedor fornecedor = new Fornecedor();
            ValueObjectLayer.Empresa empresa = new ValueObjectLayer.Empresa();
            empresa.Nome = txtNomeInsere.Text;
            empresa.Cpf_Cnpj = ttxtCpf_CnpjInsere.Text;
            empresa.PessoaFisicaJuridica = ddlPessoaFisicaJuridaInsere.SelectedValue;
            empresa.Email = txtEmailInsere.Text;
            empresa.Fone = txtTelefoneInsere.Text;

            Logradouro logradouro = new Logradouro();
            logradouro.Descricao = txtLogradouroInsere.Text;
            logradouro.Descricao_Bairro = txtBairroInsere.Text;
            logradouro.Cep = txtCepInsere.Text;
            logradouro.Cidade = txtCidadeInsere.Text;
            logradouro.Uf = txtEstadoInsere.Text;

            fornecedor.Logradouro = logradouro;

            if (FornecedorFacade.RecuperarFornecedor(fornecedor) == null)
            {
                if (FornecedorFacade.CriarFornecedor(fornecedor) > 0)
                {
                    alerta1 = "Fornecedor criado com sucesso! ";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                    InserirFornecedor.Enabled = false;
                }
                else
                {
                    alerta1 = "Falha ao tentar criar um Fornecedor! ";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                }
            }
            else
            {
                alerta1 = "Já existe um Fornecedor com este Cpf/Cnpj! ";
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
            }
        }

        protected void btnAdd_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            LimpaCamposInsere();
            MultiViewNota.ActiveViewIndex = 2;
        }

        protected void btnLimpaPesquisa_Click(object sender, EventArgs e)
        {
            txtFornecedorPesquisa.Text = string.Empty;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            MultiViewNota.ActiveViewIndex = 0;
        }

        protected void btnVoltarAtualizar_Click(object sender, EventArgs e)
        {
            MultiViewNota.ActiveViewIndex = 0;
        }

        protected void btnConfirmarExclusaoFornecedor_Click(object sender, EventArgs e)
        {

            Fornecedor fornecedor = new Fornecedor(Convert.ToInt32(lblCodigoFornecedorExclusao.Text));

            string alerta1 = string.Empty;
            if (FornecedorFacade.ExcluiFornecedor(fornecedor))
            {
                alerta1 = "Fornecedor Excluído com Sucesso! ";
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
                MultiViewNota.ActiveViewIndex = 0;
            }
            else
            {
                alerta1 = "Falha ao tentar Excluir o Fornecedor " + lblNomeForcedorExluir.Text;
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta1 + "')</script>");
            }
        }

        protected void btnVoltarPesquisaExclusao_Click(object sender, EventArgs e)
        {
            MultiViewNota.ActiveViewIndex = 0;
        }
    }
}