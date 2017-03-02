namespace custom_cloud.subMainForm
{
    partial class SettingUserInfo
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
            this.pictureBox_userIcon = new System.Windows.Forms.PictureBox();
            this.label_userName = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.label_syncPath = new System.Windows.Forms.Label();
            this.label_syncServerAddress = new System.Windows.Forms.Label();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_syncPath = new System.Windows.Forms.TextBox();
            this.textBox_syncServerAddress = new System.Windows.Forms.TextBox();
            this.button_modifyPassword = new System.Windows.Forms.Button();
            this.button_folderBrowser = new System.Windows.Forms.Button();
            this.button_confirm = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog_syncPath = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_userIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_userIcon
            // 
            this.pictureBox_userIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_userIcon.Image = global::custom_cloud.Properties.Resources.user_icon;
            this.pictureBox_userIcon.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_userIcon.Name = "pictureBox_userIcon";
            this.pictureBox_userIcon.Size = new System.Drawing.Size(64, 64);
            this.pictureBox_userIcon.TabIndex = 5;
            this.pictureBox_userIcon.TabStop = false;
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.Location = new System.Drawing.Point(12, 84);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(47, 12);
            this.label_userName.TabIndex = 6;
            this.label_userName.Text = "用户名:";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(12, 114);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(35, 12);
            this.label_password.TabIndex = 7;
            this.label_password.Text = "密码:";
            // 
            // label_syncPath
            // 
            this.label_syncPath.AutoSize = true;
            this.label_syncPath.Location = new System.Drawing.Point(12, 144);
            this.label_syncPath.Name = "label_syncPath";
            this.label_syncPath.Size = new System.Drawing.Size(83, 12);
            this.label_syncPath.TabIndex = 8;
            this.label_syncPath.Text = "本地同步目录:";
            // 
            // label_syncServerAddress
            // 
            this.label_syncServerAddress.AutoSize = true;
            this.label_syncServerAddress.Location = new System.Drawing.Point(12, 174);
            this.label_syncServerAddress.Name = "label_syncServerAddress";
            this.label_syncServerAddress.Size = new System.Drawing.Size(95, 12);
            this.label_syncServerAddress.TabIndex = 9;
            this.label_syncServerAddress.Text = "同步服务器地址:";
            // 
            // textBox_userName
            // 
            this.textBox_userName.Location = new System.Drawing.Point(110, 81);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(290, 21);
            this.textBox_userName.TabIndex = 10;
            // 
            // textBox_password
            // 
            this.textBox_password.Enabled = false;
            this.textBox_password.Location = new System.Drawing.Point(110, 111);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(290, 21);
            this.textBox_password.TabIndex = 11;
            // 
            // textBox_syncPath
            // 
            this.textBox_syncPath.Location = new System.Drawing.Point(110, 141);
            this.textBox_syncPath.Name = "textBox_syncPath";
            this.textBox_syncPath.Size = new System.Drawing.Size(290, 21);
            this.textBox_syncPath.TabIndex = 12;
            // 
            // textBox_syncServerAddress
            // 
            this.textBox_syncServerAddress.Location = new System.Drawing.Point(110, 171);
            this.textBox_syncServerAddress.Name = "textBox_syncServerAddress";
            this.textBox_syncServerAddress.Size = new System.Drawing.Size(290, 21);
            this.textBox_syncServerAddress.TabIndex = 13;
            // 
            // button_modifyPassword
            // 
            this.button_modifyPassword.Location = new System.Drawing.Point(406, 109);
            this.button_modifyPassword.Name = "button_modifyPassword";
            this.button_modifyPassword.Size = new System.Drawing.Size(60, 23);
            this.button_modifyPassword.TabIndex = 14;
            this.button_modifyPassword.Text = "更改";
            this.button_modifyPassword.UseVisualStyleBackColor = true;
            this.button_modifyPassword.Click += new System.EventHandler(this.btn_Click_Event);
            // 
            // button_folderBrowser
            // 
            this.button_folderBrowser.Location = new System.Drawing.Point(406, 139);
            this.button_folderBrowser.Name = "button_folderBrowser";
            this.button_folderBrowser.Size = new System.Drawing.Size(60, 23);
            this.button_folderBrowser.TabIndex = 15;
            this.button_folderBrowser.Text = "浏览...";
            this.button_folderBrowser.UseVisualStyleBackColor = true;
            this.button_folderBrowser.Click += new System.EventHandler(this.btn_Click_Event);
            // 
            // button_confirm
            // 
            this.button_confirm.BackColor = System.Drawing.SystemColors.Control;
            this.button_confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_confirm.ForeColor = System.Drawing.Color.White;
            this.button_confirm.Image = global::custom_cloud.Properties.Resources.down;
            this.button_confirm.Location = new System.Drawing.Point(300, 198);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(80, 30);
            this.button_confirm.TabIndex = 16;
            this.button_confirm.Text = "保存";
            this.button_confirm.UseVisualStyleBackColor = false;
            this.button_confirm.Click += new System.EventHandler(this.btn_Click_Event);
            this.button_confirm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown_Event);
            this.button_confirm.MouseEnter += new System.EventHandler(this.btn_MouseEnter_Event);
            this.button_confirm.MouseLeave += new System.EventHandler(this.btn_MouseLeave_Event);
            this.button_confirm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp_Event);
            // 
            // button_cancel
            // 
            this.button_cancel.BackgroundImage = global::custom_cloud.Properties.Resources.down;
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancel.ForeColor = System.Drawing.Color.White;
            this.button_cancel.Location = new System.Drawing.Point(386, 198);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(80, 30);
            this.button_cancel.TabIndex = 17;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.btn_Click_Event);
            this.button_cancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown_Event);
            this.button_cancel.MouseEnter += new System.EventHandler(this.btn_MouseEnter_Event);
            this.button_cancel.MouseLeave += new System.EventHandler(this.btn_MouseLeave_Event);
            this.button_cancel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp_Event);
            // 
            // SettingUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 233);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.button_folderBrowser);
            this.Controls.Add(this.button_modifyPassword);
            this.Controls.Add(this.textBox_syncServerAddress);
            this.Controls.Add(this.textBox_syncPath);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_userName);
            this.Controls.Add(this.label_syncServerAddress);
            this.Controls.Add(this.label_syncPath);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_userName);
            this.Controls.Add(this.pictureBox_userIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingUserInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个人信息";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_userIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_userIcon;
        private System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_syncPath;
        private System.Windows.Forms.Label label_syncServerAddress;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_syncPath;
        private System.Windows.Forms.TextBox textBox_syncServerAddress;
        private System.Windows.Forms.Button button_modifyPassword;
        private System.Windows.Forms.Button button_folderBrowser;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_syncPath;
    }
}