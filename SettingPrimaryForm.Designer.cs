namespace custom_cloud
{
    partial class SettingPrimaryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_autoStart = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "基本:";
            // 
            // checkBox_autoStart
            // 
            this.checkBox_autoStart.AutoSize = true;
            this.checkBox_autoStart.Location = new System.Drawing.Point(100, 9);
            this.checkBox_autoStart.Name = "checkBox_autoStart";
            this.checkBox_autoStart.Size = new System.Drawing.Size(108, 16);
            this.checkBox_autoStart.TabIndex = 1;
            this.checkBox_autoStart.Text = "开机时自动启动";
            this.checkBox_autoStart.UseVisualStyleBackColor = true;
            // 
            // SettingPrimaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::custom_cloud.Properties.Resources.backgroud_form;
            this.ClientSize = new System.Drawing.Size(470, 264);
            this.Controls.Add(this.checkBox_autoStart);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingPrimaryForm";
            this.Text = "SettingPrimaryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_autoStart;
    }
}