namespace custom_cloud
{
    partial class LoadingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
            this.pictureBox_wait = new System.Windows.Forms.PictureBox();
            this.button_cancelLogin = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_wait)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_wait
            // 
            this.pictureBox_wait.Image = global::custom_cloud.Properties.Resources.loading_small;
            this.pictureBox_wait.Location = new System.Drawing.Point(104, 10);
            this.pictureBox_wait.Name = "pictureBox_wait";
            this.pictureBox_wait.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_wait.TabIndex = 0;
            this.pictureBox_wait.TabStop = false;
            // 
            // button_cancelLogin
            // 
            this.button_cancelLogin.FlatAppearance.BorderSize = 0;
            this.button_cancelLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancelLogin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cancelLogin.ForeColor = System.Drawing.Color.White;
            this.button_cancelLogin.Image = global::custom_cloud.Properties.Resources.down;
            this.button_cancelLogin.Location = new System.Drawing.Point(20, 64);
            this.button_cancelLogin.Name = "button_cancelLogin";
            this.button_cancelLogin.Size = new System.Drawing.Size(200, 30);
            this.button_cancelLogin.TabIndex = 8;
            this.button_cancelLogin.Text = "取消登录";
            this.button_cancelLogin.UseVisualStyleBackColor = true;
            this.button_cancelLogin.Click += new System.EventHandler(this.btn_Click_Event);
            this.button_cancelLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDownEvent);
            this.button_cancelLogin.MouseEnter += new System.EventHandler(this.btn_Any_MouseEnter);
            this.button_cancelLogin.MouseLeave += new System.EventHandler(this.btn_Any_MouseLeave);
            this.button_cancelLogin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUpEvent);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.ForeColor = System.Drawing.Color.Blue;
            this.label_status.Location = new System.Drawing.Point(100, 44);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(41, 12);
            this.label_status.TabIndex = 9;
            this.label_status.Text = "登录中";
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::custom_cloud.Properties.Resources.white_background1;
            this.ClientSize = new System.Drawing.Size(240, 100);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.button_cancelLogin);
            this.Controls.Add(this.pictureBox_wait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoadingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_wait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_wait;
        private System.Windows.Forms.Button button_cancelLogin;
        private System.Windows.Forms.Label label_status;
    }
}