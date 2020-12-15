using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Steto.Notas
{
    public partial class Paciente : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //tabMenu.Items[MultiView1.ActiveViewIndex].Selected = true;
        }

        protected void tabMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "Info":
                    Response.Redirect(@"~/Paciente/PacienteFicha.aspx");
                    //MultiView1.ActiveViewIndex = 0;
                    break;
                case "anamineseEvolucoes":
                    Response.Redirect(@"~/Paciente/AnamineseEvolucao.aspx");
                    //MultiView1.ActiveViewIndex = 2;
                    break;
                case "Guias":
                    //MultiView1.ActiveViewIndex = 1;
                    break;
            }
        }
    }
}