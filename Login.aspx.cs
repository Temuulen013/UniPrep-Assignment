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
                // We need to fetch the ID and Role so we can save them in the Session
                string query = "SELECT user_id, username, role FROM users WHERE email=@email AND password=@pass";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // If a row was found
                    {
                        // 1. Create the Session Variables
                        // This "logs them in" and remembers who they are
                        Session["user_id"] = reader["user_id"].ToString();
                        Session["username"] = reader["username"].ToString();
                        Session["role"] = reader["role"].ToString(); // Important for Admin check later!

                        // 2. Redirect to Homepage
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