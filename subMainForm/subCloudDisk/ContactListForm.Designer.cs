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
            this.button_confirm = new System.Windows.Forms.Button();
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
            // button_confirm
            // 
            this.button_confirm.FlatAppearance.BorderSize = 0;
            this.button_confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_confirm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_confirm.ForeColor = System.Drawing.Color.White;
            this.button_confirm.Image = global::custom_cloud.Properties.Resources.down;
            this.button_confirm.Location = new System.Drawing.Point(585, 519);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(187, 30);
            this.button_confirm.TabIndex = 8;
            this.button_confirm.Text = "确定分享";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            this.button_confirm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_confirm_MouseDown);
            this.button_confirm.MouseEnter += new System.EventHandler(this.button_confirm_MouseEnter);
            this.button_confirm.MouseLeave += new System.EventHandler(this.button_confirm_MouseLeave);
            this.button_confirm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_confirm_MouseUp);
            // 
            // ContactListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.treeView_contact);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ContactListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "分享给";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_contact;
        private System.Windows.Forms.Button button_confirm;
    }
}