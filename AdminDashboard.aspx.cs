using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniPreperation
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. SECURITY: Only allow Admins!
            if (Session["role"] == null || Session["role"].ToString() != "admin")
            {
                // Kick them out if they are not an admin
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadPendingResources();
            }
        }

        private void LoadPendingResources()
        {
            string connStr = ConfigurationManager.ConnectionStrings["UniPrepDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                // Show ALL resources (both pending and approved) so Admin can manage them
                string query = @"SELECT r.resource_id, r.title, r.status, u.username 
                                 FROM resources r 
                                 JOIN users u ON r.uploaded_by = u.user_id";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvAdmin.DataSource = dt;
                gvAdmin.DataBind();
            }
        }

        protected void gvAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["UniPrepDB"].ConnectionString;
            int resourceId = Convert.ToInt32(e.CommandArgument);

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                if (e.CommandName == "ApproveResource")
                {
                    // === REQUIREMENT: UPDATE RECORD ===
                    string updateQuery = "UPDATE resources SET status='approved' WHERE resource_id=@id";
                    SqlCommand cmd = new SqlCommand(updateQuery, con);
                    cmd.Parameters.AddWithValue("@id", resourceId);
                    cmd.ExecuteNonQuery();

                    lblMessage.Text = "Resource Approved Successfully.";
                }
                else if (e.CommandName == "DeleteResource")
                {
                    // === REQUIREMENT: DELETE RECORD ===
                    string deleteQuery = "DELETE FROM resources WHERE resource_id=@id";
                    SqlCommand cmd = new SqlCommand(deleteQuery, con);
                    cmd.Parameters.AddWithValue("@id", resourceId);
                    cmd.ExecuteNonQuery();

                    lblMessage.Text = "Resource Deleted.";
                }
            }

            // Refresh the list to show changes
            LoadPendingResources();
        }
    }
}