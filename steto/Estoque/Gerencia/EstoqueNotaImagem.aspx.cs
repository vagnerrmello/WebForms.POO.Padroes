
using System;


namespace Steto.Notas
{
    public partial class EstoqueNotaImagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strCaminhoArquivo = Convert.ToString(Session["impressao"]);

            ImageNota.ImageUrl = strCaminhoArquivo;

            //string strReconhecimento = string.Empty;
            //if (impressao.Equals("V"))
            //{
            //    strReconhecimento = "RECONHECO por Verdadeiro a firma de";
            //    //lblCliente.Text = indices[0].Nome;
            //}

            //if (impressao.Equals("S"))
            //{
            //    strReconhecimento = "RECONHECO por  Semelhança a firma de";
            //    //lblCliente.Text = indices[0].Nome;
            //}

            //if (impressao.Equals("A"))
            //{
            //    strReconhecimento = "RECONHECO por  Autenticidade a firma de";
            //    //lblCliente.Text = indices[0].Nome;
            //}

            //lblReconheco.Text = strReconhecimento;
            //lblCliente.Text = indices[0].Nome;

            //lblLocalData.Text = empresa.Cidade + " " + DateTime.Now + " " + empresa.Escrevente1 + "- Escrevente";

            //lblInformacaoSelo.Text = "Selo: " + indices[0].Selo.Numero_Selo + ", consulte em";
            //lblInformacaoHttp.Text = "selo.tjal.jus.br";

            //StringBuilder relatorio = new StringBuilder();
            //StringBuilder sbTabela = new StringBuilder();

            
            //foreach (var item in selos)
            //{
            //    sbTabela.Append("<table style='border: 1px #444 solid'>");

            //    sbTabela.Append("<tr>");
            //        sbTabela.Append("<td rowspan='1'> <img src='/imagens/Logo_SMC.png' Height='32px' Width='34px' /> </td>");
            //        sbTabela.Append("<td> <center> <b>" + empresa.Nome + "</b> </center> </td>");
            //    sbTabela.Append("</tr>");

            //    sbTabela.Append("<tr>");
            //        sbTabela.Append("<td colspan='2'> <font size='1' >" + empresa.Logradouro + " - " + empresa.Bairro + " - " + empresa.Cidade + " - " + empresa.Estado + " - " + empresa.Cep + " </font></td>");
            //    sbTabela.Append("</tr>");

            //    sbTabela.Append("<tr>");
            //        sbTabela.Append("<td colspan='2'> <hr /> </td>");
            //    sbTabela.Append("</tr>");

            //    sbTabela.Append("<tr>");
            //        sbTabela.Append("<td colspan='2'><b> " + strReconhecimento + "</b>  </td>");
            //    sbTabela.Append("</tr>");

            //    sbTabela.Append("<tr>");
            //        sbTabela.Append("<td colspan='2'> <b>" + indices[0].Nome + "</b>  </td>");
            //    sbTabela.Append("</tr>");

            //    sbTabela.Append("<tr>");
            //        sbTabela.Append("<td colspan='2'> "+ empresa.Cidade + " " + DateTime.Now + " " + empresa.Escrevente1 + "- Escrevente" + " </td>");
            //    sbTabela.Append("</tr>");

            //    sbTabela.Append("<tr>");
            //        sbTabela.Append("<td colspan='2'> <b>" + "Selo: " + indices[0].Selo.Numero_Selo + ", consulte em" + "</b>  </td>");
            //    sbTabela.Append("</tr>");

            //    sbTabela.Append("<tr>");
            //        sbTabela.Append("<td colspan='2'> <b>selo.tjal.jus.br</b>   </td>");
            //    sbTabela.Append("</tr>");

            //    sbTabela.Append("</table>");

            //    sbTabela.Append("<br />");
            //}
            

            //relatorio.Append("!+----------------------------------+" + "<br />");
            //    relatorio.Append("|SERVICO NOTARIAL DE JUNQUEIRO-AL  |" + "<br />");
            //    relatorio.Append("|R.Joaquim F.da Costa,210,Centro   |" + "<br />");
            //    relatorio.Append("|Fone:(82) 3541-1321               |" + "<br />");

            //    if (impressao.Equals("V"))
            //    {
            //        relatorio.Append("|     RECONHECO A firma por  verda-|" + "<br />");
            //        relatorio.Append("|deiro de:                         |" + "<br />");
            //    }
            //    if (impressao.Equals("S"))
            //    {
            //        relatorio.Append("|      RECONHECO A firma por  seme-|" + "<br />");
            //        relatorio.Append("|lhanca de:                        |" + "<br />");
            //    }
            //    if (impressao.Equals("A"))
            //    {
            //        relatorio.Append("|      RECONHECO A firma por auten-|" + "<br />");
            //        relatorio.Append("|ticidade de:                      |" + "<br />");
            //    }
            

        }
    }
}