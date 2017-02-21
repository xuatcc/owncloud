using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace custom_cloud
{
    class Reporter
    {
        public const string BUG_REPORT_LOG_PATH = @"./log/bug_report.log";
        /// <summary>
        /// 将异常信息输出到"./log/"目录下，正式发布时应取消这个功能
        /// </summary>
        /// <param name="content"></param>
        public static void reportBug(string content)
        {
            StreamWriter bugWriter = new StreamWriter(BUG_REPORT_LOG_PATH, true, Encoding.Default);
            bugWriter.WriteLine(DateTime.Now.ToString(), true, Encoding.Default);
            bugWriter.Write(content, true, Encoding.Default);
            bugWriter.WriteLine("", true, Encoding.Default);// 换行
            bugWriter.Close();
        }
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public static void writeLog(string path, string content)
        {
            StreamWriter logWriter = new StreamWriter(path, true, Encoding.Default);
            string date = DateTime.Now.ToString();
            logWriter.WriteLine(date);
            logWriter.Write(content);
            logWriter.WriteLine("");
            logWriter.Close();
        }
    }
}
