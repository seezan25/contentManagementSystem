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
    public partial class adminNotificationPage : UserControl
    {
        private adminViewNotificationPage adminViewNotification;
        private adminNotificationPage adminNotification;
        public adminNotificationPage()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl userControl)
        {
            adminNotification = new adminNotificationPage();
            userControl.Dock = DockStyle.Fill;
            adminNotification.Controls.Clear();
            adminNotification.Controls.Add(adminViewNotification);
            userControl.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
