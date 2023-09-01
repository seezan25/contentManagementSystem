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
    public partial class uploaderPage : UserControl
    {
        private uploaderContentPage uploaderContent;
        private uploaderHomePage uploaderHome;
        private uploaderNotificationPage uploaderNotification;
        private uploaderUploadPage uploaderUpload;
        public uploaderPage()
        {
            InitializeComponent();
            uploaderHome = new uploaderHomePage();
            addUserControl(uploaderHome);
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void uploaderPage_Load(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            uploaderHome = new uploaderHomePage();
            addUserControl(uploaderHome);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            uploaderContent = new uploaderContentPage();
            addUserControl(uploaderContent);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            uploaderUpload = new uploaderUploadPage();
            addUserControl(uploaderUpload);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            uploaderNotification = new uploaderNotificationPage();  
            addUserControl(uploaderNotification);   
        }

        private void label13_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
