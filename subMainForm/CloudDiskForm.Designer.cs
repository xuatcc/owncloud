namespace custom_cloud
{
    partial class CloudDiskForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip_cloudDisk = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_import = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_title_importFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_export = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_share = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_newFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_title_sync = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_function = new System.Windows.Forms.Panel();
            this.pictureBox_buttonSearchItem = new System.Windows.Forms.PictureBox();
            this.label_syncStatus = new System.Windows.Forms.Label();
            this.textBox_searchKey = new System.Windows.Forms.TextBox();
            this.pictureBox_buttonRefresh = new System.Windows.Forms.PictureBox();
            this.pictureBox_buttonForward = new System.Windows.Forms.PictureBox();
            this.pictureBox_buttonBack = new System.Windows.Forms.PictureBox();
            this.panel_fileFilter = new System.Windows.Forms.Panel();
            this.treeView_directoryTree = new System.Windows.Forms.TreeView();
            this.imageList_treeView = new System.Windows.Forms.ImageList(this.components);
            this.listView_explorer = new System.Windows.Forms.ListView();
            this.imageList_large = new System.Windows.Forms.ImageList(this.components);
            this.imageList_small = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip_listRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_listContextRightClickImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listContextRightClick_importFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listContextRightClickNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listContextRightClick_paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listContextRightClickView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listContextRightClickView_largeIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listContextRightClickView_smallIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listContextRightClickView_detail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listContextRightClickRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listContextRightClickSortRule = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listContextRightClickSortRule_byName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listContextRightClickSortRule_bySize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listContextRightClickSortRule_byTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listRightClick_Item_open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listRightClick_item_export = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listRightClick_item_share = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listRightClick_item_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listRightClick_item_cut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listRightClick_item_rename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listRightClick_item_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_listRightClick_item_attribute = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog_main = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog_main = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog_main = new System.Windows.Forms.SaveFileDialog();
            this.fileSystemWatcher_main = new System.IO.FileSystemWatcher();
            this.toolTip_menuButton = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripMenuItem_listContextRightClick_selectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_treeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_treeView_open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_treeView_importItems = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_treeView_importFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_treeView_exportFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_treeView_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_cloudDisk.SuspendLayout();
            this.panel_function.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonSearchItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonForward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonBack)).BeginInit();
            this.panel_fileFilter.SuspendLayout();
            this.contextMenuStrip_listRightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher_main)).BeginInit();
            this.contextMenuStrip_treeView.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_cloudDisk
            // 
            this.menuStrip_cloudDisk.AutoSize = false;
            this.menuStrip_cloudDisk.BackgroundImage = global::custom_cloud.Properties.Resources.backgroud_form;
            this.menuStrip_cloudDisk.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.menuStrip_cloudDisk.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_import,
            this.toolStripMenuItem_title_importFolder,
            this.toolStripMenuItem_export,
            this.toolStripMenuItem_share,
            this.toolStripMenuItem_delete,
            this.toolStripMenuItem_newFolder,
            this.toolStripMenuItem_title_sync});
            this.menuStrip_cloudDisk.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_cloudDisk.Name = "menuStrip_cloudDisk";
            this.menuStrip_cloudDisk.Size = new System.Drawing.Size(1024, 30);
            this.menuStrip_cloudDisk.TabIndex = 0;
            this.menuStrip_cloudDisk.Text = "菜单";
            // 
            // toolStripMenuItem_import
            // 
            this.toolStripMenuItem_import.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripMenuItem_import.Image = global::custom_cloud.Properties.Resources.import_files;
            this.toolStripMenuItem_import.Name = "toolStripMenuItem_import";
            this.toolStripMenuItem_import.Size = new System.Drawing.Size(84, 26);
            this.toolStripMenuItem_import.Text = "导入文件";
            this.toolStripMenuItem_import.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_title_importFolder
            // 
            this.toolStripMenuItem_title_importFolder.Image = global::custom_cloud.Properties.Resources.import_folder;
            this.toolStripMenuItem_title_importFolder.Name = "toolStripMenuItem_title_importFolder";
            this.toolStripMenuItem_title_importFolder.Size = new System.Drawing.Size(96, 26);
            this.toolStripMenuItem_title_importFolder.Text = "导入文件夹";
            this.toolStripMenuItem_title_importFolder.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_export
            // 
            this.toolStripMenuItem_export.Enabled = false;
            this.toolStripMenuItem_export.Image = global::custom_cloud.Properties.Resources.export_files;
            this.toolStripMenuItem_export.Name = "toolStripMenuItem_export";
            this.toolStripMenuItem_export.Size = new System.Drawing.Size(60, 26);
            this.toolStripMenuItem_export.Text = "导出";
            this.toolStripMenuItem_export.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_share
            // 
            this.toolStripMenuItem_share.Enabled = false;
            this.toolStripMenuItem_share.Image = global::custom_cloud.Properties.Resources.menu_share;
            this.toolStripMenuItem_share.Name = "toolStripMenuItem_share";
            this.toolStripMenuItem_share.Size = new System.Drawing.Size(60, 26);
            this.toolStripMenuItem_share.Text = "分享";
            this.toolStripMenuItem_share.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_delete
            // 
            this.toolStripMenuItem_delete.Enabled = false;
            this.toolStripMenuItem_delete.Image = global::custom_cloud.Properties.Resources.menu_delete_files;
            this.toolStripMenuItem_delete.Name = "toolStripMenuItem_delete";
            this.toolStripMenuItem_delete.Size = new System.Drawing.Size(60, 26);
            this.toolStripMenuItem_delete.Text = "删除";
            this.toolStripMenuItem_delete.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_newFolder
            // 
            this.toolStripMenuItem_newFolder.Image = global::custom_cloud.Properties.Resources.menu_new_folder;
            this.toolStripMenuItem_newFolder.Name = "toolStripMenuItem_newFolder";
            this.toolStripMenuItem_newFolder.Size = new System.Drawing.Size(96, 26);
            this.toolStripMenuItem_newFolder.Text = "新建文件夹";
            this.toolStripMenuItem_newFolder.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_title_sync
            // 
            this.toolStripMenuItem_title_sync.Image = global::custom_cloud.Properties.Resources.menu_sync;
            this.toolStripMenuItem_title_sync.Name = "toolStripMenuItem_title_sync";
            this.toolStripMenuItem_title_sync.Size = new System.Drawing.Size(84, 26);
            this.toolStripMenuItem_title_sync.Text = "同步文件";
            this.toolStripMenuItem_title_sync.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // panel_function
            // 
            this.panel_function.BackgroundImage = global::custom_cloud.Properties.Resources.white_background1;
            this.panel_function.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_function.Controls.Add(this.pictureBox_buttonSearchItem);
            this.panel_function.Controls.Add(this.label_syncStatus);
            this.panel_function.Controls.Add(this.textBox_searchKey);
            this.panel_function.Controls.Add(this.pictureBox_buttonRefresh);
            this.panel_function.Controls.Add(this.pictureBox_buttonForward);
            this.panel_function.Controls.Add(this.pictureBox_buttonBack);
            this.panel_function.Location = new System.Drawing.Point(200, 30);
            this.panel_function.Name = "panel_function";
            this.panel_function.Size = new System.Drawing.Size(824, 30);
            this.panel_function.TabIndex = 1;
            // 
            // pictureBox_buttonSearchItem
            // 
            this.pictureBox_buttonSearchItem.Image = global::custom_cloud.Properties.Resources.menu_search_deep_blue;
            this.pictureBox_buttonSearchItem.Location = new System.Drawing.Point(302, 0);
            this.pictureBox_buttonSearchItem.Name = "pictureBox_buttonSearchItem";
            this.pictureBox_buttonSearchItem.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_buttonSearchItem.TabIndex = 6;
            this.pictureBox_buttonSearchItem.TabStop = false;
            this.pictureBox_buttonSearchItem.Click += new System.EventHandler(this.menuItem_Click_Event);
            this.pictureBox_buttonSearchItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown_Event);
            this.pictureBox_buttonSearchItem.MouseEnter += new System.EventHandler(this.pictureBox_buttonBack_MouseEnter);
            this.pictureBox_buttonSearchItem.MouseLeave += new System.EventHandler(this.pictureBox_buttonBack_MouseLeave);
            this.pictureBox_buttonSearchItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp_Event);
            // 
            // label_syncStatus
            // 
            this.label_syncStatus.AutoSize = true;
            this.label_syncStatus.Location = new System.Drawing.Point(338, 9);
            this.label_syncStatus.Name = "label_syncStatus";
            this.label_syncStatus.Size = new System.Drawing.Size(29, 12);
            this.label_syncStatus.TabIndex = 4;
            this.label_syncStatus.Text = "sync";
            // 
            // textBox_searchKey
            // 
            this.textBox_searchKey.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_searchKey.Location = new System.Drawing.Point(96, 0);
            this.textBox_searchKey.Name = "textBox_searchKey";
            this.textBox_searchKey.Size = new System.Drawing.Size(200, 30);
            this.textBox_searchKey.TabIndex = 5;
            // 
            // pictureBox_buttonRefresh
            // 
            this.pictureBox_buttonRefresh.Image = global::custom_cloud.Properties.Resources.refresh_deep_blue;
            this.pictureBox_buttonRefresh.Location = new System.Drawing.Point(60, 0);
            this.pictureBox_buttonRefresh.Name = "pictureBox_buttonRefresh";
            this.pictureBox_buttonRefresh.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_buttonRefresh.TabIndex = 3;
            this.pictureBox_buttonRefresh.TabStop = false;
            this.pictureBox_buttonRefresh.Click += new System.EventHandler(this.menuItem_Click_Event);
            this.pictureBox_buttonRefresh.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown_Event);
            this.pictureBox_buttonRefresh.MouseEnter += new System.EventHandler(this.pictureBox_buttonBack_MouseEnter);
            this.pictureBox_buttonRefresh.MouseLeave += new System.EventHandler(this.pictureBox_buttonBack_MouseLeave);
            this.pictureBox_buttonRefresh.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp_Event);
            // 
            // pictureBox_buttonForward
            // 
            this.pictureBox_buttonForward.Enabled = false;
            this.pictureBox_buttonForward.Image = global::custom_cloud.Properties.Resources.function_arrow_gray_forward_button;
            this.pictureBox_buttonForward.Location = new System.Drawing.Point(30, 0);
            this.pictureBox_buttonForward.Name = "pictureBox_buttonForward";
            this.pictureBox_buttonForward.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_buttonForward.TabIndex = 3;
            this.pictureBox_buttonForward.TabStop = false;
            this.pictureBox_buttonForward.Click += new System.EventHandler(this.menuItem_Click_Event);
            this.pictureBox_buttonForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown_Event);
            this.pictureBox_buttonForward.MouseEnter += new System.EventHandler(this.pictureBox_buttonBack_MouseEnter);
            this.pictureBox_buttonForward.MouseLeave += new System.EventHandler(this.pictureBox_buttonBack_MouseLeave);
            this.pictureBox_buttonForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp_Event);
            // 
            // pictureBox_buttonBack
            // 
            this.pictureBox_buttonBack.Enabled = false;
            this.pictureBox_buttonBack.Image = global::custom_cloud.Properties.Resources.function_arrow_gray_back_button;
            this.pictureBox_buttonBack.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_buttonBack.Name = "pictureBox_buttonBack";
            this.pictureBox_buttonBack.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_buttonBack.TabIndex = 2;
            this.pictureBox_buttonBack.TabStop = false;
            this.pictureBox_buttonBack.Click += new System.EventHandler(this.menuItem_Click_Event);
            this.pictureBox_buttonBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown_Event);
            this.pictureBox_buttonBack.MouseEnter += new System.EventHandler(this.pictureBox_buttonBack_MouseEnter);
            this.pictureBox_buttonBack.MouseLeave += new System.EventHandler(this.pictureBox_buttonBack_MouseLeave);
            this.pictureBox_buttonBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp_Event);
            // 
            // panel_fileFilter
            // 
            this.panel_fileFilter.BackgroundImage = global::custom_cloud.Properties.Resources.backgroud_form;
            this.panel_fileFilter.Controls.Add(this.treeView_directoryTree);
            this.panel_fileFilter.Location = new System.Drawing.Point(0, 30);
            this.panel_fileFilter.Name = "panel_fileFilter";
            this.panel_fileFilter.Size = new System.Drawing.Size(200, 502);
            this.panel_fileFilter.TabIndex = 2;
            // 
            // treeView_directoryTree
            // 
            this.treeView_directoryTree.AllowDrop = true;
            this.treeView_directoryTree.ContextMenuStrip = this.contextMenuStrip_treeView;
            this.treeView_directoryTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_directoryTree.ImageIndex = 0;
            this.treeView_directoryTree.ImageList = this.imageList_treeView;
            this.treeView_directoryTree.Location = new System.Drawing.Point(0, 0);
            this.treeView_directoryTree.Name = "treeView_directoryTree";
            this.treeView_directoryTree.SelectedImageIndex = 0;
            this.treeView_directoryTree.Size = new System.Drawing.Size(200, 502);
            this.treeView_directoryTree.TabIndex = 0;
            this.treeView_directoryTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_directoryTree_NodeMouseClick);
            // 
            // imageList_treeView
            // 
            this.imageList_treeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_treeView.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList_treeView.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listView_explorer
            // 
            this.listView_explorer.AllowColumnReorder = true;
            this.listView_explorer.AllowDrop = true;
            this.listView_explorer.BackColor = System.Drawing.Color.White;
            this.listView_explorer.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView_explorer.LabelEdit = true;
            this.listView_explorer.Location = new System.Drawing.Point(200, 60);
            this.listView_explorer.Name = "listView_explorer";
            this.listView_explorer.ShowItemToolTips = true;
            this.listView_explorer.Size = new System.Drawing.Size(824, 472);
            this.listView_explorer.TabIndex = 3;
            this.listView_explorer.UseCompatibleStateImageBehavior = false;
            this.listView_explorer.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView_explorer_AfterLabelEdit);
            this.listView_explorer.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView_explorer_BeforeLabelEdit);
            this.listView_explorer.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_explorer_ItemDrag);
            this.listView_explorer.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_explorer_ItemSelectionChanged);
            this.listView_explorer.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_explorer_DragDrop);
            this.listView_explorer.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_explorer_DragEnter);
            this.listView_explorer.DragOver += new System.Windows.Forms.DragEventHandler(this.listView_explorer_DragOver);
            this.listView_explorer.DragLeave += new System.EventHandler(this.listView_explorer_DragLeave);
            this.listView_explorer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.item_Open);
            // 
            // imageList_large
            // 
            this.imageList_large.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_large.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList_large.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList_small
            // 
            this.imageList_small.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_small.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList_small.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip_listRightClick
            // 
            this.contextMenuStrip_listRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_listContextRightClickImport,
            this.toolStripMenuItem_listContextRightClick_importFolder,
            this.toolStripMenuItem_listContextRightClickNewFolder,
            this.toolStripMenuItem_listContextRightClick_paste,
            this.toolStripMenuItem_listContextRightClickView,
            this.toolStripMenuItem_listContextRightClickRefresh,
            this.toolStripMenuItem_listContextRightClickSortRule,
            this.toolStripMenuItem_listContextRightClick_selectAll,
            this.toolStripMenuItem_listRightClick_Item_open,
            this.toolStripMenuItem_listRightClick_item_export,
            this.toolStripMenuItem_listRightClick_item_share,
            this.toolStripMenuItem_listRightClick_item_copy,
            this.toolStripMenuItem_listRightClick_item_cut,
            this.toolStripMenuItem_listRightClick_item_rename,
            this.toolStripMenuItem_listRightClick_item_delete,
            this.toolStripMenuItem_listRightClick_item_attribute});
            this.contextMenuStrip_listRightClick.Name = "contextMenuStrip_listRightClick";
            this.contextMenuStrip_listRightClick.Size = new System.Drawing.Size(137, 356);
            // 
            // toolStripMenuItem_listContextRightClickImport
            // 
            this.toolStripMenuItem_listContextRightClickImport.Image = global::custom_cloud.Properties.Resources.import_files;
            this.toolStripMenuItem_listContextRightClickImport.Name = "toolStripMenuItem_listContextRightClickImport";
            this.toolStripMenuItem_listContextRightClickImport.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listContextRightClickImport.Text = "导入文件";
            this.toolStripMenuItem_listContextRightClickImport.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listContextRightClick_importFolder
            // 
            this.toolStripMenuItem_listContextRightClick_importFolder.Image = global::custom_cloud.Properties.Resources.import_folder;
            this.toolStripMenuItem_listContextRightClick_importFolder.Name = "toolStripMenuItem_listContextRightClick_importFolder";
            this.toolStripMenuItem_listContextRightClick_importFolder.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listContextRightClick_importFolder.Text = "导入文件夹";
            this.toolStripMenuItem_listContextRightClick_importFolder.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listContextRightClickNewFolder
            // 
            this.toolStripMenuItem_listContextRightClickNewFolder.Image = global::custom_cloud.Properties.Resources.menu_new_folder;
            this.toolStripMenuItem_listContextRightClickNewFolder.Name = "toolStripMenuItem_listContextRightClickNewFolder";
            this.toolStripMenuItem_listContextRightClickNewFolder.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listContextRightClickNewFolder.Text = "新建文件夹";
            this.toolStripMenuItem_listContextRightClickNewFolder.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listContextRightClick_paste
            // 
            this.toolStripMenuItem_listContextRightClick_paste.Enabled = false;
            this.toolStripMenuItem_listContextRightClick_paste.Name = "toolStripMenuItem_listContextRightClick_paste";
            this.toolStripMenuItem_listContextRightClick_paste.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listContextRightClick_paste.Text = "粘贴";
            this.toolStripMenuItem_listContextRightClick_paste.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listContextRightClickView
            // 
            this.toolStripMenuItem_listContextRightClickView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_listContextRightClickView_largeIcon,
            this.toolStripMenuItem_listContextRightClickView_smallIcon,
            this.toolStripMenuItem_listContextRightClickView_detail});
            this.toolStripMenuItem_listContextRightClickView.Name = "toolStripMenuItem_listContextRightClickView";
            this.toolStripMenuItem_listContextRightClickView.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listContextRightClickView.Text = "查看";
            // 
            // toolStripMenuItem_listContextRightClickView_largeIcon
            // 
            this.toolStripMenuItem_listContextRightClickView_largeIcon.Name = "toolStripMenuItem_listContextRightClickView_largeIcon";
            this.toolStripMenuItem_listContextRightClickView_largeIcon.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_listContextRightClickView_largeIcon.Text = "大图标";
            this.toolStripMenuItem_listContextRightClickView_largeIcon.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listContextRightClickView_smallIcon
            // 
            this.toolStripMenuItem_listContextRightClickView_smallIcon.Name = "toolStripMenuItem_listContextRightClickView_smallIcon";
            this.toolStripMenuItem_listContextRightClickView_smallIcon.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_listContextRightClickView_smallIcon.Text = "小图标";
            this.toolStripMenuItem_listContextRightClickView_smallIcon.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listContextRightClickView_detail
            // 
            this.toolStripMenuItem_listContextRightClickView_detail.Name = "toolStripMenuItem_listContextRightClickView_detail";
            this.toolStripMenuItem_listContextRightClickView_detail.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_listContextRightClickView_detail.Text = "详细信息";
            this.toolStripMenuItem_listContextRightClickView_detail.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listContextRightClickRefresh
            // 
            this.toolStripMenuItem_listContextRightClickRefresh.Image = global::custom_cloud.Properties.Resources.refresh_deep_blue;
            this.toolStripMenuItem_listContextRightClickRefresh.Name = "toolStripMenuItem_listContextRightClickRefresh";
            this.toolStripMenuItem_listContextRightClickRefresh.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listContextRightClickRefresh.Text = "刷新";
            this.toolStripMenuItem_listContextRightClickRefresh.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listContextRightClickSortRule
            // 
            this.toolStripMenuItem_listContextRightClickSortRule.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_listContextRightClickSortRule_byName,
            this.toolStripMenuItem_listContextRightClickSortRule_bySize,
            this.toolStripMenuItem_listContextRightClickSortRule_byTime});
            this.toolStripMenuItem_listContextRightClickSortRule.Name = "toolStripMenuItem_listContextRightClickSortRule";
            this.toolStripMenuItem_listContextRightClickSortRule.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listContextRightClickSortRule.Text = "排序方式";
            // 
            // toolStripMenuItem_listContextRightClickSortRule_byName
            // 
            this.toolStripMenuItem_listContextRightClickSortRule_byName.Name = "toolStripMenuItem_listContextRightClickSortRule_byName";
            this.toolStripMenuItem_listContextRightClickSortRule_byName.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_listContextRightClickSortRule_byName.Text = "文件名";
            this.toolStripMenuItem_listContextRightClickSortRule_byName.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listContextRightClickSortRule_bySize
            // 
            this.toolStripMenuItem_listContextRightClickSortRule_bySize.Name = "toolStripMenuItem_listContextRightClickSortRule_bySize";
            this.toolStripMenuItem_listContextRightClickSortRule_bySize.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_listContextRightClickSortRule_bySize.Text = "大小";
            this.toolStripMenuItem_listContextRightClickSortRule_bySize.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listContextRightClickSortRule_byTime
            // 
            this.toolStripMenuItem_listContextRightClickSortRule_byTime.Name = "toolStripMenuItem_listContextRightClickSortRule_byTime";
            this.toolStripMenuItem_listContextRightClickSortRule_byTime.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_listContextRightClickSortRule_byTime.Text = "修改时间";
            this.toolStripMenuItem_listContextRightClickSortRule_byTime.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listRightClick_Item_open
            // 
            this.toolStripMenuItem_listRightClick_Item_open.Name = "toolStripMenuItem_listRightClick_Item_open";
            this.toolStripMenuItem_listRightClick_Item_open.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listRightClick_Item_open.Text = "打开";
            this.toolStripMenuItem_listRightClick_Item_open.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listRightClick_item_export
            // 
            this.toolStripMenuItem_listRightClick_item_export.Image = global::custom_cloud.Properties.Resources.export_files;
            this.toolStripMenuItem_listRightClick_item_export.Name = "toolStripMenuItem_listRightClick_item_export";
            this.toolStripMenuItem_listRightClick_item_export.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listRightClick_item_export.Text = "导出";
            this.toolStripMenuItem_listRightClick_item_export.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listRightClick_item_share
            // 
            this.toolStripMenuItem_listRightClick_item_share.Image = global::custom_cloud.Properties.Resources.menu_share;
            this.toolStripMenuItem_listRightClick_item_share.Name = "toolStripMenuItem_listRightClick_item_share";
            this.toolStripMenuItem_listRightClick_item_share.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listRightClick_item_share.Text = "分享";
            this.toolStripMenuItem_listRightClick_item_share.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listRightClick_item_copy
            // 
            this.toolStripMenuItem_listRightClick_item_copy.Name = "toolStripMenuItem_listRightClick_item_copy";
            this.toolStripMenuItem_listRightClick_item_copy.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listRightClick_item_copy.Text = "复制";
            this.toolStripMenuItem_listRightClick_item_copy.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listRightClick_item_cut
            // 
            this.toolStripMenuItem_listRightClick_item_cut.Name = "toolStripMenuItem_listRightClick_item_cut";
            this.toolStripMenuItem_listRightClick_item_cut.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listRightClick_item_cut.Text = "剪切";
            this.toolStripMenuItem_listRightClick_item_cut.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listRightClick_item_rename
            // 
            this.toolStripMenuItem_listRightClick_item_rename.Name = "toolStripMenuItem_listRightClick_item_rename";
            this.toolStripMenuItem_listRightClick_item_rename.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listRightClick_item_rename.Text = "重命名";
            this.toolStripMenuItem_listRightClick_item_rename.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listRightClick_item_delete
            // 
            this.toolStripMenuItem_listRightClick_item_delete.Image = global::custom_cloud.Properties.Resources.menu_delete_files;
            this.toolStripMenuItem_listRightClick_item_delete.Name = "toolStripMenuItem_listRightClick_item_delete";
            this.toolStripMenuItem_listRightClick_item_delete.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listRightClick_item_delete.Text = "删除";
            this.toolStripMenuItem_listRightClick_item_delete.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_listRightClick_item_attribute
            // 
            this.toolStripMenuItem_listRightClick_item_attribute.Name = "toolStripMenuItem_listRightClick_item_attribute";
            this.toolStripMenuItem_listRightClick_item_attribute.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listRightClick_item_attribute.Text = "属性";
            this.toolStripMenuItem_listRightClick_item_attribute.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // openFileDialog_main
            // 
            this.openFileDialog_main.Multiselect = true;
            // 
            // fileSystemWatcher_main
            // 
            this.fileSystemWatcher_main.EnableRaisingEvents = true;
            this.fileSystemWatcher_main.SynchronizingObject = this;
            this.fileSystemWatcher_main.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_main_Changed);
            // 
            // toolStripMenuItem_listContextRightClick_selectAll
            // 
            this.toolStripMenuItem_listContextRightClick_selectAll.Name = "toolStripMenuItem_listContextRightClick_selectAll";
            this.toolStripMenuItem_listContextRightClick_selectAll.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem_listContextRightClick_selectAll.Text = "全选";
            this.toolStripMenuItem_listContextRightClick_selectAll.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // contextMenuStrip_treeView
            // 
            this.contextMenuStrip_treeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_treeView_open,
            this.toolStripMenuItem_treeView_importItems,
            this.toolStripMenuItem_treeView_importFolder,
            this.toolStripMenuItem_treeView_exportFolder,
            this.toolStripMenuItem_treeView_delete});
            this.contextMenuStrip_treeView.Name = "contextMenuStrip_treeView";
            this.contextMenuStrip_treeView.Size = new System.Drawing.Size(153, 136);
            // 
            // toolStripMenuItem_treeView_open
            // 
            this.toolStripMenuItem_treeView_open.Name = "toolStripMenuItem_treeView_open";
            this.toolStripMenuItem_treeView_open.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_treeView_open.Text = "打开";
            this.toolStripMenuItem_treeView_open.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_treeView_importItems
            // 
            this.toolStripMenuItem_treeView_importItems.Name = "toolStripMenuItem_treeView_importItems";
            this.toolStripMenuItem_treeView_importItems.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_treeView_importItems.Text = "导入文件";
            this.toolStripMenuItem_treeView_importItems.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_treeView_importFolder
            // 
            this.toolStripMenuItem_treeView_importFolder.Name = "toolStripMenuItem_treeView_importFolder";
            this.toolStripMenuItem_treeView_importFolder.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_treeView_importFolder.Text = "导入文件夹";
            this.toolStripMenuItem_treeView_importFolder.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_treeView_exportFolder
            // 
            this.toolStripMenuItem_treeView_exportFolder.Name = "toolStripMenuItem_treeView_exportFolder";
            this.toolStripMenuItem_treeView_exportFolder.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_treeView_exportFolder.Text = "导出";
            this.toolStripMenuItem_treeView_exportFolder.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // toolStripMenuItem_treeView_delete
            // 
            this.toolStripMenuItem_treeView_delete.Name = "toolStripMenuItem_treeView_delete";
            this.toolStripMenuItem_treeView_delete.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_treeView_delete.Text = "删除";
            this.toolStripMenuItem_treeView_delete.Click += new System.EventHandler(this.menuItem_Click_Event);
            // 
            // CloudDiskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::custom_cloud.Properties.Resources.white_background1;
            this.ClientSize = new System.Drawing.Size(1024, 532);
            this.Controls.Add(this.listView_explorer);
            this.Controls.Add(this.panel_fileFilter);
            this.Controls.Add(this.panel_function);
            this.Controls.Add(this.menuStrip_cloudDisk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip_cloudDisk;
            this.Name = "CloudDiskForm";
            this.Text = "CloudDiskForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloudDiskForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.CloudDiskForm_SizeChanged);
            this.menuStrip_cloudDisk.ResumeLayout(false);
            this.menuStrip_cloudDisk.PerformLayout();
            this.panel_function.ResumeLayout(false);
            this.panel_function.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonSearchItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonForward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_buttonBack)).EndInit();
            this.panel_fileFilter.ResumeLayout(false);
            this.contextMenuStrip_listRightClick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher_main)).EndInit();
            this.contextMenuStrip_treeView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_cloudDisk;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_import;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_export;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_share;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_delete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_newFolder;
        private System.Windows.Forms.Panel panel_function;
        private System.Windows.Forms.PictureBox pictureBox_buttonBack;
        private System.Windows.Forms.PictureBox pictureBox_buttonForward;
        private System.Windows.Forms.PictureBox pictureBox_buttonRefresh;
        private System.Windows.Forms.Panel panel_fileFilter;
        private System.Windows.Forms.ImageList imageList_large;
        private System.Windows.Forms.ImageList imageList_small;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_listRightClick;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listContextRightClickImport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listContextRightClickNewFolder;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listContextRightClickView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listContextRightClickRefresh;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listContextRightClickSortRule;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listContextRightClickView_largeIcon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listContextRightClickView_smallIcon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listContextRightClickView_detail;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listContextRightClickSortRule_byName;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listContextRightClickSortRule_bySize;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listContextRightClickSortRule_byTime;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listRightClick_Item_open;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listRightClick_item_export;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listRightClick_item_share;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listRightClick_item_copy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listRightClick_item_cut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listRightClick_item_rename;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listRightClick_item_delete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listRightClick_item_attribute;
        private System.Windows.Forms.OpenFileDialog openFileDialog_main;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_main;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_main;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listContextRightClick_importFolder;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_title_importFolder;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listContextRightClick_paste;
        private System.IO.FileSystemWatcher fileSystemWatcher_main;
        private System.Windows.Forms.TreeView treeView_directoryTree;
        private System.Windows.Forms.ImageList imageList_treeView;
        private System.Windows.Forms.Label label_syncStatus;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_title_sync;
        private System.Windows.Forms.ToolTip toolTip_menuButton;
        private System.Windows.Forms.PictureBox pictureBox_buttonSearchItem;
        private System.Windows.Forms.TextBox textBox_searchKey;
        protected System.Windows.Forms.ListView listView_explorer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_listContextRightClick_selectAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_treeView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_treeView_open;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_treeView_importItems;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_treeView_importFolder;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_treeView_exportFolder;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_treeView_delete;
    }
}