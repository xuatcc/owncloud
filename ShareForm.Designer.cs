namespace custom_cloud
{
    partial class ShareForm
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
            this.panel_functionList = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel_functionList
            // 
            this.panel_functionList.BackgroundImage = global::custom_cloud.Properties.Resources.backgroud_gray;
            this.panel_functionList.Location = new System.Drawing.Point(0, 0);
            this.panel_functionList.Name = "panel_functionList";
            this.panel_functionList.Size = new System.Drawing.Size(64, 532);
            this.panel_functionList.TabIndex = 0;
            // 
            // ShareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::custom_cloud.Properties.Resources.white_background1;
            this.ClientSize = new System.Drawing.Size(1024, 532);
            this.Controls.Add(this.panel_functionList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShareForm";
            this.Text = "ShareForm";
            this.SizeChanged += new System.EventHandler(this.ShareForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_functionList;
    }
}