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
        /// 后退目录栈
        /// </summary>
        Stack<string> StackBackDirectory = new Stack<string>();
        /// <summary>
        /// 前进目录栈
        /// </summary>
        Stack<string> StackForwardDirectory = new Stack<string>();
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
            /* 加载文件图标配置 */
            LargeIconDict = MyConfig.getLargeFileIconDictionary();
            SmallIconDict = MyConfig.getSmallFileIconDictionary();

            imageList_large.ImageSize = new Size(100, 100);
            imageList_small.ImageSize = new Size(16, 16);
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
            FileView = View.LargeIcon;
            FileView = View.Tile;
            listView_explorer.ContextMenuStrip = contextMenuStrip_listRightClick;
            toolStripMenuItem_listContextRightClickView_largeIcon.Checked = true;
            //toolStripMenuItem_listContextRightClickNewFolder.Visible = false;
            addItemsToListView(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
            /* 测试部分 */
            /* 选项菜单不可见 */
            setVisibleOfItemRightClickMenu(false);
            listView_explorer.LargeImageList = imageList_large;
            listView_explorer.SmallImageList = imageList_small;
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
        void addItemsToListView(View view, FileTree fileTree, MyConfig.SortRule sortRule)
        {
            if (fileTree == null) return;
            /* 设置显示方式 */
            listView_explorer.Items.Clear();
            listView_explorer.View = view;
            listView_explorer.ListViewItemSorter = null;
            /* 加载图标列表 */
            imageList_large.Images.Clear();
            imageList_small.Images.Clear();
            
            switch (sortRule)
            {
                case MyConfig.SortRule.ByName:
                    addItemsToListViewByName(fileTree);
                    break;
            }
        }
        void addItemsToListViewByName(FileTree fileTree)
        {
            /* 按名字排序 */
            //listView_explorer.ListViewItemSorter = new ListViewItemComparerByName();
           
            var temp = listView_explorer;
            var temp2 = imageList_large;
            /* 排序方式 */
            //listView_explorer.ListViewItemSorter = new ListViewItemComparerByName();
            foreach(FileTree file_tree in fileTree.SubTree.Values)
            {
                imageList_large.Images.Add(LargeFolderIcon);
                imageList_small.Images.Add(SmallFolderIcon);
                listView_explorer.Items.Add(file_tree.RootDirectory.Name);
                listView_explorer.Items[listView_explorer.Items.Count - 1].ImageIndex = listView_explorer.Items.Count - 1;
                listView_explorer.Items[listView_explorer.Items.Count - 1].Name = FileTree.FOLDER_IDENTIFY_NAME;
            }
            /* 手动排序 */
            //listView_explorer.Sort();
            foreach (FileTree.TreeFileInfo treeFileInfo in fileTree.CurrentDirectoryFileList.Values)
            {
                /* 大图标注意判断文件是否为图片 */
                if (CodeAnalysis.IsImage(treeFileInfo.Fileinfo.FullName))
                {
                    Image image = Int32Dec64Convert.ConverToSquareBitmap(imageList_large.ImageSize.Width, Image.FromFile(treeFileInfo.Fileinfo.FullName));
                    imageList_large.Images.Add(image);
                }
                else if (LargeIconDict.ContainsKey(treeFileInfo.ExtendName)) imageList_large.Images.Add(LargeIconDict[treeFileInfo.ExtendName]);
                else imageList_large.Images.Add(LargeDefaultFileIcon);

                if (SmallIconDict.ContainsKey(treeFileInfo.ExtendName)) imageList_small.Images.Add(SmallIconDict[treeFileInfo.ExtendName]);
                else imageList_small.Images.Add(SmallDefaultFileIcon);

                listView_explorer.Items.Add(treeFileInfo.Fileinfo.Name);
                listView_explorer.Items[listView_explorer.Items.Count - 1].ImageIndex = listView_explorer.Items.Count - 1;
                listView_explorer.Items[listView_explorer.Items.Count - 1].Name = FileTree.FILE_IDENTIFY_NAME;
            }
            //listView_explorer.ListViewItemSorter = new ListViewItemComparerByName();
            //listView_explorer.Sort();
            /* 手动排序 */
            //listView_explorer.Sort();
            //listView_explorer.Sorting = SortOrder.Ascending;
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

            toolStripMenuItem_share.Enabled = visible;
            toolStripMenuItem_delete.Enabled = visible;
            toolStripMenuItem_export.Enabled = visible;
        }
        /// <summary>
        /// 不选中时发送的事件
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
                }
                
                
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
                addItemsToListView(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
                for(int i = 0; i < listView_explorer.Items.Count; i++)
                {
                    if (listView_explorer.Items[i].Text.Equals(Path.GetFileName(newFileName)) && 
                        File.Exists(File_Tree.getTargetTree(CurrentPath).RootDirectory.FullName + "/" + Path.GetFileName(newFileName)))
                    {
                        listView_explorer.Items[i].Selected = true;
                        break;
                    }
                }
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
                addItemsToListView(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
                for (int i = 0; i < listView_explorer.Items.Count; i++)
                {
                    if (listView_explorer.Items[i].Text.Equals(Path.GetFileName(newFolderName)) && 
                        Directory.Exists(File_Tree.getTargetTree(CurrentPath).RootDirectory.FullName + "/" + Path.GetFileName(newFolderName)))
                    {
                        listView_explorer.Items[i].Selected = true;
                        break;
                    }
                }
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
            addItemsToListView(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
        }
        /// <summary>
        /// 新建文件夹
        /// </summary>
        void list_NewFolder()
        {
            string newFolderName = FileTree.createFolder(CurrentPath);
            File_Tree.updateTree(CurrentPath);
            addItemsToListView(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
            for(int i = 0; i < listView_explorer.Items.Count; i++)
            {
                /* 判断是否是文件夹 */
                if(listView_explorer.Items[i].Name.Equals(FileTree.FOLDER_IDENTIFY_NAME) &&
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
            addItemsToListView(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
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
                    if (listView_explorer.Items[i].Name.Equals(FileTree.FOLDER_IDENTIFY_NAME))
                    {
                        clearSelectedItems();

                        StackForwardDirectory.Clear();
                        StackBackDirectory.Push(CurrentPath);

                        CurrentPath += ("/" + listView_explorer.Items[i].Text);
                        string a = CurrentPath;
                        string b = "";
                        File_Tree.updateTree(CurrentPath);
                        addItemsToListView(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);

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
        /// 返回前一目录
        /// </summary>
        void list_Back()
        {
            if (StackBackDirectory.Count < 1) return;

            clearSelectedItems();

            StackForwardDirectory.Push(CurrentPath);
            CurrentPath = StackBackDirectory.Pop();
            File_Tree.updateTree(CurrentPath);
            addItemsToListView(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
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
            addItemsToListView(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
            if (StackForwardDirectory.Count < 1)
            {
                pictureBox_buttonForward.Enabled = false;
                pictureBox_buttonForward.Image = Properties.Resources.function_arrow_gray_forward_button;
            }
            
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
            addItemsToListView(FileView, File_Tree.getTargetTree(CurrentPath), Sort_Rule);
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
    }
}
