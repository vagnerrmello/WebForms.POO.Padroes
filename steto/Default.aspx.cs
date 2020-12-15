using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Text;

namespace steto
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String currurl = HttpContext.Current.Request.RawUrl;
            //String querystring = null;

            //// Check to make sure some query string variables
            //// exist and if not add some and redirect.
            //int iqs = currurl.IndexOf('?');
            //if (iqs == -1)
            //{
            //    String redirecturl = currurl + "?var1=1&var2=2+2%2f3&var1=3";
            //    Response.Redirect(redirecturl, true);
            //}
            //// If query string variables exist, put them in
            //// a string.
            //else if (iqs >= 0)
            //{
            //    querystring = (iqs < currurl.Length - 1) ? currurl.Substring(iqs + 1) : String.Empty;
            //}

            //// Parse the query string variables into a NameValueCollection.
            //NameValueCollection qscoll = HttpUtility.ParseQueryString(querystring);

            //// Iterate through the collection.
            //StringBuilder sb = new StringBuilder();
            //foreach (String s in qscoll.AllKeys)
            //{
            //    sb.Append(s + " - " + qscoll[s] + "<br />");
            //}

            //// Write the results to the appropriate labels.
            //string teste1 = sb.ToString();
            //string teste2 = currurl;
            //string teste3 = HttpUtility.UrlEncode(currurl);
            //string teste4 = HttpUtility.UrlDecode(currurl);
        }
    }
}
