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

namespace custom_cloud
{
    public partial class LoadingForm : Form
    {
        NetHelper netHelper = new NetHelper();
        public string userID;
        public string Password;
        public int serverPort;
        public string serverURI;
        public UserInfo User_Info = new UserInfo();
        int TimeToLive = 15000;
        Thread Timer;
        public LoadingForm()
        {
            InitializeComponent();
            initializeWidget();
        }
        void initializeWidget()
        {
            label_status.Parent = this;
            label_status.BackColor = Color.Transparent;
            label_status.ForeColor = MyConfig.SelectedColor;

            pictureBox_wait.BackColor = Color.Transparent;
            pictureBox_wait.Parent = this;
        }
        /// <summary>
        /// 计时线程
        /// </summary>
        void thread_Timer()
        {
            try
            {
                int time_clock = 0;
                int time_step = 100;
                while (time_clock < TimeToLive)
                {
                    time_clock += time_step;
                    Thread.Sleep(time_step);
                }
                lock (User_Info)
                {
                    User_Info.login_result = false;
                    User_Info.error_code = ErrorCode.ERROR_CODE_CONNECT_TIMEOUT;
                }
                MethodInvoker methodInvokeNavigation = new MethodInvoker(navigateToLoginWindow);
                BeginInvoke(methodInvokeNavigation);
            }
            catch (Exception e)
            {
                Reporter.reportBug(e.ToString());
            }
        }
        /// <summary>
        /// 设置信息
        /// </summary>
        public void setInfo(string user_id, string password, string server_uri, int server_port)
        {
            userID = user_id;
            Password = password;
            serverPort = server_port;
            serverURI = server_uri;
            initializeConnection();
            Timer = new Thread(thread_Timer);
            Timer.Start();
        }
        /// <summary>
        /// 鼠标移到关闭按钮上改变颜色
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="mea"></param>
        /// 
        void btn_Any_MouseEnter(object obj, EventArgs ea)
        {
            if (obj.Equals(button_cancelLogin)) button_cancelLogin.Image = Properties.Resources.enter;
        }
        void btn_Any_MouseLeave(object obj, EventArgs ea)
        {
            if (obj.Equals(button_cancelLogin)) button_cancelLogin.Image = Properties.Resources.down;
        }
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_MouseDownEvent(object obj, MouseEventArgs ea)
        {
            if (obj.Equals(button_cancelLogin)) button_cancelLogin.Image = Properties.Resources.down;
        }
        void btn_MouseUpEvent(object obj, MouseEventArgs ea)
        {
            if (obj.Equals(button_cancelLogin)) button_cancelLogin.Image = Properties.Resources.enter;
        }
        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_Click_Event(object obj, EventArgs ea)
        {
            if (netHelper == null) return;
            netHelper.stopConnection();
            if (Timer != null) Timer.Abort();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// 建立通讯
        /// </summary>
        void initializeConnection()
        {
            Order order = new Order();
            UserInfo userInfo = new UserInfo();
            userInfo.UserID = userID;
            userInfo.Password = Password;
            userInfo.Order = order.OrderCodes["login"];

            netHelper = new NetHelper();
            netHelper.setCallBack(new AsyncCallback(receiveCallBack));
            netHelper.startConnection(serverURI, serverPort);
            Thread.Sleep(200);
            netHelper.sendJsonBlock(userInfo);
        }
        void navigateToLoginWindow()
        {
            if (Timer != null) Timer.Abort();
            if (!User_Info.login_result)
            {
                this.DialogResult = DialogResult.No;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
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
                        UserInfo userInfo = new UserInfo();
                        userInfo = JsonHelper.getDeserializeObject<UserInfo>(full_content);
                        userInfo.UserID = userID;
                        userInfo.Password = Password;
                        userInfo.ServerPort = serverPort;
                        userInfo.ServerURI = serverURI;
                        /* 测试名字 */
                        //userInfo.UserName = "李坑";
                        //userInfo.login_result = true;
                        
                        Hashtable ht = JsonHelper.getDeserializeObject<Hashtable>(full_content);
                        if (ht.ContainsKey(UserInfo.NAME_USER_NAME)) userInfo.UserName = ht[UserInfo.NAME_USER_NAME].ToString();
                        if (ht.ContainsKey(UserInfo.NAME_ICON)) userInfo.Icon = ht[UserInfo.NAME_ICON].ToString();
                        if (ht.ContainsKey(UserInfo.NAME_LOGIN_RESULT)) userInfo.login_result = (bool)ht[UserInfo.NAME_LOGIN_RESULT];
                        if (ht.ContainsKey(UserInfo.NAME_ERRO_CODE)) userInfo.error_code = int.Parse(ht[UserInfo.NAME_ERRO_CODE].ToString());
                        

                        User_Info = userInfo;
                        MethodInvoker methodInvokeNavigation = new MethodInvoker(navigateToLoginWindow);
                        BeginInvoke(methodInvokeNavigation);
                    }
                    netHelper.beginReceiveCallBack();
                }

            }
            catch (Exception e)
            {
                Reporter.reportBug(e.ToString());
            }
        }
    }
}
