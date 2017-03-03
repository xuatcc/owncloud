using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace custom_cloud
{
    /// <summary>
    /// 请求类
    /// </summary>
    class Order
    {
        public Dictionary<string, string> OrderCodes = new Dictionary<string, string>();
        const string ORDER_LOGIN = "ORDER_LOGIN";
        const string ORDER_REGISTER = "ORDER_REGISTER";
        const string ORDER_CHECK_STATUS = "ORDER_CHECK_STATUS";
        const string ORDER_LOG_OUT = "ORDER_LOG_OUT";
        public static string _ORDER_LOGIN = "ORDER_LOGIN";
        public static string _ORDER_REGISTER = "ORDER_REGISTER";
        public static string _ORDER_CHECK_STATUS = "ORDER_CHECK_STATUS";
        public static string _ORDER_LOG_OUT = "ORDER_LOG_OUT";
        public const string FLAG_START = "FLAG_START";
        public const string FLAG_STOP = "FLAG_STOP";
        public Order()
        {
            OrderCodes.Add("login", ORDER_LOGIN);
            OrderCodes.Add("register", ORDER_REGISTER);
            OrderCodes.Add("check_status", ORDER_CHECK_STATUS);
            OrderCodes.Add("log_out", ORDER_LOG_OUT);
        }
        string order_code;
        public string OrderCode
        {
            get { return order_code; }
            set { order_code = value; }
        }
    }
}
