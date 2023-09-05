using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using RestSharp;
namespace ContentManagement.UserControls
{
    public partial class uploaderUploadContentPage : UserControl
    {
        private uploaderUploadContentPage uploaderUploadContent;
        private uploaderEditContentPage uploaderEditContent;
        private string selectedFilePath;
        public uploaderUploadContentPage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}