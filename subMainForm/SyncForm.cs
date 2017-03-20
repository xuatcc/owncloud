using custom_cloud.IOClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace custom_cloud
{
    public partial class SyncForm : Form
    {
        /// <summary>
        /// 列表头1，显示同步中的文件名
        /// </summary>
        protected ColumnHeader ListFileNameHeader = new ColumnHeader();
        /// <summary>
        /// 列表头3，显示文件同步状态
        /// </summary>
        protected ColumnHeader ListFileStatusHeader = new ColumnHeader();
        /// <summary>
        /// 列表头2，显示修改文件变动类型
        /// </summary>
        protected ColumnHeader ListFileModifyType = new ColumnHeader();
        /// <summary>
        /// 列表头4，显示文件修改时间
        /// </summary>
        protected ColumnHeader ListFileModifyTime = new ColumnHeader();
        /// <summary>
        /// 用户本地信息
        /// </summary>
        protected UserLocalInfo User_LocalInfo;

        const string NO_EVENT = "nothing";
        const string INITIATING = "initiating";
        const string UNSYNCED = "unsynced";
        /// <summary>
        /// 用于标记窗体是否刚刚启动
        /// </summary>
        bool Flag_isInitiation = true;
        /// <summary>
        /// 文件同步状态哈希表
        /// </summary>
        protected Dictionary<string, bool> Dict_FileSynced = new Dictionary<string, bool>();
        public SyncForm()
        {
            InitializeComponent();
            
        }

        private void SyncForm_SizeChanged(object sender, EventArgs e)
        {
            listView_syncStatus.Width = this.Width;
            listView_syncStatus.Height = this.Height;
        }
        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="userLocalInfo"></param>
        public void setInfo(UserLocalInfo userLocalInfo)
        {
            User_LocalInfo = userLocalInfo;
            initializeConfig();
            initializeWidget();
        }
        /// <summary>
        /// 初始化配置
        /// </summary>
        protected void initializeConfig()
        {
            if (User_LocalInfo != null)
            {
                if (!string.IsNullOrEmpty(User_LocalInfo.SyncPath))
                { 
                    fileSystemWatcher_main.Path = User_LocalInfo.SyncPath;
                    fileSystemWatcher_main.EnableRaisingEvents = true;
                }
            }
        }
        /// <summary>
        /// 初始化控件
        /// </summary>
        protected void initializeWidget()
        {
            ListFileNameHeader.Text = "文件路径";
            ListFileNameHeader.Width = (int)(listView_syncStatus.Width * 0.5);
            ListFileNameHeader.TextAlign = HorizontalAlignment.Center;
            ListFileModifyType.Text = "事件";
            ListFileModifyType.Width = (int)(listView_syncStatus.Width * 0.1);
            ListFileModifyType.TextAlign = HorizontalAlignment.Center;
            ListFileStatusHeader.Text = "同步状态";
            ListFileStatusHeader.Width = (int)(listView_syncStatus.Width * 0.1);
            ListFileStatusHeader.TextAlign = HorizontalAlignment.Center;
            ListFileModifyTime.Text = "时间";
            ListFileModifyTime.Width = listView_syncStatus.Width - ListFileModifyType.Width - ListFileNameHeader.Width - ListFileStatusHeader.Width;
            ListFileModifyTime.TextAlign = HorizontalAlignment.Center;

            listView_syncStatus.Columns.Add(ListFileNameHeader);
            listView_syncStatus.Columns.Add(ListFileModifyType);
            listView_syncStatus.Columns.Add(ListFileStatusHeader);
            listView_syncStatus.Columns.Add(ListFileModifyTime);

            listView_syncStatus.GridLines = true;
        }
        /// <summary>
        /// 刷新文件列表
        /// </summary>
        public void refreshFileList(string path, string syncPath)
        {
            if (!Directory.Exists(path)) return;
            //if (path.Equals(syncPath)) listView_syncStatus.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] sub_dia = di.GetDirectories();
            FileInfo[] fia = di.GetFiles();
            foreach(FileInfo fi in fia)
            {
                if (!Path.GetExtension(fi.Name).Equals(MyConfig.EXTEND_NAME_ENCRYP_FILE)) continue;

                ListViewItem lvi = new ListViewItem();
                lvi.Text = (@"Home:\" + fi.FullName.Substring(Path.GetFullPath(syncPath).Length));
                if (listView_syncStatus.Items.ContainsKey(lvi.Text)) continue;
                lvi.Name = lvi.Text;
                lvi.SubItems.Add(INITIATING);
                lvi.SubItems.Add("正在检测");
                lvi.SubItems[2].ForeColor = Color.Blue;
                lvi.SubItems.Add(fi.LastWriteTime.ToString());
                /* 增加新项目 */
                listView_syncStatus.Items.Add(lvi);
            }
            /* 防止操作系统认为程序无响应 */
            Application.DoEvents();
            foreach(DirectoryInfo sub_di in sub_dia)
            {
                refreshFileList(sub_di.FullName, syncPath);
            }
        }
        /// <summary>
        /// 设置文件同步状态
        /// </summary>
        /// <param name="queue"></param>
        public void setFileStatus(Queue<string> queue, SyncResult.FileSyncStatus status)
        {
            Reporter.writeLog("./log/file_synced.log", "synced");
            string fileName;
            if (status == SyncResult.FileSyncStatus.Success) {
                while (queue.Count > 0)
                {
                    fileName = queue.Dequeue();
                    if (listView_syncStatus.Items.ContainsKey(fileName))
                    {
                        if (listView_syncStatus.Items[fileName].SubItems[1].Text.Equals(NO_EVENT)) continue;
                        listView_syncStatus.Items[fileName].SubItems[1].Text = NO_EVENT;
                        listView_syncStatus.Items[fileName].SubItems[2].Text = "同步完成";
                        listView_syncStatus.Items[fileName].SubItems[2].ForeColor = Color.Green;
                        listView_syncStatus.Items[fileName].SubItems[3].Text = DateTime.Now.ToString();
                    }
                }
            }
            else
            {
                foreach (ListViewItem lvi in listView_syncStatus.Items)
                {
                    if (lvi.SubItems[1].Text.Equals(NO_EVENT)) continue;
                    lvi.SubItems[1].Text = UNSYNCED;
                    lvi.SubItems[2].Text = "同步失败";
                    lvi.SubItems[2].ForeColor = Color.Red;
                    lvi.SubItems[3].Text = DateTime.Now.ToString();
                }
            }
        }
        /// <summary>
        /// 更新列表
        /// </summary>
        protected void refreshListFSE(System.IO.FileSystemEventArgs fse)
        {
            listView_syncStatus.Invoke(new MethodInvoker(delegate
            {
                if (User_LocalInfo == null) return;
                string itemText = (@"Home:\" + Path.GetFullPath(fse.FullPath).Substring(Path.GetFullPath(User_LocalInfo.SyncPath).Length));
                if (!listView_syncStatus.Items.ContainsKey(itemText)) return;
                if (!fse.ChangeType.Equals(WatcherChangeTypes.Deleted))
                {
                    listView_syncStatus.Items[itemText].SubItems[1].Text = fse.ChangeType.ToString();
                    listView_syncStatus.Items[itemText].SubItems[2].Text = "正在检测";
                    listView_syncStatus.Items[itemText].SubItems[2].ForeColor = Color.Blue;
                }
                else
                {
                    /* 删除项目 */
                    if(listView_syncStatus.Items.ContainsKey(itemText))listView_syncStatus.Items.RemoveByKey(itemText);
                }
            }));
        }
        /// <summary>
        /// 更新列表
        /// </summary>
        protected void refreshListFSE(System.IO.RenamedEventArgs re)
        {
            listView_syncStatus.Invoke(new MethodInvoker(delegate
            {
                if (User_LocalInfo == null) return;
                string itemText = (@"Home:\" + Path.GetFullPath(re.OldFullPath).Substring(Path.GetFullPath(User_LocalInfo.SyncPath).Length));
                if (!listView_syncStatus.Items.ContainsKey(itemText)) return;
                listView_syncStatus.Items[itemText].SubItems[1].Text = re.ChangeType.ToString();
                listView_syncStatus.Items[itemText].SubItems[2].Text = "正在检测";
                listView_syncStatus.Items[itemText].SubItems[2].ForeColor = Color.Blue;
                listView_syncStatus.Items[itemText].Text= (@"Home:\" + Path.GetFullPath(re.FullPath).Substring(Path.GetFullPath(User_LocalInfo.SyncPath).Length));
                listView_syncStatus.Items[itemText].Name = listView_syncStatus.Items[itemText].Text;
            }));
        }
        /// <summary>
        /// 当目录下的文件发生改变时，执行此操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemWatcher_sync_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            refreshListFSE(e);
        }

        private void fileSystemWatcher_sync_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            //refreshListFSE(e);
        }

        private void fileSystemWatcher_sync_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            refreshListFSE(e);
        }

        private void fileSystemWatcher_sync_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            refreshListFSE(e);
        }

        private void listView_syncStatus_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }

        private void listView_syncStatus_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.DrawText();
        }

        private void listView_syncStatus_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawBackground();
            //e.DrawFocusRectangle();
            e.DrawText();
        }
    }
}
