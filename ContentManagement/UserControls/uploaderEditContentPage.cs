using SAM.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContentManagement.UserControls
{
    public partial class uploaderEditContentPage : UserControl
    {
        private string selectedFilePath;
        public uploaderEditContentPage()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Execute an UPDATE SQL query to update the data in the database
            using (SqlConnection connection = new SqlConnection(dbConnect.strConnString))
            {
                connection.Open();
                string updateQuery = "UPDATE Contents SET Name = @ModifiedName,Description = @Description WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@ModifiedName", textBox1.Text);
                    command.Parameters.AddWithValue("@Description", textBox3.Text);
                    command.Parameters.AddWithValue("@ID", label4.Text);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Update successful.");
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated.");
                    }
                }
            }
        }

        private void uploaderEditContentPage_Load(object sender, EventArgs e)
        {

        }
    }
    }

