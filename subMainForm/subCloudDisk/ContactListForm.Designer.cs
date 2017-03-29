namespace custom_cloud.subMainForm.subCloudDisk
{
    partial class ContactListForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView_contact = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView_contact
            // 
            this.treeView_contact.CheckBoxes = true;
            this.treeView_contact.Location = new System.Drawing.Point(0, 0);
            this.treeView_contact.Name = "treeView_contact";
            this.treeView_contact.Size = new System.Drawing.Size(783, 511);
            this.treeView_contact.TabIndex = 0;
            this.treeView_contact.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_contact_AfterCheck);
            // 
            // ContactListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.treeView_contact);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ContactListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择分享的联系人";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_contact;
    }
}