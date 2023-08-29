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
    public partial class loginUserControl : UserControl
    {
        public Form1 form1;
        public uploaderContentPage uploaderContent;
        public loginUserControl()
        {
            InitializeComponent();
        }
        public void addUserControl(UserControl userControl)
        {
            form1 = new Form1();
            form1.Dock = DockStyle.Fill;
            form1.panel2.Controls.Clear();
            form1.panel2.Controls.Add(userControl);
            form1.panel2.BringToFront();
        }
        
        private void login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            uploaderContent = new uploaderContentPage();
            addUserControl(uploaderContent);
        }
    }
}
