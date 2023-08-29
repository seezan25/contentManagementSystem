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
        private verifierViewNotificationPage verifierViewNotification;
        public verifierNotificationPage()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void verifierNotificationPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verifierViewNotification = new verifierViewNotificationPage();
            addUserControl(verifierViewNotification) ;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
