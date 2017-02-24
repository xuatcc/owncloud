using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        public static void ecryptFile(string fileSource, string fileTarget)
        {
            if (!File.Exists(MyConfig.PATH_FILE_ENCRYPTION)) throw new Exception("can't find ecryption!");
            /* 执行语句 */
            string sslComand = "openssl.exe enc -e -aes-128-cbc";
            sslComand += (" -k " + MyConfig.PASSWORD_FILE_ENCRYPTION + " -in " + fileSource + " -out " + fileTarget + "\n");
            /* 调用系统调用选择打开方式 */
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.RedirectStandardInput = true;//重定向输入
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            //变换地址
            proc.StandardInput.WriteLine("cd " + MyConfig.PATH_TOOL);
            proc.StandardInput.Flush();
            proc.StandardInput.WriteLine(sslComand);
            proc.StandardInput.Flush();
        }
        /// <summary>
        /// 解密文件
        /// </summary>
        /// <param name="fileSource"></param>
        /// <param name="fileTarget"></param>
        public static void discryptFile(string fileSource, string fileTarget)
        {
            if (!File.Exists(MyConfig.PATH_FILE_ENCRYPTION)) throw new Exception("can't find ecryption!");
            /* 执行语句 */
            string sslComand = "openssl.exe enc -d -aes-128-cbc";
            sslComand += (" -k " + MyConfig.PASSWORD_FILE_ENCRYPTION + " -in " + fileSource + " -out " + fileTarget + "\n");
            /* 调用系统调用选择打开方式 */
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.RedirectStandardInput = true;//重定向输入
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            //变换地址
            proc.StandardInput.WriteLine("cd " + MyConfig.PATH_TOOL);
            proc.StandardInput.Flush();
            proc.StandardInput.WriteLine(sslComand);
            proc.StandardInput.Flush();
        }
    }
}
