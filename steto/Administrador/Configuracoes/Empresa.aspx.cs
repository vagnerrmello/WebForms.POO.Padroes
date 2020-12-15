using Steto.FacadeLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Steto.Administrador.Configuracoes
{
    public partial class Empresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCodigoEmpresa.Text = "0";
            Inicializa();
        }

        protected void Inicializa()
        {
            ValueObjectLayer.Usuario usuario = (ValueObjectLayer.Usuario)Session["UsuarioLogado"];
            ValueObjectLayer.Empresa empresa = EmpresaFacade.RecuperaEmpresa(new ValueObjectLayer.Empresa());

            if (empresa != null)
            {
                lblCodigoEmpresa.Text = empresa.Id.ToString();
                txtNome.Text = empresa.Nome;
                txtCpf_Cnpj.Text = empresa.Cpf_Cnpj;
                txtLogradouro.Text = empresa.Logradouro;
                txtBairro.Text = empresa.Bairro;
                txtCep.Text = empresa.Cep;
                txtCidade.Text = empresa.Cidade;
                txtEstado.Text = empresa.Estado;
                txtTelefone.Text = empresa.Fone;
                txtEmail.Text = empresa.Email;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ValueObjectLayer.Empresa empresa = new ValueObjectLayer.Empresa();

            if (Convert.ToInt32(lblCodigoEmpresa.Text) > 0)
                empresa.Id = Convert.ToInt32(lblCodigoEmpresa.Text);

            empresa.Nome = txtNome.Text;
            empresa.Cpf_Cnpj = txtCpf_Cnpj.Text;
            empresa.Logradouro = txtLogradouro.Text;
            empresa.Bairro = txtBairro.Text;
            empresa.Cep = txtCep.Text;
            empresa.Cidade = txtCidade.Text;
            empresa.Estado = txtEstado.Text;
            empresa.Fone = txtTelefone.Text;
            empresa.Email = txtEmail.Text;

            string alerta = string.Empty;

            if (Convert.ToInt32(lblCodigoEmpresa.Text) > 0)
            {
                if(EmpresaFacade.AtualizarEmpresa(empresa))
                {
                    alerta = "Empresa atualizada com Sucesso! ";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                }
                else
                {
                    alerta = "Erro ao atualizar Empresa! ";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                }
            }
            else
            {
                if (empresa != null)
                {
                    if (EmpresaFacade.CriarEmpresa(empresa) > 0)
                    {
                        alerta = "Empresa Cadastrada com Sucesso! ";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                    }
                    else
                    {
                        alerta = "Erro ao cadastrar Empresa! ";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                    }
                }
                else
                {
                    alerta = "Verifique os campos! ";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                }
            }
        }
    }
}