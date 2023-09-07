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
using System.IO;

namespace ContentManagement.UserControls
{
    public partial class adminContentPage : UserControl
    {
        private adminEditContentPage adminEditContent;
        private adminUploadContentPage adminUploadContent;
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public adminContentPage()
        {
            InitializeComponent();
            // Initialize your database connection
            connection = new SqlConnection(dbConnect.strConnString);

            // Initialize data adapter and data table
            dataAdapter = new SqlDataAdapter("SELECT * FROM Contents", connection);
            dataTable = new DataTable();

            // Fill the data table with data from the database
            dataAdapter.Fill(dataTable);

            // Bind the data table to the DataGridView
            dataGridView1.DataSource = dataTable;
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void adminContentPage_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminUploadContent = new adminUploadContentPage();
            addUserControl(adminUploadContent);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminEditContent = new adminEditContentPage();
            // Check if a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row (assuming you want to show data from the first selected row)
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Assuming you have columns named "FilePath" and "FileData" in your DataGridView
                string id = selectedRow.Cells["Id"].Value.ToString();
                string fileName = selectedRow.Cells["Name"].Value.ToString();
                string fileDescription = selectedRow.Cells["Description"].Value.ToString();

                // Display the file path in the txtFilePath TextBox
                adminEditContent.label4.Text = id;
                adminEditContent.textBox1.Text = fileName;
                adminEditContent.textBox3.Text = fileDescription;
            }
            else
            {
                // Clear the TextBoxes if no row is selected
                adminEditContent.label4.Text = string.Empty;
                adminEditContent.textBox1.Text = string.Empty;
                adminEditContent.textBox3.Text = string.Empty;
            }
            addUserControl(adminEditContent);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Get the selected rows from the DataGridView
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                // Assuming you have a column called "FileData" that contains binary file data
                byte[] fileData = (byte[])row.Cells["Files"].Value;

                // Assuming you have a column called "FileName" that contains the file name
                string fileName = row.Cells["Name"].Value.ToString();

                // Create a SaveFileDialog to prompt the user for the download location
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = fileName;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the file to the selected location
                    File.WriteAllBytes(saveFileDialog.FileName, fileData);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Assuming your DataGridView has a column named "ID" as a unique identifier
                int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Execute DELETE SQL query
                using (SqlConnection connection = new SqlConnection(dbConnect.strConnString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM Contents WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", selectedId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Delete successful.");
                            // Refresh the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("No rows were deleted.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Assuming your DataGridView has a boolean column named "Status"
                bool currentStatus = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["Status"].Value);

                // Toggle the boolean value
                bool newStatus = !currentStatus;

                // Get the ID of the selected row
                int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Execute an UPDATE SQL query to update the status
                using (SqlConnection connection = new SqlConnection(dbConnect.strConnString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE Contents SET Status = @NewStatus WHERE Id = @ID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NewStatus", newStatus);
                        command.Parameters.AddWithValue("@ID", selectedId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Update the DataGridView to reflect the change
                            dataGridView1.SelectedRows[0].Cells["Status"].Value = newStatus;
                            MessageBox.Show("Status updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to change the status.");
            }
        }
    }
}










