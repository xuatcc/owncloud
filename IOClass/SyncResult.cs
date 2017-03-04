using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace custom_cloud.IOClass
{
    /// <summary>
    /// 用于分析同步结果
    /// </summary>
    public class SyncResult
    {
        /// <summary>
        /// 同步临时结果的位置
        /// </summary>
        public static string PATH_SYNC_RESULT = "./log/sync_result.log";
        /// <summary>
        /// 同步结果-无法获取同步结果
        /// </summary>
        public static string RESULT_CANNT_ASSESS_SYNC_RESULT = "无法获取同步结果";
        /// <summary>
        /// 同步结果-同步目录不存在
        /// </summary>
        public static string RESULT_DIRECTORY_NOT_EXIST = "同步目录不存在";
        /// <summary>
        /// 同步关键字-目录不存在
        /// </summary>
        public static string KEY_DIRECTORY_NOT_EXIST = "does not exist";
        /// <summary>
        /// 同步结果-无法建立与同步服务器的连接
        /// </summary>
        public static string RESULT_CANNT_ASSESS_SERVER = "无法建立与同步服务器的连接";
        /// <summary>
        /// 同步关键字-无法建立与同步服务器的连接
        /// </summary>
        public static string KEY_CANNT_ASSESS_SERVER = "failed for";
        /// <summary>
        /// 同步结果-同步成功
        /// </summary>
        public static string RESULT_SYNC_SUCCESS = "同步完成";
        /// <summary>
        /// 同步关键字-同步成功
        /// </summary>
        public static string KEY_SYNC_SUCCESS = "visiting";
        public static string getSyncResult()
        {
            if (!File.Exists(PATH_SYNC_RESULT)) return RESULT_CANNT_ASSESS_SYNC_RESULT;
            StreamReader resultReader = new StreamReader(PATH_SYNC_RESULT, Encoding.Default);
            string content = resultReader.ReadToEnd();
            resultReader.Close();
            /* 清除同步记录 */
            StreamWriter syncWriter = new StreamWriter(PATH_SYNC_RESULT, false, Encoding.Default);
            syncWriter.Write("");
            syncWriter.Close();
            /* 分析结果 */
            if (content.Contains(KEY_DIRECTORY_NOT_EXIST)) return RESULT_DIRECTORY_NOT_EXIST;
            else if (content.Contains(KEY_CANNT_ASSESS_SERVER)) return RESULT_CANNT_ASSESS_SERVER;
            else if (content.Contains(KEY_SYNC_SUCCESS)) return RESULT_SYNC_SUCCESS;
            return RESULT_CANNT_ASSESS_SERVER;
        }
    }
}
