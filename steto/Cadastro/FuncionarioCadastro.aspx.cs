using System;
using System.Web;
using System.Web.UI;
using System.IO;
using Steto.ValueObjectLayer;
using Steto.FacadeLayer;

namespace Steto.Cadastro
{
    public partial class FuncionarioCadastro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Usuario usuario = (Usuario)Session["UsuarioLogado"];
                Empresa empresa = EmpresaFacade.RecuperaEmpresa(new Empresa());
                lblEmpresaCodigo.Text = string.Empty;
                lblEmpresa.Text = empresa.Nome;
                lblEmpresaCodigo.Text = empresa.Id.ToString();
            }
        }

        protected void btnUploadImagemPaciente_Click(object sender, EventArgs e)
        {
            string caminho = "";

            string diretorio = MapPath(@"imagens\PacienteFicha\");

            HttpPostedFile imagemEnviada;

            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }

            HttpFileCollection imagensEnviadas = Request.Files;

            for (int i = 0; i < imagensEnviadas.Count; i++)
            {
                imagemEnviada = imagensEnviadas[i];

                if (imagemEnviada.ContentLength <= 0) return;

                string auxExt = Path.GetFileName(imagemEnviada.FileName).Substring(Path.GetFileName(imagemEnviada.FileName).Length - 4, 4);

                caminho = diretorio + Path.GetFileName(imagemEnviada.FileName);
                imagemEnviada.SaveAs(caminho);

                MemoryStream ms = new MemoryStream(ImagemRedonda(caminho));
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                imgPaciente.ImageUrl = @"~/Paciente/imagens/PacienteFicha/" + Path.GetFileName(imagemEnviada.FileName);
            }
        }

        public byte[] ImagemRedonda(string Path)
        {
            System.Drawing.Image imagem = System.Drawing.Bitmap.FromFile(Path);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imagem.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            
            return ms.ToArray();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = null;
            if (!lblCodigoFuncionario.Text.Equals(""))
            {
                funcionario = new Funcionario(Convert.ToInt32(lblCodigoFuncionario.Text));
            }
            else
            {
                funcionario = new Funcionario();
            }
            funcionario.Nome = txtNomeFuncionario.Text;
            funcionario.CPF = txtDocumentosCPF.Text;
            funcionario.Email = txtEmailResidencial.Text;

            lblCodigoFuncionario.Text = FuncionarioFacade.InsereFuncionario(funcionario).ToString();

        }

        protected void btnAddTelefoneResidencial_Click(object sender, EventArgs e)
        {
            lstTelefoneResidencial.Items.Add(txtTelefoneResidencial.Text);
            txtTelefoneResidencial.Text = string.Empty;
            txtTelefoneResidencial.Focus();
        }

        protected void btnAddEmailResidencial_Click(object sender, EventArgs e)
        {
            lstEmailResidencial.Items.Add(txtEmailResidencial.Text);
            txtEmailResidencial.Text = string.Empty;
            txtEmailResidencial.Focus();
        }
    }
}