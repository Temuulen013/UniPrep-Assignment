using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace UniPreperation
{
    public partial class ViewResources : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadResources();
            }
        }

        private void LoadResources(string searchTerm = "")
        {
            string connStr = ConfigurationManager.ConnectionStrings["UniPrepDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                // Basic SQL query
                // We JOIN 'users' table so we can show the username instead of just user_id
                string query = @"SELECT r.resource_id, r.title, r.subject_code, r.type, r.file_link, r.status, u.username 
                                 FROM resources r 
                                 JOIN users u ON r.uploaded_by = u.user_id";

                // If user typed in search box, add a WHERE clause
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " WHERE r.title LIKE @search OR r.subject_code LIKE @search";
                }

                SqlCommand cmd = new SqlCommand(query, con);

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                }

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Bind the data to the GridView
                gvResources.DataSource = dt;
                gvResources.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadResources(txtSearch.Text.Trim());
        }
    }
}