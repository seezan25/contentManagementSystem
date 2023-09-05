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
    public partial class adminUploaderPage : UserControl
    {
        private adminUploaderAddPage adminUploaderAdd;
        private adminUploaderEditPage adminUploaderEdit;
        public adminUploaderPage()
        {
            InitializeComponent();
            try
            {
                using (SqlConnection connection = new SqlConnection(dbConnect.strConnString))
                {
                    connection.Open();

                    // Define your SQL query to retrieve limited columns from the "uploaders" table
                    string selectQuery = "SELECT Username, Password,Name,Address,Phone_no FROM uploaders";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
          private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminUploaderAdd = new adminUploaderAddPage();
            addUserControl(adminUploaderAdd);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Check if any rows are selected
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No rows selected. Please select the rows you want to delete.");
                return;
            }
            else
            {


                try
                {
                    using (SqlConnection connection = new SqlConnection(dbConnect.strConnString))
                    {
                        connection.Open();

                        // Iterate through the selected rows in the DataGridView
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            // Assuming the primary key value is in the first column (e.g., "ID")
                            string usernameToDelete = row.Cells["Username"].Value.ToString();

                            // Define the SQL DELETE statement
                            string deleteQuery = "DELETE FROM Uploaders WHERE Username = @Username";

                            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                            {
                                // Add the parameter for the primary key
                                command.Parameters.AddWithValue("@Username", usernameToDelete);

                                // Execute the DELETE statement
                                command.ExecuteNonQuery();
                            }

                            // Remove the row from the DataGridView
                            dataGridView1.Rows.Remove(row);
                            MessageBox.Show("Data Deleted Successfully");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            adminUploaderEdit = new adminUploaderEditPage();
            addUserControl(adminUploaderEdit);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
