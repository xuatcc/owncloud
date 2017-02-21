using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace custom_cloud
{
    public partial class Form_main : Form
    {
        //string userInfo.SyncDirectory = null;
        string TOOL_LOCATION = null;
        string CURRENT_DIRECTORY = null;
        Stack<string> Path_Stack;
        string Copy_Path;
        bool Flag_CutTrue_CopyFalse = false;
        Queue<string> Copy_File_Name;
        Queue<string> Copy_Directory_Name;
        /* 重命名项目索引 */
        int RenameItemID = -1;
        string Old_Name;
        string New_Name;
        /* 账户设置用到的变量 */
        /*
        string User;
        string Password;
        //string SyncDirectory;
        string ServerURL;
        */
        string User;
        UserInfo userInfo;
        /* 同步线程 */
        Thread ThreadSync;
        int TimeSlice = 4500;// milesecond 时间片，即同步时间间隔
        /* Icon哈希表 */
        Hashtable IconNameTable = new Hashtable();
        LinkedList<string> IconName = new LinkedList<string>(); 
        LinkedList<IconUnit> IconList = new LinkedList<IconUnit>();
        public Form_main()
        {
            InitializeComponent();
            initialize_All();
        }
        /// <summary>
        /// 所有初始化
        /// </summary>
        void initialize_All()
        {
            //initialize_Config();
            
            //loadUserInfo();
        }
        /// <summary>
        /// 检查是否是第一位用户
        /// </summary>
        void loadUserInfo()
        {
            //userInfo = MyConfig.readUserInfo(User);
            /*
            string temp_pw = Password;
            string temp_su = ServerURL;
            string temp_ws = userInfo.SyncDirectory;
            string temp_n = User;
            */
        }
        /// <summary>
        /// 用于给登录窗体赋值
        /// </summary>
        /// <param name="user"></param>
        public void setForm2Value(string user)
        {
            User = user;
            toolStripMenuItem_setting_user_online.Text = user;
            loadUserInfo();
            initialize_Widget();
            initialize_GlobalVar();
            list_FileInCurrentDirectory();
            list_FileTree();
            /* 启动同步线程 */
            //TimeSlice = 4500;
            startSync(null, null);
        }
        /// <summary>
        /// 组件初始化
        /// </summary>
        void initialize_Widget()
        {
            this.FormClosing += new FormClosingEventHandler(notify_FormClosing);
            notifyIcon_main.DoubleClick += new EventHandler(notify_DoubleClick);
            openFileDialog_file.Multiselect = true;
            progressBar_transfer.Visible = false;
            listView_search.Visible = false;
            button_shut.Visible = false;
            /* 按钮交互事件 */
            toolStripMenuItem_synDir.Click += new EventHandler(set_WorkSpace);
            toolStripMenuItem_import.Click += new EventHandler(toolStrip_Import_Click);
            toolStripMenuItem_delete.Click += new EventHandler(deleteFile);
            toolStripMenuItem_mouse_delete.Click += new EventHandler(deleteFile);
            toolStripMenuItem_paste.Enabled = false;
            toolStripMenuItem_right_paste.Enabled = false;
            toolStripMenuItem_copy.Click += new EventHandler(copy_Click);
            toolStripMenuItem_cut.Click += new EventHandler(cut_Click);
            toolStripMenuItem_right_copy.Click += new EventHandler(copy_Click);
            toolStripMenuItem_right_cut.Click += new EventHandler(cut_Click);
            toolStripMenuItem_paste.Click += new EventHandler(paste_Click);
            toolStripMenuItem_right_paste.Click += new EventHandler(paste_Click);
            toolStripMenuItem_import_folder.Click += new EventHandler(toolStrip_ImportFolder_Click);
            toolStripMenuItem_export.Click += new EventHandler(export_File);
            toolStripMenuItem_selectAll.Click += new EventHandler(toolStrip_selectAll_Click);
            toolStripMenuItem_right_selectAll.Click += new EventHandler(toolStrip_selectAll_Click);
            toolStripMenuItem_right_rename.Click += new EventHandler(toolStrip_rename_Click);
            toolStripMenuItem_notifyIcon_showMainForm.Click += new EventHandler(notify_DoubleClick);
            toolStripMenuItem_notifyIcon_exit.Click += new EventHandler(notify_ExitApp);
            toolStripMenuItem_log_out.Click += new EventHandler(menuItem_logout_Click);
            toolStripMenuItem_change_user.Click += new EventHandler(menuItem_logout_Click);
            // 按钮事件
            button_back.Click += new EventHandler(btn_goBackClick);
            button_refresh.Click += new EventHandler(btn_refreshFileTree);
            button_gotoUpBound.Click += new EventHandler(btn_goUpBound_Click);
            button_search.Click += new EventHandler(btn_search_Click);
            button_shut.Click += new EventHandler(btn_shutSearchResult_Click);
            //button_go.Click += new EventHandler(btn_go_Click);
            /* 文件浏览视图 */
            listView_explorer.LargeImageList = imageList_file;
            listView_explorer.ContextMenuStrip = contextMenuStrip_listRightClick;
            listView_explorer.LabelEdit = true;
            listView_explorer.AfterLabelEdit += new LabelEditEventHandler(rename_event);
            listView_search.LargeImageList = imageList_file;
            listView_search.SmallImageList = imageList_file;
            listView_search.LabelEdit = true;
            /* 文件树视图 */
            treeView_explorer.ImageList = imageList_tree;
            try
            {
                imageList_file.Images.Add(Image.FromFile(MyConfig.FOLDER_ICON_PATH));
                imageList_file.Images.Add(Image.FromFile(MyConfig.FILE_ICON_PATH));
                imageList_tree.Images.Add(Image.FromFile(MyConfig.FOLDER_ICON_PATH));
                imageList_tree.Images.Add(Image.FromFile(MyConfig.FILE_ICON_PATH));
            }catch(Exception e)
            {
                MessageBox.Show("文件图标初始化失败!");
                Reporter.reportBug(e.ToString());
            }
        }
        /// <summary>
        /// 全局变量初始化
        /// </summary>
        void initialize_GlobalVar()
        {
            IconNameTable.Clear();
            IconName.Clear();
            //CURRENT_DIRECTORY = userInfo.SyncDirectory;// 初始化当前路径
            Path_Stack = new Stack<string>();
            Copy_File_Name = new Queue<string>();
            Copy_Directory_Name = new Queue<string>();
            textBox_currentDir.Text = CURRENT_DIRECTORY;
            /* 加载同步配置 */
            loadTimeStampConfig();
            /* 加载图标配置 */
            loadIconList();
        }
        /// <summary>
        /// 加载配置
        /// </summary>
        void initialize_Config()
        {
            try
            {
                /* 加载路径配置文件 */
                StreamReader configReader = new StreamReader(MyConfig.CONFIG_FILE_PATH, Encoding.Default);
                string line;
                int counter = 0;
                while((line = configReader.ReadLine()) != null)
                {
                    switch (counter)
                    {
                        case 0:
                            //userInfo.SyncDirectory = line;
                            break;
                        case 1:
                            TOOL_LOCATION = line;
                            break;
                    }
                    ++counter;
                }
                configReader.Close();
            }catch(Exception e)
            {
                MessageBox.Show("加载配置文件失败!");
                Reporter.reportBug(e.ToString());

            }
        }
        
        /// <summary>
        /// 选择同步路径
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void set_WorkSpace(object obj, EventArgs ea)
        {
            if(folderBrowserDialog_folder.ShowDialog() == DialogResult.OK)
            {
                string path_name = folderBrowserDialog_folder.SelectedPath;
                string[] content = new string[2];
                //content[0] = userInfo.SyncDirectory;
                content[1] = path_name;
                //MyConfig.saveConfig(MyConfig.CONFIG_FILE_PATH, content);
                MyConfig.createOrModifyUserDirectory(User, userInfo);
                initialize_All();
            }
        }
        /// <summary>
        /// 设置启动程序
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void set_Excuteion(object obj, EventArgs ea)
        {
            if (openFileDialog_file.ShowDialog() == DialogResult.OK)
            {
                string[] config = new string[2];
                //config[0] = userInfo.SyncDirectory;
                config[1] = openFileDialog_file.FileName;
                try
                {
                    //MyConfig.saveConfig(MyConfig.CONFIG_FILE_PATH, config);
                    initialize_All();// 刷新
                }catch(Exception e)
                {
                    MessageBox.Show("创建配置失败!");
                    Reporter.reportBug(e.ToString());
                }
            }
        }
        /// <summary>
        /// 显示工作目录文件和文件夹
        /// </summary>
        void list_FileInCurrentDirectory()
        {
            if(CURRENT_DIRECTORY == null)
            {
                MessageBox.Show("文件显示失败!");
                return;
            }
            imageList_file.ImageSize = new System.Drawing.Size(64, 64);
            listView_explorer.Clear();// 刷新
            listView_explorer.MouseDoubleClick += new MouseEventHandler(DoubleClick_toOpenFileByApp);
            listView_explorer.LargeImageList = imageList_file;
            listView_explorer.SmallImageList = imageList_file;
            try
            {
                DirectoryInfo currentFolder = new DirectoryInfo(CURRENT_DIRECTORY);
                DirectoryInfo[] dinfo = currentFolder.GetDirectories();
                FileInfo[] info = currentFolder.GetFiles();
                int counter = 0;
                while(counter < dinfo.Length)
                {
                    listView_explorer.SmallImageList = imageList_file;
                    listView_explorer.Items.Add(dinfo[counter].Name);
                    listView_explorer.Items[counter].ImageIndex = 0;
                    ++counter;
                }
                while(counter < dinfo.Length + info.Length)
                {
                    listView_explorer.SmallImageList = imageList_file;
                    listView_explorer.Items.Add(info[counter - dinfo.Length].Name);
                    // string extendName = Path.GetExtension(listView_explorer.Items[counter].Text);
                    if (IconNameTable.ContainsKey(Path.GetExtension(listView_explorer.Items[counter].Text).ToLower()))
                    {
                        listView_explorer.Items[counter].ImageIndex = (int) 
                            CodeAnalysis.getHashValue(Path.GetExtension(listView_explorer.Items[counter].Text).ToLower(), IconNameTable);
                    }
                    else
                    {
                        listView_explorer.Items[counter].ImageIndex = 1;
                    }
                    ++counter;
                }
            }catch(Exception e)
            {
                MessageBox.Show("文件显示异常!");
                Reporter.reportBug(e.ToString());
            }
        }
        /// <summary>
        /// 显示文件树
        /// </summary>
        void list_FileTree()
        {
            //if(userInfo.SyncDirectory == null)
            {
                MessageBox.Show("文件树显示失败!");
                return;
            }
            imageList_tree.ImageSize = new System.Drawing.Size(16, 16);
            treeView_explorer.Nodes.Clear();// 清空
            treeView_explorer.AfterSelect += new TreeViewEventHandler(TreeNode_Click);// 添加点击事件
            try
            {
                //DirectoryInfo currentFolder = new DirectoryInfo(userInfo.SyncDirectory);
                //DirectoryInfo[] rootInfo = currentFolder.GetDirectories();
                TreeNode baseNode = treeView_explorer.Nodes.Add("目录资源浏览");
                //TreeNode rootNode = new TreeNode(currentFolder.Name);
                //baseNode.Nodes.Add(rootNode);
                //rootNode.ImageIndex = 0;
                //rootNode.SelectedImageIndex = 0;
                //addTreeNode(rootInfo, currentFolder.GetFiles(), rootNode);
            }
            catch(Exception e)
            {
                MessageBox.Show("文件树显示异常");
                Reporter.reportBug(e.ToString());
            }
        }
        /// <summary>
        /// 构造树的节点
        /// </summary>
        void addTreeNode(DirectoryInfo[] dinfo, FileInfo[] finfo, TreeNode father)
        {
            if(dinfo.Length == 0 && finfo.Length == 0)
            {
                return;
            }
            int counter = 0;
            /* 增加目录 */
            while(counter < dinfo.Length)
            {
                TreeNode dnode = new TreeNode(dinfo[counter].Name);
                father.Nodes.Add(dnode);
                dnode.ImageIndex = 0;
                dnode.SelectedImageIndex = 0;
                DirectoryInfo[] dchild = dinfo[counter].GetDirectories();
                FileInfo[] fchild = dinfo[counter].GetFiles();
                addTreeNode(dchild, fchild, dnode);// 深度优先遍历
                ++counter;
            }
            /* 增加文件 */
            while(counter < dinfo.Length + finfo.Length)
            {
                TreeNode fnode = new TreeNode(finfo[counter - dinfo.Length].Name);
                father.Nodes.Add(fnode);
                if (IconNameTable.ContainsKey(Path.GetExtension(fnode.Text).ToLower()))
                {
                    fnode.ImageIndex = (int) 
                        CodeAnalysis.getHashValue(Path.GetExtension(fnode.Text).ToLower(), IconNameTable);
                    fnode.SelectedImageIndex = (int)
                        CodeAnalysis.getHashValue(Path.GetExtension(fnode.Text).ToLower(), IconNameTable);
                }
                else
                {
                    fnode.ImageIndex = 1;
                    fnode.SelectedImageIndex = 1;
                }
                ++counter;
            }
        }
        /// <summary>
        /// 文件树节点点击事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void TreeNode_Click(object obj, TreeViewEventArgs tvea)
        {
            if (tvea.Node.ImageIndex != 0) return;// 文件不做操作目录才操作
            /* 反向追踪目录 */
            TreeNode temp_node = @tvea.Node;
            string path_new = "";
            string temp_name;
            if (temp_node == null) return;
            while(temp_node.Text != treeView_explorer.Nodes[0].Nodes[0].Text)
            {
                temp_name = temp_node.Text;
                path_new = temp_name + @"\" + path_new;
                temp_node = temp_node.Parent;
            }
            Path_Stack.Push(CURRENT_DIRECTORY);
            //CURRENT_DIRECTORY = userInfo.SyncDirectory + path_new;
            textBox_currentDir.Text = CURRENT_DIRECTORY;
            string temp = CURRENT_DIRECTORY;
            string n = temp;
            list_FileInCurrentDirectory();// 重新显示文件
        }
        /// <summary>
        /// 导入文件事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void toolStrip_Import_Click(object obj, EventArgs ea)
        {
            if (openFileDialog_file.ShowDialog() == DialogResult.OK)
            {
                string[] file_name = openFileDialog_file.FileNames;
                progressBar_transfer.Visible = true;
                Application.DoEvents();
                progressBar_transfer.Maximum = file_name.Length;
                progressBar_transfer.Value = 0;
                for (int i = 0; i < file_name.Length; i++)
                {
                    file_name[i] = Path.GetFileName(file_name[i]);
                    /* 重名文件检查 */
                    while (File.Exists(CURRENT_DIRECTORY + file_name[i])) file_name[i] =
                            Path.GetFileNameWithoutExtension(file_name[i]) + "_副本" + Path.GetExtension(file_name[i]);
                    File.Copy(openFileDialog_file.FileName, CURRENT_DIRECTORY + file_name[i]);
                    progressBar_transfer.Value = i;
                    Application.DoEvents();
                }
                progressBar_transfer.Visible = false;
                list_FileInCurrentDirectory();
                list_FileTree();
            }
        }
        /// <summary>
        /// 导入文件夹事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void toolStrip_ImportFolder_Click(object obj, EventArgs ea)
        {
            if (folderBrowserDialog_folder.ShowDialog() == DialogResult.OK)
            {
                string dir_name = folderBrowserDialog_folder.SelectedPath;
                dir_name = Path.GetFileName(dir_name);
                /* 重名检查 */
                while (Directory.Exists(CURRENT_DIRECTORY + dir_name))
                    dir_name += "_副本";
                string[] fileList = System.IO.Directory.GetFileSystemEntries(folderBrowserDialog_folder.SelectedPath);
                CopyDir(folderBrowserDialog_folder.SelectedPath, CURRENT_DIRECTORY + dir_name, 0);
                progressBar_transfer.Visible = false;
                list_FileInCurrentDirectory();
                list_FileTree();
            }
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void deleteFile(object obj, EventArgs ea)
        {
            // 遍历当前目录被选中的文件
            int counter = 0;
            int check_counter = 0;
            progressBar_transfer.Visible = true;
            progressBar_transfer.Maximum = listView_explorer.Items.Count;
            progressBar_transfer.Value = 0;
            Application.DoEvents();
            while (counter < listView_explorer.Items.Count)
            {
                if (listView_explorer.Items[counter].Selected)
                {
                    if(listView_explorer.Items[counter].ImageIndex == 0)
                    {
                        // 删除文件夹，包括子目录
                        Directory.Delete(CURRENT_DIRECTORY + listView_explorer.Items[counter].Text, true);
                    }
                    else
                    {
                        // 删除文件
                        File.Delete(CURRENT_DIRECTORY + listView_explorer.Items[counter].Text);
                    }
                    ++check_counter;
                }
                ++counter;
                progressBar_transfer.Value = counter;
                Application.DoEvents();
            }
            progressBar_transfer.Visible = false;
            if (check_counter == 0)
            {
                MessageBox.Show("请选择要删除的文件或文件夹!");
            }
            else
            {
                list_FileInCurrentDirectory();
                list_FileTree();
            }
        }
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void DoubleClick_toOpenFileByApp(object obj, MouseEventArgs ea)
        {
            /* 遍历文件，查看点的是谁 */
            for(int i = 0;i < listView_explorer.Items.Count; i++)
            {
                if (listView_explorer.Items[i].Focused)
                {
                    if(listView_explorer.Items[i].ImageIndex == 0)
                    {
                        Path_Stack.Push(CURRENT_DIRECTORY);
                        CURRENT_DIRECTORY += listView_explorer.Items[i].Text + @"\";
                        textBox_currentDir.Text = CURRENT_DIRECTORY;
                        list_FileInCurrentDirectory();
                    }
                    else
                    {
                        try
                        {
                            Process.Start(Path.GetFullPath(CURRENT_DIRECTORY + listView_explorer.Items[i].Text));// 调用第三方应用打开文件
                            listView_explorer.Items[i].Focused = false;// 防止多次打开
                        }catch(Exception e)
                        {
                            MessageBox.Show("此文件无法打开!");
                            Reporter.reportBug(e.ToString());
                        }
                    }
                    break;
                }
            }
        }
        /// <summary>
        /// 返回前一个目录
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_goBackClick(object obj, EventArgs ea)
        {
            if(Path_Stack.Count == 0)
            {
                MessageBox.Show("已回到最初目录");
                return;
            }
            CURRENT_DIRECTORY = Path_Stack.Pop();
            textBox_currentDir.Text = CURRENT_DIRECTORY;
            list_FileInCurrentDirectory();
        }
        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void copy_Click(object obj, EventArgs ea)
        {
            /* 遍历文件，查看选中的是谁 */
            for (int i = 0; i < listView_explorer.Items.Count; i++)
            {
                if (listView_explorer.Items[i].Selected)
                {
                    if (listView_explorer.Items[i].ImageIndex == 0)
                    {
                        // 复制文件夹
                        Copy_Directory_Name.Enqueue(listView_explorer.Items[i].Text);
                    }
                    else
                    {
                        Copy_File_Name.Enqueue(listView_explorer.Items[i].Text);
                    }
                    Flag_CutTrue_CopyFalse = false;
                    toolStripMenuItem_paste.Enabled = true;
                    toolStripMenuItem_right_paste.Enabled = true;
                    Copy_Path = CURRENT_DIRECTORY;
                }
            }
        }
        /// <summary>
        /// 剪切文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void cut_Click(object obj, EventArgs ea)
        {
            /* 遍历文件，查看选中的是谁 */
            for (int i = 0; i < listView_explorer.Items.Count; i++)
            {
                if (listView_explorer.Items[i].Selected)
                {
                    if (listView_explorer.Items[i].ImageIndex == 0)
                    {
                        // 复制文件夹
                        Copy_Directory_Name.Enqueue(listView_explorer.Items[i].Text);
                    }
                    else
                    {
                        Copy_File_Name.Enqueue(listView_explorer.Items[i].Text);
                    }
                    Flag_CutTrue_CopyFalse = true;
                    toolStripMenuItem_paste.Enabled = true;
                    toolStripMenuItem_right_paste.Enabled = true;
                    Copy_Path = CURRENT_DIRECTORY;
                }
            }
        }
        /// <summary>
        /// 粘贴
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void paste_Click(object obj, EventArgs ea)
        {
            string temp_name;
            string temp_name2;
            progressBar_transfer.Visible = true;
            progressBar_transfer.Maximum = Copy_Directory_Name.Count + Copy_File_Name.Count;
            progressBar_transfer.Value = 0;
            Application.DoEvents();
            if (Flag_CutTrue_CopyFalse)
            {
                while(Copy_Directory_Name.Count > 0)
                {
                    temp_name = Copy_Directory_Name.Dequeue();
                    temp_name2 = temp_name;
                    /* 重名检查 */
                    for(int i = 0; i < listView_explorer.Items.Count; i++)
                    {
                        if (temp_name == listView_explorer.Items[i].Text)
                        {
                            while (Directory.Exists(CURRENT_DIRECTORY + temp_name2))
                            {
                                temp_name2 += "_副本";
                            }
                            break;
                        }
                    }
                    if(Copy_Path != CURRENT_DIRECTORY)Directory.Move(Copy_Path + temp_name, CURRENT_DIRECTORY + temp_name2);
                    ++progressBar_transfer.Value;
                    Application.DoEvents();
                }
                while(Copy_File_Name.Count > 0)
                {
                    temp_name = Copy_File_Name.Dequeue();
                    temp_name2 = temp_name;
                    /* 重名检查 */
                    for (int i = 0; i < listView_explorer.Items.Count; i++)
                    {
                        if (temp_name == listView_explorer.Items[i].Text)
                        {
                            while (File.Exists(CURRENT_DIRECTORY + temp_name2))
                            {
                                temp_name2 = Path.GetFileNameWithoutExtension(temp_name2) + "_副本" + Path.GetExtension(temp_name2);
                            }
                            break;
                        }
                    }
                    if (Copy_Path != CURRENT_DIRECTORY) File.Move(Copy_Path + temp_name, CURRENT_DIRECTORY + temp_name2);
                    ++progressBar_transfer.Value;
                    Application.DoEvents();
                }
            }
            else
            {
                while (Copy_Directory_Name.Count > 0)
                {
                    temp_name = Copy_Directory_Name.Dequeue();
                    temp_name2 = temp_name;
                    /* 重名检查 */
                    for (int i = 0; i < listView_explorer.Items.Count; i++)
                    {
                        if (temp_name == listView_explorer.Items[i].Text)
                        {
                            while (Directory.Exists(CURRENT_DIRECTORY + temp_name2))
                            {
                                temp_name2 += "_副本";
                            }
                            break;
                        }
                    }
                    CopyDir(Copy_Path + temp_name, CURRENT_DIRECTORY + temp_name2, 1);
                    ++progressBar_transfer.Value;
                    Application.DoEvents();
                }
                while (Copy_File_Name.Count > 0)
                {
                    temp_name = Copy_File_Name.Dequeue();
                    temp_name2 = temp_name;
                    /* 重名检查 */
                    for (int i = 0; i < listView_explorer.Items.Count; i++)
                    {
                        if (temp_name == listView_explorer.Items[i].Text)
                        {
                            while (File.Exists(CURRENT_DIRECTORY + temp_name2))
                            {
                                temp_name2 =
                                    Path.GetFileNameWithoutExtension(temp_name2) + "_副本" + Path.GetExtension(temp_name2);
                            }
                            break;
                        }
                    }
                    File.Copy(Copy_Path + temp_name, CURRENT_DIRECTORY + temp_name2);
                    ++progressBar_transfer.Value;
                    Application.DoEvents();
                }
            }
            progressBar_transfer.Visible = false;
            list_FileInCurrentDirectory();
            list_FileTree();
            toolStripMenuItem_paste.Enabled = false;
            toolStripMenuItem_right_paste.Enabled = false;
        }
        /// <summary>
        /// 刷新文件树
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_refreshFileTree(object obj, EventArgs ea)
        {
            list_FileTree();
        }
        /// <summary>
        /// 返回上层
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_goUpBound_Click(object obj, EventArgs ea)
        {
            //if(CURRENT_DIRECTORY == userInfo.SyncDirectory)
            {
                MessageBox.Show("已返回到最上层!");
                return;
            }
            for(int i = CURRENT_DIRECTORY.Length - 2; i >= 0; i--)
            {
                if(CURRENT_DIRECTORY.ToCharArray()[i] == '\\')
                {
                    CURRENT_DIRECTORY = CURRENT_DIRECTORY.Remove(i, CURRENT_DIRECTORY.Length - 1 - i);
                    list_FileInCurrentDirectory();
                    textBox_currentDir.Text = CURRENT_DIRECTORY;
                    break;
                }
            }
            
        }
        void export_File(object obj, EventArgs ea)
        {
            if (folderBrowserDialog_folder.ShowDialog() == DialogResult.OK)
            {
                string destination = folderBrowserDialog_folder.SelectedPath;
                if(destination.Length > 4)
                {
                    destination += @"\";
                }
                progressBar_transfer.Visible = true;
                progressBar_transfer.Maximum = listView_explorer.Items.Count;
                progressBar_transfer.Value = 0;
                Application.DoEvents();
                /* 遍历文件，查看选中的是谁 */
                for (int i = 0; i < listView_explorer.Items.Count; i++)
                {
                    if (listView_explorer.Items[i].Selected)
                    {
                        if (listView_explorer.Items[i].ImageIndex == 0)
                        {
                            // 文件夹
                            CopyDir(CURRENT_DIRECTORY + listView_explorer.Items[i].Text, destination + listView_explorer.Items[i].Text, 1);
                        }
                        else
                        {
                           File.Copy(CURRENT_DIRECTORY + listView_explorer.Items[i].Text, destination + listView_explorer.Items[i].Text);
                        }
                    }
                    progressBar_transfer.Value = i;
                    Application.DoEvents();
                }
                progressBar_transfer.Visible = false;
                MessageBox.Show("文件导出完毕!");
            }
        }
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void toolStrip_selectAll_Click(object obj, EventArgs ea)
        {
            for(int i = 0; i < listView_explorer.Items.Count; i++)
            {
                listView_explorer.Items[i].Selected = true;
            }
        }
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void toolStrip_rename_Click(object obj, EventArgs ea)
        {
            /* 遍历，查看选中的项目 */
            for (int i = 0; i < listView_explorer.Items.Count;i++)
            {
                if (listView_explorer.Items[i].Focused && listView_explorer.Items[i].Selected)
                {
                    RenameItemID = i;
                    Old_Name = listView_explorer.Items[i].Text;
                    listView_explorer.Items[i].BeginEdit();
                    listView_explorer.Items[i].Focused = false;
                    break;
                }
            }
        }
        /// <summary>
        /// 重命名事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="leea"></param>
        void rename_event(object obj, LabelEditEventArgs leea)
        {
            New_Name = leea.Label;
            if (listView_explorer.Items[RenameItemID].ImageIndex == 0)
            {
                // 文件夹
                // 检查重名
                if (Directory.Exists(CURRENT_DIRECTORY + New_Name))
                {
                    MessageBox.Show("存在同名文件夹!");
                    list_FileInCurrentDirectory();
                    return;
                }
                else
                {
                    Directory.Move(CURRENT_DIRECTORY + Old_Name, CURRENT_DIRECTORY + New_Name);
                    list_FileInCurrentDirectory();
                    list_FileTree();
                }
            }
            else
            {
                // 文件
                // 检查重名
                if (Directory.Exists(CURRENT_DIRECTORY + New_Name))
                {
                    MessageBox.Show("存在同名文件!");
                    list_FileInCurrentDirectory();
                    return;
                }
                else
                {
                    File.Move(CURRENT_DIRECTORY + Old_Name, CURRENT_DIRECTORY + New_Name);
                    list_FileInCurrentDirectory();
                    list_FileTree();
                }
            }
        }
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_search_Click(object obj, EventArgs ea)
        {
            string key = textBox_searchKey.Text;
            DirectoryInfo dinfo = new DirectoryInfo(CURRENT_DIRECTORY);
            DirectoryInfo[] subdinfo = dinfo.GetDirectories();
            FileInfo[] finfo = dinfo.GetFiles();
            progressBar_transfer.Visible = true;
            button_shut.Visible = true;
            progressBar_transfer.Maximum = subdinfo.Length + finfo.Length;
            progressBar_transfer.Value = 0;
            Application.DoEvents();
            listView_search.Clear();
            listView_search.Items.Add("搜索结果");
            for (int i = 0; i < subdinfo.Length; i++)
            {
                if (subdinfo[i].Name.Contains(key))
                {
                    listView_search.Items.Add(subdinfo[i].FullName);
                    listView_search.Items[listView_search.Items.Count - 1].ImageIndex = 0;
                }
                recurse_search(subdinfo[i], key);
                ++progressBar_transfer.Value;
                Application.DoEvents();
            }
            for (int i = 0; i < finfo.Length; i++)
            {
                if (finfo[i].Name.Contains(key))
                {
                    listView_search.Items.Add(finfo[i].FullName);
                    listView_search.Items[listView_search.Items.Count - 1].ImageIndex = 1;
                }
                ++progressBar_transfer.Value;
                Application.DoEvents();
            }
            progressBar_transfer.Visible = false;
            listView_search.Visible = true;
            listView_explorer.Visible = false;
            Application.DoEvents();
        }
        /// <summary>
        /// 递归搜索
        /// </summary>
        void recurse_search(DirectoryInfo dinfo, string key)
        {
            DirectoryInfo[] subdinfo = dinfo.GetDirectories();
            FileInfo[] finfo = dinfo.GetFiles();
            for (int i = 0; i < subdinfo.Length; i++)
            {
                if (subdinfo[i].Name.Contains(key))
                {
                    listView_search.Items.Add(subdinfo[i].FullName);
                    listView_search.Items[listView_search.Items.Count - 1].ImageIndex = 0;
                }
                recurse_search(subdinfo[i], key);
            }
            for (int i = 0; i < finfo.Length; i++)
            {
                if (finfo[i].Name.Contains(key))
                {
                    listView_search.Items.Add(finfo[i].FullName);
                    listView_search.Items[listView_search.Items.Count - 1].ImageIndex = 1;
                }
            }
            
        }
        /// <summary>
        /// 关闭搜索结果
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_shutSearchResult_Click(object obj, EventArgs ea)
        {
            listView_search.Visible = false;
            button_shut.Visible = false;
            listView_explorer.Visible = true;
        }
        /// <summary>
        /// 前往指定目录
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        /// 
        /*
        void btn_go_Click(object obj, EventArgs e)
        {
            try
            { 
                
                //if(!textBox_currentDir.Text.Contains(userInfo.SyncDirectory))
                {
                    MessageBox.Show("目录必须在工作目录内!");
                    return;
                } 
                
                else
                {
                    CURRENT_DIRECTORY = textBox_currentDir.Text;
                    list_FileInCurrentDirectory();
                }
            }catch(Exception ec)
            {
                MessageBox.Show("无效的目录!");
                Reporter.reportBug(e.ToString());
            }
        }
        */
        /// <summary>
        /// 复制文件夹
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="aimPath"></param>
        void CopyDir(string srcPath, string aimPath, int depth)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加
                if (aimPath[aimPath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                {
                    aimPath += System.IO.Path.DirectorySeparatorChar;
                }
                string destination = aimPath;
                // 重名检查
                while (Directory.Exists(destination))
                    destination += "_副本";
                //if(!Directory.Exists(aimPath))System.IO.Directory.CreateDirectory(aimPath);
                if(!Directory.Exists(destination))
                    System.IO.Directory.CreateDirectory(destination);
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                // string[] fileList = Directory.GetFiles（srcPath）；
                string[] fileList = System.IO.Directory.GetFileSystemEntries(srcPath);
                if(depth == 0)
                {
                    progressBar_transfer.Visible = true;
                    progressBar_transfer.Maximum = fileList.Length;
                    progressBar_transfer.Value = 0;
                    Application.DoEvents();
                }
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    // 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                    /* 重名检查 */
                    string file_new = Path.GetFileName(file);
                    if (System.IO.Directory.Exists(file))
                    {
                        CopyDir(file, destination + file_new, depth + 1);
                    }
                    // 否则直接Copy文件
                    else
                    {
                        while (Directory.Exists(destination + file_new))
                            file_new = Path.GetFileNameWithoutExtension(file_new) + "_副本" + Path.GetExtension(file_new);
                        System.IO.File.Copy(file, destination + file_new, true);
                    }
                    if (depth == 0)
                    {
                        ++progressBar_transfer.Value; ;
                        Application.DoEvents();
                    }
                }
                if (depth == 0) progressBar_transfer.Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("文件传输失败!");
                Reporter.reportBug(e.ToString());
            }
        }
        /// <summary>
        /// 点击"x"隐藏窗口
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void notify_FormClosing(object obj, FormClosingEventArgs fcea)
        {
            fcea.Cancel = true;
            this.Visible = false;
        }
        void notify_FormClosing2(object obj, FormClosingEventArgs fcea)
        {
            fcea.Cancel = false;
        }
        /// <summary>
        /// 双击托盘图标还原窗口
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void notify_DoubleClick(object obj, EventArgs ea)
        {
            this.Visible = true;
            this.FormClosing += new FormClosingEventHandler(notify_FormClosing);
        }
        /// <summary>
        /// 退出应用
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void notify_ExitApp(object obj, EventArgs ea)
        {
            endSync(null, null);// 停止同步
            this.FormClosing += new FormClosingEventHandler(notify_FormClosing2);
            Application.Exit();
        }
        /// <summary>
        /// sync by using CMD
        /// </summary>
        void syncCMD()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序
            p.StandardInput.WriteLine("cd tool" + "\n");
            p.StandardInput.Flush();
            //string str = "tool " + User + " " + Password + " " + Path.GetFullPath(userInfo.SyncDirectory) + " " + ServerURL;
            //string str = "sync --user " + User + " --password " + userInfo.Password + " " + Path.GetFullPath(userInfo.SyncDirectory) + " " + userInfo.ServerURI;
            //string temp_str = str;
            //string temp_str2 = str;
            //向cmd窗口发送输入信息
            //p.StandardInput.WriteLine(str + "\n");
            p.StandardInput.Flush();
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令
            //获取cmd窗口的输出信息
            //string output = p.StandardOutput.ReadLine();
            //Console.WriteLine(output);
            //p.WaitForExit(TimeSlice / 4);//等待程序执行完退出进程
            p.Close();
            // 可以使用Trust命令进行同步
        }
        /// <summary>
        /// sync button event
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void startSync(object obj, EventArgs ea)
        {
            ThreadSync = new Thread(thread_to_sync);
            ThreadSync.Start();
        }
        /// <summary>
        /// button unsync event
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void endSync(object obj, EventArgs ea)
        {
            if (ThreadSync != null)
            {
                ThreadSync.Abort();
                ThreadSync = null;
            }
        }
        /// <summary>
        /// sync thread
        /// </summary>
        void thread_to_sync()
        {
            try
            {
                while (true)
                {
                    //Thread.Sleep(TimeSlice);
                    syncCMD();
                    //if (ThreadSyncSub != null) ThreadSyncSub.Abort();
                    Thread.Sleep(TimeSlice);
                }
            }
            catch (Exception e)
            {
                //EventLog.CreateEventSource(e.ToString(), "syncthread");
                Reporter.reportBug(e.ToString());
            }
        }
        /// <summary>
        /// 加载同步时间戳
        /// </summary>
        void loadTimeStampConfig()
        {
            try
            {
                StreamReader time_stamp_Reader = new StreamReader(MyConfig.SYNC_CONF_PATH, Encoding.Default);
                string line;
                while((line = time_stamp_Reader.ReadLine()) != null)
                {
                    if(CodeAnalysis.getCommandString(line) == MyConfig.KEY_WORD_TIME_STAMP)
                    {
                        TimeSlice = int.Parse(CodeAnalysis.getValueString(line)[0]);
                    }
                }
                time_stamp_Reader.Close();
            }catch(Exception e)
            {
                MessageBox.Show("加载同步配置失败!");
                Reporter.reportBug(e.ToString());
            }
        }
        /// <summary>
        /// 加载图标列表
        /// </summary>
        void loadIconList()
        {
            try
            {
                StreamReader IconListReader = new StreamReader(MyConfig.ICON_CONF_PATH, Encoding.Default);
                string line;
                IconList.Clear();
                int imageindex = 1;
                while((line = IconListReader.ReadLine()) != null)
                {
                    IconUnit temp = new IconUnit();
                    temp.ExtendName = CodeAnalysis.getCommandString(line);
                    temp.IconPath = CodeAnalysis.getValueString(line)[0];
                    IconList.AddLast(temp);
                    IconNameTable.Add(temp.ExtendName, ++imageindex);
                    IconName.AddLast(temp.ExtendName);
                    /* 遍历图标目录下所有的图标，并添加到imagelist中 */
                    imageList_file.Images.Add(Image.FromFile(Path.GetFullPath(MyConfig.ICON_LIB_PATH + temp.IconPath)));
                    imageList_tree.Images.Add(Image.FromFile(Path.GetFullPath(MyConfig.ICON_LIB_PATH + temp.IconPath)));
                }
                IconListReader.Close();
                
            }catch(Exception e)
            {
                MessageBox.Show("加载图标配置失败!");
                Reporter.reportBug(e.ToString());
            }
        }
        /// <summary>
        /// 注销事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void menuItem_logout_Click(object obj, EventArgs ea)
        {
            endSync(null, null);// 停止同步
            this.FormClosing += new FormClosingEventHandler(notify_FormClosing2);
            Application.Restart();
        }
    }
}

