using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace UniPreperation
{
    public partial class UserProfile : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["UniPrepDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadProfile();
            }
        }

        // --- READ OPERATION ---
        private void LoadProfile()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                // Fetch current user details
                string query = "SELECT username, email FROM users WHERE user_id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Session["user_id"]);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtUsername.Text = reader["username"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                }
            }
        }

        // --- UPDATE OPERATION ---
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "UPDATE users SET email = @email";

                // Only update password if the user typed something new
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    query += ", password = @pass";
                }

                query += " WHERE user_id = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@id", Session["user_id"]);

                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                }

                con.Open();
                cmd.ExecuteNonQuery();

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Profile updated successfully!";
            }
        }

        // --- DELETE OPERATION ---
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                // First: Delete user's uploads to avoid database errors (Foreign Key constraints)
                string deleteResources = "DELETE FROM resources WHERE uploaded_by = @id";
                SqlCommand cmdRes = new SqlCommand(deleteResources, con);
                cmdRes.Parameters.AddWithValue("@id", Session["user_id"]);

                con.Open();
                cmdRes.ExecuteNonQuery();

                // Second: Delete the user account
                string deleteUser = "DELETE FROM users WHERE user_id = @id";
                SqlCommand cmdUser = new SqlCommand(deleteUser, con);
                cmdUser.Parameters.AddWithValue("@id", Session["user_id"]);
                cmdUser.ExecuteNonQuery();
            }

            // Log them out and send to home
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}