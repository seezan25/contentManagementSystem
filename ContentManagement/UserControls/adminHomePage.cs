using SAM.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContentManagement.UserControls
{
    public partial class adminHomePage : UserControl
    {
        public adminHomePage()
        {
            InitializeComponent();

          
          
            using (SqlConnection connection = new SqlConnection(dbConnect.strConnString))
            {
                // Open the connection
                connection.Open();

                // Define the SQL query to count the items in the "uploader" table
                string query = "SELECT COUNT(*) FROM Uploaders";
                string query1 = "SELECT COUNT(*) FROM Verifiers";
                string query2 = "SELECT COUNT(*) FROM Contents";


                // Create a SqlCommand object with the query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the query and get the result (count)
                    int totalCount = (int)command.ExecuteScalar();
                    label6.Text = totalCount.ToString();

                    // Display the total count or use it as needed
                    
                }
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    // Execute the query and get the result (count)
                    int totalCount = (int)command.ExecuteScalar();
                    label5.Text = totalCount.ToString();

                    // Display the total count or use it as needed

                }
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    // Execute the query and get the result (count)
                    int totalCount = (int)command.ExecuteScalar();
                    label4.Text = totalCount.ToString();

                    // Display the total count or use it as needed

                }
            }


        }

        private void adminHomePage_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
