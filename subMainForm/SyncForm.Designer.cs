﻿namespace custom_cloud
{
    partial class SyncForm
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
            this.panel_functionList = new System.Windows.Forms.Panel();
            this.listView_syncStatus = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // panel_functionList
            // 
            this.panel_functionList.BackgroundImage = global::custom_cloud.Properties.Resources.backgroud_gray;
            this.panel_functionList.Location = new System.Drawing.Point(0, 0);
            this.panel_functionList.Name = "panel_functionList";
            this.panel_functionList.Size = new System.Drawing.Size(1024, 64);
            this.panel_functionList.TabIndex = 1;
            // 
            // listView_syncStatus
            // 
            this.listView_syncStatus.Location = new System.Drawing.Point(0, 64);
            this.listView_syncStatus.Name = "listView_syncStatus";
            this.listView_syncStatus.Size = new System.Drawing.Size(1024, 468);
            this.listView_syncStatus.TabIndex = 2;
            this.listView_syncStatus.UseCompatibleStateImageBehavior = false;
            this.listView_syncStatus.View = System.Windows.Forms.View.Details;
            // 
            // SyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::custom_cloud.Properties.Resources.white_background1;
            this.ClientSize = new System.Drawing.Size(1024, 532);
            this.Controls.Add(this.listView_syncStatus);
            this.Controls.Add(this.panel_functionList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SyncForm";
            this.Text = "SyncForm";
            this.SizeChanged += new System.EventHandler(this.SyncForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_functionList;
        private System.Windows.Forms.ListView listView_syncStatus;
    }
}