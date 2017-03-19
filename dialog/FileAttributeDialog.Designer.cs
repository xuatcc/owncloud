namespace custom_cloud.dialog
{
    partial class FileAttributeDialog
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
            this.label_fileName = new System.Windows.Forms.Label();
            this.label_fileSize = new System.Windows.Forms.Label();
            this.label_fileCreateTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_fileName
            // 
            this.label_fileName.AutoSize = true;
            this.label_fileName.Location = new System.Drawing.Point(13, 23);
            this.label_fileName.Name = "label_fileName";
            this.label_fileName.Size = new System.Drawing.Size(41, 12);
            this.label_fileName.TabIndex = 0;
            this.label_fileName.Text = "label1";
            // 
            // label_fileSize
            // 
            this.label_fileSize.AutoSize = true;
            this.label_fileSize.Location = new System.Drawing.Point(13, 49);
            this.label_fileSize.Name = "label_fileSize";
            this.label_fileSize.Size = new System.Drawing.Size(41, 12);
            this.label_fileSize.TabIndex = 1;
            this.label_fileSize.Text = "label2";
            // 
            // label_fileCreateTime
            // 
            this.label_fileCreateTime.AutoSize = true;
            this.label_fileCreateTime.Location = new System.Drawing.Point(13, 77);
            this.label_fileCreateTime.Name = "label_fileCreateTime";
            this.label_fileCreateTime.Size = new System.Drawing.Size(41, 12);
            this.label_fileCreateTime.TabIndex = 2;
            this.label_fileCreateTime.Text = "label3";
            // 
            // FileAttributeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 139);
            this.Controls.Add(this.label_fileCreateTime);
            this.Controls.Add(this.label_fileSize);
            this.Controls.Add(this.label_fileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FileAttributeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "属性";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_fileName;
        private System.Windows.Forms.Label label_fileSize;
        private System.Windows.Forms.Label label_fileCreateTime;
    }
}