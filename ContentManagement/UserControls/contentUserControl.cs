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
using System.Data.Common;

namespace ContentManagement.UserControls
{
    public partial class contentUserControl : UserControl
    {
        private readContent ReadContent;
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public contentUserControl()
        {
            InitializeComponent();
            // Initialize your database connection
            connection = new SqlConnection(dbConnect.strConnString);

            // Initialize data adapter and data table
            dataAdapter = new SqlDataAdapter("SELECT Name, Date, Description FROM Contents WHERE Status = 'True'", connection);
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

        private void button4_Click(object sender, EventArgs e)
        {
            ReadContent = new readContent();
            // Check if a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row (assuming you want to show data from the first selected row)
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Assuming you have columns named "FilePath" and "FileData" in your DataGridView
                string fileName = selectedRow.Cells["Name"].Value.ToString();
                string fileDescription = selectedRow.Cells["Description"].Value.ToString();

                // Display the file path in the txtFilePath TextBox


                ReadContent.textBox3.Text = fileDescription;
            }
            else
            {
                // Clear the TextBoxes if no row is selected


                ReadContent.textBox3.Text = string.Empty;
            }
            addUserControl(ReadContent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
