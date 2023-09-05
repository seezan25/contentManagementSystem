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
    public partial class uploaderEditContentPage : UserControl
    {
        private string selectedFilePath;
        public uploaderEditContentPage()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filters for the file types you want to allow (e.g., PDF files)
            openFileDialog.Filter = "PDF Files|*.pdf|All Files|*.*";

            // Show the file dialog to the user
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path and display it in a TextBox
                selectedFilePath = openFileDialog.FileName; // Assign the value to the class-level variable
                textBox3.Text = selectedFilePath;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
