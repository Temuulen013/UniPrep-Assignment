using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration; // Required for Web.config
using System.Data.SqlClient; // Required for SQL

namespace UniPreperation
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // 1. Read connection string from Web.config
            // Make sure "UniPrepDB" matches the name in your Web.config file!
            string connStr = ConfigurationManager.ConnectionStrings["UniPrepDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                try
                {
                    // 2. Prepare the SQL query
                    string query = "INSERT INTO users (username, email, password) VALUES (@user, @email, @pass)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    // 3. Add parameters (Security)
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                    // 4. Open connection and Execute
                    con.Open();
                    cmd.ExecuteNonQuery();

                    // 5. Success Feedback
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Registration Successful! You can now Login.";
                }
                catch (Exception ex)
                {
                    // 6. Error Feedback
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}