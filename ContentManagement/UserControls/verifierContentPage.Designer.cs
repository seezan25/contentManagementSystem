namespace ContentManagement.UserControls
{
    partial class verifierContentPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uploadedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verifiedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sn,
            this.contentName,
            this.content,
            this.uploadedBy,
            this.verifiedBy});
            this.dataGridView1.Location = new System.Drawing.Point(415, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(541, 536);
            this.dataGridView1.TabIndex = 4;
            // 
            // sn
            // 
            this.sn.HeaderText = "S.N";
            this.sn.Name = "sn";
            // 
            // contentName
            // 
            this.contentName.HeaderText = "Content Name";
            this.contentName.Name = "contentName";
            // 
            // content
            // 
            this.content.HeaderText = "Content";
            this.content.Name = "content";
            // 
            // uploadedBy
            // 
            this.uploadedBy.HeaderText = "Uploaded By";
            this.uploadedBy.Name = "uploadedBy";
            // 
            // verifiedBy
            // 
            this.verifiedBy.HeaderText = "Verified By";
            this.verifiedBy.Name = "verifiedBy";
            // 
            // verifierContentPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(187)))));
            this.Controls.Add(this.dataGridView1);
            this.Name = "verifierContentPage";
            this.Size = new System.Drawing.Size(1370, 678);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn content;
        private System.Windows.Forms.DataGridViewTextBoxColumn uploadedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn verifiedBy;
    }
}
