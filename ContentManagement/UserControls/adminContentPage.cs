using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContentManagement.UserControls
{
    public partial class adminContentPage : UserControl
    {
        private adminEditContentPage adminEditContent;
        private adminUploadContentPage adminUploadContent;

        public adminContentPage()
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
        private void adminContentPage_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminUploadContent = new adminUploadContentPage();
            addUserControl(adminUploadContent);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminEditContent = new adminEditContentPage();
            addUserControl(adminEditContent);
        }
    }
}









