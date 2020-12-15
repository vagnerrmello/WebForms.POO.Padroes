using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Drawing;

namespace Steto.Paciente
{
    public partial class FichaPaciente : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
                //imgPaciente.ImageUrl = @"~/Paciente/imagens/PacienteFicha/048.JPG";
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

        protected void btnAddTelefoneResidencial_Click(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

        }


    }
}