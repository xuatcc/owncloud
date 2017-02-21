using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections;

namespace custom_cloud
{
    class JsonHelper
    {
       
        /// <summary>
        /// 对象序列化
        /// </summary>
        /// <returns></returns>
        public static string getSerializeString(object msg)
        {
            return JsonConvert.SerializeObject(msg);
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static T getDeserializeObject<T>(string msg)
        {
            return JsonConvert.DeserializeObject<T>(msg);
        }
        /// <summary>
        /// 将字符串转换为UTF8编码字符串
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string getUTF8String(string msg)
        {
            byte[] b = Encoding.Default.GetBytes(msg);
            return Encoding.UTF8.GetString(b);
        }
    }
}
