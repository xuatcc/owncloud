using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace custom_cloud
{
    /// <summary>
    /// 用于帮助客户端访问服务器
    /// </summary>
    class NetHelper
    {
        public Queue<string> receiveBuffer = new Queue<string>();// 消息缓冲队列
        public Socket SocketClient;
        public string ServerIP;
        public int ServerPort;
        public byte[] msgByte = new byte[64 * 1024];
        Thread ThreadSocket;
        public bool flag_fullReceive = false;// 标记是否可以向外输出消息
        string receiveInfo = "";
        AsyncCallback asycnCallBack;
        public string ReceiveInfo
        {
            get
            {
                lock ((object)flag_fullReceive)
                {
                    if (flag_fullReceive)
                    {
                        flag_fullReceive = false;
                        lock (receiveInfo)
                        {
                            return receiveInfo;
                        }
                    }
                    else return null;
                }
            }
        }

        public NetHelper()
        {
            asycnCallBack = new AsyncCallback(this.receiveCallBack);
        }
        /// <summary>
        /// 设置接收到消息后的处理方式
        /// </summary>
        public void setCallBack(AsyncCallback acb)
        {
            asycnCallBack = acb;
        }
        /// <summary>
        /// 启动连接
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void startConnection(string ip, int port)
        {
            ServerIP = ip;
            ServerPort = port;
            //SocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);
            ThreadSocket = new Thread(thread_connect);
            ThreadSocket.Start();
        }
        /// <summary>
        /// 停止连接
        /// </summary>
        public void stopConnection()
        {
            if (SocketClient.Connected) SocketClient.Close();
            if (ThreadSocket != null) ThreadSocket.Abort();
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        public void sendMessage(string msg)
        {
            if (!SocketClient.Connected) return;
            SocketClient.Send(Encoding.UTF8.GetBytes(msg));
        }
        /// <summary>
        /// 发送Json数据块
        /// </summary>
        /// <param name="block"></param>
        public void sendJsonBlock(object obj)
        {
            if (SocketClient == null) return;
            if (!SocketClient.Connected) return;
            string serial_code = JsonHelper.getSerializeString(obj);
            sendMessage(Order.FLAG_START);
            Thread.Sleep(200);
            sendMessage(serial_code);
            Thread.Sleep(200);
            sendMessage(Order.FLAG_STOP);
        }
        /// <summary>
        /// 开始接收消息
        /// </summary>
        public void beginReceiveCallBack()
        {
            if (SocketClient == null) return;
            if (!SocketClient.Connected) return;
            if (asycnCallBack == null) return;
            SocketClient.BeginReceive(msgByte, 0, msgByte.Length, 0, asycnCallBack, null);
        }
        /// <summary>
        /// 连接线程
        /// </summary>
        void thread_connect()
        {
            try
            {
                //lock (SocketClient)
                
                SocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);
                SocketClient.Connect(serverEndPoint);
                Reporter.writeLog(MyConfig.PATH_NET_LOG, "connect to " + ServerIP + ":" + ServerPort.ToString());
                if (SocketClient.Connected)
                {
                    SocketClient.BeginReceive(msgByte, 0, msgByte.Length, 0, asycnCallBack, null);

                }
                
            }
            catch (Exception e)
            {
                Reporter.reportBug(e.ToString());
                //throw e;
            }
        }
        public void receiveCallBackDoNothing(IAsyncResult iar)
        {

        }
        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="iar"></param>
        void receiveCallBack(IAsyncResult iar)
        {
            try
            {
                int REnd = SocketClient.EndReceive(iar);
                string receive_content = Encoding.UTF8.GetString(msgByte, 0, REnd);
                string full_content = "";
                if (!string.IsNullOrEmpty(receive_content) && receive_content != "")
                {

                    //Thread.Sleep(2);
                    if (receive_content.Contains(Order.FLAG_START))
                    {
                        flag_fullReceive = false;
                        receiveBuffer = new Queue<string>();
                    }
                    if (!receive_content.Contains(Order.FLAG_START) && !receive_content.Contains(Order.FLAG_STOP))
                    {
                        receiveBuffer.Enqueue(receive_content);
                    }
                    if (receive_content.Contains(Order.FLAG_STOP))
                    {
                        while (receiveBuffer.Count > 0)
                        {
                            full_content += receiveBuffer.Dequeue();
                        }
                        Reporter.writeLog(MyConfig.PATH_NET_LOG, "net helper : " + full_content);
                        //receiveInfo = full_content;
                        //flag_fullReceive = true;
                    }
                }
                SocketClient.BeginReceive(msgByte, 0, msgByte.Length, 0, asycnCallBack, null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
