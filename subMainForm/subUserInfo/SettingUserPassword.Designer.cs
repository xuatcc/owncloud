namespace custom_cloud.subMainForm.subUserInfo
{
    partial class SettingUserPassword
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
            this.label_originPassword = new System.Windows.Forms.Label();
            this.label_newPassword = new System.Windows.Forms.Label();
            this.label_confirm = new System.Windows.Forms.Label();
            this.textBox_originPassword = new System.Windows.Forms.TextBox();
            this.textBox_newPassword = new System.Windows.Forms.TextBox();
            this.textBox_confirm = new System.Windows.Forms.TextBox();
            this.button_confirm = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_originPassword
            // 
            this.label_originPassword.AutoSize = true;
            this.label_originPassword.Location = new System.Drawing.Point(36, 9);
            this.label_originPassword.Name = "label_originPassword";
            this.label_originPassword.Size = new System.Drawing.Size(47, 12);
            this.label_originPassword.TabIndex = 0;
            this.label_originPassword.Text = "旧密码:";
            // 
            // label_newPassword
            // 
            this.label_newPassword.AutoSize = true;
            this.label_newPassword.Location = new System.Drawing.Point(36, 42);
            this.label_newPassword.Name = "label_newPassword";
            this.label_newPassword.Size = new System.Drawing.Size(47, 12);
            this.label_newPassword.TabIndex = 1;
            this.label_newPassword.Text = "新密码:";
            // 
            // label_confirm
            // 
            this.label_confirm.AutoSize = true;
            this.label_confirm.Location = new System.Drawing.Point(12, 72);
            this.label_confirm.Name = "label_confirm";
            this.label_confirm.Size = new System.Drawing.Size(71, 12);
            this.label_confirm.TabIndex = 2;
            this.label_confirm.Text = "确认新密码:";
            // 
            // textBox_originPassword
            // 
            this.textBox_originPassword.Location = new System.Drawing.Point(90, 6);
            this.textBox_originPassword.Name = "textBox_originPassword";
            this.textBox_originPassword.Size = new System.Drawing.Size(182, 21);
            this.textBox_originPassword.TabIndex = 3;
            // 
            // textBox_newPassword
            // 
            this.textBox_newPassword.Location = new System.Drawing.Point(90, 39);
            this.textBox_newPassword.Name = "textBox_newPassword";
            this.textBox_newPassword.Size = new System.Drawing.Size(182, 21);
            this.textBox_newPassword.TabIndex = 4;
            // 
            // textBox_confirm
            // 
            this.textBox_confirm.Location = new System.Drawing.Point(90, 69);
            this.textBox_confirm.Name = "textBox_confirm";
            this.textBox_confirm.Size = new System.Drawing.Size(182, 21);
            this.textBox_confirm.TabIndex = 5;
            // 
            // button_confirm
            // 
            this.button_confirm.BackColor = System.Drawing.SystemColors.Control;
            this.button_confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_confirm.ForeColor = System.Drawing.Color.White;
            this.button_confirm.Image = global::custom_cloud.Properties.Resources.down;
            this.button_confirm.Location = new System.Drawing.Point(106, 96);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(80, 30);
            this.button_confirm.TabIndex = 17;
            this.button_confirm.Text = "更改";
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
            this.button_cancel.Location = new System.Drawing.Point(192, 96);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(80, 30);
            this.button_cancel.TabIndex = 18;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.btn_Click_Event);
            this.button_cancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown_Event);
            this.button_cancel.MouseEnter += new System.EventHandler(this.btn_MouseEnter_Event);
            this.button_cancel.MouseLeave += new System.EventHandler(this.btn_MouseLeave_Event);
            this.button_cancel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp_Event);
            // 
            // SettingUserPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 134);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.textBox_confirm);
            this.Controls.Add(this.textBox_newPassword);
            this.Controls.Add(this.textBox_originPassword);
            this.Controls.Add(this.label_confirm);
            this.Controls.Add(this.label_newPassword);
            this.Controls.Add(this.label_originPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingUserPassword";
            this.Text = "更改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_originPassword;
        private System.Windows.Forms.Label label_newPassword;
        private System.Windows.Forms.Label label_confirm;
        private System.Windows.Forms.TextBox textBox_originPassword;
        private System.Windows.Forms.TextBox textBox_newPassword;
        private System.Windows.Forms.TextBox textBox_confirm;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Button button_cancel;
    }
}