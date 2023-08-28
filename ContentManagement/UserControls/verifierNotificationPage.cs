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
    public partial class verifierNotificationPage : UserControl
    {
        private verifierMenuBar verifierMenu;
        private verifierViewNotificationPage verifierViewNotification;
        private verifierNotificationPage verifierNotification;
        private Form1 form1;
        public verifierNotificationPage()
        {
            InitializeComponent();
            verifierMenu = new verifierMenuBar();
            addUserControl(verifierMenu);
            verifierNotification =new verifierNotificationPage();
            addUserControl2(verifierNotification);
            
        }
        private void addUserControl(UserControl userControl)
        {
            form1 = new Form1();  
            userControl.Dock= DockStyle.Fill;
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
        private void verifierNotificationPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verifierViewNotification = new verifierViewNotificationPage();
            addUserControl2(verifierViewNotification) ;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
