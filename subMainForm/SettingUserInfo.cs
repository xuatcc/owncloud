using custom_cloud.subMainForm.subUserInfo;
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
    public partial class SettingUserInfo : Form
    {
        /// <summary>
        /// 用户信息，从上一个窗体传递
        /// </summary>
        UserInfo User_Info = new UserInfo();
        /// <summary>
        /// 用户本地信息
        /// </summary>
        UserLocalInfo User_LocalInfo = new UserLocalInfo();
        public SettingUserInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 从父窗体设置用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="userLocalInfo"></param>
        public void setUserInfo(UserInfo userInfo, UserLocalInfo userLocalInfo)
        {
            User_Info = userInfo;
            User_LocalInfo = userLocalInfo;

            this.Text +=  "-" + User_Info.UserID;

            initializeConfig();
            initializeWidget();
        }
        void initializeConfig()
        {

        }
        void initializeWidget()
        {
            label_userName.BackColor = Color.Transparent;
            label_password.BackColor = Color.Transparent;
            label_syncPath.BackColor = Color.Transparent;
            label_syncServerAddress.BackColor = Color.Transparent;

            textBox_userName.Text = User_Info.UserName;
            textBox_password.PasswordChar = '*';
            textBox_password.Text = User_Info.Password;
            textBox_syncPath.Text = User_LocalInfo.SyncPath;
            textBox_syncServerAddress.Text = User_Info.SyncServerAddress;
        }
        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void btn_Click_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_folderBrowser)) selectSyncPath();
            if (sender.Equals(button_modifyPassword)) modiryPassword();
        }
        /// <summary>
        /// 光标移入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void btn_MouseEnter_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_confirm)) button_confirm.Image = Properties.Resources.enter;
            if (sender.Equals(button_cancel)) button_cancel.Image = Properties.Resources.enter;
        }
        /// <summary>
        /// 光标移出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ea"></param>
        void btn_MouseLeave_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_confirm)) button_confirm.Image = Properties.Resources.down;
            if (sender.Equals(button_cancel)) button_cancel.Image = Properties.Resources.down;
        }
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mea"></param>
        void btn_MouseDown_Event(object sender, MouseEventArgs mea)
        {
            if (sender.Equals(button_confirm)) button_confirm.Image = Properties.Resources.down;
            if (sender.Equals(button_cancel)) button_cancel.Image = Properties.Resources.down;
        }
        /// <summary>
        /// 鼠标抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mea"></param>
        void btn_MouseUp_Event(object sender, MouseEventArgs mea)
        {
            if (sender.Equals(button_confirm)) button_confirm.Image = Properties.Resources.enter;
            if (sender.Equals(button_cancel)) button_cancel.Image = Properties.Resources.enter;
        }
        /// <summary>
        /// 保存用户本地信息
        /// </summary>
        void saveUserLocalInfo()
        {
            User_LocalInfo.SyncPath = textBox_syncPath.Text;
            User_LocalInfo.Password = textBox_password.Text;
            MyConfig.createOrModifyUserLocalInfo(User_LocalInfo);
        }
        /// <summary>
        /// 向服务器提交用户信息
        /// </summary>
        void commitUserInfo()
        {

        }
        /// <summary>
        /// 选择同步目录
        /// </summary>
        void selectSyncPath()
        {
            if (folderBrowserDialog_syncPath.ShowDialog() == DialogResult.OK)
            {
                textBox_syncPath.Text = folderBrowserDialog_syncPath.SelectedPath;
            }
        }
        /// <summary>
        /// 更改密码
        /// </summary>
        void modiryPassword()
        {
            SettingUserPassword settingUserPassword = new SettingUserPassword();
            DialogResult dialogResult = settingUserPassword.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                textBox_password.Text = settingUserPassword.NewPassword;
            }
            settingUserPassword.Close();
        }
    }
}
