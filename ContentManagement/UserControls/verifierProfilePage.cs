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
    public partial class verifierProfilePage : UserControl
    {
        private verifierProfileEditPage verifierProfileEdit;
        private verifierHomePage verifierHome;
        public verifierProfilePage()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            verifierHome.panel1.Controls.Clear();
            verifierHome.panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verifierProfileEdit = new verifierProfileEditPage();
            addUserControl(verifierProfileEdit);
        }
    }
}
