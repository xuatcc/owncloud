using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace custom_cloud.subMainForm
{
    /// <summary>
    /// 修改用户信息的窗体
    /// </summary>
    public partial class UserModifyForm : Form
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        UserInfo User_Info;
        /// <summary>
        /// 用户本地信息
        /// </summary>
        UserLocalInfo User_LocalInfo = new UserLocalInfo();

        public UserModifyForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        public void setUserInfo(UserInfo userInfo)
        {
            User_Info = userInfo;
            initializeConfig();
            initializeWidget();
        }
        void initializeConfig()
        {
            /* 读取本地用户配置文件 */
            User_LocalInfo = MyConfig.getUserLocalInfo(User_Info.UserID);
        }
        void initializeWidget()
        {

        }
    }
}
