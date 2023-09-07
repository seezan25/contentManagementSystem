using SAM.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContentManagement.UserControls
{
    public partial class adminEditContentPage : UserControl
    {
        private string selectedFilePath;
        public adminEditContentPage()
        {
            InitializeComponent();
        }

        internal void SetContentData(int contentID, string title, string description)
        {
            throw new NotImplementedException();
        }

        private void adminEditContentPage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}
