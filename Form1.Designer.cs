namespace custom_cloud
{
    partial class Form_main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_file = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_import = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_import_folder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_selectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_cut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_export = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_setting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_synDir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_selectAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_setting_user_online = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_change_user = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_log_out = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog_file = new System.Windows.Forms.OpenFileDialog();
            this.treeView_explorer = new System.Windows.Forms.TreeView();
            this.listView_explorer = new System.Windows.Forms.ListView();
            this.imageList_file = new System.Windows.Forms.ImageList(this.components);
            this.imageList_tree = new System.Windows.Forms.ImageList(this.components);
            this.button_back = new System.Windows.Forms.Button();
            this.label_currentDir = new System.Windows.Forms.Label();
            this.textBox_currentDir = new System.Windows.Forms.TextBox();
            this.contextMenuStrip_listRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_right_selectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_right_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_right_cut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_right_paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_mouse_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_right_rename = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog_folder = new System.Windows.Forms.FolderBrowserDialog();
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_gotoUpBound = new System.Windows.Forms.Button();
            this.saveFileDialog_export = new System.Windows.Forms.SaveFileDialog();
            this.progressBar_transfer = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_searchKey = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.listView_search = new System.Windows.Forms.ListView();
            this.button_shut = new System.Windows.Forms.Button();
            this.button_go = new System.Windows.Forms.Button();
            this.notifyIcon_main = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_notifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_notifyIcon_showMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_notifyIcon_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_main.SuspendLayout();
            this.contextMenuStrip_listRightClick.SuspendLayout();
            this.contextMenuStrip_notifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_file,
            this.toolStripMenuItem_setting});
            resources.ApplyResources(this.menuStrip_main, "menuStrip_main");
            this.menuStrip_main.Name = "menuStrip_main";
            // 
            // toolStripMenuItem_file
            // 
            this.toolStripMenuItem_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_import,
            this.toolStripMenuItem_import_folder,
            this.toolStripMenuItem_selectAll,
            this.toolStripMenuItem_copy,
            this.toolStripMenuItem_cut,
            this.toolStripMenuItem_paste,
            this.toolStripMenuItem_delete,
            this.toolStripMenuItem_export});
            this.toolStripMenuItem_file.Name = "toolStripMenuItem_file";
            resources.ApplyResources(this.toolStripMenuItem_file, "toolStripMenuItem_file");
            // 
            // toolStripMenuItem_import
            // 
            this.toolStripMenuItem_import.Name = "toolStripMenuItem_import";
            resources.ApplyResources(this.toolStripMenuItem_import, "toolStripMenuItem_import");
            // 
            // toolStripMenuItem_import_folder
            // 
            this.toolStripMenuItem_import_folder.Name = "toolStripMenuItem_import_folder";
            resources.ApplyResources(this.toolStripMenuItem_import_folder, "toolStripMenuItem_import_folder");
            // 
            // toolStripMenuItem_selectAll
            // 
            this.toolStripMenuItem_selectAll.Name = "toolStripMenuItem_selectAll";
            resources.ApplyResources(this.toolStripMenuItem_selectAll, "toolStripMenuItem_selectAll");
            // 
            // toolStripMenuItem_copy
            // 
            this.toolStripMenuItem_copy.Name = "toolStripMenuItem_copy";
            resources.ApplyResources(this.toolStripMenuItem_copy, "toolStripMenuItem_copy");
            // 
            // toolStripMenuItem_cut
            // 
            this.toolStripMenuItem_cut.Name = "toolStripMenuItem_cut";
            resources.ApplyResources(this.toolStripMenuItem_cut, "toolStripMenuItem_cut");
            // 
            // toolStripMenuItem_paste
            // 
            this.toolStripMenuItem_paste.Name = "toolStripMenuItem_paste";
            resources.ApplyResources(this.toolStripMenuItem_paste, "toolStripMenuItem_paste");
            // 
            // toolStripMenuItem_delete
            // 
            this.toolStripMenuItem_delete.Name = "toolStripMenuItem_delete";
            resources.ApplyResources(this.toolStripMenuItem_delete, "toolStripMenuItem_delete");
            // 
            // toolStripMenuItem_export
            // 
            this.toolStripMenuItem_export.Name = "toolStripMenuItem_export";
            resources.ApplyResources(this.toolStripMenuItem_export, "toolStripMenuItem_export");
            // 
            // toolStripMenuItem_setting
            // 
            this.toolStripMenuItem_setting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_synDir,
            this.toolStripMenuItem_selectAccount});
            this.toolStripMenuItem_setting.Name = "toolStripMenuItem_setting";
            resources.ApplyResources(this.toolStripMenuItem_setting, "toolStripMenuItem_setting");
            // 
            // toolStripMenuItem_synDir
            // 
            this.toolStripMenuItem_synDir.Name = "toolStripMenuItem_synDir";
            resources.ApplyResources(this.toolStripMenuItem_synDir, "toolStripMenuItem_synDir");
            // 
            // toolStripMenuItem_selectAccount
            // 
            this.toolStripMenuItem_selectAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_setting_user_online,
            this.toolStripMenuItem_change_user,
            this.toolStripMenuItem_log_out});
            this.toolStripMenuItem_selectAccount.Name = "toolStripMenuItem_selectAccount";
            resources.ApplyResources(this.toolStripMenuItem_selectAccount, "toolStripMenuItem_selectAccount");
            // 
            // toolStripMenuItem_setting_user_online
            // 
            this.toolStripMenuItem_setting_user_online.Name = "toolStripMenuItem_setting_user_online";
            resources.ApplyResources(this.toolStripMenuItem_setting_user_online, "toolStripMenuItem_setting_user_online");
            // 
            // toolStripMenuItem_change_user
            // 
            this.toolStripMenuItem_change_user.Name = "toolStripMenuItem_change_user";
            resources.ApplyResources(this.toolStripMenuItem_change_user, "toolStripMenuItem_change_user");
            // 
            // toolStripMenuItem_log_out
            // 
            this.toolStripMenuItem_log_out.Name = "toolStripMenuItem_log_out";
            resources.ApplyResources(this.toolStripMenuItem_log_out, "toolStripMenuItem_log_out");
            // 
            // openFileDialog_file
            // 
            this.openFileDialog_file.FileName = "选择";
            this.openFileDialog_file.RestoreDirectory = true;
            // 
            // treeView_explorer
            // 
            resources.ApplyResources(this.treeView_explorer, "treeView_explorer");
            this.treeView_explorer.Name = "treeView_explorer";
            // 
            // listView_explorer
            // 
            resources.ApplyResources(this.listView_explorer, "listView_explorer");
            this.listView_explorer.Name = "listView_explorer";
            this.listView_explorer.UseCompatibleStateImageBehavior = false;
            // 
            // imageList_file
            // 
            this.imageList_file.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageList_file, "imageList_file");
            this.imageList_file.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList_tree
            // 
            this.imageList_tree.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageList_tree, "imageList_tree");
            this.imageList_tree.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // button_back
            // 
            resources.ApplyResources(this.button_back, "button_back");
            this.button_back.Name = "button_back";
            this.button_back.UseVisualStyleBackColor = true;
            // 
            // label_currentDir
            // 
            resources.ApplyResources(this.label_currentDir, "label_currentDir");
            this.label_currentDir.Name = "label_currentDir";
            // 
            // textBox_currentDir
            // 
            resources.ApplyResources(this.textBox_currentDir, "textBox_currentDir");
            this.textBox_currentDir.Name = "textBox_currentDir";
            // 
            // contextMenuStrip_listRightClick
            // 
            this.contextMenuStrip_listRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_right_selectAll,
            this.toolStripMenuItem_right_copy,
            this.toolStripMenuItem_right_cut,
            this.toolStripMenuItem_right_paste,
            this.toolStripMenuItem_mouse_delete,
            this.toolStripMenuItem_right_rename});
            this.contextMenuStrip_listRightClick.Name = "contextMenuStrip_listRightClick";
            resources.ApplyResources(this.contextMenuStrip_listRightClick, "contextMenuStrip_listRightClick");
            // 
            // toolStripMenuItem_right_selectAll
            // 
            this.toolStripMenuItem_right_selectAll.Name = "toolStripMenuItem_right_selectAll";
            resources.ApplyResources(this.toolStripMenuItem_right_selectAll, "toolStripMenuItem_right_selectAll");
            // 
            // toolStripMenuItem_right_copy
            // 
            this.toolStripMenuItem_right_copy.Name = "toolStripMenuItem_right_copy";
            resources.ApplyResources(this.toolStripMenuItem_right_copy, "toolStripMenuItem_right_copy");
            // 
            // toolStripMenuItem_right_cut
            // 
            this.toolStripMenuItem_right_cut.Name = "toolStripMenuItem_right_cut";
            resources.ApplyResources(this.toolStripMenuItem_right_cut, "toolStripMenuItem_right_cut");
            // 
            // toolStripMenuItem_right_paste
            // 
            this.toolStripMenuItem_right_paste.Name = "toolStripMenuItem_right_paste";
            resources.ApplyResources(this.toolStripMenuItem_right_paste, "toolStripMenuItem_right_paste");
            // 
            // toolStripMenuItem_mouse_delete
            // 
            this.toolStripMenuItem_mouse_delete.Name = "toolStripMenuItem_mouse_delete";
            resources.ApplyResources(this.toolStripMenuItem_mouse_delete, "toolStripMenuItem_mouse_delete");
            // 
            // toolStripMenuItem_right_rename
            // 
            this.toolStripMenuItem_right_rename.Name = "toolStripMenuItem_right_rename";
            resources.ApplyResources(this.toolStripMenuItem_right_rename, "toolStripMenuItem_right_rename");
            // 
            // button_refresh
            // 
            resources.ApplyResources(this.button_refresh, "button_refresh");
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            // 
            // button_gotoUpBound
            // 
            resources.ApplyResources(this.button_gotoUpBound, "button_gotoUpBound");
            this.button_gotoUpBound.Name = "button_gotoUpBound";
            this.button_gotoUpBound.UseVisualStyleBackColor = true;
            // 
            // progressBar_transfer
            // 
            resources.ApplyResources(this.progressBar_transfer, "progressBar_transfer");
            this.progressBar_transfer.Name = "progressBar_transfer";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBox_searchKey
            // 
            resources.ApplyResources(this.textBox_searchKey, "textBox_searchKey");
            this.textBox_searchKey.Name = "textBox_searchKey";
            // 
            // button_search
            // 
            resources.ApplyResources(this.button_search, "button_search");
            this.button_search.Name = "button_search";
            this.button_search.UseVisualStyleBackColor = true;
            // 
            // listView_search
            // 
            resources.ApplyResources(this.listView_search, "listView_search");
            this.listView_search.Name = "listView_search";
            this.listView_search.UseCompatibleStateImageBehavior = false;
            // 
            // button_shut
            // 
            resources.ApplyResources(this.button_shut, "button_shut");
            this.button_shut.Name = "button_shut";
            this.button_shut.UseVisualStyleBackColor = true;
            // 
            // button_go
            // 
            resources.ApplyResources(this.button_go, "button_go");
            this.button_go.Name = "button_go";
            this.button_go.UseVisualStyleBackColor = true;
            // 
            // notifyIcon_main
            // 
            this.notifyIcon_main.ContextMenuStrip = this.contextMenuStrip_notifyIcon;
            resources.ApplyResources(this.notifyIcon_main, "notifyIcon_main");
            // 
            // contextMenuStrip_notifyIcon
            // 
            this.contextMenuStrip_notifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_notifyIcon_showMainForm,
            this.toolStripMenuItem_notifyIcon_exit});
            this.contextMenuStrip_notifyIcon.Name = "contextMenuStrip_notifyIcon";
            resources.ApplyResources(this.contextMenuStrip_notifyIcon, "contextMenuStrip_notifyIcon");
            // 
            // toolStripMenuItem_notifyIcon_showMainForm
            // 
            this.toolStripMenuItem_notifyIcon_showMainForm.Name = "toolStripMenuItem_notifyIcon_showMainForm";
            resources.ApplyResources(this.toolStripMenuItem_notifyIcon_showMainForm, "toolStripMenuItem_notifyIcon_showMainForm");
            // 
            // toolStripMenuItem_notifyIcon_exit
            // 
            this.toolStripMenuItem_notifyIcon_exit.Name = "toolStripMenuItem_notifyIcon_exit";
            resources.ApplyResources(this.toolStripMenuItem_notifyIcon_exit, "toolStripMenuItem_notifyIcon_exit");
            // 
            // Form_main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_go);
            this.Controls.Add(this.button_shut);
            this.Controls.Add(this.listView_search);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_searchKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar_transfer);
            this.Controls.Add(this.button_gotoUpBound);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.textBox_currentDir);
            this.Controls.Add(this.label_currentDir);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.listView_explorer);
            this.Controls.Add(this.treeView_explorer);
            this.Controls.Add(this.menuStrip_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip_main;
            this.Name = "Form_main";
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.contextMenuStrip_listRightClick.ResumeLayout(false);
            this.contextMenuStrip_notifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_file;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_import;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_copy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_cut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_paste;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_delete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_setting;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_synDir;
        private System.Windows.Forms.OpenFileDialog openFileDialog_file;
        private System.Windows.Forms.TreeView treeView_explorer;
        private System.Windows.Forms.ListView listView_explorer;
        private System.Windows.Forms.ImageList imageList_file;
        private System.Windows.Forms.ImageList imageList_tree;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Label label_currentDir;
        private System.Windows.Forms.TextBox textBox_currentDir;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_listRightClick;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_mouse_delete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_right_copy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_right_cut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_right_paste;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_folder;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_import_folder;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_gotoUpBound;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_export;
        private System.Windows.Forms.ProgressBar progressBar_transfer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_selectAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_right_selectAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_right_rename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_searchKey;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.ListView listView_search;
        private System.Windows.Forms.Button button_shut;
        private System.Windows.Forms.Button button_go;
        private System.Windows.Forms.NotifyIcon notifyIcon_main;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_notifyIcon_showMainForm;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_notifyIcon_exit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_selectAccount;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_setting_user_online;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_change_user;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_log_out;
    }
}

