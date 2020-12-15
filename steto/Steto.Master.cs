using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Steto.ValueObjectLayer;

namespace Steto
{
    public partial class Steto : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Permissoes();
            }
        }

        protected void Permissoes()
        {
            IList<ValueObjectLayer.Modulo> modulos = (IList<ValueObjectLayer.Modulo>)Session["Modulos"];
            IList<MenuItem> itensMenu = new List<MenuItem>();
            //foreach (TB_Modulo modulo in modulos)
            foreach (ValueObjectLayer.Modulo modulo in modulos)
            {
                itensMenu.Add(new MenuItem(modulo.Nome, modulo.Nome, "", modulo.CaminhoPagina));
            }
            foreach (MenuItem item in itensMenu)
            {
                MenuPrincipal.Items.Add(item);
            }

        }
    }
}