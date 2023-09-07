
using SAM.form;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ContentManagement.UserControls
{
    public partial class adminUploadContentPage : UserControl
    {
        // Database connection string


        public adminUploadContentPage()
        {
            InitializeComponent();
        }

        private void adminUploadContentPage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    DateTime uploadDate = DateTime.Now;
                    int status = 0; // Set initial status as needed

                    using (SqlConnection connection = new SqlConnection(dbConnect.strConnString))
                    {
                        connection.Open();

                        // SQL query to insert the file data into the database
                        string insertQuery = "INSERT INTO Contents (Name, Date, Status, Description) " +
                                             "VALUES (@ContentName, @UploadDate, @Status,@Description)";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            // Set parameters for the query
                            command.Parameters.AddWithValue("@ContentName",textBox1.Text);
                            command.Parameters.AddWithValue("@UploadDate", uploadDate);
                            command.Parameters.AddWithValue("@Status", status);
                            command.Parameters.AddWithValue("@Description", textBox3.Text);

                            // Execute the query
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Content Uploaded to the Database");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a file and enter a name to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

 

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



