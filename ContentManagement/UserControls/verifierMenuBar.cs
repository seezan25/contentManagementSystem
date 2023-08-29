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
    public partial class verifierMenuBar : UserControl
    {
        private Form1 form1;
        private verifierHomePage verifierHome;
        private verifierMenuBar verifierMenu;
        private viewerContentPage verifierContent;
        private verifierNotificationPage verifierNotification;
        public verifierMenuBar()
        {
            InitializeComponent();
            verifierHome = new verifierHomePage();
            addUserControl2(verifierHome);
        }
        private void addUserControl(UserControl userControl)
        {
            form1 = new Form1();
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
        private void addUserControl3(UserControl userControl)
        {
            form1 = new Form1();
            userControl.Dock = DockStyle.Fill;
            verifierHome.panel1.Controls.Clear();
            verifierHome.panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void verifierMenuBar_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            verifierHome = new verifierHomePage();
            addUserControl2(verifierHome);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            verifierContent=new viewerContentPage();
            addUserControl2(verifierContent);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            verifierNotification=new verifierNotificationPage();
            addUserControl2(verifierNotification);
        }
    }
}
