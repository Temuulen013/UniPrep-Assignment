using System;
using System.Web;
using System.Web.UI;

namespace UniPreperation
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Session.Abandon();

            
            Session.Clear();

            
            Response.Redirect("Login.aspx");
        }
    }
}