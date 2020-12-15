using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Steto.CID.Convênio
{
    public partial class Convenio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tabMenu.Items[MultiView1.ActiveViewIndex].Selected = true;
        }

        protected void tabMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "Info":
                    MultiView1.ActiveViewIndex = 0;
                    break;

                case "Guias":
                    MultiView1.ActiveViewIndex = 1;
                    break;
                case "WebServices":
                    MultiView1.ActiveViewIndex = 2;
                    break;
                case "Procedimento":
                    MultiView1.ActiveViewIndex = 3;
                    break;
                case "Pacotes":
                    MultiView1.ActiveViewIndex = 4;
                    break;
                case "ModInterfaces":
                    MultiView1.ActiveViewIndex = 5;
                    break;
                case "Preferencias":
                    MultiView1.ActiveViewIndex = 6;
                    break;
            }
        }
    }
}