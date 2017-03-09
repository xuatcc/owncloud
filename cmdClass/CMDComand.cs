/*
    *@by Benquicki
    *@in XJTU
    *@in 2017.2
*/
using custom_cloud.IOClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;

namespace custom_cloud.cmdClass
{
    /// <summary>
    /// 专门执行控制台命令的类
    /// </summary>
    class CMDComand
    {
        /// <summary>
        /// 执行普通的CMD命令
        /// </summary>
        /// <param name="command"></param>
        /// <param name="args"></param>
        public static void executeCMDComand(string command, string[] args, string path)
        {
            /* 调用系统调用选择打开方式 */
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.RedirectStandardInput = true;//重定向输入
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            //变换地址
            proc.StandardInput.WriteLine("cd " + path);
            proc.StandardInput.Flush();
            string totalString = command;
            for(int i = 0; i < args.Length; i++)
            {
                totalString += " " + args[i];
            }
            totalString += "\n";
            proc.StandardInput.WriteLine(totalString);
            proc.StandardInput.Flush();
        }
        /// <summary>
        /// 对文件加密
        /// </summary>
        /// <param name="fileSource"></param>
        /// <param name="fileTarget"></param>
        public static string encryptFile(string fileSource, string fileTarget)
        {
            if (!File.Exists(MyConfig.PATH_FILE_ENCRYPTION)) throw new Exception("can't find ecryption!");
            string sslComand = (" -k " + MyConfig.PASSWORD_FILE_ENCRYPTION + " -in " + fileSource + " -out " + fileTarget + MyConfig.EXTEND_NAME_ENCRYP_FILE);
            Process process = new Process();
            process.StartInfo.FileName = MyConfig.PATH_ECRYTION;
            process.StartInfo.Arguments = "enc -e -aes-128-cbc" + sslComand;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            process.WaitForExit();
            File.Delete(fileSource);
            return "ecryption complete";
        }
        /// <summary>
        /// 解密文件
        /// </summary>
        /// <param name="fileSource"></param>
        /// <param name="fileTarget"></param>
        public static string discryptFile(string fileSource, string fileTarget)
        {
            if (!File.Exists(fileSource)) throw new Exception("can't find ecryption!");
            //if (!File.Exists(fileSource)) return "";
            if (!Directory.Exists(MyConfig.PATH_FILE_BUFFER)) Directory.CreateDirectory(MyConfig.PATH_FILE_BUFFER);
            /* 执行语句 */
            string sslComand = (" -k " + MyConfig.PASSWORD_FILE_ENCRYPTION + " -in " + fileSource + " -out " + fileTarget);
            Process process = new Process();
            process.StartInfo.FileName = MyConfig.PATH_ECRYTION;
            process.StartInfo.Arguments = "enc -d -aes-128-cbc" + sslComand;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            process.WaitForExit();
            return fileTarget;
        }
        /// <summary>
        /// 对目录进行同步
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="user_id"></param>
        /// <param name="password"></param>
        /// <param name="server_url"></param>
        public static int syncDirectory(string directory, string user_id, string password, string server_url)
        {
            if (!File.Exists(MyConfig.PATH_SYNC_TOOL)) throw new Exception("cann't find sync tool!");
            Process process = new Process();
            process.StartInfo.FileName = MyConfig.PATH_SYNC_TOOL;
            process.StartInfo.Arguments = "--user  " + user_id + " --password " + password + " " + Path.GetFullPath(directory) + " " + server_url;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.ErrorDataReceived += new DataReceivedEventHandler(msgReceivedManager);
            process.Start();
            process.BeginErrorReadLine();
            process.WaitForExit();
            return process.ExitCode;
        }
        static void msgReceivedManager(object obj, DataReceivedEventArgs drea)
        {
            if (!string.IsNullOrEmpty(drea.Data))
            {
                string temp = drea.Data;
                Reporter.writeLog("./log/sync_temp.log", temp);
                Reporter.writeLog(SyncResult.PATH_SYNC_RESULT, temp);
            }
        }
    }
}
