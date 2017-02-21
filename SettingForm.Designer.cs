namespace custom_cloud
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.panel_title = new System.Windows.Forms.Panel();
            this.panel_menu = new System.Windows.Forms.Panel();
            this.pictureBox_buttonMinimize = new System.Windows.Forms.PictureBox();
            this.pictureBox_buttonClose = new System.Windows.Forms.PictureBox();
            this.panel_menuPanel = new System.Windows.Forms.Panel();
            this.menuStrip_function = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_primary = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_transfer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_skin = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_form = new System.Windows.Forms.Panel();
            this.button_confirm = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label_error = new System.Windows.Forms.Label();
            this.panel_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonClose)).BeginInit();
            this.panel_menuPanel.SuspendLayout();
            this.menuStrip_function.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_title
            // 
            this.panel_title.BackgroundImage = global::custom_cloud.Properties.Resources.backgroud_blue;
            this.panel_title.Controls.Add(this.panel_menu);
            this.panel_title.Controls.Add(this.pictureBox_buttonMinimize);
            this.panel_title.Controls.Add(this.pictureBox_buttonClose);
            this.panel_title.Location = new System.Drawing.Point(0, 0);
            this.panel_title.Name = "panel_title";
            this.panel_title.Size = new System.Drawing.Size(600, 60);
            this.panel_title.TabIndex = 8;
            this.panel_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            this.panel_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseMove);
            // 
            // panel_menu
            // 
            this.panel_menu.Location = new System.Drawing.Point(0, 60);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(200, 100);
            this.panel_menu.TabIndex = 9;
            // 
            // pictureBox_buttonMinimize
            // 
            this.pictureBox_buttonMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_buttonMinimize.Image")));
            this.pictureBox_buttonMinimize.Location = new System.Drawing.Point(532, 0);
            this.pictureBox_buttonMinimize.Name = "pictureBox_buttonMinimize";
            this.pictureBox_buttonMinimize.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_buttonMinimize.TabIndex = 1;
            this.pictureBox_buttonMinimize.TabStop = false;
            this.pictureBox_buttonMinimize.Click += new System.EventHandler(this.btn_Click_Event);
            this.pictureBox_buttonMinimize.MouseEnter += new System.EventHandler(this.button_MouseEnterEvent);
            this.pictureBox_buttonMinimize.MouseLeave += new System.EventHandler(this.button_MouseLeaveEvent);
            // 
            // pictureBox_buttonClose
            // 
            this.pictureBox_buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_buttonClose.Image")));
            this.pictureBox_buttonClose.Location = new System.Drawing.Point(567, 0);
            this.pictureBox_buttonClose.Name = "pictureBox_buttonClose";
            this.pictureBox_buttonClose.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_buttonClose.TabIndex = 0;
            this.pictureBox_buttonClose.TabStop = false;
            this.pictureBox_buttonClose.Click += new System.EventHandler(this.btn_Click_Event);
            this.pictureBox_buttonClose.MouseEnter += new System.EventHandler(this.button_MouseEnterEvent);
            this.pictureBox_buttonClose.MouseLeave += new System.EventHandler(this.button_MouseLeaveEvent);
            // 
            // panel_menuPanel
            // 
            this.panel_menuPanel.BackgroundImage = global::custom_cloud.Properties.Resources.form_backgroud_2;
            this.panel_menuPanel.Controls.Add(this.menuStrip_function);
            this.panel_menuPanel.Location = new System.Drawing.Point(0, 60);
            this.panel_menuPanel.Name = "panel_menuPanel";
            this.panel_menuPanel.Size = new System.Drawing.Size(130, 310);
            this.panel_menuPanel.TabIndex = 9;
            // 
            // menuStrip_function
            // 
            this.menuStrip_function.BackgroundImage = global::custom_cloud.Properties.Resources.form_backgroud_2;
            this.menuStrip_function.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_primary,
            this.toolStripMenuItem_transfer,
            this.toolStripMenuItem_skin});
            this.menuStrip_function.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip_function.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_function.Name = "menuStrip_function";
            this.menuStrip_function.Size = new System.Drawing.Size(130, 115);
            this.menuStrip_function.TabIndex = 0;
            this.menuStrip_function.Text = "设置";
            // 
            // toolStripMenuItem_primary
            // 
            this.toolStripMenuItem_primary.AutoSize = false;
            this.toolStripMenuItem_primary.Name = "toolStripMenuItem_primary";
            this.toolStripMenuItem_primary.Size = new System.Drawing.Size(120, 30);
            this.toolStripMenuItem_primary.Text = "基本";
            this.toolStripMenuItem_primary.Click += new System.EventHandler(this.btn_formChoose_Event);
            // 
            // toolStripMenuItem_transfer
            // 
            this.toolStripMenuItem_transfer.AutoSize = false;
            this.toolStripMenuItem_transfer.Name = "toolStripMenuItem_transfer";
            this.toolStripMenuItem_transfer.Size = new System.Drawing.Size(120, 30);
            this.toolStripMenuItem_transfer.Text = "同步";
            this.toolStripMenuItem_transfer.Click += new System.EventHandler(this.btn_formChoose_Event);
            // 
            // toolStripMenuItem_skin
            // 
            this.toolStripMenuItem_skin.AutoSize = false;
            this.toolStripMenuItem_skin.Name = "toolStripMenuItem_skin";
            this.toolStripMenuItem_skin.Size = new System.Drawing.Size(120, 30);
            this.toolStripMenuItem_skin.Text = "外观";
            this.toolStripMenuItem_skin.Click += new System.EventHandler(this.btn_formChoose_Event);
            // 
            // panel_form
            // 
            this.panel_form.BackgroundImage = global::custom_cloud.Properties.Resources.backgroud_form;
            this.panel_form.Location = new System.Drawing.Point(130, 60);
            this.panel_form.Name = "panel_form";
            this.panel_form.Size = new System.Drawing.Size(470, 264);
            this.panel_form.TabIndex = 10;
            // 
            // button_confirm
            // 
            this.button_confirm.BackColor = System.Drawing.SystemColors.Control;
            this.button_confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_confirm.ForeColor = System.Drawing.Color.White;
            this.button_confirm.Image = global::custom_cloud.Properties.Resources.down;
            this.button_confirm.Location = new System.Drawing.Point(422, 330);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(80, 30);
            this.button_confirm.TabIndex = 11;
            this.button_confirm.Text = "确定";
            this.button_confirm.UseVisualStyleBackColor = false;
            this.button_confirm.Click += new System.EventHandler(this.btn_Click_Event);
            this.button_confirm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDownEvent);
            this.button_confirm.MouseEnter += new System.EventHandler(this.button_MouseEnterEvent);
            this.button_confirm.MouseLeave += new System.EventHandler(this.button_MouseLeaveEvent);
            this.button_confirm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUpEvent);
            // 
            // button_cancel
            // 
            this.button_cancel.BackgroundImage = global::custom_cloud.Properties.Resources.down;
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancel.ForeColor = System.Drawing.Color.White;
            this.button_cancel.Location = new System.Drawing.Point(508, 330);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(80, 30);
            this.button_cancel.TabIndex = 12;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.btn_Click_Event);
            this.button_cancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDownEvent);
            this.button_cancel.MouseEnter += new System.EventHandler(this.button_MouseEnterEvent);
            this.button_cancel.MouseLeave += new System.EventHandler(this.button_MouseLeaveEvent);
            this.button_cancel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUpEvent);
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.ForeColor = System.Drawing.Color.Red;
            this.label_error.Location = new System.Drawing.Point(136, 339);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(35, 12);
            this.label_error.TabIndex = 13;
            this.label_error.Text = "label";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::custom_cloud.Properties.Resources.backgroud_form;
            this.ClientSize = new System.Drawing.Size(600, 370);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.panel_form);
            this.Controls.Add(this.panel_menuPanel);
            this.Controls.Add(this.panel_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_function;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingForm";
            this.panel_title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonClose)).EndInit();
            this.panel_menuPanel.ResumeLayout(false);
            this.panel_menuPanel.PerformLayout();
            this.menuStrip_function.ResumeLayout(false);
            this.menuStrip_function.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_title;
        private System.Windows.Forms.PictureBox pictureBox_buttonMinimize;
        private System.Windows.Forms.PictureBox pictureBox_buttonClose;
        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.Panel panel_menuPanel;
        private System.Windows.Forms.Panel panel_form;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.MenuStrip menuStrip_function;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_primary;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_transfer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_skin;
        private System.Windows.Forms.Label label_error;
    }
}