using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration; 
using System.Data.SqlClient; 

namespace UniPreperation
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            
            
            string connStr = ConfigurationManager.ConnectionStrings["UniPrepDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                try
                {
                    
                    string query = "INSERT INTO users (username, email, password) VALUES (@user, @email, @pass)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                    
                    con.Open();
                    cmd.ExecuteNonQuery();

                    
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Registration Successful! You can now Login.";
                }
                catch (Exception ex)
                {
                    
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}