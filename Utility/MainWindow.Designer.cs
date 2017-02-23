﻿namespace custom_cloud
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panel_mainForm = new System.Windows.Forms.Panel();
            this.panel_title = new System.Windows.Forms.Panel();
            this.pictureBox_buttonSetting = new System.Windows.Forms.PictureBox();
            this.label_sync = new System.Windows.Forms.Label();
            this.label_share = new System.Windows.Forms.Label();
            this.label_disk = new System.Windows.Forms.Label();
            this.pictureBox_buttonNet = new System.Windows.Forms.PictureBox();
            this.pictureBox_buttonShare = new System.Windows.Forms.PictureBox();
            this.pictureBox_buttonSelectDisk = new System.Windows.Forms.PictureBox();
            this.pictureBox_buttonRecover = new System.Windows.Forms.PictureBox();
            this.label_userName = new System.Windows.Forms.Label();
            this.pictureBox_userIcon = new System.Windows.Forms.PictureBox();
            this.pictureBox_buttonMinimize = new System.Windows.Forms.PictureBox();
            this.pictureBox_buttonMaximize = new System.Windows.Forms.PictureBox();
            this.pictureBox_buttonClose = new System.Windows.Forms.PictureBox();
            this.panel_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonNet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonShare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonSelectDisk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonRecover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_userIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_mainForm
            // 
            this.panel_mainForm.Location = new System.Drawing.Point(0, 100);
            this.panel_mainForm.Name = "panel_mainForm";
            this.panel_mainForm.Size = new System.Drawing.Size(1024, 632);
            this.panel_mainForm.TabIndex = 1;
            this.panel_mainForm.Click += new System.EventHandler(this.btn_function_Click);
            // 
            // panel_title
            // 
            this.panel_title.BackgroundImage = global::custom_cloud.Properties.Resources.backgroud_blue1;
            this.panel_title.Controls.Add(this.pictureBox_buttonSetting);
            this.panel_title.Controls.Add(this.label_sync);
            this.panel_title.Controls.Add(this.label_share);
            this.panel_title.Controls.Add(this.label_disk);
            this.panel_title.Controls.Add(this.pictureBox_buttonNet);
            this.panel_title.Controls.Add(this.pictureBox_buttonShare);
            this.panel_title.Controls.Add(this.pictureBox_buttonSelectDisk);
            this.panel_title.Controls.Add(this.pictureBox_buttonRecover);
            this.panel_title.Controls.Add(this.label_userName);
            this.panel_title.Controls.Add(this.pictureBox_userIcon);
            this.panel_title.Controls.Add(this.pictureBox_buttonMinimize);
            this.panel_title.Controls.Add(this.pictureBox_buttonMaximize);
            this.panel_title.Controls.Add(this.pictureBox_buttonClose);
            this.panel_title.Location = new System.Drawing.Point(0, 0);
            this.panel_title.Name = "panel_title";
            this.panel_title.Size = new System.Drawing.Size(1024, 100);
            this.panel_title.TabIndex = 0;
            this.panel_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            this.panel_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseMove);
            // 
            // pictureBox_buttonSetting
            // 
            this.pictureBox_buttonSetting.Image = global::custom_cloud.Properties.Resources.setting_button;
            this.pictureBox_buttonSetting.Location = new System.Drawing.Point(886, 0);
            this.pictureBox_buttonSetting.Name = "pictureBox_buttonSetting";
            this.pictureBox_buttonSetting.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_buttonSetting.TabIndex = 13;
            this.pictureBox_buttonSetting.TabStop = false;
            this.pictureBox_buttonSetting.Click += new System.EventHandler(this.pictureBox_buttonSetting_Click);
            this.pictureBox_buttonSetting.MouseEnter += new System.EventHandler(this.pictureBox_buttonSetting_MouseEnter);
            this.pictureBox_buttonSetting.MouseLeave += new System.EventHandler(this.pictureBox_buttonSetting_MouseLeave);
            // 
            // label_sync
            // 
            this.label_sync.AutoSize = true;
            this.label_sync.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_sync.ForeColor = System.Drawing.Color.White;
            this.label_sync.Location = new System.Drawing.Point(458, 81);
            this.label_sync.Name = "label_sync";
            this.label_sync.Size = new System.Drawing.Size(40, 16);
            this.label_sync.TabIndex = 12;
            this.label_sync.Text = "同步";
            // 
            // label_share
            // 
            this.label_share.AutoSize = true;
            this.label_share.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_share.ForeColor = System.Drawing.Color.White;
            this.label_share.Location = new System.Drawing.Point(364, 81);
            this.label_share.Name = "label_share";
            this.label_share.Size = new System.Drawing.Size(40, 16);
            this.label_share.TabIndex = 11;
            this.label_share.Text = "分享";
            // 
            // label_disk
            // 
            this.label_disk.AutoSize = true;
            this.label_disk.BackColor = System.Drawing.Color.Blue;
            this.label_disk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_disk.ForeColor = System.Drawing.Color.White;
            this.label_disk.Location = new System.Drawing.Point(270, 81);
            this.label_disk.Name = "label_disk";
            this.label_disk.Size = new System.Drawing.Size(40, 16);
            this.label_disk.TabIndex = 10;
            this.label_disk.Text = "云盘";
            // 
            // pictureBox_buttonNet
            // 
            this.pictureBox_buttonNet.Image = global::custom_cloud.Properties.Resources.function_sync_button;
            this.pictureBox_buttonNet.Location = new System.Drawing.Point(431, 3);
            this.pictureBox_buttonNet.Name = "pictureBox_buttonNet";
            this.pictureBox_buttonNet.Size = new System.Drawing.Size(94, 94);
            this.pictureBox_buttonNet.TabIndex = 9;
            this.pictureBox_buttonNet.TabStop = false;
            this.pictureBox_buttonNet.Click += new System.EventHandler(this.btn_function_Click);
            this.pictureBox_buttonNet.MouseEnter += new System.EventHandler(this.btn_function_MouseEnter);
            this.pictureBox_buttonNet.MouseLeave += new System.EventHandler(this.btn_function_MouseLeave);
            // 
            // pictureBox_buttonShare
            // 
            this.pictureBox_buttonShare.Image = global::custom_cloud.Properties.Resources.function_share_button;
            this.pictureBox_buttonShare.Location = new System.Drawing.Point(337, 3);
            this.pictureBox_buttonShare.Name = "pictureBox_buttonShare";
            this.pictureBox_buttonShare.Size = new System.Drawing.Size(94, 94);
            this.pictureBox_buttonShare.TabIndex = 8;
            this.pictureBox_buttonShare.TabStop = false;
            this.pictureBox_buttonShare.Click += new System.EventHandler(this.btn_function_Click);
            this.pictureBox_buttonShare.MouseEnter += new System.EventHandler(this.btn_function_MouseEnter);
            this.pictureBox_buttonShare.MouseLeave += new System.EventHandler(this.btn_function_MouseLeave);
            // 
            // pictureBox_buttonSelectDisk
            // 
            this.pictureBox_buttonSelectDisk.BackColor = System.Drawing.Color.Blue;
            this.pictureBox_buttonSelectDisk.Image = global::custom_cloud.Properties.Resources.function_Disk_button;
            this.pictureBox_buttonSelectDisk.Location = new System.Drawing.Point(243, 3);
            this.pictureBox_buttonSelectDisk.Name = "pictureBox_buttonSelectDisk";
            this.pictureBox_buttonSelectDisk.Size = new System.Drawing.Size(94, 94);
            this.pictureBox_buttonSelectDisk.TabIndex = 7;
            this.pictureBox_buttonSelectDisk.TabStop = false;
            this.pictureBox_buttonSelectDisk.Click += new System.EventHandler(this.btn_function_Click);
            this.pictureBox_buttonSelectDisk.MouseEnter += new System.EventHandler(this.btn_function_MouseEnter);
            // 
            // pictureBox_buttonRecover
            // 
            this.pictureBox_buttonRecover.Image = global::custom_cloud.Properties.Resources.button_recover;
            this.pictureBox_buttonRecover.Location = new System.Drawing.Point(958, 0);
            this.pictureBox_buttonRecover.Name = "pictureBox_buttonRecover";
            this.pictureBox_buttonRecover.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_buttonRecover.TabIndex = 6;
            this.pictureBox_buttonRecover.TabStop = false;
            this.pictureBox_buttonRecover.Click += new System.EventHandler(this.btn_formRecover_Click);
            this.pictureBox_buttonRecover.MouseEnter += new System.EventHandler(this.btn_formRecover_MouseEnter);
            this.pictureBox_buttonRecover.MouseLeave += new System.EventHandler(this.btn_formRecover_MouseLeave);
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_userName.ForeColor = System.Drawing.Color.White;
            this.label_userName.Location = new System.Drawing.Point(82, 33);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(99, 20);
            this.label_userName.TabIndex = 5;
            this.label_userName.Text = "user name";
            // 
            // pictureBox_userIcon
            // 
            this.pictureBox_userIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_userIcon.Image = global::custom_cloud.Properties.Resources.user_icon;
            this.pictureBox_userIcon.Location = new System.Drawing.Point(12, 33);
            this.pictureBox_userIcon.Name = "pictureBox_userIcon";
            this.pictureBox_userIcon.Size = new System.Drawing.Size(64, 64);
            this.pictureBox_userIcon.TabIndex = 4;
            this.pictureBox_userIcon.TabStop = false;
            this.pictureBox_userIcon.MouseEnter += new System.EventHandler(this.btn_formuserIcon_MouseEnter);
            this.pictureBox_userIcon.MouseLeave += new System.EventHandler(this.btn_formuserIcon_MouseLeave);
            // 
            // pictureBox_buttonMinimize
            // 
            this.pictureBox_buttonMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_buttonMinimize.Image")));
            this.pictureBox_buttonMinimize.Location = new System.Drawing.Point(922, 0);
            this.pictureBox_buttonMinimize.Name = "pictureBox_buttonMinimize";
            this.pictureBox_buttonMinimize.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_buttonMinimize.TabIndex = 3;
            this.pictureBox_buttonMinimize.TabStop = false;
            this.pictureBox_buttonMinimize.Click += new System.EventHandler(this.btn_formMinimize_Click);
            this.pictureBox_buttonMinimize.MouseEnter += new System.EventHandler(this.btn_formMinimize_MouseEnter);
            this.pictureBox_buttonMinimize.MouseLeave += new System.EventHandler(this.btn_formMinimize_MouseLeave);
            // 
            // pictureBox_buttonMaximize
            // 
            this.pictureBox_buttonMaximize.Image = global::custom_cloud.Properties.Resources.maximize;
            this.pictureBox_buttonMaximize.Location = new System.Drawing.Point(958, 0);
            this.pictureBox_buttonMaximize.Name = "pictureBox_buttonMaximize";
            this.pictureBox_buttonMaximize.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_buttonMaximize.TabIndex = 2;
            this.pictureBox_buttonMaximize.TabStop = false;
            this.pictureBox_buttonMaximize.Click += new System.EventHandler(this.btn_formMaximize_Click);
            this.pictureBox_buttonMaximize.MouseEnter += new System.EventHandler(this.btn_formMaximize_MouseEnter);
            this.pictureBox_buttonMaximize.MouseLeave += new System.EventHandler(this.btn_formMaximize_MouseLeave);
            // 
            // pictureBox_buttonClose
            // 
            this.pictureBox_buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_buttonClose.Image")));
            this.pictureBox_buttonClose.Location = new System.Drawing.Point(994, 0);
            this.pictureBox_buttonClose.Name = "pictureBox_buttonClose";
            this.pictureBox_buttonClose.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_buttonClose.TabIndex = 1;
            this.pictureBox_buttonClose.TabStop = false;
            this.pictureBox_buttonClose.Click += new System.EventHandler(this.btn_formClose_Click);
            this.pictureBox_buttonClose.MouseEnter += new System.EventHandler(this.btn_formClose_MouseEnter);
            this.pictureBox_buttonClose.MouseLeave += new System.EventHandler(this.btn_formClose_MouseLeave);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 632);
            this.Controls.Add(this.panel_mainForm);
            this.Controls.Add(this.panel_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWindow";
            this.SizeChanged += new System.EventHandler(this.MainWindow_SizeChanged);
            this.panel_title.ResumeLayout(false);
            this.panel_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonNet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonShare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonSelectDisk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonRecover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_userIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_title;
        private System.Windows.Forms.PictureBox pictureBox_buttonClose;
        private System.Windows.Forms.PictureBox pictureBox_buttonMinimize;
        private System.Windows.Forms.PictureBox pictureBox_buttonMaximize;
        private System.Windows.Forms.PictureBox pictureBox_userIcon;
        private System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.PictureBox pictureBox_buttonRecover;
        private System.Windows.Forms.PictureBox pictureBox_buttonSelectDisk;
        private System.Windows.Forms.PictureBox pictureBox_buttonShare;
        private System.Windows.Forms.PictureBox pictureBox_buttonNet;
        private System.Windows.Forms.Label label_disk;
        private System.Windows.Forms.Label label_sync;
        private System.Windows.Forms.Label label_share;
        private System.Windows.Forms.Panel panel_mainForm;
        private System.Windows.Forms.PictureBox pictureBox_buttonSetting;
    }
}