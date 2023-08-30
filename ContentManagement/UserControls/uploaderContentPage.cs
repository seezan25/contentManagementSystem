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
    public partial class uploaderContentPage : UserControl
    {
        public uploaderContentPage()
        {
            InitializeComponent();
        }

        public Action<object, EventArgs> AddUserControlRequested { get; internal set; }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void uploaderContentPage_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
