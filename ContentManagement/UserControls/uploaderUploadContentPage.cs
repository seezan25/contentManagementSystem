using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using RestSharp;
using SAM.form;
using System.Data.SqlClient;

namespace ContentManagement.UserControls
{
    public partial class uploaderUploadContentPage : UserControl
    {
        private uploaderUploadContentPage uploaderUploadContent;
        private uploaderEditContentPage uploaderEditContent;
        private string selectedFilePath;
        public uploaderUploadContentPage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filters for the file types you want to allow (e.g., PDF files)
            openFileDialog.Filter = "PDF Files|*.pdf|All Files|*.*";

            // Show the file dialog to the user
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path and display it in a TextBox
                selectedFilePath = openFileDialog.FileName; // Assign the value to the class-level variable
                textBox3.Text = selectedFilePath;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
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
                            command.Parameters.AddWithValue("@ContentName", textBox1.Text);
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

        private void uploaderUploadContentPage_Load(object sender, EventArgs e)
        {

        }
    }
}