namespace custom_cloud
{
    partial class SettingSyncForm
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
            this.label_sync = new System.Windows.Forms.Label();
            this.checkBox_autoSync = new System.Windows.Forms.CheckBox();
            this.label_serverAddress = new System.Windows.Forms.Label();
            this.textBox_serverAddress = new System.Windows.Forms.TextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_sync
            // 
            this.label_sync.AutoSize = true;
            this.label_sync.Location = new System.Drawing.Point(10, 10);
            this.label_sync.Name = "label_sync";
            this.label_sync.Size = new System.Drawing.Size(35, 12);
            this.label_sync.TabIndex = 0;
            this.label_sync.Text = "同步:";
            // 
            // checkBox_autoSync
            // 
            this.checkBox_autoSync.AutoSize = true;
            this.checkBox_autoSync.Checked = true;
            this.checkBox_autoSync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_autoSync.Location = new System.Drawing.Point(100, 9);
            this.checkBox_autoSync.Name = "checkBox_autoSync";
            this.checkBox_autoSync.Size = new System.Drawing.Size(72, 16);
            this.checkBox_autoSync.TabIndex = 1;
            this.checkBox_autoSync.Text = "自动同步";
            this.checkBox_autoSync.UseVisualStyleBackColor = true;
            // 
            // label_serverAddress
            // 
            this.label_serverAddress.AutoSize = true;
            this.label_serverAddress.Location = new System.Drawing.Point(100, 40);
            this.label_serverAddress.Name = "label_serverAddress";
            this.label_serverAddress.Size = new System.Drawing.Size(71, 12);
            this.label_serverAddress.TabIndex = 2;
            this.label_serverAddress.Text = "服务器地址:";
            // 
            // textBox_serverAddress
            // 
            this.textBox_serverAddress.Location = new System.Drawing.Point(100, 56);
            this.textBox_serverAddress.Name = "textBox_serverAddress";
            this.textBox_serverAddress.Size = new System.Drawing.Size(300, 21);
            this.textBox_serverAddress.TabIndex = 3;
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(100, 90);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(35, 12);
            this.label_port.TabIndex = 4;
            this.label_port.Text = "端口:";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(100, 105);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(71, 21);
            this.textBox_port.TabIndex = 5;
            // 
            // SettingSyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::custom_cloud.Properties.Resources.backgroud_form;
            this.ClientSize = new System.Drawing.Size(470, 264);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.textBox_serverAddress);
            this.Controls.Add(this.label_serverAddress);
            this.Controls.Add(this.checkBox_autoSync);
            this.Controls.Add(this.label_sync);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingSyncForm";
            this.Text = "SettingSyncForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_sync;
        private System.Windows.Forms.CheckBox checkBox_autoSync;
        private System.Windows.Forms.Label label_serverAddress;
        private System.Windows.Forms.TextBox textBox_serverAddress;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox textBox_port;
    }
}