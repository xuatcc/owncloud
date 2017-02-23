﻿using System;
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
        FileTree File_Tree;
        string CurrentPath;
        /// <summary>
        /// 获取当前工作目录
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
        /// <summary>
        /// 文件视图
        /// </summary>
        View FileView;
        /// <summary>
        /// 同步目录
        /// </summary>
        public string SyncPath = "./test/";
        public CloudDiskForm()
        {
            InitializeComponent();
            initializeConfig();
            initializeWidget();
            //testFileTree();
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

            /* 加载文件显示视图 */
            if (configFile.TableSkin.ContainsKey(MyConfig.ConfigFile.Skin.KEY_FILE_VIEW)) FileView = 
                    (View)int.Parse(configFile.TableSkin[MyConfig.ConfigFile.Skin.KEY_FILE_VIEW].ToString());

            /* 加载排序方式 */
            if (configFile.TableSkin.ContainsKey(MyConfig.ConfigFile.Skin.KEY_FILE_SORT_RULE))
                Sort_Rule = (MyConfig.SortRule)int.Parse(configFile.TableSkin[MyConfig.ConfigFile.Skin.KEY_FILE_SORT_RULE].ToString());
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
            Sort_Rule = MyConfig.SortRule.ByName;
            //FileView = View.LargeIcon;
            //FileView = View.Tile;
            /* 文件显示视图 */
            setViewMode();
            listView_explorer.ContextMenuStrip = contextMenuStrip_listRightClick;
            //toolStripMenuItem_listContextRightClickView_largeIcon.Checked = true;
            //toolStripMenuItem_listContextRightClickNewFolder.Visible = false;
            //listView_explorer.Items.Clear();
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
            /* 测试部分 */
            /* 选项菜单不可见 */
            setVisibleOfItemRightClickMenu(false);
            listView_explorer.LargeImageList = imageList_large;
            listView_explorer.SmallImageList = imageList_small;
            //listView_explorer.ListViewItemSorter = new ListViewItemComparerByName();
            listView_explorer.ListViewItemSorter = new ListViewItemComparerByTime();
            listView_explorer.LabelEdit = true;
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
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
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
        }
        void pictureBox_MouseDown_Event(object sender, MouseEventArgs ea)
        {
            if (sender.Equals(pictureBox_buttonRefresh)) pictureBox_buttonRefresh.Image = Properties.Resources.refresh_deep_blue;
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
            
            switch (sortRule)
            {
                case MyConfig.SortRule.ByName:
                    updateListViewItemsByName(fileTree);
                    break;
            }
        }
        void updateListViewItemsByName(FileTree fileTree)
        {
            /* 按名字排序 */
            //listView_explorer.ListViewItemSorter = new ListViewItemComparerByName();
           
            var temp = listView_explorer;
            var temp2 = imageList_large;
            /* 排序方式 */
            //listView_explorer.ListViewItemSorter = new ListViewItemComparerByName();
            foreach(FileTree file_tree in fileTree.SubTree.Values)
            {
                imageList_large.Images.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, file_tree.RootDirectory.Name), 
                    Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, LargeFolderIcon));
                imageList_small.Images.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, file_tree.RootDirectory.Name), 
                    Int32Dec64Convert.ConverToSquareBitmap(imageList_small.ImageSize.Width, SmallFolderIcon));
                listView_explorer.Items.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, file_tree.RootDirectory.Name), file_tree.RootDirectory.Name, MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, file_tree.RootDirectory.Name));
                //listView_explorer.Items[MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, file_tree.RootDirectory.Name)].Name = 
                    //FileTree.FOLDER_IDENTIFY_NAME;
            }
            /* 手动排序 */
            //listView_explorer.Sort();
            foreach (FileTree.TreeFileInfo treeFileInfo in fileTree.CurrentDirectoryFileList.Values)
            {
                string fileName = treeFileInfo.Fileinfo.Name;
                /* 大图标注意判断文件是否为图片 */
                if (CodeAnalysis.IsImage(treeFileInfo.Fileinfo.FullName))
                {
                    Image image = Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, Image.FromFile(treeFileInfo.Fileinfo.FullName));
                    imageList_large.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), image);
                }
                else if (LargeIconDict.ContainsKey(treeFileInfo.ExtendName)) imageList_large.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, LargeIconDict[treeFileInfo.ExtendName]));
                else imageList_large.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, LargeDefaultFileIcon));

                if (SmallIconDict.ContainsKey(treeFileInfo.ExtendName)) imageList_small.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), Int32Dec64Convert.ConverToSquareBitmap(imageList_small.ImageSize.Width, SmallIconDict[treeFileInfo.ExtendName]));
                else imageList_small.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), Int32Dec64Convert.ConverToSquareBitmap(imageList_small.ImageSize.Width, SmallDefaultFileIcon));

                listView_explorer.Items.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), treeFileInfo.Fileinfo.Name, MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName));
                //listView_explorer.Items[MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName)].Name = FileTree.FILE_IDENTIFY_NAME;
            }
            
        }
        /// <summary>
        /// 按名字排序接口
        /// </summary>
        public class ListViewItemComparerByName : IComparer
        {
            private int col;
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                ((ListViewItem)y).SubItems[col].Text);
                return returnVal;
            }
        }
        /// <summary>
        /// 按大小排序接口
        /// </summary>
        public class ListViewItemComparerByTime : IComparer
        {
            public string path_1;
            public string path_2;
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                /* 分4种情况 */
                ListViewItem lvi_1 = (ListViewItem)x;
                ListViewItem lvi_2 = (ListViewItem)y;
                if(lvi_1.Name.Contains(FileTree.FILE_IDENTIFY_NAME) && lvi_2.Name.Contains(FileTree.FILE_IDENTIFY_NAME))
                {
                    
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
        }
        /// <summary>
        /// 文件树测试
        /// </summary>
        void testFileTree(object obj, EventArgs ea)
        {
            
            //File_Tree.updateTree("./icon/");
            var temp = File_Tree;
            string a = "";
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

        }
        void setVisibleOfItemRightClickMenu(bool visible)
        {
            toolStripMenuItem_listRightClick_Item_open.Visible = visible;
            //toolStripMenuItem_listRightClick_item_openMethod.Visible = visible;
            toolStripMenuItem_listRightClick_item_copy.Visible = visible;
            toolStripMenuItem_listRightClick_item_cut.Visible = visible;
            toolStripMenuItem_listRightClick_item_delete.Visible = visible;
            toolStripMenuItem_listRightClick_item_export.Visible = visible;
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
            if (obj.Equals(toolStripMenuItem_export)) item_ExportFiles();
            if (obj.Equals(toolStripMenuItem_delete)) item_Delete();
            if (obj.Equals(toolStripMenuItem_newFolder)) list_NewFolder();
            if (obj.Equals(pictureBox_buttonRefresh)) list_Refresh();
            if (obj.Equals(pictureBox_buttonBack)) list_Back();
            if (obj.Equals(pictureBox_buttonForward)) list_Forward();

            /* Context功能 */
            if (obj.Equals(toolStripMenuItem_listContextRightClickImport)) item_Import();
            if (obj.Equals(toolStripMenuItem_listContextRightClickNewFolder)) list_NewFolder();
            if (obj.Equals(toolStripMenuItem_listContextRightClickRefresh)) list_Refresh();
            if (obj.Equals(toolStripMenuItem_listRightClick_item_delete)) item_Delete();
            if (obj.Equals(toolStripMenuItem_listRightClick_item_export)) item_ExportFiles();
            if (obj.Equals(toolStripMenuItem_listContextRightClick_importFolder)) item_ImportFolder();
            if (obj.Equals(toolStripMenuItem_listRightClick_Item_open)) item_Open(null, null);
            //if (obj.Equals(toolStripMenuItem_listContextRightClick_openMethod)) item_openMethod();
            if (obj.Equals(toolStripMenuItem_listContextRightClick_paste)) items_Paste();
            if (obj.Equals(toolStripMenuItem_listRightClick_item_copy)) items_Copy();
            if (obj.Equals(toolStripMenuItem_listRightClick_item_cut)) items_Cut();
            if (obj.Equals(toolStripMenuItem_listRightClick_item_rename)) item_Rename();

            if (obj.Equals(toolStripMenuItem_listContextRightClickView_largeIcon))
                modifyViewMode(toolStripMenuItem_listContextRightClickView_largeIcon);
            if (obj.Equals(toolStripMenuItem_listContextRightClickView_smallIcon))
                modifyViewMode(toolStripMenuItem_listContextRightClickView_smallIcon);
            if (obj.Equals(toolStripMenuItem_listContextRightClickView_detail))
                modifyViewMode(toolStripMenuItem_listContextRightClickView_detail);
        }
        /* 各种详细事件 */
        /// <summary>
        /// 导入文件
        /// </summary>
        void item_Import()
        {
            if (openFileDialog_main.ShowDialog() == DialogResult.OK)
            {
                //这期间需要加密，这里先不加
                string newFileName = FileTree.copyFile(openFileDialog_main.FileName,
                    File_Tree.getTargetTree(CurrentPath).RootDirectory.FullName + "/" + Path.GetFileName(openFileDialog_main.FileName));
                //更新文件树
                File_Tree.updateTree(CurrentPath);
                //updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
                addItemToListView(newFileName, FileTree.FILE_IDENTIFY_NAME);
                /*
                for(int i = 0; i < listView_explorer.Items.Count; i++)
                {
                    if (listView_explorer.Items[i].Text.Equals(Path.GetFileName(newFileName)) && 
                        File.Exists(File_Tree.getTargetTree(CurrentPath).RootDirectory.FullName + "/" + Path.GetFileName(newFileName)))
                    {
                        listView_explorer.Items[i].Selected = true;
                        break;
                    }
                }
                */
                /* 启动同步 */
            }
        }
        /// <summary>
        /// 导入文件夹
        /// </summary>
        void item_ImportFolder()
        {
            if (folderBrowserDialog_main.ShowDialog() == DialogResult.OK)
            {
                string newFolderName = FileTree.copyDirectory(folderBrowserDialog_main.SelectedPath, 
                    File_Tree.getTargetTree(CurrentPath).RootDirectory.FullName + "/" + Path.GetFileName(folderBrowserDialog_main.SelectedPath));
                //更新文件树
                File_Tree.updateTree(CurrentPath);
                //updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
                addItemToListView(newFolderName, FileTree.FOLDER_IDENTIFY_NAME);
                /*
                for (int i = 0; i < listView_explorer.Items.Count; i++)
                {
                    if (listView_explorer.Items[i].Text.Equals(Path.GetFileName(newFolderName)) && 
                        Directory.Exists(File_Tree.getTargetTree(CurrentPath).RootDirectory.FullName + "/" + Path.GetFileName(newFolderName)))
                    {
                        listView_explorer.Items[i].Selected = true;
                        break;
                    }
                }
                */
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
                string fileName;
                for(int i = 0; i < listView_explorer.SelectedItems.Count; i++)
                {
                    fileName = listView_explorer.SelectedItems[i].Text;
                    if (File.Exists(File_Tree.getTargetTree(CurrentPath).RootDirectory.FullName + "/" + fileName))
                    {
                        FileTree.copyFile(File_Tree.getTargetTree(CurrentPath).RootDirectory.FullName + "/" + fileName,
                            folderBrowserDialog_main.SelectedPath + "/" + fileName);
                    }
                    if(Directory.Exists(File_Tree.getTargetTree(CurrentPath).RootDirectory.FullName + "/" + fileName))
                    {
                        FileTree.copyDirectory(File_Tree.getTargetTree(CurrentPath).RootDirectory.FullName + "/" + fileName,
                            folderBrowserDialog_main.SelectedPath + "/" + fileName);
                    }
                }
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        void item_Delete()
        {
            string fileName;
            for (int i = 0; i < listView_explorer.SelectedItems.Count; i++)
            {
                fileName = listView_explorer.SelectedItems[i].Text;
                if (File.Exists(File_Tree.getTargetTree(CurrentPath).RootDirectory.FullName + "/" + fileName))
                {
                    File.Delete(File_Tree.getTargetTree(CurrentPath).RootDirectory.FullName + "/" + fileName);
                }
                if (Directory.Exists(File_Tree.getTargetTree(CurrentPath).RootDirectory.FullName + "/" + fileName))
                {
                    FileTree.deleteDirectory(File_Tree.getTargetTree(CurrentPath).RootDirectory.FullName + "/" + fileName);
                }
            }
            //更新文件树
            File_Tree.updateTree(CurrentPath);
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
        }
        /// <summary>
        /// 新建文件夹
        /// </summary>
        void list_NewFolder()
        {
            string newFolderName = FileTree.createFolder(CurrentPath);
            File_Tree.updateTree(CurrentPath);
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
        }
        /// <summary>
        /// 刷新界面
        /// </summary>
        void list_Refresh()
        {
            File_Tree.updateTree(CurrentPath);
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

                        CurrentPath += ("/" + listView_explorer.Items[i].Text);
                        string a = CurrentPath;
                        string b = "";
                        File_Tree.updateTree(CurrentPath);
                        updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);

                        /* 调整可返回值 */
                        pictureBox_buttonBack.Enabled = true;
                        pictureBox_buttonBack.Image = Properties.Resources.arrow_back_deep_blue;
                        pictureBox_buttonForward.Enabled = false;
                        pictureBox_buttonForward.Image = Properties.Resources.function_arrow_gray_forward_button;

                        
                        /* 应该使上方的navigation同步变化，先不做 */
                        break;
                    }
                    else if (File.Exists(CurrentPath + "/" + listView_explorer.Items[i].Text))
                    {
                        Process.Start(CurrentPath + "/" + listView_explorer.Items[i].Text);
                        listView_explorer.Items[i].Focused = false;
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
            File_Tree.updateTree(CurrentPath);
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
            /* 调整按钮可用性 */
            if (StackBackDirectory.Count < 1)
            {
                pictureBox_buttonBack.Enabled = false;
                pictureBox_buttonBack.Image = Properties.Resources.function_arrow_gray_back_button;
            }
            pictureBox_buttonForward.Enabled = true;
            pictureBox_buttonForward.Image = Properties.Resources.arrow_forward_deep_blue;

            
        }
        /// <summary>
        /// 目录前进
        /// </summary>
        void list_Forward()
        {
            if (StackForwardDirectory.Count < 1) return;

            clearSelectedItems();

            StackBackDirectory.Push(CurrentPath);
            pictureBox_buttonBack.Enabled = true;
            pictureBox_buttonBack.Image = Properties.Resources.arrow_back_deep_blue;
            CurrentPath = StackForwardDirectory.Pop();
            File_Tree.updateTree(CurrentPath);
            updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
            if (StackForwardDirectory.Count < 1)
            {
                pictureBox_buttonForward.Enabled = false;
                pictureBox_buttonForward.Image = Properties.Resources.function_arrow_gray_forward_button;
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
                    
                    addItemToListView(newName, FileTree.FOLDER_IDENTIFY_NAME);
                    /*
                    
                    */
                }
                else if (attribute.Contains(FileTree.FILE_IDENTIFY_NAME))
                {
                    if (!CutTrue_CopyFalse)
                    {
                        newName = FileTree.copyFile(fileName, CurrentPath + "/" + Path.GetFileName(fileName));
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
                        newName = FileTree.moveFile(fileName, CurrentPath + "/" + Path.GetFileName(fileName));
                    }
                    addItemToListView(newName, FileTree.FILE_IDENTIFY_NAME);
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
            //File_Tree.updateTree(CurrentPath);
            //updateListViewItems(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
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
        /// 当文件有变更时发送的事件（ 废弃这个方法，太敏感了）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemWatcher_main_Changed(object sender, FileSystemEventArgs e)
        {
            /*
            File_Tree.updateTree(CurrentPath);
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
                FileTree.moveFile(CurrentPath + "/" + itemOldName, CurrentPath + "/" + newText);
            }
            else if (name.Contains(FileTree.FOLDER_IDENTIFY_NAME))
            {
                FileTree.moveDirectory(CurrentPath + "/" + itemOldName, CurrentPath + "/" + newText);
            }
            File_Tree.updateTree(CurrentPath);
            /* 更新该项目 */
            modifyListViewItems(index, CurrentPath + "/" + newText);
            /* 删除原来的项目 */
            //listView_explorer.Items.RemoveAt(index);
            //imageList_large.Images.RemoveAt(index);
            //imageList_small.Images.RemoveAt(index);
            //addItemToListView(CurrentPath + "/" + newText, name);
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
    }
}
