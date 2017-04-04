/*
    *@by Benquicki
    *@in XJTU
    *@in 2017.2
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace custom_cloud.dialog
{
    /// <summary>
    /// 用于通知用户并执行删除文件操作的窗体
    /// </summary>
    public partial class DeleteFileDialog : Form
    {
        public DeleteFileDialog()
        {
            InitializeComponent();
            initializeWidget();
        }
        void initializeWidget()
        {
            label1.Parent = this;
            label1.BackColor = Color.Transparent;
        }
        /// <summary>
        /// 鼠标移入事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_MouseEnter_Event(object obj, EventArgs ea)
        {
            if (obj.Equals(button_confirm)) button_confirm.Image = Properties.Resources.enter;
            if (obj.Equals(button_cancel)) button_cancel.Image = Properties.Resources.enter;
        }
        /// <summary>
        /// 鼠标移出事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_MouseLeave_Event(object obj, EventArgs ea)
        {
            if (obj.Equals(button_confirm)) button_confirm.Image = Properties.Resources.down;
            if (obj.Equals(button_cancel)) button_cancel.Image = Properties.Resources.down;
        }
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_MouseDown_Event(object obj, MouseEventArgs ea)
        {
            if (obj.Equals(button_confirm)) button_confirm.Image = Properties.Resources.down;
            if (obj.Equals(button_cancel)) button_cancel.Image = Properties.Resources.down;
        }
        /// <summary>
        /// 鼠标抬起事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_MouseUp_Event(object obj, MouseEventArgs ea)
        {
            if (obj.Equals(button_confirm)) button_confirm.Image = Properties.Resources.enter;
            if (obj.Equals(button_cancel)) button_cancel.Image = Properties.Resources.enter;
        }
        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ea"></param>
        void btn_Click_Event(object obj, EventArgs ea)
        {
            if (obj.Equals(button_confirm))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            if (obj.Equals(button_cancel))
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
