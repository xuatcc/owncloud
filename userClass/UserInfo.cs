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
        public string UserID;
        public string UserName;
        public string Password;
        //public string SyncDirectory;
        /// <summary>
        /// 登录服务器地址
        /// </summary>
        public string ServerURI;
        public int ServerPort;
        public string Icon;
        public string Order;
        public bool login_result;
        public int error_code;
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
        
        public UserInfo()
        {

        }
        /// <summary>
        /// 从服务器获取用户信息
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
