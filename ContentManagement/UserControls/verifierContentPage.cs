using SAM.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContentManagement.UserControls
{
    public partial class verifierContentPage : UserControl
    {
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public verifierContentPage()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void verifierContentPage_Load(object sender, EventArgs e)
        {

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
