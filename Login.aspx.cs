using System;
using System.Configuration;
using System.Data.SqlClient;

namespace UniPreperation

{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["UniPrepDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                
                string query = "SELECT user_id, username, role FROM users WHERE email=@email AND password=@pass";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) 
                    {
                        
                        
                        Session["user_id"] = reader["user_id"].ToString();
                        Session["username"] = reader["username"].ToString();
                        Session["role"] = reader["role"].ToString(); 

                        
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Invalid Email or Password.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}