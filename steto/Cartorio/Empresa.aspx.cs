using Steto.FacadeLayer;
using Steto.ValueObjectLayer;
using System;

namespace Steto.Cartorio
{
    public partial class Empresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Inicializa();
        }

        protected void Inicializa()
        {
            Usuario usuario = (Usuario)Session["UsuarioLogado"];
            ValueObjectLayer.Empresa empresa = EmpresaFacade.RecuperaEmpresa(new ValueObjectLayer.Empresa());

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
}