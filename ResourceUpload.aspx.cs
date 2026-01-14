using System;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI; // standard
using System.Web.UI.WebControls; // standard

namespace UniPreperation.Uploads  // <--- CHECK THIS! Does it match your other files?
{
    // The class name here MUST match the filename "ResourceUpload"
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
            // Note: Make sure your HTML Button has OnClick="btnUpload_Click"

            // Check if the file upload control actually has a file
            // If "fileUploadCtx" is red here, your HTML ID might be different.
            // Check your HTML for: <asp:FileUpload ID="fileUploadCtx" ... />
            if (fileUploadCtx.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fileUploadCtx.FileName);
                    string folderPath = Server.MapPath("~/Uploads/");

                    // Create folder if it doesn't exist (prevents crash)
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    fileUploadCtx.SaveAs(folderPath + filename);

                    string connStr = ConfigurationManager.ConnectionStrings["UniPrepDB"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(connStr))
                    {
                        // Ensure your HTML TextBoxes IDs match these names:
                        // txtTitle, txtCode, ddlType, txtDesc

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