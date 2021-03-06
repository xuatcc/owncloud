﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
        public const string PATH_SYNC_RESULT = "./log/sync_result.log";
        /// <summary>
        /// 同步结果-无法获取同步结果
        /// </summary>
        public const string RESULT_CANNT_ASSESS_SYNC_RESULT = "无法获取同步结果";
        /// <summary>
        /// 同步结果-同步目录不存在
        /// </summary>
        public const string RESULT_DIRECTORY_NOT_EXIST = "同步目录不存在";
        /// <summary>
        /// 同步关键字-目录不存在
        /// </summary>
        public const string KEY_DIRECTORY_NOT_EXIST = "does not exist";
        /// <summary>
        /// 同步结果-无法建立与同步服务器的连接
        /// </summary>
        public const string RESULT_CANNT_ASSESS_SERVER = "无法建立与同步服务器的连接";
        /// <summary>
        /// 同步关键字-无法建立与同步服务器的连接
        /// </summary>
        public const string KEY_CANNT_ASSESS_SERVER = "failed for";
        /// <summary>
        /// 同步结果-同步成功
        /// </summary>
        public const string RESULT_SYNC_SUCCESS = "同步完成";
        /// <summary>
        /// 同步关键字-同步成功
        /// </summary>
        public const string KEY_SYNC_SUCCESS = "visiting";
        /// <summary>
        /// 获取同步结果
        /// </summary>
        /// <returns></returns>
        public static string getSyncResult()
        {
            if (!File.Exists(PATH_SYNC_RESULT)) return RESULT_CANNT_ASSESS_SYNC_RESULT;
            StreamReader resultReader = new StreamReader(PATH_SYNC_RESULT, Encoding.Default);
            string content = resultReader.ReadToEnd();
            resultReader.Close();
            /* 分析结果 */
            if (content.Contains(KEY_DIRECTORY_NOT_EXIST)) return RESULT_DIRECTORY_NOT_EXIST;
            else if (content.Contains(KEY_CANNT_ASSESS_SERVER)) return RESULT_CANNT_ASSESS_SERVER;
            else if (content.Contains(KEY_SYNC_SUCCESS)) return RESULT_SYNC_SUCCESS;
            return RESULT_CANNT_ASSESS_SERVER;
        }
        const string FileSyncedFlag = "client file: ";
        /// <summary>
        /// 文件同步状态
        /// </summary>
        public enum FileSyncStatus
        {
            Success = 0,
            Fail = 1
        }
        /// <summary>
        /// 获取同步文件的同步结果
        /// </summary>
        /// <param name="syncPath"></param>
        /// <returns></returns>
        public static Queue<string> getSyncFileResult(string syncPath)
        {
            Queue<string> queue = new Queue<string>();
            if (!File.Exists(PATH_SYNC_RESULT)) return queue;
            StreamReader resultReader = new StreamReader(PATH_SYNC_RESULT, Encoding.Default);
            string line;
            string filePath;
            while((line=resultReader.ReadLine())!=null)
            {
                filePath = catchFilePath(syncPath, line);
                if(File.Exists(filePath))queue.Enqueue(@"Home:\" + filePath.Substring(filePath.IndexOf(syncPath),filePath.Length-filePath.IndexOf(syncPath)));
            }
            resultReader.Close();
            
            /* 分析结果 */

            return queue;
        }
        /// <summary>
        /// 抓取文件路径
        /// </summary>
        /// <param name="syncPath"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string catchFilePath(string syncPath, string line_str)
        {
            if (line_str == null) return "";
            
            /* 转换成UTF8编码 */
            string line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(line_str));
            //Reporter.writeLog("./log/file_line_str.log", line_str);
            string result = "";
            int startIndex = line.IndexOf(Encoding.UTF8.GetString(Encoding.UTF8.GetBytes("csync_walker:  file: "))) + "csync_walker:  file: ".Length;
            int endIndex = line.IndexOf(Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(" [inode=")));
            if (startIndex >= 0 && endIndex >= startIndex)result = Path.GetFullPath(syncPath + "/" + line.Substring(startIndex, endIndex - startIndex));
            //Reporter.writeLog("./log/file_synced_detail.log", result);
            return result;
        }
        /// <summary>
        /// 清除同步记录
        /// </summary>
        public static void clearSyncResult()
        {
            if (!File.Exists(PATH_SYNC_RESULT)) return;
            /* 清除同步记录 */
            StreamWriter syncWriter = new StreamWriter(PATH_SYNC_RESULT, false, Encoding.Default);
            syncWriter.Write("");
            syncWriter.Close();
        }
    }
}
