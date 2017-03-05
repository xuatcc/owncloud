using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace custom_cloud.loadingForm
{
    /// <summary>
    /// 通用等待界面
    /// </summary>
    public partial class UtilityLoading : Form
    {
        /* 静态类 */
        /// <summary>
        /// 状态标签
        /// </summary>
        public string StatusText
        {
            set
            {
                label_status.Text = value;
                /* 调整状态标签位置，使其居中 */
                int picBox_X = pictureBox_wait.Location.X;
                int picBoxWidth = pictureBox_wait.Width / 2;
                int labelWidth = label_status.Width / 2;
                label_status.SetBounds(picBox_X + picBoxWidth - labelWidth, label_status.Location.Y, label_status.Width, label_status.Height);
            }
        }
        /// <summary>
        /// 按钮文本
        /// </summary>
        public string ButtonText
        {
            set { button_cancel.Text = value; }
        }
        /// <summary>
        /// 网络辅助
        /// </summary>
        NetHelper netHelper;
        /// <summary>
        /// 计时器线程
        /// </summary>
        Thread ThreadTimer;
        /// <summary>
        /// 通用线程
        /// </summary>
        Thread ThreadUtility;
        /// <summary>
        /// 通用列表
        /// </summary>
        ListView ListViewUtility;
        /// <summary>
        /// 通用文件树
        /// </summary>
        FileTree FileTreeUtility;
        /// <summary>
        /// 通用关键字
        /// </summary>
        string KeyUtility;
        /// <summary>
        /// 通用大图标列表
        /// </summary>
        ImageList ImageListLargeUtility;
        /// <summary>
        /// 通用小图标列表
        /// </summary>
        ImageList ImageListSmallUtility;
        /// <summary>
        /// 大图标库
        /// </summary>
        Dictionary<string, Image> LargeIconDict;
        /// <summary>
        /// 小图标库
        /// </summary>
        Dictionary<string, Image> SmallIconDict;
        Image LargeFolderIcon;
        Image SmallFolderIcon;
        Image LargeDefaultFileIcon;
        Image SmallDefaultFileIcon;
        public UtilityLoading()
        {
            InitializeComponent();
            initializeWidget();
        }
        void initializeWidget()
        {
            label_status.BackColor = Color.Transparent;
        }
        /// <summary>
        /// 鼠标移入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void btn_MouseEnter_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_cancel)) button_cancel.Image = Properties.Resources.enter;
        }
        /// <summary>
        /// 鼠标移出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void btn_MouseLeave_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_cancel)) button_cancel.Image = Properties.Resources.down;
        }
        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void btn_Click_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_cancel)) logOutFail();
        }
        #region search items
        /// <summary>
        /// 根据关键字搜索文件
        /// </summary>
        /// <param name="totalTree"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public void functionSearchItems(FileTree totalTree, string key, ref ListView listView, ref ImageList imageListLarge, ref ImageList imageListSmall, Dictionary<string, Image> largeIconDict, Dictionary<string, Image> smallIconDict)
        {
            /* 传值 */
            FileTreeUtility = totalTree;
            KeyUtility = key;
            LargeIconDict = largeIconDict;
            SmallIconDict = smallIconDict;
            /* 传地址 */
            ListViewUtility = listView;
            ImageListLargeUtility = imageListLarge;
            ImageListSmallUtility = imageListSmall;
            /* 初始化列表和图片列表 */
            LargeFolderIcon = Image.FromFile(MyConfig.LARGE_FOLDER_ICON_PATH);
            SmallFolderIcon = Image.FromFile(MyConfig.SMALL_FOLDER_ICON_PATH);
            LargeDefaultFileIcon = Image.FromFile(MyConfig.LARGE_DEFAULT_FILE_ICON_PATH);
            SmallDefaultFileIcon = Image.FromFile(MyConfig.SMALL_DEFAULT_FILE_ICON_PATH);
            ListViewUtility.Items.Clear();
            ImageListLargeUtility.Images.Clear();
            ImageListSmallUtility.Images.Clear();
            /* 开始搜索线程 */
            ThreadUtility = new Thread(threadSearchItems);
            ThreadUtility.Start();
        }
        /// <summary>
        /// 递归搜索
        /// </summary>
        /// <param name="fileTree"></param>
        /// <param name="key"></param>
        /// <param name="listView"></param>
        void recursiveSearch(FileTree fileTree, string key)
        {
            /* 检索文件 */
            foreach(FileTree.TreeFileInfo tfi in fileTree.CurrentDirectoryFileList.Values)
            {
                if (tfi.FileName.ToLower().Contains(key.ToLower()))
                {
                    string fileName = tfi.FilePath;
                    /* 大图标注意判断文件是否为图片 */
                    ListViewUtility.Invoke(new MethodInvoker(delegate
                    {
                        if (CodeAnalysis.IsImage(tfi.FilePath))
                        {
                            Image image = Int32Dec64Convert.ConverToSquareBitmap(ImageListLargeUtility.ImageSize.Width, Image.FromFile(tfi.FilePath));
                            ImageListLargeUtility.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), image);
                        }
                        else if (LargeIconDict.ContainsKey(tfi.ExtendName)) ImageListLargeUtility.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), Int32Dec64Convert.ConverToSquareBitmap(ImageListLargeUtility.ImageSize.Width, LargeIconDict[tfi.ExtendName]));
                        else ImageListLargeUtility.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), Int32Dec64Convert.ConverToSquareBitmap(ImageListLargeUtility.ImageSize.Width, LargeDefaultFileIcon));

                        if (SmallIconDict.ContainsKey(tfi.ExtendName)) ImageListSmallUtility.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), Int32Dec64Convert.ConverToSquareBitmap(ImageListSmallUtility.ImageSize.Width, SmallIconDict[tfi.ExtendName]));
                        else ImageListSmallUtility.Images.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), Int32Dec64Convert.ConverToSquareBitmap(ImageListSmallUtility.ImageSize.Width, SmallDefaultFileIcon));

                    
                        ListViewUtility.Items.Add(MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName), tfi.FileName, MyConfig.getListKeyName(FileTree.FILE_IDENTIFY_NAME, fileName));
                        Application.DoEvents();
                    }));
                    
                }
            }
            /* 检索文件夹 */
            foreach(FileTree ft in fileTree.SubTree.Values)
            {
                if (ft.RootDirectory.Name.ToLower().Contains(key.ToLower()))
                {
                    string directoryPath = ft.RootDirectory.FullName;
                    ListViewUtility.Invoke(new MethodInvoker(delegate
                    {
                        ImageListLargeUtility.Images.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, directoryPath),
                        Int32Dec64Convert.ConverToSquareBitmap(ImageListLargeUtility.ImageSize.Width, LargeFolderIcon));
                        ImageListSmallUtility.Images.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, directoryPath),
                        Int32Dec64Convert.ConverToSquareBitmap(ImageListSmallUtility.ImageSize.Width, SmallFolderIcon));
                    
                        ListViewUtility.Items.Add(MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, directoryPath), ft.RootDirectory.Name, MyConfig.getListKeyName(FileTree.FOLDER_IDENTIFY_NAME, directoryPath));
                        Application.DoEvents();
                    }));
                    
                }
                /* 递归 */
                recursiveSearch(ft, key);
            }
        }
        /// <summary>
        /// 搜索线程
        /// </summary>
        void threadSearchItems()
        {
            try
            {
                Thread.Sleep(200);
                recursiveSearch(FileTreeUtility, KeyUtility);
            }
            catch(Exception e)
            {
                Reporter.reportBug(e.ToString());
            }
            /* 检索结束 */
            MethodInvoker methodInvoker = new MethodInvoker(logOutFail);
            BeginInvoke(methodInvoker);
        }
        #endregion
        #region Logout
        /// <summary>
        /// 功能-注销
        /// </summary>
        public void functionLogout(UserInfo userInfo)
        {
            /* 建立与服务器的连接 */
            initializeNetWork(userInfo.ServerURI, userInfo.ServerPort);
            UserInfo user_info = userInfo;
            user_info.Order = Order._ORDER_LOG_OUT;
            /* 发送注销报文 */
            netHelper.sendJsonBlock(user_info);
            /* 启动计时 */
            ThreadTimer = new Thread(thread_Timer);
            ThreadTimer.Start();
        }
        /// <summary>
        /// 注销成功
        /// </summary>
        void logOutSuccess()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// 注销失败
        /// </summary>
        void logOutFail()
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        #endregion
        #region NetWork
        /// <summary>
        /// 初始化网络
        /// </summary>
        void initializeNetWork(string serverURI, int port)
        {
            netHelper = new NetHelper();
            netHelper.setCallBack(receiveCallBack);
            netHelper.startConnection(serverURI, port);
            netHelper.beginReceiveCallBack();
            Thread.Sleep(200);
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        void disposeNetwork()
        {
            netHelper.stopConnection();
        }
        /// <summary>
        /// 计时线程
        /// </summary>
        void thread_Timer()
        {
            try
            {
                int TimeToLive = 15000;
                int time_clock = 0;
                int time_step = 100;
                while (time_clock < TimeToLive)
                {
                    time_clock += time_step;
                    Thread.Sleep(time_step);
                }
                /* 超时操作 */
                MethodInvoker methodInvoker = new MethodInvoker(logOutFail);
                BeginInvoke(methodInvoker);
            }
            catch (Exception e)
            {
                Reporter.reportBug(e.ToString());
            }
        }
        /// <summary>
        /// 收到消息后的处理
        /// </summary>
        /// <param name="iar"></param>
        void receiveCallBack(IAsyncResult iar)
        {
            try
            {
                int REnd = netHelper.SocketClient.EndReceive(iar);
                string receive_content = Encoding.UTF8.GetString(netHelper.msgByte, 0, REnd);
                string full_content = "";
                if (!string.IsNullOrEmpty(receive_content) && receive_content != "")
                {
                    Reporter.writeLog(MyConfig.PATH_NET_LOG, "login : " + receive_content);
                    //Thread.Sleep(2);
                    if (receive_content.Contains(Order.FLAG_START))
                    {
                        netHelper.flag_fullReceive = false;
                        netHelper.receiveBuffer = new Queue<string>();
                    }
                    if (!receive_content.Contains(Order.FLAG_START) && !receive_content.Contains(Order.FLAG_STOP))
                    {
                        netHelper.receiveBuffer.Enqueue(receive_content);
                    }
                    if (receive_content.Contains(Order.FLAG_STOP))
                    {

                        while (netHelper.receiveBuffer.Count > 0)
                        {
                            full_content += netHelper.receiveBuffer.Dequeue();
                        }
                        Hashtable hashtable = JsonHelper.getDeserializeObject<Hashtable>(full_content);
                        if (hashtable != null)
                        {
                            if (hashtable.ContainsKey("log_out"))
                            {
                                bool result = (bool)hashtable["log_out"];
                                if (result)
                                {
                                    MethodInvoker methodInvoker = new MethodInvoker(logOutSuccess);
                                    BeginInvoke(methodInvoker);
                                }
                            }
                        }
                    }
                    netHelper.beginReceiveCallBack();
                }

            }
            catch (Exception e)
            {
                Reporter.reportBug(e.ToString());
            }
        }
        #endregion
        #region 更改用户信息
        public void functionModifyUserInfo(UserInfo userInfo)
        {

        }
        #endregion
        /// <summary>
        /// 退出窗体时要注意关闭连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UtilityLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ThreadTimer != null) ThreadTimer.Abort();
            if (ThreadUtility != null) ThreadUtility.Abort();
            if (netHelper != null)
            {
                if (netHelper.SocketClient.Connected) netHelper.stopConnection();
            }
        }
    }
}
