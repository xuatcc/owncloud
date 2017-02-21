namespace custom_cloud.subSettingForm
{
    partial class SettingSkinForm
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
            this.label_title = new System.Windows.Forms.Label();
            this.label_sub_iconSize = new System.Windows.Forms.Label();
            this.numericUpDown_iconSizeLarge = new System.Windows.Forms.NumericUpDown();
            this.label_sub_iconSize_large = new System.Windows.Forms.Label();
            this.label_iconSizeLarge_pixel = new System.Windows.Forms.Label();
            this.label_iconSizeSmall = new System.Windows.Forms.Label();
            this.numericUpDown_iconSizeSmall = new System.Windows.Forms.NumericUpDown();
            this.label_iconSizeSmall_pixel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_iconSizeLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_iconSizeSmall)).BeginInit();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(10, 10);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(35, 12);
            this.label_title.TabIndex = 1;
            this.label_title.Text = "外观:";
            // 
            // label_sub_iconSize
            // 
            this.label_sub_iconSize.AutoSize = true;
            this.label_sub_iconSize.Location = new System.Drawing.Point(100, 10);
            this.label_sub_iconSize.Name = "label_sub_iconSize";
            this.label_sub_iconSize.Size = new System.Drawing.Size(59, 12);
            this.label_sub_iconSize.TabIndex = 2;
            this.label_sub_iconSize.Text = "图标大小:";
            // 
            // numericUpDown_iconSizeLarge
            // 
            this.numericUpDown_iconSizeLarge.Location = new System.Drawing.Point(190, 28);
            this.numericUpDown_iconSizeLarge.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown_iconSizeLarge.Minimum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.numericUpDown_iconSizeLarge.Name = "numericUpDown_iconSizeLarge";
            this.numericUpDown_iconSizeLarge.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown_iconSizeLarge.TabIndex = 3;
            this.numericUpDown_iconSizeLarge.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label_sub_iconSize_large
            // 
            this.label_sub_iconSize_large.AutoSize = true;
            this.label_sub_iconSize_large.Location = new System.Drawing.Point(124, 30);
            this.label_sub_iconSize_large.Name = "label_sub_iconSize_large";
            this.label_sub_iconSize_large.Size = new System.Drawing.Size(47, 12);
            this.label_sub_iconSize_large.TabIndex = 4;
            this.label_sub_iconSize_large.Text = "大图标:";
            // 
            // label_iconSizeLarge_pixel
            // 
            this.label_iconSizeLarge_pixel.AutoSize = true;
            this.label_iconSizeLarge_pixel.Location = new System.Drawing.Point(240, 30);
            this.label_iconSizeLarge_pixel.Name = "label_iconSizeLarge_pixel";
            this.label_iconSizeLarge_pixel.Size = new System.Drawing.Size(29, 12);
            this.label_iconSizeLarge_pixel.TabIndex = 5;
            this.label_iconSizeLarge_pixel.Text = "像素";
            // 
            // label_iconSizeSmall
            // 
            this.label_iconSizeSmall.AutoSize = true;
            this.label_iconSizeSmall.Location = new System.Drawing.Point(124, 50);
            this.label_iconSizeSmall.Name = "label_iconSizeSmall";
            this.label_iconSizeSmall.Size = new System.Drawing.Size(47, 12);
            this.label_iconSizeSmall.TabIndex = 6;
            this.label_iconSizeSmall.Text = "小图标:";
            // 
            // numericUpDown_iconSizeSmall
            // 
            this.numericUpDown_iconSizeSmall.Location = new System.Drawing.Point(190, 48);
            this.numericUpDown_iconSizeSmall.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.numericUpDown_iconSizeSmall.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_iconSizeSmall.Name = "numericUpDown_iconSizeSmall";
            this.numericUpDown_iconSizeSmall.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown_iconSizeSmall.TabIndex = 7;
            this.numericUpDown_iconSizeSmall.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label_iconSizeSmall_pixel
            // 
            this.label_iconSizeSmall_pixel.AutoSize = true;
            this.label_iconSizeSmall_pixel.Location = new System.Drawing.Point(240, 50);
            this.label_iconSizeSmall_pixel.Name = "label_iconSizeSmall_pixel";
            this.label_iconSizeSmall_pixel.Size = new System.Drawing.Size(29, 12);
            this.label_iconSizeSmall_pixel.TabIndex = 8;
            this.label_iconSizeSmall_pixel.Text = "像素";
            // 
            // SettingSkinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::custom_cloud.Properties.Resources.backgroud_form;
            this.ClientSize = new System.Drawing.Size(470, 264);
            this.Controls.Add(this.label_iconSizeSmall_pixel);
            this.Controls.Add(this.numericUpDown_iconSizeSmall);
            this.Controls.Add(this.label_iconSizeSmall);
            this.Controls.Add(this.label_iconSizeLarge_pixel);
            this.Controls.Add(this.label_sub_iconSize_large);
            this.Controls.Add(this.numericUpDown_iconSizeLarge);
            this.Controls.Add(this.label_sub_iconSize);
            this.Controls.Add(this.label_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingSkinForm";
            this.Text = "SettingSkinForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_iconSizeLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_iconSizeSmall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_sub_iconSize;
        private System.Windows.Forms.NumericUpDown numericUpDown_iconSizeLarge;
        private System.Windows.Forms.Label label_sub_iconSize_large;
        private System.Windows.Forms.Label label_iconSizeLarge_pixel;
        private System.Windows.Forms.Label label_iconSizeSmall;
        private System.Windows.Forms.NumericUpDown numericUpDown_iconSizeSmall;
        private System.Windows.Forms.Label label_iconSizeSmall_pixel;
    }
}