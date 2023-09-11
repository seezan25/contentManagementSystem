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
    public partial class verifierPage : UserControl
    {
        private verifierHomePage verifierHome;
        private verifierUploaderPage verifierUploader;
        private verifierContentPage verifiercontent;
        private VerifierVerifierPage verifierVerifier;
        public verifierPage()
        {
            InitializeComponent();
            verifierHome = new verifierHomePage();
            addUserControl(verifierHome);
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void verifierP_Load(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            verifierHome = new verifierHomePage();
            addUserControl(verifierHome);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            verifiercontent = new verifierContentPage();
            addUserControl(verifiercontent);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            verifierUploader = new verifierUploaderPage();
            addUserControl(verifierUploader);
        }

       

        private void label13_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            verifierVerifier = new VerifierVerifierPage();
            addUserControl(verifierVerifier);
        }
    }
}
