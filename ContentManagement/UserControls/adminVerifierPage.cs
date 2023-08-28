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
    public partial class adminVerifierPage : UserControl
    {
        private adminVerifierAddPage adminVerifierAdd;
        private adminVerifierEditPage adminVerifierEdit;
        public adminVerifierPage()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminVerifierAdd = new adminVerifierAddPage();
            addUserControl(adminVerifierAdd);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminVerifierEdit = new adminVerifierEditPage();
            addUserControl(adminVerifierEdit);
        }
    }
}
