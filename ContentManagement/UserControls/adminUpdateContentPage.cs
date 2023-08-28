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
    public partial class adminUpdateContentPage : UserControl
    {
        private adminUploadContentPage adminUploadContent;
        private adminEditContentPage adminEditContent;
        public adminUpdateContentPage()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl userControl)
        {
            Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void adminUpdateContentPage_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
