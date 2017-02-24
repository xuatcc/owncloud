/*
    *@by Benquicki
    *@in XJTU
    *@in 2016.3
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace custom_cloud
{//代码分析器
    class CodeAnalysis
    {
        public CodeAnalysis() { }
        //用于提取某字符之前的字符串
        public static String getStringBefore(String str, char beforeEle)
        {
            String result = "";
            for(int i = 0; i < str.Length; i++)
            {
                if (str.ElementAt<char>(i) == beforeEle) break;
                result += str.ElementAt<char>(i).ToString();
            }
            return result;
        }
        public static String getStringAfter(String str,char afterele)
        {
            String result = "";
            for (int i = str.Length-1; i >= 0; i--)
            {
                if (str.ElementAt<char>(i) == afterele) break;
                result += str.ElementAt<char>(i).ToString();
            }
            return result;
        }
        //获取指令
        public static String getCommandString(String str)
        {
            String command = "";
            command = getStringBefore(str, ';');//获取分号之前的内容
            //从左到右，从开始有字的部分到空格之前
            String temp = "";
            for(int i = 0; i < command.Length; i++)
            {
                if (temp != "" &&( command.ElementAt<char>(i) == ' ' || command.ElementAt<char>(i) == '\t')) break;
                if (command.ElementAt<char>(i)!=' ' || command.ElementAt<char>(i) == '\t')
                {
                    temp += command.ElementAt<char>(i).ToString();
                }
            }
            return temp;
        }
        //获取操作变量
        public static String[] getValueString(String str)
        {
            String temp1 = getStringBefore(str, ';');//获取分号之前的部分
            //从右到左，从开始有字的部分到空格之前
            String temp2 = "";
            for(int i = temp1.Length - 1; i >= 0; i--)
            {
                if (temp1.ElementAt<char>(i) == ' ' && temp2 != "") break;
                if(temp1.ElementAt<char>(i)!=' ')
                {
                    temp2 += temp1.ElementAt<char>(i).ToString();
                }
            }
            String temp3 = "";
            //字符串倒置
            for(int i = temp2.Length - 1; i >= 0; i--)
            {
                temp3 += temp2.ElementAt<char>(i).ToString();
            }
            //检验该行是否为不带操作变量的指令
            if (temp3 == getCommandString(str))
            {
                String[] empty = new String[1];
                empty[0] = "";
                return empty;
            }
            //统计逗号的个数
            int num_of_dh = 0;
            for(int i = 0; i < temp3.Length; i++)
            {
                if (temp3.ElementAt<char>(i) == ',') ++num_of_dh;
            }
            String[] result = new String[num_of_dh + 1];
            //逐个存入变量名
            int loop1 = 0;
            for(int i = 0; i < result.Length; i++)
            {
                while (loop1 < temp3.Length)
                {
                    if (temp3.ElementAt<char>(loop1) == ',')
                    {
                        ++loop1;
                        break;
                    }
                    result[i] += temp3.ElementAt<char>(loop1).ToString();
                    ++loop1;
                }
            }
            return result;
        }
        //获取CSV数据文件里的数据
        public static String[] getValueInCSV(String str)
        {
            //统计逗号的个数
            int num_of_dh = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.ElementAt<char>(i) == ',') ++num_of_dh;
            }
            String[] result = new String[num_of_dh + 1];
            //逐个存入变量名
            int loop1 = 0;
            for (int i = 0; i < result.Length; i++)
            {
                while (loop1 < str.Length)
                {
                    if (str.ElementAt<char>(loop1) == ',')
                    {
                        ++loop1;
                        break;
                    }
                    result[i] += str.ElementAt<char>(loop1).ToString();
                    ++loop1;
                }
            }
            return result;
        }
        //根据数字转换成Excel列号
        public static String getExcelColumn(int num)
        {
            String column = "";
            int x = num;
            const int letter = 26;
            while (x > 0)
            {
                int temp = 'A' + ((x - 1) % letter);
                column += (char)temp;
                x = x / letter;
            }
            //倒置输出字符
            String result = "";
            for(int i = column.Length - 1; i >= 0; i--)
            {
                result += column.ElementAt<char>(i).ToString();
            }
            return result;
        }
        // 获取哈希值
        public static object getHashValue(object key, Hashtable hashtable)
        {
            foreach(DictionaryEntry temp in hashtable)
            {
                if (temp.Key.Equals(key)) return temp.Value;
            }
            return null;
        }
        /// <summary>
        /// Used for verifying whether a string is a legal integer
        /// </summary>
        /// <param name="value">the string for verifying</param>
        /// <returns></returns>
        public static bool IsInteger(string value)
        {
            if (value == "" || string.IsNullOrEmpty(value)) return false;
            int result;
            return int.TryParse(value, out result);
        }
        /// <summary>
        /// 判断字符串是否为合法IP地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsValidIP(string ip)
        {
            if (ip == "" || string.IsNullOrEmpty(ip)) return false;
            IPAddress IP;
            return IPAddress.TryParse(ip, out IP);
        }
        /// <summary>
        /// 将文件大小用字符串表示
        /// </summary>
        /// <param name="byteLength"></param>
        /// <returns></returns>
        public static string converSizeToString(long byteLength)
        {
            string result;
            const double dot = 1024;
            double temp_result;
            temp_result = (double)byteLength / dot;
            // B
            if (temp_result < 1)
            {
                result = byteLength.ToString("f0") + " B";
                return result;
            }
            // KB
            if (temp_result / dot < 1)
            {
                result = temp_result.ToString("f2") + " KB";
                return result;
            }
            // MB
            temp_result /= dot;
            if (temp_result / dot < 1)
            {
                result = temp_result.ToString("f2") + " MB";
                return result;
            }
            // GB
            temp_result /= dot;
            result = temp_result.ToString("f2") + " GB";
            return result;
        }
        /// 判断文件是否为图片
        /// </summary>
        /// <param name="path">文件的完整路径</param>
        /// <returns>返回结果</returns>
        public static Boolean IsImage(string path)
        {
            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(path);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
