using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContentManagement.UserControls
{
    public partial class adminMenuBar : UserControl
    {
        private adminHomePage adminHome;
        private Form1 form1;
        private adminContentPage adminContent;
        private adminNotificationPage adminNotification;
        public adminMenuBar()
        {
            InitializeComponent();
            adminContent = new adminContentPage();
            addUserControl2(adminContent);

    }
        private void addUserControl(UserControl userControl)
        {
            form1 = new  Form1();           
            userControl.Dock = DockStyle.Fill;
            form1.panel1.Controls.Clear();
            form1.panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void addUserControl2(UserControl userControl)
        {
            form1 = new Form1();
            userControl.Dock = DockStyle.Fill;
            form1.panel2.Controls.Clear();
            form1.panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void adminMenuBar_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            adminHome =new adminHomePage();
            addUserControl2(adminHome);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            adminContent = new adminContentPage();
            addUserControl2(adminContent);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            adminNotification = new adminNotificationPage();
            addUserControl2(adminNotification);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
