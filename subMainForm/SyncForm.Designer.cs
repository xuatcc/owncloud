namespace custom_cloud
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
            this.listView_syncStatus = new System.Windows.Forms.ListView();
            this.fileSystemWatcher_sync = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher_sync)).BeginInit();
            this.SuspendLayout();
            // 
            // listView_syncStatus
            // 
            this.listView_syncStatus.Location = new System.Drawing.Point(0, 0);
            this.listView_syncStatus.Name = "listView_syncStatus";
            this.listView_syncStatus.Size = new System.Drawing.Size(1024, 532);
            this.listView_syncStatus.TabIndex = 2;
            this.listView_syncStatus.UseCompatibleStateImageBehavior = false;
            this.listView_syncStatus.View = System.Windows.Forms.View.Details;
            // 
            // fileSystemWatcher_sync
            // 
            this.fileSystemWatcher_sync.EnableRaisingEvents = true;
            this.fileSystemWatcher_sync.Filter = "*.ssl*";
            this.fileSystemWatcher_sync.SynchronizingObject = this;
            this.fileSystemWatcher_sync.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_sync_Changed);
            this.fileSystemWatcher_sync.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_sync_Created);
            this.fileSystemWatcher_sync.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_sync_Deleted);
            this.fileSystemWatcher_sync.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher_sync_Renamed);
            // 
            // SyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::custom_cloud.Properties.Resources.white_background1;
            this.ClientSize = new System.Drawing.Size(1024, 532);
            this.Controls.Add(this.listView_syncStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SyncForm";
            this.Text = "SyncForm";
            this.SizeChanged += new System.EventHandler(this.SyncForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher_sync)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView_syncStatus;
        private System.IO.FileSystemWatcher fileSystemWatcher_sync;
    }
}