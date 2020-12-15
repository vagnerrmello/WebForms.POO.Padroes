using System;
using System.IO;
using System.Web;

namespace Steto
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PermissaoPagina();
        }

        private void PermissaoPagina()
        {
            try
            {
                if (Session["PerfilFuncionalidades"] != null)
                {
                }
                else
                {
                    Response.Redirect(@"~/Default.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}