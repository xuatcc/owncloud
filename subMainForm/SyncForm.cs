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
            if (path.Equals(syncPath)) listView_syncStatus.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] sub_dia = di.GetDirectories();
            FileInfo[] fia = di.GetFiles();
            foreach(FileInfo fi in fia)
            {
                if (!Path.GetExtension(fi.Name).Equals(MyConfig.EXTEND_NAME_ENCRYP_FILE)) continue;
                ListViewItem lvi = new ListViewItem();
                lvi.Text = (@"Home:\" + fi.FullName.Substring(Path.GetFullPath(syncPath).Length));
                lvi.Name = lvi.Text;
                lvi.SubItems.Add("");
                lvi.SubItems.Add("正在检测");
                lvi.SubItems[2].ForeColor = Color.Blue;
                lvi.SubItems.Add(fi.LastWriteTime.ToString());
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
                /*
                ListViewItem lvi = new ListViewItem();
                lvi.Text = (@"Home:\" + fse.FullPath.Substring(Path.GetFullPath(User_LocalInfo.SyncPath).Length));
                lvi.SubItems.Add(fse.ChangeType.ToString());
                lvi.SubItems.Add("未同步");
                lvi.SubItems.Add(DateTime.Now.ToString());
                listView_syncStatus.Items.Add(lvi);
                */
                //listView_syncStatus.Items.Add()
            }));
        }
        /// <summary>
        /// 更新列表
        /// </summary>
        protected void refreshListFSE(System.IO.RenamedEventArgs re)
        {
            listView_syncStatus.Invoke(new MethodInvoker(delegate
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = (@"Home:\" + re.FullPath.Substring(Path.GetFullPath(User_LocalInfo.SyncPath).Length));
                lvi.SubItems.Add(re.ChangeType.ToString());
                lvi.SubItems.Add("未同步");
                lvi.SubItems.Add(DateTime.Now.ToString());
                listView_syncStatus.Items.Add(lvi);
                //listView_syncStatus.Items.Add()
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
            refreshListFSE(e);
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
