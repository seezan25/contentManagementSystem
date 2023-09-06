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
                string fileName = selectedRow.Cells["Name"].Value.ToString();
                string filePath = selectedRow.Cells["Path"].Value.ToString();
                byte[] fileData = (byte[])selectedRow.Cells["Files"].Value;

                // Display the file path in the txtFilePath TextBox
                adminEditContent.textBox1.Text = fileName;
                adminEditContent.textBox3.Text = filePath;

                // Assuming you want to display the file data as a string (you may need to decode it appropriately)
                string fileDataAsString = Encoding.UTF8.GetString(fileData); // Change the encoding if needed
                //txtFileData.Text = fileDataAsString;
            }
            else
            {
                // Clear the TextBoxes if no row is selected
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
    }
}










