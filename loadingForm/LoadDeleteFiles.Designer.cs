namespace custom_cloud.loadingForm
{
    partial class LoadDeleteFiles
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
            this.button_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_wait)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_wait
            // 
            this.pictureBox_wait.Image = global::custom_cloud.Properties.Resources.loading_small;
            this.pictureBox_wait.Location = new System.Drawing.Point(126, 88);
            this.pictureBox_wait.Name = "pictureBox_wait";
            this.pictureBox_wait.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_wait.TabIndex = 12;
            this.pictureBox_wait.TabStop = false;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.ForeColor = System.Drawing.Color.Blue;
            this.label_status.Location = new System.Drawing.Point(115, 123);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(53, 12);
            this.label_status.TabIndex = 14;
            this.label_status.Text = "正在删除";
            // 
            // button_cancel
            // 
            this.button_cancel.FlatAppearance.BorderSize = 0;
            this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cancel.ForeColor = System.Drawing.Color.White;
            this.button_cancel.Image = global::custom_cloud.Properties.Resources.down;
            this.button_cancel.Location = new System.Drawing.Point(42, 142);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(200, 30);
            this.button_cancel.TabIndex = 15;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.btn_Click_Event);
            this.button_cancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown_Event);
            this.button_cancel.MouseEnter += new System.EventHandler(this.btn_MouseEnter_Event);
            this.button_cancel.MouseLeave += new System.EventHandler(this.btn_MouseLeave_Event);
            this.button_cancel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp_Event);
            // 
            // LoadDeleteFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.pictureBox_wait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoadDeleteFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadDeleteFiles_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_wait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_wait;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button button_cancel;
    }
}