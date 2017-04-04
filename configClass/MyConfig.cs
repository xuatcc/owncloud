/*
    *@by Benquicki
    *@in XJTU
    *@in 2017.2
*/
using custom_cloud.cmdClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace custom_cloud
{
    /// <summary>
    /// 配置文件管理类
    /// </summary>
    class MyConfig
    {
        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static string CONFIG_FILE_PATH = @"./config/config.conf";
        /// <summary>
        /// （已作废）
        /// </summary>
        public static string WORK_SPACE_ID = "work_space";
        /// <summary>
        /// 初始生成文件路径
        /// </summary>
        public static string FIRST_USE_FILE = @"./config/init";
        /// <summary>
        /// （已作废）
        /// </summary>
        public static string OWNCLOUD_LOCATION_ID = "owncloud_location";
        /// <summary>
        /// 未知类型文件图标路径（已作废）
        /// </summary>
        public static string FILE_ICON_PATH = @"./icon/file/File.png";
        /// <summary>
        /// 文件夹图标路径（已作废）
        /// </summary>
        public static string FOLDER_ICON_PATH = @"./icon/file/Folder.png";
        /// <summary>
        /// 同步配置文件路径
        /// </summary>
        public static string SYNC_CONF_PATH = @"./config/sync.conf";
        /// <summary>
        /// 文件图标配置文件路径
        /// </summary>
        public static string ICON_CONF_PATH = @"./config/icon.conf";
        /// <summary>
        /// （已作废）
        /// </summary>
        public static string ICON_LIB_PATH = @"./icon/file/";
        /// <summary>
        /// 用户登录记录文件路径
        /// </summary>
        public static string PATH_USER_TRACK = @"./log/user_track.log";
        /// <summary>
        /// （已作废）
        /// </summary>
        public static string KEY_WORD_TIME_STAMP = "time_stamp";
        /// <summary>
        /// 用户信息文件夹路径
        /// </summary>
        public static string PATH_USER = @"./user/";
        /// <summary>
        /// 用户信息文件名
        /// </summary>
        public static string NAME_USER_INFO = "info.conf";
        /// <summary>
        /// 网络记录文件路径
        /// </summary>
        public static string PATH_NET_LOG = @"./log/net.log";
        /// <summary>
        /// 默认同步目录名
        /// </summary>
        public static string NAME_FOLDER_SYNC = "sync";
        /// <summary>
        /// 文件大图标目录
        /// </summary>
        public static string LARGE_ICON_PATH = @"./icon/Large";
        /// <summary>
        /// 文件小图标目录
        /// </summary>
        public static string SMALL_ICON_PATH = @"./icon/Small";
        /// <summary>
        /// 大文件夹图标路径
        /// </summary>
        public static string LARGE_FOLDER_ICON_PATH = @"./icon/Large/Folder.png";
        /// <summary>
        /// 小文件夹图标路径
        /// </summary>
        public static string SMALL_FOLDER_ICON_PATH = @"./icon/Small/Folder.png";
        /// <summary>
        /// 大文件图标路径
        /// </summary>
        public static string LARGE_DEFAULT_FILE_ICON_PATH = @"./icon/Large/File.png";
        /// <summary>
        /// 小文件图标路径
        /// </summary>
        public static string SMALL_DEFAULT_FILE_ICON_PATH = @"./icon/Small/File.png";
        public static UTF8Encoding ENCODE;
        /// <summary>
        /// 主题色
        /// </summary>
        public static Color SelectedColor = Color.FromArgb(Convert.ToInt32("e93da5fc", 16));
        /// <summary>
        /// 参考时间
        /// </summary>
        public static DateTime RefTime = Convert.ToDateTime("1900-1-1 00:00:00");
        public static DateTime RefFutureTime = Convert.ToDateTime("2050-1-1 00:00:00");
        public static double RefFutureTimeDouble = RefFutureTime.Subtract(RefFutureTime).TotalSeconds;
        /// <summary>
        /// 加密模块的位置
        /// </summary>
        public static string PATH_FILE_ENCRYPTION = @"./tool/openssl.exe";
        /// <summary>
        /// 辅助工具包的位置
        /// </summary>
        public static string PATH_TOOL = @"./tool/";
        /// <summary>
        /// 文件加密密码
        /// </summary>
        public static string PASSWORD_FILE_ENCRYPTION = "custom_cloud";
        /// <summary>
        /// 本地用户信息加密密码
        /// </summary>
        public static string PASSWORD_USER_FILE_ENCRYPTION = "custom_cloud_userLocalInfo";
        /// <summary>
        /// 加密后文件的扩展名
        /// </summary>
        public static string EXTEND_NAME_ENCRYP_FILE = ".ssl";
        /// <summary>
        /// 同步工具的位置
        /// </summary>
        public static string PATH_SYNC_TOOL = @"./tool/sync.exe";
        /// <summary>
        /// 加密工具的位置
        /// </summary>
        public static string PATH_ECRYTION = @"./tool/openssl.exe";
        /// <summary>
        /// 解密文件缓冲目录
        /// </summary>
        public static string PATH_FILE_BUFFER = @"./file_buffer/";
        /// <summary>
        /// 文件排序规则
        /// </summary>
        public enum SortRule
        {
            ByName = 1,
            BySize = 2,
            ByTime = 3
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public static void saveConfig(string path, ConfigFile ht)
        {
            string serial_code = JsonHelper.getSerializeString(ht);
            StreamWriter configWriter = new StreamWriter(path, false, Encoding.Default);
            configWriter.Write(serial_code);
            configWriter.Close();
        }
        /// <summary>
        /// 使用默认路径保存配置
        /// </summary>
        /// <param name="ht"></param>
        public static void saveConfig(ConfigFile ht)
        {
            string serial_code = JsonHelper.getSerializeString(ht);
            StreamWriter configWriter = new StreamWriter(CONFIG_FILE_PATH, false, Encoding.Default);
            configWriter.Write(serial_code);
            configWriter.Close();
        }
        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        
        public static ConfigFile readConfig(string path)
        {
            StreamReader configReader = new StreamReader(path, Encoding.Default);
            string serial_code = configReader.ReadToEnd();
            configReader.Close();
            return JsonHelper.getDeserializeObject<ConfigFile>(serial_code);
        }
        /// <summary>
        /// 使用默认路径读取配置
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ConfigFile readConfig()
        {
            StreamReader configReader = new StreamReader(CONFIG_FILE_PATH, Encoding.Default);
            string serial_code = configReader.ReadToEnd();
            configReader.Close();
            return JsonHelper.getDeserializeObject<ConfigFile>(serial_code);
        }
        /// <summary>
        /// 检查是否为第一次使用
        /// </summary>
        /// <returns></returns>
        public static string checkUserTrackEmpty()
        {
            StreamReader userTrackReader = new StreamReader(PATH_USER_TRACK, Encoding.Default);
            string line;
            string content = string.Empty;
            while((line = userTrackReader.ReadLine()) != null)
            {
                content = line;
            }
            userTrackReader.Close();
            if (content == string.Empty) return null;
            return content;
        }
        /// <summary>
        /// 写userTrack
        /// </summary>
        /// <param name="user"></param>
        public static void writeUserTrack(string user)
        {
            StreamWriter userTrackWriter = new StreamWriter(PATH_USER_TRACK, true, Encoding.Default);
            userTrackWriter.Write(DateTime.Now.ToString() + " ");
            userTrackWriter.WriteLine(user);
            userTrackWriter.Close();
        }
        /// <summary>
        /// 获取用户使用痕迹
        /// </summary>
        /// <param name="path"></param>
        public static Stack<string> getUserTrack(string path)
        {
            Stack<string> userIDStack = new Stack<string>();
            try {
                StreamReader trackReader = new StreamReader(path, Encoding.Default);
                string line;
                string userName;
                while ((line = trackReader.ReadLine()) != null)
                {
                    userName = CodeAnalysis.getValueString(line)[0];
                    if (!userIDStack.Contains(userName)) userIDStack.Push(userName);
                }
                trackReader.Close();
            }
            catch(Exception e)
            {
                Reporter.reportBug(e.ToString());
            }
            return userIDStack;
        }
        /// <summary>
        /// 获取用户使用痕迹
        /// </summary>
        /// <param name="path"></param>
        public static Stack<string> getUserTrack()
        {
            Stack<string> userIDStack = new Stack<string>();
            try
            {
                StreamReader trackReader = new StreamReader(PATH_USER_TRACK, Encoding.Default);
                string line;
                string userName;
                while ((line = trackReader.ReadLine()) != null)
                {
                    userName = CodeAnalysis.getValueString(line)[0];
                    if (!userIDStack.Contains(userName)) userIDStack.Push(userName);
                }
                trackReader.Close();
            }
            catch (Exception e)
            {
                Reporter.reportBug(e.ToString());
            }
            return userIDStack;
        }
        /// <summary>
        /// 创建用户文件夹
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public static void createOrModifyUserDirectory(string user, UserInfo user_info)
        {
            if (!Directory.Exists(PATH_USER + user)) Directory.CreateDirectory(PATH_USER + user);
            UserInfo.storeUserInfoByJson(PATH_USER + user + "" + NAME_USER_INFO, user_info);
        }
        /// <summary>
        /// 读取用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="server_address"></param>
        /// <param name="work_directory"></param>
        public static UserInfo readUserInfo(string user)
        {
            if (!Directory.Exists(PATH_USER + user))
            {
                return null;
            }
            return UserInfo.readUserInfoByJson(PATH_USER + user + "" + NAME_USER_INFO);
        }
        /// <summary>
        /// 创建或修改用户本地信息
        /// </summary>
        /// <param name="path"></param>
        /// <param name="userLocalInfo"></param>
        public static void createOrModifyUserLocalInfo(string path, UserLocalInfo userLocalInfo)
        {
            if (!Directory.Exists(path + "/" + userLocalInfo.UserId))
                Directory.CreateDirectory(path + "/" + userLocalInfo.UserId);
            if (!Directory.Exists(path + "/" + userLocalInfo.UserId + "/" + NAME_FOLDER_SYNC))
                Directory.CreateDirectory(path + "/" + userLocalInfo.UserId + "/" + NAME_FOLDER_SYNC);
            UserLocalInfo user_localInfo = userLocalInfo;
            /* 设置起始默认同步目录 */
            UserLocalInfo temp = getUserLocalInfo(userLocalInfo.UserId);
            if (temp == null) user_localInfo.SyncPath = PATH_USER + "/" + user_localInfo.UserId + "/" + NAME_FOLDER_SYNC;
            else if (temp.SyncPath == null || (!Directory.Exists(temp.SyncPath))) user_localInfo.SyncPath = Path.GetFullPath(PATH_USER + "/" + user_localInfo.UserId + "/" + NAME_FOLDER_SYNC);
            StreamWriter infoWriter = new StreamWriter(path + "/" + userLocalInfo.UserId + "/" + NAME_USER_INFO, 
                false, Encoding.Default);
            infoWriter.Write(Int32Dec64Convert.encryptSerialToBase64Code(JsonHelper.getSerializeString(user_localInfo), PASSWORD_USER_FILE_ENCRYPTION, 0x400));
            infoWriter.Close();
            
        }
        /// <summary>
        /// 创建或修改用户本地信息
        /// </summary>
        /// <param name="path"></param>
        /// <param name="userLocalInfo"></param>
        public static void createOrModifyUserLocalInfo(UserLocalInfo userLocalInfo)
        {
            if (!Directory.Exists(PATH_USER + "/" + userLocalInfo.UserId))
                Directory.CreateDirectory(PATH_USER + "/" + userLocalInfo.UserId);
            if (!Directory.Exists(PATH_USER + "/" + userLocalInfo.UserId + "/" + NAME_FOLDER_SYNC))
                Directory.CreateDirectory(PATH_USER + "/" + userLocalInfo.UserId + "/" + NAME_FOLDER_SYNC);
            UserLocalInfo user_localInfo = userLocalInfo;
            /* 设置起始默认同步目录 */
            UserLocalInfo temp = getUserLocalInfo(userLocalInfo.UserId);
            if (temp == null) user_localInfo.SyncPath = PATH_USER + "/" + user_localInfo.UserId + "/" + NAME_FOLDER_SYNC;
            else if (temp.SyncPath == null || (!Directory.Exists(temp.SyncPath))) user_localInfo.SyncPath = Path.GetFullPath(PATH_USER + "/" + user_localInfo.UserId + "/" + NAME_FOLDER_SYNC);
            StreamWriter infoWriter = new StreamWriter(PATH_USER + "/" + userLocalInfo.UserId + "/" + NAME_USER_INFO,
                false, Encoding.Default);
            infoWriter.Write(Int32Dec64Convert.encryptSerialToBase64Code(JsonHelper.getSerializeString(user_localInfo), PASSWORD_USER_FILE_ENCRYPTION, 0x400));
            infoWriter.Close();
        }
        /// <summary>
        /// 获取用户本地信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static UserLocalInfo getUserLocalInfo(string path, string userID)
        {
            
            if (!File.Exists(path + "/" + userID + "/" + NAME_USER_INFO)) return null;
            StreamReader infoReader = new StreamReader(path + "/" + userID + "/" + NAME_USER_INFO, Encoding.Default);
            string serial = infoReader.ReadToEnd();
            infoReader.Close();
            serial = Int32Dec64Convert.discryptBase64CodeToSerial(serial, PASSWORD_USER_FILE_ENCRYPTION);
            return JsonHelper.getDeserializeObject<UserLocalInfo>(serial);
        }
        /// <summary>
        /// 获取用户本地信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static UserLocalInfo getUserLocalInfo(string userID)
        {
            if (!File.Exists(PATH_USER + "/" + userID + "/" + NAME_USER_INFO)) return null;
            StreamReader infoReader = new StreamReader(PATH_USER + "/" + userID + "/" + NAME_USER_INFO, Encoding.Default);
            string serial = infoReader.ReadToEnd();
            infoReader.Close();
            serial = Int32Dec64Convert.discryptBase64CodeToSerial(serial, PASSWORD_USER_FILE_ENCRYPTION);
            return JsonHelper.getDeserializeObject<UserLocalInfo>(serial);
        }
        /// <summary>
        /// 获取登陆过的ID
        /// </summary>
        /// <returns></returns>
        public static string[] getLocalUserID()
        {
            if (!Directory.Exists(PATH_USER)) return null;
            DirectoryInfo userInfo = new DirectoryInfo(PATH_USER);
            DirectoryInfo[] userIDInfo = userInfo.GetDirectories();
            string[] result = new string[userIDInfo.Length];
            for (int i = 0; i < result.Length; i++) result[i] = userIDInfo[i].Name;
            return result;
        }
        /// <summary>
        /// 检查用户本地信息是否存在
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool checkIfUserLocalInfoExists(string userID)
        {
            return File.Exists(PATH_USER + "/" + userID + "/" + NAME_USER_INFO);
        }
        /// <summary>
        /// 获取大文件图标
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Image> getLargeFileIconDictionary()
        {
            Dictionary<string, Image> iconDict = new Dictionary<string, Image>();
            if (!Directory.Exists(LARGE_ICON_PATH)) return null;
            //if (!Directory.Exists(SMALL_ICON_PATH)) return null;
            if (!File.Exists(ICON_CONF_PATH)) return null;
            StreamReader confReader = new StreamReader(ICON_CONF_PATH, Encoding.Default);
            string line;
            while ((line = confReader.ReadLine()) != null)
            {
                iconDict.Add(Path.GetExtension(CodeAnalysis.getCommandString(line)), 
                    Image.FromFile(LARGE_ICON_PATH + "/" + CodeAnalysis.getValueString(line)[0]));
            }
            confReader.Close();
            return iconDict;
        }
        /// <summary>
        /// 获取小文件图标
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Image> getSmallFileIconDictionary()
        {
            Dictionary<string, Image> iconDict = new Dictionary<string, Image>();
            //if (!Directory.Exists(LARGE_ICON_PATH)) return null;
            if (!Directory.Exists(SMALL_ICON_PATH)) return null;
            if (!File.Exists(ICON_CONF_PATH)) return null;
            StreamReader confReader = new StreamReader(ICON_CONF_PATH, Encoding.Default);
            string line;
            while ((line = confReader.ReadLine()) != null)
            {
                iconDict.Add(Path.GetExtension(CodeAnalysis.getCommandString(line)),
                    Image.FromFile(SMALL_ICON_PATH + "/" + CodeAnalysis.getValueString(line)[0]));
            }
            confReader.Close();
            return iconDict;
        }
        /// <summary>
        /// 生成表单键名称的唯一方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string getListKeyName(string name, string text)
        {
            return name + STRING_SEPERATER+ text;
        }
        /// <summary>
        /// 通过项目键来获取文件路径
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string getPathByKey(string key)
        {
            int index_a = key.IndexOf(STRING_SEPERATER);
            return key.Substring(index_a + STRING_SEPERATER.Length);
        }
        /// <summary>
        /// 键与名的分隔字符串
        /// </summary>
        public static string STRING_SEPERATER = "_+_";
        /// <summary>
        /// 配置文件
        /// </summary>
        public class ConfigFile
        {
            /* 配置存储表 */
            //public Hashtable TableIcon = new Hashtable();
            public Hashtable TableSkin = new Hashtable();
            public Hashtable TableSync = new Hashtable();
            public Hashtable TableNotification = new Hashtable();
            public Hashtable TableLogin = new Hashtable();
            public Hashtable TablePrimary = new Hashtable();
            /* 总表 */
            //Hashtable TableAll;
            /* 表名 */
            //public const string TABLE_NAME_ICON = "TABLE_ICON";
            public const string TABLE_NAME_SKIN = "TAFBLE_SKIN";
            public const string TABLE_NAME_SYNC = "TABLE_SYNC";
            public const string TABLE_NAME_NOTIFICATION = "TABLE_NOTIFICATION";
            public const string TABLE_NAME_LOGIN = "TABLE_LOGIN";
            public const string TABLE_NAME_PRIMARY = "TABLE_PRIMARY";
            public ConfigFile()
            {
            }
            /// <summary>
            /// 创建或修改表中的某个属性
            /// </summary>
            /// <param name="table_name"></param>
            /// <param name="key"></param>
            /// <param name="value"></param>
            public void createOrModifyItem(string table_name, object key, object value)
            {
                switch (table_name)
                {
                    /*
                    case TABLE_NAME_ICON:
                        if (TableIcon.ContainsKey(key)) TableIcon[key] = value;
                        else TableIcon.Add(key, value);
                        break;
                    */
                    case TABLE_NAME_LOGIN:
                        if (TableLogin.ContainsKey(key)) TableLogin[key] = value;
                        else TableLogin.Add(key, value);
                        break;
                    case TABLE_NAME_NOTIFICATION:
                        if (TableNotification.ContainsKey(key)) TableNotification[key] = value;
                        else TableNotification.Add(key, value);
                        break;
                    case TABLE_NAME_PRIMARY:
                        if (TablePrimary.ContainsKey(key)) TablePrimary[key] = value;
                        else TablePrimary.Add(key, value);
                        break;
                    case TABLE_NAME_SKIN:
                        if (TableSkin.ContainsKey(key)) TableSkin[key] = value;
                        else TableSkin.Add(key, value);
                        break;
                    case TABLE_NAME_SYNC:
                        if (TableSync.ContainsKey(key)) TableSync[key] = value;
                        else TableSync.Add(key, value);
                        break;
                }
            }
            /* 静态子类，用于设置表键值 */
            public static class Skin
            {
                /// <summary>
                /// 图标大小
                /// </summary>
                public const string KEY_LARGE_ICON_SIZE = "KEY_LARGE_ICON_SIZE";
                public const string KEY_SMALL_ICON_SIZE = "KEY_SMALL_ICON_SIZE";
                /// <summary>
                /// 文件显示方式
                /// </summary>
                public const string KEY_FILE_VIEW = "KEY_FILE_VIEW";
                public const string KEY_FILE_SORT_RULE = "KEY_FILE_SORT_RULE";
            }
            public static class Sync
            {
                public const string KEY_AUTO_SYNC = "KEY_AUTO_SYNC";
                public const string KEY_SERVER_URI = "KEY_SERVER_URI";
                public const string KEY_SERVER_PORT = "KEY_SERVER_PORT";
            }
            public static class Notification
            {

            }
            public static class Login
            {
                public const string KEY_REMEMBER_PASSWORD = "KEY_REMEMBER_PASSWORD";
                public const string KEY_AUTO_LOGIN = "KEY_AUTO_LOGIN";
                public const string KEY_LAST_LOGIN_ACCOUNT = "KEY_LAST_LOGIN_ACCOUNT";
                public const string KEY_LAST_LOGIN_PASSWORD = "KEY_LAST_LOGIN_PASSWORD";

            }
            public static class Primary
            {
                public const string KEY_AUTO_START = "KEY_AUTO_START";
            }
        }
    }
}
