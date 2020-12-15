using System;
using System.Web;
using System.Web.UI;
using System.IO;
using Steto.ValueObjectLayer;
using Steto.FacadeLayer;

namespace Steto.Cadastro
{
    public partial class ClienteCadastro : System.Web.UI.Page
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

        protected void btnAddTelefoneComercial_Click(object sender, EventArgs e)
        {
            lstTelefoneComercial.Items.Add(txtTelefoneComercial.Text);
            txtTelefoneComercial.Text = string.Empty;
            txtTelefoneComercial.Focus();
        }

        protected void btnAddEmailComercial_Click(object sender, EventArgs e)
        {
            lstEmailComercial.Items.Add(txtEmailComercial.Text);
            txtEmailComercial.Text = string.Empty;
            txtEmailComercial.Focus();
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

        protected void resumeupload(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblCodigoCliente.Text) > 0)
            {
                salvaArquivo();
            }
            else
            {
                string alerta = "Salve o Cliente para poder importar documentos!";
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
            }
        }


        protected void salvaArquivo()
        {
            string caminho = string.Empty;

            string diretorio = MapPath(@"~\Imagens\Cliente\Documentos\");

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

                //string extension = Path.GetExtension(FileInput.PostedFile.FileName);
                string teste = string.Empty;
                switch (auxExt.ToLower())
                {
                    case ".doc":
                        teste = "ok";
                        break;

                    case ".jpg":
                        teste = "ok";
                        break;
                }

                //switch (auxExt.ToLower())
                //{
                //    case "doc":
                //        arquivoEnviar.ContentType = "application/vnd.ms-word";
                //        break;

                //    case "docx":
                //        arquivoEnviar.ContentType = "application/vnd.ms-word";
                //        break;

                //    case "xls":
                //        arquivoEnviar.ContentType = "application/vnd.ms-excel";
                //        break;

                //    case "xlsx":
                //        arquivoEnviar.ContentType = "application/vnd.ms-excel";
                //        break;

                //    case "jpg":
                //        arquivoEnviar.ContentType = "image/jpeg";
                //        break;

                //    case "jpeg":
                //        arquivoEnviar.ContentType = "image/jpeg";
                //        break;

                //    case "pdf":
                //        arquivoEnviar.ContentType = "application/pdf";
                //        break;
                //}
                string strDocumentoNome = Path.GetFileName("Cliente.Doc" + lblCodigoCliente.Text + "." + lblEmpresaCodigo.Text + ".jpg");
                caminho = diretorio + strDocumentoNome;
                imagemEnviada.SaveAs(caminho);
            }
        }

    }
}