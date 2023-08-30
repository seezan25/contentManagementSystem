﻿using System;
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
    public partial class uploaderUploadPage : UserControl
    {
        private uploaderUploadContentPage uploaderUploadContent;
        private uploaderEditContentPage uploaderEditContent;
        public uploaderUploadPage()
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
            uploaderUploadContent = new uploaderUploadContentPage();
            addUserControl(uploaderUploadContent);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uploaderEditContent = new uploaderEditContentPage();
            addUserControl(uploaderEditContent);
        }

        private void uploaderUploadPage_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
