namespace custom_cloud.loadingForm
{
    partial class LoadEncryption
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
            this.label_status = new System.Windows.Forms.Label();
            this.button_cancelImport = new System.Windows.Forms.Button();
            this.pictureBox_wait = new System.Windows.Forms.PictureBox();
            this.progressBar_main = new System.Windows.Forms.ProgressBar();
            this.label_fileStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_wait)).BeginInit();
            this.SuspendLayout();
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.ForeColor = System.Drawing.Color.Blue;
            this.label_status.Location = new System.Drawing.Point(88, 69);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(113, 12);
            this.label_status.TabIndex = 12;
            this.label_status.Text = "正在导入并加密文件";
            // 
            // button_cancelImport
            // 
            this.button_cancelImport.FlatAppearance.BorderSize = 0;
            this.button_cancelImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancelImport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cancelImport.ForeColor = System.Drawing.Color.White;
            this.button_cancelImport.Image = global::custom_cloud.Properties.Resources.down;
            this.button_cancelImport.Location = new System.Drawing.Point(42, 117);
            this.button_cancelImport.Name = "button_cancelImport";
            this.button_cancelImport.Size = new System.Drawing.Size(200, 30);
            this.button_cancelImport.TabIndex = 11;
            this.button_cancelImport.Text = "取消导入";
            this.button_cancelImport.UseVisualStyleBackColor = true;
            this.button_cancelImport.Click += new System.EventHandler(this.btn_Click_Event);
            this.button_cancelImport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown_Event);
            this.button_cancelImport.MouseEnter += new System.EventHandler(this.btn_MouseEnter_Event);
            this.button_cancelImport.MouseLeave += new System.EventHandler(this.btn_MouseLeave_Event);
            this.button_cancelImport.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp_Event);
            // 
            // pictureBox_wait
            // 
            this.pictureBox_wait.Image = global::custom_cloud.Properties.Resources.loading_small;
            this.pictureBox_wait.Location = new System.Drawing.Point(126, 34);
            this.pictureBox_wait.Name = "pictureBox_wait";
            this.pictureBox_wait.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_wait.TabIndex = 10;
            this.pictureBox_wait.TabStop = false;
            // 
            // progressBar_main
            // 
            this.progressBar_main.Location = new System.Drawing.Point(42, 88);
            this.progressBar_main.Name = "progressBar_main";
            this.progressBar_main.Size = new System.Drawing.Size(200, 23);
            this.progressBar_main.TabIndex = 13;
            // 
            // label_fileStatus
            // 
            this.label_fileStatus.AutoSize = true;
            this.label_fileStatus.Location = new System.Drawing.Point(40, 88);
            this.label_fileStatus.Name = "label_fileStatus";
            this.label_fileStatus.Size = new System.Drawing.Size(59, 12);
            this.label_fileStatus.TabIndex = 14;
            this.label_fileStatus.Text = "正在处理:";
            // 
            // LoadEncryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 177);
            this.Controls.Add(this.label_fileStatus);
            this.Controls.Add(this.progressBar_main);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.button_cancelImport);
            this.Controls.Add(this.pictureBox_wait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoadEncryption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadEncryption_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_wait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button button_cancelImport;
        private System.Windows.Forms.PictureBox pictureBox_wait;
        private System.Windows.Forms.ProgressBar progressBar_main;
        private System.Windows.Forms.Label label_fileStatus;
    }
}