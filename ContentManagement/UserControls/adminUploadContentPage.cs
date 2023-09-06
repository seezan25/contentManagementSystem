//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace ContentManagement.UserControls
//{
//    public partial class adminUploadContentPage : UserControl
//    {
//        public adminUploadContentPage()
//        {
//            InitializeComponent();
//        }

//        private void adminUploadContentPage_Load(object sender, EventArgs e)
//        {

//        }

//        private void button1_Click(object sender, EventArgs e)
//        {

//                // Check if a file has been selected
//                if (!string.IsNullOrEmpty(textBox3.Text))
//                {
//                    try
//                    {
//                        // Get the selected file path from the TextBox
//                        string selectedFilePath = textBox3.Text;

//                        // Set the destination directory where you want to save the file
//                        string destinationDirectory = @"C:\YourDestinationDirectory\";

//                        // Get the file name from the selected file path
//                        string fileName = System.IO.Path.GetFileName(selectedFilePath);

//                        // Combine the destination directory and file name to create the destination path
//                        string destinationPath = System.IO.Path.Combine(destinationDirectory, fileName);

//                        // Copy the selected file to the destination directory
//                        System.IO.File.Copy(selectedFilePath, destinationPath);

//                        // Display a success message
//                        MessageBox.Show("File has been saved to the destination directory.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    }
//                    catch (Exception ex)
//                    {
//                        // Handle any exceptions that may occur during the file copy operation
//                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    }
//                }
//                else
//                {
//                    // Display a message if no file has been selected
//                    MessageBox.Show("Please select a file to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//            }



//        private void button2_Click(object sender, EventArgs e)
//        {
//            OpenFileDialog openFileDialog = new OpenFileDialog();

//            // Set filters for the file types you want to allow (e.g., PDF files)
//            openFileDialog.Filter = "PDF Files|*.pdf|All Files|*.*";

//            // Show the file dialog to the user
//            if (openFileDialog.ShowDialog() == DialogResult.OK)
//            {
//                // Get the selected file path and display it in a TextBox or Label
//                string selectedFilePath = openFileDialog.FileName;
//                textBox3.Text = selectedFilePath; // Assuming you have a TextBox named textBoxFilePath
//            }
//        }
//    }
//}
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ContentManagement.UserControls
{
    public partial class adminUploadContentPage : UserControl
    {
        private string selectedFilePath;
        // Database connection string
        private string strConnString = "Data Source=DESKTOP-4MDUH5M;Initial Catalog=contentManagementSystem;Integrated Security=True";

        public adminUploadContentPage()
        {
            InitializeComponent();
        }

        private void adminUploadContentPage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the OpenFileDialog class
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    // Read the selected file into a byte array
                    byte[] fileData = File.ReadAllBytes(selectedFilePath); // Use the class-level variable
                    string fileName = textBox1.Text.Trim();
                    int uploaderId = GetUploaderId(); // Replace with the actual uploader ID
                    DateTime uploadDate = DateTime.Now;
                    int status = 0; // Set initial status as needed

                    using (SqlConnection connection = new SqlConnection(strConnString))
                    {
                        connection.Open();

                        // SQL query to insert the file data into the database
                        string insertQuery = "INSERT INTO Contents (Name, Path, Date, Status,Files) " +
                                             "VALUES (@ContentName, @ContentPath, @UploadDate, @Status,@Files)";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            // Set parameters for the query
                            command.Parameters.AddWithValue("@ContentName", fileName);
                            command.Parameters.AddWithValue("@ContentPath", selectedFilePath);
                            command.Parameters.AddWithValue("@UploadDate", uploadDate);
                            command.Parameters.AddWithValue("@Status", status);
                            command.Parameters.AddWithValue("@Files", fileData);
                            // Execute the query
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("File has been saved to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private int GetUploaderId()
        {
            // Replace this with your logic to get the uploader ID
            // For example, you might have a login system that assigns an ID to the uploader.
            return 1; // Dummy value; replace it with the actual ID.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



