using System;
using System.Web;
using System.Web.UI;

namespace UniPreperation
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. Destroy the Session (The digital ID card)
            Session.Abandon();

            // 2. Clear any authentication cookies (Good practice)
            Session.Clear();

            // 3. Redirect back to Login
            Response.Redirect("Login.aspx");
        }
    }
}