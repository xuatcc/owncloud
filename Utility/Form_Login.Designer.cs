namespace custom_cloud
{
    partial class Form_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.comboBox_user = new System.Windows.Forms.ComboBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            this.panel_loginPanel = new System.Windows.Forms.Panel();
            this.label_errorInfo = new System.Windows.Forms.Label();
            this.button_register = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_password = new System.Windows.Forms.Panel();
            this.pictureBox_password = new System.Windows.Forms.PictureBox();
            this.panel_user = new System.Windows.Forms.Panel();
            this.pictureBox_user = new System.Windows.Forms.PictureBox();
            this.checkBox_autoLogin = new System.Windows.Forms.CheckBox();
            this.checkBox_rememberPW = new System.Windows.Forms.CheckBox();
            this.panel_title = new System.Windows.Forms.Panel();
            this.pictureBox_buttonSetting = new System.Windows.Forms.PictureBox();
            this.pictureBox_buttonMinimize = new System.Windows.Forms.PictureBox();
            this.pictureBox_buttonClose = new System.Windows.Forms.PictureBox();
            this.panel_loginPanel.SuspendLayout();
            this.panel_password.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_password)).BeginInit();
            this.panel_user.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_user)).BeginInit();
            this.panel_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonClose)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_user
            // 
            this.comboBox_user.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_user.Font = new System.Drawing.Font("宋体", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_user.FormattingEnabled = true;
            this.comboBox_user.Location = new System.Drawing.Point(36, 0);
            this.comboBox_user.Name = "comboBox_user";
            this.comboBox_user.Size = new System.Drawing.Size(214, 36);
            this.comboBox_user.TabIndex = 0;
            this.comboBox_user.SelectedIndexChanged += new System.EventHandler(this.comboBox_user_Click);
            this.comboBox_user.TextUpdate += new System.EventHandler(this.comboBox_user_Textchange);
            // 
            // textBox_password
            // 
            this.textBox_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_password.Font = new System.Drawing.Font("宋体", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_password.Location = new System.Drawing.Point(36, 0);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(214, 35);
            this.textBox_password.TabIndex = 1;
            // 
            // button_login
            // 
            this.button_login.FlatAppearance.BorderSize = 0;
            this.button_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_login.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_login.ForeColor = System.Drawing.Color.White;
            this.button_login.Image = global::custom_cloud.Properties.Resources.down;
            this.button_login.Location = new System.Drawing.Point(25, 133);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(250, 30);
            this.button_login.TabIndex = 2;
            this.button_login.Text = "登录";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDownEvent);
            this.button_login.MouseEnter += new System.EventHandler(this.btn_Any_MouseEnter);
            this.button_login.MouseLeave += new System.EventHandler(this.btn_Any_MouseLeave);
            this.button_login.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUpEvent);
            // 
            // panel_loginPanel
            // 
            this.panel_loginPanel.BackgroundImage = global::custom_cloud.Properties.Resources.form_backgroud_2;
            this.panel_loginPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_loginPanel.Controls.Add(this.label_errorInfo);
            this.panel_loginPanel.Controls.Add(this.button_register);
            this.panel_loginPanel.Controls.Add(this.label1);
            this.panel_loginPanel.Controls.Add(this.panel_password);
            this.panel_loginPanel.Controls.Add(this.panel_user);
            this.panel_loginPanel.Controls.Add(this.checkBox_autoLogin);
            this.panel_loginPanel.Controls.Add(this.checkBox_rememberPW);
            this.panel_loginPanel.Controls.Add(this.button_login);
            this.panel_loginPanel.Location = new System.Drawing.Point(293, 67);
            this.panel_loginPanel.Name = "panel_loginPanel";
            this.panel_loginPanel.Size = new System.Drawing.Size(300, 290);
            this.panel_loginPanel.TabIndex = 6;
            // 
            // label_errorInfo
            // 
            this.label_errorInfo.AutoSize = true;
            this.label_errorInfo.ForeColor = System.Drawing.Color.Red;
            this.label_errorInfo.Location = new System.Drawing.Point(23, 205);
            this.label_errorInfo.Name = "label_errorInfo";
            this.label_errorInfo.Size = new System.Drawing.Size(41, 12);
            this.label_errorInfo.TabIndex = 8;
            this.label_errorInfo.Text = "label2";
            // 
            // button_register
            // 
            this.button_register.FlatAppearance.BorderSize = 0;
            this.button_register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_register.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_register.ForeColor = System.Drawing.Color.White;
            this.button_register.Image = global::custom_cloud.Properties.Resources.down;
            this.button_register.Location = new System.Drawing.Point(88, 169);
            this.button_register.Name = "button_register";
            this.button_register.Size = new System.Drawing.Size(187, 30);
            this.button_register.TabIndex = 7;
            this.button_register.Text = "注册账号";
            this.button_register.UseVisualStyleBackColor = true;
            this.button_register.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDownEvent);
            this.button_register.MouseEnter += new System.EventHandler(this.btn_Any_MouseEnter);
            this.button_register.MouseLeave += new System.EventHandler(this.btn_Any_MouseLeave);
            this.button_register.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUpEvent);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "没有账号?";
            // 
            // panel_password
            // 
            this.panel_password.BackColor = System.Drawing.Color.White;
            this.panel_password.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_password.BackgroundImage")));
            this.panel_password.Controls.Add(this.pictureBox_password);
            this.panel_password.Controls.Add(this.textBox_password);
            this.panel_password.Location = new System.Drawing.Point(25, 71);
            this.panel_password.Name = "panel_password";
            this.panel_password.Size = new System.Drawing.Size(250, 36);
            this.panel_password.TabIndex = 5;
            // 
            // pictureBox_password
            // 
            this.pictureBox_password.Image = global::custom_cloud.Properties.Resources._lock;
            this.pictureBox_password.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_password.Name = "pictureBox_password";
            this.pictureBox_password.Size = new System.Drawing.Size(36, 36);
            this.pictureBox_password.TabIndex = 1;
            this.pictureBox_password.TabStop = false;
            // 
            // panel_user
            // 
            this.panel_user.BackColor = System.Drawing.Color.White;
            this.panel_user.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_user.BackgroundImage")));
            this.panel_user.Controls.Add(this.pictureBox_user);
            this.panel_user.Controls.Add(this.comboBox_user);
            this.panel_user.Location = new System.Drawing.Point(25, 29);
            this.panel_user.Name = "panel_user";
            this.panel_user.Size = new System.Drawing.Size(250, 36);
            this.panel_user.TabIndex = 4;
            // 
            // pictureBox_user
            // 
            this.pictureBox_user.Image = global::custom_cloud.Properties.Resources.user_icon1;
            this.pictureBox_user.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_user.Name = "pictureBox_user";
            this.pictureBox_user.Size = new System.Drawing.Size(36, 36);
            this.pictureBox_user.TabIndex = 1;
            this.pictureBox_user.TabStop = false;
            // 
            // checkBox_autoLogin
            // 
            this.checkBox_autoLogin.AutoSize = true;
            this.checkBox_autoLogin.ForeColor = System.Drawing.SystemColors.GrayText;
            this.checkBox_autoLogin.Location = new System.Drawing.Point(132, 110);
            this.checkBox_autoLogin.Name = "checkBox_autoLogin";
            this.checkBox_autoLogin.Size = new System.Drawing.Size(72, 16);
            this.checkBox_autoLogin.TabIndex = 3;
            this.checkBox_autoLogin.Text = "自动登录";
            this.checkBox_autoLogin.UseVisualStyleBackColor = true;
            // 
            // checkBox_rememberPW
            // 
            this.checkBox_rememberPW.AutoSize = true;
            this.checkBox_rememberPW.ForeColor = System.Drawing.SystemColors.GrayText;
            this.checkBox_rememberPW.Location = new System.Drawing.Point(25, 110);
            this.checkBox_rememberPW.Name = "checkBox_rememberPW";
            this.checkBox_rememberPW.Size = new System.Drawing.Size(72, 16);
            this.checkBox_rememberPW.TabIndex = 2;
            this.checkBox_rememberPW.Text = "记住密码";
            this.checkBox_rememberPW.UseVisualStyleBackColor = true;
            // 
            // panel_title
            // 
            this.panel_title.BackgroundImage = global::custom_cloud.Properties.Resources.backgroud_blue;
            this.panel_title.Controls.Add(this.pictureBox_buttonSetting);
            this.panel_title.Controls.Add(this.pictureBox_buttonMinimize);
            this.panel_title.Controls.Add(this.pictureBox_buttonClose);
            this.panel_title.Location = new System.Drawing.Point(0, 0);
            this.panel_title.Name = "panel_title";
            this.panel_title.Size = new System.Drawing.Size(600, 61);
            this.panel_title.TabIndex = 7;
            this.panel_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            this.panel_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseMove);
            // 
            // pictureBox_buttonSetting
            // 
            this.pictureBox_buttonSetting.Image = global::custom_cloud.Properties.Resources.setting_button;
            this.pictureBox_buttonSetting.Location = new System.Drawing.Point(507, 0);
            this.pictureBox_buttonSetting.Name = "pictureBox_buttonSetting";
            this.pictureBox_buttonSetting.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_buttonSetting.TabIndex = 14;
            this.pictureBox_buttonSetting.TabStop = false;
            this.pictureBox_buttonSetting.Click += new System.EventHandler(this.btn_settingForm_Click);
            this.pictureBox_buttonSetting.MouseEnter += new System.EventHandler(this.btn_Any_MouseEnter);
            this.pictureBox_buttonSetting.MouseLeave += new System.EventHandler(this.btn_Any_MouseLeave);
            // 
            // pictureBox_buttonMinimize
            // 
            this.pictureBox_buttonMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_buttonMinimize.Image")));
            this.pictureBox_buttonMinimize.Location = new System.Drawing.Point(537, 0);
            this.pictureBox_buttonMinimize.Name = "pictureBox_buttonMinimize";
            this.pictureBox_buttonMinimize.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_buttonMinimize.TabIndex = 1;
            this.pictureBox_buttonMinimize.TabStop = false;
            this.pictureBox_buttonMinimize.Click += new System.EventHandler(this.btn_formMinimize_Click);
            this.pictureBox_buttonMinimize.MouseEnter += new System.EventHandler(this.btn_Any_MouseEnter);
            this.pictureBox_buttonMinimize.MouseLeave += new System.EventHandler(this.btn_Any_MouseLeave);
            // 
            // pictureBox_buttonClose
            // 
            this.pictureBox_buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_buttonClose.Image")));
            this.pictureBox_buttonClose.Location = new System.Drawing.Point(567, 0);
            this.pictureBox_buttonClose.Name = "pictureBox_buttonClose";
            this.pictureBox_buttonClose.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_buttonClose.TabIndex = 0;
            this.pictureBox_buttonClose.TabStop = false;
            this.pictureBox_buttonClose.MouseEnter += new System.EventHandler(this.btn_Any_MouseEnter);
            this.pictureBox_buttonClose.MouseLeave += new System.EventHandler(this.btn_Any_MouseLeave);
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::custom_cloud.Properties.Resources.sub_backgroud;
            this.ClientSize = new System.Drawing.Size(600, 370);
            this.Controls.Add(this.panel_title);
            this.Controls.Add(this.panel_loginPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Login_KeyDown);
            this.panel_loginPanel.ResumeLayout(false);
            this.panel_loginPanel.PerformLayout();
            this.panel_password.ResumeLayout(false);
            this.panel_password.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_password)).EndInit();
            this.panel_user.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_user)).EndInit();
            this.panel_title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_user;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Panel panel_loginPanel;
        private System.Windows.Forms.CheckBox checkBox_rememberPW;
        private System.Windows.Forms.Panel panel_title;
        private System.Windows.Forms.CheckBox checkBox_autoLogin;
        private System.Windows.Forms.PictureBox pictureBox_buttonClose;
        private System.Windows.Forms.PictureBox pictureBox_buttonMinimize;
        private System.Windows.Forms.Panel panel_user;
        private System.Windows.Forms.PictureBox pictureBox_user;
        private System.Windows.Forms.Panel panel_password;
        private System.Windows.Forms.PictureBox pictureBox_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_register;
        private System.Windows.Forms.PictureBox pictureBox_buttonSetting;
        private System.Windows.Forms.Label label_errorInfo;
    }
}