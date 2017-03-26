using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace custom_cloud
{
    public class UserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID;
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName;
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password;
        //public string SyncDirectory;
        /// <summary>
        /// 登录服务器地址
        /// </summary>
        public string ServerURI;
        /// <summary>
        /// 登录服务器端口
        /// </summary>
        public int ServerPort;
        /// <summary>
        /// 用户头像编码
        /// </summary>
        public string Icon;
        /// <summary>
        /// 请求命令
        /// </summary>
        public string Order;
        /// <summary>
        /// 登录结果
        /// </summary>
        public bool login_result;
        /// <summary>
        /// 登录错误码
        /// </summary>
        public int error_code;
        /// <summary>
        /// 文件密钥
        /// </summary>
        public String FileKey;
        /// <summary>
        /// 同步服务器地址
        /// </summary>
        public string SyncServerAddress;
        /* 公用属性名 */
        public static string NAME_USER_ID = "UserID";
        public static string NAME_USER_NAME = "UserName";
        public static string NAME_PASSWORD = "Password";
        public static string NAME_SERVER_URI = "ServerURI";
        public static string NAME_ICON = "Icon";
        public static string NAME_ORDER = "Order";
        public static string NAME_LOGIN_RESULT = "login_result";
        public static string NAME_ERRO_CODE = "error_code";
        public static string NAME_SYNC_SERVER_ADDRESS = "SyncServerAddress";
        public static string NAME_SYNC_FILE_KEY = "FileKey";
        
        public UserInfo()
        {

        }
        /// <summary>
        /// 从服务器获取用户信息（这个方法废掉了）
        /// </summary>
        /// <returns></returns>
        public static UserInfo getUserInfoFromServer(string ip, int port, string order, string id, string password)
        {
            UserInfo userInfo = new UserInfo();
            NetHelper netHelper = new NetHelper();
            netHelper.startConnection(ip, port);
            userInfo.Order = order;
            userInfo.UserID = id;
            userInfo.Password = password;
            netHelper.sendJsonBlock(userInfo);
            string receiveMsg = null;

            while (true)
            {
                receiveMsg = netHelper.ReceiveInfo;
                if (receiveMsg != null) break;

                //Thread.Sleep(10);
            }
            netHelper.stopConnection();
            Hashtable ht = JsonHelper.getDeserializeObject<Hashtable>(receiveMsg);
            if (ht.ContainsKey(NAME_USER_NAME)) userInfo.UserName = ht[NAME_USER_NAME].ToString();
            if (ht.ContainsKey(NAME_ICON)) userInfo.Icon = ht[NAME_ICON].ToString();
            if (ht.ContainsKey(NAME_LOGIN_RESULT)) userInfo.login_result = (bool)ht[NAME_LOGIN_RESULT];
            if (ht.ContainsKey(NAME_ERRO_CODE)) userInfo.error_code = int.Parse(ht[NAME_ERRO_CODE].ToString());
            return userInfo;
        }
        /// <summary>
        /// 以Json格式保存用户信息
        /// </summary>
        /// <param name="directory"></param>
        public static void storeUserInfoByJson(string directory, UserInfo user_info)
        {
            string serial = JsonHelper.getSerializeString(user_info);
            StreamWriter infoWriter = new StreamWriter(directory, false, MyConfig.ENCODE);
            infoWriter.Write(infoWriter);
            infoWriter.Close();
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static UserInfo readUserInfoByJson(string directory)
        {
            StreamReader infoReader = new StreamReader(directory, MyConfig.ENCODE);
            string serial = infoReader.ReadToEnd();
            infoReader.Close();
            return JsonHelper.getDeserializeObject<UserInfo>(serial);
        }
    }
}
