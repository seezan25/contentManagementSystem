﻿using SAM.form;
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
    public partial class uploaderContentPage : UserControl
    {
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private uploaderUploadContentPage UploaderUploadContentPage;
        private uploaderEditContentPage UploaderEditContentPage;
        private readContent ReadContent;
        public uploaderContentPage()
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

        public Action<object, EventArgs> AddUserControlRequested { get; internal set; }

        private void uploaderContentPage_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UploaderUploadContentPage = new uploaderUploadContentPage();
            addUserControl(UploaderUploadContentPage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UploaderEditContentPage = new uploaderEditContentPage();
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
                UploaderEditContentPage.label4.Text = id;
                UploaderEditContentPage.textBox1.Text = fileName;
                UploaderEditContentPage.textBox3.Text = fileDescription;
            }
            else
            {
               // if not row is selected
                UploaderEditContentPage.label4.Text = string.Empty;
                UploaderEditContentPage.textBox1.Text = string.Empty;
                UploaderEditContentPage.textBox3.Text = string.Empty;
            }
            addUserControl(UploaderEditContentPage);
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to allow the user to choose where to save the text file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files|*.txt";
                saveFileDialog.Title = "Save Text File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileName = saveFileDialog.FileName;

                        // Create a StringBuilder to store the text data
                        StringBuilder sb = new StringBuilder();

                        // Iterate through the selected rows in the DataGridView
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            // Assuming you have DataGridView columns named "Column1" and "Column2"
                            string column1Value = row.Cells["Name"].Value.ToString();
                            string column2Value = row.Cells["Description"].Value.ToString();

                            // Append the data to the StringBuilder
                            sb.AppendLine($"File Source Name: {column1Value}");
                            sb.AppendLine($" Content: {column2Value}");
                        }

                        // Write the content to the selected file
                        File.WriteAllText(fileName, sb.ToString(), Encoding.UTF8);

                        MessageBox.Show("Text file saved successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving the text file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
