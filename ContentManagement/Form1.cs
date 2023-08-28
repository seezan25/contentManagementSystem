using ContentManagement.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContentManagement
{
    public partial class Form1 : Form
    {
        private nonRegisteredUserPage nonRegisteredUser;
        private loginUserControl login;
        private signupUserControl signUp;

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock= DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }
        public Form1()
        {
            InitializeComponent();
            nonRegisteredUser = new nonRegisteredUserPage();
            addUserControl(nonRegisteredUser);
        }

        private void label1_Click(object sender, EventArgs e)
        {

            nonRegisteredUser = new nonRegisteredUserPage();
            addUserControl(nonRegisteredUser);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            login = new loginUserControl();
            addUserControl(login);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            signUp = new signupUserControl();
            addUserControl(signUp);
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
    }
}
