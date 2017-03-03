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
                        if (full_content.Contains(Order._ORDER_LOG_OUT))
                        {
                            MethodInvoker methodInvoker = new MethodInvoker(logOutSuccess);
                            BeginInvoke(methodInvoker);
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
        /// <summary>
        /// 退出窗体时要注意关闭连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UtilityLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ThreadTimer != null) ThreadTimer.Abort();
            if (netHelper.SocketClient.Connected) netHelper.stopConnection();
        }
    }
}
