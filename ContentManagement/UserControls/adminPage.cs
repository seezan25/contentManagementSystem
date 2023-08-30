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
    public partial class adminPage : UserControl
    {
        private adminHomePage adminHome;
        private adminContentPage adminContent;
        private adminNotificationPage adminNotification;
        private adminVerifierPage adminVerifier;
        private adminUploaderPage adminUploader;
        public adminPage()
        {
            InitializeComponent();
            adminHome = new adminHomePage();
            addUserControl(adminHome);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            adminHome = new adminHomePage();
            addUserControl(adminHome);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            adminContent = new adminContentPage();
            addUserControl(adminContent);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            adminVerifier = new adminVerifierPage();
            addUserControl(adminVerifier);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            adminUploader = new adminUploaderPage();
            addUserControl(adminUploader);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            adminNotification = new adminNotificationPage();    
            addUserControl(adminNotification);
        }
    }
}
