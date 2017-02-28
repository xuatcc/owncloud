namespace custom_cloud.loadingForm
{
    partial class LoadDisCryption
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
            this.pictureBox_wait = new System.Windows.Forms.PictureBox();
            this.label_status = new System.Windows.Forms.Label();
            this.button_cancelExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_wait)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_wait
            // 
            this.pictureBox_wait.Image = global::custom_cloud.Properties.Resources.loading_small;
            this.pictureBox_wait.Location = new System.Drawing.Point(126, 88);
            this.pictureBox_wait.Name = "pictureBox_wait";
            this.pictureBox_wait.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_wait.TabIndex = 11;
            this.pictureBox_wait.TabStop = false;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.ForeColor = System.Drawing.Color.Blue;
            this.label_status.Location = new System.Drawing.Point(88, 123);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(113, 12);
            this.label_status.TabIndex = 13;
            this.label_status.Text = "正在解密并导出文件";
            // 
            // button_cancelExport
            // 
            this.button_cancelExport.FlatAppearance.BorderSize = 0;
            this.button_cancelExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancelExport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cancelExport.ForeColor = System.Drawing.Color.White;
            this.button_cancelExport.Image = global::custom_cloud.Properties.Resources.down;
            this.button_cancelExport.Location = new System.Drawing.Point(42, 142);
            this.button_cancelExport.Name = "button_cancelExport";
            this.button_cancelExport.Size = new System.Drawing.Size(200, 30);
            this.button_cancelExport.TabIndex = 14;
            this.button_cancelExport.Text = "取消导出";
            this.button_cancelExport.UseVisualStyleBackColor = true;
            this.button_cancelExport.Click += new System.EventHandler(this.btn_Click_Event);
            this.button_cancelExport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown_Event);
            this.button_cancelExport.MouseEnter += new System.EventHandler(this.btn_MouseEnter_Event);
            this.button_cancelExport.MouseLeave += new System.EventHandler(this.btn_MouseLeave_Event);
            this.button_cancelExport.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp_Event);
            // 
            // LoadDisCryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button_cancelExport);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.pictureBox_wait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoadDisCryption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_wait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_wait;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button button_cancelExport;
    }
}