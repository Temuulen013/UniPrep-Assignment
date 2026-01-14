using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniPreperation // Ensure this matches your project namespace
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // The logic is now handled in the HTML (Default.aspx) 
            // using <%= Session["username"] %> tags.
            // So we don't need extra C# code here for now!
        }
    }
}