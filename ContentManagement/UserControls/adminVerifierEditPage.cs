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
    public partial class adminVerifierEditPage : UserControl
    {
        public adminVerifierEditPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Construct and execute the SQL UPDATE query
                using (SqlConnection connection = new SqlConnection(dbConnect.strConnString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE verifiers SET Name = @NewValue1, Phone_no = @NewValue2, Address = @NewValue3,Username = @NewValue4,Password = @NewValue5 WHERE Id = @RecordID";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@NewValue1", textBox1.Text);
                        cmd.Parameters.AddWithValue("@NewValue2", textBox2.Text);
                        cmd.Parameters.AddWithValue("@NewValue3", textBox3.Text);
                        cmd.Parameters.AddWithValue("@NewValue4", textBox5.Text);
                        cmd.Parameters.AddWithValue("@NewValue5", textBox6.Text);
                        cmd.Parameters.AddWithValue("@RecordID", label7.Text); // Provide the record's unique identifier
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data updated successfully.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
