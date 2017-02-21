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
        /* 错误信息 */
        public static string ERROR_INFO_CONNECT_TIMEOUT = "连接超时，请检查网络连接\n或服务器地址是否正确";
        /* 错误信息表 */
        public Hashtable TableErrorCode = new Hashtable();
        public ErrorCode()
        {
            TableErrorCode.Add(ERROR_CODE_CONNECT_TIMEOUT, ERROR_INFO_CONNECT_TIMEOUT);
        }
    }
}
