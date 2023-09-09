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
    public partial class adminVerifierAddPage : UserControl
    {
        public adminVerifierAddPage()
        {
            InitializeComponent();
        }

        private void adminVerifierAddPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dbConnect.strConnString))
                {
                    connection.Open();

                    // Define your INSERT SQL statement
                    string insertQuery = "INSERT INTO Verifiers (Name, Phone_no,Address,Username,Password) VALUES (@VerifierName, @VerifierPhone,@VerifierAddress,@VerifierUsername,@VerifierPassword)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Set parameter values from your form inputs
                        command.Parameters.AddWithValue("@VerifierName", textBox1.Text);
                        command.Parameters.AddWithValue("@VerifierPhone", textBox2.Text);
                        command.Parameters.AddWithValue("@VerifierAddress", textBox3.Text);
                        command.Parameters.AddWithValue("@VerifierUsername", textBox5.Text);
                        command.Parameters.AddWithValue("@VerifierPassword", textBox6.Text);

                        // Execute the INSERT statement
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data inserted successfully.");
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox5.Text = "";
                            textBox6.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Data insertion failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
