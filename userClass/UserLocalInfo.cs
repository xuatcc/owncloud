/*
    *@by Benquicki
    *@in XJTU
    *@in 2017.2
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace custom_cloud
{
    /// <summary>
    /// 用户本地信息
    /// </summary>
    class UserLocalInfo
    {
        /// <summary>
        /// 本地同步目录
        /// </summary>
        public string SyncPath;
        /// <summary>
        /// 是否记住密码
        /// </summary>
        public bool IsRemeberPassword;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password;
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId;
    }
}
