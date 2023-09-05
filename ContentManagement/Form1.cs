using ContentManagement.UserControls;
using SAM.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContentManagement
{
    public partial class Form1 : Form
    {
        private adminPage adminpage;
        private uploaderPage uploaderpage;
        private verifierPage verifierpage;
        private dbConnect DbConnect;

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }
        public Form1()
        {
            InitializeComponent();
            comboBox3.Text = "Admin";
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {



        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            string password = textBox4.Text;
            string userrole = "";
            if (comboBox3.SelectedItem != null)
            {
                userrole = comboBox3.SelectedItem.ToString();
            }

            if (username == "" || password == "" | userrole == "")
            {
                MessageBox.Show("Please fill the login details first.");
            }
            else
            {
                DbConnect = new dbConnect();
                if (userrole == "Admin")
                {
                    using (SqlConnection connection = new SqlConnection(dbConnect.strConnString))
                    {
                        connection.Open();
                        try
                        {
                            string query = "SELECT COUNT(*) FROM Admins WHERE Username = @Username AND Password = @Password";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Username", username);
                                command.Parameters.AddWithValue("@Password", password);

                                int count = (int)command.ExecuteScalar();

                                if (count > 0)
                                {
                                    // Successful login
                                    MessageBox.Show("Login successful!");

                                    adminpage = new adminPage();
                                    addUserControl(adminpage);
                                    // Perform user control change or other navigation here
                                }
                                else
                                {
                                    // Invalid login
                                    MessageBox.Show("Invalid login credentials.");
                                }
                            }

                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }
                    }
                }
                else if (userrole == "Verifier")
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(dbConnect.strConnString))
                        {
                            connection.Open();
                            string query = "SELECT COUNT(*) FROM Verifiers WHERE Username = @Username AND Password = @Password";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Username", username);
                                command.Parameters.AddWithValue("@Password", password);

                                int count = (int)command.ExecuteScalar();

                                if (count > 0)
                                {
                                    // Successful login
                                    MessageBox.Show("Login successful!");

                                    verifierpage = new verifierPage();
                                    addUserControl(verifierpage);
                                    // Perform user control change or other navigation here
                                }
                                else
                                {
                                    // Invalid login
                                    MessageBox.Show("Invalid login credentials.");
                                }
                            }

                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }

                }


                else if (userrole == "Uploader")
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(dbConnect.strConnString))
                        {
                            connection.Open();
                            string query = "SELECT COUNT(*) FROM Uploaders WHERE Username = @Username AND Password = @Password";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Username", username);
                                command.Parameters.AddWithValue("@Password", password);

                                int count = (int)command.ExecuteScalar();

                                if (count > 0)
                                {
                                    // Successful login
                                    MessageBox.Show("Login successful!");

                                    uploaderpage = new uploaderPage();
                                    addUserControl(uploaderpage);
                                    // Perform user control change or other navigation here
                                }
                                else
                                {
                                    // Invalid login
                                    MessageBox.Show("Invalid login credentials.");
                                }
                            }

                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox3.Text = "Admin";
        }
    }
}





