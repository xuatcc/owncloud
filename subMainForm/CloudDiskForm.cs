/*
    *@by Benquicki
    *@in XJTU
    *@in 2017.2
*/
using custom_cloud.cmdClass;
using custom_cloud.dialog;
using custom_cloud.IOClass;
using custom_cloud.loadingForm;
using custom_cloud.subMainForm.subCloudDisk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace custom_cloud
{
    public partial class CloudDiskForm : Form
    {
        /// <summary>
        /// 文件树
        /// </summary>
        public FileTree File_Tree;
        /// <summary>
        /// 文件搜索树，用于显示符合搜索条件的文件
        /// </summary>
        public FileTree SearchTree;
        
        
        /// <summary>
        /// 当前目录
        /// </summary>
        string CurrentPath;
        /// <summary>
        /// 用户信息
        /// </summary>
        UserInfo User_Info = new UserInfo();
        /// <summary>
        /// 用户本地信息
        /// </summary>
        UserLocalInfo User_LocalInfo = new UserLocalInfo();
        /// <summary>
        /// 获取当前工作目录，设置该变量时还可以刷新窗体的控件
        /// </summary>
        public string Current_Path
        {
            get
            {
                return CurrentPath;
            }
            set
            {
                CurrentPath = value;
                //initializeConfig();
                initializeWidget();
            }
        }
        /// <summary>
        /// 当前加密文件存放根目录
        /// </summary>
        //string SyncPathEcryption;
        /// <summary>
        /// 获取或设置当前路径栈
        /// </summary>
        public Stack<string> BackStack
        {
            get
            {
                return StackBackDirectory;
            }
            set
            {
                StackBackDirectory = value;
                if (StackBackDirectory.Count > 0)
                {
                    pictureBox_buttonBack.Enabled = true;
                    pictureBox_buttonBack.Image = Properties.Resources.arrow_back_deep_blue;
                }
            }
        }
        /// <summary>
        /// 获取或设置前进栈
        /// </summary>
        public Stack<string> ForwardStack
        {
            get
            {
                return StackForwardDirectory;
            }
            set
            {
                StackForwardDirectory = value;
                if (StackForwardDirectory.Count > 0)
                {
                    pictureBox_buttonForward.Enabled = true;
                    pictureBox_buttonForward.Image = Properties.Resources.arrow_forward_deep_blue;
                }
            }
        }
        /// <summary>
        /// 后退目录栈
        /// </summary>
        Stack<string> StackBackDirectory = new Stack<string>();
        /// <summary>
        /// 前进目录栈
        /// </summary>
        Stack<string> StackForwardDirectory = new Stack<string>();
        /// <summary>
        /// 复制文件原地址队列
        /// </summary>
        Queue<string> QueueCopyDirectory = new Queue<string>();
        /// <summary>
        /// 复制文件属性队列
        /// </summary>
        Queue<string> QueueCopyAttribute = new Queue<string>();
        /// <summary>
        /// 判断执行的是剪切还是复制
        /// </summary>
        bool CutTrue_CopyFalse = false;
        /// <summary>
        /// 辅助重命名，用于记录项目的旧名称
        /// </summary>
        string itemOldName = "";
        /// <summary>
        /// 文件图标字典
        /// </summary>
        Dictionary<string, Image> LargeIconDict = new Dictionary<string, Image>();
        Dictionary<string, Image> SmallIconDict = new Dictionary<string, Image>();
        Image LargeFolderIcon = Image.FromFile(MyConfig.LARGE_FOLDER_ICON_PATH);
        Image SmallFolderIcon = Image.FromFile(MyConfig.SMALL_FOLDER_ICON_PATH);
        Image LargeDefaultFileIcon = Image.FromFile(MyConfig.LARGE_DEFAULT_FILE_ICON_PATH);
        Image SmallDefaultFileIcon = Image.FromFile(MyConfig.SMALL_DEFAULT_FILE_ICON_PATH);
        /// <summary>
        /// 排序规则
        /// </summary>
        MyConfig.SortRule Sort_Rule;
        ListViewItemComparerByName LVIC_BN = new ListViewItemComparerByName();
        ListViewItemComparerByTime LVIC_BT = new ListViewItemComparerByTime();
        ListViewItemComparerBySize LVIC_BS = new ListViewItemComparerBySize();
        /// <summary>
        /// 文件视图
        /// </summary>
        View FileView;
        /// <summary>
        /// 同步目录
        /// </summary>
        public string SyncPath;
        /// <summary>
        /// 删除问询界面
        /// </summary>
        DeleteFileDialog deleteFileDialog = new DeleteFileDialog();
        /// <summary>
        /// 文件属性界面
        /// </summary>
        FileAttributeDialog fileAttributeDialog = new FileAttributeDialog();
        public TreeView Tree_View
        {
            get { return treeView_directoryTree; }
            set { treeView_directoryTree = value; }
        }
        /// <summary>
        /// 指向父窗体的指针
        /// </summary>
        MainWindow mainWindow;
        /// <summary>
        /// 指向同步窗体的指针
        /// </summary>
        //SyncForm syncForm;
        public CloudDiskForm(MainWindow mw, SyncForm sf)
        {
            InitializeComponent();
            mainWindow = mw;
            //syncForm = sf;
            //testFileTree();
        }
        public void setUserInfo(UserInfo userInfo)
        {
            User_Info = userInfo;
            User_LocalInfo = MyConfig.getUserLocalInfo(userInfo.UserID);
            SyncPath = User_LocalInfo.SyncPath;
            initializeConfig();
            initializeWidget();
        }
        void initializeConfig()
        {
            MyConfig.ConfigFile configFile = MyConfig.readConfig();
            /* 加载文件图标配置 */
            LargeIconDict = MyConfig.getLargeFileIconDictionary();
            SmallIconDict = MyConfig.getSmallFileIconDictionary();
            /* 加载图标大小配置 */
            int largeIconSize = 100;
            int smallIconSize = 16;
            if (configFile.TableSkin.ContainsKey(MyConfig.ConfigFile.Skin.KEY_LARGE_ICON_SIZE)) largeIconSize = 
                    int.Parse(configFile.TableSkin[MyConfig.ConfigFile.Skin.KEY_LARGE_ICON_SIZE].ToString());
            if (configFile.TableSkin.ContainsKey(MyConfig.ConfigFile.Skin.KEY_SMALL_ICON_SIZE)) smallIconSize = 
                    int.Parse(configFile.TableSkin[MyConfig.ConfigFile.Skin.KEY_SMALL_ICON_SIZE].ToString());
            /* 设置图标 */
            imageList_large.ImageSize = new Size(largeIconSize, largeIconSize);
            imageList_small.ImageSize = new Size(smallIconSize, smallIconSize);
            imageList_treeView.ImageSize = new Size(smallIconSize, smallIconSize);

            /* 加载文件显示视图 */
            if (configFile.TableSkin.ContainsKey(MyConfig.ConfigFile.Skin.KEY_FILE_VIEW)) FileView = 
                    (View)int.Parse(configFile.TableSkin[MyConfig.ConfigFile.Skin.KEY_FILE_VIEW].ToString());

            /* 加载排序方式 */
            if (configFile.TableSkin.ContainsKey(MyConfig.ConfigFile.Skin.KEY_FILE_SORT_RULE))
                Sort_Rule = (MyConfig.SortRule)int.Parse(configFile.TableSkin[MyConfig.ConfigFile.Skin.KEY_FILE_SORT_RULE].ToString());
            /* 加载用户本地信息 */
            /* 测试 */
            /*
                User_Info = new UserInfo();
                User_Info.UserID = "Doge";
                User_LocalInfo = MyConfig.getUserLocalInfo(User_Info.UserID);
                SyncPath = User_LocalInfo.SyncPath;
             */
            /* 进入同步目录 */
            File_Tree = new FileTree(SyncPath);
            CurrentPath = File_Tree.RootDirectory.FullName;
            fileSystemWatcher_main.Path = SyncPath;
        }
        void initializeWidget()
        {
            
            panel_function.Parent = this;
            panel_function.BackColor = Color.Transparent;
            /* 按钮设置 */
            pictureBox_buttonBack.Parent = panel_function;
            pictureBox_buttonForward.Parent = panel_function;
            pictureBox_buttonRefresh.Parent = panel_function;

            pictureBox_buttonBack.BackColor = Color.Transparent;
            pictureBox_buttonForward.BackColor = Color.Transparent;
            pictureBox_buttonRefresh.BackColor = Color.Transparent;

            /* 测试部分 */
            //Sort_Rule = MyConfig.SortRule.ByName;
            //FileView = View.LargeIcon;
            //FileView = View.Tile;
            /* 文件显示视图 */
            setViewMode();
            listView_explorer.ContextMenuStrip = contextMenuStrip_listRightClick;

            //checkTreeNodeExpandStatus(File_Tree, treeView_directoryTree.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName)]);
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
            //updateDirectoryTree();

            /* 测试部分 */
            /*
                User_Info.UserID = "Doge";
                User_Info.Password = "xjtu2017";
                User_LocalInfo.SyncPath = SyncPath;
                User_Info.ServerURI = "http://192.168.204.130/helo";
                */
            label_syncStatus.Text = "正在尝试同步";
            /* 测试部分 */
            updateDirectoryTree();
            /* 选项菜单不可见 */
            setVisibleOfItemRightClickMenu(false);
            listView_explorer.LargeImageList = imageList_large;
            listView_explorer.SmallImageList = imageList_small;
            updateSorterPath();
            updateSortRule();
            sortBySortRule();
            listView_explorer.LabelEdit = true;
            listView_explorer.AllowDrop = true;
            //listView_explorer.InsertionMark.Color = Color.Blue;

            /* set tool tip */
            toolTip_menuButton.SetToolTip(pictureBox_buttonBack, "后退");
            toolTip_menuButton.SetToolTip(pictureBox_buttonForward, "前进");
            toolTip_menuButton.SetToolTip(pictureBox_buttonRefresh, "刷新");
            toolTip_menuButton.SetToolTip(pictureBox_buttonSearchItem, "搜索 文件/文件夹");

            
        }
        /// <summary>
        /// 设置显示模式
        /// </summary>
        void setViewMode()
        {
            switch (FileView)
            {
                case View.LargeIcon:
                    toolStripMenuItem_listContextRightClickView_detail.Checked = false;
                    toolStripMenuItem_listContextRightClickView_largeIcon.Checked = true;
                    toolStripMenuItem_listContextRightClickView_smallIcon.Checked = false;
                    break;
                case View.SmallIcon:
                    toolStripMenuItem_listContextRightClickView_detail.Checked = false;
                    toolStripMenuItem_listContextRightClickView_largeIcon.Checked = false;
                    toolStripMenuItem_listContextRightClickView_smallIcon.Checked = true;
                    break;
                case View.List:
                    toolStripMenuItem_listContextRightClickView_detail.Checked = true;
                    toolStripMenuItem_listContextRightClickView_largeIcon.Checked = false;
                    toolStripMenuItem_listContextRightClickView_smallIcon.Checked = false;
                    break;
            }
        }
        /// <summary>
        /// 保存本窗体特有的配置
        /// </summary>
        void saveConfig()
        {
            MyConfig.ConfigFile configFile = MyConfig.readConfig();
            configFile.createOrModifyItem(MyConfig.ConfigFile.TABLE_NAME_SKIN, 
                MyConfig.ConfigFile.Skin.KEY_FILE_VIEW, FileView);
            MyConfig.saveConfig(configFile);
        }
        /// <summary>
        /// 修改显示模式
        /// </summary>
        /// <param name="obj"></param>
        void modifyViewMode(object obj)
        {
            if (obj.Equals(toolStripMenuItem_listContextRightClickView_largeIcon))
            {
                toolStripMenuItem_listContextRightClickView_detail.Checked = false;
                toolStripMenuItem_listContextRightClickView_largeIcon.Checked = true;
                toolStripMenuItem_listContextRightClickView_smallIcon.Checked = false;
                FileView = View.LargeIcon;
                setViewMode();
            }
            if (obj.Equals(toolStripMenuItem_listContextRightClickView_smallIcon))
            {
                toolStripMenuItem_listContextRightClickView_detail.Checked = false;
                toolStripMenuItem_listContextRightClickView_largeIcon.Checked = false;
                toolStripMenuItem_listContextRightClickView_smallIcon.Checked = true;
                FileView = View.SmallIcon;
                setViewMode();
            }
            if (obj.Equals(toolStripMenuItem_listContextRightClickView_detail))
            {
                toolStripMenuItem_listContextRightClickView_detail.Checked = true;
                toolStripMenuItem_listContextRightClickView_largeIcon.Checked = false;
                toolStripMenuItem_listContextRightClickView_smallIcon.Checked = false;
                FileView = View.List;
                setViewMode();
            }
            saveConfig();

            //checkTreeNodeExpandStatus(File_Tree, treeView_directoryTree.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName)]);
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
            //updateDirectoryTree();
        }

        private void pictureBox_buttonBack_MouseEnter(object sender, EventArgs e)
        {
            if (sender.Equals(pictureBox_buttonBack))
            {
                if (!pictureBox_buttonBack.Enabled) return;
                pictureBox_buttonBack.Image = Properties.Resources.arrow_back_blue;
            }
            if (sender.Equals(pictureBox_buttonForward))
            {
                if (!pictureBox_buttonForward.Enabled) return;
                pictureBox_buttonForward.Image = Properties.Resources.arrow_forward_blue;
            }
            if (sender.Equals(pictureBox_buttonRefresh)) pictureBox_buttonRefresh.Image = Properties.Resources.refresh_blue;
            if (sender.Equals(pictureBox_buttonSearchItem)) pictureBox_buttonSearchItem.Image = Properties.Resources.menu_search_blue;
        }

        private void pictureBox_buttonBack_MouseLeave(object sender, EventArgs e)
        {
            if (sender.Equals(pictureBox_buttonBack))
            {
                if (!pictureBox_buttonBack.Enabled) return;
                pictureBox_buttonBack.Image = Properties.Resources.arrow_back_deep_blue;
            }
            if (sender.Equals(pictureBox_buttonForward))
            {
                if (!pictureBox_buttonForward.Enabled) return;
                pictureBox_buttonForward.Image = Properties.Resources.arrow_forward_deep_blue;
            }
            if (sender.Equals(pictureBox_buttonRefresh)) pictureBox_buttonRefresh.Image = Properties.Resources.refresh_deep_blue;
            if (sender.Equals(pictureBox_buttonSearchItem)) pictureBox_buttonSearchItem.Image = Properties.Resources.menu_search_deep_blue;
        }
        void pictureBox_MouseDown_Event(object sender, MouseEventArgs ea)
        {
            if (sender.Equals(pictureBox_buttonRefresh)) pictureBox_buttonRefresh.Image = Properties.Resources.refresh_deep_blue;
            if (sender.Equals(pictureBox_buttonSearchItem)) pictureBox_buttonSearchItem.Image = Properties.Resources.menu_search_deep_blue;
            if (sender.Equals(pictureBox_buttonBack))
            {
                if (!pictureBox_buttonBack.Enabled) return;
                pictureBox_buttonBack.Image = Properties.Resources.arrow_back_deep_blue;
            }
            if (sender.Equals(pictureBox_buttonForward))
            {
                if (!pictureBox_buttonForward.Enabled) return;
                pictureBox_buttonForward.Image = Properties.Resources.arrow_forward_deep_blue;
            }
        }
        void pictureBox_MouseUp_Event(object sender, MouseEventArgs ea)
        {
            if (sender.Equals(pictureBox_buttonRefresh)) pictureBox_buttonRefresh.Image = Properties.Resources.refresh_blue;
            if (sender.Equals(pictureBox_buttonSearchItem)) pictureBox_buttonSearchItem.Image = Properties.Resources.menu_search_blue;
            if (sender.Equals(pictureBox_buttonBack))
            {
                if (!pictureBox_buttonBack.Enabled) return;
                pictureBox_buttonBack.Image = Properties.Resources.arrow_back_blue;
            }
            if (sender.Equals(pictureBox_buttonForward))
            {
                if (!pictureBox_buttonForward.Enabled) return;
                pictureBox_buttonForward.Image = Properties.Resources.arrow_forward_blue;
            }
        }
        private void CloudDiskForm_SizeChanged(object sender, EventArgs e)
        {
            panel_function.Width = this.Width - panel_fileFilter.Width;
            listView_explorer.Width = this.Width - panel_fileFilter.Width;
            listView_explorer.Height = this.Height - menuStrip_cloudDisk.Height - panel_function.Height;
            
            panel_fileFilter.Height = listView_explorer.Height + panel_function.Height;
            treeView_directoryTree.Height = listView_explorer.Height + panel_function.Height;

            //textBox_searchKey.SetBounds(textBox_directoryInfo.Location.X + textBox_directoryInfo.Width + 8, textBox_searchKey.Location.Y, textBox_searchKey.Width, textBox_searchKey.Height);

        }
        /// <summary>
        /// 向listview里添加项目
        /// </summary>
        void updateListViewItems(View view, FileTree fileTree, MyConfig.SortRule sortRule)
        {
            if (fileTree == null) return;
            /* 设置显示方式 */
            listView_explorer.Items.Clear();
            listView_explorer.View = view;
            //listView_explorer.ListViewItemSorter = null;
            /* 加载图标列表 */
            imageList_large.Images.Clear();
            imageList_small.Images.Clear();

            //checkTreeNodeExpandStatus(File_Tree, treeView_directoryTree.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName)]);
            updateListViewItems(fileTree);
            updateDirectoryTree();

            
        }
        /// <summary>
        /// 向listview里添加项目，但不更新文件树
        /// </summary>
        void updateListViewItemsWithoutTreeUpdate(View view, FileTree fileTree, MyConfig.SortRule sortRule)
        {
            if (fileTree == null) return;
            /* 设置显示方式 */
            listView_explorer.Items.Clear();
            listView_explorer.View = view;
            //listView_explorer.ListViewItemSorter = null;
            /* 加载图标列表 */
            imageList_large.Images.Clear();
            imageList_small.Images.Clear();

            //checkTreeNodeExpandStatus(File_Tree, treeView_directoryTree.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName)]);
            updateListViewItems(fileTree);
            //updateDirectoryTree();
        }
        void updateListViewItems(FileTree fileTree)
        {
            /* 按名字排序 */
            //listView_explorer.ListViewItemSorter = new ListViewItemComparerByName();
           
            var temp = listView_explorer;
            var temp2 = imageList_large;
            //listView_explorer.ListViewItemSorter = new ListViewItemComparerByName();
            foreach(FileTree file_tree in fileTree.SubTree.Values)
            {
                string directoryPath = file_tree.RootDirectory.FullName;
                imageList_large.Images.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, directoryPath), 
                    Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, LargeFolderIcon));
                imageList_small.Images.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, directoryPath), 
                    Int32Dec64Convert.ConverToSquareBitmap(imageList_small.ImageSize.Width, SmallFolderIcon));
                listView_explorer.Items.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, directoryPath), file_tree.RootDirectory.Name, MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, directoryPath));
                //listView_explorer.Items[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, file_tree.RootDirectory.Name)].Name = 
                    //FileTree.FOLDER_IDENTIFY_NAME;
                
            }
            /* 手动排序 */
            //listView_explorer.Sort();
            foreach (FileTree.TreeFileInfo treeFileInfo in fileTree.CurrentDirectoryFileList.Values)
            {
                string fileName = treeFileInfo.FilePath;
                /* 大图标注意判断文件是否为图片 */
                if (CodeAnalysis.IsImage(treeFileInfo.FilePath))
                {
                    Image image = Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, Image.FromFile(treeFileInfo.FilePath));
                    imageList_large.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), image);
                }
                else if (LargeIconDict.ContainsKey(treeFileInfo.ExtendName)) imageList_large.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, LargeIconDict[treeFileInfo.ExtendName]));
                else imageList_large.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, LargeDefaultFileIcon));

                if (SmallIconDict.ContainsKey(treeFileInfo.ExtendName)) imageList_small.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), Int32Dec64Convert.ConverToSquareBitmap(imageList_small.ImageSize.Width, SmallIconDict[treeFileInfo.ExtendName]));
                else imageList_small.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), Int32Dec64Convert.ConverToSquareBitmap(imageList_small.ImageSize.Width, SmallDefaultFileIcon));

                listView_explorer.Items.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), treeFileInfo.FileName, MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName));
                //listView_explorer.Items[MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName)].Name = FileTree.FILE_IDENTIFY_NAME;
            }
            //listView_explorer.AllowDrop = true;
            /* 更改当前目录 */
            textBox_directoryInfo.Text = "Home:" + CurrentPath.Substring(Path.GetFullPath(SyncPath).Length);
            /* 刷新文件同步列表 */
            //if (syncForm != null) syncForm.refreshFileList(SyncPath, SyncPath);
        }
        /// <summary>
        /// 按名字排序接口
        /// </summary>
        public class ListViewItemComparerByName : IComparer
        {
            public string CurrentPath;
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                /* 分4种情况 */
                ListViewItem lvi_1 = (ListViewItem)x;
                ListViewItem lvi_2 = (ListViewItem)y;

                if (lvi_1.Name.Contains(FileTree.FILE_IDENTIFY_NAME) && lvi_2.Name.Contains(FileTree.FILE_IDENTIFY_NAME))
                {
                    if (!File.Exists(CurrentPath + "/" + lvi_1.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE)) return -1;
                    if (!File.Exists(CurrentPath + "/" + lvi_2.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE)) return -1;
                    returnVal = string.Compare(lvi_1.Text, lvi_2.Text);
                }
                else if (lvi_1.Name.Contains(FileTree.FOLDER_IDENTIFY_NAME) && lvi_2.Name.Contains(FileTree.FILE_IDENTIFY_NAME))
                {
                    if (!Directory.Exists(CurrentPath + "/" + lvi_1.Text)) return -1;
                    if (!File.Exists(CurrentPath + "/" + lvi_2.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE)) return -1;
                    returnVal = -1;
                }
                else if (lvi_1.Name.Contains(FileTree.FILE_IDENTIFY_NAME) && lvi_2.Name.Contains(FileTree.FOLDER_IDENTIFY_NAME))
                {
                    if (!File.Exists(CurrentPath + "/" + lvi_1.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE)) return -1;
                    if (!Directory.Exists(CurrentPath + "/" + lvi_2.Text)) return -1;
                    returnVal = 1;
                }
                else if (lvi_1.Name.Contains(FileTree.FOLDER_IDENTIFY_NAME) && lvi_2.Name.Contains(FileTree.FOLDER_IDENTIFY_NAME))
                {
                    if (!Directory.Exists(CurrentPath + "/" + lvi_1.Text)) return -1;
                    if (!Directory.Exists(CurrentPath + "/" + lvi_2.Text)) return -1;
                    returnVal = string.Compare(lvi_1.Text, lvi_2.Text);
                }
                return returnVal;
            }
        }
        /// <summary>
        /// 按时间排序接口
        /// </summary>
        public class ListViewItemComparerByTime : IComparer
        {
            public string CurrentPath;
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                /* 分4种情况 */
                ListViewItem lvi_1 = (ListViewItem)x;
                ListViewItem lvi_2 = (ListViewItem)y;
                
                if(lvi_1.Name.Contains(FileTree.FILE_IDENTIFY_NAME) && lvi_2.Name.Contains(FileTree.FILE_IDENTIFY_NAME))
                {
                    if (!File.Exists(CurrentPath + "/" + lvi_1.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE)) return -1;
                    if (!File.Exists(CurrentPath + "/" + lvi_2.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE)) return -1;
                    FileTree.TreeFileInfo tfi_1 = new FileTree.TreeFileInfo(CurrentPath + "/" + lvi_1.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE);
                    FileTree.TreeFileInfo tfi_2 = new FileTree.TreeFileInfo(CurrentPath + "/" + lvi_2.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE);
                    returnVal = -(int)(tfi_1.ModifyTime - tfi_2.ModifyTime);
                }
                else if (lvi_1.Name.Contains(FileTree.FOLDER_IDENTIFY_NAME) && lvi_2.Name.Contains(FileTree.FILE_IDENTIFY_NAME))
                {
                    if (!Directory.Exists(CurrentPath + "/" + lvi_1.Text)) return -1;
                    if (!File.Exists(CurrentPath + "/" + lvi_2.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE)) return -1;
                    FileTree ft_1 = new FileTree(CurrentPath + "/" + lvi_1.Text);
                    FileTree.TreeFileInfo tfi_2 = new FileTree.TreeFileInfo(CurrentPath + "/" + lvi_2.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE);
                    returnVal = -(int)(ft_1.ModifyTime + MyConfig.RefFutureTimeDouble - tfi_2.ModifyTime);
                }
                else if (lvi_1.Name.Contains(FileTree.FILE_IDENTIFY_NAME) && lvi_2.Name.Contains(FileTree.FOLDER_IDENTIFY_NAME))
                {
                    if (!File.Exists(CurrentPath + "/" + lvi_1.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE)) return -1;
                    if (!Directory.Exists(CurrentPath + "/" + lvi_2.Text)) return -1;
                    FileTree.TreeFileInfo tfi_1 = new FileTree.TreeFileInfo(CurrentPath + "/" + lvi_1.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE);
                    FileTree ft_2 = new FileTree(CurrentPath + "/" + lvi_2.Text);
                    returnVal = -(int)(tfi_1.ModifyTime - (ft_2.ModifyTime + MyConfig.RefFutureTimeDouble));
                }
                else if (lvi_1.Name.Contains(FileTree.FOLDER_IDENTIFY_NAME) && lvi_2.Name.Contains(FileTree.FOLDER_IDENTIFY_NAME))
                {
                    if (!Directory.Exists(CurrentPath + "/" + lvi_1.Text)) return -1;
                    if (!Directory.Exists(CurrentPath + "/" + lvi_2.Text)) return -1;
                    FileTree ft_1 = new FileTree(CurrentPath + "/" + lvi_1.Text);
                    FileTree ft_2 = new FileTree(CurrentPath + "/" + lvi_2.Text);
                    returnVal = -(int)(ft_1.ModifyTime - ft_2.ModifyTime);
                }
                return returnVal;
            }
        }
        /// <summary>
        /// 按大小排序接口
        /// </summary>
        public class ListViewItemComparerBySize : IComparer
        {
            public string CurrentPath;
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                /* 分4种情况 */
                ListViewItem lvi_1 = (ListViewItem)x;
                ListViewItem lvi_2 = (ListViewItem)y;

                if (lvi_1.Name.Contains(FileTree.FILE_IDENTIFY_NAME) && lvi_2.Name.Contains(FileTree.FILE_IDENTIFY_NAME))
                {
                    if (!File.Exists(CurrentPath + "/" + lvi_1.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE)) return -1;
                    if (!File.Exists(CurrentPath + "/" + lvi_2.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE)) return -1;
                    FileTree.TreeFileInfo tfi_1 = new FileTree.TreeFileInfo(CurrentPath + "/" + lvi_1.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE);
                    FileTree.TreeFileInfo tfi_2 = new FileTree.TreeFileInfo(CurrentPath + "/" + lvi_2.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE);
                    returnVal = tfi_1.Fileinfo.Length > tfi_2.Fileinfo.Length ? -1 : 1;
                }
                else if (lvi_1.Name.Contains(FileTree.FOLDER_IDENTIFY_NAME) && lvi_2.Name.Contains(FileTree.FILE_IDENTIFY_NAME))
                {
                    if (!Directory.Exists(CurrentPath + "/" + lvi_1.Text)) return -1;
                    if (!File.Exists(CurrentPath + "/" + lvi_2.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE)) return -1;
                    //FileTree ft_1 = new FileTree(CurrentPath + "/" + lvi_1.Text);
                    //FileTree.TreeFileInfo tfi_2 = new FileTree.TreeFileInfo(CurrentPath + "/" + lvi_2.Text);
                    returnVal = -1;
                }
                else if (lvi_1.Name.Contains(FileTree.FILE_IDENTIFY_NAME) && lvi_2.Name.Contains(FileTree.FOLDER_IDENTIFY_NAME))
                {
                    if (!File.Exists(CurrentPath + "/" + lvi_1.Text + MyConfig.EXTEND_NAME_ENCRYP_FILE)) return -1;
                    if (!Directory.Exists(CurrentPath + "/" + lvi_2.Text)) return -1;
                    //FileTree.TreeFileInfo tfi_1 = new FileTree.TreeFileInfo(CurrentPath + "/" + lvi_1.Text);
                    //FileTree ft_2 = new FileTree(CurrentPath + "/" + lvi_2.Text);
                    returnVal = 1;
                }
                else if (lvi_1.Name.Contains(FileTree.FOLDER_IDENTIFY_NAME) && lvi_2.Name.Contains(FileTree.FOLDER_IDENTIFY_NAME))
                {
                    if (!Directory.Exists(CurrentPath + "/" + lvi_1.Text)) return -1;
                    if (!Directory.Exists(CurrentPath + "/" + lvi_2.Text)) return -1;
                    FileTree ft_1 = new FileTree(CurrentPath + "/" + lvi_1.Text);
                    FileTree ft_2 = new FileTree(CurrentPath + "/" + lvi_2.Text);
                    returnVal = ft_1.getByteLength() > ft_2.getByteLength() ? -1 : 1;
                }
                return returnVal;
            }
        }
        /// <summary>
        /// 向listView里添加新项目
        /// </summary>
        /// <param name="text">项目路径</param>
        /// <param name="name">属性，区别添加的是文件还是文件夹</param>
        void addItemToListView(string path, string name)
        {
            string text = Path.GetFileName(path);
            //listView_explorer.Items.Add(text);
            //int index = listView_explorer.Items.Count - 1;
            //listView_explorer.Items[index].Name = name;
            string extendName = Path.GetExtension(text);
            if (name.Contains(FileTree.FILE_IDENTIFY_NAME))
            {
                /* 大图标注意判断文件是否为图片 */
                if (CodeAnalysis.IsImage(path))
                {
                    Image image = Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, Image.FromFile(path));
                    imageList_large.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, text), image);
                }
                else if (LargeIconDict.ContainsKey(extendName)) imageList_large.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, text), Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, LargeIconDict[extendName]));
                else imageList_large.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, text), Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, LargeDefaultFileIcon));

                if (SmallIconDict.ContainsKey(extendName)) imageList_small.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, text), Int32Dec64Convert.ConverToSquareBitmap(imageList_small.ImageSize.Width, SmallIconDict[extendName]));
                else imageList_small.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, text), Int32Dec64Convert.ConverToSquareBitmap(imageList_small.ImageSize.Width, SmallDefaultFileIcon));
                //listView_explorer.Items[MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, text), ].ImageIndex = index;
                listView_explorer.Items.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, text), text, MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, text));
                //listView_explorer.Items[MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, text)].Name = name;
                Application.DoEvents();
                listView_explorer.Items[MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, text)].Selected = true;
            }
            else if (name.Contains(FileTree.FOLDER_IDENTIFY_NAME))
            {
                imageList_large.Images.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, text), Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, LargeFolderIcon));
                imageList_small.Images.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, text), Int32Dec64Convert.ConverToSquareBitmap(imageList_small.ImageSize.Width, SmallFolderIcon));
                //listView_explorer.Items[index].ImageIndex = index;
                listView_explorer.Items.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, text), text, MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, text));
                //listView_explorer.Items[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, text)].Name = name;
                listView_explorer.Items[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, text)].Selected = true;
            }
        }
        /// <summary>
        /// 改动某个项目
        /// </summary>
        /// <param name="index"></param>
        void modifyListViewItems(int index, string filePath)
        {
            if (index < 0) return;
            if (index >= listView_explorer.Items.Count) return;
            string extendName = Path.GetExtension(filePath);
            string name = listView_explorer.Items[index].Name;
            /* 如果是文件 */
            if (name.Contains(FileTree.FILE_IDENTIFY_NAME))
            {
                /* 大图标注意判断文件是否为图片 */
                if (CodeAnalysis.IsImage(filePath))
                {
                    Image image = Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, Image.FromFile(filePath));
                    imageList_large.Images.Add(image);
                }
                else if (LargeIconDict.ContainsKey(extendName)) imageList_large.Images[index] = (Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, LargeIconDict[extendName]));
                else imageList_large.Images[index] = (Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, LargeDefaultFileIcon));

                if (SmallIconDict.ContainsKey(extendName)) imageList_small.Images[index] = (Int32Dec64Convert.ConverToSquareBitmap(imageList_small.ImageSize.Width, SmallIconDict[extendName]));
                else imageList_small.Images[index] = (Int32Dec64Convert.ConverToSquareBitmap(imageList_small.ImageSize.Width, SmallDefaultFileIcon));
            }
            /* 如果是文件夹 */
            else if (name.Contains(FileTree.FOLDER_IDENTIFY_NAME))
            {
                imageList_large.Images[index] = (Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, LargeFolderIcon));
                imageList_small.Images[index] = (Int32Dec64Convert.ConverToSquareBitmap(imageList_small.ImageSize.Width, SmallFolderIcon));
            }
            /* 刷新文件同步列表 */
            //if (syncForm != null) syncForm.refreshFileList(SyncPath, SyncPath);
        }
        /// <summary>
        /// 文件树测试
        /// </summary>
        void testFileTree(object obj, EventArgs ea)
        {
            
            //File_Tree.updateTree("./icon/");
            var temp = File_Tree;
        }
        /// <summary>
        /// 设置一部分菜单项是否可见
        /// </summary>
        /// <param name="visible"></param>
        void setVisibleOfRightClickMenu(bool visible)
        {
            toolStripMenuItem_listContextRightClickImport.Visible = visible;
            toolStripMenuItem_listContextRightClickNewFolder.Visible = visible;
            toolStripMenuItem_listContextRightClickRefresh.Visible = visible;
            toolStripMenuItem_listContextRightClickSortRule.Visible = visible;
            toolStripMenuItem_listContextRightClickView.Visible = visible;
            toolStripMenuItem_listContextRightClick_importFolder.Visible = visible;
            toolStripMenuItem_listContextRightClick_paste.Visible = visible;
            toolStripMenuItem_listContextRightClick_selectAll.Visible = visible;
        }
        void setVisibleOfItemRightClickMenu(bool visible)
        {
            toolStripMenuItem_listRightClick_Item_open.Visible = visible;
            //toolStripMenuItem_listRightClick_item_openMethod.Visible = visible;
            toolStripMenuItem_listRightClick_item_copy.Visible = visible;
            toolStripMenuItem_listRightClick_item_cut.Visible = visible;
            toolStripMenuItem_listRightClick_item_delete.Visible = visible;
            toolStripMenuItem_listRightClick_itemExportDiscryption.Visible = visible;
            toolStripMenuItem_listRightClick_item_rename.Visible = visible;
            toolStripMenuItem_listRightClick_item_share.Visible = visible;
            toolStripMenuItem_listRightClick_item_attribute.Visible=visible;
            //toolStripMenuItem_listContextRightClick_openMethod.Visible = visible;

            toolStripMenuItem_share.Enabled = visible;
            toolStripMenuItem_delete.Enabled = visible;
            toolStripMenuItem_export.Enabled = visible;
        }
        /// <summary>
        /// 选中项目发生改变时的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_explorer_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView_explorer.SelectedItems.Count > 0)
            {
                setVisibleOfRightClickMenu(false);
                setVisibleOfItemRightClickMenu(true);
                if (listView_explorer.SelectedItems.Count > 1)
                {
                    toolStripMenuItem_listRightClick_Item_open.Visible = false;
                    //toolStripMenuItem_listRightClick_item_openMethod.Visible = false;
                    toolStripMenuItem_listRightClick_item_attribute.Visible = false;
                    //toolStripMenuItem_listContextRightClick_openMethod.Visible = false;
                    toolStripMenuItem_listRightClick_item_rename.Visible = false;
                }
                /* 如果选中项目是一个文件夹，那么不能够选择打开方式 */
                /*
                else if (listView_explorer.SelectedItems.Count == 1 && 
                    listView_explorer.SelectedItems[0].name.Contains(FileTree.FOLDER_IDENTIFY_NAME))
                {
                    //toolStripMenuItem_listContextRightClick_openMethod.Visible = false;
                }
                */
            }
            else
            {
                setVisibleOfItemRightClickMenu(false);
                setVisibleOfRightClickMenu(true);
            }
        }
        /// <summary>
        /// 菜单项目点击事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void menuItem_Click_Event(object obj, EventArgs ea)
        {
            /* 上方功能框 */
            if (obj.Equals(toolStripMenuItem_import)) item_Import();
            if (obj.Equals(toolStripMenuItem_title_importFolder)) item_ImportFolder();
            if (obj.Equals(toolStripMenuItem_title_itemExportDiscryption)) item_ExportFiles();
            if (obj.Equals(toolStripMenuItem_title_itemExportWithoutDiscryption)) item_ExportFilesWithoutDiscryption();
            if (obj.Equals(toolStripMenuItem_delete)) item_Delete();
            if (obj.Equals(toolStripMenuItem_newFolder)) list_NewFolder();
            if (obj.Equals(pictureBox_buttonRefresh)) list_Refresh();
            if (obj.Equals(pictureBox_buttonBack)) list_Back();
            if (obj.Equals(pictureBox_buttonForward)) list_Forward();
            if (obj.Equals(toolStripMenuItem_title_sync))
            {
                mainWindow.ThreadSync = new Thread(mainWindow.threadSync);
                mainWindow.ThreadSync.Start();
            }
            if (obj.Equals(pictureBox_buttonSearchItem)) items_Search();
            if (obj.Equals(toolStripMenuItem_share)) items_share();

            /* Context功能 */
            if (obj.Equals(toolStripMenuItem_listContextRightClickImport)) item_Import();
            if (obj.Equals(toolStripMenuItem_listContextRightClickNewFolder)) list_NewFolder();
            if (obj.Equals(toolStripMenuItem_listContextRightClickRefresh)) list_Refresh();
            if (obj.Equals(toolStripMenuItem_listRightClick_item_delete)) item_Delete();
            if (obj.Equals(toolStripMenuItem_listRightClick_itemExportDiscryption)) item_ExportFiles();
            if (obj.Equals(toolStripMenuItem_listRightClick_itemExportWithoutDiscryption)) item_ExportFilesWithoutDiscryption();
            if (obj.Equals(toolStripMenuItem_listContextRightClick_importFolder)) item_ImportFolder();
            if (obj.Equals(toolStripMenuItem_listRightClick_Item_open)) item_Open(null, null);
            //if (obj.Equals(toolStripMenuItem_listContextRightClick_openMethod)) item_openMethod();
            if (obj.Equals(toolStripMenuItem_listContextRightClick_paste)) items_Paste();
            if (obj.Equals(toolStripMenuItem_listRightClick_item_copy)) items_Copy();
            if (obj.Equals(toolStripMenuItem_listRightClick_item_cut)) items_Cut();
            if (obj.Equals(toolStripMenuItem_listRightClick_item_rename)) item_Rename();
            if (obj.Equals(toolStripMenuItem_listContextRightClickSortRule_byName)) list_Sort(obj);
            if (obj.Equals(toolStripMenuItem_listContextRightClickSortRule_bySize)) list_Sort(obj);
            if (obj.Equals(toolStripMenuItem_listContextRightClickSortRule_byTime)) list_Sort(obj);
            if (obj.Equals(toolStripMenuItem_listRightClick_item_attribute)) item_ShowAttribute();
            if (obj.Equals(toolStripMenuItem_listContextRightClick_selectAll)) list_SelectAll();

            if (obj.Equals(toolStripMenuItem_listContextRightClickView_largeIcon))
                modifyViewMode(toolStripMenuItem_listContextRightClickView_largeIcon);
            if (obj.Equals(toolStripMenuItem_listContextRightClickView_smallIcon))
                modifyViewMode(toolStripMenuItem_listContextRightClickView_smallIcon);
            if (obj.Equals(toolStripMenuItem_listContextRightClickView_detail))
                modifyViewMode(toolStripMenuItem_listContextRightClickView_detail);
            if (obj.Equals(toolStripMenuItem_listRightClick_item_share)) items_share();

            /* treeview context */
            if (obj.Equals(toolStripMenuItem_treeView_open)) treeView_Open();
            if (obj.Equals(toolStripMenuItem_treeView_importItems)) treeView_importFiles();
            if (obj.Equals(toolStripMenuItem_treeView_importFolder)) treeView_ImportFolder();
            if (obj.Equals(toolStripMenuItem_treeView_exportFolder)) treeView_ExportFolder();
            if (obj.Equals(toolStripMenuItem_treeView_delete)) treeView_DeleteFolder();
            if (obj.Equals(toolStripMenuItem_treeView_newFolder)) treeView_newFolder();
        }
        /* 各种详细事件 */
        /// <summary>
        /// 导入文件
        /// </summary>
        void item_Import()
        {
            if (openFileDialog_main.ShowDialog() == DialogResult.OK)
            {
                string[] fileNames = openFileDialog_main.FileNames;

                LoadEncryption loadEncryption = new LoadEncryption();
                loadEncryption.importItem(fileNames, CurrentPath);
                loadEncryption.ShowDialog();

                
                //更新文件树
                updateFileTree();
                updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
                
                //while (newFileNames.Count > 0) addItemToListView(newFileNames.Dequeue(), FileTree.FILE_IDENTIFY_NAME);
                //updateListViewItems(FileView, File_Tree, Sort_Rule);
            }
        }
        /// <summary>
        /// 导入文件夹
        /// </summary>
        void item_ImportFolder()
        {
            if (folderBrowserDialog_main.ShowDialog() == DialogResult.OK)
            {
                LoadEncryption loadEncryption = new LoadEncryption();
                //loadEncryption.Show();
                loadEncryption.importFolder(folderBrowserDialog_main.SelectedPath,
                    CurrentPath + "/" + Path.GetFileName(folderBrowserDialog_main.SelectedPath));
                loadEncryption.ShowDialog();
                //更新文件树
                updateFileTree();
                updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
                //addItemToListView(newFolderName, FileTree.FOLDER_IDENTIFY_NAME);

                updateDirectoryTree();
                /* 启动同步 */
            }
        }
        /// <summary>
        /// 导出文件（夹）
        /// </summary>
        void item_ExportFiles()
        {
            if (folderBrowserDialog_main.ShowDialog() == DialogResult.OK)
            {
                Queue<string> fileNames = new Queue<string>();
                Queue<string> keyNames = new Queue<string>();
                string destination = folderBrowserDialog_main.SelectedPath;
                for(int i = 0; i < listView_explorer.SelectedItems.Count; i++)
                {
                    fileNames.Enqueue(MyConfig.getPathByKey(listView_explorer.SelectedItems[i].Name));
                    keyNames.Enqueue(listView_explorer.SelectedItems[i].Name);
                }
                LoadDisCryption loadDisCryption = new LoadDisCryption();
                loadDisCryption.exportFiles(fileNames, keyNames, destination);
                loadDisCryption.ShowDialog();
            }
        }
        /// <summary>
        /// 不加密导出
        /// </summary>
        void item_ExportFilesWithoutDiscryption()
        {
            if (folderBrowserDialog_main.ShowDialog() == DialogResult.OK)
            {
                Queue<string> fileNames = new Queue<string>();
                Queue<string> keyNames = new Queue<string>();
                string destination = folderBrowserDialog_main.SelectedPath;
                for (int i = 0; i < listView_explorer.SelectedItems.Count; i++)
                {
                    fileNames.Enqueue(MyConfig.getPathByKey(listView_explorer.SelectedItems[i].Name));
                    keyNames.Enqueue(listView_explorer.SelectedItems[i].Name);
                }
                LoadDisCryption loadDisCryption = new LoadDisCryption();
                loadDisCryption.exportFilesWithoutDiscryption(fileNames, keyNames, destination);
                loadDisCryption.ShowDialog();
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        void item_Delete()
        {
            deleteFileDialog = new DeleteFileDialog();
            if (deleteFileDialog.ShowDialog() != DialogResult.OK) return;
            Queue<string> filePaths = new Queue<string>();
            Queue<string> keyNames = new Queue<string>();
            for (int i = 0; i < listView_explorer.SelectedItems.Count; i++)
            {
                filePaths.Enqueue(MyConfig.getPathByKey(listView_explorer.SelectedItems[i].Name));
                keyNames.Enqueue(listView_explorer.SelectedItems[i].Name);
                
            }
            LoadDeleteFiles loadDeleteFiles = new LoadDeleteFiles();
            loadDeleteFiles.deleteItems(filePaths, keyNames);
            loadDeleteFiles.ShowDialog();
            //更新文件树
            //checkTreeNodeExpandStatus(File_Tree, treeView_directoryTree.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName)]);

            updateFileTree();
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);

            updateDirectoryTree();
            //if (syncForm != null) syncForm.refreshFileList(SyncPath, SyncPath);

            setVisibleOfItemRightClickMenu(false);
            setVisibleOfRightClickMenu(true);
            //updateDirectoryTree();
            
        }
        /// <summary>
        /// 新建文件夹
        /// </summary>
        void list_NewFolder()
        {
            string newFolderName = FileTree.createFolder(CurrentPath);
            updateFileTree();
            //updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
            addItemToListView(newFolderName, FileTree.FOLDER_IDENTIFY_NAME);
            for(int i = 0; i < listView_explorer.Items.Count; i++)
            {
                /* 判断是否是文件夹 */
                if(listView_explorer.Items[i].Name.Contains(FileTree.FOLDER_IDENTIFY_NAME) &&
                    listView_explorer.Items[i].Text.Equals(Path.GetFileName(newFolderName)))
                {
                    listView_explorer.Items[i].Selected = true;
                    break;
                }
            }
            updateDirectoryTree();

        }
        /// <summary>
        /// 刷新界面
        /// </summary>
        void list_Refresh()
        {
            updateFileTree();
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
        }
        /// <summary>
        /// 打开文件（夹）
        /// </summary>
        void item_Open(object sender, MouseEventArgs ea)
        {
            //if (listView_explorer.SelectedItems.Count != 1) return;
            for (int i = 0; i < listView_explorer.Items.Count; i++)
            {
                if (listView_explorer.Items[i].Focused)
                {
                    /* 判断是否是文件夹 */
                    if (listView_explorer.Items[i].Name.Contains(FileTree.FOLDER_IDENTIFY_NAME))
                    {
                        clearSelectedItems();

                        StackForwardDirectory.Clear();
                        StackBackDirectory.Push(CurrentPath);

                        //CurrentPath += ("/" + listView_explorer.Items[i].Text);
                        CurrentPath = MyConfig.getPathByKey(listView_explorer.Items[i].Name);

                        string a = CurrentPath;
                        updateFileTree();
                        updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);

                        /* 调整可返回值 */
                        pictureBox_buttonBack.Enabled = true;
                        pictureBox_buttonBack.Image = Properties.Resources.arrow_back_deep_blue;
                        pictureBox_buttonForward.Enabled = false;
                        pictureBox_buttonForward.Image = Properties.Resources.function_arrow_gray_forward_button;

                        updateSorterPath();
                        sortBySortRule();
                        /* 应该使上方的navigation同步变化，先不做 */
                        break;
                    }
                    else if (File.Exists(MyConfig.getPathByKey(listView_explorer.Items[i].Name + MyConfig.EXTEND_NAME_ENCRYP_FILE)))
                    {
                        //Process.Start(CurrentPath + "/" + listView_explorer.Items[i].Text);
                        string path = MyConfig.getPathByKey(listView_explorer.Items[i].Name);
                        /* 解密等待框 */
                        Queue<string> openFileName = new Queue<string>();
                        Queue<string> openFileKey = new Queue<string>();
                        openFileName.Enqueue(path);
                        openFileKey.Enqueue(listView_explorer.Items[i].Name);
                        LoadDisCryption loadDisCryption = new LoadDisCryption();
                        loadDisCryption.exportFiles(openFileName, openFileKey, MyConfig.PATH_FILE_BUFFER);
                        loadDisCryption.ShowDialog();
                        //string fileName = CMDComand.discryptFile(path, MyConfig.PATH_FILE_BUFFER + "/" + listView_explorer.Items[i].Text);
                        //while (!File.Exists(fileName)) Application.DoEvents();
                        if (!File.Exists(Path.GetFullPath(MyConfig.PATH_FILE_BUFFER + "/" + Path.GetFileName(path)))) return;
                        FileInfo temp_fi = new FileInfo(Path.GetFullPath(MyConfig.PATH_FILE_BUFFER + "/" + Path.GetFileName(path)));
                        temp_fi.IsReadOnly = true;
                        Process.Start(Path.GetFullPath(MyConfig.PATH_FILE_BUFFER + "/" + Path.GetFileName(path)));
                        listView_explorer.Items[i].Focused = false;

                        updateSorterPath();
                        sortBySortRule();
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 选择打开方式，暂时废弃这个方法
        /// </summary>
        void item_openMethod()
        {
            string fileName = listView_explorer.SelectedItems[0].Text;
            /* 调用系统调用选择打开方式 */
            Process proc = new Process();
            //proc.EnableRaisingEvents = false;
            //proc.
            //proc.StartInfo.FileName = "rundll32.exe";
            //proc.StartInfo.Arguments = "shell32,OpenAs_RunDLL " + filePath;
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.RedirectStandardInput = true;//重定向输入
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            //proc.StandardInput.WriteLine("cd " + CurrentPath + "\n");
            //proc.StandardInput.Flush();
            proc.StandardInput.WriteLine("rundll32.exe shell32,OpenAs_RunDLL " + fileName + "\n");
            proc.StandardInput.Flush();
        }
        /// <summary>
        /// 返回前一目录
        /// </summary>
        void list_Back()
        {
            if (StackBackDirectory.Count < 1) return;

            clearSelectedItems();

            StackForwardDirectory.Push(CurrentPath);
            CurrentPath = StackBackDirectory.Pop();
            

            updateFileTree();
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
            /* 调整按钮可用性 */
            if (StackBackDirectory.Count < 1)
            {
                pictureBox_buttonBack.Enabled = false;
                pictureBox_buttonBack.Image = Properties.Resources.function_arrow_gray_back_button;
            }
            pictureBox_buttonForward.Enabled = true;
            pictureBox_buttonForward.Image = Properties.Resources.arrow_forward_deep_blue;

            updateSorterPath();
            sortBySortRule();
        }
        /// <summary>
        /// 分享文件
        /// </summary>
        void items_share()
        {
            ContactListForm clf = new ContactListForm();
            if(clf.ShowDialog()==DialogResult.OK)
            {

            }
            clf.Close();
        }
        /// <summary>
        /// 目录前进
        /// </summary>
        void list_Forward()
        {
            if (StackForwardDirectory.Count < 1) return;

            clearSelectedItems();
            try {
                StackBackDirectory.Push(CurrentPath);
                pictureBox_buttonBack.Enabled = true;
                pictureBox_buttonBack.Image = Properties.Resources.arrow_back_deep_blue;
                CurrentPath = StackForwardDirectory.Pop();


                updateFileTree();
                updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
                if (StackForwardDirectory.Count < 1)
                {
                    pictureBox_buttonForward.Enabled = false;
                    pictureBox_buttonForward.Image = Properties.Resources.function_arrow_gray_forward_button;
                }
                updateSorterPath();
                sortBySortRule();
            }
            catch(Exception e)
            {
                Reporter.reportBug(e.ToString());
                MessageBox.Show("目录不存在!");
            }
        }
        /// <summary>
        /// 复制多份文件（夹）
        /// </summary>
        void items_Copy()
        {
            QueueCopyDirectory = new Queue<string>();
            for(int i = 0; i < listView_explorer.SelectedItems.Count; i++)
            {
                QueueCopyDirectory.Enqueue(Current_Path + "/" + listView_explorer.SelectedItems[i].Text);
                QueueCopyAttribute.Enqueue(listView_explorer.SelectedItems[i].Name);
            }
            toolStripMenuItem_listContextRightClick_paste.Enabled = true;
            CutTrue_CopyFalse = false;
        }
        /// <summary>
        /// 剪切多份文件（夹)
        /// </summary>
        void items_Cut()
        {
            QueueCopyDirectory = new Queue<string>();
            for (int i = 0; i < listView_explorer.SelectedItems.Count; i++)
            {
                QueueCopyDirectory.Enqueue(Current_Path + "/" + listView_explorer.SelectedItems[i].Text);
                QueueCopyAttribute.Enqueue(listView_explorer.SelectedItems[i].Name);
            }
            toolStripMenuItem_listContextRightClick_paste.Enabled = true;
            CutTrue_CopyFalse = true;
        }
        /// <summary>
        /// 粘贴多份文件
        /// </summary>
        void items_Paste()
        {
            string fileName;
            string attribute;
            string newName = "";
            while (QueueCopyDirectory.Count > 0)
            {
                fileName = QueueCopyDirectory.Dequeue();
                attribute = QueueCopyAttribute.Dequeue();
                /* 判断是文件还是文件夹 */
                if (attribute.Contains(FileTree.FOLDER_IDENTIFY_NAME))
                {
                    if (!CutTrue_CopyFalse)
                    {
                        newName = FileTree.copyDirectory(fileName, CurrentPath + "/" + Path.GetFileName(fileName));
                    }
                    else
                    {
                        /* 如果是剪切的话，检查原有项目 */
                        for (int i = 0; i < listView_explorer.Items.Count; i++)
                        {
                            if (Directory.Exists(fileName) && listView_explorer.Items[i].Text.Equals(Path.GetFileName(fileName)))
                            {
                                string itemKey = listView_explorer.Items[i].Name;
                                listView_explorer.Items[i].Remove();
                                imageList_large.Images.RemoveByKey(itemKey);
                                imageList_small.Images.RemoveByKey(itemKey);
                                break;
                            }
                        }
                        newName = FileTree.moveDirectory(fileName, CurrentPath + "/" + Path.GetFileName(fileName));
                    }
                    
                    //addItemToListView(newName, FileTree.FOLDER_IDENTIFY_NAME);
                    /*
                    
                    */
                }
                else if (attribute.Contains(FileTree.FILE_IDENTIFY_NAME))
                {
                    if (!CutTrue_CopyFalse)
                    {
                        newName = FileTree.copyFile(fileName + MyConfig.EXTEND_NAME_ENCRYP_FILE, CurrentPath + "/" + Path.GetFileName(fileName + MyConfig.EXTEND_NAME_ENCRYP_FILE));
                    }
                    else
                    {
                        /* 删除原有项目 */
                        for (int i = 0; i < listView_explorer.Items.Count; i++)
                        {
                            if (File.Exists(fileName) && listView_explorer.Items[i].Text.Equals(Path.GetFileName(fileName)))
                            {
                                string itemKey = listView_explorer.Items[i].Name;
                                listView_explorer.Items[i].Remove();
                                imageList_large.Images.RemoveByKey(itemKey);
                                imageList_small.Images.RemoveByKey(itemKey);
                                break;
                            }
                        }
                        newName = FileTree.moveFile(fileName + MyConfig.EXTEND_NAME_ENCRYP_FILE, CurrentPath + "/" + Path.GetFileName(fileName + MyConfig.EXTEND_NAME_ENCRYP_FILE));
                    }
                    //addItemToListView(newName, FileTree.FILE_IDENTIFY_NAME);
                    /*
                    for (int i = 0; i < listView_explorer.Items.Count; i++)
                    {
                        if (File.Exists(newName) && listView_explorer.Items[i].Equals(Path.GetFileName(newName)))
                        {
                            listView_explorer.Items[i].Selected = true;
                            break;
                        }
                    }
                    */
                }
                
            }
            toolStripMenuItem_listContextRightClick_paste.Enabled = false;
            /* 更新文件树 */
            updateFileTree();
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
        }
        /// <summary>
        /// 文件（夹）重命名
        /// </summary>
        void item_Rename()
        {
            if (listView_explorer.SelectedItems.Count != 1) return;
            listView_explorer.SelectedItems[0].BeginEdit();
        }
        /// <summary>
        /// 显示文件（夹）的属性
        /// </summary>
        void item_ShowAttribute()
        {
            if (listView_explorer.SelectedItems.Count != 1) return;
            /* 判断是文件还是文件夹 */
            string text = listView_explorer.SelectedItems[0].Text;
            string name = listView_explorer.SelectedItems[0].Name;
            if (name.Contains(FileTree.FOLDER_IDENTIFY_NAME))
            {
                FileTree fileTree = File_Tree.getTargetTree(MyConfig.getPathByKey(name));
                fileAttributeDialog.setLabelValue(fileTree.RootDirectory.Name, CodeAnalysis.converSizeToString(fileTree.getByteLength()), fileTree.RootDirectory.CreationTime.ToString(), "unsync");
            }
            else if (name.Contains(FileTree.FILE_IDENTIFY_NAME))
            {
                FileTree.TreeFileInfo treeFileInfo = File_Tree.getTargetTree(Path.GetDirectoryName(MyConfig.getPathByKey(name))).CurrentDirectoryFileList[text];
                fileAttributeDialog.setLabelValue(treeFileInfo.Fileinfo.Name, CodeAnalysis.converSizeToString(treeFileInfo.Fileinfo.Length), treeFileInfo.Fileinfo.CreationTime.ToString(), "unsync");
            }
            fileAttributeDialog.ShowDialog();
        }
        /// <summary>
        /// 排序事件
        /// </summary>
        /// <param name="sender"></param>
        void list_Sort(object sender)
        {
            if (sender.Equals(toolStripMenuItem_listContextRightClickSortRule_byName))
                Sort_Rule = MyConfig.SortRule.ByName;
            else if (sender.Equals(toolStripMenuItem_listContextRightClickSortRule_bySize))
                Sort_Rule = MyConfig.SortRule.BySize;
            else if (sender.Equals(toolStripMenuItem_listContextRightClickSortRule_byTime))
                Sort_Rule = MyConfig.SortRule.ByTime;
            updateSortRule();
            //sortBySortRule();
        }
        /// <summary>
        /// 全选事件
        /// </summary>
        void list_SelectAll()
        {
            foreach(ListViewItem item in listView_explorer.Items)
            {
                item.Selected = true;
            }
        }
        /// <summary>
        /// 检索操作
        /// </summary>
        void items_Search()
        {
            if (string.IsNullOrEmpty(textBox_searchKey.Text)) return;
            UtilityLoading searchLoading = new UtilityLoading();
            searchLoading.StatusText = "正在搜索 文件/文件夹";
            searchLoading.ButtonText = "取消";
            searchLoading.Show();
            searchLoading.functionSearchItems(File_Tree, textBox_searchKey.Text, ref listView_explorer, ref imageList_large, ref imageList_small, LargeIconDict, SmallIconDict);
            
        }
        /// <summary>
        /// 根据排序规则自动排序
        /// </summary>
        /// <param name="sender"></param>
        void sortBySortRule()
        {
            listView_explorer.Sort();
        }
        /// <summary>
        /// 当文件有变更时发送的事件（ 废弃这个方法，太敏感了）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemWatcher_main_Changed(object sender, FileSystemEventArgs e)
        {
            /* 只要文件已发生改变，就进行同步 */
            /*
            updateFileTree();
            FileTree temp = File_Tree;
            //temp = File_Tree.getTargetTree(CurrentPath);
            //var temp2 = listView_explorer;
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
            var temp2 = listView_explorer;
            string a = "";
            //Thread.Sleep(100);
            */
        }
        /// <summary>
        /// 清除已选择项
        /// </summary>
        void clearSelectedItems()
        {
            //清除已选项
            for (int i = 0; i < listView_explorer.SelectedItems.Count; i++)
            {
                listView_explorer.SelectedItems[i].Selected = false;
            }
        }
        /// <summary>
        /// 项目名称发生改变后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_explorer_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            int index = e.Item;
            string name = listView_explorer.Items[index].Name;
            string newText = e.Label;
            if (newText == null) return;
            if (newText.Equals(itemOldName)) return;
            
            if (name.Contains(FileTree.FILE_IDENTIFY_NAME))
            {
                FileTree.moveFile(CurrentPath + "/" + itemOldName + MyConfig.EXTEND_NAME_ENCRYP_FILE, CurrentPath + "/" + newText + MyConfig.EXTEND_NAME_ENCRYP_FILE);
            }
            else if (name.Contains(FileTree.FOLDER_IDENTIFY_NAME))
            {
                FileTree.moveDirectory(CurrentPath + "/" + itemOldName, CurrentPath + "/" + newText);
            }
            updateFileTree();
            /* 更新该项目 */
            modifyListViewItems(index, CurrentPath + "/" + newText);
            /* 重新排序 */
            sortBySortRule();
        }
        /// <summary>
        /// 项目名称编辑前发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_explorer_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            itemOldName = listView_explorer.Items[e.Item].Text;
        }
        /// <summary>
        /// 更新排序器的路径
        /// </summary>
        void updateSorterPath()
        {
            
            LVIC_BN.CurrentPath = CurrentPath;
            LVIC_BT.CurrentPath = CurrentPath;
            LVIC_BS.CurrentPath = CurrentPath;
            updateSortRule();
        }
        /// <summary>
        /// 更新排序规则
        /// </summary>
        void updateSortRule()
        {
            switch (Sort_Rule)
            {
                case MyConfig.SortRule.ByName:
                    listView_explorer.ListViewItemSorter = LVIC_BN;
                    toolStripMenuItem_listContextRightClickSortRule_byName.Checked = true;
                    toolStripMenuItem_listContextRightClickSortRule_bySize.Checked = false;
                    toolStripMenuItem_listContextRightClickSortRule_byTime.Checked = false;
                    break;
                case MyConfig.SortRule.ByTime:
                    listView_explorer.ListViewItemSorter = LVIC_BT;
                    toolStripMenuItem_listContextRightClickSortRule_byName.Checked = false;
                    toolStripMenuItem_listContextRightClickSortRule_byTime.Checked = true;
                    toolStripMenuItem_listContextRightClickSortRule_bySize.Checked = false;
                    break;
                case MyConfig.SortRule.BySize:
                    listView_explorer.ListViewItemSorter = LVIC_BS;
                    toolStripMenuItem_listContextRightClickSortRule_byName.Checked = false;
                    toolStripMenuItem_listContextRightClickSortRule_byTime.Checked = false;
                    toolStripMenuItem_listContextRightClickSortRule_bySize.Checked = true;
                    break;
            }
            listView_explorer.Sort();
            /* 保存排序信息 */
            MyConfig.ConfigFile configFile = MyConfig.readConfig();
            configFile.createOrModifyItem(MyConfig.ConfigFile.TABLE_NAME_SKIN, MyConfig.ConfigFile.Skin.KEY_FILE_SORT_RULE, Sort_Rule);
            MyConfig.saveConfig(configFile);
        }
        #region 目录树模块
        /// <summary>
        /// 更新目录树
        /// </summary>
        public void updateDirectoryTree()
        {
            /* 清除原有节点 */
            treeView_directoryTree.Nodes.Clear();
            imageList_treeView.Images.Clear();
            /* 先添加根节点 */
            treeView_directoryTree.Nodes.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName),
                "Home", MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName));
            imageList_treeView.Images.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName),
                SmallFolderIcon);
            //if(File_Tree.isExpand) treeView_directoryTree.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName)].Expand();
            //else treeView_directoryTree.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName)].Collapse();
            /* 测试代码 */
            //treeView_directoryTree.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName)].Expand();
            /* 递归子目录 */
            foreach (FileTree ft in File_Tree.SubTree.Values)
            {
                recursiveAddItemToDirectoryTree(ft, 
                    treeView_directoryTree.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName)]);
            }
            /* 展开树节点 */
            expandTreeNodeByExpandStatus(File_Tree, 
                treeView_directoryTree.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName)]);
        }
        /// <summary>
        /// 用递归的方法向treeview中添加项目
        /// </summary>
        /// <param name="fileTree"></param>
        void recursiveAddItemToDirectoryTree(FileTree fileTree, TreeNode treeNode)
        {
            /* 添加新节点 */
            treeNode.Nodes.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, fileTree.RootDirectory.FullName),
                fileTree.RootDirectory.Name, MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, fileTree.RootDirectory.FullName));
            imageList_treeView.Images.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, fileTree.RootDirectory.FullName),
                SmallFolderIcon);
            //if (fileTree.isExpand) treeNode.Expand();
            //else treeNode.Collapse();
            /* 递归子目录 */
            foreach(FileTree  ft in fileTree.SubTree.Values)
            {
                recursiveAddItemToDirectoryTree(ft, 
                    treeNode.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, fileTree.RootDirectory.FullName)]);
            }
        }
        /// <summary>
        /// 展开树节点
        /// </summary>
        /// <param name="fileTree"></param>
        /// <param name="treeNode"></param>
        void expandTreeNodeByExpandStatus(FileTree fileTree, TreeNode treeNode)
        {
            if (treeNode == null) return;
            if (fileTree.isExpand) treeNode.Expand();
            foreach (FileTree ft in fileTree.SubTree.Values)
            {
                expandTreeNodeByExpandStatus(ft,
                    treeNode.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, ft.RootDirectory.FullName)]);
            }
        }
        /// <summary>
        /// 递归检查树节点展开状态
        /// </summary>
        void checkTreeNodeExpandStatus(FileTree fileTree, TreeNode treeNode)
        {
            if (treeNode == null) return;
            fileTree.isExpand = treeNode.IsExpanded;
            fileTree.Key = treeNode.Name;
            foreach(FileTree ft in fileTree.SubTree.Values)
            {
                checkTreeNodeExpandStatus(ft, 
                    treeNode.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, ft.RootDirectory.FullName)]);
            }
        }
        /// <summary>
        /// 更新文件树
        /// </summary>
        public void updateFileTree()
        {
            File_Tree.updateTree(CurrentPath);
            checkTreeNodeExpandStatus(File_Tree, treeView_directoryTree.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName)]);
        }

        /// <summary>
        /// 目录树上的节点被单击时发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_directoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int pathIndex = e.Node.Name.IndexOf(MyConfig.STRING_SEPERATER) + MyConfig.STRING_SEPERATER.Length;
                /* 截取得到文件路径 */
                string path = e.Node.Name.Substring(pathIndex, e.Node.Name.Length - pathIndex);
                CurrentPath = path;
                /* 更新 */
                //updateFileTree();
                File_Tree.updateTree(CurrentPath);
                updateListViewItemsWithoutTreeUpdate(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
                //updateDirectoryTree();
            }
            else if (e.Button == MouseButtons.Right)
            {
                /* 右键选中该节点 */
                treeView_directoryTree.SelectedNode = e.Node;
            }
        }
        /// <summary>
        /// 文件树-打开文件夹
        /// </summary>
        void treeView_Open()
        {
            if (treeView_directoryTree.SelectedNode == null) return;
            clearSelectedItems();

            StackForwardDirectory.Clear();
            StackBackDirectory.Push(CurrentPath);

            //CurrentPath += ("/" + listView_explorer.Items[i].Text);
            CurrentPath = MyConfig.getPathByKey(treeView_directoryTree.SelectedNode.Name);

            string a = CurrentPath;
            updateFileTree();
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);

            /* 调整可返回值 */
            pictureBox_buttonBack.Enabled = true;
            pictureBox_buttonBack.Image = Properties.Resources.arrow_back_deep_blue;
            pictureBox_buttonForward.Enabled = false;
            pictureBox_buttonForward.Image = Properties.Resources.function_arrow_gray_forward_button;

            updateSorterPath();
            sortBySortRule();
        }
        /// <summary>
        /// 目录树-导入文件
        /// </summary>
        void treeView_importFiles()
        {
            if (openFileDialog_main.ShowDialog() == DialogResult.OK)
            {
                string[] fileNames = openFileDialog_main.FileNames;

                LoadEncryption loadEncryption = new LoadEncryption();
                loadEncryption.importItem(fileNames, MyConfig.getPathByKey(treeView_directoryTree.SelectedNode.Name));
                loadEncryption.ShowDialog();


                //更新文件树
                updateFileTree();
                updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);

                //while (newFileNames.Count > 0) addItemToListView(newFileNames.Dequeue(), FileTree.FILE_IDENTIFY_NAME);
                //updateListViewItems(FileView, File_Tree, Sort_Rule);
            }
        }
        /// <summary>
        /// 目录树-导入文件夹
        /// </summary>
        void treeView_ImportFolder()
        {
            if (treeView_directoryTree.SelectedNode == null) return;
            if (folderBrowserDialog_main.ShowDialog() == DialogResult.OK)
            {
                LoadEncryption loadEncryption = new LoadEncryption();
                //loadEncryption.Show();
                loadEncryption.importFolder(folderBrowserDialog_main.SelectedPath,
                    MyConfig.getPathByKey(treeView_directoryTree.SelectedNode.Name) + "/" + Path.GetFileName(folderBrowserDialog_main.SelectedPath));
                loadEncryption.ShowDialog();
                //更新文件树
                updateFileTree();
                updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
                //addItemToListView(newFolderName, FileTree.FOLDER_IDENTIFY_NAME);

                updateDirectoryTree();
            }
        }
        /// <summary>
        /// 目录树-导出文件夹
        /// </summary>
        void treeView_ExportFolder()
        {
            if (treeView_directoryTree.SelectedNode == null) return;
            if (folderBrowserDialog_main.ShowDialog() == DialogResult.OK)
            {
                Queue<string> fileNames = new Queue<string>();
                Queue<string> keyNames = new Queue<string>();
                string destination = folderBrowserDialog_main.SelectedPath;
                if (treeView_directoryTree.SelectedNode.Name.Equals(treeView_directoryTree.Nodes[0].Name))
                {
                    fileNames.Enqueue(SyncPath);
                    keyNames.Enqueue(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, SyncPath));
                }
                else
                {
                    fileNames.Enqueue(MyConfig.getPathByKey(treeView_directoryTree.SelectedNode.Name));
                    keyNames.Enqueue(treeView_directoryTree.SelectedNode.Name);
                }
                LoadDisCryption loadDisCryption = new LoadDisCryption();
                loadDisCryption.exportFiles(fileNames, keyNames, destination);
                loadDisCryption.ShowDialog();
            }
        }
        /// <summary>
        /// 目录树-删除文件夹
        /// </summary>
        void treeView_DeleteFolder()
        {
            if (treeView_directoryTree.SelectedNode == null) return;
            if (treeView_directoryTree.SelectedNode.Name.Equals(treeView_directoryTree.Nodes[0].Name))
            {
                MessageBox.Show("根目录不能删除!");
                return;
            }
            deleteFileDialog = new DeleteFileDialog();
            if (deleteFileDialog.ShowDialog() != DialogResult.OK) return;
            Queue<string> filePaths = new Queue<string>();
            Queue<string> keyNames = new Queue<string>();
            filePaths.Enqueue(MyConfig.getPathByKey(treeView_directoryTree.SelectedNode.Name));
            keyNames.Enqueue(treeView_directoryTree.SelectedNode.Name);
            LoadDeleteFiles loadDeleteFiles = new LoadDeleteFiles();
            loadDeleteFiles.deleteItems(filePaths, keyNames);
            loadDeleteFiles.ShowDialog();
            /* 如果删除的是当前目录，则回到根目录 */
            if (CurrentPath.Equals(MyConfig.getPathByKey(treeView_directoryTree.SelectedNode.Name)))
            {
                CurrentPath = SyncPath;
            }
            //更新文件树
            //checkTreeNodeExpandStatus(File_Tree, treeView_directoryTree.Nodes[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, File_Tree.RootDirectory.FullName)]);

            updateFileTree();
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);

            updateDirectoryTree();

            setVisibleOfItemRightClickMenu(false);
            setVisibleOfRightClickMenu(true);
            //updateDirectoryTree();
        }
        /// <summary>
        /// 目录树-新建文件夹
        /// </summary>
        void treeView_newFolder()
        {
            if (treeView_directoryTree.SelectedNode == null) return;
            string newFolderName = FileTree.createFolder(MyConfig.getPathByKey(treeView_directoryTree.SelectedNode.Name));
            updateFileTree();
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
            updateDirectoryTree();
        }
        #endregion
        
        /// <summary>
        /// 窗体关闭时的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloudDiskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
        }
        /// <summary>
        /// 拖拽放下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_explorer_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            if (!sender.Equals(listView_explorer)) return;
            try
            {
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, true);
                LoadEncryption loadEncryption = new LoadEncryption();
                loadEncryption.importItem(fileNames, CurrentPath);
                loadEncryption.ShowDialog();
            }
            catch(Exception ex)
            {
                Reporter.reportBug(ex.ToString());
            }

            //更新文件树
            updateFileTree();
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
        }
        /// <summary>
        /// 拖拽进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_explorer_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }
        /// <summary>
        /// 拖拽结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_explorer_DragOver(object sender, DragEventArgs e)
        {

        }
        /// <summary>
        /// 拖拽离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_explorer_DragLeave(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 项目拖拽事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_explorer_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            
            
            Queue<string> fileNames = new Queue<string>();
            Queue<string> keyNames = new Queue<string>();

            for (int i = 0; i < listView_explorer.SelectedItems.Count; i++)
            {
                fileNames.Enqueue(MyConfig.getPathByKey(listView_explorer.SelectedItems[i].Name));
                keyNames.Enqueue(listView_explorer.SelectedItems[i].Name);
            }
            if (!Directory.Exists(MyConfig.PATH_FILE_BUFFER)) Directory.CreateDirectory(MyConfig.PATH_FILE_BUFFER);
            LoadDisCryption loadDisCryption = new LoadDisCryption();
            loadDisCryption.exportFiles(fileNames, keyNames, Path.GetFullPath(MyConfig.PATH_FILE_BUFFER));
            loadDisCryption.ShowDialog();
            string[] files = new string[listView_explorer.SelectedItems.Count];
            //bool temp = false;
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFullPath(MyConfig.PATH_FILE_BUFFER + "/" + listView_explorer.SelectedItems[i].Text);
                //temp = File.Exists(files[i]);
            }
            
            DataObject data = new DataObject(DataFormats.FileDrop, files);
            data.SetData(DataFormats.StringFormat, files[0]);
            DoDragDrop(data, DragDropEffects.Copy).ToString();
            //bool a = temp;
        }
    }
}
