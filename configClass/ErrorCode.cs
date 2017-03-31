using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace custom_cloud
{
    /// <summary>
    /// 存储错误码
    /// </summary>
    class ErrorCode
    {
        /* 错误码 */
        public static int ERROR_CODE_CONNECT_TIMEOUT = 1;
        public static int ERROR_CODE_USER_NOT_FOUND = 2;
        public static int ERROR_CODE_PASSWORD_ERROR = 3;
        public static int ERROR_CODE_ID_EXIST = 4;
        public static int ERROR_CODE_SERVER_ERROR = 5;
        public static int ERROR_CODE_USER_ALREADY_ONLINE = 6;
        public static int ERROR_CODE_UPDATE_USER_INFO_FAIL = 7;
        public static int ERROR_CODE_REQUEST_GROUP_INFO_FAIL = 8;
        public static int ERROR_CODE_SHARE_FILES_FAIL = 9;
        /* 错误信息 */
        public static string ERROR_INFO_CONNECT_TIMEOUT = "连接超时";
        public static string ERROR_INFO_USER_NOT_FOUND = "用户不存在";
        public static string ERROR_INFO_PASSWORD_ERROR = "密码错误";
        //public static string ERROR_INFO_ID_EXIST = "该用户已被注册";
        public static string ERROR_INFO_SERVER_ERROR = "服务器异常";
        public static string ERROR_INFO_USER_ALREADY_ONLINE = "该用户已在线";

        /* 错误信息表 */
        public Hashtable TableErrorCode = new Hashtable();
        public ErrorCode()
        {
            TableErrorCode.Add(ERROR_CODE_CONNECT_TIMEOUT, ERROR_INFO_CONNECT_TIMEOUT);
            TableErrorCode.Add(ERROR_CODE_USER_NOT_FOUND, ERROR_INFO_USER_NOT_FOUND);
            TableErrorCode.Add(ERROR_CODE_PASSWORD_ERROR, ERROR_INFO_PASSWORD_ERROR);
            TableErrorCode.Add(ERROR_CODE_SERVER_ERROR, ERROR_INFO_SERVER_ERROR);
            TableErrorCode.Add(ERROR_CODE_USER_ALREADY_ONLINE, ERROR_INFO_USER_ALREADY_ONLINE);
        }
    }
}
