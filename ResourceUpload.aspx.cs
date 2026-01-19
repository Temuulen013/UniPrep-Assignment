using System;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI; 
using System.Web.UI.WebControls; 

namespace UniPreperation.Uploads  
{
    
    public partial class ResourceUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            

            
            
            
            if (fileUploadCtx.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fileUploadCtx.FileName);
                    string folderPath = Server.MapPath("~/Uploads/");

                    
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    fileUploadCtx.SaveAs(folderPath + filename);

                    string connStr = ConfigurationManager.ConnectionStrings["UniPrepDB"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(connStr))
                    {
                        
                        

                        string query = @"INSERT INTO resources 
                                       (title, subject_code, type, file_link, description, uploaded_by, status) 
                                       VALUES (@title, @code, @type, @link, @desc, @uid, 'pending')";

                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@code", txtCode.Text);
                        cmd.Parameters.AddWithValue("@type", ddlType.SelectedValue);
                        cmd.Parameters.AddWithValue("@link", filename);
                        cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
                        cmd.Parameters.AddWithValue("@uid", Session["user_id"]);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Upload Successful!";
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please select a file.";
            }
        }
    }
}