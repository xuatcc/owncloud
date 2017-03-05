using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace custom_cloud.subMainForm.subUserInfo
{
    public partial class SettingUserPassword : Form
    {
        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassword
        {
            get { return textBox_newPassword.Text; }
        }
        public SettingUserPassword()
        {
            InitializeComponent();
            initializeWidget();
        }
        void initializeWidget()
        {
            label_originPassword.BackColor = Color.Transparent;
            label_newPassword.BackColor = Color.Transparent;
            label_confirm.BackColor = Color.Transparent;

            textBox_originPassword.PasswordChar = '*';
            textBox_newPassword.PasswordChar = '*';
            textBox_confirm.PasswordChar = '*';
        }
        void btn_Click_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_confirm)) confirm();
        }
        void btn_MouseEnter_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_confirm)) button_confirm.Image = Properties.Resources.enter;
            if (sender.Equals(button_cancel)) button_cancel.Image = Properties.Resources.enter;
        }
        void btn_MouseLeave_Event(object sender, EventArgs ea)
        {
            if (sender.Equals(button_confirm)) button_confirm.Image = Properties.Resources.down;
            if (sender.Equals(button_cancel)) button_cancel.Image = Properties.Resources.down;
        }
        void btn_MouseDown_Event(object sender, MouseEventArgs ea)
        {
            
            if (sender.Equals(button_confirm)) button_confirm.Image = Properties.Resources.down;
            if (sender.Equals(button_cancel)) button_cancel.Image = Properties.Resources.down;
            
        }
        void btn_MouseUp_Event(object sender, MouseEventArgs ea)
        {
            
            if (sender.Equals(button_confirm)) button_confirm.Image = Properties.Resources.enter;
            if (sender.Equals(button_cancel)) button_cancel.Image = Properties.Resources.enter;
            
        }
        /// <summary>
        /// 检查新密码是否一致
        /// </summary>
        bool checkNewPasswordCorrect()
        {
            return textBox_confirm.Text.Equals(textBox_newPassword.Text);
        }
        /// <summary>
        /// 检查旧密码是否匹配
        /// </summary>
        void checkOldPassword()
        {

        }
        /// <summary>
        /// 更改成功
        /// </summary>
        void confirm()
        {
            if (!checkNewPasswordCorrect())
            {
                MessageBox.Show("两次输入的新密码不一致!");
                button_confirm.Image = Properties.Resources.down;
                return;
            }
            checkOldPassword();
            this.DialogResult = DialogResult.OK;
        }
    }
}
